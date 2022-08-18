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
    public class OnlineExamExaminationQuePaperDetailsServiceAccess : IOnlineExamExaminationQuePaperDetailsServiceAccess
    {
        IOnlineExamExaminationQuePaperDetailsBA _OnlineExamExaminationQuePaperDetailsBA = null;
        public OnlineExamExaminationQuePaperDetailsServiceAccess()
        {
            _OnlineExamExaminationQuePaperDetailsBA = new OnlineExamExaminationQuePaperDetailsBA();
        }
        public IBaseEntityCollectionResponse<OnlineExamExaminationQuePaperDetails> GetOnlineExamExaminationQuePaperDetails(OnlineExamExaminationQuePaperDetailsSearchRequest searchRequest)
        {
            return _OnlineExamExaminationQuePaperDetailsBA.GetOnlineExamExaminationQuePaperDetails(searchRequest);
        }
        public IBaseEntityCollectionResponse<OnlineExamExaminationQuePaperDetails> GetListQuestionBankMaster(OnlineExamExaminationQuePaperDetailsSearchRequest searchRequest)
        {
            return _OnlineExamExaminationQuePaperDetailsBA.GetListQuestionBankMaster(searchRequest);
        }
        public IBaseEntityCollectionResponse<OnlineExamExaminationQuePaperDetails> OnlineExamExaminationQuestionsList(OnlineExamExaminationQuePaperDetailsSearchRequest searchRequest)
        {
            return _OnlineExamExaminationQuePaperDetailsBA.OnlineExamExaminationQuestionsList(searchRequest);
        }
        public IBaseEntityCollectionResponse<OnlineExamExaminationQuePaperDetails> OnlineExamExaminationViewQuestionsList(OnlineExamExaminationQuePaperDetailsSearchRequest searchRequest)
        {
            return _OnlineExamExaminationQuePaperDetailsBA.OnlineExamExaminationViewQuestionsList(searchRequest);
        }
        public IBaseEntityResponse<OnlineExamExaminationQuePaperDetails> AddQuestionToExamPaper(OnlineExamExaminationQuePaperDetails item)
        {
            return _OnlineExamExaminationQuePaperDetailsBA.AddQuestionToExamPaper(item);
        }
        public IBaseEntityResponse<OnlineExamExaminationQuePaperDetails> RemoveQuestionFromExamPaper(OnlineExamExaminationQuePaperDetails item)
        {
            return _OnlineExamExaminationQuePaperDetailsBA.RemoveQuestionFromExamPaper(item);
        }
        public IBaseEntityResponse<OnlineExamExaminationQuePaperDetails> QuestionPaperFinalSubmit(OnlineExamExaminationQuePaperDetails item)
        {
            return _OnlineExamExaminationQuePaperDetailsBA.QuestionPaperFinalSubmit(item);
        }
    }
}
