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
    public class SalaryDeductionCurrentSettingController : BaseController
    {
        ISalaryDeductionCurrentSettingServiceAccess _SalaryDeductionCurrentSettingServiceAcess = null;
        ISalaryPayRulesServiceAccess _SalaryPayRulesServiceAccess = null;
        ISalaryDeductionMasterServiceAccess _SalaryDeductionMasterServiceAccess = null;
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

        public SalaryDeductionCurrentSettingController()
        {
            _SalaryDeductionCurrentSettingServiceAcess = new SalaryDeductionCurrentSettingServiceAccess();
            _SalaryPayRulesServiceAccess = new SalaryPayRulesServiceAccess();
            _SalaryDeductionMasterServiceAccess = new SalaryDeductionMasterServiceAccess();
            _GeneralTypeOfAccountServiceAcess = new GeneralTypeOfAccountServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {

            return View("/Views/Salary/SalaryDeductionCurrentSetting/Index.cshtml");

        }

        public ActionResult List(string actionMode)
        {
            try
            {
                SalaryDeductionCurrentSettingViewModel model = new SalaryDeductionCurrentSettingViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Salary/SalaryDeductionCurrentSetting/List.cshtml", model);
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
            SalaryDeductionCurrentSettingViewModel model = new SalaryDeductionCurrentSettingViewModel();
            //**************************DropDown List Head NAme*********************
            List<SalaryDeductionMaster> DeductionHeadName = GetListSalaryDeductionMaster();
            List<SelectListItem> SalaryDeductionMasterIDsList = new List<SelectListItem>();
            foreach (SalaryDeductionMaster item in DeductionHeadName)
            {
                SalaryDeductionMasterIDsList.Add(new SelectListItem { Text = item.DeductionHeadName, Value = Convert.ToString(item.ID) });
            }
            ViewBag.SalaryDeductionMasterIDsList = new SelectList(SalaryDeductionMasterIDsList, "Value", "Text");


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

            return PartialView("/Views/Salary/SalaryDeductionCurrentSetting/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(SalaryDeductionCurrentSettingViewModel model)
        {
            try
            {
                if (model != null && model.SalaryDeductionCurrentSettingDTO != null)
                {
                    model.SalaryDeductionCurrentSettingDTO.ConnectionString = _connectioString;
                    model.SalaryDeductionCurrentSettingDTO.SalaryDeductionMasterID = model.SalaryDeductionMasterID;
                  //  model.SalaryDeductionCurrentSettingDTO.DeductionHeadName = model.DeductionHeadName;
                    model.SalaryDeductionCurrentSettingDTO.FixAmount = model.FixAmount;
                    model.SalaryDeductionCurrentSettingDTO.Percentage = model.Percentage;
                  
                    model.SalaryDeductionCurrentSettingDTO.MapAccountID = model.MapAccountID;
                   // model.SalaryDeductionCurrentSettingDTO.AccountName = model.AccountName;
                    model.SalaryDeductionCurrentSettingDTO.CalculateOn = model.CalculateOn; ;

                    model.SalaryDeductionCurrentSettingDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<SalaryDeductionCurrentSetting> response = _SalaryDeductionCurrentSettingServiceAcess.InsertSalaryDeductionCurrentSetting(model.SalaryDeductionCurrentSettingDTO);

                    model.SalaryDeductionCurrentSettingDTO.ErrorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);


                    return Json(model.SalaryDeductionCurrentSettingDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
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
            SalaryDeductionCurrentSettingViewModel model = new SalaryDeductionCurrentSettingViewModel();
            try
            {
                model.SalaryDeductionCurrentSettingDTO = new SalaryDeductionCurrentSetting();
                model.SalaryDeductionCurrentSettingDTO.ID = id;
                model.SalaryDeductionCurrentSettingDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<SalaryDeductionCurrentSetting> response = _SalaryDeductionCurrentSettingServiceAcess.SelectByID(model.SalaryDeductionCurrentSettingDTO);
                if (response != null && response.Entity != null)
                {
                    model.SalaryDeductionCurrentSettingDTO.ID = response.Entity.ID;
                    model.SalaryDeductionCurrentSettingDTO.SalaryDeductionMasterID = response.Entity.SalaryDeductionMasterID;

                    model.SalaryDeductionCurrentSettingDTO.FixAmount = response.Entity.FixAmount;
                    model.SalaryDeductionCurrentSettingDTO.Percentage = response.Entity.Percentage;

                    model.SalaryDeductionCurrentSettingDTO.DeductionHeadName = Convert.ToString(response.Entity.SalaryDeductionMasterID);
                  
                    model.SalaryDeductionCurrentSettingDTO.AccountName = Convert.ToString(response.Entity.MapAccountID);
                    model.SalaryDeductionCurrentSettingDTO.CalculateOn = response.Entity.CalculateOn;

                 
                    //**************************DropDown List Head NAme*********************
                    List<SalaryDeductionMaster> DeductionHeadName = GetListSalaryDeductionMaster();
                    List<SelectListItem> SalaryDeductionMasterIDsList = new List<SelectListItem>();
                    foreach (SalaryDeductionMaster item in DeductionHeadName)
                    {
                        SalaryDeductionMasterIDsList.Add(new SelectListItem { Text = item.DeductionHeadName, Value = Convert.ToString(item.ID) });
                    }
                    ViewBag.SalaryDeductionMasterIDsList = new SelectList(SalaryDeductionMasterIDsList, "Value", "Text");

                   
                    //*************************DropDown List For Account Name******************************
                    string dispalyFor = "SelectList";
                    List<GeneralTypeOfAccount> GeneralTypeOfAccount = GetListGeneralTypeOfAccount(dispalyFor);
                    List<SelectListItem> GeneralTypeOfAccountList = new List<SelectListItem>();

                    foreach (GeneralTypeOfAccount item in GeneralTypeOfAccount)
                    {
                        GeneralTypeOfAccountList.Add(new SelectListItem { Text = item.AccountName, Value = Convert.ToString((item.AccountMasterId)) });
                    }
                    ViewBag.GeneralTypeOfAccountList = new SelectList(GeneralTypeOfAccountList, "Value", "Text", model.SalaryDeductionCurrentSettingDTO.AccountName);
                    //*************************DropDown List For Calculate On*******************************
                    List<SelectListItem> CalculateOn = new List<SelectListItem>();
                    ViewBag.CalculateOn = new SelectList(CalculateOn, "Value", "Text");
                    List<SelectListItem> CalculateOn_li = new List<SelectListItem>();
                    CalculateOn_li.Add(new SelectListItem { Text = "Basic", Value = "1" });
                    CalculateOn_li.Add(new SelectListItem { Text = "Gross Pay", Value = "2" });

                    ViewData["CalculateOn"] = new SelectList(CalculateOn_li, "Value", "Text");

                }
                return PartialView("/Views/Salary/SalaryDeductionCurrentSetting/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(SalaryDeductionCurrentSettingViewModel model)
        {
            try
            {
                if (model != null && model.SalaryDeductionCurrentSettingDTO != null)
                {
                    model.SalaryDeductionCurrentSettingDTO.ConnectionString = _connectioString;

                    model.SalaryDeductionCurrentSettingDTO.SalaryDeductionMasterID = model.SalaryDeductionMasterID;
                    // model.SalaryDeductionCurrentSettingDTO.AllowanceHeadName = model.AllowanceHeadName;
                    model.SalaryDeductionCurrentSettingDTO.FixAmount = model.FixAmount;
                    model.SalaryDeductionCurrentSettingDTO.Percentage = model.Percentage;
                  
                    // model.SalaryDeductionCurrentSettingDTO.PayScaleRuleDescription = model.PayScaleRuleDescription;
                    model.SalaryDeductionCurrentSettingDTO.MapAccountID = model.MapAccountID;
                    // model.SalaryDeductionCurrentSettingDTO.AccountName = model.AccountName;
                    model.SalaryDeductionCurrentSettingDTO.CalculateOn = model.CalculateOn; ;

                    model.SalaryDeductionCurrentSettingDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<SalaryDeductionCurrentSetting> response = _SalaryDeductionCurrentSettingServiceAcess.UpdateSalaryDeductionCurrentSetting(model.SalaryDeductionCurrentSettingDTO);
                    model.SalaryDeductionCurrentSettingDTO.ErrorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);

                    return Json(model.SalaryDeductionCurrentSettingDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
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
                SalaryDeductionCurrentSettingViewModel model = new SalaryDeductionCurrentSettingViewModel();
                model.SalaryDeductionCurrentSettingDTO = new SalaryDeductionCurrentSetting();
                model.SalaryDeductionCurrentSettingDTO.ID = Convert.ToInt16(ID);
                model.SalaryDeductionCurrentSettingDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<SalaryDeductionCurrentSetting> response = _SalaryDeductionCurrentSettingServiceAcess.SelectByID(model.SalaryDeductionCurrentSettingDTO);
                if (response != null && response.Entity != null)
                {

                }

                return PartialView("/Views/Salary/SalaryDeductionCurrentSetting/ViewDetails.cshtml", model);
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
                IBaseEntityResponse<SalaryDeductionCurrentSetting> response = null;
                SalaryDeductionCurrentSetting SalaryDeductionCurrentSettingDTO = new SalaryDeductionCurrentSetting();
                SalaryDeductionCurrentSettingDTO.ConnectionString = _connectioString;
                SalaryDeductionCurrentSettingDTO.ID = ID;
                SalaryDeductionCurrentSettingDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _SalaryDeductionCurrentSettingServiceAcess.DeleteSalaryDeductionCurrentSetting(SalaryDeductionCurrentSettingDTO);
                errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }

        #endregion

        // Non-Action Method
    
        //***************************For Dropdown List For Allowance Head Name********************
        protected List<SalaryDeductionMaster> GetListSalaryDeductionMaster()
        {
            SalaryDeductionMasterSearchRequest searchRequest = new SalaryDeductionMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<SalaryDeductionMaster> listSalaryDeductionMaster = new List<SalaryDeductionMaster>();
            IBaseEntityCollectionResponse<SalaryDeductionMaster> baseEntityCollectionResponse = _SalaryDeductionMasterServiceAccess.GetAllowanceHeadNameList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSalaryDeductionMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listSalaryDeductionMaster;
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
        public IEnumerable<SalaryDeductionCurrentSettingViewModel> GetSalaryDeductionCurrentSetting(out int TotalRecords)
        {
            SalaryDeductionCurrentSettingSearchRequest searchRequest = new SalaryDeductionCurrentSettingSearchRequest();
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
            List<SalaryDeductionCurrentSettingViewModel> listSalaryDeductionCurrentSettingViewModel = new List<SalaryDeductionCurrentSettingViewModel>();
            List<SalaryDeductionCurrentSetting> listSalaryDeductionCurrentSetting = new List<SalaryDeductionCurrentSetting>();
            IBaseEntityCollectionResponse<SalaryDeductionCurrentSetting> baseEntityCollectionResponse = _SalaryDeductionCurrentSettingServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSalaryDeductionCurrentSetting = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (SalaryDeductionCurrentSetting item in listSalaryDeductionCurrentSetting)
                    {
                        SalaryDeductionCurrentSettingViewModel SalaryDeductionCurrentSettingViewModel = new SalaryDeductionCurrentSettingViewModel();
                        SalaryDeductionCurrentSettingViewModel.SalaryDeductionCurrentSettingDTO = item;
                        listSalaryDeductionCurrentSettingViewModel.Add(SalaryDeductionCurrentSettingViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listSalaryDeductionCurrentSettingViewModel;
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

                IEnumerable<SalaryDeductionCurrentSettingViewModel> filteredUnitType;
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
                            _searchBy = "B.DeductionHeadName Like '%" + param.sSearch + "%' or A.FixAmount Like '%" + param.sSearch + "%' or A.Percentage Like'%" + param.sSearch + "%' or C.AccountName Like '%" + param.sSearch + "%' or  A.CalculateOn Like'%" + param.sSearch + "%'";      //this "if" block is added for search functionality
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
                            _searchBy = "B.DeductionHeadName Like '%" + param.sSearch + "%' or A.FixAmount Like '%" + param.sSearch + "%' or A.Percentage Like'%" + param.sSearch + "%' or C.AccountName Like '%" + param.sSearch + "%' or  A.CalculateOn Like'%" + param.sSearch + "%'";      //this "if" block is added for search functionality

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
                            _searchBy = "B.DeductionHeadName Like '%" + param.sSearch + "%' or A.FixAmount Like '%" + param.sSearch + "%' or A.Percentage Like'%" + param.sSearch + "%' or C.AccountName Like '%" + param.sSearch + "%' or  A.CalculateOn Like'%" + param.sSearch + "%'";      //this "if" block is added for search functionality
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
                            _searchBy = "B.DeductionHeadName Like '%" + param.sSearch + "%' or A.FixAmount Like '%" + param.sSearch + "%' or A.Percentage Like'%" + param.sSearch + "%' or C.AccountName Like '%" + param.sSearch + "%' or  A.CalculateOn Like'%" + param.sSearch + "%'";      //this "if" block is added for search functionality

                        }
                        break;
                  
                    case 4:
                        _sortBy = " D.AccountName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "B.DeductionHeadName Like '%" + param.sSearch + "%' or A.FixAmount Like '%" + param.sSearch + "%' or A.Percentage Like'%" + param.sSearch + "%' or C.AccountName Like '%" + param.sSearch + "%' or  A.CalculateOn Like'%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                        }
                        break;
                    case 5:
                        _sortBy = "A.CalculateOn";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "B.DeductionHeadName Like '%" + param.sSearch + "%' or A.FixAmount Like '%" + param.sSearch + "%' or A.Percentage Like'%" + param.sSearch + "%' or C.AccountName Like '%" + param.sSearch + "%' or  A.CalculateOn Like'%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredUnitType = GetSalaryDeductionCurrentSetting(out TotalRecords);
                var records = filteredUnitType.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.DeductionHeadName), Convert.ToString(c.FixAmount), Convert.ToString(c.Percentage), Convert.ToString(c.AccountName), Convert.ToString(c.CalculateOn), Convert.ToString(c.SalaryDeductionMasterID),  Convert.ToString(c.MapAccountID), Convert.ToString(c.ID) };

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