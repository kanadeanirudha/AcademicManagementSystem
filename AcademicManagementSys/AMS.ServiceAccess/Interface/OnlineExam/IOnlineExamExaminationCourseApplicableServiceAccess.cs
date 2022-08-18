using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IOnlineExamExaminationCourseApplicableServiceAccess
    {
        IBaseEntityResponse<OnlineExamExaminationCourseApplicable> InsertOnlineExamExaminationCourseApplicable(OnlineExamExaminationCourseApplicable item);
        IBaseEntityResponse<OnlineExamExaminationCourseApplicable> UpdateOnlineExamExaminationCourseApplicable(OnlineExamExaminationCourseApplicable item);
        IBaseEntityResponse<OnlineExamExaminationCourseApplicable> DeleteOnlineExamExaminationCourseApplicable(OnlineExamExaminationCourseApplicable item);
        IBaseEntityCollectionResponse<OnlineExamExaminationCourseApplicable> GetBySearch(OnlineExamExaminationCourseApplicableSearchRequest searchRequest);
        //IBaseEntityResponse<OnlineExamExaminationCourseApplicable> GetSessionNameList(OnlineExamExaminationCourseApplicable item);
        IBaseEntityCollectionResponse<OnlineExamExaminationCourseApplicable> GetOnlineExamExaminationCourseApplicableSearchList(OnlineExamExaminationCourseApplicableSearchRequest searchRequest);
        IBaseEntityResponse<OnlineExamExaminationCourseApplicable> SelectByID(OnlineExamExaminationCourseApplicable item);
        IBaseEntityResponse<OnlineExamExaminationCourseApplicable> AnnounceResult(OnlineExamExaminationCourseApplicable item);
    }
}
