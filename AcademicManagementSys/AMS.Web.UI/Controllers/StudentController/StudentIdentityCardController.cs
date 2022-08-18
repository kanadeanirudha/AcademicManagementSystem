﻿using AMS.Base.DTO;
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
    public class StudentIdentityCardController : BaseController
    {

        IStudentIdentityCardServiceAccess _StudentIdentityCardServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public StudentIdentityCardController()
        {
            _StudentIdentityCardServiceAcess = new StudentIdentityCardServiceAccess();
        }

        /// <summary>
        /// First Load When controller call List Method
        /// </summary>
        /// <returns>view</returns>
        [HttpGet]
        public ActionResult Index()
        {
            //StudentIdentityCardViewModel model = new StudentIdentityCardViewModel();
            return View("/Views/Student/StudentIdentityCard/Index.cshtml");
        }

        public ActionResult List(string centreCode, string sectionDetailsID, string AcademicYear, string UniversityID, string BranchID, string actionMode)
        {
            try
            {
                StudentIdentityCardViewModel model = new StudentIdentityCardViewModel();
                string[] vCentreCode = null;
                string vCentreCode1 = null;
                string vCentreCode2 = null;
                if (centreCode != null)
                {
                    vCentreCode = centreCode.Split(':');
                    vCentreCode1 = vCentreCode[0];
                    vCentreCode2 = vCentreCode[1];
                }
                else
                {
                    vCentreCode1 = "0";
                }
                model.CentreCode = vCentreCode1;
                model.SectionDetailID = Convert.ToInt32(sectionDetailsID);
                model.AcademicYear = AcademicYear;

                model.SelectedCentreCode = centreCode;
                model.SelectedSectionDetailID = sectionDetailsID;
                model.SelectedAcademicYear = AcademicYear;
                model.SelectedUniversityID = UniversityID;
                model.SelectedBranchID = BranchID;
                // model.SelectedAcademicYear = AcademicYear;

                model.ListOrganisationStudyCentreMaster = GetCentreListRoleWise(Convert.ToInt32(Session["RoleID"]));

                foreach (var b in model.ListOrganisationStudyCentreMaster)
                {
                    b.CentreCode = b.CentreCode + ":" + b.ScopeIdentity;
                }

                model.ListOrganisationCentrewiseSessionDetails = GetCurrentSession(vCentreCode1);

                foreach (var b in model.ListOrganisationCentrewiseSessionDetails)
                {
                    b.SessionID = b.SessionID;
                }



                model.ListOrganisationUniversityMaster = GetListOrganisationUniversityMaster(vCentreCode1);

                foreach (var b in model.ListOrganisationUniversityMaster)
                {
                    b.universityID = b.ID + ":" + b.universityName;
                }

                model.ListOrganisationBranchMaster = GetBranchListRoleWise(vCentreCode1, vCentreCode2, Convert.ToInt32(Session["RoleID"]), Convert.ToInt32(UniversityID), "false");

                foreach (var b in model.ListOrganisationBranchMaster)
                {
                    b.ID = b.ID;
                }
                model.ListOrganisationSectionDetails = GetSectionDetailsRoleWise(Convert.ToInt32(BranchID), vCentreCode1, UniversityID, "false");

                foreach (var b in model.ListOrganisationSectionDetails)
                {
                    b.ID = b.ID;
                }


                //For Blood Group
                List<SelectListItem> BloodGroup = new List<SelectListItem>();
                ViewBag.BloodGroup = new SelectList(BloodGroup, "Value", "Text");
                List<SelectListItem> li_BloodGroup = new List<SelectListItem>();
                li_BloodGroup.Add(new SelectListItem { Text = "-- Select Blood Group -- ", Value = "" });
                li_BloodGroup.Add(new SelectListItem { Text = "O-", Value = "O-" });
                li_BloodGroup.Add(new SelectListItem { Text = "O+", Value = "O+" });
                li_BloodGroup.Add(new SelectListItem { Text = "A-", Value = "A-" });
                li_BloodGroup.Add(new SelectListItem { Text = "A+", Value = "A+" });
                li_BloodGroup.Add(new SelectListItem { Text = "B-", Value = "B-" });
                li_BloodGroup.Add(new SelectListItem { Text = "B+", Value = "B+" });
                li_BloodGroup.Add(new SelectListItem { Text = "AB-", Value = "AB-" });
                li_BloodGroup.Add(new SelectListItem { Text = "AB+", Value = "AB+" });
                ViewData["Bloodgroup"] = new SelectList(li_BloodGroup, "Value", "Text", model.StudentIdentityCardDTO.Bloodgroup);


                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Student/StudentIdentityCard/List.cshtml", model);


            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }



        public ActionResult StudentInfo(string Id)
        {
            StudentIdentityCardViewModel model = new StudentIdentityCardViewModel();
            try
            {
                model.StudentIdentityCardDTO = new StudentIdentityCard();
                model.StudentIdentityCardDTO.StudentId = Convert.ToInt32(Id);
                model.StudentIdentityCardDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<StudentIdentityCard> response = _StudentIdentityCardServiceAcess.SelectByID(model.StudentIdentityCardDTO);
                if (response != null && response.Entity != null)
                {
                    model.StudentIdentityCardDTO.StudentCode = response.Entity.StudentCode;
                    model.StudentIdentityCardDTO.StudentId = response.Entity.StudentId;
                    model.StudentIdentityCardDTO.StudentFullName = response.Entity.StudentFullName;
                    
                    model.StudentIdentityCardDTO.StudentMobileNumber = response.Entity.StudentMobileNumber;
                    model.StudentIdentityCardDTO.ParentMobileNumber = response.Entity.ParentMobileNumber;
                    model.StudentIdentityCardDTO.StudentIdentificationMark = response.Entity.StudentIdentificationMark;
                    model.StudentIdentityCardDTO.PermanentAddressLine1 = response.Entity.PermanentAddressLine1;
                    model.StudentIdentityCardDTO.PermanentAddressLine2 = response.Entity.PermanentAddressLine2;
                    //model.StudentIdentityCardDTO.CorrespondenceAddressLine1 = response.Entity.CorrespondenceAddressLine1;
                    //model.StudentIdentityCardDTO.CorrespondenceAddressLine2 = response.Entity.CorrespondenceAddressLine2;
                    model.StudentIdentityCardDTO.DateOfBirth = response.Entity.DateOfBirth;
                    model.StudentIdentityCardDTO.Bloodgroup = response.Entity.Bloodgroup;
                    model.StudentIdentityCardDTO.StudentPhoto = response.Entity.StudentPhoto;
                    model.StudentIdentityCardDTO.StudentSignature = response.Entity.StudentSignature;
                    model.StudentIdentityCardDTO.StudentPhotoType = response.Entity.StudentPhotoType;
                    model.StudentIdentityCardDTO.StudentPhotoFilename = response.Entity.StudentPhotoFilename;
                    model.StudentIdentityCardDTO.StudentPhotoFileWidth = response.Entity.StudentPhotoFileWidth;
                    model.StudentIdentityCardDTO.StudentPhotoFileHeight = response.Entity.StudentPhotoFileHeight;
                    model.StudentIdentityCardDTO.StudentPhotoFileSize = response.Entity.StudentPhotoFileSize;
                    model.StudentIdentityCardDTO.StudentSignatureType = response.Entity.StudentSignatureType;
                    model.StudentIdentityCardDTO.StudentSignatureFilename = response.Entity.StudentSignatureFilename;
                    model.StudentIdentityCardDTO.StudentSignatureFileWidth = response.Entity.StudentSignatureFileWidth;
                    model.StudentIdentityCardDTO.StudentSignatureFileHeight = response.Entity.StudentSignatureFileHeight;
                    model.StudentIdentityCardDTO.StudentSignatureFileSize = response.Entity.StudentSignatureFileSize;


                }
                //For Blood Group
                List<SelectListItem> BloodGroup = new List<SelectListItem>();
                ViewBag.BloodGroup = new SelectList(BloodGroup, "Value", "Text");
                List<SelectListItem> li_BloodGroup = new List<SelectListItem>();
                li_BloodGroup.Add(new SelectListItem { Text = "-- Select Blood Group -- ", Value = "" });
                li_BloodGroup.Add(new SelectListItem { Text = "O-", Value = "O-" });
                li_BloodGroup.Add(new SelectListItem { Text = "O+", Value = "O+" });
                li_BloodGroup.Add(new SelectListItem { Text = "A-", Value = "A-" });
                li_BloodGroup.Add(new SelectListItem { Text = "A+", Value = "A+" });
                li_BloodGroup.Add(new SelectListItem { Text = "B-", Value = "B-" });
                li_BloodGroup.Add(new SelectListItem { Text = "B+", Value = "B+" });
                li_BloodGroup.Add(new SelectListItem { Text = "AB-", Value = "AB-" });
                li_BloodGroup.Add(new SelectListItem { Text = "AB+", Value = "AB+" });
                ViewData["Bloodgroup"] = new SelectList(li_BloodGroup, "Value", "Text", model.StudentIdentityCardDTO.Bloodgroup);


                return PartialView("/Views/Student/StudentIdentityCard/StudentInfo.cshtml", model);



            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult StudentInfoSave(StudentIdentityCardViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                if (model != null && model.StudentIdentityCardDTO != null)
                {
                    model.StudentIdentityCardDTO.ConnectionString = _connectioString;

                    model.StudentIdentityCardDTO.StudentId = model.StudentId;
                    //for Photo
                    model.StudentIdentityCardDTO.StudentPhoto = model.StudentPhoto;
                    model.StudentIdentityCardDTO.StudentPhotoFilename = model.StudentPhotoFilename;
                    model.StudentIdentityCardDTO.StudentPhotoType = model.StudentPhotoType;
                    model.StudentIdentityCardDTO.StudentPhotoFileSize = model.StudentPhotoFileSize;
                    model.StudentIdentityCardDTO.StudentPhotoFileWidth = model.StudentPhotoFileWidth;
                    model.StudentIdentityCardDTO.StudentPhotoFileHeight = model.StudentPhotoFileHeight;

                    //for Signature
                    model.StudentIdentityCardDTO.StudentSignature = model.StudentSignature;
                    model.StudentIdentityCardDTO.StudentSignatureFilename = model.StudentSignatureFilename;
                    model.StudentIdentityCardDTO.StudentSignatureType = model.StudentSignatureType;
                    model.StudentIdentityCardDTO.StudentSignatureFileSize = model.StudentSignatureFileSize;
                    model.StudentIdentityCardDTO.StudentSignatureFileWidth = model.StudentSignatureFileWidth;
                    model.StudentIdentityCardDTO.StudentSignatureFileHeight = model.StudentSignatureFileHeight;


                    model.StudentIdentityCardDTO.PermanentAddressLine1 = model.PermanentAddressLine1;
                    model.StudentIdentityCardDTO.PermanentAddressLine2 = model.PermanentAddressLine2;
                    //model.StudentIdentityCardDTO.CorrespondenceAddressLine1 = model.CorrespondenceAddressLine1;
                    //model.StudentIdentityCardDTO.CorrespondenceAddressLine2 = model.CorrespondenceAddressLine2;
                    model.StudentIdentityCardDTO.Bloodgroup = model.Bloodgroup;
                    model.StudentIdentityCardDTO.StudentMobileNumber = model.StudentMobileNumber;
                    model.StudentIdentityCardDTO.ParentMobileNumber = model.ParentMobileNumber;
                    model.StudentIdentityCardDTO.StudentCode = model.StudentCode;
                    model.StudentIdentityCardDTO.StudentIdentificationMark = model.StudentIdentificationMark;

                    model.StudentIdentityCardDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<StudentIdentityCard> response = _StudentIdentityCardServiceAcess.UpdateStudentIdentityCard(model.StudentIdentityCardDTO);
                    model.StudentIdentityCardDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    return Json(model.StudentIdentityCardDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }

                else
                {
                    return Json("Please review your form");
                }
                //}


            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }


        #region Methods
        // Non-Action Method 

        public IEnumerable<StudentIdentityCardViewModel> GetStudentList(string centreCode, string sectionDetailsID, string AcademicYear, out int TotalRecords)
        {
            StudentIdentityCardSearchRequest searchRequest = new StudentIdentityCardSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CentreCode = centreCode;
            if (sectionDetailsID != "")
            {
                searchRequest.SectionDetailID = Convert.ToInt32(sectionDetailsID);
            }
            searchRequest.AcademicYear = AcademicYear;

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

                searchRequest.SortDirection = "Desc";
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
            }
            List<StudentIdentityCardViewModel> listStudentIdentityCardViewModel = new List<StudentIdentityCardViewModel>();
            List<StudentIdentityCard> listStudentIdentityCard = new List<StudentIdentityCard>();
            IBaseEntityCollectionResponse<StudentIdentityCard> baseEntityCollectionResponse = _StudentIdentityCardServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listStudentIdentityCard = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (StudentIdentityCard item in listStudentIdentityCard)
                    {
                        StudentIdentityCardViewModel StudentIdentityCardViewModel = new StudentIdentityCardViewModel();
                        StudentIdentityCardViewModel.StudentIdentityCardDTO = item;
                        listStudentIdentityCardViewModel.Add(StudentIdentityCardViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listStudentIdentityCardViewModel;
        }
        #endregion


        #region ------------CONTROLLER AJAX HANDLER METHODS------------

        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string centreCode, string sectionDetailsID, string AcademicYear)
        //    public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            //string centreCode = null; string sectionDetailsID = null; string AcademicYear = null;
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);

                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
                if (sortDirection == null)
                {
                    sortDirection = "asc";
                }
                string[] vCentreCode = null;
                string vCentreCode1 = null;
                if (centreCode != null)
                {
                    vCentreCode = centreCode.Split(':');
                    vCentreCode1 = vCentreCode[0];
                }
                IEnumerable<StudentIdentityCardViewModel> filteredStudentIdentityCard;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.Title,A.FirstName,A.MiddleName,A.LastName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.FirstName Like '%" + param.sSearch + "%' or A.MiddleName Like '%" + param.sSearch + "%' or A.LastName Like '%" + param.sSearch + "%' or b.YearlyRollNumber Like '%" + param.sSearch + "%' or A.StudentCode Like '%" + param.sSearch + "%'";    //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "A.StudentCode";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.FirstName Like '%" + param.sSearch + "%' or A.MiddleName Like '%" + param.sSearch + "%' or A.LastName Like '%" + param.sSearch + "%' or b.YearlyRollNumber Like '%" + param.sSearch + "%' or A.StudentCode Like '%" + param.sSearch + "%'";    //this "if" block is added for search functionality
                        }
                        break;
                    case 2:
                        _sortBy = "b.YearlyRollNumber";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.FirstName Like '%" + param.sSearch + "%' or A.MiddleName Like '%" + param.sSearch + "%' or A.LastName Like '%" + param.sSearch + "%' or b.YearlyRollNumber Like '%" + param.sSearch + "%' or A.StudentCode Like '%" + param.sSearch + "%'";    //this "if" block is added for search functionality
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;

                if (_rowLength == 0)
                {
                    _rowLength = 10;
                }

                filteredStudentIdentityCard = GetStudentList(vCentreCode1, sectionDetailsID, AcademicYear, out TotalRecords);
                var records = filteredStudentIdentityCard.Skip(0).Take(param.iDisplayLength);
                //   var result = from c in filteredStudentIdentityCard select new[] { c.StudentTitle.ToString() + " " + c.StudentFirstName.ToString() + " " + c.StudentMiddleName.ToString() + " " + c.StudentLastName.ToString(), c.StudentCode.ToString(), c.RollNumber.ToString(), Convert.ToString(c.StudentId) };
                var result = from c in records select new[] { Convert.ToString(c.StudentFullName), Convert.ToString(c.StudentCode), Convert.ToString(c.RollNumber), Convert.ToString(c.StudentId) };
                return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
            }
            else
            {

                var result = 0;
                return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);

            }
        }

        [HttpGet]
        public ActionResult GetBranchDetails(string CentreCode, string UniversityID)
        {
            string[] vcentreCode = CentreCode.Split(':');
            var OrganisationBranchDetails = GetBranchListRoleWise(vcentreCode[0], vcentreCode[1], Convert.ToInt32(Session["RoleID"]), Convert.ToInt32(UniversityID), "false");
            var result = (from s in OrganisationBranchDetails
                          select new
                          {
                              id = s.ID,
                              name = s.BranchDescription,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetSessionDetails(string CentreCode)
        {
            string[] vcentreCode = CentreCode.Split(':');
            var OrganisationSessionDetails = GetCentreWiseSessionListRoleWise(vcentreCode[0], 0);
            var result = (from s in OrganisationSessionDetails
                          select new
                          {
                              id = s.SessionName,
                              name = s.SessionName,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAllSessionDetails(string CentreCode)
        {
            string[] vcentreCode = CentreCode.Split(':');
            var OrganisationSessionDetails = GetCentreWiseSessionListRoleWise(vcentreCode[0], 1);
            var result = (from s in OrganisationSessionDetails
                          select new
                          {
                              id = s.SessionName,
                              name = s.SessionName,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetCurrentSessionDetails(string CentreCode)
        {
            string[] vcentreCode = CentreCode.Split(':');
            var OrganisationCurrentSessionDetails = GetCurrentSession(vcentreCode[0]);
            var result = (from s in OrganisationCurrentSessionDetails
                          select new
                          {
                              id = s.SessionID,
                              name = s.SessionName,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetSectionDetails(string SelectedBranchID, string CentreCode, string UniversityID)
        {
            string[] vcentreCode = CentreCode.Split(':');
            int id = 0;
            bool isValid = Int32.TryParse(SelectedBranchID, out id);
            var OrganisationSectionDetails = GetSectionDetailsRoleWise(Convert.ToInt32(SelectedBranchID), vcentreCode[0], UniversityID, "false");
            var result = (from s in OrganisationSectionDetails
                          select new
                          {
                              id = s.ID,
                              name = s.Descriptions,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetUniversityByCentreCode(string CentreCode)
        {
            string[] vcentreCode = CentreCode.Split(':');
            //int id = 0;
            //bool isValid = Int32.TryParse(SelectedCentreCode, out id);
            var university = GetListOrganisationUniversityMaster(vcentreCode[0]);
            var result = (from s in university
                          select new
                          {
                              id = s.ID,
                              name = s.UniversityName,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

    }
}