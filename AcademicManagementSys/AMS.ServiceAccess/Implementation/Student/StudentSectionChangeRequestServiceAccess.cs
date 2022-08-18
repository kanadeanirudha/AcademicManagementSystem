using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business.BusinessActions;

namespace AMS.ServiceAccess
{
	public class StudentSectionChangeRequestServiceAccess : IStudentSectionChangeRequestServiceAccess
	{
		IStudentSectionChangeRequestBA _StudentSectionChangeRequestBA = null;
		public StudentSectionChangeRequestServiceAccess()
		{
			_StudentSectionChangeRequestBA = new StudentSectionChangeRequestBA();
		}
		public IBaseEntityResponse<StudentSectionChangeRequest> InsertStudentSectionChangeRequest(StudentSectionChangeRequest item)
		{
			return _StudentSectionChangeRequestBA.InsertStudentSectionChangeRequest(item);
		}
		public IBaseEntityResponse<StudentSectionChangeRequest> UpdateStudentSectionChangeRequest(StudentSectionChangeRequest item)
		{
			return _StudentSectionChangeRequestBA.UpdateStudentSectionChangeRequest(item);
		}
		public IBaseEntityResponse<StudentSectionChangeRequest> DeleteStudentSectionChangeRequest(StudentSectionChangeRequest item)
		{
			return _StudentSectionChangeRequestBA.DeleteStudentSectionChangeRequest(item);
		}
		public IBaseEntityCollectionResponse<StudentSectionChangeRequest> GetBySearch(StudentSectionChangeRequestSearchRequest searchRequest)
		{
			return _StudentSectionChangeRequestBA.GetBySearch(searchRequest);
		}
        public IBaseEntityCollectionResponse<StudentSectionChangeRequest> GetSectionList(StudentSectionChangeRequestSearchRequest searchRequest)
		{
            return _StudentSectionChangeRequestBA.GetSectionList(searchRequest);
		}
		public IBaseEntityResponse<StudentSectionChangeRequest> SelectByID(StudentSectionChangeRequest item)
		{
			return _StudentSectionChangeRequestBA.SelectByID(item);
		}
	}
}
