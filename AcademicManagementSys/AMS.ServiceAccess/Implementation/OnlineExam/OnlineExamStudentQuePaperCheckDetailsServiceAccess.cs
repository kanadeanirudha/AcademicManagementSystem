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
    public class OnlineExamStudentQuePaperCheckDetailsServiceAccess : IOnlineExamStudentQuePaperCheckDetailsServiceAccess
    {
        IOnlineExamStudentQuePaperCheckDetailsBA _OnlineExamStudentQuePaperCheckDetailsBA = null;
        public OnlineExamStudentQuePaperCheckDetailsServiceAccess()
        {
            _OnlineExamStudentQuePaperCheckDetailsBA = new OnlineExamStudentQuePaperCheckDetailsBA();
        }
        public IBaseEntityCollectionResponse<OnlineExamStudentQuePaperCheckDetails> GetOnlineExamStudentQuePaperCheckDetails(OnlineExamStudentQuePaperCheckDetailsSearchRequest searchRequest)
        {
            return _OnlineExamStudentQuePaperCheckDetailsBA.GetOnlineExamStudentQuePaperCheckDetails(searchRequest);
        }
        public IBaseEntityCollectionResponse<OnlineExamStudentQuePaperCheckDetails> OnlineExamExaminationStudentApplicableList(OnlineExamStudentQuePaperCheckDetailsSearchRequest searchRequest)
        {
            return _OnlineExamStudentQuePaperCheckDetailsBA.OnlineExamExaminationStudentApplicableList(searchRequest);
        }
        public IBaseEntityCollectionResponse<OnlineExamStudentQuePaperCheckDetails> OnlineExamExaminationViewQuestionsList(OnlineExamStudentQuePaperCheckDetailsSearchRequest searchRequest)
        {
            return _OnlineExamStudentQuePaperCheckDetailsBA.OnlineExamExaminationViewQuestionsList(searchRequest);
        }
        public IBaseEntityResponse<OnlineExamStudentQuePaperCheckDetails> MarksObtainInExamination(OnlineExamStudentQuePaperCheckDetails item)
        {
            return _OnlineExamStudentQuePaperCheckDetailsBA.MarksObtainInExamination(item);
        }
        public IBaseEntityResponse<OnlineExamStudentQuePaperCheckDetails> OnlineDescriptiveIsCheckedQuestion(OnlineExamStudentQuePaperCheckDetails item)
        {
            return _OnlineExamStudentQuePaperCheckDetailsBA.OnlineDescriptiveIsCheckedQuestion(item);
        }
        public IBaseEntityResponse<OnlineExamStudentQuePaperCheckDetails> OnlineExamIsAllCheckedQuestion(OnlineExamStudentQuePaperCheckDetails item)
        {
            return _OnlineExamStudentQuePaperCheckDetailsBA.OnlineExamIsAllCheckedQuestion(item);
        }
    }
}
