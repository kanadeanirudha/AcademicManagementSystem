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
    public class OrganisationSemesterMasterController : BaseController
    {
        IOrganisationSemesterMasterServiceAccess _organisationSemesterMasterServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public OrganisationSemesterMasterController()
        {
            _organisationSemesterMasterServiceAcess = new OrganisationSemesterMasterServiceAccess();
        }

        #region Controller Methods

        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["SuperUser"]) > 0 || Convert.ToInt32(Session["AcadMgr"]) > 0 || Convert.ToInt32(Session["EstMgr"]) > 0)
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
                OrganisationSemesterMasterViewModel model = new OrganisationSemesterMasterViewModel();
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
            OrganisationSemesterMasterViewModel model = new OrganisationSemesterMasterViewModel();
            List<SelectListItem> li = new List<SelectListItem>();
            //li.Add(new SelectListItem { Text = "Select Type", Value = "0" });
            li.Add(new SelectListItem { Text = Resources.DisplayName_Even, Value = "E" });
            li.Add(new SelectListItem { Text = Resources.DisplayName_Odd, Value = "O" });
            ViewData["SemesterType"] = li;
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Create(OrganisationSemesterMasterViewModel model)
        {
            try
            {
            if (ModelState.IsValid)
            {
                if (model != null && model.OrganisationSemesterMasterDTO != null)
                {
                    model.OrganisationSemesterMasterDTO.ConnectionString = _connectioString;
                    model.OrganisationSemesterMasterDTO.OrgSemesterName = model.OrgSemesterName;
                    model.OrganisationSemesterMasterDTO.SemesterType = model.SemesterType;
                    model.OrganisationSemesterMasterDTO.SemesterCode = model.SemesterCode;
                    model.OrganisationSemesterMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]); //model.CreatedBy;
                   IBaseEntityResponse<OrganisationSemesterMaster> response = _organisationSemesterMasterServiceAcess.InsertOrganisationSemesterMaster(model.OrganisationSemesterMasterDTO);
                   model.OrganisationSemesterMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                }
                return Json(model.OrganisationSemesterMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            OrganisationSemesterMasterViewModel model = new OrganisationSemesterMasterViewModel();
            List<SelectListItem> li = new List<SelectListItem>();
            li.Add(new SelectListItem { Text = Resources.DisplayName_E, Value = "Even" });
            li.Add(new SelectListItem { Text = Resources.DisplayName_O, Value = "Odd" });

            model.OrganisationSemesterMasterDTO = new OrganisationSemesterMaster();
            model.OrganisationSemesterMasterDTO.ID = id;
            model.OrganisationSemesterMasterDTO.ConnectionString = _connectioString;

            IBaseEntityResponse<OrganisationSemesterMaster> response = _organisationSemesterMasterServiceAcess.SelectByID(model.OrganisationSemesterMasterDTO);

            if (response != null && response.Entity != null)
            {
                model.OrganisationSemesterMasterDTO.ID = response.Entity.ID;
                model.OrganisationSemesterMasterDTO.OrgSemesterName = response.Entity.OrgSemesterName;
                model.OrganisationSemesterMasterDTO.SemesterCode = response.Entity.SemesterCode;
                model.OrganisationSemesterMasterDTO.IsUserDefined = response.Entity.IsUserDefined;
                ViewData["SemesterType"] = new SelectList(li, "Text", "Value", response.Entity.SemesterType);

            }

            return PartialView(model);
        }
        
        [HttpPost]
        public ActionResult Edit(OrganisationSemesterMasterViewModel model)
        {
           try
            {
            if (ModelState.IsValid)
            {
                if (model != null && model.OrganisationSemesterMasterDTO != null)
                {
                    if (model != null && model.OrganisationSemesterMasterDTO != null)
                    {
                        model.OrganisationSemesterMasterDTO.ConnectionString = _connectioString;
                        model.OrganisationSemesterMasterDTO.OrgSemesterName = model.OrgSemesterName;
                        model.OrganisationSemesterMasterDTO.SemesterType = model.SemesterType;
                        model.OrganisationSemesterMasterDTO.SemesterCode = model.SemesterCode;
                        model.OrganisationSemesterMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);//model.ModifiedBy;
                        IBaseEntityResponse<OrganisationSemesterMaster> response = _organisationSemesterMasterServiceAcess.UpdateOrganisationSemesterMaster(model.OrganisationSemesterMasterDTO);
                        model.OrganisationSemesterMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }

                return Json(model.OrganisationSemesterMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }

            }
           catch (Exception ex)
           {
               _logException.Error(ex.Message);
               throw;
           }
        }

        //[HttpGet]
        //public ActionResult Delete(int ID)
        //{

        //    OrganisationSemesterMasterViewModel model = new OrganisationSemesterMasterViewModel();

        //    model.OrganisationSemesterMasterDTO = new OrganisationSemesterMaster();
        //    model.OrganisationSemesterMasterDTO.ID = ID;
        //    model.OrganisationSemesterMasterDTO.ConnectionString = _connectioString;

        //    IBaseEntityResponse<OrganisationSemesterMaster> response = _organisationSemesterMasterServiceAcess.SelectByID(model.OrganisationSemesterMasterDTO);

        //    if (response != null && response.Entity != null)
        //    {
        //        model.OrganisationSemesterMasterDTO.ID = response.Entity.ID;
        //    }

        //    return PartialView(model);
        //}



        //[HttpPost]
        //public ActionResult Delete(OrganisationSemesterMasterViewModel model)
        //{
        //  try
        //     {
        //      if (!ModelState.IsValid)
        //       {
        //        if (model.ID > 0)
        //        {
        //        OrganisationSemesterMaster OrganisationSemesterMasterDTO = new OrganisationSemesterMaster();
        //        OrganisationSemesterMasterDTO.ConnectionString = _connectioString;
        //        OrganisationSemesterMasterDTO.ID = model.ID;
        //        OrganisationSemesterMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);// model.DeletedBy;
        //        IBaseEntityResponse<OrganisationSemesterMaster> response = null;
        //        response = _organisationSemesterMasterServiceAcess.DeleteOrganisationSemesterMaster(OrganisationSemesterMasterDTO);
        //        model.OrganisationSemesterMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
        //     }
        //    return Json(model.OrganisationSemesterMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
        //     }
        //    else
        //    {
        //        return Json("Please review your form");
        //    }

        //    }
        //    catch (Exception ex)
        //    {
        //        _logException.Error(ex.Message);
        //        throw;
        //    }
        //}

        public ActionResult Delete(int ID)
        {
            OrganisationSemesterMasterViewModel model = new OrganisationSemesterMasterViewModel();
            try
            {
                if (ID > 0)
                {
                    if (ID > 0)
                    {
                        OrganisationSemesterMaster OrganisationSemesterMasterDTO = new OrganisationSemesterMaster();
                        OrganisationSemesterMasterDTO.ConnectionString = _connectioString;
                        OrganisationSemesterMasterDTO.ID = ID;
                        OrganisationSemesterMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);// model.DeletedBy;
                        IBaseEntityResponse<OrganisationSemesterMaster> response = null;
                        response = _organisationSemesterMasterServiceAcess.DeleteOrganisationSemesterMaster(OrganisationSemesterMasterDTO);
                        model.OrganisationSemesterMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    }
                    return Json(model.OrganisationSemesterMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("Please review your form");
                }

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        #endregion

        #region Methods

        public IEnumerable<OrganisationSemesterMasterViewModel> GetlistOrganisationSemesterMaster(out int TotalRecords)
        {
            OrganisationSemesterMasterSearchRequest searchRequest = new OrganisationSemesterMasterSearchRequest();
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
            List<OrganisationSemesterMasterViewModel> listOrganisationSemesterMasterViewModel = new List<OrganisationSemesterMasterViewModel>();
            List<OrganisationSemesterMaster> listOrganisationSemesterMaster = new List<OrganisationSemesterMaster>();
            IBaseEntityCollectionResponse<OrganisationSemesterMaster> baseEntityCollectionResponse = _organisationSemesterMasterServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationSemesterMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (OrganisationSemesterMaster item in listOrganisationSemesterMaster)
                    {
                        OrganisationSemesterMasterViewModel orgReligionMasterViewModel = new OrganisationSemesterMasterViewModel();
                        orgReligionMasterViewModel.OrganisationSemesterMasterDTO = item;
                        listOrganisationSemesterMasterViewModel.Add(orgReligionMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listOrganisationSemesterMasterViewModel;
        }

        #endregion
        #region
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {

            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
            int TotalRecords;
            IEnumerable<OrganisationSemesterMasterViewModel> filteredOrganisationSemesterMaster;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "OrgSemesterName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(OrgSemesterName Like '%" + param.sSearch + "%' or SemesterCode  Like '%" + param.sSearch + "%' or SemesterType Like '%" + param.sSearch + "%')";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "SemesterType";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(OrgSemesterName Like '%" + param.sSearch + "%' or SemesterCode Like '%" + param.sSearch + "%' or SemesterType  Like '%" + param.sSearch + "%')";      //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "SemesterCode";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(OrgSemesterName Like '%" + param.sSearch + "%' or SemesterCode Like '%" + param.sSearch + "%' or SemesterType  Like '%" + param.sSearch + "%')";    //this "if" block is added for search functionality
                    }
                    break;
            }

            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredOrganisationSemesterMaster = GetlistOrganisationSemesterMaster(out TotalRecords);              
            var displayedCaste = filteredOrganisationSemesterMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in displayedCaste select new[] { c.OrgSemesterName.ToString(), c.SemesterCode.ToString(), c.SemesterType.ToString(), Convert.ToString(c.ID), Convert.ToString(c.IsUserDefined) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}