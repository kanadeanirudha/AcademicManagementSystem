using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class EntranceExamScheduleAndScheduleDetailServiceAccess :IEntranceExamScheduleAndScheduleDetailServiceAccess
    {
        IEntranceExamScheduleAndScheduleDetailBA _entranceExamScheduleAndScheduleDetailBA = null;        
        public EntranceExamScheduleAndScheduleDetailServiceAccess()
		{
            _entranceExamScheduleAndScheduleDetailBA = new EntranceExamScheduleAndScheduleDetailBA();
		}

        //EntranceExamSchedule Table Method.
        public IBaseEntityResponse<EntranceExamScheduleAndScheduleDetail> InsertEntranceExamSchedule(EntranceExamScheduleAndScheduleDetail item)
		{
            return _entranceExamScheduleAndScheduleDetailBA.InsertEntranceExamSchedule(item);
		}
        public IBaseEntityResponse<EntranceExamScheduleAndScheduleDetail> UpdateEntranceExamSchedule(EntranceExamScheduleAndScheduleDetail item)
		{
            return _entranceExamScheduleAndScheduleDetailBA.UpdateEntranceExamSchedule(item);
		}
        public IBaseEntityResponse<EntranceExamScheduleAndScheduleDetail> DeleteEntranceExamSchedule(EntranceExamScheduleAndScheduleDetail item)
		{
            return _entranceExamScheduleAndScheduleDetailBA.DeleteEntranceExamSchedule(item);
		}
        public IBaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail> GetEntranceExamScheduleBySearch(EntranceExamScheduleAndScheduleDetailSearchRequest searchRequest)
        {
            return _entranceExamScheduleAndScheduleDetailBA.GetEntranceExamScheduleBySearch(searchRequest);
        }
        public IBaseEntityResponse<EntranceExamScheduleAndScheduleDetail> SelectEntranceExamScheduleByID(EntranceExamScheduleAndScheduleDetail item)
		{
            return _entranceExamScheduleAndScheduleDetailBA.SelectEntranceExamScheduleByID(item);
		}

        //Search List
        public IBaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail> GetEntranceExamScheduleSearchList(EntranceExamScheduleAndScheduleDetailSearchRequest searchRequest)
        {
            return _entranceExamScheduleAndScheduleDetailBA.GetEntranceExamScheduleSearchList(searchRequest);
        }


        //EntranceExamScheduleDetail Table Method.
        public IBaseEntityResponse<EntranceExamScheduleAndScheduleDetail> InsertEntranceExamScheduleDetail(EntranceExamScheduleAndScheduleDetail item)
        {
            return _entranceExamScheduleAndScheduleDetailBA.InsertEntranceExamScheduleDetail(item);
        }
        public IBaseEntityResponse<EntranceExamScheduleAndScheduleDetail> UpdateEntranceExamScheduleDetail(EntranceExamScheduleAndScheduleDetail item)
        {
            return _entranceExamScheduleAndScheduleDetailBA.UpdateEntranceExamScheduleDetail(item);
        }
        public IBaseEntityResponse<EntranceExamScheduleAndScheduleDetail> DeleteEntranceExamScheduleDetail(EntranceExamScheduleAndScheduleDetail item)
        {
            return _entranceExamScheduleAndScheduleDetailBA.DeleteEntranceExamScheduleDetail(item);
        }
        public IBaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail> GetEntranceExamScheduleDetailBySearch(EntranceExamScheduleAndScheduleDetailSearchRequest searchRequest)
        {
            return _entranceExamScheduleAndScheduleDetailBA.GetEntranceExamScheduleDetailBySearch(searchRequest);
        }
        public IBaseEntityResponse<EntranceExamScheduleAndScheduleDetail> SelectEntranceExamScheduleDetailByID(EntranceExamScheduleAndScheduleDetail item)
        {
            return _entranceExamScheduleAndScheduleDetailBA.SelectEntranceExamScheduleDetailByID(item);
        }

        //Search List
        public IBaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail> GetEntranceExamScheduleDetailSearchList(EntranceExamScheduleAndScheduleDetailSearchRequest searchRequest)
        {
            return _entranceExamScheduleAndScheduleDetailBA.GetEntranceExamScheduleDetailSearchList(searchRequest);
        }

        public IBaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail> GetOnlineExamQuestionPaperSet(EntranceExamScheduleAndScheduleDetailSearchRequest searchRequest)
        {
            return _entranceExamScheduleAndScheduleDetailBA.GetOnlineExamQuestionPaperSet(searchRequest);
        }  

        public IBaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail> GetAllotedStuentForScheduleAvailCentreList(EntranceExamScheduleAndScheduleDetailSearchRequest searchRequest)
        {
            return _entranceExamScheduleAndScheduleDetailBA.GetAllotedStuentForScheduleAvailCentreList(searchRequest);
        }

        //Get Alloted Student for Centre
        public IBaseEntityCollectionResponse<EntranceExamScheduleAndScheduleDetail> GetAllotedStudentListForCentre(EntranceExamScheduleAndScheduleDetailSearchRequest searchRequest)
        {
            return _entranceExamScheduleAndScheduleDetailBA.GetAllotedStudentListForCentre(searchRequest);
        }
    }
}
