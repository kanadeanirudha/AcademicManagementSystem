using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class OnlineExamExaminationCourseApplicableServiceAccess : IOnlineExamExaminationCourseApplicableServiceAccess
    {
        IOnlineExamExaminationCourseApplicableBA _OnlineExamExaminationCourseApplicableBA = null;
        public OnlineExamExaminationCourseApplicableServiceAccess()
        {
            _OnlineExamExaminationCourseApplicableBA = new OnlineExamExaminationCourseApplicableBA();
        }
        public IBaseEntityResponse<OnlineExamExaminationCourseApplicable> InsertOnlineExamExaminationCourseApplicable(OnlineExamExaminationCourseApplicable item)
        {
            return _OnlineExamExaminationCourseApplicableBA.InsertOnlineExamExaminationCourseApplicable(item);
        }
        public IBaseEntityResponse<OnlineExamExaminationCourseApplicable> UpdateOnlineExamExaminationCourseApplicable(OnlineExamExaminationCourseApplicable item)
        {
            return _OnlineExamExaminationCourseApplicableBA.UpdateOnlineExamExaminationCourseApplicable(item);
        }
        public IBaseEntityResponse<OnlineExamExaminationCourseApplicable> DeleteOnlineExamExaminationCourseApplicable(OnlineExamExaminationCourseApplicable item)
        {
            return _OnlineExamExaminationCourseApplicableBA.DeleteOnlineExamExaminationCourseApplicable(item);
        }
        public IBaseEntityCollectionResponse<OnlineExamExaminationCourseApplicable> GetBySearch(OnlineExamExaminationCourseApplicableSearchRequest searchRequest)
        {
            return _OnlineExamExaminationCourseApplicableBA.GetBySearch(searchRequest);
        }
        //public IBaseEntityCollectionResponse<OnlineExamExaminationCourseApplicable> GetSessionNameList(OnlineExamExaminationCourseApplicableSearchRequest searchRequest)
        //{
        //    return _OnlineExamExaminationCourseApplicableBA.GetBySearch(searchRequest);
        //}
        public IBaseEntityCollectionResponse<OnlineExamExaminationCourseApplicable> GetOnlineExamExaminationCourseApplicableSearchList(OnlineExamExaminationCourseApplicableSearchRequest searchRequest)
        {
            return _OnlineExamExaminationCourseApplicableBA.GetOnlineExamExaminationCourseApplicableSearchList(searchRequest);
        }
        public IBaseEntityResponse<OnlineExamExaminationCourseApplicable> SelectByID(OnlineExamExaminationCourseApplicable item)
        {
            return _OnlineExamExaminationCourseApplicableBA.SelectByID(item);
        }
        public IBaseEntityResponse<OnlineExamExaminationCourseApplicable> AnnounceResult(OnlineExamExaminationCourseApplicable item)
        {
            return _OnlineExamExaminationCourseApplicableBA.AnnounceResult(item);
        }
    }
}
