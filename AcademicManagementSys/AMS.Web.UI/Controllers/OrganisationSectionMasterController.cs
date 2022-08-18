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
    public class OrganisationSectionMasterController : BaseController
    {
        IOrganisationSectionMasterServiceAccess _organisationSectionMasterServiceAcess = null;

        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        public OrganisationSectionMasterController()
        {
            _organisationSectionMasterServiceAcess = new OrganisationSectionMasterServiceAccess();

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
                OrganisationSectionMasterViewModel model = new OrganisationSectionMasterViewModel();
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
            OrganisationSectionMasterViewModel model = new OrganisationSectionMasterViewModel();
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Create(OrganisationSectionMasterViewModel model)
        {
           try
            {
            if (ModelState.IsValid)
            {
                if (model != null && model.OrganisationSectionMasterDTO != null)
                {
                    model.OrganisationSectionMasterDTO.ConnectionString = _connectioString;

                    model.OrganisationSectionMasterDTO.SectionName = model.SectionName;
                    model.OrganisationSectionMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);//model.CreatedBy;
                    IBaseEntityResponse<OrganisationSectionMaster> response = _organisationSectionMasterServiceAcess.InsertOrganisationSectionMaster(model.OrganisationSectionMasterDTO);
                    model.OrganisationSectionMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                }
                return Json(model.OrganisationSectionMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

            OrganisationSectionMasterViewModel model = new OrganisationSectionMasterViewModel();
            try
            {

                model.OrganisationSectionMasterDTO = new OrganisationSectionMaster();
                model.OrganisationSectionMasterDTO.ID = id;
                model.OrganisationSectionMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<OrganisationSectionMaster> response = _organisationSectionMasterServiceAcess.SelectByID(model.OrganisationSectionMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.OrganisationSectionMasterDTO.ID = response.Entity.ID;
                    model.OrganisationSectionMasterDTO.SectionName = response.Entity.SectionName;
                    model.OrganisationSectionMasterDTO.IsUserDefined = response.Entity.IsUserDefined;
                }
                return PartialView(model);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        public ActionResult Edit(OrganisationSectionMasterViewModel model)
        {
            try
            {
            if (ModelState.IsValid)
            {
                if (model != null && model.OrganisationSectionMasterDTO != null)
                {
                    if (model != null && model.OrganisationSectionMasterDTO != null)
                    {
                        model.OrganisationSectionMasterDTO.ConnectionString = _connectioString;
                        model.OrganisationSectionMasterDTO.SectionName = model.SectionName;
                        model.OrganisationSectionMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);// model.ModifiedBy;
                        IBaseEntityResponse<OrganisationSectionMaster> response = _organisationSectionMasterServiceAcess.UpdateOrganisationSectionMaster(model.OrganisationSectionMasterDTO);
                        model.OrganisationSectionMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }

                return Json(model.OrganisationSectionMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        //    OrganisationSectionMasterViewModel model = new OrganisationSectionMasterViewModel();

        //    model.OrganisationSectionMasterDTO = new OrganisationSectionMaster();
        //    model.OrganisationSectionMasterDTO.ID = ID;
        //    model.OrganisationSectionMasterDTO.ConnectionString = _connectioString;

        //    IBaseEntityResponse<OrganisationSectionMaster> response = _organisationSectionMasterServiceAcess.SelectByID(model.OrganisationSectionMasterDTO);

        //    if (response != null && response.Entity != null)
        //    {
        //        model.OrganisationSectionMasterDTO.ID = response.Entity.ID;
        //    }

        //    return PartialView(model);
        //}

        //[HttpPost]
        //public ActionResult Delete(OrganisationSectionMasterViewModel model)
        //{
        //    try
        //    {
        //    IBaseEntityResponse<OrganisationSectionMaster> response = null;
        //    if (!ModelState.IsValid)
        //    {
        //        if (model != null && model.OrganisationSectionMasterDTO != null)
        //        {
        //        OrganisationSectionMaster OrganisationSectionMasterDTO = new OrganisationSectionMaster();
        //        OrganisationSectionMasterDTO.ConnectionString = _connectioString;
        //        OrganisationSectionMasterDTO.ID = model.ID;
        //        OrganisationSectionMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]); ;// model.DeletedBy;
        //        response = _organisationSectionMasterServiceAcess.DeleteOrganisationSectionMaster(OrganisationSectionMasterDTO);
        //        model.OrganisationSectionMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
        //    }
        //    return Json(model.OrganisationSectionMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json("Please review your form");
        //    }

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}

        public ActionResult Delete(int ID)
        {

            OrganisationSectionMasterViewModel model = new OrganisationSectionMasterViewModel();
            try
            {
                IBaseEntityResponse<OrganisationSectionMaster> response = null;
                if (ID > 0)
                {
                    if (ID != null)
                    {
                        OrganisationSectionMaster OrganisationSectionMasterDTO = new OrganisationSectionMaster();
                        OrganisationSectionMasterDTO.ConnectionString = _connectioString;
                        OrganisationSectionMasterDTO.ID = ID;
                        OrganisationSectionMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]); ;// model.DeletedBy;
                        response = _organisationSectionMasterServiceAcess.DeleteOrganisationSectionMaster(OrganisationSectionMasterDTO);
                        model.OrganisationSectionMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    }
                    return Json(model.OrganisationSectionMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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



        #endregion

        #region Methods

        public IEnumerable<OrganisationSectionMasterViewModel> GetOrganisationSectionMaster(out int TotalRecords)
        {
            OrganisationSectionMasterSearchRequest searchRequest = new OrganisationSectionMasterSearchRequest();
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
            List<OrganisationSectionMasterViewModel> listOrganisationSectionMasterViewModel = new List<OrganisationSectionMasterViewModel>();
            List<OrganisationSectionMaster> listOrganisationSectionMaster = new List<OrganisationSectionMaster>();
            IBaseEntityCollectionResponse<OrganisationSectionMaster> baseEntityCollectionResponse = _organisationSectionMasterServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationSectionMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (OrganisationSectionMaster item in listOrganisationSectionMaster)
                    {
                        OrganisationSectionMasterViewModel organisationSectionMasterViewModel = new OrganisationSectionMasterViewModel();
                        organisationSectionMasterViewModel.OrganisationSectionMasterDTO = item;
                        listOrganisationSectionMasterViewModel.Add(organisationSectionMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listOrganisationSectionMasterViewModel;
        }

        #endregion

        #region AjaxHandler


        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc  
            IEnumerable<OrganisationSectionMasterViewModel> filteredOrganisationSectionMasterViewModel;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "SectionName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(SectionName Like '%" + param.sSearch +  "%')";        //this "if" block is added for search functionality
                    }
                    break;
            }

            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredOrganisationSectionMasterViewModel = GetOrganisationSectionMaster(out TotalRecords);            
            var records = filteredOrganisationSectionMasterViewModel.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { c.SectionName.ToString(), Convert.ToString(c.ID), Convert.ToString(c.IsUserDefined) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}