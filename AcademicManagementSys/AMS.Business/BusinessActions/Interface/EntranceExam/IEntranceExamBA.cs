using AMS.Base.DTO;
using AMS.DTO;
namespace AMS.Business.BusinessAction
{
	public interface IEntranceExamBA
	{
		IBaseEntityResponse<EntranceExam> InsertEntranceExam(EntranceExam item);
		IBaseEntityResponse<EntranceExam> UpdateEntranceExam(EntranceExam item);
		IBaseEntityResponse<EntranceExam> DeleteEntranceExam(EntranceExam item);		
		IBaseEntityResponse<EntranceExam> SelectByID(EntranceExam item);
        IBaseEntityCollectionResponse<EntranceExam> GetBySearch(EntranceExamSearchRequest searchRequest);
        IBaseEntityCollectionResponse<EntranceExam> GetEntranceExamIndStudentExamInfo(EntranceExamSearchRequest searchRequest);
        IBaseEntityCollectionResponse<EntranceExam> GetEntranceExamIndExamQuestionType(EntranceExamSearchRequest searchRequest);
        IBaseEntityCollectionResponse<EntranceExam> EntranceExamIndEGetSetQuestion(EntranceExamSearchRequest searchRequest);
        IBaseEntityCollectionResponse<EntranceExam> GetEntranceExamGetResultofStudent(EntranceExamSearchRequest searchRequest); 
	}
}
