using AMS.Base.DTO;
using AMS.DTO;
using AMS.ServiceAccess;
using AMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AMS.Common;
using AMS.ExceptionManager;
namespace AMS.Web.UI.Controllers
{
    public class ToolTemplateRegistrationController : BaseController
    {
        IToolTemplateRegistrationServiceAccess _ToolTemplateRegistrationServiceAccess = null;
        ActionModeEnum actionModeEnum;
        private readonly ILogger _logException;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        public ToolTemplateRegistrationController()
        {
            _ToolTemplateRegistrationServiceAccess = new ToolTemplateRegistrationServiceAccess();

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
                ToolTemplateRegistrationViewModel model = new ToolTemplateRegistrationViewModel();
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
            ToolTemplateRegistrationViewModel model = new ToolTemplateRegistrationViewModel();
            model.ToolRegistrationFieldMasterList = GetListToolRegistrationFieldMaster();
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Create(ToolTemplateRegistrationViewModel model)
        {
            try
            {


                if (model != null && model.ToolTemplateRegistrationDTO != null)
                {
                    model.ToolTemplateRegistrationDTO.ConnectionString = _connectioString;
                    model.ToolTemplateRegistrationDTO.TemplateName = model.TemplateName;
                    if (model.Data1 != null)
                    {
                        model.ToolTemplateRegistrationDTO.Data1 = model.Data1.Replace("&", "And"); ;
                    }
                    else
                    {
                        model.ToolTemplateRegistrationDTO.Data1 = " ";
                    }
                    if (model.Data2 != null)
                    {
                        model.ToolTemplateRegistrationDTO.Data2 = model.Data2.Replace("&", "And"); ;
                    }
                    else
                    {
                        model.ToolTemplateRegistrationDTO.Data2 = " ";
                    }

                    if (model.Data3 != null)
                    {
                        model.ToolTemplateRegistrationDTO.Data3 = model.Data3.Replace("&", "And"); ;
                    }
                    else
                    {
                        model.ToolTemplateRegistrationDTO.Data3 = " ";
                    }
                    if (model.Data4 != null)
                    {
                        model.ToolTemplateRegistrationDTO.Data4 = model.Data4.Replace("&", "And"); ;
                    }
                    else
                    {
                        model.ToolTemplateRegistrationDTO.Data4 = " ";
                    }
                    if (model.Data5 != null)
                    {
                        model.ToolTemplateRegistrationDTO.Data5 = model.Data5.Replace("&", "And"); ;
                    }
                    else
                    {
                        model.ToolTemplateRegistrationDTO.Data5 = " ";
                    }
                    if (model.Data6 != null)
                    {
                        model.ToolTemplateRegistrationDTO.Data6 = model.Data6.Replace("&", "And"); ;
                    }
                    else
                    {
                        model.ToolTemplateRegistrationDTO.Data6 = " ";
                    }
                    if (model.Data7 != null)
                    {
                        model.ToolTemplateRegistrationDTO.Data7 = model.Data7.Replace("&", "And");
                    }
                    else
                    {
                        model.ToolTemplateRegistrationDTO.Data7 = " ";
                    }
                    if (model.Data8 != null)
                    {
                        model.ToolTemplateRegistrationDTO.Data8 = model.Data8.Replace("&", "And"); ;
                    }
                    else
                    {
                        model.ToolTemplateRegistrationDTO.Data8 = " ";
                    }
                    if (model.Data9 != null)
                    {
                        model.ToolTemplateRegistrationDTO.Data9 = model.Data9.Replace("&", "And"); ;
                    }
                    else
                    {
                        model.ToolTemplateRegistrationDTO.Data9 = " ";
                    }
                    if (model.Data10 != null)
                    {
                        model.ToolTemplateRegistrationDTO.Data10 = model.Data10.Replace("&", "And"); ;
                    }
                    else
                    {
                        model.ToolTemplateRegistrationDTO.Data10 = " ";
                    }
                    model.ToolTemplateRegistrationDTO.CreatedBy = Convert.ToInt32(Session["UserId"]); //model.CreatedBy;
                    IBaseEntityResponse<ToolTemplateRegistration> response = _ToolTemplateRegistrationServiceAccess.InsertToolTemplateRegistration(model.ToolTemplateRegistrationDTO);
                    model.ToolTemplateRegistrationDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.ToolTemplateRegistrationDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(Resources.DisplayMessage_PleaseReviewYourForm);
                }

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult CreateV2()
        {
            ToolTemplateRegistrationViewModel model = new ToolTemplateRegistrationViewModel();
            model.ToolRegistrationFieldMasterList = GetListToolRegistrationFieldMaster();
            return PartialView(model);
        }
        #endregion

        #region Methods
        public IEnumerable<ToolTemplateRegistrationViewModel> GetToolTemplateRegistration(out int TotalRecords)
        {
            ToolTemplateRegistrationSearchRequest searchRequest = new ToolTemplateRegistrationSearchRequest();
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
            List<ToolTemplateRegistrationViewModel> listToolTemplateRegistrationViewModel = new List<ToolTemplateRegistrationViewModel>();
            List<ToolTemplateRegistration> listToolTemplateRegistration = new List<ToolTemplateRegistration>();
            IBaseEntityCollectionResponse<ToolTemplateRegistration> baseEntityCollectionResponse = _ToolTemplateRegistrationServiceAccess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listToolTemplateRegistration = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (ToolTemplateRegistration item in listToolTemplateRegistration)
                    {
                        ToolTemplateRegistrationViewModel ToolTemplateRegistrationViewModel = new ToolTemplateRegistrationViewModel();
                        ToolTemplateRegistrationViewModel.ToolTemplateRegistrationDTO = item;
                        listToolTemplateRegistrationViewModel.Add(ToolTemplateRegistrationViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listToolTemplateRegistrationViewModel;
        }


        protected List<ToolTemplateRegistration> GetListToolRegistrationFieldMaster()
        {
            ToolTemplateRegistrationSearchRequest searchRequest = new ToolTemplateRegistrationSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            //searchRequest.ID = SubjectGrpID;
            //searchRequest.CurrentSessionID = CurrentSessionID;
            List<ToolTemplateRegistration> ToolRegistrationFieldList = new List<ToolTemplateRegistration>();
            IBaseEntityCollectionResponse<ToolTemplateRegistration> baseEntityCollectionResponse = _ToolTemplateRegistrationServiceAccess.GetByToolRegistrationFieldList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    ToolRegistrationFieldList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return ToolRegistrationFieldList;
        }
        #endregion

        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<ToolTemplateRegistrationViewModel> filteredCountryMaster;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "TemplateName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "TemplateName Like '%" + param.sSearch +"%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "IsActive";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "TemplateName Like '%" + param.sSearch + "%'";    
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredCountryMaster = GetToolTemplateRegistration(out TotalRecords);
                var records = filteredCountryMaster.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { c.TemplateName.ToString(), c.IsActive.ToString(), Convert.ToString(c.ID) };

                return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
            }
            else
            {

                //return View("Login","Account");
                //return RedirectToAction("Login", "Account");
                var result = 0;
                return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
                // return PartialView("Login");
            }
        }
        #endregion
    }
}