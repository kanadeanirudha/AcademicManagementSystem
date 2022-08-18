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
    public class OrganisationDivisionMasterController : BaseController
    {
        IOrganisationDivisionMasterServiceAccess _orgDivisionMasterServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public OrganisationDivisionMasterController()
        {
            _orgDivisionMasterServiceAcess = new OrganisationDivisionMasterServiceAccess();
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
                OrganisationDivisionMasterViewModel model = new OrganisationDivisionMasterViewModel();
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
            OrganisationDivisionMasterViewModel model = new OrganisationDivisionMasterViewModel();
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Create(OrganisationDivisionMasterViewModel model)
        {
           try
            {
            if (ModelState.IsValid)
            {
                if (model != null && model.OrganisationDivisionMasterDTO != null)
                {
                    model.OrganisationDivisionMasterDTO.ConnectionString = _connectioString;
                    model.OrganisationDivisionMasterDTO.DivisionDescription = model.DivisionDescription;
                    model.OrganisationDivisionMasterDTO.DivShortCode = model.DivShortCode;
                    model.OrganisationDivisionMasterDTO.PrintShortCode = model.PrintShortCode;
                    model.OrganisationDivisionMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<OrganisationDivisionMaster> response = _orgDivisionMasterServiceAcess.InsertOrganisationDivisionMaster(model.OrganisationDivisionMasterDTO);
                    model.OrganisationDivisionMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                }
                return Json(model.OrganisationDivisionMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            OrganisationDivisionMasterViewModel model = new OrganisationDivisionMasterViewModel();

            model.OrganisationDivisionMasterDTO = new OrganisationDivisionMaster();
            model.OrganisationDivisionMasterDTO.ID = id;
            model.OrganisationDivisionMasterDTO.ConnectionString = _connectioString;
            IBaseEntityResponse<OrganisationDivisionMaster> response = _orgDivisionMasterServiceAcess.SelectByID(model.OrganisationDivisionMasterDTO);

            if (response != null && response.Entity != null)
            {
                model.OrganisationDivisionMasterDTO.ID = response.Entity.ID;
                model.OrganisationDivisionMasterDTO.DivisionDescription = response.Entity.DivisionDescription;
                model.OrganisationDivisionMasterDTO.DivShortCode = response.Entity.DivShortCode;
                model.OrganisationDivisionMasterDTO.PrintShortCode = response.Entity.PrintShortCode;
                model.OrganisationDivisionMasterDTO.IsUserDefined= response.Entity.IsUserDefined;
            }
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(OrganisationDivisionMasterViewModel model)
        {
          try
            {
            if (ModelState.IsValid)
            {
                if (model != null && model.OrganisationDivisionMasterDTO != null)
                {
                    if (model != null && model.OrganisationDivisionMasterDTO != null)
                    {
                        model.OrganisationDivisionMasterDTO.ConnectionString = _connectioString;
                        model.OrganisationDivisionMasterDTO.DivisionDescription = model.DivisionDescription;
                        model.OrganisationDivisionMasterDTO.DivShortCode = model.DivShortCode;
                        model.OrganisationDivisionMasterDTO.PrintShortCode = model.PrintShortCode;
                        model.OrganisationDivisionMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<OrganisationDivisionMaster> response = _orgDivisionMasterServiceAcess.UpdateOrganisationDivisionMaster(model.OrganisationDivisionMasterDTO);
                        model.OrganisationDivisionMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }

                return Json(model.OrganisationDivisionMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(Boolean.FalseString);
            }
        }
          catch (Exception ex)
          {
              _logException.Error(ex.Message);
              throw;
          }
        }

      //[HttpGet]
      //  public ActionResult Delete(int ID)
      //  {

      //      OrganisationDivisionMasterViewModel model = new OrganisationDivisionMasterViewModel();
      //      model.OrganisationDivisionMasterDTO = new OrganisationDivisionMaster();
      //      model.OrganisationDivisionMasterDTO.ID = ID;
      //      model.OrganisationDivisionMasterDTO.ConnectionString = _connectioString;

      //      IBaseEntityResponse<OrganisationDivisionMaster> response = _orgDivisionMasterServiceAcess.SelectByID(model.OrganisationDivisionMasterDTO);

      //      if (response != null && response.Entity != null)
      //      {
      //          model.OrganisationDivisionMasterDTO.ID = response.Entity.ID;
      //          model.OrganisationDivisionMasterDTO.DivisionDescription = response.Entity.DivisionDescription;
      //          model.OrganisationDivisionMasterDTO.DivShortCode = response.Entity.DivShortCode;
      //          model.OrganisationDivisionMasterDTO.PrintShortCode = response.Entity.PrintShortCode;
      //      }
      //      return PartialView(model);
      //  }

        //[HttpPost]
        //public ActionResult Delete(OrganisationDivisionMasterViewModel model)
        //{
        //   try
        //    {
        //        if (!ModelState.IsValid)
        //    {
        //        if (model.ID > 0)
        //        {
        //            OrganisationDivisionMaster organisationDivisionMasterDTO = new OrganisationDivisionMaster();
        //            organisationDivisionMasterDTO.ConnectionString = _connectioString;
        //            organisationDivisionMasterDTO.ID = model.ID;
        //            organisationDivisionMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
        //            IBaseEntityResponse<OrganisationDivisionMaster> response = _orgDivisionMasterServiceAcess.DeleteOrganisationDivisionMaster(organisationDivisionMasterDTO);
        //            model.OrganisationDivisionMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
        //        }
        //        return Json(model.OrganisationDivisionMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json("Please review your form");
        //    }
        //    }
        // catch (Exception ex)
        //  {
        //      _logException.Error(ex.Message);
        //      throw;
        //  }
        //}

        
        public ActionResult Delete(int ID)
        {
            OrganisationDivisionMasterViewModel model = new OrganisationDivisionMasterViewModel();
            try
            {
                if (ID > 0)
                {
                    if (ID > 0)
                    {
                        OrganisationDivisionMaster organisationDivisionMasterDTO = new OrganisationDivisionMaster();
                        organisationDivisionMasterDTO.ConnectionString = _connectioString;
                        organisationDivisionMasterDTO.ID = ID;
                        organisationDivisionMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<OrganisationDivisionMaster> response = _orgDivisionMasterServiceAcess.DeleteOrganisationDivisionMaster(organisationDivisionMasterDTO);
                        model.OrganisationDivisionMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    }
                    return Json(model.OrganisationDivisionMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public IEnumerable<OrganisationDivisionMasterViewModel> GetlistOrganisationDivisionMaster(out int TotalRecords)
        {
            OrganisationDivisionMasterSearchRequest searchRequest = new OrganisationDivisionMasterSearchRequest();
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
            List<OrganisationDivisionMasterViewModel> listOrganisationDivisionMasterViewModel = new List<OrganisationDivisionMasterViewModel>();
            List<OrganisationDivisionMaster> listOrganisationDivisionMaster = new List<OrganisationDivisionMaster>();
            IBaseEntityCollectionResponse<OrganisationDivisionMaster> baseEntityCollectionResponse = _orgDivisionMasterServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationDivisionMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (OrganisationDivisionMaster item in listOrganisationDivisionMaster)
                    {
                        OrganisationDivisionMasterViewModel orgReligionMasterViewModel = new OrganisationDivisionMasterViewModel();
                        orgReligionMasterViewModel.OrganisationDivisionMasterDTO = item;
                        listOrganisationDivisionMasterViewModel.Add(orgReligionMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listOrganisationDivisionMasterViewModel;
        }

        #endregion
        #region
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
            IEnumerable<OrganisationDivisionMasterViewModel> filteredOrganisationDivisionMaster;

            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "DivisionDescription";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(DivisionDescription Like '%" + param.sSearch + "%' or DivShortCode Like '%" + param.sSearch + "%' or PrintShortCode Like '%" + param.sSearch + "%')";         //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "DivShortCode";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(DivisionDescription Like '%" + param.sSearch + "%' or DivShortCode Like '%" + param.sSearch + "%' or PrintShortCode Like '%" + param.sSearch + "%')";        //this "if" block is added for search functionality
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
                        _searchBy = "(DivisionDescription Like '%" + param.sSearch + "%' or DivShortCode Like '%" + param.sSearch + "%' or PrintShortCode Like '%" + param.sSearch + "%')";         //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredOrganisationDivisionMaster = GetlistOrganisationDivisionMaster(out TotalRecords);
            var records = filteredOrganisationDivisionMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { c.DivisionDescription.ToString(), c.DivShortCode.ToString(), c.PrintShortCode.ToString(), Convert.ToString(c.ID) ,Convert.ToString(c.IsUserDefined)};
           
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}