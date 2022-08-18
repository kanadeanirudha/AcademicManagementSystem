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
    public class HMPatientMasterController : BaseController
    {
        IHMPatientMasterServiceAccess _HMPatientMasterServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public HMPatientMasterController()
        {
            _HMPatientMasterServiceAcess = new HMPatientMasterServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {

            return View("/Views/HealthCare/HMPatientMaster/Index.cshtml");

        }

        public ActionResult List(string actionMode)
        {
            try
            {
                HMPatientMasterViewModel model = new HMPatientMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/HealthCare/HMPatientMaster/List.cshtml", model);
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
            HMPatientMasterViewModel model = new HMPatientMasterViewModel();
            
           
            return PartialView("/Views/HealthCare/HMPatientMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(HMPatientMasterViewModel model)
        {
            try
            {
                if (model != null && model.HMPatientMasterDTO != null)
                {
                    model.HMPatientMasterDTO.ConnectionString = _connectioString;
                   // model.HMPatientMasterDTO.PatientCode = model.PatientCode;
                    model.HMPatientMasterDTO.FirstName = model.FirstName;
                    model.HMPatientMasterDTO.MiddleName = model.MiddleName;
                    model.HMPatientMasterDTO.LastName = model.LastName;
                    model.HMPatientMasterDTO.Age = model.Age;
                    model.HMPatientMasterDTO.Gender = model.Gender;
                    model.HMPatientMasterDTO.DOB = model.DOB;
                    model.HMPatientMasterDTO.Address = model.Address;
                    model.HMPatientMasterDTO.City = model.City;
                    model.HMPatientMasterDTO.PinCode = model.PinCode;
                    model.HMPatientMasterDTO.Note = model.Note;
                    model.HMPatientMasterDTO.IdentityNumber = model.IdentityNumber;
                    model.HMPatientMasterDTO.FamilyMobileNumber = model.FamilyMobileNumber;
                    model.HMPatientMasterDTO.NextAppointmentDate = model.NextAppointmentDate;
                    model.HMPatientMasterDTO.LastAppointmentTransactionID = model.LastAppointmentTransactionID;
                 


                    model.HMPatientMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<HMPatientMaster> response = _HMPatientMasterServiceAcess.InsertHMPatientMaster(model.HMPatientMasterDTO);

                    model.HMPatientMasterDTO.ErrorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);


                    return Json(model.HMPatientMasterDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
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
        //    HMPatientMasterViewModel model = new HMPatientMasterViewModel();
        //    try
        //    {
        //        model.HMPatientMasterDTO = new HMPatientMaster();
        //        model.HMPatientMasterDTO.ID = id;
        //        model.HMPatientMasterDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<HMPatientMaster> response = _HMPatientMasterServiceAcess.SelectByID(model.HMPatientMasterDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.HMPatientMasterDTO.ID = response.Entity.ID;
        //            model.HMPatientMasterDTO.DeductionHeadName = response.Entity.DeductionHeadName;
        //            model.HMPatientMasterDTO.DeductionType = response.Entity.DeductionType;
                   
        //            model.HMPatientMasterDTO.CreatedBy = response.Entity.CreatedBy;
        //            List<SelectListItem> DeductionType = new List<SelectListItem>();
        //            ViewBag.DeductionType = new SelectList(DeductionType, "Value", "Text");
        //            List<SelectListItem> DeductionType_li = new List<SelectListItem>();
        //            DeductionType_li.Add(new SelectListItem { Text = "PF", Value = "PF" });
        //            DeductionType_li.Add(new SelectListItem { Text = "ESI", Value = "ESI" });
        //            DeductionType_li.Add(new SelectListItem { Text = "PT", Value = "PT" });
        //            DeductionType_li.Add(new SelectListItem { Text = "LIC", Value = "LIC" });
        //            DeductionType_li.Add(new SelectListItem { Text = "LOAN", Value = "LOAN" });
        //            DeductionType_li.Add(new SelectListItem { Text = "TDS", Value = "TDS" });

        //            ViewData["DeductionType"] = new SelectList(DeductionType_li, "Value", "Text");
        //        }
        //        return PartialView("/Views/HealthCare/HMPatientMaster/Edit.cshtml", model);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //[HttpPost]
        //public ActionResult Edit(HMPatientMasterViewModel model)
        //{
        //    try
        //    {
        //        if (model != null && model.HMPatientMasterDTO != null)
        //        {
        //            model.HMPatientMasterDTO.ConnectionString = _connectioString;
        //            model.HMPatientMasterDTO.ID = model.ID;
        //            model.HMPatientMasterDTO.DeductionHeadName = model.DeductionHeadName;
        //            model.HMPatientMasterDTO.DeductionType = model.DeductionType;
                   
        //            model.HMPatientMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
        //            IBaseEntityResponse<HMPatientMaster> response = _HMPatientMasterServiceAcess.UpdateHMPatientMaster(model.HMPatientMasterDTO);
        //            model.HMPatientMasterDTO.ErrorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);

        //            return Json(model.HMPatientMasterDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult ViewDetails(string patientcode ,int Id)
        {
            HMPatientMasterViewModel model = new HMPatientMasterViewModel();
            try
            {
                model.HMPatientMasterDTO = new HMPatientMaster();
                model.HMPatientMasterDTO.ID = Id;
                model.HMPatientMasterDTO.PatientCode = patientcode;
                
                model.HMPatientMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<HMPatientMaster> response = _HMPatientMasterServiceAcess.SelectByID(model.HMPatientMasterDTO);
                if (response != null && response.Entity != null)
                {

                    model.HMPatientMasterDTO.PatientCode = response.Entity.PatientCode;
                    model.HMPatientMasterDTO.FirstName = response.Entity.FirstName;
                    model.HMPatientMasterDTO.MiddleName = response.Entity.MiddleName;
                    model.HMPatientMasterDTO.LastName = response.Entity.LastName;
                    model.HMPatientMasterDTO.Age = response.Entity.Age;
                    model.HMPatientMasterDTO.Gender = response.Entity.Gender;
                    model.HMPatientMasterDTO.DOB = response.Entity.DOB;
                    model.HMPatientMasterDTO.Address = response.Entity.Address;
                    model.HMPatientMasterDTO.City = response.Entity.City;
                    model.HMPatientMasterDTO.PinCode = response.Entity.PinCode;
                    model.HMPatientMasterDTO.Note = response.Entity.Note;
                    model.HMPatientMasterDTO.IdentityNumber = response.Entity.IdentityNumber;
                    model.HMPatientMasterDTO.FamilyMobileNumber = response.Entity.FamilyMobileNumber;
                    model.HMPatientMasterDTO.IsIPDPatient = response.Entity.IsIPDPatient;

                    model.HMPatientMasterDTO.CreatedBy = response.Entity.CreatedBy;
                }
                return PartialView("/Views/HealthCare/HMPatientMaster/ViewDetails.cshtml", model);
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
        //        HMPatientMasterViewModel model = new HMPatientMasterViewModel();
        //        model.HMPatientMasterDTO = new HMPatientMaster();
        //        model.HMPatientMasterDTO.ID = Convert.ToInt16(ID);
        //        model.HMPatientMasterDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<HMPatientMaster> response = _HMPatientMasterServiceAcess.SelectByID(model.HMPatientMasterDTO);
        //        if (response != null && response.Entity != null)
        //        {

        //        }

        //        return PartialView("/Views/HealthCare/HMPatientMaster/ViewDetails.cshtml", model);
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
                IBaseEntityResponse<HMPatientMaster> response = null;
                HMPatientMaster HMPatientMasterDTO = new HMPatientMaster();
                HMPatientMasterDTO.ConnectionString = _connectioString;
                HMPatientMasterDTO.ID = ID;
                HMPatientMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _HMPatientMasterServiceAcess.DeleteHMPatientMaster(HMPatientMasterDTO);
                errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }

        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<HMPatientMasterViewModel> GetHMPatientMaster(out int TotalRecords)
        {
            HMPatientMasterSearchRequest searchRequest = new HMPatientMasterSearchRequest();
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
            List<HMPatientMasterViewModel> listHMPatientMasterViewModel = new List<HMPatientMasterViewModel>();
            List<HMPatientMaster> listHMPatientMaster = new List<HMPatientMaster>();
            IBaseEntityCollectionResponse<HMPatientMaster> baseEntityCollectionResponse = _HMPatientMasterServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listHMPatientMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (HMPatientMaster item in listHMPatientMaster)
                    {
                        HMPatientMasterViewModel HMPatientMasterViewModel = new HMPatientMasterViewModel();
                        HMPatientMasterViewModel.HMPatientMasterDTO = item;
                        listHMPatientMasterViewModel.Add(HMPatientMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listHMPatientMasterViewModel;
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

                IEnumerable<HMPatientMasterViewModel> filteredUnitType;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "PatientName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "FirstName Like '%" + param.sSearch + "%' or MiddleName Like '%" + param.sSearch + "%'or LastName Like '%" + param.sSearch + "%'or Address Like '%" + param.sSearch + "%'or City Like '%" + param.sSearch + "%'or PinCode Like '%" + param.sSearch + "%'or IdentityNumber Like '%" + param.sSearch + "%'or FamilyMobileNumber Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "Gender ";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "FirstName Like '%" + param.sSearch + "%' or MiddleName Like '%" + param.sSearch + "%'or LastName Like '%" + param.sSearch + "%'or Address Like '%" + param.sSearch + "%'or City Like '%" + param.sSearch + "%'or PinCode Like '%" + param.sSearch + "%'or IdentityNumber Like '%" + param.sSearch + "%'or FamilyMobileNumber Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 2:
                        _sortBy = "Address ";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "FirstName Like '%" + param.sSearch + "%' or MiddleName Like '%" + param.sSearch + "%'or LastName Like '%" + param.sSearch + "%'or Address Like '%" + param.sSearch + "%'or City Like '%" + param.sSearch + "%'or PinCode Like '%" + param.sSearch + "%'or IdentityNumber Like '%" + param.sSearch + "%'or FamilyMobileNumber Like '%" + param.sSearch + "%'";
                        }
                        break;

                    case 3:
                        _sortBy = "City";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "FirstName Like '%" + param.sSearch + "%' or MiddleName Like '%" + param.sSearch + "%'or LastName Like '%" + param.sSearch + "%'or Address Like '%" + param.sSearch + "%'or City Like '%" + param.sSearch + "%'or PinCode Like '%" + param.sSearch + "%'or IdentityNumber Like '%" + param.sSearch + "%'or FamilyMobileNumber Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 4:
                        _sortBy = "IdentityNumber";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "FirstName Like '%" + param.sSearch + "%' or MiddleName Like '%" + param.sSearch + "%'or LastName Like '%" + param.sSearch + "%'or Address Like '%" + param.sSearch + "%'or City Like '%" + param.sSearch + "%'or PinCode Like '%" + param.sSearch + "%'or IdentityNumber Like '%" + param.sSearch + "%'or FamilyMobileNumber Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 5:
                        _sortBy = "FamilyMobileNumber ";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "FirstName Like '%" + param.sSearch + "%' or MiddleName Like '%" + param.sSearch + "%'or LastName Like '%" + param.sSearch + "%'or Address Like '%" + param.sSearch + "%'or City Like '%" + param.sSearch + "%'or PinCode Like '%" + param.sSearch + "%'or IdentityNumber Like '%" + param.sSearch + "%'or FamilyMobileNumber Like '%" + param.sSearch + "%'";
                        }
                        break;
                  
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredUnitType = GetHMPatientMaster(out TotalRecords);
                var records = filteredUnitType.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] {Convert.ToString(c.PatientName),Convert.ToString(c.Gender),Convert.ToString(c.Address),Convert.ToString(c.City),Convert.ToString(c.IdentityNumber),Convert.ToString(c.FamilyMobileNumber), Convert.ToString(c.PatientCode), Convert.ToString(c.Age), Convert.ToString(c.DOB),  Convert.ToString(c.PinCode), Convert.ToString(c.Note), Convert.ToString(c.NextAppointmentDate), Convert.ToString(c.LastAppointmentTransactionID),Convert.ToString(c.IsIPDPatient), Convert.ToString(c.ID) };

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