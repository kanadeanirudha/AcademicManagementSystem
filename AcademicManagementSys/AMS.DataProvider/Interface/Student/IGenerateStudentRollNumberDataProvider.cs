using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataProvider
{
	public interface IGenerateStudentRollNumberDataProvider
	{
		IBaseEntityResponse<GenerateStudentRollNumber> InsertGenerateStudentRollNumber(GenerateStudentRollNumber item);
		IBaseEntityResponse<GenerateStudentRollNumber> UpdateGenerateStudentRollNumber(GenerateStudentRollNumber item);
		IBaseEntityResponse<GenerateStudentRollNumber> DeleteGenerateStudentRollNumber(GenerateStudentRollNumber item);
		IBaseEntityCollectionResponse<GenerateStudentRollNumber> GetGenerateStudentRollNumberBySearch(GenerateStudentRollNumberSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GenerateStudentRollNumber> GetGenerateStudentRollNumberStudentListBySearch(GenerateStudentRollNumberSearchRequest searchRequest);
		IBaseEntityResponse<GenerateStudentRollNumber> GetGenerateStudentRollNumberByID(GenerateStudentRollNumber item);
	}
}
