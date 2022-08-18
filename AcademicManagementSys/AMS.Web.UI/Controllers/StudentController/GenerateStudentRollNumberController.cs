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
    public class GenerateStudentRollNumberController : BaseController
    {
        IGenerateStudentRollNumberServiceAccess _GenerateStudentRollNumberServiceAcess = null;
        private readonly ILogger _logException;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public GenerateStudentRollNumberController()
        {
            _GenerateStudentRollNumberServiceAcess = new GenerateStudentRollNumberServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            return View("/Views/Student/GenerateStudentRollNumber/Index.cshtml");
        }

        [HttpGet]
        public ActionResult List(string isFirstYearPromotion)
        {
            try
            {
                GenerateStudentRollNumberViewModel model = new GenerateStudentRollNumberViewModel();
                model.ListOrganisationStudyCentreMaster = GetCentreListRoleWise(Convert.ToInt32(Session["RoleID"]));
                foreach (var b in model.ListOrganisationStudyCentreMaster)
                {
                    b.CentreCode = b.CentreCode + ":" + b.ScopeIdentity;
                }
                if (string.IsNullOrEmpty(isFirstYearPromotion) || isFirstYearPromotion=="false")
                {
                     model.IsFirstYearPromotion = false;
                }

                if (!string.IsNullOrEmpty(isFirstYearPromotion) && isFirstYearPromotion == "true")
                {
                    model.IsFirstYearPromotion = true;
                }
                return PartialView("/Views/Student/GenerateStudentRollNumber/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;  
            }
        }
        [HttpPost]
        public ActionResult List(string CentreCode, int SessionID, string PromotedStudentList)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    GenerateStudentRollNumberViewModel model = new GenerateStudentRollNumberViewModel();
                    if (PromotedStudentList != null && CentreCode != null && SessionID != null)
                    {
                       
                        var splitData = CentreCode.Split(':');
                        model.GenerateStudentRollNumberDTO.ConnectionString = _connectioString;
                        model.GenerateStudentRollNumberDTO.CentreCode = splitData[0];
                        model.GenerateStudentRollNumberDTO.PromotedStudentList = PromotedStudentList;
                        model.GenerateStudentRollNumberDTO.SessionID = SessionID;
                        model.GenerateStudentRollNumberDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GenerateStudentRollNumber> response = _GenerateStudentRollNumberServiceAcess.InsertGenerateStudentRollNumber(model.GenerateStudentRollNumberDTO);

                        if (response.Entity != null && !string.IsNullOrEmpty(response.Entity.errorMessage) && response.Entity.ErrorCode == 11)
                        {
                            string[] arrayList = { response.Entity.errorMessage, "#FFCC80", string.Empty };
                            model.GenerateStudentRollNumberDTO.errorMessage = string.Join(",", arrayList);
                        }
                        else if (response.Entity != null && !string.IsNullOrEmpty(response.Entity.errorMessage) && response.Entity.ErrorCode == 0)
                        {
                            string[] arrayList = { response.Entity.errorMessage, "#9FEA7A", string.Empty };
                            model.GenerateStudentRollNumberDTO.errorMessage = string.Join(",", arrayList);
                        }
                        
                    }
                    return Json(model.GenerateStudentRollNumberDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        #endregion
        
        #region Methods
        // Non-Action Method 
        [NonAction]
        public List<GenerateStudentRollNumber> GetStudentListForGenerateStudentRollNumber(string centreCode, int sectionDetailsID, int sessionID, bool isFirstYearPromotion)
        {
            List<GenerateStudentRollNumber> listAccountChequeBookMaster = new List<GenerateStudentRollNumber>();
            GenerateStudentRollNumberSearchRequest searchRequest = new GenerateStudentRollNumberSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SessionID = sessionID;                     
            searchRequest.SectionDetailID = sectionDetailsID;
            var splitData = centreCode.Split(':');
            searchRequest.CentreCode = splitData[0];
            searchRequest.AdmissionStatus = "C"; // or "P"
            searchRequest.StatusCode = "Pursuing";
            searchRequest.IsFirstYearPromotion = isFirstYearPromotion;
            IBaseEntityCollectionResponse<GenerateStudentRollNumber> baseEntityCollectionResponse = _GenerateStudentRollNumberServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAccountChequeBookMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
          
            return listAccountChequeBookMaster;
        }
        [HttpGet]
        public ActionResult GetBranchDetails(string SelectedCentreCode, string selectedUniversityID, string isFirstYearPromotion)
        {
            if (!string.IsNullOrEmpty(SelectedCentreCode) && !string.IsNullOrEmpty(selectedUniversityID))
            {
                string[] vcentreCode = SelectedCentreCode.Split(':');
                var splitData = selectedUniversityID.Split(':');
                var OrganisationBranchDetails = GetBranchListRoleWise(vcentreCode[0], vcentreCode[1], Convert.ToInt32(Session["RoleID"]), Convert.ToInt32(splitData[0]), isFirstYearPromotion);
                var result = (from s in OrganisationBranchDetails
                              select new
                              {
                                  id = s.ID,
                                  name = s.BranchDescription,
                              }).ToList();
                return Json(result, JsonRequestBehavior.AllowGet);                
            }
            else
            {
                return null;
            }

        }
        [HttpGet]
        public ActionResult GetSessionDetails(string SelectedCentreCode)
        {
            string[] vcentreCode = SelectedCentreCode.Split(':');
            var OrganisationSessionDetails = GetCentreWiseSessionListRoleWise(vcentreCode[0],0);
            var result = (from s in OrganisationSessionDetails
                          select new
                          {
                              id = s.SessionID,
                              name = s.SessionName,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetSectionDetails(string SelectedBranchID, string SelectedCentreCode, string UniversityDetails, string isFirstYearPromotion)
        {
            if (!string.IsNullOrEmpty(SelectedBranchID) && !string.IsNullOrEmpty(SelectedCentreCode) && !string.IsNullOrEmpty(UniversityDetails))
            {
                string[] vcentreCode = SelectedCentreCode.Split(':');
                var splitData = UniversityDetails.Split(':');
                var OrganisationSectionDetails = GetSectionDetailsRoleWise(Convert.ToInt32(SelectedBranchID), vcentreCode[0], splitData[0], isFirstYearPromotion);
                var result = (from s in OrganisationSectionDetails
                              select new
                              {
                                  id = s.ID,
                                  name = s.Descriptions,
                              }).ToList();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return null;
            }

        }
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetUniversityByCentreCode(string SelectedCentreCode)
        {
            string[] splited;
            splited = SelectedCentreCode.Split(':');
            if (String.IsNullOrEmpty(SelectedCentreCode))
            {
                throw new ArgumentNullException("SelectedCentreCode");
            }

            var university = GetListOrganisationUniversityMaster(SelectedCentreCode);
            var result = (from s in university
                          select new
                          {
                              id = s.ID + ":" + s.UniversityName,
                              name = s.UniversityName,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion


        #region ------------CONTROLLER AJAX HANDLER METHODS------------

        /// <summary>
        /// AJAX Method for binding List Account category master
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ActionResult AjaxHandlerOtherThanFirstYear(JQueryDataTableParamModel param, string centreCode, string sectionDetailsID, string sessionID, bool isFirstYearPromotion)
        {
           
                int TotalRecords = 0;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<GenerateStudentRollNumber> filteredGenerateStudentRollNumber;

                _sortDirection = sortDirection;
                if (Convert.ToBoolean(isFirstYearPromotion) != true && !string.IsNullOrEmpty(centreCode) && !string.IsNullOrEmpty(sectionDetailsID) && !string.IsNullOrEmpty(sessionID))
                {
                    filteredGenerateStudentRollNumber = GetStudentListForGenerateStudentRollNumber(centreCode, Convert.ToInt32(sectionDetailsID), Convert.ToInt32(sessionID), isFirstYearPromotion);
                }
                else
                {
                    filteredGenerateStudentRollNumber = new List<GenerateStudentRollNumber>();
                }
                var records = filteredGenerateStudentRollNumber.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.StudentName), Convert.ToString(c.NextSectionDescription), Convert.ToString(c.StudentAdmissionDetailId + "~" + c.StudentId + "~" + c.SectionDetailID + "~" + c.NextSectionDetailID) };

                return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);                
           
            

        }

        /// <summary>
        /// AJAX Method for binding List Account category master
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ActionResult AjaxHandlerFirstYearStudent(JQueryDataTableParamModel param, string centreCode, string sectionDetailsID, string sessionID, bool isFirstYearPromotion)
        {

            int TotalRecords = 0;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<GenerateStudentRollNumber> filteredGenerateStudentRollNumber;

            _sortDirection = sortDirection;
            if (Convert.ToBoolean(isFirstYearPromotion) == true && !string.IsNullOrEmpty(centreCode) && !string.IsNullOrEmpty(sectionDetailsID) && !string.IsNullOrEmpty(sessionID))
            {
                filteredGenerateStudentRollNumber = GetStudentListForGenerateStudentRollNumber(centreCode, Convert.ToInt32(sectionDetailsID), Convert.ToInt32(sessionID), isFirstYearPromotion);
            }
            else
            {
                filteredGenerateStudentRollNumber = new List<GenerateStudentRollNumber>();
            }
            var records = filteredGenerateStudentRollNumber.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.StudentName), Convert.ToString(c.NextSectionDescription), Convert.ToString(c.StudentAdmissionDetailId + "~" + c.StudentId + "~" + c.SectionDetailID + "~" + c.NextSectionDetailID) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);



        }
        #endregion

    }
}