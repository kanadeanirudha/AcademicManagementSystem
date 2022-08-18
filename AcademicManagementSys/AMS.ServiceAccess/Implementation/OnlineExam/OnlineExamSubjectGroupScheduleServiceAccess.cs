
using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class OnlineExamSubjectGroupScheduleServiceAccess : IOnlineExamSubjectGroupScheduleServiceAccess
    {
        IOnlineExamSubjectGroupScheduleBA _OnlineExamSubjectGroupScheduleBA = null;
        public OnlineExamSubjectGroupScheduleServiceAccess()
        {
            _OnlineExamSubjectGroupScheduleBA = new OnlineExamSubjectGroupScheduleBA();
        }
        public IBaseEntityResponse<OnlineExamSubjectGroupSchedule> InsertOnlineExamSubjectGroupSchedule(OnlineExamSubjectGroupSchedule item)
        {
            return _OnlineExamSubjectGroupScheduleBA.InsertOnlineExamSubjectGroupSchedule(item);
        }
        public IBaseEntityResponse<OnlineExamSubjectGroupSchedule> UpdateOnlineExamSubjectGroupSchedule(OnlineExamSubjectGroupSchedule item)
        {
            return _OnlineExamSubjectGroupScheduleBA.UpdateOnlineExamSubjectGroupSchedule(item);
        }
        public IBaseEntityResponse<OnlineExamSubjectGroupSchedule> DeleteOnlineExamSubjectGroupSchedule(OnlineExamSubjectGroupSchedule item)
        {
            return _OnlineExamSubjectGroupScheduleBA.DeleteOnlineExamSubjectGroupSchedule(item);
        }
        public IBaseEntityCollectionResponse<OnlineExamSubjectGroupSchedule> GetBySearch(OnlineExamSubjectGroupScheduleSearchRequest searchRequest)
        {
            return _OnlineExamSubjectGroupScheduleBA.GetBySearch(searchRequest);
        }
        //public IBaseEntityResponse<OnlineExamSubjectGroupSchedule> GetSectionDetails(OnlineExamSubjectGroupSchedule item)
        //{
        //    return _OnlineExamSubjectGroupScheduleBA.GetSectionDetails(item);
        //}
        public IBaseEntityCollectionResponse<OnlineExamSubjectGroupSchedule> GetOnlineExamSubjectGroupScheduleSearchList(OnlineExamSubjectGroupScheduleSearchRequest searchRequest)
        {
            return _OnlineExamSubjectGroupScheduleBA.GetOnlineExamSubjectGroupScheduleSearchList(searchRequest);
        }
        public IBaseEntityResponse<OnlineExamSubjectGroupSchedule> SelectByID(OnlineExamSubjectGroupSchedule item)
        {
            return _OnlineExamSubjectGroupScheduleBA.SelectByID(item);
        }

    }
}
