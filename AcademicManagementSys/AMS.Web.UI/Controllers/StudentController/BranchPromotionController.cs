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
    public class BranchPromotionController : BaseController
    {
        IBranchPromotionServiceAccess _branchPromotionServiceAcess = null;
        private readonly ILogger _logException;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public BranchPromotionController()
        {
            _branchPromotionServiceAcess = new BranchPromotionServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            return View("/Views/Student/BranchPromotion/Index.cshtml");
        }

        [HttpGet]
        public ActionResult List(string isFirstYearPromotion)
        {
            try
            {
                BranchPromotionViewModel model = new BranchPromotionViewModel();
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
                return PartialView("/Views/Student/BranchPromotion/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;  
            }
        }
        [HttpPost]
        public ActionResult List(string CentreCode, int SessionID, string PromotedStudentList,string AcademicYear,int BranchID)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    BranchPromotionViewModel model = new BranchPromotionViewModel();
                    if (PromotedStudentList != null && CentreCode != null && SessionID != null)
                    {
                       
                        var splitData = CentreCode.Split(':');
                        model.BranchPromotionDTO.ConnectionString = _connectioString;
                        model.BranchPromotionDTO.CentreCode = splitData[0];
                        List<OrganisationCentrewiseSession> list = GetCurrentSession(splitData[0]);
                        model.BranchPromotionDTO.PromotedStudentList = PromotedStudentList;
                        model.BranchPromotionDTO.SessionID = list.Count > 0 ? list[0].SessionID : 0;
                        model.AcademicYear = list.Count > 0 ? list[0].SessionName : "Session not defined"; 
                        model.BranchId = BranchID;                        
                        model.BranchPromotionDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<BranchPromotion> response = _branchPromotionServiceAcess.InsertBranchPromotion(model.BranchPromotionDTO);
                        model.BranchPromotionDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                        
                    }
                    return Json(model.BranchPromotionDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public List<BranchPromotion> GetStudentListForBranchPromotion(string centreCode, int sectionDetailsID, int sessionID, bool isFirstYearPromotion)
        {
            List<BranchPromotion> listAccountChequeBookMaster = new List<BranchPromotion>();
            BranchPromotionSearchRequest searchRequest = new BranchPromotionSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SessionID = sessionID;                     
            searchRequest.SectionDetailID = sectionDetailsID;
            var splitData = centreCode.Split(':');
            searchRequest.CentreCode = splitData[0];
            searchRequest.AdmissionStatus = "C"; // or "P"
            searchRequest.StatusCode = "Pursuing";
            searchRequest.IsFirstYearPromotion = isFirstYearPromotion;
            IBaseEntityCollectionResponse<BranchPromotion> baseEntityCollectionResponse = _branchPromotionServiceAcess.GetBySearch(searchRequest);
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

                IEnumerable<BranchPromotion> filteredBranchPromotion;

                _sortDirection = sortDirection;
                if (Convert.ToBoolean(isFirstYearPromotion) != true && !string.IsNullOrEmpty(centreCode) && !string.IsNullOrEmpty(sectionDetailsID) && !string.IsNullOrEmpty(sessionID))
                {
                    filteredBranchPromotion = GetStudentListForBranchPromotion(centreCode, Convert.ToInt32(sectionDetailsID), Convert.ToInt32(sessionID), isFirstYearPromotion);
                }
                else
                {
                    filteredBranchPromotion = new List<BranchPromotion>();
                }
                var records = filteredBranchPromotion.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.StudentName), Convert.ToString(c.NextSectionDescription), Convert.ToString(c.StudentAdmissionDetailId + "~" + c.StudentId + "~" + c.SectionDetailID + "~" + c.NextSectionDetailID + "~" + c.AcademicYear)};

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

            IEnumerable<BranchPromotion> filteredBranchPromotion;

            _sortDirection = sortDirection;
            if (Convert.ToBoolean(isFirstYearPromotion) == true && !string.IsNullOrEmpty(centreCode) && !string.IsNullOrEmpty(sectionDetailsID) && !string.IsNullOrEmpty(sessionID))
            {
                filteredBranchPromotion = GetStudentListForBranchPromotion(centreCode, Convert.ToInt32(sectionDetailsID), Convert.ToInt32(sessionID), isFirstYearPromotion);
            }
            else
            {
                filteredBranchPromotion = new List<BranchPromotion>();
            }
            var records = filteredBranchPromotion.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.StudentName), Convert.ToString(c.NextSectionDescription), Convert.ToString(c.StudentAdmissionDetailId + "~" + c.StudentId + "~" + c.SectionDetailID + "~" + c.NextSectionDetailID +"~"+c.AcademicYear) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);



        }
        #endregion

    }
}