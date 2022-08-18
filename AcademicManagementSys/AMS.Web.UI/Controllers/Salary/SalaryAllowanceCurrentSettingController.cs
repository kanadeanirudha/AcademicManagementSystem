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
using AMS.DataProvider;
namespace AMS.Web.UI.Controllers
{
    public class SalaryAllowanceCurrentSettingController : BaseController
    {
        ISalaryAllowanceCurrentSettingServiceAccess _SalaryAllowanceCurrentSettingServiceAcess = null;
        ISalaryPayRulesServiceAccess _SalaryPayRulesServiceAccess = null;
        ISalaryAllowanceMasterServiceAccess _SalaryAllowanceMasterServiceAccess = null;
        IGeneralTypeOfAccountServiceAccess _GeneralTypeOfAccountServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public SalaryAllowanceCurrentSettingController()
        {
            _SalaryAllowanceCurrentSettingServiceAcess = new SalaryAllowanceCurrentSettingServiceAccess();
            _SalaryPayRulesServiceAccess = new SalaryPayRulesServiceAccess();
            _SalaryAllowanceMasterServiceAccess = new SalaryAllowanceMasterServiceAccess();
            _GeneralTypeOfAccountServiceAcess = new GeneralTypeOfAccountServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {

            return View("/Views/Salary/SalaryAllowanceCurrentSetting/Index.cshtml");

        }

        public ActionResult List(string actionMode)
        {
            try
            {
                SalaryAllowanceCurrentSettingViewModel model = new SalaryAllowanceCurrentSettingViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Salary/SalaryAllowanceCurrentSetting/List.cshtml", model);
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
            SalaryAllowanceCurrentSettingViewModel model = new SalaryAllowanceCurrentSettingViewModel();
            //**************************DropDown List For Allowance Head NAme*********************
            List<SalaryAllowanceMaster> AllowanceHeadName = GetListSalaryAllowanceMaster();
            List<SelectListItem> SalaryAllowanceMasterIDsList = new List<SelectListItem>();
            foreach (SalaryAllowanceMaster item in AllowanceHeadName)
            {
                SalaryAllowanceMasterIDsList.Add(new SelectListItem { Text = item.AllowanceHeadName, Value = Convert.ToString(item.ID) });
            }
            ViewBag.SalaryAllowanceMasterIDsList = new SelectList(SalaryAllowanceMasterIDsList, "Value", "Text");

            //**************************Dropdown List For PayScaleRulesDiscription*****************
            List<SalaryPayRules> PayScaleRuleDescription = GetListSalaryPayRules();
            List<SelectListItem> SalaryPayRulesIDsList = new List<SelectListItem>();
            foreach (SalaryPayRules item in PayScaleRuleDescription)
            {
                SalaryPayRulesIDsList.Add(new SelectListItem { Text = item.PayScaleRuleDescription, Value = Convert.ToString(item.ID) });
            }
            ViewBag.SalaryPayRulesIDsList = new SelectList(SalaryPayRulesIDsList, "Value", "Text");
            //*************************DropDown List For Account Name******************************
            string dispalyFor = "SelectList";
            List<GeneralTypeOfAccount> GeneralTypeOfAccount = GetListGeneralTypeOfAccount(dispalyFor);
            List<SelectListItem> GeneralTypeOfAccountList = new List<SelectListItem>();

            foreach (GeneralTypeOfAccount item in GeneralTypeOfAccount)
            {
                GeneralTypeOfAccountList.Add(new SelectListItem { Text = item.AccountName, Value = Convert.ToString((item.AccountMasterId)) });
            }
            ViewBag.GeneralTypeOfAccountList = new SelectList(GeneralTypeOfAccountList, "Value", "Text");
            //*************************DropDown List For Calculate On*******************************
            List<SelectListItem> CalculateOn = new List<SelectListItem>();
            ViewBag.CalculateOn = new SelectList(CalculateOn, "Value", "Text");
            List<SelectListItem> CalculateOn_li = new List<SelectListItem>();
            CalculateOn_li.Add(new SelectListItem { Text = "Basic", Value = "1" });
            CalculateOn_li.Add(new SelectListItem { Text = "Gross Pay", Value = "2" });

            ViewData["CalculateOn"] = new SelectList(CalculateOn_li, "Value", "Text");

            return PartialView("/Views/Salary/SalaryAllowanceCurrentSetting/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(SalaryAllowanceCurrentSettingViewModel model)
        {
            try
            {
                if (model != null && model.SalaryAllowanceCurrentSettingDTO != null)
                {
                    model.SalaryAllowanceCurrentSettingDTO.ConnectionString = _connectioString;
                    model.SalaryAllowanceCurrentSettingDTO.SalaryAllowanceMasterID = model.SalaryAllowanceMasterID;
                    model.SalaryAllowanceCurrentSettingDTO.AllowanceHeadName = model.AllowanceHeadName;
                    model.SalaryAllowanceCurrentSettingDTO.FixedAmount = model.FixedAmount;
                    model.SalaryAllowanceCurrentSettingDTO.Percentage = model.Percentage;
                    model.SalaryAllowanceCurrentSettingDTO.EffectedDate = model.EffectedDate;
                    model.SalaryAllowanceCurrentSettingDTO.CloseDate = model.CloseDate;
                    model.SalaryAllowanceCurrentSettingDTO.IsCurrent = model.IsCurrent;
                    model.SalaryAllowanceCurrentSettingDTO.SalaryPayRulesID = model.SalaryPayRulesID;
                    model.SalaryAllowanceCurrentSettingDTO.PayScaleRuleDescription = model.PayScaleRuleDescription;
                    model.SalaryAllowanceCurrentSettingDTO.MapAccountID = model.MapAccountID;
                    model.SalaryAllowanceCurrentSettingDTO.AccountName = model.AccountName;
                    model.SalaryAllowanceCurrentSettingDTO.CalculateOn = model.CalculateOn; ;

                    model.SalaryAllowanceCurrentSettingDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<SalaryAllowanceCurrentSetting> response = _SalaryAllowanceCurrentSettingServiceAcess.InsertSalaryAllowanceCurrentSetting(model.SalaryAllowanceCurrentSettingDTO);

                    model.SalaryAllowanceCurrentSettingDTO.ErrorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);


                    return Json(model.SalaryAllowanceCurrentSettingDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
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
            SalaryAllowanceCurrentSettingViewModel model = new SalaryAllowanceCurrentSettingViewModel();
            try
            {
                model.SalaryAllowanceCurrentSettingDTO = new SalaryAllowanceCurrentSetting();
                model.SalaryAllowanceCurrentSettingDTO.ID = id;
                model.SalaryAllowanceCurrentSettingDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<SalaryAllowanceCurrentSetting> response = _SalaryAllowanceCurrentSettingServiceAcess.SelectByID(model.SalaryAllowanceCurrentSettingDTO);
                if (response != null && response.Entity != null)
                {
                    model.SalaryAllowanceCurrentSettingDTO.ID = response.Entity.ID;
                    model.SalaryAllowanceCurrentSettingDTO.SalaryAllowanceMasterID = response.Entity.SalaryAllowanceMasterID;

                    model.SalaryAllowanceCurrentSettingDTO.FixedAmount = response.Entity.FixedAmount;
                    model.SalaryAllowanceCurrentSettingDTO.Percentage = response.Entity.Percentage;
                    model.SalaryAllowanceCurrentSettingDTO.EffectedDate = response.Entity.EffectedDate;
                    model.SalaryAllowanceCurrentSettingDTO.CloseDate = response.Entity.CloseDate;
                    model.SalaryAllowanceCurrentSettingDTO.IsCurrent = response.Entity.IsCurrent;
                    model.SalaryAllowanceCurrentSettingDTO.SalaryPayRulesID = response.Entity.SalaryPayRulesID;
                    model.SalaryAllowanceCurrentSettingDTO.AllowanceHeadName = Convert.ToString(response.Entity.SalaryAllowanceMasterID);
                    model.SalaryAllowanceCurrentSettingDTO.PayScaleRuleDescription = Convert.ToString(response.Entity.SalaryPayRulesID);
                    model.SalaryAllowanceCurrentSettingDTO.AccountName = Convert.ToString(response.Entity.MapAccountID);
                    model.SalaryAllowanceCurrentSettingDTO.CalculateOn = response.Entity.CalculateOn;

                    //**************************DropDown List For Allowance Head NAme*********************
                    List<SalaryAllowanceMaster> AllowanceHeadName = GetListSalaryAllowanceMaster();
                    List<SelectListItem> SalaryAllowanceMasterIDsList = new List<SelectListItem>();
                    ViewBag.SalaryAllowanceMasterIDsList = new SelectList(SalaryAllowanceMasterIDsList, "Value", "Text");
                    List<SelectListItem> SalaryAllowanceMasterIDsList_li = new List<SelectListItem>();
                    foreach (SalaryAllowanceMaster item in AllowanceHeadName)
                    {
                        SalaryAllowanceMasterIDsList_li.Add(new SelectListItem { Text = item.AllowanceHeadName, Value = Convert.ToString(item.ID) });
                    }
                    ViewBag.SalaryAllowanceMasterIDsList = new SelectList(SalaryAllowanceMasterIDsList_li, "Value", "Text", model.SalaryAllowanceCurrentSettingDTO.AllowanceHeadName);

                    //**************************Dropdown List For PayScaleRulesDiscription*****************
                    List<SalaryPayRules> PayScaleRuleDescription = GetListSalaryPayRules();
                    List<SelectListItem> SalaryPayRulesIDsList = new List<SelectListItem>();
                    foreach (SalaryPayRules item in PayScaleRuleDescription)
                    {
                        SalaryPayRulesIDsList.Add(new SelectListItem { Text = item.PayScaleRuleDescription, Value = Convert.ToString(item.ID) });
                    }
                    ViewBag.SalaryPayRulesIDsList = new SelectList(SalaryPayRulesIDsList, "Value", "Text", model.SalaryAllowanceCurrentSettingDTO.PayScaleRuleDescription);
                    //*************************DropDown List For Account Name******************************
                    string dispalyFor = "SelectList";
                    List<GeneralTypeOfAccount> GeneralTypeOfAccount = GetListGeneralTypeOfAccount(dispalyFor);
                    List<SelectListItem> GeneralTypeOfAccountList = new List<SelectListItem>();

                    foreach (GeneralTypeOfAccount item in GeneralTypeOfAccount)
                    {
                        GeneralTypeOfAccountList.Add(new SelectListItem { Text = item.AccountName, Value = Convert.ToString((item.AccountMasterId)) });
                    }
                    ViewBag.GeneralTypeOfAccountList = new SelectList(GeneralTypeOfAccountList, "Value", "Text", model.SalaryAllowanceCurrentSettingDTO.AccountName);
                    //*************************DropDown List For Calculate On*******************************
                    List<SelectListItem> CalculateOn = new List<SelectListItem>();
                    ViewBag.CalculateOn = new SelectList(CalculateOn, "Value", "Text");
                    List<SelectListItem> CalculateOn_li = new List<SelectListItem>();
                    CalculateOn_li.Add(new SelectListItem { Text = "Basic", Value = "1" });
                    CalculateOn_li.Add(new SelectListItem { Text = "Gross Pay", Value = "2" });

                    ViewData["CalculateOn"] = new SelectList(CalculateOn_li, "Value", "Text");

                }
                return PartialView("/Views/Salary/SalaryAllowanceCurrentSetting/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(SalaryAllowanceCurrentSettingViewModel model)
        {
            try
            {
                if (model != null && model.SalaryAllowanceCurrentSettingDTO != null)
                {
                    model.SalaryAllowanceCurrentSettingDTO.ConnectionString = _connectioString;

                    model.SalaryAllowanceCurrentSettingDTO.SalaryAllowanceMasterID = model.SalaryAllowanceMasterID;
                    // model.SalaryAllowanceCurrentSettingDTO.AllowanceHeadName = model.AllowanceHeadName;
                    model.SalaryAllowanceCurrentSettingDTO.FixedAmount = model.FixedAmount;
                    model.SalaryAllowanceCurrentSettingDTO.Percentage = model.Percentage;
                    model.SalaryAllowanceCurrentSettingDTO.EffectedDate = model.EffectedDate;
                    model.SalaryAllowanceCurrentSettingDTO.CloseDate = model.CloseDate;
                    model.SalaryAllowanceCurrentSettingDTO.IsCurrent = model.IsCurrent;
                    model.SalaryAllowanceCurrentSettingDTO.SalaryPayRulesID = model.SalaryPayRulesID;
                    // model.SalaryAllowanceCurrentSettingDTO.PayScaleRuleDescription = model.PayScaleRuleDescription;
                    model.SalaryAllowanceCurrentSettingDTO.MapAccountID = model.MapAccountID;
                    // model.SalaryAllowanceCurrentSettingDTO.AccountName = model.AccountName;
                    model.SalaryAllowanceCurrentSettingDTO.CalculateOn = model.CalculateOn; ;

                    model.SalaryAllowanceCurrentSettingDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<SalaryAllowanceCurrentSetting> response = _SalaryAllowanceCurrentSettingServiceAcess.UpdateSalaryAllowanceCurrentSetting(model.SalaryAllowanceCurrentSettingDTO);
                    model.SalaryAllowanceCurrentSettingDTO.ErrorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);

                    return Json(model.SalaryAllowanceCurrentSettingDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult ViewDetails(string ID)
        {
            try
            {
                SalaryAllowanceCurrentSettingViewModel model = new SalaryAllowanceCurrentSettingViewModel();
                model.SalaryAllowanceCurrentSettingDTO = new SalaryAllowanceCurrentSetting();
                model.SalaryAllowanceCurrentSettingDTO.ID = Convert.ToInt16(ID);
                model.SalaryAllowanceCurrentSettingDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<SalaryAllowanceCurrentSetting> response = _SalaryAllowanceCurrentSettingServiceAcess.SelectByID(model.SalaryAllowanceCurrentSettingDTO);
                if (response != null && response.Entity != null)
                {

                }

                return PartialView("/Views/Salary/SalaryAllowanceCurrentSetting/ViewDetails.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        public ActionResult Delete(Int16 ID)
        {
            var errorMessage = string.Empty;
            if (ID > 0)
            {
                IBaseEntityResponse<SalaryAllowanceCurrentSetting> response = null;
                SalaryAllowanceCurrentSetting SalaryAllowanceCurrentSettingDTO = new SalaryAllowanceCurrentSetting();
                SalaryAllowanceCurrentSettingDTO.ConnectionString = _connectioString;
                SalaryAllowanceCurrentSettingDTO.ID = ID;
                SalaryAllowanceCurrentSettingDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _SalaryAllowanceCurrentSettingServiceAcess.DeleteSalaryAllowanceCurrentSetting(SalaryAllowanceCurrentSettingDTO);
                errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }

        #endregion

        // Non-Action Method
        //***************************For Dropdown List Of Salary Rule Master********************
        protected List<SalaryPayRules> GetListSalaryPayRules()
        {
            SalaryPayRulesSearchRequest searchRequest = new SalaryPayRulesSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<SalaryPayRules> listSalaryPayRules = new List<SalaryPayRules>();
            IBaseEntityCollectionResponse<SalaryPayRules> baseEntityCollectionResponse = _SalaryPayRulesServiceAccess.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSalaryPayRules = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listSalaryPayRules;
        }

        //***************************For Dropdown List For Allowance Head Name********************
        protected List<SalaryAllowanceMaster> GetListSalaryAllowanceMaster()
        {
            SalaryAllowanceMasterSearchRequest searchRequest = new SalaryAllowanceMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<SalaryAllowanceMaster> listSalaryAllowanceMaster = new List<SalaryAllowanceMaster>();
            IBaseEntityCollectionResponse<SalaryAllowanceMaster> baseEntityCollectionResponse = _SalaryAllowanceMasterServiceAccess.GetAllowanceHeadNameList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSalaryAllowanceMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listSalaryAllowanceMaster;
        }
        //Dropdown For Account Name 
        protected List<GeneralTypeOfAccount> GetListGeneralTypeOfAccount(string displayFor)
        {
            GeneralTypeOfAccountSearchRequest searchRequest = new GeneralTypeOfAccountSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.DisplayFor = displayFor;
            List<GeneralTypeOfAccount> listGeneralTypeOfAccount = new List<GeneralTypeOfAccount>();
            IBaseEntityCollectionResponse<GeneralTypeOfAccount> baseEntityCollectionResponse = _GeneralTypeOfAccountServiceAcess.GetListName(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralTypeOfAccount = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listGeneralTypeOfAccount;
        }
        #region Methods
        public IEnumerable<SalaryAllowanceCurrentSettingViewModel> GetSalaryAllowanceCurrentSetting(out int TotalRecords)
        {
            SalaryAllowanceCurrentSettingSearchRequest searchRequest = new SalaryAllowanceCurrentSettingSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "A.CreatedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "A.ModifiedDate";
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
            List<SalaryAllowanceCurrentSettingViewModel> listSalaryAllowanceCurrentSettingViewModel = new List<SalaryAllowanceCurrentSettingViewModel>();
            List<SalaryAllowanceCurrentSetting> listSalaryAllowanceCurrentSetting = new List<SalaryAllowanceCurrentSetting>();
            IBaseEntityCollectionResponse<SalaryAllowanceCurrentSetting> baseEntityCollectionResponse = _SalaryAllowanceCurrentSettingServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSalaryAllowanceCurrentSetting = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (SalaryAllowanceCurrentSetting item in listSalaryAllowanceCurrentSetting)
                    {
                        SalaryAllowanceCurrentSettingViewModel SalaryAllowanceCurrentSettingViewModel = new SalaryAllowanceCurrentSettingViewModel();
                        SalaryAllowanceCurrentSettingViewModel.SalaryAllowanceCurrentSettingDTO = item;
                        listSalaryAllowanceCurrentSettingViewModel.Add(SalaryAllowanceCurrentSettingViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listSalaryAllowanceCurrentSettingViewModel;
        }
        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<SalaryAllowanceCurrentSettingViewModel> filteredUnitType;
                switch (Convert.ToInt32(sortColumnIndex))
                {


                    case 0:
                        _sortBy = "A.ID";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "B.AllowanceHeadName Like '%" + param.sSearch + "%' or A.FixedAmount Like '%" + param.sSearch + "%' or A.Percentage Like'%" + param.sSearch + "%' or A.EffectedDate Like '%" + param.sSearch + "%' or A.CloseDate Like '%" + param.sSearch + "%' or A.IsCurrent Like '%" + param.sSearch + "%' or  C.PayScaleRuleDescription Like '%" + param.sSearch + "%' or D.AccountName Like '%" + param.sSearch + "%' or  A.CalculateOn Like'%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                        }
                        break;
                    //case 1:
                    //    _sortBy = "B.AllowanceHeadName";
                    //    if (string.IsNullOrEmpty(param.sSearch))
                    //    {
                    //        _searchBy = string.Empty;
                    //    }
                    //    else
                    //    {
                    //        _searchBy = "B.AllowanceHeadName Like '%" + param.sSearch + "%' or A.FixedAmount Like '%" + param.sSearch + "%' or A.Percentage Like'%" + param.sSearch + "%' or A.EffectedDate Like '%" + param.sSearch + "%' or A.CloseDate Like '%" + param.sSearch + "%' or A.IsCurrent Like '%" + param.sSearch + "%' or  C.PayScaleRuleDescription Like '%" + param.sSearch + "%' or D.AccountName Like '%" + param.sSearch + "%' or  A.CalculateOn Like'%" + param.sSearch + "%'";
                    //    }
                    //    break;

                    case 1:
                        _sortBy = "A.FixedAmount ";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "B.AllowanceHeadName Like '%" + param.sSearch + "%' or A.FixedAmount Like '%" + param.sSearch + "%' or A.Percentage Like'%" + param.sSearch + "%' or A.EffectedDate Like '%" + param.sSearch + "%' or A.CloseDate Like '%" + param.sSearch + "%' or A.IsCurrent Like '%" + param.sSearch + "%' or  C.PayScaleRuleDescription Like '%" + param.sSearch + "%' or D.AccountName Like '%" + param.sSearch + "%' or  A.CalculateOn Like'%" + param.sSearch + "%'";

                        }
                        break;
                    case 2:
                        _sortBy = "A.Percentage ";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "B.AllowanceHeadName Like '%" + param.sSearch + "%' or A.FixedAmount Like '%" + param.sSearch + "%' or A.Percentage Like'%" + param.sSearch + "%' or A.EffectedDate Like '%" + param.sSearch + "%' or A.CloseDate Like '%" + param.sSearch + "%' or A.IsCurrent Like '%" + param.sSearch + "%' or  C.PayScaleRuleDescription Like '%" + param.sSearch + "%' or D.AccountName Like '%" + param.sSearch + "%' or  A.CalculateOn Like'%" + param.sSearch + "%'";
                        }
                        break;
                    case 3:
                        _sortBy = "A.EffectedDate ";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "B.AllowanceHeadName Like '%" + param.sSearch + "%' or A.FixedAmount Like '%" + param.sSearch + "%' or A.Percentage Like'%" + param.sSearch + "%' or A.EffectedDate Like '%" + param.sSearch + "%' or A.CloseDate Like '%" + param.sSearch + "%' or A.IsCurrent Like '%" + param.sSearch + "%' or  C.PayScaleRuleDescription Like '%" + param.sSearch + "%' or D.AccountName Like '%" + param.sSearch + "%' or  A.CalculateOn Like'%" + param.sSearch + "%'";

                        }
                        break;
                    case 4:
                        _sortBy = "A.CloseDate ";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "B.AllowanceHeadName Like '%" + param.sSearch + "%' or A.FixedAmount Like '%" + param.sSearch + "%' or A.Percentage Like'%" + param.sSearch + "%' or A.EffectedDate Like '%" + param.sSearch + "%' or A.CloseDate Like '%" + param.sSearch + "%' or A.IsCurrent Like '%" + param.sSearch + "%' or  C.PayScaleRuleDescription Like '%" + param.sSearch + "%' or D.AccountName Like '%" + param.sSearch + "%' or  A.CalculateOn Like'%" + param.sSearch + "%'";

                        }
                        break;
                    case 5:
                        _sortBy = "A.IsCurrent ";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "B.AllowanceHeadName Like '%" + param.sSearch + "%' or A.FixedAmount Like '%" + param.sSearch + "%' or A.Percentage Like'%" + param.sSearch + "%' or A.EffectedDate Like '%" + param.sSearch + "%' or A.CloseDate Like '%" + param.sSearch + "%' or A.IsCurrent Like '%" + param.sSearch + "%' or  C.PayScaleRuleDescription Like '%" + param.sSearch + "%' or D.AccountName Like '%" + param.sSearch + "%' or  A.CalculateOn Like'%" + param.sSearch + "%'";
                        }
                        break;
                    case 6:
                        _sortBy = "C.PayScaleRuleDescription ";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "B.AllowanceHeadName Like '%" + param.sSearch + "%' or A.FixedAmount Like '%" + param.sSearch + "%' or A.Percentage Like'%" + param.sSearch + "%' or A.EffectedDate Like '%" + param.sSearch + "%' or A.CloseDate Like '%" + param.sSearch + "%' or A.IsCurrent Like '%" + param.sSearch + "%' or  C.PayScaleRuleDescription Like '%" + param.sSearch + "%' or D.AccountName Like '%" + param.sSearch + "%' or  A.CalculateOn Like'%" + param.sSearch + "%'";
                        }
                        break;
                    case 7:
                        _sortBy = " D.AccountName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "B.AllowanceHeadName Like '%" + param.sSearch + "%' or A.FixedAmount Like '%" + param.sSearch + "%' or A.Percentage Like'%" + param.sSearch + "%' or A.EffectedDate Like '%" + param.sSearch + "%' or A.CloseDate Like '%" + param.sSearch + "%' or A.IsCurrent Like '%" + param.sSearch + "%' or  C.PayScaleRuleDescription Like '%" + param.sSearch + "%' or D.AccountName Like '%" + param.sSearch + "%' or  A.CalculateOn Like'%" + param.sSearch + "%'";
                        }
                        break;
                    case 8:
                        _sortBy = "A.CalculateOn";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "B.AllowanceHeadName Like '%" + param.sSearch + "%' or A.FixedAmount Like '%" + param.sSearch + "%' or A.Percentage Like'%" + param.sSearch + "%' or A.EffectedDate Like '%" + param.sSearch + "%' or A.CloseDate Like '%" + param.sSearch + "%' or A.IsCurrent Like '%" + param.sSearch + "%' or  C.PayScaleRuleDescription Like '%" + param.sSearch + "%' or D.AccountName Like '%" + param.sSearch + "%' or  A.CalculateOn Like'%" + param.sSearch + "%'";
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredUnitType = GetSalaryAllowanceCurrentSetting(out TotalRecords);
                var records = filteredUnitType.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.AllowanceHeadName), Convert.ToString(c.FixedAmount), Convert.ToString(c.Percentage), Convert.ToString(c.EffectedDate), Convert.ToString(c.CloseDate), Convert.ToString(c.IsCurrent), Convert.ToString(c.PayScaleRuleDescription), Convert.ToString(c.AccountName), Convert.ToString(c.CalculateOn), Convert.ToString(c.SalaryAllowanceMasterID), Convert.ToString(c.SalaryPayRulesID), Convert.ToString(c.MapAccountID), Convert.ToString(c.ID) };

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