using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IOnlineExamExaminationCourseApplicableDataProvider
    {
        IBaseEntityResponse<OnlineExamExaminationCourseApplicable> InsertOnlineExamExaminationCourseApplicable(OnlineExamExaminationCourseApplicable item);
        IBaseEntityResponse<OnlineExamExaminationCourseApplicable> UpdateOnlineExamExaminationCourseApplicable(OnlineExamExaminationCourseApplicable item);
        IBaseEntityResponse<OnlineExamExaminationCourseApplicable> DeleteOnlineExamExaminationCourseApplicable(OnlineExamExaminationCourseApplicable item);
        IBaseEntityCollectionResponse<OnlineExamExaminationCourseApplicable> GetOnlineExamExaminationCourseApplicableBySearch(OnlineExamExaminationCourseApplicableSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OnlineExamExaminationCourseApplicable> GetOnlineExamExaminationCourseApplicableSearchList(OnlineExamExaminationCourseApplicableSearchRequest searchRequest);
       // IBaseEntityCollectionResponse<OnlineExamExaminationCourseApplicable> GetSessionNameList(OnlineExamExaminationCourseApplicable searchRequest);
        IBaseEntityResponse<OnlineExamExaminationCourseApplicable> GetOnlineExamExaminationCourseApplicableByID(OnlineExamExaminationCourseApplicable item);
        IBaseEntityResponse<OnlineExamExaminationCourseApplicable> AnnounceResult(OnlineExamExaminationCourseApplicable item);
    }
}
