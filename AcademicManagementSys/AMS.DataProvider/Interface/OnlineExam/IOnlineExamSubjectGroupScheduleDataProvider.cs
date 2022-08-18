using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IOnlineExamSubjectGroupScheduleDataProvider
    {
        IBaseEntityResponse<OnlineExamSubjectGroupSchedule> InsertOnlineExamSubjectGroupSchedule(OnlineExamSubjectGroupSchedule item);
        IBaseEntityResponse<OnlineExamSubjectGroupSchedule> UpdateOnlineExamSubjectGroupSchedule(OnlineExamSubjectGroupSchedule item);
        IBaseEntityResponse<OnlineExamSubjectGroupSchedule> DeleteOnlineExamSubjectGroupSchedule(OnlineExamSubjectGroupSchedule item);
        IBaseEntityCollectionResponse<OnlineExamSubjectGroupSchedule> GetOnlineExamSubjectGroupScheduleBySearch(OnlineExamSubjectGroupScheduleSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OnlineExamSubjectGroupSchedule> GetOnlineExamSubjectGroupScheduleSearchList(OnlineExamSubjectGroupScheduleSearchRequest searchRequest);
        IBaseEntityResponse<OnlineExamSubjectGroupSchedule> GetOnlineExamSubjectGroupScheduleByID(OnlineExamSubjectGroupSchedule item);
        IBaseEntityResponse<OnlineExamSubjectGroupSchedule> GetOnlineExamSubjectGroupScheduleBySectionDetails(OnlineExamSubjectGroupSchedule item);

    }
}

