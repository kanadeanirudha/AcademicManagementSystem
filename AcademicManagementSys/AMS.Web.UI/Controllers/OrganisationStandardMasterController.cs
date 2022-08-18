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
    public class OrganisationStandardMasterController : BaseController
    {
        IOrganisationStandardMasterServiceAccess _orgStandardMasterServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public OrganisationStandardMasterController()
        {
            _orgStandardMasterServiceAcess = new OrganisationStandardMasterServiceAccess();
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
                OrganisationStandardMasterViewModel model = new OrganisationStandardMasterViewModel();
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

        public ActionResult Create()
        {
            OrganisationStandardMasterViewModel model = new OrganisationStandardMasterViewModel();
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Create(OrganisationStandardMasterViewModel model)
        {
            try
            {
            if (ModelState.IsValid)
            {
                if (model != null && model.OrganisationStandardMasterDTO != null)
                {
                    model.OrganisationStandardMasterDTO.ConnectionString = _connectioString;
                    model.OrganisationStandardMasterDTO.Description = model.Description;
                    model.OrganisationStandardMasterDTO.StandardNumber = model.StandardNumber;
                    model.OrganisationStandardMasterDTO.CodeShortCode = model.CodeShortCode;
                    model.OrganisationStandardMasterDTO.PrintShortCode = model.PrintShortCode;
                    model.OrganisationStandardMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]); //model.CreatedBy;
                    IBaseEntityResponse<OrganisationStandardMaster> response = _orgStandardMasterServiceAcess.InsertOrganisationStandardMaster(model.OrganisationStandardMasterDTO);
                    model.OrganisationStandardMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                }
                return Json(model.OrganisationStandardMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            OrganisationStandardMasterViewModel model = new OrganisationStandardMasterViewModel();

            model.OrganisationStandardMasterDTO = new OrganisationStandardMaster();
            model.OrganisationStandardMasterDTO.ID = id;
            model.OrganisationStandardMasterDTO.ConnectionString = _connectioString;

            IBaseEntityResponse<OrganisationStandardMaster> response = _orgStandardMasterServiceAcess.SelectByID(model.OrganisationStandardMasterDTO);

            if (response != null && response.Entity != null)
            {
                model.OrganisationStandardMasterDTO.ID = response.Entity.ID;
                model.OrganisationStandardMasterDTO.Description = response.Entity.Description;
                model.OrganisationStandardMasterDTO.StandardNumber = response.Entity.StandardNumber;
                model.OrganisationStandardMasterDTO.CodeShortCode = response.Entity.CodeShortCode;
                model.OrganisationStandardMasterDTO.PrintShortCode = response.Entity.PrintShortCode;
                model.OrganisationStandardMasterDTO.IsUserDefined= response.Entity.IsUserDefined;
            }

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(OrganisationStandardMasterViewModel model)
        {
          try
            {
            if (ModelState.IsValid)
            {
                if (model != null && model.OrganisationStandardMasterDTO != null)
                {
                    if (model != null && model.OrganisationStandardMasterDTO != null)
                    {
                        model.OrganisationStandardMasterDTO.ConnectionString = _connectioString;
                        model.OrganisationStandardMasterDTO.Description = model.Description;
                        model.OrganisationStandardMasterDTO.StandardNumber = model.StandardNumber;
                        model.OrganisationStandardMasterDTO.CodeShortCode = model.CodeShortCode;
                        model.OrganisationStandardMasterDTO.PrintShortCode = model.PrintShortCode;
                        model.OrganisationStandardMasterDTO.CreatedBy = model.CreatedBy;
                        model.OrganisationStandardMasterDTO.CreatedDate = model.CreatedDate;
                        model.OrganisationStandardMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);//model.ModifiedBy;
                        IBaseEntityResponse<OrganisationStandardMaster> response = _orgStandardMasterServiceAcess.UpdateOrganisationStandardMaster(model.OrganisationStandardMasterDTO);
                        model.OrganisationStandardMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.OrganisationStandardMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        //    OrganisationStandardMasterViewModel model = new OrganisationStandardMasterViewModel();

        //    model.OrganisationStandardMasterDTO = new OrganisationStandardMaster();
        //    model.OrganisationStandardMasterDTO.ID = ID;
        //    model.OrganisationStandardMasterDTO.ConnectionString = _connectioString;

        //    IBaseEntityResponse<OrganisationStandardMaster> response = _orgStandardMasterServiceAcess.SelectByID(model.OrganisationStandardMasterDTO);

        //    if (response != null && response.Entity != null)
        //    {
        //        model.OrganisationStandardMasterDTO.ID = response.Entity.ID;
        //        model.OrganisationStandardMasterDTO.Description = response.Entity.Description;
        //        model.OrganisationStandardMasterDTO.StandardNumber = response.Entity.StandardNumber;
        //        model.OrganisationStandardMasterDTO.CodeShortCode = response.Entity.CodeShortCode;
        //        model.OrganisationStandardMasterDTO.PrintShortCode = response.Entity.PrintShortCode;
        //    }

        //    return PartialView(model);
        //}



        //[HttpPost]
        //public ActionResult Delete(OrganisationStandardMasterViewModel model)
        //{
        //    try
        //    {
        //    if (!ModelState.IsValid)
        //    {
        //        if (model.ID > 0)
        //        {
        //            OrganisationStandardMaster _orgStandardMasterDTO = new OrganisationStandardMaster();
        //            _orgStandardMasterDTO.ConnectionString = _connectioString;
        //            _orgStandardMasterDTO.ID = model.ID;
        //            _orgStandardMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);// model.DeletedBy;
        //            IBaseEntityResponse<OrganisationStandardMaster> response = _orgStandardMasterServiceAcess.DeleteOrganisationStandardMaster(_orgStandardMasterDTO);
        //            model.OrganisationStandardMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
        //        }
        //        return Json(model.OrganisationStandardMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json("Please review your form");
        //    }

        //    }
        // catch (Exception ex)
        //    {
        //        _logException.Error(ex.Message);
        //        throw;
        //    }

        //}

        
        public ActionResult Delete(int ID)
        {
            OrganisationStandardMasterViewModel model = new OrganisationStandardMasterViewModel();
            try
            {
                if (ID > 0)
                {
                    if (ID > 0)
                    {
                        OrganisationStandardMaster _orgStandardMasterDTO = new OrganisationStandardMaster();
                        _orgStandardMasterDTO.ConnectionString = _connectioString;
                        _orgStandardMasterDTO.ID = ID;
                        _orgStandardMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);// model.DeletedBy;
                        IBaseEntityResponse<OrganisationStandardMaster> response = _orgStandardMasterServiceAcess.DeleteOrganisationStandardMaster(_orgStandardMasterDTO);
                        model.OrganisationStandardMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    }
                    return Json(model.OrganisationStandardMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        public IEnumerable<OrganisationStandardMasterViewModel> GetOrganisationStandardMaster(out int TotalRecords)
        {
            OrganisationStandardMasterSearchRequest searchRequest = new OrganisationStandardMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.sortBy = "CreatedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.sortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                }
            }
            else
            {
                searchRequest.sortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
            }
            List<OrganisationStandardMasterViewModel> listOrganisationStandardMasterViewModel = new List<OrganisationStandardMasterViewModel>();
            List<OrganisationStandardMaster> listOrganisationStandardMaster = new List<OrganisationStandardMaster>();
            IBaseEntityCollectionResponse<OrganisationStandardMaster> baseEntityCollectionResponse = _orgStandardMasterServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationStandardMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (OrganisationStandardMaster item in listOrganisationStandardMaster)
                    {
                        OrganisationStandardMasterViewModel _orgStandardMasterViewModel = new OrganisationStandardMasterViewModel();
                        _orgStandardMasterViewModel.OrganisationStandardMasterDTO = item;
                        listOrganisationStandardMasterViewModel.Add(_orgStandardMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listOrganisationStandardMasterViewModel;
        }

        #endregion
        #region
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc      
            IEnumerable<OrganisationStandardMasterViewModel> filteredOrganisationStandardMaster;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "Description";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(Description Like '%" + param.sSearch + "%' or CodeShortCode Like '%" + param.sSearch + "%'   or StandardNumber Like '%" + param.sSearch + "%'  or PrintShortCode Like '%" + param.sSearch + "%')";   //this "if" block is added for search functionality      //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "StandardNumber";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(Description Like '%" + param.sSearch + "%' or CodeShortCode Like '%" + param.sSearch + "%'   or StandardNumber Like '%" + param.sSearch + "%'  or PrintShortCode Like '%" + param.sSearch + "%')";   //this "if" block is added for search functionality
                    }
                    break;

                case 2:
                    _sortBy = "CodeShortCode";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(Description Like '%" + param.sSearch + "%' or CodeShortCode Like '%" + param.sSearch + "%'   or StandardNumber Like '%" + param.sSearch + "%'  or PrintShortCode Like '%" + param.sSearch + "%')";    //this "if" block is added for search functionality
                    }
                    break;

            
             case 3:
                    _sortBy = "PrintShortCode";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(Description Like '%" + param.sSearch + "%' or CodeShortCode Like '%" + param.sSearch + "%'   or StandardNumber Like '%" + param.sSearch + "%'  or PrintShortCode Like '%" + param.sSearch + "%')";      //this "if" block is added for search functionality
                    }
                    break;

            }

            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredOrganisationStandardMaster = GetOrganisationStandardMaster(out TotalRecords);
            var records = filteredOrganisationStandardMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { c.Description.ToString(), c.StandardNumber.ToString(), c.CodeShortCode.ToString(), c.PrintShortCode.ToString(), Convert.ToString(c.ID), Convert.ToString(c.IsUserDefined) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}