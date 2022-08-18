using AMS.Base.DTO;
using AMS.DTO;
namespace AMS.Business.BusinessAction
{
    public interface IOnlineExaminationMasterAndCourseApplicableBA
    {
        IBaseEntityResponse<OnlineExaminationMasterAndCourseApplicable> InsertOnlineExaminationMasterAndCourseApplicable(OnlineExaminationMasterAndCourseApplicable item);
        IBaseEntityResponse<OnlineExaminationMasterAndCourseApplicable> UpdateOnlineExaminationMasterAndCourseApplicable(OnlineExaminationMasterAndCourseApplicable item);
        IBaseEntityResponse<OnlineExaminationMasterAndCourseApplicable> DeleteOnlineExaminationMasterAndCourseApplicable(OnlineExaminationMasterAndCourseApplicable item);
        IBaseEntityCollectionResponse<OnlineExaminationMasterAndCourseApplicable> GetOnlineExaminationMasterAndCourseApplicableSelectAll(OnlineExaminationMasterAndCourseApplicableSearchRequest searchRequest);
        IBaseEntityResponse<OnlineExaminationMasterAndCourseApplicable> SelectOnlineExaminationMasterAndCourseApplicableByID(OnlineExaminationMasterAndCourseApplicable item);

    }
}
