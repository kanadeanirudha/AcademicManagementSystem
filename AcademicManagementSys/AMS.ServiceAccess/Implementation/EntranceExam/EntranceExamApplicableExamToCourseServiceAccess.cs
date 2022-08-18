using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class EntranceExamApplicableExamToCourseServiceAccess : IEntranceExamApplicableExamToCourseServiceAccess
    {
        IEntranceExamApplicableExamToCourseBA _EntranceExamApplicableExamToCourseBA = null;
        public EntranceExamApplicableExamToCourseServiceAccess()
        {
            _EntranceExamApplicableExamToCourseBA = new EntranceExamApplicableExamToCourseBA();
        }
        public IBaseEntityResponse<EntranceExamApplicableExamToCourse> InsertEntranceExamApplicableExamToCourse(EntranceExamApplicableExamToCourse item)
        {
            return _EntranceExamApplicableExamToCourseBA.InsertEntranceExamApplicableExamToCourse(item);
        }
        public IBaseEntityResponse<EntranceExamApplicableExamToCourse> UpdateEntranceExamApplicableExamToCourse(EntranceExamApplicableExamToCourse item)
        {
            return _EntranceExamApplicableExamToCourseBA.UpdateEntranceExamApplicableExamToCourse(item);
        }
        public IBaseEntityResponse<EntranceExamApplicableExamToCourse> DeleteEntranceExamApplicableExamToCourse(EntranceExamApplicableExamToCourse item)
        {
            return _EntranceExamApplicableExamToCourseBA.DeleteEntranceExamApplicableExamToCourse(item);
        }
        public IBaseEntityCollectionResponse<EntranceExamApplicableExamToCourse> GetBySearch(EntranceExamApplicableExamToCourseSearchRequest searchRequest)
        {
            return _EntranceExamApplicableExamToCourseBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<EntranceExamApplicableExamToCourse> SelectByID(EntranceExamApplicableExamToCourse item)
        {
            return _EntranceExamApplicableExamToCourseBA.SelectByID(item);
        }

        //searchlist Implemented For Examination name from table OnlineExamExaminationMaster
        public IBaseEntityCollectionResponse<EntranceExamApplicableExamToCourse> GetExaminationNameByCourseID(EntranceExamApplicableExamToCourseSearchRequest searchRequest)
        {
            return _EntranceExamApplicableExamToCourseBA.GetExaminationNameByCourseID(searchRequest);
        }
    }
}
