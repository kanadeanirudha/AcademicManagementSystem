using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IOnlineExamSubjectGroupScheduleServiceAccess
    {
        IBaseEntityResponse<OnlineExamSubjectGroupSchedule> InsertOnlineExamSubjectGroupSchedule(OnlineExamSubjectGroupSchedule item);
        IBaseEntityResponse<OnlineExamSubjectGroupSchedule> UpdateOnlineExamSubjectGroupSchedule(OnlineExamSubjectGroupSchedule item);
        IBaseEntityResponse<OnlineExamSubjectGroupSchedule> DeleteOnlineExamSubjectGroupSchedule(OnlineExamSubjectGroupSchedule item);
        IBaseEntityCollectionResponse<OnlineExamSubjectGroupSchedule> GetBySearch(OnlineExamSubjectGroupScheduleSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OnlineExamSubjectGroupSchedule> GetOnlineExamSubjectGroupScheduleSearchList(OnlineExamSubjectGroupScheduleSearchRequest searchRequest);
        //IBaseEntityResponse<OnlineExamSubjectGroupSchedule> GetSectionDetails(OnlineExamSubjectGroupSchedule item);
        IBaseEntityResponse<OnlineExamSubjectGroupSchedule> SelectByID(OnlineExamSubjectGroupSchedule item);
    }
}
