using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
	public interface IGenerateStudentRollNumberBA
	{
		IBaseEntityResponse<GenerateStudentRollNumber> InsertGenerateStudentRollNumber(GenerateStudentRollNumber item);
		IBaseEntityResponse<GenerateStudentRollNumber> UpdateGenerateStudentRollNumber(GenerateStudentRollNumber item);
		IBaseEntityResponse<GenerateStudentRollNumber> DeleteGenerateStudentRollNumber(GenerateStudentRollNumber item);
		IBaseEntityCollectionResponse<GenerateStudentRollNumber> GetBySearch(GenerateStudentRollNumberSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GenerateStudentRollNumber> GetGenerateStudentRollNumberStudentListBySearch(GenerateStudentRollNumberSearchRequest searchRequest);
		IBaseEntityResponse<GenerateStudentRollNumber> SelectByID(GenerateStudentRollNumber item);
	}
}
