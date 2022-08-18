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
using AMS.Business.BusinessActions;
namespace AMS.Web.UI.Controllers
{
    public class StudentReportCardController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        IStudentReportCardServiceAccess _StudentReportCardServiceAccess = null;
        private readonly ILogger _logException;
        public static int _StudentID;
        public static int _OnlineExamExaminationCourseApplicableID;

        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public StudentReportCardController()
        {
            _StudentReportCardServiceAccess = new StudentReportCardServiceAccess();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index(int OnlineExamExaminationCourseApplicableID)
        {
            StudentReportCardViewModel model = new StudentReportCardViewModel();
            _OnlineExamExaminationCourseApplicableID = OnlineExamExaminationCourseApplicableID;
            _StudentID = Convert.ToInt32(Session["PersonID"]);

            return View("/Views/OnlineExam/Report/StudentReportCard/Index.cshtml", model);
        }
       
        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------

        public List<StudentReportCard> GetStudentReportCardData()
        {
            try
            {
                List<StudentReportCard> listStudentReportCard = new List<StudentReportCard>();
                StudentReportCardSearchRequest searchRequest = new StudentReportCardSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                searchRequest.OnlineExamExaminationCourseApplicableID = _OnlineExamExaminationCourseApplicableID;
                searchRequest.StudentID = _StudentID;
                IBaseEntityCollectionResponse<StudentReportCard> baseEntityCollectionResponse = _StudentReportCardServiceAccess.GetStudentReportCardData(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listStudentReportCard = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                return listStudentReportCard;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        #endregion

    }
}
