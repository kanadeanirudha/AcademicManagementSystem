using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataProvider
{
    public interface IEntranceExamScheduleAndScheduleDetailDataProvider
    {
        //EntranceExamSchedule Method
        IBaseEntityResponse<EntranceExamScheduleAndScheduleDetail> InsertEntranceExamSchedule(EntranceExamScheduleAndScheduleDetail item);
        IBaseEntityResponse<EntranceExamScheduleAndScheduleDetail> UpdateEntranceExamSchedule(EntranceExamScheduleAndScheduleDetail item);
        IBaseEntityResponse<EntranceExamScheduleAndScheduleDetail> DeleteEntranceExamSchedule(EntranceExamScheduleAndScheduleDetail item);
        IBaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail> GetEntranceExamScheduleBySearch(EntranceExamScheduleAndScheduleDetailSearchRequest searchRequest);
        IBaseEntityResponse<EntranceExamScheduleAndScheduleDetail> GetEntranceExamScheduleByID(EntranceExamScheduleAndScheduleDetail item);

        //Search EntranceExamSchedule List
        IBaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail> GetEntranceExamScheduleSearchList(EntranceExamScheduleAndScheduleDetailSearchRequest searchRequest);

        //EntranceExamScheduleDetail Method
        IBaseEntityResponse<EntranceExamScheduleAndScheduleDetail> InsertEntranceExamScheduleDetail(EntranceExamScheduleAndScheduleDetail item);
        IBaseEntityResponse<EntranceExamScheduleAndScheduleDetail> UpdateEntranceExamScheduleDetail(EntranceExamScheduleAndScheduleDetail item);
        IBaseEntityResponse<EntranceExamScheduleAndScheduleDetail> DeleteEntranceExamScheduleDetail(EntranceExamScheduleAndScheduleDetail item);
        IBaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail> GetEntranceExamScheduleDetailBySearch(EntranceExamScheduleAndScheduleDetailSearchRequest searchRequest);
        IBaseEntityResponse<EntranceExamScheduleAndScheduleDetail> GetEntranceExamScheduleDetailByID(EntranceExamScheduleAndScheduleDetail item);

        //Search EntranceExamSchedule List   GetAllotedStuentForScheduleAvailCentreList
        IBaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail> GetEntranceExamScheduleDetailSearchList(EntranceExamScheduleAndScheduleDetailSearchRequest searchRequest);
        IBaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail> GetOnlineExamQuestionPaperSet(EntranceExamScheduleAndScheduleDetailSearchRequest searchRequest);
        IBaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail> GetAllotedStuentForScheduleAvailCentreList(EntranceExamScheduleAndScheduleDetailSearchRequest searchRequest);

        //Get Alloted Student fro centre GetAllotedStudentListForCentre
        IBaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail> GetAllotedStudentListForCentre(EntranceExamScheduleAndScheduleDetailSearchRequest searchRequest);
    }
}
