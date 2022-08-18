using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataProvider
{
	public interface IStudentReadmissionDataProvider
	{
		IBaseEntityResponse<StudentReadmission> InsertStudentReadmission(StudentReadmission item);
		IBaseEntityResponse<StudentReadmission> UpdateStudentReadmission(StudentReadmission item);
		IBaseEntityResponse<StudentReadmission> DeleteStudentReadmission(StudentReadmission item);
		IBaseEntityCollectionResponse<StudentReadmission> GetStudentReadmissionBySearch(StudentReadmissionSearchRequest searchRequest);
		IBaseEntityResponse<StudentReadmission> GetStudentReadmissionByID(StudentReadmission item);
        /// <summary>
        /// Interface for AuthoriseStudentSEctionChangeRequest form
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<StudentReadmission> InsertAuthoriseStudentSectionChangeRequest(StudentReadmission item);
	}
}
