using AMS.Base.DTO;
using AMS.DTO;
using AMS.ServiceAccess;
using AMS.ExceptionManager;
using AMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AMS.Common;

namespace AMS.Web.UI.Controllers
{
    public class OrganisationBranchMasterController : BaseController
    {
        IOrganisationBranchMasterServiceAccess _organisationBranchMasterServiceAcess = null;
        OrganisationBranchMasterBaseViewModel _organisationBranchMasterBaseViewModel = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        public OrganisationBranchMasterController()
        {
            _organisationBranchMasterServiceAcess = new OrganisationBranchMasterServiceAccess();
            _organisationBranchMasterBaseViewModel = new OrganisationBranchMasterBaseViewModel();
        }

        #region Controller Methods

        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["SuperUser"]) > 0 || Convert.ToInt32(Session["AcadMgr"]) > 0)
            {
                return View();
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        public ActionResult List(string actionMode)
        {
            try
            {
                OrganisationBranchMasterViewModel model = new OrganisationBranchMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("List", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }  

        [HttpGet]
        public ActionResult Create()
        {
            OrganisationBranchMasterViewModel model = new OrganisationBranchMasterViewModel();
            try
            {
                List<OrganisationDepartmentMaster> organisationDepartmentMaster = GetOrganisationDepartmentList();
                List<SelectListItem> organisationDepartmentMasterList = new List<SelectListItem>();
                foreach (OrganisationDepartmentMaster item in organisationDepartmentMaster)
                {
                    organisationDepartmentMasterList.Add(new SelectListItem { Text = item.DepartmentName, Value = item.ID.ToString() });
                }
                ViewBag.OrganisationDepartmentMaster = new SelectList(organisationDepartmentMasterList, "Value", "Text");

                List<OrganisationUniversityMaster> ListOrganisationUniversityMaster = GetListOrganisationUniversityMaster();
                List<SelectListItem> OrganisationUniversityMaster = new List<SelectListItem>();
                foreach (OrganisationUniversityMaster item in ListOrganisationUniversityMaster)
                {
                    OrganisationUniversityMaster.Add(new SelectListItem { Text = item.UniversityName, Value = item.universityID.ToString() });
                }
                ViewBag.OrganisationUniversityMaster = new SelectList(OrganisationUniversityMaster, "Value", "Text");

                model.IntroductionYear = 1950;

            }
            catch (Exception)
            {

                throw;
            }

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Create(OrganisationBranchMasterViewModel model, FormCollection Collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.OrganisationBranchMasterDTO != null)
                    {
                        model.OrganisationBranchMasterDTO.ConnectionString = _connectioString;
                        model.OrganisationBranchMasterDTO.DepartmentID =Convert.ToInt32( model.SelectedDepartmentID);
                        model.OrganisationBranchMasterDTO.UniversityID = Convert.ToInt32(model.SelectedUniversityID);
                        model.OrganisationBranchMasterDTO.BranchDescription = model.BranchDescription;
                        model.OrganisationBranchMasterDTO.BranchShortCode = model.BranchShortCode;
                        model.OrganisationBranchMasterDTO.PrintShortCode = model.PrintShortCode;
                        model.OrganisationBranchMasterDTO.CommonBranch = model.CommonBranch;
                        model.OrganisationBranchMasterDTO.IsCommonBranchApplicable = model.IsCommonBranchApplicable;
                        model.OrganisationBranchMasterDTO.IntroductionYear = model.IntroductionYear;
                        model.OrganisationBranchMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]); //model.CreatedBy;
                        IBaseEntityResponse<OrganisationBranchMaster> response = _organisationBranchMasterServiceAcess.InsertOrganisationBranchMaster(model.OrganisationBranchMasterDTO);
                        model.OrganisationBranchMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.OrganisationBranchMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("Please review your form");
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            OrganisationBranchMasterViewModel model = new OrganisationBranchMasterViewModel();
            try
            {
                List<OrganisationDepartmentMaster> organisationDepartmentMaster = GetOrganisationDepartmentList();
                List<SelectListItem> organisationDepartmentMasterList = new List<SelectListItem>();
                foreach (OrganisationDepartmentMaster item in organisationDepartmentMaster)
                {
                    organisationDepartmentMasterList.Add(new SelectListItem { Text = item.DepartmentName, Value = item.ID.ToString() });
                }

                List<OrganisationUniversityMaster> ListOrganisationUniversityMaster = GetListOrganisationUniversityMaster();
                List<SelectListItem> OrganisationUniversityMaster = new List<SelectListItem>();
                foreach (OrganisationUniversityMaster item in ListOrganisationUniversityMaster)
                {
                    OrganisationUniversityMaster.Add(new SelectListItem { Text = item.UniversityName, Value = item.universityID.ToString() });
                }

                model.OrganisationBranchMasterDTO = new OrganisationBranchMaster();
                model.OrganisationBranchMasterDTO.ID = id;
                model.OrganisationBranchMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<OrganisationBranchMaster> response = _organisationBranchMasterServiceAcess.SelectByID(model.OrganisationBranchMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.OrganisationBranchMasterDTO.ID = response.Entity.ID;
                    model.OrganisationBranchMasterDTO.BranchDescription = response.Entity.BranchDescription;
                    model.OrganisationBranchMasterDTO.BranchShortCode = response.Entity.BranchShortCode;
                    model.OrganisationBranchMasterDTO.PrintShortCode = response.Entity.PrintShortCode;
                    model.OrganisationBranchMasterDTO.IntroductionYear = response.Entity.IntroductionYear;
                    model.OrganisationBranchMasterDTO.CommonBranch = response.Entity.CommonBranch;
                    model.OrganisationBranchMasterDTO.DurationInDays = response.Entity.DurationInDays;
                    model.OrganisationBranchMasterDTO.IsCommonBranchApplicable = response.Entity.IsCommonBranchApplicable;
                    model.OrganisationBranchMasterDTO.DepartmentBranchID = response.Entity.DepartmentBranchID;
                    ViewBag.OrganisationUniversityMaster = new SelectList(OrganisationUniversityMaster, "Value", "Text", response.Entity.UniversityID.ToString());
                    ViewBag.OrganisationDepartmentMaster = new SelectList(organisationDepartmentMasterList, "Value", "Text", response.Entity.DepartmentID.ToString());

                }
                return PartialView(model);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        public ActionResult Edit(OrganisationBranchMasterViewModel model)
        {
          try
            {
            if (ModelState.IsValid)
            {
                if (model != null && model.OrganisationBranchMasterDTO != null)
                {
                    if (model != null && model.OrganisationBranchMasterDTO != null)
                    {
                        model.OrganisationBranchMasterDTO.ConnectionString = _connectioString;
                        model.OrganisationBranchMasterDTO.BranchDescription = model.BranchDescription;
                        model.OrganisationBranchMasterDTO.BranchShortCode = model.BranchShortCode;
                        model.OrganisationBranchMasterDTO.PrintShortCode = model.PrintShortCode;
                        model.OrganisationBranchMasterDTO.IntroductionYear = model.IntroductionYear;
                        model.OrganisationBranchMasterDTO.IsCommonBranchApplicable = model.IsCommonBranchApplicable;
                        model.OrganisationBranchMasterDTO.CommonBranch = model.CommonBranch;
                        model.OrganisationBranchMasterDTO.DurationInDays = model.DurationInDays;
                        model.OrganisationBranchMasterDTO.DepartmentBranchID = model.DepartmentBranchID;
                        model.OrganisationBranchMasterDTO.DepartmentID = Convert.ToInt32(model.SelectedDepartmentID);
                        model.OrganisationBranchMasterDTO.UniversityID = Convert.ToInt32(model.SelectedUniversityID);
                        model.OrganisationBranchMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]); //model.ModifiedBy;
                        IBaseEntityResponse<OrganisationBranchMaster> response = _organisationBranchMasterServiceAcess.UpdateOrganisationBranchMaster(model.OrganisationBranchMasterDTO);
                        model.OrganisationBranchMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }

                return Json(model.OrganisationBranchMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }

             }
          catch (Exception)
          {

              throw;
          }

        }

        //[HttpGet]
        //public ActionResult Delete(int ID)
        //{

        //    OrganisationBranchMasterViewModel model = new OrganisationBranchMasterViewModel();

        //    model.OrganisationBranchMasterDTO = new OrganisationBranchMaster();
        //    model.OrganisationBranchMasterDTO.ID = ID;
        //    model.OrganisationBranchMasterDTO.ConnectionString = _connectioString;

        //    IBaseEntityResponse<OrganisationBranchMaster> response = _organisationBranchMasterServiceAcess.SelectByID(model.OrganisationBranchMasterDTO);

        //    if (response != null && response.Entity != null)
        //    {
        //        model.OrganisationBranchMasterDTO.ID = response.Entity.ID;
        //        model.OrganisationBranchMasterDTO.DepartmentBranchID = response.Entity.DepartmentBranchID;
        //    }

        //    return PartialView(model);
        //}



        //[HttpPost]
        //public ActionResult Delete(OrganisationBranchMasterViewModel model)
        //{
        //    IBaseEntityResponse<OrganisationBranchMaster> response = null;
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            if (model.ID > 0)
        //            {
        //        OrganisationBranchMaster OrganisationBranchMasterDTO = new OrganisationBranchMaster();
        //        OrganisationBranchMasterDTO.ConnectionString = _connectioString;
        //        OrganisationBranchMasterDTO.ID = model.ID;
        //        OrganisationBranchMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);// model.DeletedBy;
        //        response = _organisationBranchMasterServiceAcess.DeleteOrganisationBranchMaster(OrganisationBranchMasterDTO);
        //        model.OrganisationBranchMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
        //    }
        //            return Json(model.OrganisationBranchMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json("Please review your form");
        //    }

        //    }
        // catch (Exception)
        //  {

        //      throw;
        //  }

        //}


        
        public ActionResult Delete(int ID)
        {
            OrganisationBranchMasterViewModel model = new OrganisationBranchMasterViewModel();
            IBaseEntityResponse<OrganisationBranchMaster> response = null;
            try
            {
                //if (!ModelState.IsValid)
                //{
                if (ID > 0)
                {
                    OrganisationBranchMaster OrganisationBranchMasterDTO = new OrganisationBranchMaster();
                    OrganisationBranchMasterDTO.ConnectionString = _connectioString;
                    OrganisationBranchMasterDTO.ID = ID;
                    OrganisationBranchMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);// model.DeletedBy;
                    response = _organisationBranchMasterServiceAcess.DeleteOrganisationBranchMaster(OrganisationBranchMasterDTO);
                    model.OrganisationBranchMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);

                    return Json(model.OrganisationBranchMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }
                else {
                    return Json("Please review your form");
                }
                    
                //}
                //else
                //{
                //    return Json("Please review your form");
                //}

            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion

        #region Methods

        public IEnumerable<OrganisationBranchMasterViewModel> GetOrganisationBranchMaster(out int TotalRecords)
        {
            OrganisationBranchMasterSearchRequest searchRequest = new OrganisationBranchMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "CreatedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
            }
            List<OrganisationBranchMasterViewModel> listOrganisationBranchMasterViewModel = new List<OrganisationBranchMasterViewModel>();
            List<OrganisationBranchMaster> listOrganisationBranchMaster = new List<OrganisationBranchMaster>();
            IBaseEntityCollectionResponse<OrganisationBranchMaster> baseEntityCollectionResponse = _organisationBranchMasterServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationBranchMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (OrganisationBranchMaster item in listOrganisationBranchMaster)
                    {
                        OrganisationBranchMasterViewModel generalLocationMasterViewModel = new OrganisationBranchMasterViewModel();
                        generalLocationMasterViewModel.OrganisationBranchMasterDTO = item;
                        listOrganisationBranchMasterViewModel.Add(generalLocationMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listOrganisationBranchMasterViewModel;
        }

        #endregion

        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc     
            IEnumerable<OrganisationBranchMasterViewModel> filteredOrganisationBranchMaster;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "BranchDescription";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(BranchDescription Like '%" + param.sSearch + "%' or BranchShortCode Like '%" + param.sSearch + "%'or PrintShortCode Like '%" + param.sSearch + "%')";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "BranchShortCode";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(BranchDescription Like '%" + param.sSearch + "%' or BranchShortCode Like '%" + param.sSearch + "%'or PrintShortCode Like '%" + param.sSearch + "%')";      //this "if" block is added for search functionality
                    }
                    break;

                case 2:
                    _sortBy = "PrintShortCode";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(BranchDescription Like '%" + param.sSearch + "%' or BranchShortCode Like '%" + param.sSearch + "%'or PrintShortCode Like '%" + param.sSearch + "%')";      //this "if" block is added for search functionality
                    }
                    break;

            }

            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            //Check whether the companies should be filtered by keyword     
            filteredOrganisationBranchMaster = GetOrganisationBranchMaster(out TotalRecords);              
            var displayedPosts = filteredOrganisationBranchMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in displayedPosts select new[] { c.BranchDescription.ToString(), c.BranchShortCode.ToString(),c.PrintShortCode.ToString(), Convert.ToString(c.ID) };
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = TotalRecords,
                iTotalDisplayRecords = TotalRecords,
                aaData = result
            },
           JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}