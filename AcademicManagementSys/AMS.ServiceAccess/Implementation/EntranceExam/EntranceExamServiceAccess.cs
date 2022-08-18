using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business.BusinessAction;
namespace AMS.ServiceAccess
{
	public class EntranceExamServiceAccess : IEntranceExamServiceAccess
	{
		IEntranceExamBA _EntranceExamBA = null;
		public EntranceExamServiceAccess()
		{
			_EntranceExamBA = new EntranceExamBA();
		}
		public IBaseEntityResponse<EntranceExam> InsertEntranceExam(EntranceExam item)
		{
			return _EntranceExamBA.InsertEntranceExam(item);
		}
		public IBaseEntityResponse<EntranceExam> UpdateEntranceExam(EntranceExam item)
		{
			return _EntranceExamBA.UpdateEntranceExam(item);
		}
		public IBaseEntityResponse<EntranceExam> DeleteEntranceExam(EntranceExam item)
		{
			return _EntranceExamBA.DeleteEntranceExam(item);
		}
		public IBaseEntityResponse<EntranceExam> SelectByID(EntranceExam item)
		{
			return _EntranceExamBA.SelectByID(item);
		}
        public IBaseEntityCollectionResponse<EntranceExam> GetBySearch(EntranceExamSearchRequest searchRequest)
        {
            return _EntranceExamBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<EntranceExam> GetEntranceExamIndStudentExamInfo(EntranceExamSearchRequest searchRequest)
        {
            return _EntranceExamBA.GetEntranceExamIndStudentExamInfo(searchRequest);
        }
        public IBaseEntityCollectionResponse<EntranceExam> GetEntranceExamIndExamQuestionType(EntranceExamSearchRequest searchRequest)
        {
            return _EntranceExamBA.GetEntranceExamIndExamQuestionType(searchRequest);
        }
        public IBaseEntityCollectionResponse<EntranceExam> EntranceExamIndEGetSetQuestion(EntranceExamSearchRequest searchRequest)
        {
            return _EntranceExamBA.EntranceExamIndEGetSetQuestion(searchRequest);
        }
        public IBaseEntityCollectionResponse<EntranceExam> GetEntranceExamGetResultofStudent(EntranceExamSearchRequest searchRequest)
        {
            return _EntranceExamBA.GetEntranceExamGetResultofStudent(searchRequest);
        }
	}
}
