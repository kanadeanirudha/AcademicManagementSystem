using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
	public class StudentReadmissionServiceAccess : IStudentReadmissionServiceAccess
	{
		IStudentReadmissionBA _StudentReadmissionBA = null;
		public StudentReadmissionServiceAccess()
		{
			_StudentReadmissionBA = new StudentReadmissionBA();
		}
		public IBaseEntityResponse<StudentReadmission> InsertStudentReadmission(StudentReadmission item)
		{
			return _StudentReadmissionBA.InsertStudentReadmission(item);
		}
		public IBaseEntityResponse<StudentReadmission> UpdateStudentReadmission(StudentReadmission item)
		{
			return _StudentReadmissionBA.UpdateStudentReadmission(item);
		}
		public IBaseEntityResponse<StudentReadmission> DeleteStudentReadmission(StudentReadmission item)
		{
			return _StudentReadmissionBA.DeleteStudentReadmission(item);
		}
		public IBaseEntityCollectionResponse<StudentReadmission> GetBySearch(StudentReadmissionSearchRequest searchRequest)
		{
			return _StudentReadmissionBA.GetBySearch(searchRequest);
		}
		public IBaseEntityResponse<StudentReadmission> SelectByID(StudentReadmission item)
		{
			return _StudentReadmissionBA.SelectByID(item);
		}
       
        /// <summary>
        /// Service Action method for AuthoriseStudentSectionChangeRequest form
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<StudentReadmission> InsertAuthoriseStudentSectionChangeRequest(StudentReadmission item)
		{
            return _StudentReadmissionBA.InsertAuthoriseStudentSectionChangeRequest(item);
		}
	}
}

