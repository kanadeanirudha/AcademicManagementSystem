using AMS.Base.DTO;
using AMS.DTO;
using AMS.ServiceAccess;
using AMS.ViewModel;
using AMS.ExceptionManager;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AMS.Common;

namespace AMS.Web.UI.Controllers
{
    public class OrganisationSubjectTypeMasterController : BaseController
    {
        IOrganisationSubjectTypeMasterServiceAccess _organisationSubjectTypeMasterServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public OrganisationSubjectTypeMasterController()
        {
            _organisationSubjectTypeMasterServiceAcess = new OrganisationSubjectTypeMasterServiceAccess();
           
        }

        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" )
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
                OrganisationSubjectTypeMasterViewModel model = new OrganisationSubjectTypeMasterViewModel();
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
            OrganisationSubjectTypeMasterViewModel model = new OrganisationSubjectTypeMasterViewModel();
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Create(OrganisationSubjectTypeMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.OrganisationSubjectTypeMasterDTO != null)
                    {
                        model.OrganisationSubjectTypeMasterDTO.ConnectionString = _connectioString;
                        model.OrganisationSubjectTypeMasterDTO.TypeName = model.TypeName;
                        model.OrganisationSubjectTypeMasterDTO.TypeShortCode = model.TypeShortCode;
                        model.OrganisationSubjectTypeMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<OrganisationSubjectTypeMaster> response = _organisationSubjectTypeMasterServiceAcess.InsertOrganisationSubjectTypeMaster(model.OrganisationSubjectTypeMasterDTO);
                        model.OrganisationSubjectTypeMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.OrganisationSubjectTypeMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Content("Please review your form");
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
            try
            {
                OrganisationSubjectTypeMasterViewModel model = new OrganisationSubjectTypeMasterViewModel();
                model.OrganisationSubjectTypeMasterDTO = new OrganisationSubjectTypeMaster();
                model.OrganisationSubjectTypeMasterDTO.ID =Convert.ToInt16(id);
                model.OrganisationSubjectTypeMasterDTO.ConnectionString = _connectioString;
                IBaseEntityResponse<OrganisationSubjectTypeMaster> response = _organisationSubjectTypeMasterServiceAcess.SelectByID(model.OrganisationSubjectTypeMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.OrganisationSubjectTypeMasterDTO.ID = response.Entity.ID;
                    model.OrganisationSubjectTypeMasterDTO.TypeName = response.Entity.TypeName;
                    model.OrganisationSubjectTypeMasterDTO.TypeShortCode = response.Entity.TypeShortCode;                 
                }
                return PartialView(model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
      
        [HttpPost]
        public ActionResult Edit(OrganisationSubjectTypeMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.OrganisationSubjectTypeMasterDTO != null)
                    {
                        model.OrganisationSubjectTypeMasterDTO.ConnectionString = _connectioString;
                        model.OrganisationSubjectTypeMasterDTO.TypeName = model.TypeName;
                        model.OrganisationSubjectTypeMasterDTO.TypeShortCode = model.TypeShortCode;
                        model.OrganisationSubjectTypeMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<OrganisationSubjectTypeMaster> response = _organisationSubjectTypeMasterServiceAcess.UpdateOrganisationSubjectTypeMaster(model.OrganisationSubjectTypeMasterDTO);
                        model.OrganisationSubjectTypeMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                    return Json(model.OrganisationSubjectTypeMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Content("Please review your form");
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
        //    OrganisationSubjectTypeMasterViewModel model = new OrganisationSubjectTypeMasterViewModel();
        //    model.OrganisationSubjectTypeMasterDTO = new OrganisationSubjectTypeMaster();
        //    model.OrganisationSubjectTypeMasterDTO.ID = Convert.ToInt16(ID);
        //    return PartialView(model);
        //}



        //[HttpPost]
        //public ActionResult Delete(OrganisationSubjectTypeMasterViewModel model)
        //{
        //    try
        //    {
        //        if (model.ID > 0)
        //        {
        //            OrganisationSubjectTypeMaster OrganisationSubjectTypeMasterDTO = new OrganisationSubjectTypeMaster();
        //            OrganisationSubjectTypeMasterDTO.ConnectionString = _connectioString;
        //            OrganisationSubjectTypeMasterDTO.ID = model.ID;
        //            OrganisationSubjectTypeMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
        //           IBaseEntityResponse<OrganisationSubjectTypeMaster> response = _organisationSubjectTypeMasterServiceAcess.DeleteOrganisationSubjectTypeMaster(OrganisationSubjectTypeMasterDTO);
        //           model.OrganisationSubjectTypeMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
        //           return Json(model.OrganisationSubjectTypeMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
        //        }
        //        else
        //        {
        //            return Json("Please review your form");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logException.Error(ex.Message);
        //        throw;
        //    }
        //}

        public ActionResult Delete(short ID)
        {
            OrganisationSubjectTypeMasterViewModel model = new OrganisationSubjectTypeMasterViewModel();
            try
            {
                if (ID > 0)
                {
                    OrganisationSubjectTypeMaster OrganisationSubjectTypeMasterDTO = new OrganisationSubjectTypeMaster();
                    OrganisationSubjectTypeMasterDTO.ConnectionString = _connectioString;
                    OrganisationSubjectTypeMasterDTO.ID = ID;
                    OrganisationSubjectTypeMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<OrganisationSubjectTypeMaster> response = _organisationSubjectTypeMasterServiceAcess.DeleteOrganisationSubjectTypeMaster(OrganisationSubjectTypeMasterDTO);
                    model.OrganisationSubjectTypeMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    return Json(model.OrganisationSubjectTypeMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public IEnumerable<OrganisationSubjectTypeMasterViewModel> GetOrganisationSubjectTypeMaster(out int TotalRecords)
        {
            OrganisationSubjectTypeMasterSearchRequest searchRequest = new OrganisationSubjectTypeMasterSearchRequest();
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
            List<OrganisationSubjectTypeMasterViewModel> listOrganisationSubjectTypeMasterViewModel = new List<OrganisationSubjectTypeMasterViewModel>();
            List<OrganisationSubjectTypeMaster> listOrganisationSubjectTypeMaster = new List<OrganisationSubjectTypeMaster>();
            IBaseEntityCollectionResponse<OrganisationSubjectTypeMaster> baseEntityCollectionResponse = _organisationSubjectTypeMasterServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationSubjectTypeMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (OrganisationSubjectTypeMaster item in listOrganisationSubjectTypeMaster)
                    {
                        OrganisationSubjectTypeMasterViewModel organisationMediumMasterViewModel = new OrganisationSubjectTypeMasterViewModel();
                        organisationMediumMasterViewModel.OrganisationSubjectTypeMasterDTO = item;
                        listOrganisationSubjectTypeMasterViewModel.Add(organisationMediumMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listOrganisationSubjectTypeMasterViewModel;
        }
        #endregion

        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<OrganisationSubjectTypeMasterViewModel> filteredOrganisationSubjectTypeMaster;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "TypeName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "TypeName Like '%" + param.sSearch + "%' or TypeShortCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "TypeShortCode";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "TypeName Like '%" + param.sSearch + "%' or TypeShortCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredOrganisationSubjectTypeMaster = GetOrganisationSubjectTypeMaster(out TotalRecords);
            var records = filteredOrganisationSubjectTypeMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { c.TypeName.ToString(), c.TypeShortCode.ToString(), Convert.ToString(c.ID) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}