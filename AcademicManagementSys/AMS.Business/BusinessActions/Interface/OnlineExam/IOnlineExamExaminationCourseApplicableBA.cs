using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IOnlineExamExaminationCourseApplicableBA
    {
        IBaseEntityResponse<OnlineExamExaminationCourseApplicable> InsertOnlineExamExaminationCourseApplicable(OnlineExamExaminationCourseApplicable item);
        IBaseEntityResponse<OnlineExamExaminationCourseApplicable> UpdateOnlineExamExaminationCourseApplicable(OnlineExamExaminationCourseApplicable item);
        IBaseEntityResponse<OnlineExamExaminationCourseApplicable> DeleteOnlineExamExaminationCourseApplicable(OnlineExamExaminationCourseApplicable item);
        IBaseEntityCollectionResponse<OnlineExamExaminationCourseApplicable> GetBySearch(OnlineExamExaminationCourseApplicableSearchRequest searchRequest);
        //IBaseEntityCollectionResponse<OnlineExamExaminationCourseApplicable> GetSessionNameList(OnlineExamExaminationCourseApplicable searchRequest);
        IBaseEntityCollectionResponse<OnlineExamExaminationCourseApplicable> GetOnlineExamExaminationCourseApplicableSearchList(OnlineExamExaminationCourseApplicableSearchRequest searchRequest);
        IBaseEntityResponse<OnlineExamExaminationCourseApplicable> SelectByID(OnlineExamExaminationCourseApplicable item);
        IBaseEntityResponse<OnlineExamExaminationCourseApplicable> AnnounceResult(OnlineExamExaminationCourseApplicable item);
    }
}

