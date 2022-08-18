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
    public class OrganisationUniversityMasterController : BaseController
    {
        IOrganisationUniversityMasterServiceAccess _organisationUniversityMasterServiceAcess = null;
        private readonly ILogger _logException;
        OrganisationUniversityMasterBaseViewModel _organisationUniversityMasterBaseViewModel = null;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public OrganisationUniversityMasterController()
        {
            _organisationUniversityMasterServiceAcess = new OrganisationUniversityMasterServiceAccess();
            _organisationUniversityMasterBaseViewModel = new OrganisationUniversityMasterBaseViewModel();           
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
            OrganisationUniversityMasterViewModel model = new OrganisationUniversityMasterViewModel();
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
            OrganisationUniversityMasterViewModel model = new OrganisationUniversityMasterViewModel();
            try
            {
                string SelectedValue = string.Empty;
                List<GeneralCityMaster> GeneralCityMasterList = GetListGeneralCityMaster(SelectedValue);
                List<SelectListItem> GeneralCityMaster = new List<SelectListItem>();
                foreach (GeneralCityMaster item in GeneralCityMasterList)
                {
                    GeneralCityMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
                }
                ViewBag.GeneralCityMaster = new SelectList(GeneralCityMaster, "Value", "Text");
            }
            catch (Exception)
            {
                throw;
            }
            return PartialView(model);
        }

        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(OrganisationUniversityMasterViewModel model)
        {
           try
            {
            if (ModelState.IsValid)
            {
                if (model != null && model.OrganisationUniversityMasterDTO != null)
                {
                    model.OrganisationUniversityMasterDTO.ConnectionString = _connectioString;
                    model.OrganisationUniversityMasterDTO.UniversityName = model.UniversityName;
                    model.OrganisationUniversityMasterDTO.EstablishmentCode = model.EstablishmentCode;
                    model.OrganisationUniversityMasterDTO.CityID = Convert.ToInt32(model.SelectedCityID);
                    model.OrganisationUniversityMasterDTO.UniversityFoundationDatetime = model.UniversityFoundationDatetime;
                    model.OrganisationUniversityMasterDTO.UniversityFounderMember = model.UniversityFounderMember;
                    model.OrganisationUniversityMasterDTO.UniversityAddress1 = model.UniversityAddress1;
                    model.OrganisationUniversityMasterDTO.PlotNumber = model.PlotNumber;
                    model.OrganisationUniversityMasterDTO.StreetNumber = model.StreetNumber;
                    model.OrganisationUniversityMasterDTO.Pincode = model.Pincode;
                    model.OrganisationUniversityMasterDTO.FaxNumber = model.FaxNumber;
                    model.OrganisationUniversityMasterDTO.PhoneNumberOffice = model.PhoneNumberOffice;
                    model.OrganisationUniversityMasterDTO.Extention = model.Extention;
                    model.OrganisationUniversityMasterDTO.CellPhone = model.CellPhone;
                    model.OrganisationUniversityMasterDTO.EmailID = model.EmailID;
                    model.OrganisationUniversityMasterDTO.Url = model.Url;
                    model.OrganisationUniversityMasterDTO.DefaultFlag = model.DefaultFlag;
                    if (string.IsNullOrEmpty(model.UniversityAddress2))
                    {
                        model.UniversityAddress2 = string.Empty;
                    }
                    else
                    {
                        model.OrganisationUniversityMasterDTO.UniversityAddress2 = model.UniversityAddress2;
                    }
                    if (string.IsNullOrEmpty(model.OfficeComment))
                    {
                        model.OfficeComment = string.Empty;
                    }
                    else
                    {
                        model.OrganisationUniversityMasterDTO.OfficeComment = model.OfficeComment;
                    }
                    if (string.IsNullOrEmpty(model.MissionStatement))
                    {
                        model.MissionStatement = string.Empty;
                    }
                    else
                    {
                        model.OrganisationUniversityMasterDTO.MissionStatement = model.MissionStatement;
                    }
                    if (string.IsNullOrEmpty(model.UniversityReportPath))
                    {
                        model.UniversityReportPath = string.Empty;
                    }
                    else
                    {
                        model.OrganisationUniversityMasterDTO.UniversityReportPath = model.UniversityReportPath;
                    }
                    if (string.IsNullOrEmpty(model.UniversityShortName))
                    {
                        model.UniversityShortName = string.Empty;
                    }
                    else
                    {
                        model.OrganisationUniversityMasterDTO.UniversityShortName = model.UniversityShortName;
                    }
                    model.OrganisationUniversityMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);  
                    IBaseEntityResponse<OrganisationUniversityMaster> response = _organisationUniversityMasterServiceAcess.InsertOrganisationUniversityMaster(model.OrganisationUniversityMasterDTO);
                    model.OrganisationUniversityMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                }
                return Json(model.OrganisationUniversityMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

            OrganisationUniversityMasterViewModel model = new OrganisationUniversityMasterViewModel();
            try
            {
                string SelectedValue = string.Empty;
                List<GeneralCityMaster> GeneralCityMasterList = GetListGeneralCityMaster(SelectedValue);
                List<SelectListItem> GeneralCityMaster = new List<SelectListItem>();
                foreach (GeneralCityMaster item in GeneralCityMasterList)
                {
                    GeneralCityMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
                }
                model.OrganisationUniversityMasterDTO = new OrganisationUniversityMaster();
                model.OrganisationUniversityMasterDTO.ID = id;
                model.OrganisationUniversityMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<OrganisationUniversityMaster> response = _organisationUniversityMasterServiceAcess.SelectByID(model.OrganisationUniversityMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.OrganisationUniversityMasterDTO.ID = response.Entity.ID;
                    model.OrganisationUniversityMasterDTO.UniversityName = response.Entity.UniversityName;
                    model.OrganisationUniversityMasterDTO.EstablishmentCode = response.Entity.EstablishmentCode;
                    model.OrganisationUniversityMasterDTO.UniversityFoundationDatetime = response.Entity.UniversityFoundationDatetime;
                    model.OrganisationUniversityMasterDTO.UniversityFounderMember = response.Entity.UniversityFounderMember;
                    model.OrganisationUniversityMasterDTO.UniversityAddress1 = response.Entity.UniversityAddress1;
                    model.OrganisationUniversityMasterDTO.UniversityAddress2 = response.Entity.UniversityAddress2;
                    model.OrganisationUniversityMasterDTO.PlotNumber = response.Entity.PlotNumber;
                    model.OrganisationUniversityMasterDTO.StreetNumber = response.Entity.StreetNumber;
                    model.OrganisationUniversityMasterDTO.Pincode = response.Entity.Pincode;
                    model.OrganisationUniversityMasterDTO.FaxNumber = response.Entity.FaxNumber;
                    model.OrganisationUniversityMasterDTO.PhoneNumberOffice = response.Entity.PhoneNumberOffice;
                    model.OrganisationUniversityMasterDTO.Extention = response.Entity.Extention;
                    model.OrganisationUniversityMasterDTO.CellPhone = response.Entity.CellPhone;
                    model.OrganisationUniversityMasterDTO.EmailID = response.Entity.EmailID;
                    model.OrganisationUniversityMasterDTO.Url = response.Entity.Url;
                    model.OrganisationUniversityMasterDTO.OfficeComment = response.Entity.OfficeComment;
                    model.OrganisationUniversityMasterDTO.MissionStatement = response.Entity.MissionStatement;
                    model.OrganisationUniversityMasterDTO.UniversityReportPath = response.Entity.UniversityReportPath;
                    model.OrganisationUniversityMasterDTO.UniversityShortName = response.Entity.UniversityShortName;
                    model.OrganisationUniversityMasterDTO.DefaultFlag = response.Entity.DefaultFlag;
                    
                    ViewBag.GeneralCityMaster = new SelectList(GeneralCityMaster, "Value", "Text", response.Entity.CityID.ToString());

                }
                return PartialView(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(OrganisationUniversityMasterViewModel model)
        {
           try
            {
            if (ModelState.IsValid)
            {
                if (model != null && model.OrganisationUniversityMasterDTO != null)
                {
                    model.OrganisationUniversityMasterDTO.ConnectionString = _connectioString;
                    model.OrganisationUniversityMasterDTO.UniversityName = model.UniversityName;
                    model.OrganisationUniversityMasterDTO.EstablishmentCode = model.EstablishmentCode;
                    model.OrganisationUniversityMasterDTO.CityID = Convert.ToInt32(model.SelectedCityID);
                    model.OrganisationUniversityMasterDTO.UniversityFoundationDatetime = model.UniversityFoundationDatetime;
                    model.OrganisationUniversityMasterDTO.UniversityFounderMember = model.UniversityFounderMember;
                    model.OrganisationUniversityMasterDTO.UniversityAddress1 = model.UniversityAddress1;
                    model.OrganisationUniversityMasterDTO.PlotNumber = model.PlotNumber;
                    model.OrganisationUniversityMasterDTO.StreetNumber = model.StreetNumber;
                    model.OrganisationUniversityMasterDTO.Pincode = model.Pincode;
                    model.OrganisationUniversityMasterDTO.FaxNumber = model.FaxNumber;
                    model.OrganisationUniversityMasterDTO.PhoneNumberOffice = model.PhoneNumberOffice;
                    model.OrganisationUniversityMasterDTO.Extention = model.Extention;
                    model.OrganisationUniversityMasterDTO.CellPhone = model.CellPhone;
                    model.OrganisationUniversityMasterDTO.EmailID = model.EmailID;
                    model.OrganisationUniversityMasterDTO.Url = model.Url;
                    model.OrganisationUniversityMasterDTO.DefaultFlag = model.DefaultFlag;
                    if (string.IsNullOrEmpty(model.UniversityAddress2))
                    {
                        model.UniversityAddress2 = string.Empty;
                    }
                    else
                    {
                        model.OrganisationUniversityMasterDTO.UniversityAddress2 = model.UniversityAddress2;
                    }
                    if (string.IsNullOrEmpty(model.OfficeComment))
                    {
                        model.OfficeComment = string.Empty;
                    }
                    else
                    {
                        model.OrganisationUniversityMasterDTO.OfficeComment = model.OfficeComment;
                    }
                    if (string.IsNullOrEmpty(model.MissionStatement))
                    {
                        model.MissionStatement = string.Empty;
                    }
                    else
                    {
                        model.OrganisationUniversityMasterDTO.MissionStatement = model.MissionStatement;
                    }
                    if (string.IsNullOrEmpty(model.UniversityReportPath))
                    {
                        model.UniversityReportPath = string.Empty;
                    }
                    else
                    {
                        model.OrganisationUniversityMasterDTO.UniversityReportPath = model.UniversityReportPath;
                    }
                    if (string.IsNullOrEmpty(model.UniversityShortName))
                    {
                        model.UniversityShortName = string.Empty;
                    }
                    else
                    {
                        model.OrganisationUniversityMasterDTO.UniversityShortName = model.UniversityShortName;
                    }
                        model.OrganisationUniversityMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);  
                        IBaseEntityResponse<OrganisationUniversityMaster> response = _organisationUniversityMasterServiceAcess.UpdateOrganisationUniversityMaster(model.OrganisationUniversityMasterDTO);
                        model.OrganisationUniversityMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                }
                return Json(model.OrganisationUniversityMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        //    OrganisationUniversityMasterViewModel model = new OrganisationUniversityMasterViewModel();
        //    model.OrganisationUniversityMasterDTO = new OrganisationUniversityMaster();
        //    model.OrganisationUniversityMasterDTO.ID = ID;
        //    return PartialView(model);
        //}

        //[HttpPost]
        //public ActionResult Delete(OrganisationUniversityMasterViewModel model)
        //{
        //    IBaseEntityResponse<OrganisationUniversityMaster> response = null;
        //    try
        //    {
        //    if (model.ID > 0)
        //    {
        //        OrganisationUniversityMaster OrganisationUniversityMasterDTO = new OrganisationUniversityMaster();
        //        OrganisationUniversityMasterDTO.ConnectionString = _connectioString;
        //        OrganisationUniversityMasterDTO.ID = model.ID;
        //        OrganisationUniversityMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);  
        //        response = _organisationUniversityMasterServiceAcess.DeleteOrganisationUniversityMaster(OrganisationUniversityMasterDTO);
        //        model.OrganisationUniversityMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
        //    }
        //    if (response.Message.Count == 0)
        //    {
        //        return Json(model.OrganisationUniversityMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            IBaseEntityResponse<OrganisationUniversityMaster> response = null;
            OrganisationUniversityMasterViewModel model = new OrganisationUniversityMasterViewModel();
            try
            {
                if (ID > 0)
                {
                    OrganisationUniversityMaster OrganisationUniversityMasterDTO = new OrganisationUniversityMaster();
                    OrganisationUniversityMasterDTO.ConnectionString = _connectioString;
                    OrganisationUniversityMasterDTO.ID = ID;
                    OrganisationUniversityMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                    response = _organisationUniversityMasterServiceAcess.DeleteOrganisationUniversityMaster(OrganisationUniversityMasterDTO);
                    model.OrganisationUniversityMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                }
                if (response.Message.Count == 0)
                {
                    return Json(model.OrganisationUniversityMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        // Non-Action Methods
        #region Non-Action Methods
        public IEnumerable<OrganisationUniversityMasterViewModel> GetOrganisationUniversityMaster(out int TotalRecords)
        {
            OrganisationUniversityMasterSearchRequest searchRequest = new OrganisationUniversityMasterSearchRequest();
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
                searchRequest.SortBy = _sortBy;                        // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
            }
            List<OrganisationUniversityMasterViewModel> listOrganisationUniversityMasterViewModel = new List<OrganisationUniversityMasterViewModel>();
            List<OrganisationUniversityMaster> listOrganisationUniversityMaster = new List<OrganisationUniversityMaster>();
            IBaseEntityCollectionResponse<OrganisationUniversityMaster> baseEntityCollectionResponse = _organisationUniversityMasterServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationUniversityMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (OrganisationUniversityMaster item in listOrganisationUniversityMaster)
                    {
                        OrganisationUniversityMasterViewModel generalRegionMasterViewModel = new OrganisationUniversityMasterViewModel();
                        generalRegionMasterViewModel.OrganisationUniversityMasterDTO = item;
                        listOrganisationUniversityMasterViewModel.Add(generalRegionMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listOrganisationUniversityMasterViewModel;
        }
        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {

            int TotalRecords; 
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
           
            IEnumerable<OrganisationUniversityMasterViewModel> filteredUniversityMaster;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "UniversityName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "UniversityName Like '%" + param.sSearch + "%' or EstablishmentCode Like '%" + param.sSearch + "%' or UniversityFounderMember Like '%" + param.sSearch + "%' or UniversityFoundationDatetime Like '%"+param.sSearch+"%'";        //this "if" block is added for search functionality
                    }  
                    break;
                case 1:
                    _sortBy = "EstablishmentCode";
                  if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "UniversityName Like '%" + param.sSearch + "%' or EstablishmentCode Like '%" + param.sSearch + "%' or UniversityFounderMember Like '%" + param.sSearch + "%' or UniversityFoundationDatetime Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }  
                    break;
                case 2:
                    _sortBy = "UniversityFounderMember";
                     if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "UniversityName Like '%" + param.sSearch + "%' or EstablishmentCode Like '%" + param.sSearch + "%' or UniversityFounderMember Like '%" + param.sSearch + "%' or UniversityFoundationDatetime Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }  
                    break;
                case 3:
                    _sortBy = "UniversityFoundationDatetime";
                     if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "UniversityName Like '%" + param.sSearch + "%' or EstablishmentCode Like '%" + param.sSearch + "%' or UniversityFounderMember Like '%" + param.sSearch + "%' or UniversityFoundationDatetime Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }  
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart; 
            filteredUniversityMaster = GetOrganisationUniversityMaster(out TotalRecords);
            var records = filteredUniversityMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { c.UniversityName.ToString(), c.EstablishmentCode.ToString(), c.UniversityFounderMember.ToString(), DateTime.Parse(c.UniversityFoundationDatetime.ToString()).ToString("dd-MMM-yyyy"), Convert.ToString(c.ID) };
            
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}