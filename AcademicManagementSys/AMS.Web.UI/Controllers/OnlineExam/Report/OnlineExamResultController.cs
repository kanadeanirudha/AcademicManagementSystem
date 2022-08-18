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
    public class OnlineExamResultController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        IOnlineExamResultServiceAccess _OnlineExamResultServiceAccess = null;
        private readonly ILogger _logException;
        protected static int _vendorID;
        protected string _centreCode = string.Empty;
        private short _VendorID;
        public static string _Examname;
        public static string _ExamDate;
        public static string _SubjectName;
        protected static string _ReportForPage;
        public static int _onlineExamIndStudentExamInfoID;
      
        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public OnlineExamResultController()
        {
            _OnlineExamResultServiceAccess = new OnlineExamResultServiceAccess();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index(int OnlineExamIndStudentExamInfoID)
        {
            OnlineExamResultViewModel model = new OnlineExamResultViewModel();
            
            _onlineExamIndStudentExamInfoID = 0;
            _onlineExamIndStudentExamInfoID = OnlineExamIndStudentExamInfoID;
            _Examname = model.ExamName;
            _SubjectName = model.SubjectName;
            _ExamDate = model.ExamDate;
          
            return View("/Views/OnlineExam/Report/OnlineExamResult/Index.cshtml", model);
        }
        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------

        public List<OnlineExamResult> GetOnlineExaminationData()
        {
            try
            {
                List<OnlineExamResult> listOnlineExamResult = new List<OnlineExamResult>();
                OnlineExamResultSearchRequest searchRequest = new OnlineExamResultSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                searchRequest.OnlineExamIndStudentExamInfoID = _onlineExamIndStudentExamInfoID;
                IBaseEntityCollectionResponse<OnlineExamResult> baseEntityCollectionResponse = _OnlineExamResultServiceAccess.GetOnlineExamResultBySearch_AllVendorList(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listOnlineExamResult = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                return listOnlineExamResult;
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
