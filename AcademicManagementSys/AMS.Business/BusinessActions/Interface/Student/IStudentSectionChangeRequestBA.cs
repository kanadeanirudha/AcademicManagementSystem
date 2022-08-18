using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
	public interface IStudentSectionChangeRequestBA
	{
		IBaseEntityResponse<StudentSectionChangeRequest> InsertStudentSectionChangeRequest(StudentSectionChangeRequest item);
		IBaseEntityResponse<StudentSectionChangeRequest> UpdateStudentSectionChangeRequest(StudentSectionChangeRequest item);
		IBaseEntityResponse<StudentSectionChangeRequest> DeleteStudentSectionChangeRequest(StudentSectionChangeRequest item);
		IBaseEntityCollectionResponse<StudentSectionChangeRequest> GetBySearch(StudentSectionChangeRequestSearchRequest searchRequest);
        IBaseEntityCollectionResponse<StudentSectionChangeRequest> GetSectionList(StudentSectionChangeRequestSearchRequest searchRequest);
		IBaseEntityResponse<StudentSectionChangeRequest> SelectByID(StudentSectionChangeRequest item);
	}
}
