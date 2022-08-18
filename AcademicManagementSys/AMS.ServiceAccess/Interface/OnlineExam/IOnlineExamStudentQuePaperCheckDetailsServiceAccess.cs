using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IOnlineExamStudentQuePaperCheckDetailsServiceAccess
    {

        IBaseEntityCollectionResponse<OnlineExamStudentQuePaperCheckDetails> GetOnlineExamStudentQuePaperCheckDetails(OnlineExamStudentQuePaperCheckDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OnlineExamStudentQuePaperCheckDetails> OnlineExamExaminationStudentApplicableList(OnlineExamStudentQuePaperCheckDetailsSearchRequest searchRequest);

        IBaseEntityCollectionResponse<OnlineExamStudentQuePaperCheckDetails> OnlineExamExaminationViewQuestionsList(OnlineExamStudentQuePaperCheckDetailsSearchRequest searchRequest);
        IBaseEntityResponse<OnlineExamStudentQuePaperCheckDetails> MarksObtainInExamination(OnlineExamStudentQuePaperCheckDetails item);
        IBaseEntityResponse<OnlineExamStudentQuePaperCheckDetails> OnlineDescriptiveIsCheckedQuestion(OnlineExamStudentQuePaperCheckDetails item);
        IBaseEntityResponse<OnlineExamStudentQuePaperCheckDetails> OnlineExamIsAllCheckedQuestion(OnlineExamStudentQuePaperCheckDetails item);
    }
}
