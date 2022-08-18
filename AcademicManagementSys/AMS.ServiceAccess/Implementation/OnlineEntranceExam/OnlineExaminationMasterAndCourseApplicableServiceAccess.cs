using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class OnlineExaminationMasterAndCourseApplicableServiceAccess : IOnlineExaminationMasterAndCourseApplicableServiceAccess
    {
        IOnlineExaminationMasterAndCourseApplicableBA onlineExaminationMasterAndCourseApplicableBA = null;
        public OnlineExaminationMasterAndCourseApplicableServiceAccess()
        {
            onlineExaminationMasterAndCourseApplicableBA = new OnlineExaminationMasterAndCourseApplicableBA();
        }

        public IBaseEntityResponse<OnlineExaminationMasterAndCourseApplicable> InsertOnlineExaminationMasterAndCourseApplicable(OnlineExaminationMasterAndCourseApplicable item)
        {
            return onlineExaminationMasterAndCourseApplicableBA.InsertOnlineExaminationMasterAndCourseApplicable(item);
        }

        public IBaseEntityResponse<OnlineExaminationMasterAndCourseApplicable> UpdateOnlineExaminationMasterAndCourseApplicable(OnlineExaminationMasterAndCourseApplicable item)
        {
            return onlineExaminationMasterAndCourseApplicableBA.UpdateOnlineExaminationMasterAndCourseApplicable(item);
        }

        public IBaseEntityResponse<OnlineExaminationMasterAndCourseApplicable> DeleteOnlineExaminationMasterAndCourseApplicable(OnlineExaminationMasterAndCourseApplicable item)
        {
            return onlineExaminationMasterAndCourseApplicableBA.DeleteOnlineExaminationMasterAndCourseApplicable(item);
        }

        public IBaseEntityCollectionResponse<OnlineExaminationMasterAndCourseApplicable> GetOnlineExaminationMasterAndCourseApplicableSelectAll(OnlineExaminationMasterAndCourseApplicableSearchRequest searchRequest)
        {
            return onlineExaminationMasterAndCourseApplicableBA.GetOnlineExaminationMasterAndCourseApplicableSelectAll(searchRequest);
        }

        public IBaseEntityResponse<OnlineExaminationMasterAndCourseApplicable> SelectOnlineExaminationMasterAndCourseApplicableByID(OnlineExaminationMasterAndCourseApplicable item)
        {
            return onlineExaminationMasterAndCourseApplicableBA.SelectOnlineExaminationMasterAndCourseApplicableByID(item);
        }

    }
}
