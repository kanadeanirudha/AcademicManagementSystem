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
    public class CRMSaleNotificationTransactionController : BaseController
    {
        INotificationTypeMasterAndNotificationTransactionServiceAccess _NotificationTypeMasterAndNotificationTransactionServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public CRMSaleNotificationTransactionController()
        {
            _NotificationTypeMasterAndNotificationTransactionServiceAcess = new NotificationTypeMasterAndNotificationTransactionServiceAccess();
        }


        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {

            return View("/Views/CRMSales/CRMSaleNotificationTransaction/Index.cshtml");
        }

        public ActionResult List(string actionMode)
        {
            try
            {
                NotificationTypeMasterAndNotificationTransactionViewModel model = new NotificationTypeMasterAndNotificationTransactionViewModel();

                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/CRMSales/CRMSaleNotificationTransaction/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult Push()
        {
            NotificationTypeMasterAndNotificationTransactionViewModel model = new NotificationTypeMasterAndNotificationTransactionViewModel();

            //Get Employee
            model.ListEmpEmployeeMaster = GetListEmpEmployeeMasterInCRMSales(0, "EmployeeListNotificationTransaction");
            model.FromUserID = Convert.ToInt32(Session["PersonID"]);
            foreach (var email in model.ListEmpEmployeeMaster)
            {
                if (email.ID == Convert.ToInt32(Session["UserID"]))
                {
                    model.FromMailID = email.EmailID;
                }
            }

            return PartialView("/Views/CRMSales/CRMSaleNotificationTransaction/Push.cshtml", model);
        }

        [HttpPost]
        public ActionResult Push(NotificationTypeMasterAndNotificationTransactionViewModel model)
        {
            try
            {
                if (model != null && model.NotificationTypeMasterAndNotificationTransactionDTO != null)
                {
                    model.NotificationTypeMasterAndNotificationTransactionDTO.ConnectionString = _connectioString;
                    model.NotificationTypeMasterAndNotificationTransactionDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);

                    model.NotificationTypeMasterAndNotificationTransactionDTO.NotificationTypeMasterID = model.NotificationTypeMasterID;
                    model.NotificationTypeMasterAndNotificationTransactionDTO.FromUserID = model.FromUserID;
                    model.NotificationTypeMasterAndNotificationTransactionDTO.FromMailID = model.FromMailID;
                    model.NotificationTypeMasterAndNotificationTransactionDTO.ToMailID = model.ToMailID;
                    model.NotificationTypeMasterAndNotificationTransactionDTO.SubjectDescription = model.SubjectDescription;
                    model.NotificationTypeMasterAndNotificationTransactionDTO.BodyDescription = model.BodyDescription;

                    IBaseEntityResponse<NotificationTypeMasterAndNotificationTransaction> response = _NotificationTypeMasterAndNotificationTransactionServiceAcess.InsertNotificationTransaction(model.NotificationTypeMasterAndNotificationTransactionDTO);
                    model.NotificationTypeMasterAndNotificationTransactionDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.NotificationTypeMasterAndNotificationTransactionDTO.errorMessage, JsonRequestBehavior.AllowGet);

                }
                return Json("Please review your form");
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult ViewPushNotification(int NotificationTransactionID)
        {
            NotificationTypeMasterAndNotificationTransactionViewModel model = new NotificationTypeMasterAndNotificationTransactionViewModel();
            try
            {
                model.NotificationTypeMasterAndNotificationTransactionDTO = new NotificationTypeMasterAndNotificationTransaction();
                model.NotificationTypeMasterAndNotificationTransactionDTO.ConnectionString = _connectioString;
                model.NotificationTypeMasterAndNotificationTransactionDTO.NotificationTransactionID = NotificationTransactionID;

                //Get Employee
                model.ListEmpEmployeeMaster = GetListEmpEmployeeMasterInCRMSales(0, "EmployeeListNotificationTransaction");
                //model.FromUserID = Convert.ToInt32(Session["UserID"]);

                IBaseEntityResponse<NotificationTypeMasterAndNotificationTransaction> response = _NotificationTypeMasterAndNotificationTransactionServiceAcess.SelectByNotificationTransactionID(model.NotificationTypeMasterAndNotificationTransactionDTO);

                if (response != null && response.Entity != null)
                {
                    model.NotificationTypeMasterAndNotificationTransactionDTO.ToUserID = response.Entity.ToUserID;
                    model.NotificationTypeMasterAndNotificationTransactionDTO.ToMailID = response.Entity.ToMailID;
                    model.NotificationTypeMasterAndNotificationTransactionDTO.SubjectDescription = response.Entity.SubjectDescription;
                    model.NotificationTypeMasterAndNotificationTransactionDTO.BodyDescription = response.Entity.BodyDescription;
                }
                return PartialView("/Views/CRMSales/CRMSaleNotificationTransaction/ViewPushNotification.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        #endregion



        // Non-Action Method
        #region Methods

        public IEnumerable<NotificationTypeMasterAndNotificationTransactionViewModel> GetNotificationTypeMasterAndNotificationTransaction(out int TotalRecords)
        {
            NotificationTypeMasterAndNotificationTransactionSearchRequest searchRequest = new NotificationTypeMasterAndNotificationTransactionSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ToUserID = Convert.ToInt32(Session["UserID"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);

            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "A.CreatedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = String.Empty;
                    searchRequest.SortDirection = "Desc";
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "A.ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = String.Empty;
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
            List<NotificationTypeMasterAndNotificationTransactionViewModel> listNotificationTypeMasterAndTransactionVM = new List<NotificationTypeMasterAndNotificationTransactionViewModel>();
            List<NotificationTypeMasterAndNotificationTransaction> listNotificationTypeAndTransaction = new List<NotificationTypeMasterAndNotificationTransaction>();
            IBaseEntityCollectionResponse<NotificationTypeMasterAndNotificationTransaction> baseEntityCollectionResponse = _NotificationTypeMasterAndNotificationTransactionServiceAcess.GetBySearchNotificationTransaction(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listNotificationTypeAndTransaction = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (NotificationTypeMasterAndNotificationTransaction item in listNotificationTypeAndTransaction)
                    {
                        NotificationTypeMasterAndNotificationTransactionViewModel NotificationTypeVM = new NotificationTypeMasterAndNotificationTransactionViewModel();
                        NotificationTypeVM.NotificationTypeMasterAndNotificationTransactionDTO = item;
                        listNotificationTypeMasterAndTransactionVM.Add(NotificationTypeVM);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listNotificationTypeMasterAndTransactionVM;
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

                IEnumerable<NotificationTypeMasterAndNotificationTransactionViewModel> filteredNotificationTypeMaster;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "D.FirstName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "D.FirstName Like '%" + param.sSearch + "%' or C.FirstName Like '%" + param.sSearch + "%' or B.SubjectDescription Like '%" + param.sSearch + "%' or B.TransactionDate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "C.FirstName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "D.FirstName Like '%" + param.sSearch + "%' or C.FirstName Like '%" + param.sSearch + "%' or B.SubjectDescription Like '%" + param.sSearch + "%' or B.TransactionDate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 2:
                        _sortBy = "B.SubjectDescription";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "D.FirstName Like '%" + param.sSearch + "%' or C.FirstName Like '%" + param.sSearch + "%' or B.SubjectDescription Like '%" + param.sSearch + "%' or B.TransactionDate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 3:
                        _sortBy = "B.TransactionDate";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "D.FirstName Like '%" + param.sSearch + "%' or C.FirstName Like '%" + param.sSearch + "%' or B.SubjectDescription Like '%" + param.sSearch + "%' or B.TransactionDate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality

                        }
                        break;

                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredNotificationTypeMaster = GetNotificationTypeMasterAndNotificationTransaction(out TotalRecords);

                if ((filteredNotificationTypeMaster.Count()) == 0)
                {
                    filteredNotificationTypeMaster = new List<NotificationTypeMasterAndNotificationTransactionViewModel>();
                    TotalRecords = 0;
                }

                var records = filteredNotificationTypeMaster.Skip(0).Take(param.iDisplayLength);
                var result = from c in records
                             select new[] { 
                                             Convert.ToString(c.NotificationTypeMasterID), 
                                             Convert.ToString(c.NotificationTransactionID), 
                                             Convert.ToString(c.NotificationType), 
                                             Convert.ToString(c.TransactionDate), 
                                             Convert.ToString(c.SubjectDescription), 
                                             Convert.ToString(c.FromMailID), 
                                             Convert.ToString(c.EmployeeFullName),
                                             Convert.ToString(c.FromEmployeeFullName)};
                return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var result = 0;
                return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

    }
}
