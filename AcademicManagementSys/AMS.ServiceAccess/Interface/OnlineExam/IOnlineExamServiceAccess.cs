using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IOnlineExamServiceAccess
    {
        IBaseEntityCollectionResponse<OnlineExam> GetOnlineExamsPerStudentBySearch(OnlineExamSearchRequest searchRequest);

        IBaseEntityResponse<OnlineExam> SelectOnlineExamDetails(OnlineExam item);

        IBaseEntityResponse<OnlineExam> SelectOnlineExamQuestion(OnlineExam item);

        IBaseEntityResponse<OnlineExam> OnlineExamSaveAnswer(OnlineExam onlineExam);
        IBaseEntityResponse<OnlineExam> OnlineExamFinalSubmit(OnlineExam onlineExam);
        
    }
}
