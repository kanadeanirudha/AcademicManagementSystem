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
    public class HMAppointmentTransactionController : BaseController
    {
        IHMAppointmentTransactionServiceAccess _HMAppointmentTransactionServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public HMAppointmentTransactionController()
        {
            _HMAppointmentTransactionServiceAcess = new HMAppointmentTransactionServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {

            return View("/Views/HealthCare/HMAppointmentTransaction/Index.cshtml");

        }

        public ActionResult List(string actionMode)
        {
            try
            {
                HMAppointmentTransactionViewModel model = new HMAppointmentTransactionViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/HealthCare/HMAppointmentTransaction/ListOfAppoinmentCreate.cshtml", model);
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
            HMAppointmentTransactionViewModel model = new HMAppointmentTransactionViewModel();


            return PartialView("/Views/HealthCare/HMAppointmentTransaction/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(HMAppointmentTransactionViewModel model)
        {
            try
            {
                if (model != null && model.HMAppointmentTransactionDTO != null)
                {
                    model.HMAppointmentTransactionDTO.ConnectionString = _connectioString;
                    // model.HMAppointmentTransactionDTO.PatientCode = model.PatientCode;
                    //model.HMAppointmentTransactionDTO.FirstName = model.FirstName;
                    //model.HMAppointmentTransactionDTO.MiddleName = model.MiddleName;
                    //model.HMAppointmentTransactionDTO.LastName = model.LastName;
                    //model.HMAppointmentTransactionDTO.Age = model.Age;
                    //model.HMAppointmentTransactionDTO.Gender = model.Gender;
                    //model.HMAppointmentTransactionDTO.DOB = model.DOB;
                    //model.HMAppointmentTransactionDTO.Address = model.Address;
                    //model.HMAppointmentTransactionDTO.City = model.City;
                    //model.HMAppointmentTransactionDTO.PinCode = model.PinCode;
                    //model.HMAppointmentTransactionDTO.Note = model.Note;
                    //model.HMAppointmentTransactionDTO.IdentityNumber = model.IdentityNumber;
                    //model.HMAppointmentTransactionDTO.FamilyMobileNumber = model.FamilyMobileNumber;
                    //model.HMAppointmentTransactionDTO.NextAppointmentDate = model.NextAppointmentDate;
                    //model.HMAppointmentTransactionDTO.LastAppointmentTransactionID = model.LastAppointmentTransactionID;



                    model.HMAppointmentTransactionDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<HMAppointmentTransaction> response = _HMAppointmentTransactionServiceAcess.InsertHMAppointmentTransaction(model.HMAppointmentTransactionDTO);

                    model.HMAppointmentTransactionDTO.ErrorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);


                    return Json(model.HMAppointmentTransactionDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult ViewDetails(string patientcode, int Id)
        {
            HMAppointmentTransactionViewModel model = new HMAppointmentTransactionViewModel();
            try
            {
                model.HMAppointmentTransactionDTO = new HMAppointmentTransaction();
                model.HMAppointmentTransactionDTO.ID = Id;
               // model.HMAppointmentTransactionDTO.PatientCode = patientcode;

                model.HMAppointmentTransactionDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<HMAppointmentTransaction> response = _HMAppointmentTransactionServiceAcess.SelectByID(model.HMAppointmentTransactionDTO);
                if (response != null && response.Entity != null)
                {

                    //model.HMAppointmentTransactionDTO.PatientCode = response.Entity.PatientCode;
                    //model.HMAppointmentTransactionDTO.FirstName = response.Entity.FirstName;
                    //model.HMAppointmentTransactionDTO.MiddleName = response.Entity.MiddleName;
                    //model.HMAppointmentTransactionDTO.LastName = response.Entity.LastName;
                    //model.HMAppointmentTransactionDTO.Age = response.Entity.Age;
                    //model.HMAppointmentTransactionDTO.Gender = response.Entity.Gender;
                    //model.HMAppointmentTransactionDTO.DOB = response.Entity.DOB;
                    //model.HMAppointmentTransactionDTO.Address = response.Entity.Address;
                    //model.HMAppointmentTransactionDTO.City = response.Entity.City;
                    //model.HMAppointmentTransactionDTO.PinCode = response.Entity.PinCode;
                    //model.HMAppointmentTransactionDTO.Note = response.Entity.Note;
                    //model.HMAppointmentTransactionDTO.IdentityNumber = response.Entity.IdentityNumber;
                    //model.HMAppointmentTransactionDTO.FamilyMobileNumber = response.Entity.FamilyMobileNumber;
                    //model.HMAppointmentTransactionDTO.IsIPDPatient = response.Entity.IsIPDPatient;

                    model.HMAppointmentTransactionDTO.CreatedBy = response.Entity.CreatedBy;
                }
                return PartialView("/Views/HealthCare/HMAppointmentTransaction/ViewDetails.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //[HttpGet]
        //public ActionResult ViewDetails(string ID)
        //{
        //    try
        //    {
        //        HMAppointmentTransactionViewModel model = new HMAppointmentTransactionViewModel();
        //        model.HMAppointmentTransactionDTO = new HMAppointmentTransaction();
        //        model.HMAppointmentTransactionDTO.ID = Convert.ToInt16(ID);
        //        model.HMAppointmentTransactionDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<HMAppointmentTransaction> response = _HMAppointmentTransactionServiceAcess.SelectByID(model.HMAppointmentTransactionDTO);
        //        if (response != null && response.Entity != null)
        //        {

        //        }

        //        return PartialView("/Views/HealthCare/HMAppointmentTransaction/ViewDetails.cshtml", model);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logException.Error(ex.Message);
        //        throw;
        //    }

        //}

        public ActionResult Delete(Int16 ID)
        {
            var errorMessage = string.Empty;
            if (ID > 0)
            {
                IBaseEntityResponse<HMAppointmentTransaction> response = null;
                HMAppointmentTransaction HMAppointmentTransactionDTO = new HMAppointmentTransaction();
                HMAppointmentTransactionDTO.ConnectionString = _connectioString;
                HMAppointmentTransactionDTO.ID = ID;
                HMAppointmentTransactionDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _HMAppointmentTransactionServiceAcess.DeleteHMAppointmentTransaction(HMAppointmentTransactionDTO);
                errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }

        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<HMAppointmentTransactionViewModel> GetHMAppointmentTransaction(out int TotalRecords)
        {
            HMAppointmentTransactionSearchRequest searchRequest = new HMAppointmentTransactionSearchRequest();
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
            List<HMAppointmentTransactionViewModel> listHMAppointmentTransactionViewModel = new List<HMAppointmentTransactionViewModel>();
            List<HMAppointmentTransaction> listHMAppointmentTransaction = new List<HMAppointmentTransaction>();
            IBaseEntityCollectionResponse<HMAppointmentTransaction> baseEntityCollectionResponse = _HMAppointmentTransactionServiceAcess.GetAppointmentData(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listHMAppointmentTransaction = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (HMAppointmentTransaction item in listHMAppointmentTransaction)
                    {
                        HMAppointmentTransactionViewModel HMAppointmentTransactionViewModel = new HMAppointmentTransactionViewModel();
                        HMAppointmentTransactionViewModel.HMAppointmentTransactionDTO = item;
                        listHMAppointmentTransactionViewModel.Add(HMAppointmentTransactionViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listHMAppointmentTransactionViewModel;
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

                IEnumerable<HMAppointmentTransactionViewModel> filteredUnitType;
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
                            _searchBy = "PatientName Like '%" + param.sSearch + "%'or A.TransactionDate Like '%" + param.sSearch + "%'or C.OPDName Like '%" + param.sSearch + "%' or Status Like'%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "PatientName ";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "PatientName Like '%" + param.sSearch + "%'or A.TransactionDate Like '%" + param.sSearch + "%'or C.OPDName Like '%" + param.sSearch + "%' or Status Like'%" + param.sSearch + "%'";         //this "if" block is added for search functionality
                        }
                        break;
                    case 2:
                        _sortBy = "A.TransactionDate ";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "PatientName Like '%" + param.sSearch + "%'or A.TransactionDate Like '%" + param.sSearch + "%'or C.OPDName Like '%" + param.sSearch + "%' or Status Like'%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;

                    case 3:
                        _sortBy = "C.OPDName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "PatientName Like '%" + param.sSearch + "%'or A.TransactionDate Like '%" + param.sSearch + "%'or C.OPDName Like '%" + param.sSearch + "%' or Status Like'%" + param.sSearch + "%'";       //this "if" block is added for search functionality
                        }
                        break;
                    case 4:
                        _sortBy = "Status";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "PatientName Like '%" + param.sSearch + "%'or A.TransactionDate Like '%" + param.sSearch + "%'or C.OPDName Like '%" + param.sSearch + "%' or Status Like'%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredUnitType = GetHMAppointmentTransaction(out TotalRecords);
                var records = filteredUnitType.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.PatientName), Convert.ToString(c.TransactionDate), Convert.ToString(c.OPDName), Convert.ToString(c.Status), Convert.ToString(c.ID) };

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