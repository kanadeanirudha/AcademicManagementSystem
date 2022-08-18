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

using System.IO;
using System.Net;
using System.Text;
using System.Data;

namespace AMS.Web.UI.Controllers
{
    public class CRMSaleEmployeeScheduleController : BaseController
    {
        ICRMSaleJobUserJobScheduleSheetServiceAccess _CRMSaleJobUserJobScheduleSheetServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        static int _employeeID;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public CRMSaleEmployeeScheduleController()
        {
            _CRMSaleJobUserJobScheduleSheetServiceAcess = new CRMSaleJobUserJobScheduleSheetServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index(string EmployeeID)
        {
            CRMSaleJobUserJobScheduleSheetViewModel model = new CRMSaleJobUserJobScheduleSheetViewModel();
            //Get Employee
            model.ListEmpEmployeeMaster = GetListEmpEmployeeMasterInCRMSales(0, "EmployeeListNotInTargetException");
            if (EmployeeID != null && EmployeeID != string.Empty)
            {
                _employeeID = Convert.ToInt32(EmployeeID);
            }else
            {
                _employeeID = 0;
            }
            model.CRMSaleJobUserJobScheduleSheetDTO.EmployeeID = _employeeID;
            return View("/Views/CRMSales/CRMSaleEmployeeSchedule/Index.cshtml", model);
        }

        #endregion

        public JsonResult GetWicklyStatusByEmployee(double start, double end)
        {
            try
            {
                var fromDate = ConvertFromMiliSecondsToDate(start);
                var toDate = ConvertFromMiliSecondsToDate(end);                

                List<CRMSaleReport> WicklyStatusDetailsCollection = LoadAllWicklyStatusDetailsInDateRange(fromDate, toDate, _employeeID);
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

                List<CRMSaleReport> WicklyStatusDetailsCollection = LoadAllWicklyStatusDetailsInDateRange(fromDate, toDate, _employeeID);
                var eventList = from e in WicklyStatusDetailsCollection
                                select new
                                {
                                    title = e.ScheduleDescription,
                                    start = e.TransactionDate,
                                    end = e.TransactionDate.AddMinutes(e.ScheduleTimeInMin).ToString("s"),
                                    allDay = true,
                                    editable = false,
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

    }
}
