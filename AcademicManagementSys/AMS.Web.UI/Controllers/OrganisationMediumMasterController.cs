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
    public class OrganisationMediumMasterController : BaseController
    {
        IOrganisationMediumMasterServiceAccess _organisationMediumMasterServiceAcess = null;

        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        public OrganisationMediumMasterController()
        {
            _organisationMediumMasterServiceAcess = new OrganisationMediumMasterServiceAccess();
           
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
                OrganisationMediumMasterViewModel model = new OrganisationMediumMasterViewModel();
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
            OrganisationMediumMasterViewModel model = new OrganisationMediumMasterViewModel();
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Create(OrganisationMediumMasterViewModel model)
        {  
          try
            {
            if (ModelState.IsValid)
            {
                if (model != null && model.OrganisationMediumMasterDTO != null)
                {
                    model.OrganisationMediumMasterDTO.ConnectionString = _connectioString;

                    model.OrganisationMediumMasterDTO.Description = model.Description;
                    model.OrganisationMediumMasterDTO.CodeShortCode = model.CodeShortCode;
                    model.OrganisationMediumMasterDTO.PrintShortCode = model.PrintShortCode;
                    model.OrganisationMediumMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]); //model.CreatedBy;
                    IBaseEntityResponse<OrganisationMediumMaster> response = _organisationMediumMasterServiceAcess.InsertOrganisationMediumMaster(model.OrganisationMediumMasterDTO);
                    model.OrganisationMediumMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                }
                return Json(model.OrganisationMediumMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

            OrganisationMediumMasterViewModel model = new OrganisationMediumMasterViewModel();
            try
            {
               
                model.OrganisationMediumMasterDTO = new OrganisationMediumMaster();
                model.OrganisationMediumMasterDTO.ID = id;
                model.OrganisationMediumMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<OrganisationMediumMaster> response = _organisationMediumMasterServiceAcess.SelectByID(model.OrganisationMediumMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.OrganisationMediumMasterDTO.ID = response.Entity.ID;
                    model.OrganisationMediumMasterDTO.Description = response.Entity.Description;
                    model.OrganisationMediumMasterDTO.CodeShortCode = response.Entity.CodeShortCode;
                    model.OrganisationMediumMasterDTO.PrintShortCode = response.Entity.PrintShortCode;
                    model.OrganisationMediumMasterDTO.IsUserDefined = response.Entity.IsUserDefined;     
                }
                return PartialView(model);
            }
            catch (Exception)
            {

                throw;
            }
        }
  
        [HttpPost]
        public ActionResult Edit(OrganisationMediumMasterViewModel model)
        {
          try
            {
            if (ModelState.IsValid)
            {
                if (model != null && model.OrganisationMediumMasterDTO != null)
                {
                    if (model != null && model.OrganisationMediumMasterDTO != null)
                    {
                        model.OrganisationMediumMasterDTO.ConnectionString = _connectioString;
                        model.OrganisationMediumMasterDTO.Description = model.Description;
                        model.OrganisationMediumMasterDTO.CodeShortCode = model.CodeShortCode;
                        model.OrganisationMediumMasterDTO.PrintShortCode = model.PrintShortCode;
                        model.OrganisationMediumMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<OrganisationMediumMaster> response = _organisationMediumMasterServiceAcess.UpdateOrganisationMediumMaster(model.OrganisationMediumMasterDTO);
                        model.OrganisationMediumMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }

                return Json(model.OrganisationMediumMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        //    OrganisationMediumMasterViewModel model = new OrganisationMediumMasterViewModel();

        //    model.OrganisationMediumMasterDTO = new OrganisationMediumMaster();
        //    model.OrganisationMediumMasterDTO.ID = ID;
        //    model.OrganisationMediumMasterDTO.ConnectionString = _connectioString;

        //    IBaseEntityResponse<OrganisationMediumMaster> response = _organisationMediumMasterServiceAcess.SelectByID(model.OrganisationMediumMasterDTO);

        //    if (response != null && response.Entity != null)
        //    {
        //        model.OrganisationMediumMasterDTO.ID = response.Entity.ID;
        //    }

        //    return PartialView(model);
        //}

        //[HttpPost]
        //public ActionResult Delete(OrganisationMediumMasterViewModel model)
        //{
        //    IBaseEntityResponse<OrganisationMediumMaster> response = null;
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            if (model.ID > 0)
        //            {
        //                OrganisationMediumMaster OrganisationMediumMasterDTO = new OrganisationMediumMaster();
        //                OrganisationMediumMasterDTO.ConnectionString = _connectioString;
        //                OrganisationMediumMasterDTO.ID = model.ID;
        //                OrganisationMediumMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
        //                response = _organisationMediumMasterServiceAcess.DeleteOrganisationMediumMaster(OrganisationMediumMasterDTO);
        //                model.OrganisationMediumMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
        //            }

        //            return Json(model.OrganisationMediumMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
        //        }
        //        else
        //        {
        //            return Json("Please review your form");
        //        }
        //    }

        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}


        public ActionResult Delete(int ID)
        {
            OrganisationMediumMasterViewModel model = new OrganisationMediumMasterViewModel();
            IBaseEntityResponse<OrganisationMediumMaster> response = null;
            try
            {
                if (ID > 0)
                {
                    if (ID > 0)
                    {
                        OrganisationMediumMaster OrganisationMediumMasterDTO = new OrganisationMediumMaster();
                        OrganisationMediumMasterDTO.ConnectionString = _connectioString;
                        OrganisationMediumMasterDTO.ID = ID;
                        OrganisationMediumMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                        response = _organisationMediumMasterServiceAcess.DeleteOrganisationMediumMaster(OrganisationMediumMasterDTO);
                        model.OrganisationMediumMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    }

                    return Json(model.OrganisationMediumMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        public IEnumerable<OrganisationMediumMasterViewModel> GetOrganisationMediumMaster(out int TotalRecords)
        {
            OrganisationMediumMasterSearchRequest searchRequest = new OrganisationMediumMasterSearchRequest();
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
            List<OrganisationMediumMasterViewModel> listOrganisationMediumMasterViewModel = new List<OrganisationMediumMasterViewModel>();
            List<OrganisationMediumMaster> listOrganisationMediumMaster = new List<OrganisationMediumMaster>();
            IBaseEntityCollectionResponse<OrganisationMediumMaster> baseEntityCollectionResponse = _organisationMediumMasterServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationMediumMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (OrganisationMediumMaster item in listOrganisationMediumMaster)
                    {
                        OrganisationMediumMasterViewModel organisationMediumMasterViewModel = new OrganisationMediumMasterViewModel();
                        organisationMediumMasterViewModel.OrganisationMediumMasterDTO = item;
                        listOrganisationMediumMasterViewModel.Add(organisationMediumMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listOrganisationMediumMasterViewModel;
        }

        #endregion

        #region AjaxHandler

        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
          
            IEnumerable<OrganisationMediumMasterViewModel> filteredOrganisationMediumMasterViewModel;
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
                        _searchBy = "(Description Like '%" + param.sSearch + "%' or CodeShortCode Like '%" + param.sSearch + "%')";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "CodeShortCode";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(Description Like '%" + param.sSearch + "%' or CodeShortCode Like '%" + param.sSearch + "%')";      //this "if" block is added for search functionality
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
                        _searchBy = "(Description Like '%" + param.sSearch + "%' or CodeShortCode Like '%" + param.sSearch + "%')";      //this "if" block is added for search functionality
                    }
                    break;

            }

            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredOrganisationMediumMasterViewModel = GetOrganisationMediumMaster(out TotalRecords);
            var records = filteredOrganisationMediumMasterViewModel.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { c.Description.ToString(), c.CodeShortCode.ToString(), c.PrintShortCode.ToString(), Convert.ToString(c.ID), Convert.ToString(c.IsUserDefined) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}