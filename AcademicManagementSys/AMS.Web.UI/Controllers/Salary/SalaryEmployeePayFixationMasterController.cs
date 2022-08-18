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
    public class SalaryEmployeePayFixationMasterController : BaseController
    {
        ISalaryEmployeePayFixationMasterServiceAccess _SalaryEmployeePayFixationMasterServiceAcess = null;
        ISalaryPayScaleMasterServiceAccess _SalaryPayScaleMasterServiceAccess = null;
        ISalaryGradePayMasterServiceAccess _SalaryGradePayMasterServiceAccess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public SalaryEmployeePayFixationMasterController()
        {
            _SalaryEmployeePayFixationMasterServiceAcess = new SalaryEmployeePayFixationMasterServiceAccess();
            _SalaryPayScaleMasterServiceAccess = new SalaryPayScaleMasterServiceAccess();
            _SalaryGradePayMasterServiceAccess = new SalaryGradePayMasterServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {

            return View("/Views/Salary/SalaryEmployeePayFixationMaster/Index.cshtml");

        }

        public ActionResult List()
        {
            try
            {
                SalaryEmployeePayFixationMasterViewModel model = new SalaryEmployeePayFixationMasterViewModel();
             
                return PartialView("/Views/Salary/SalaryEmployeePayFixationMaster/List.cshtml", model);
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
            SalaryEmployeePayFixationMasterViewModel model = new SalaryEmployeePayFixationMasterViewModel();

            //*************************For ArriersGenerationStatus***********************

            List<SelectListItem> ArriersGenerationStatus = new List<SelectListItem>();
            ViewBag.ArriersGenerationStatus = new SelectList(ArriersGenerationStatus, "Value", "Text");
            List<SelectListItem> ArriersGenerationStatus_li = new List<SelectListItem>();
            ArriersGenerationStatus_li.Add(new SelectListItem { Text = "Pending", Value = "0" });
            ArriersGenerationStatus_li.Add(new SelectListItem { Text = "Generated", Value = "1" });
            ArriersGenerationStatus_li.Add(new SelectListItem { Text = "Posted", Value = "2" });
            ArriersGenerationStatus_li.Add(new SelectListItem { Text = "Paid", Value = "3" });

            ViewData["ArriersGenerationStatus"] = new SelectList(ArriersGenerationStatus_li, "Value", "Text");
         
            //*******************For PayScaleRange **************************
            List<SalaryPayScaleMaster> PayScaleRange = GetPayScaleRange();
            List<SelectListItem> SalaryPayScaleMasterIDList = new List<SelectListItem>();
            foreach (SalaryPayScaleMaster item in PayScaleRange)
            {
                SalaryPayScaleMasterIDList.Add(new SelectListItem { Text = item.PayScaleRange, Value = Convert.ToString(item.ID) });
            }
            ViewBag.SalaryPayScaleMasterIDsList = new SelectList(SalaryPayScaleMasterIDList, "Value", "Text");

            //***************************For Salary Grade Pay ****************
            List<SalaryGradePayMaster> GradePayAmount = GetListGradePayAmount();
            List<SelectListItem> SalaryGradePayMasterIDsList = new List<SelectListItem>();
            foreach (SalaryGradePayMaster item in GradePayAmount)
            {
                SalaryGradePayMasterIDsList.Add(new SelectListItem { Text = Convert.ToString(item.GradePayAmount), Value = Convert.ToString(item.ID) });
            }
            ViewBag.SalaryGradePayMasterIDsList = new SelectList(SalaryGradePayMasterIDsList, "Value", "Text");
            return PartialView("/Views/Salary/SalaryEmployeePayFixationMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(SalaryEmployeePayFixationMasterViewModel model)
        {
            try
            {
                if (model != null && model.SalaryEmployeePayFixationMasterDTO != null)
                {
                    model.SalaryEmployeePayFixationMasterDTO.ConnectionString = _connectioString;
                    model.SalaryEmployeePayFixationMasterDTO.ID = model.ID;
                    model.SalaryEmployeePayFixationMasterDTO.EmployeeID = model.EmployeeID;
                    model.SalaryEmployeePayFixationMasterDTO.Basic = model.Basic;
                    model.SalaryEmployeePayFixationMasterDTO.SalaryPayScaleMasterID = model.SalaryPayScaleMasterID;
                    model.SalaryEmployeePayFixationMasterDTO.SalaryGradePayMasterID = model.SalaryGradePayMasterID;
                    model.SalaryEmployeePayFixationMasterDTO.ArriersGenerationStatus = model.ArriersGenerationStatus;
                    model.SalaryEmployeePayFixationMasterDTO.OldSalaryEmployeePayFixationMasterID = model.OldSalaryEmployeePayFixationMasterID;
                    model.SalaryEmployeePayFixationMasterDTO.PayIncrementCount = model.PayIncrementCount;
                    model.SalaryEmployeePayFixationMasterDTO.BandPay = model.BandPay;
                    model.SalaryEmployeePayFixationMasterDTO.GradePay = model.GradePay;
                    model.SalaryEmployeePayFixationMasterDTO.ApprovedStatus = model.ApprovedStatus;
                    model.SalaryEmployeePayFixationMasterDTO.ApprovedBy = model.ApprovedBy;
                    model.SalaryEmployeePayFixationMasterDTO.IsCurrent = model.IsCurrent;
                    model.SalaryEmployeePayFixationMasterDTO.OrderDate = model.OrderDate;
                    model.SalaryEmployeePayFixationMasterDTO.OrderNumber = model.OrderNumber;
                    model.SalaryEmployeePayFixationMasterDTO.EffectiveFrom = model.EffectiveFrom;
                    model.SalaryEmployeePayFixationMasterDTO.IsNeedGenerateArriers = model.IsNeedGenerateArriers;
                    model.SalaryEmployeePayFixationMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<SalaryEmployeePayFixationMaster> response = _SalaryEmployeePayFixationMasterServiceAcess.InsertSalaryEmployeePayFixationMaster(model.SalaryEmployeePayFixationMasterDTO);

                    model.SalaryEmployeePayFixationMasterDTO.ErrorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);


                    return Json(model.SalaryEmployeePayFixationMasterDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
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
        //public ActionResult Edit(int id)
        //{
        //    SalaryEmployeePayFixationMasterViewModel model = new SalaryEmployeePayFixationMasterViewModel();
        //    try
        //    {
        //        model.SalaryEmployeePayFixationMasterDTO = new SalaryEmployeePayFixationMaster();
        //        model.SalaryEmployeePayFixationMasterDTO.ID = id;
        //        model.SalaryEmployeePayFixationMasterDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<SalaryEmployeePayFixationMaster> response = _SalaryEmployeePayFixationMasterServiceAcess.SelectByID(model.SalaryEmployeePayFixationMasterDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.SalaryEmployeePayFixationMasterDTO.ID = response.Entity.ID;
        //            model.SalaryEmployeePayFixationMasterDTO.EmployeeID = response.Entity.EmployeeID;
        //            model.SalaryEmployeePayFixationMasterDTO.Basic = response.Entity.Basic;
        //            model.SalaryEmployeePayFixationMasterDTO.SalaryPayScaleMasterID = response.Entity.SalaryPayScaleMasterID;
        //            model.SalaryEmployeePayFixationMasterDTO.SalaryGradePayMasterID = response.Entity.SalaryGradePayMasterID;
        //            model.SalaryEmployeePayFixationMasterDTO.ArriersGenerationStatus = response.Entity.ArriersGenerationStatus;

        //            model.SalaryEmployeePayFixationMasterDTO.CreatedBy = response.Entity.CreatedBy;
        //        }
        //        return PartialView("/Views/Salary/SalaryEmployeePayFixationMaster/Edit.cshtml", model);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //[HttpPost]
        //public ActionResult Edit(SalaryEmployeePayFixationMasterViewModel model)
        //{
        //    try
        //    {
        //        if (model != null && model.SalaryEmployeePayFixationMasterDTO != null)
        //        {
        //              model.SalaryEmployeePayFixationMasterDTO.ConnectionString = _connectioString;
        //              model.SalaryEmployeePayFixationMasterDTO.ID = model.ID;
        //              model.SalaryEmployeePayFixationMasterDTO.EmployeeID = model.EmployeeID;
        //              model.SalaryEmployeePayFixationMasterDTO.Basic = model.Basic;
        //              model.SalaryEmployeePayFixationMasterDTO.SalaryPayScaleMasterID = model.SalaryPayScaleMasterID;
        //              model.SalaryEmployeePayFixationMasterDTO.SalaryGradePayMasterID = model.SalaryGradePayMasterID;
        //              model.SalaryEmployeePayFixationMasterDTO.ArriersGenerationStatus = model.ArriersGenerationStatus;

        //            model.SalaryEmployeePayFixationMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
        //            IBaseEntityResponse<SalaryEmployeePayFixationMaster> response = _SalaryEmployeePayFixationMasterServiceAcess.UpdateSalaryEmployeePayFixationMaster(model.SalaryEmployeePayFixationMasterDTO);
        //            model.SalaryEmployeePayFixationMasterDTO.ErrorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);

        //            return Json(model.SalaryEmployeePayFixationMasterDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
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

        [HttpGet]
        public ActionResult ViewDetails(Int32 SalaryEmployeePAyFixationMasterID,String EmployeeName)
        {
            try
            {
                SalaryEmployeePayFixationMasterViewModel model = new SalaryEmployeePayFixationMasterViewModel();
                model.SalaryEmployeePayFixationMasterDTO = new SalaryEmployeePayFixationMaster();
                model.SalaryEmployeePayFixationMasterDTO.ID = SalaryEmployeePAyFixationMasterID;
                model.SalaryEmployeePayFixationMasterDTO.EmployeeName = EmployeeName;

                model.SalaryEmployeePayFixationMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<SalaryEmployeePayFixationMaster> response = _SalaryEmployeePayFixationMasterServiceAcess.SelectByID(model.SalaryEmployeePayFixationMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.SalaryEmployeePayFixationMasterDTO.ID = response.Entity.ID;
                    model.SalaryEmployeePayFixationMasterDTO.EmployeeID = response.Entity.EmployeeID;
                    model.SalaryEmployeePayFixationMasterDTO.Basic = response.Entity.Basic;
                    model.SalaryEmployeePayFixationMasterDTO.PayScaleRange = response.Entity.PayScaleRange;
                    model.SalaryEmployeePayFixationMasterDTO.GradePayAmount = response.Entity.GradePayAmount;
                    model.SalaryEmployeePayFixationMasterDTO.SalaryPayScaleMasterID = response.Entity.SalaryPayScaleMasterID;
                    model.SalaryEmployeePayFixationMasterDTO.SalaryGradePayMasterID = response.Entity.SalaryGradePayMasterID;
                    model.SalaryEmployeePayFixationMasterDTO.ArriersGenerationStatus = response.Entity.ArriersGenerationStatus;
                    model.SalaryEmployeePayFixationMasterDTO.EmployeeName = response.Entity.EmployeeName;

                    //*************************For ArriersGenerationStatus***********************

                    List<SelectListItem> ArriersGenerationStatus = new List<SelectListItem>();
                    ViewBag.ArriersGenerationStatus = new SelectList(ArriersGenerationStatus, "Value", "Text");
                    List<SelectListItem> ArriersGenerationStatus_li = new List<SelectListItem>();
                    ArriersGenerationStatus_li.Add(new SelectListItem { Text = "Pending", Value = "0" });
                    ArriersGenerationStatus_li.Add(new SelectListItem { Text = "Generated", Value = "1" });
                    ArriersGenerationStatus_li.Add(new SelectListItem { Text = "Posted", Value = "2" });
                    ArriersGenerationStatus_li.Add(new SelectListItem { Text = "Paid", Value = "3" });

                    ViewData["ArriersGenerationStatus"] = new SelectList(ArriersGenerationStatus_li, "Value", "Text");
                    //*******************For PayScaleRange **************************
                    List<SalaryPayScaleMaster> PayScaleRange = GetPayScaleRange();
                    List<SelectListItem> SalaryPayScaleMasterIDList = new List<SelectListItem>();
                    foreach (SalaryPayScaleMaster item in PayScaleRange)
                    {
                        SalaryPayScaleMasterIDList.Add(new SelectListItem { Text = item.PayScaleRange, Value = Convert.ToString(item.ID) });
                    }
                    ViewBag.SalaryPayScaleMasterIDsList = new SelectList(SalaryPayScaleMasterIDList, "Value", "Text");

                    //***************************For Salary Grade Pay ****************
                    List<SalaryGradePayMaster> GradePayAmount = GetListGradePayAmount();
                    List<SelectListItem> SalaryGradePayMasterIDsList = new List<SelectListItem>();
                    foreach (SalaryGradePayMaster item in GradePayAmount)
                    {
                        SalaryGradePayMasterIDsList.Add(new SelectListItem { Text = Convert.ToString(item.GradePayAmount), Value = Convert.ToString(item.ID) });
                    }
                    ViewBag.SalaryGradePayMasterIDsList = new SelectList(SalaryGradePayMasterIDsList, "Value", "Text");
                  
                }

                return PartialView("/Views/Salary/SalaryEmployeePayFixationMaster/View.cshtml", model);
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
                IBaseEntityResponse<SalaryEmployeePayFixationMaster> response = null;
                SalaryEmployeePayFixationMaster SalaryEmployeePayFixationMasterDTO = new SalaryEmployeePayFixationMaster();
                SalaryEmployeePayFixationMasterDTO.ConnectionString = _connectioString;
                SalaryEmployeePayFixationMasterDTO.ID = ID;
                SalaryEmployeePayFixationMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _SalaryEmployeePayFixationMasterServiceAcess.DeleteSalaryEmployeePayFixationMaster(SalaryEmployeePayFixationMasterDTO);
                errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }

        #endregion


       
        // Non-Action Method
        protected List<SalaryPayScaleMaster> GetPayScaleRange()
        {
            SalaryPayScaleMasterSearchRequest searchRequest = new SalaryPayScaleMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<SalaryPayScaleMaster> listSalaryPayScaleMaster = new List<SalaryPayScaleMaster>();
            IBaseEntityCollectionResponse<SalaryPayScaleMaster> baseEntityCollectionResponse = _SalaryPayScaleMasterServiceAccess.GetSalaryPayRangeScale(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSalaryPayScaleMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listSalaryPayScaleMaster;
        }


        protected List<SalaryGradePayMaster> GetListGradePayAmount()
        {
            SalaryGradePayMasterSearchRequest searchRequest = new SalaryGradePayMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<SalaryGradePayMaster> listSalaryGradePayMaster = new List<SalaryGradePayMaster>();
            IBaseEntityCollectionResponse<SalaryGradePayMaster> baseEntityCollectionResponse = _SalaryGradePayMasterServiceAccess.GetListGradePayAmount(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSalaryGradePayMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listSalaryGradePayMaster;
        }
        #region Methods
       //*****For Employee Search List
        public JsonResult GetEmployeeName(string term)
        {
            var data = GetListEmpEmployeeMaster(term);
            var result = (from r in data
                          select new
                          {
                              id = r.ID,
                              name = r.EmployeeFirstName,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
       // #region Methods
        public IEnumerable<SalaryEmployeePayFixationMasterViewModel> GetSalaryEmployeePayFixationMaster(out int TotalRecords)
        {
            SalaryEmployeePayFixationMasterSearchRequest searchRequest = new SalaryEmployeePayFixationMasterSearchRequest();
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
            List<SalaryEmployeePayFixationMasterViewModel> listSalaryEmployeePayFixationMasterViewModel = new List<SalaryEmployeePayFixationMasterViewModel>();
            List<SalaryEmployeePayFixationMaster> listSalaryEmployeePayFixationMaster = new List<SalaryEmployeePayFixationMaster>();
            IBaseEntityCollectionResponse<SalaryEmployeePayFixationMaster> baseEntityCollectionResponse = _SalaryEmployeePayFixationMasterServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSalaryEmployeePayFixationMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (SalaryEmployeePayFixationMaster item in listSalaryEmployeePayFixationMaster)
                    {
                        SalaryEmployeePayFixationMasterViewModel SalaryEmployeePayFixationMasterViewModel = new SalaryEmployeePayFixationMasterViewModel();
                        SalaryEmployeePayFixationMasterViewModel.SalaryEmployeePayFixationMasterDTO = item;
                        listSalaryEmployeePayFixationMasterViewModel.Add(SalaryEmployeePayFixationMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listSalaryEmployeePayFixationMasterViewModel;
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

                IEnumerable<SalaryEmployeePayFixationMasterViewModel> filteredUnitType;
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
                            _searchBy = "EmployeeName Like '%" + param.sSearch + "%' or A.Basic Like '%" + param.sSearch + "%' or A.PayScaleRange Like'%" + param.sSearch + "%' or A.GradePayAmount Like'%" + param.sSearch + "%' or A.ArriersGenerationStatus Like '%"+param.sSearch+"%'";     //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "EmployeeName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "EmployeeName Like '%" + param.sSearch + "%' or A.Basic Like '%" + param.sSearch + "%' or A.PayScaleRange Like'%" + param.sSearch + "%' or A.GradePayAmount Like'%" + param.sSearch + "%'or A.ArriersGenerationStatus Like '%" + param.sSearch + "%'";     //this "if" block is added for search functionality
                        }
                        break;
                    case 2:
                        _sortBy = "A.Basic ";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "EmployeeName Like '%" + param.sSearch + "%' or A.Basic Like '%" + param.sSearch + "%' or A.PayScaleRange Like'%" + param.sSearch + "%' or A.GradePayAmount Like'%" + param.sSearch + "%'or A.ArriersGenerationStatus Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                        }
                        break;
                    case 3:
                        _sortBy = "A.PayScaleRange ";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "EmployeeName Like '%" + param.sSearch + "%' or A.Basic Like '%" + param.sSearch + "%' or A.PayScaleRange Like'%" + param.sSearch + "%' or A.GradePayAmount Like'%" + param.sSearch + "%'A.ArriersGenerationStatus Like '%" + param.sSearch + "%'";     //this "if" block is added for search functionality
                        }
                        break;
                    case 4:
                        _sortBy = "A.GradePayAmount ";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "EmployeeName Like '%" + param.sSearch + "%' or A.Basic Like '%" + param.sSearch + "%' or A.PayScaleRange Like'%" + param.sSearch + "%' or A.GradePayAmount Like'%" + param.sSearch + "%'A.ArriersGenerationStatus Like '%" + param.sSearch + "%'";       //this "if" block is added for search functionality
                        }
                        break;
                    case 5:
                        _sortBy = "A.ArriersGenerationStatus ";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "EmployeeName Like '%" + param.sSearch + "%' or A.Basic Like '%" + param.sSearch + "%' or A.PayScaleRange Like'%" + param.sSearch + "%' or A.GradePayAmount Like'%" + param.sSearch + "%'A.ArriersGenerationStatus Like '%" + param.sSearch + "%'";    //this "if" block is added for search functionality
                        }
                        break;
                   
                   
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredUnitType = GetSalaryEmployeePayFixationMaster(out TotalRecords);
                var records = filteredUnitType.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] {Convert.ToString(c.EmployeeName), Convert.ToString(c.Basic),Convert.ToString(c.PayScaleRange),Convert.ToString(c.GradePayAmount),Convert.ToString(c.ArriersGenerationStatus),Convert.ToString(c.SalaryGradePayMasterID),Convert.ToString(c.SalaryPayScaleMasterID), Convert.ToString(c.ID),Convert.ToString(c.EmployeeID),Convert.ToString(c.EmployeeFirstName),Convert.ToString(c.EmployeeLastName) };

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