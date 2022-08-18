using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.Business.BusinessActions;
using AMS.Base.DTO;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class OnlineExamServiceAccess : IOnlineExamServiceAccess
    {
        IOnlineExamBA _OnlineExamBA = null;
        public OnlineExamServiceAccess()
        {
            _OnlineExamBA = new OnlineExamBA();
        }
        public IBaseEntityCollectionResponse<OnlineExam> GetOnlineExamsPerStudentBySearch(OnlineExamSearchRequest searchRequest)
        {
            return _OnlineExamBA.GetOnlineExamsPerStudentBySearch(searchRequest);
        }
        public IBaseEntityResponse<OnlineExam> SelectOnlineExamDetails(OnlineExam item)
        {
            return _OnlineExamBA.SelectOnlineExamDetails(item);
        }
        public IBaseEntityResponse<OnlineExam> SelectOnlineExamQuestion(OnlineExam item)
        {
            return _OnlineExamBA.SelectOnlineExamQuestion(item);
        }
        public IBaseEntityResponse<OnlineExam> OnlineExamSaveAnswer(OnlineExam item)
        {
            return _OnlineExamBA.OnlineExamSaveAnswer(item);
        }
        public IBaseEntityResponse<OnlineExam> OnlineExamFinalSubmit(OnlineExam item)
        {
            return _OnlineExamBA.OnlineExamFinalSubmit(item);
        }
    }
}
