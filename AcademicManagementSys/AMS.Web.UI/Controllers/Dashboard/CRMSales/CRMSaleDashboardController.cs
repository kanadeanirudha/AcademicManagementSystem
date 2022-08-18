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
    public class CRMSaleDashboardController : BaseController
    {
        ICRMSaleReportServiceAccess _CRMSaleReportServiceAccess = null;
        //ICRMSaleJobUserJobScheduleSheetServiceAccess _CRMSaleJobUserJobScheduleSheetServiceAccess = null;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        private readonly ILogger _logException;
        public CRMSaleDashboardController()
        {
            _CRMSaleReportServiceAccess = new CRMSaleReportServiceAccess();
            //_CRMSaleJobUserJobScheduleSheetServiceAccess = new CRMSaleJobUserJobScheduleSheetServiceAccess();
        }
        public ActionResult Index()
        {
            CRMSaleReportViewModel model = new CRMSaleReportViewModel();
            try
            {
                model.CRMSaleReportDTO = new CRMSaleReport();
                model.CRMSaleReportDTO.EmployeeID = Convert.ToInt32(Session["PersonID"]);
                model.CRMSaleReportDTO.DataFor = "";
                model.CRMSaleReportDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<CRMSaleReport> response = _CRMSaleReportServiceAccess.CRMSaleDashboardSparklineChartsReportByEmployeeID(model.CRMSaleReportDTO);
                if (response != null && response.Entity != null)
                {
                    model.CRMSaleReportDTO.TodaysMeetingCount = response.Entity.TodaysMeetingCount;
                    model.CRMSaleReportDTO.AccountTarget = response.Entity.AccountTarget;
                    model.CRMSaleReportDTO.BillingTarget = response.Entity.BillingTarget;
                    model.CRMSaleReportDTO.PeriodType = response.Entity.PeriodType;
                    model.CRMSaleReportDTO.TotalInvoiceAmount = response.Entity.TotalInvoiceAmount;
                    model.CRMSaleReportDTO.TotalHotAccount = response.Entity.TotalHotAccount;
                    model.CRMSaleReportDTO.TotalColdAccount = response.Entity.TotalColdAccount;
                    model.CRMSaleReportDTO.TotalEnquiries = response.Entity.TotalEnquiries;
                    model.CRMSaleReportDTO.ConversionRate = response.Entity.ConversionRate;
                }
                return View("/Views/Dashboard/CRMSales/Index.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }


        }

        public ActionResult TopFiveAccountDetails()
        {
            return PartialView("/Views/Dashboard/CRMSales/TopFiveAccountDetails.cshtml");
        }

        public ActionResult MonthlyRevenueDetails()
        {
            return PartialView("/Views/Dashboard/CRMSales/MonthlyRevenueDetails.cshtml");
        }
        public ActionResult TodaysMeeting()
        {
            CRMSaleReportViewModel model = new CRMSaleReportViewModel();
            try
            {
                model.CRMSaleReportDTO = new CRMSaleReport();
                model.CRMSaleReportDTO.EmployeeID = Convert.ToInt32(Session["PersonID"]);
                model.CRMSaleReportDTO.DataFor = "TodaysMeeting";
                model.CRMSaleReportDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<CRMSaleReport> response = _CRMSaleReportServiceAccess.CRMSaleDashboardSparklineChartsReportByEmployeeID(model.CRMSaleReportDTO);
                if (response != null && response.Entity != null)
                {
                    model.CRMSaleReportDTO.ReportCount = response.Entity.ReportCount;
                    model.CRMSaleReportDTO.ReportList = response.Entity.ReportList;
                }
                return PartialView("/Views/Dashboard/CRMSales/TodaysMeeting.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public ActionResult AccountTarget()
        {
            CRMSaleReportViewModel model = new CRMSaleReportViewModel();
            try
            {
                model.CRMSaleReportDTO = new CRMSaleReport();
                model.CRMSaleReportDTO.EmployeeID = Convert.ToInt32(Session["PersonID"]);
                model.CRMSaleReportDTO.DataFor = "AccountTarget";
                model.CRMSaleReportDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<CRMSaleReport> response = _CRMSaleReportServiceAccess.CRMSaleDashboardSparklineChartsReportByEmployeeID(model.CRMSaleReportDTO);
                if (response != null && response.Entity != null)
                {
                    model.CRMSaleReportDTO.ReportCount = response.Entity.ReportCount;
                    model.CRMSaleReportDTO.ReportList = response.Entity.ReportList;
                    model.CRMSaleReportDTO.PeriodType = response.Entity.PeriodType;
                }
                return PartialView("/Views/Dashboard/CRMSales/AccountTarget.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public ActionResult BillingTarget()
        {
            CRMSaleReportViewModel model = new CRMSaleReportViewModel();
            try
            {
                model.CRMSaleReportDTO = new CRMSaleReport();
                model.CRMSaleReportDTO.EmployeeID = Convert.ToInt32(Session["PersonID"]);
                model.CRMSaleReportDTO.DataFor = "BillingTarget";
                model.CRMSaleReportDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<CRMSaleReport> response = _CRMSaleReportServiceAccess.CRMSaleDashboardSparklineChartsReportByEmployeeID(model.CRMSaleReportDTO);
                if (response != null && response.Entity != null)
                {
                    model.CRMSaleReportDTO.ReportCount = response.Entity.ReportCount;
                    model.CRMSaleReportDTO.ReportList = response.Entity.ReportList;
                    model.CRMSaleReportDTO.PeriodType = response.Entity.PeriodType;
                }
                return PartialView("/Views/Dashboard/CRMSales/BillingTarget.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public ActionResult TotalSales()
        {
            CRMSaleReportViewModel model = new CRMSaleReportViewModel();
            try
            {
                model.CRMSaleReportDTO = new CRMSaleReport();
                model.CRMSaleReportDTO.EmployeeID = Convert.ToInt32(Session["PersonID"]);
                model.CRMSaleReportDTO.DataFor = "TotalSale";
                model.CRMSaleReportDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<CRMSaleReport> response = _CRMSaleReportServiceAccess.CRMSaleDashboardSparklineChartsReportByEmployeeID(model.CRMSaleReportDTO);
                if (response != null && response.Entity != null)
                {
                    model.CRMSaleReportDTO.ReportCount = response.Entity.ReportCount;
                    model.CRMSaleReportDTO.ReportList = response.Entity.ReportList;
                }
                return PartialView("/Views/Dashboard/CRMSales/TotalSales.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public ActionResult TotalHotAccount()
        {
            CRMSaleReportViewModel model = new CRMSaleReportViewModel();
            try
            {
            
                model.CRMSaleReportDTO = new CRMSaleReport();
                model.CRMSaleReportDTO.EmployeeID = Convert.ToInt32(Session["PersonID"]);
                model.CRMSaleReportDTO.AdminRoleID = Convert.ToInt32(Session["DefaultRoleID"]);
                model.CRMSaleReportDTO.DataFor = "TotalHotAccount";
                model.CRMSaleReportDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<CRMSaleReport> response = _CRMSaleReportServiceAccess.CRMSaleDashboardSparklineChartsReportByEmployeeID(model.CRMSaleReportDTO);
                if (response != null && response.Entity != null)
                {
                    model.CRMSaleReportDTO.ReportCount = response.Entity.ReportCount;
                    model.CRMSaleReportDTO.ReportList = response.Entity.ReportList;
                }
                return PartialView("/Views/Dashboard/CRMSales/TotalHotAccount.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public ActionResult TotalColdAccount()
        {
            CRMSaleReportViewModel model = new CRMSaleReportViewModel();
            try
            {
                model.CRMSaleReportDTO = new CRMSaleReport();
                model.CRMSaleReportDTO.EmployeeID = Convert.ToInt32(Session["PersonID"]);
                model.CRMSaleReportDTO.DataFor = "TotalColdAccount";
                model.CRMSaleReportDTO.AdminRoleID = Convert.ToInt32(Session["DefaultRoleID"]);
                model.CRMSaleReportDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<CRMSaleReport> response = _CRMSaleReportServiceAccess.CRMSaleDashboardSparklineChartsReportByEmployeeID(model.CRMSaleReportDTO);
                if (response != null && response.Entity != null)
                {
                    model.CRMSaleReportDTO.ReportCount = response.Entity.ReportCount;
                    model.CRMSaleReportDTO.ReportList = response.Entity.ReportList;
                }
                return PartialView("/Views/Dashboard/CRMSales/TotalColdAccount.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public ActionResult TotalExistingAccount()
        {
            CRMSaleReportViewModel model = new CRMSaleReportViewModel();
            try
            {
                model.CRMSaleReportDTO = new CRMSaleReport();
                model.CRMSaleReportDTO.EmployeeID = Convert.ToInt32(Session["PersonID"]);
                model.CRMSaleReportDTO.DataFor = "TotalExistingAccount";
                model.CRMSaleReportDTO.AdminRoleID = Convert.ToInt32(Session["DefaultRoleID"]);
                model.CRMSaleReportDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<CRMSaleReport> response = _CRMSaleReportServiceAccess.CRMSaleDashboardSparklineChartsReportByEmployeeID(model.CRMSaleReportDTO);
                if (response != null && response.Entity != null)
                {
                    model.CRMSaleReportDTO.ReportCount = response.Entity.ReportCount;
                    model.CRMSaleReportDTO.ReportList = response.Entity.ReportList;
                }
                return PartialView("/Views/Dashboard/CRMSales/TotalExistingAccount.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public ActionResult TotalEnquiries()
        {
            CRMSaleReportViewModel model = new CRMSaleReportViewModel();
            try
            {
                model.CRMSaleReportDTO = new CRMSaleReport();
                model.CRMSaleReportDTO.EmployeeID = Convert.ToInt32(Session["PersonID"]);
                model.CRMSaleReportDTO.DataFor = "TotalEnquiries";
                model.CRMSaleReportDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<CRMSaleReport> response = _CRMSaleReportServiceAccess.CRMSaleDashboardSparklineChartsReportByEmployeeID(model.CRMSaleReportDTO);
                if (response != null && response.Entity != null)
                {
                    model.CRMSaleReportDTO.ReportCount = response.Entity.ReportCount;
                    model.CRMSaleReportDTO.ReportList = response.Entity.ReportList;
                }
                return PartialView("/Views/Dashboard/CRMSales/TotalEnquiries.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public ActionResult ConversionRate()
        {
            CRMSaleReportViewModel model = new CRMSaleReportViewModel();
            try
            {
                model.CRMSaleReportDTO = new CRMSaleReport();
                model.CRMSaleReportDTO.EmployeeID = Convert.ToInt32(Session["PersonID"]);
                model.CRMSaleReportDTO.DataFor = "ConversionRate";
                model.CRMSaleReportDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<CRMSaleReport> response = _CRMSaleReportServiceAccess.CRMSaleDashboardSparklineChartsReportByEmployeeID(model.CRMSaleReportDTO);
                if (response != null && response.Entity != null)
                {
                    model.CRMSaleReportDTO.ReportCount = response.Entity.ReportCount;
                    model.CRMSaleReportDTO.ReportList = response.Entity.ReportList;
                }
                return PartialView("/Views/Dashboard/CRMSales/ConversionRate.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public ActionResult MonthyStatusView()
        {
            return PartialView("/Views/Dashboard/CRMSales/MonthyStatusView.cshtml");
        }

        public ActionResult WeeklyStatusView()
        {
            return PartialView("/Views/Dashboard/CRMSales/WeeklyStatusView.cshtml");
        }

        public JsonResult GetWicklyStatusByEmployee(double start, double end)
        {
            try
            {
                var fromDate = ConvertFromMiliSecondsToDate(start);

                var toDate = ConvertFromMiliSecondsToDate(end);


                List<CRMSaleReport> WicklyStatusDetailsCollection = LoadAllWicklyStatusDetailsInDateRange(fromDate, toDate, Convert.ToInt32(Session["PersonID"]));
                var eventList = from e in WicklyStatusDetailsCollection
                                select new
                                {
                                    title = e.ScheduleDescription,
                                    start = e.TransactionFromDateTime.ToString("s"),
                                    end = e.TransactionUpToTime.ToString("s"),
                                    allDay = false,
                                    backgroundColor = e.BackgroundColor,
                                    borderColor = "#9FEA7A"
                                };
                var rows = eventList.ToArray();

                return Json(rows, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public JsonResult GetMonthStatusByEmployee(double start, double end)
        {
            try
            {
                var fromDate = ConvertFromMiliSecondsToDate(start);
                var toDate = ConvertFromMiliSecondsToDate(end);
                List<CRMSaleReport> WicklyStatusDetailsCollection = LoadAllWicklyStatusDetailsInDateRange(fromDate, toDate, Convert.ToInt32(Session["PersonID"]));
                var eventList = from e in WicklyStatusDetailsCollection
                                select new
                                {
                                    title = e.ScheduleDescription,
                                    start = e.TransactionDate,
                                    end = e.TransactionDate.AddMinutes(e.ScheduleTimeInMin).ToString("s"),
                                    //color = "red",//e.EventColor,
                                    allDay = true,
                                    editable = false,
                                    //weeklyOffStatus = e.WeeklyOffStatus,
                                    //leaveCode = e.LeaveCode,
                                    //attendanceDescription = e.AttendanceDescription,
                                    //checkInTime = e.CheckInTime,
                                    //checkOutTime = e.CheckOutTime,
                                    //workingHour = e.WorkingHour,
                                    //   halfLeaveStatus = e.HalfLeaveStatus,
                                    backgroundColor = e.BackgroundColor,
                                    borderColor = "#9FEA7A"
                                };
                var rows = eventList.ToArray();
                return Json(rows, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public JsonResult CRMSaleTopFiveAccountByEmployeeList()
        {

            var CRMSaleRevenuDetails = CRMSaleTopFiveAccountByEmployeeList(Convert.ToInt32(Session["PersonID"]), Convert.ToInt32(Session["DefaultRoleID"]));
            var result = (from s in CRMSaleRevenuDetails
                          select new
                          {
                              accountName = s.AccountName,
                              totalInvoiceAmountList = s.TotalInvoiceAmountList,
                              invoiceMonth = s.InvoiceMonth,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetCRMSaleMonthlyRevenueReport()
        {

            var CRMSaleRevenuDetails = GetCRMSaleMonthlyRevenueReport(Convert.ToInt32(Session["PersonID"]), Convert.ToInt32(Session["RoleID"]));
            var result = (from s in CRMSaleRevenuDetails
                          select new
                          {
                              totalInvoiceAmount = s.TotalInvoiceAmount,
                              //  invoiceMonth = s.InvoiceMonth,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetTodaysMeetingList()
        {
            CRMSaleReportViewModel model = new CRMSaleReportViewModel();
            ViewBag.ListCRMSaleTodaysMeetingDetails = GetListTodaysMeetingSchedule();

            return PartialView("/Views/Dashboard/CRMSales/TodaysMeetingList.cshtml", model);
        }

        public ActionResult GetTodaysEnquiriesList()
        {
            CRMSaleReportViewModel model = new CRMSaleReportViewModel();

            ViewBag.ListCRMSaleEnquiryMasterAndAccountDetails = GetListTodaysEnquiryDetails();

            return PartialView("/Views/Dashboard/CRMSales/TodaysEnquiryList.cshtml", model);
        }

        public ActionResult RemindersList()
        {
            CRMSaleReportViewModel model = new CRMSaleReportViewModel();
            ViewBag.GetCRMSaleRemindersListDetails = GetListReminders(0, 5);

            return PartialView("/Views/Dashboard/CRMSales/ReminderList.cshtml", model);
        }

        public ActionResult SalesCallList()
        {
            CRMSaleReportViewModel model = new CRMSaleReportViewModel();
            ViewBag.GetCRMSaleSalesCallDetails = GetListSalesCallSchedule();
            return PartialView("/Views/Dashboard/CRMSales/SalesCalls.cshtml", model);
        }

        public ActionResult RemindersListAll()
        {
            CRMSaleReportViewModel model = new CRMSaleReportViewModel();
            ViewBag.GetCRMSaleRemindersAllList = GetListReminders(0, 1000);

            return PartialView("/Views/Dashboard/CRMSales/ViewReminderAll.cshtml", model);
        }


        // Non-Action Method
        #region Methods


        protected List<CRMSaleReport> CRMSaleTopFiveAccountByEmployeeList(int employeeID, int adminRoleID)
        {
            CRMSaleReportSearchRequest searchRequest = new CRMSaleReportSearchRequest();
            searchRequest.EmployeeID = employeeID;
            searchRequest.AdminRoleID = adminRoleID;

            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<CRMSaleReport> CRMCallerCallDetailsList = new List<CRMSaleReport>();

            IBaseEntityCollectionResponse<CRMSaleReport> baseEntityCollectionResponse = _CRMSaleReportServiceAccess.GetCRMSaleTopFiveAccountReport(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    CRMCallerCallDetailsList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return CRMCallerCallDetailsList;
        }

        protected List<CRMSaleReport> GetCRMSaleMonthlyRevenueReport(int employeeID, int adminRoleID)
        {
            CRMSaleReportSearchRequest searchRequest = new CRMSaleReportSearchRequest();
            searchRequest.EmployeeID = employeeID;
            searchRequest.AdminRoleID = adminRoleID;

            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<CRMSaleReport> CRMCallerCallDetailsList = new List<CRMSaleReport>();

            IBaseEntityCollectionResponse<CRMSaleReport> baseEntityCollectionResponse = _CRMSaleReportServiceAccess.GetCRMSaleMonthlyRevenueReport(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    CRMCallerCallDetailsList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return CRMCallerCallDetailsList;
        }

        //protected List<CRMSaleReport> LoadAllWicklyStatusDetailsInDateRange(DateTime fromDate, DateTime toDate)
        //{
        //    try
        //    {
        //        CRMSaleReportSearchRequest searchRequest = new CRMSaleReportSearchRequest();
        //        searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        //        searchRequest.EmployeeID = Convert.ToInt32(Session["PersonID"]);
        //        searchRequest.FromDate = fromDate;
        //        searchRequest.UptoDate = toDate;
        //        List<CRMSaleReport> listCRMSaleReport = new List<CRMSaleReport>();
        //        IBaseEntityCollectionResponse<CRMSaleReport> baseEntityCollectionResponse = _CRMSaleReportServiceAccess.GetCRMSaleWicklyStatusDetailsInDateRangeReport(searchRequest);
        //        if (baseEntityCollectionResponse != null)
        //        {
        //            if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
        //            {
        //                listCRMSaleReport = baseEntityCollectionResponse.CollectionResponse.ToList();
        //            }
        //        }
        //        return listCRMSaleReport;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logException.Error(ex.Message);
        //        throw;
        //    }
        //}


        protected List<CRMSaleReport> GetListTodaysMeetingSchedule()
        {
            CRMSaleReportSearchRequest searchRequest = new CRMSaleReportSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.EmployeeID = Convert.ToInt32(Session["PersonID"]);

            List<CRMSaleReport> listJobScheduleSheet = new List<CRMSaleReport>();
            IBaseEntityCollectionResponse<CRMSaleReport> baseEntityCollectionResponse = _CRMSaleReportServiceAccess.GetListTodaysMeetingSchedule(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listJobScheduleSheet = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listJobScheduleSheet;
        }

        protected List<CRMSaleReport> GetListTodaysEnquiryDetails()
        {
            CRMSaleReportSearchRequest searchRequest = new CRMSaleReportSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.EmployeeID = Convert.ToInt32(Session["PersonID"]);

            List<CRMSaleReport> listEnquiryDetail = new List<CRMSaleReport>();
            IBaseEntityCollectionResponse<CRMSaleReport> baseEntityCollectionResponse = _CRMSaleReportServiceAccess.GetListTodaysEnquiryDetails(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEnquiryDetail = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listEnquiryDetail;
        }

        protected List<CRMSaleReport> GetListSalesCallSchedule()
        {
            CRMSaleReportSearchRequest searchRequest = new CRMSaleReportSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.EmployeeID = Convert.ToInt32(Session["PersonID"]);
            searchRequest.TodaysDate = DateTime.Now; ;

            List<CRMSaleReport> listJobScheduleSheet = new List<CRMSaleReport>();
            IBaseEntityCollectionResponse<CRMSaleReport> baseEntityCollectionResponse = _CRMSaleReportServiceAccess.GetListSalesCallSchedule(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listJobScheduleSheet = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listJobScheduleSheet;
        }

        protected List<CRMSaleReport> GetListReminders(int startRow, int endRow)
        {
            CRMSaleReportSearchRequest searchRequest = new CRMSaleReportSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.EmployeeID = Convert.ToInt32(Session["UserID"]);
            searchRequest.TodaysDate = DateTime.Now;
            searchRequest.StartRow = startRow;
            searchRequest.EndRow = endRow;

            List<CRMSaleReport> listJobScheduleSheet = new List<CRMSaleReport>();
            IBaseEntityCollectionResponse<CRMSaleReport> baseEntityCollectionResponse = _CRMSaleReportServiceAccess.GetListReminders(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listJobScheduleSheet = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listJobScheduleSheet;
        }

        #endregion
    }
}
