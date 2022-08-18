
using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IOnlineExamBA
    {
        IBaseEntityCollectionResponse<OnlineExam> GetOnlineExamsPerStudentBySearch(OnlineExamSearchRequest searchRequest);

        IBaseEntityResponse<OnlineExam> SelectOnlineExamDetails(OnlineExam item);

        IBaseEntityResponse<OnlineExam> SelectOnlineExamQuestion(OnlineExam item);

        IBaseEntityResponse<OnlineExam> OnlineExamSaveAnswer(OnlineExam item);
        IBaseEntityResponse<OnlineExam> OnlineExamFinalSubmit(OnlineExam item);
    }
}

