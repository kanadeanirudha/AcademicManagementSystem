using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IOnlineExamExaminationQuePaperDetailsServiceAccess
    {

        IBaseEntityCollectionResponse<OnlineExamExaminationQuePaperDetails> GetOnlineExamExaminationQuePaperDetails(OnlineExamExaminationQuePaperDetailsSearchRequest searchRequest);

        IBaseEntityCollectionResponse<OnlineExamExaminationQuePaperDetails> GetListQuestionBankMaster(OnlineExamExaminationQuePaperDetailsSearchRequest searchRequest);

        IBaseEntityCollectionResponse<OnlineExamExaminationQuePaperDetails> OnlineExamExaminationQuestionsList(OnlineExamExaminationQuePaperDetailsSearchRequest searchRequest);

        IBaseEntityCollectionResponse<OnlineExamExaminationQuePaperDetails> OnlineExamExaminationViewQuestionsList(OnlineExamExaminationQuePaperDetailsSearchRequest searchRequest);

        IBaseEntityResponse<OnlineExamExaminationQuePaperDetails> AddQuestionToExamPaper(OnlineExamExaminationQuePaperDetails item);

        IBaseEntityResponse<OnlineExamExaminationQuePaperDetails> RemoveQuestionFromExamPaper(OnlineExamExaminationQuePaperDetails item);

        IBaseEntityResponse<OnlineExamExaminationQuePaperDetails> QuestionPaperFinalSubmit(OnlineExamExaminationQuePaperDetails item);
    }
}
