using AMS.Base.DTO;
using AMS.DTO;
namespace AMS.DataProvider
{
	public interface IEntranceExamDataProvider
	{
		IBaseEntityResponse<EntranceExam> InsertEntranceExam(EntranceExam item);
		IBaseEntityResponse<EntranceExam> UpdateEntranceExam(EntranceExam item);
		IBaseEntityResponse<EntranceExam> DeleteEntranceExam(EntranceExam item);		
		IBaseEntityResponse<EntranceExam> GetEntranceExamByID(EntranceExam item);
        IBaseEntityCollectionResponse<EntranceExam> GetEntranceExamBySearch(EntranceExamSearchRequest searchRequest);
        IBaseEntityCollectionResponse<EntranceExam> GetEntranceExamIndStudentExamInfo(EntranceExamSearchRequest searchRequest);
        IBaseEntityCollectionResponse<EntranceExam> GetEntranceExamIndExamQuestionType(EntranceExamSearchRequest searchRequest);
        IBaseEntityCollectionResponse<EntranceExam> EntranceExamIndEGetSetQuestion(EntranceExamSearchRequest searchRequest);
        IBaseEntityCollectionResponse<EntranceExam> GetEntranceExamGetResultofStudent(EntranceExamSearchRequest searchRequest);        			
	}
}
