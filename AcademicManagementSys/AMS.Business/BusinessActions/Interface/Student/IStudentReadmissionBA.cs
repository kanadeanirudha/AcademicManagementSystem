using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
	public interface IStudentReadmissionBA
	{
		IBaseEntityResponse<StudentReadmission> InsertStudentReadmission(StudentReadmission item);
		IBaseEntityResponse<StudentReadmission> UpdateStudentReadmission(StudentReadmission item);
		IBaseEntityResponse<StudentReadmission> DeleteStudentReadmission(StudentReadmission item);
		IBaseEntityCollectionResponse<StudentReadmission> GetBySearch(StudentReadmissionSearchRequest searchRequest);
		IBaseEntityResponse<StudentReadmission> SelectByID(StudentReadmission item);
        /// <summary>
        /// Interfacefor AuthoriseStudentSectionChangeRequest form
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<StudentReadmission> InsertAuthoriseStudentSectionChangeRequest(StudentReadmission item);
	}
}
