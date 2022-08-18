using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class StudentQuickRegistrationServiceAccess : IStudentQuickRegistrationServiceAccess
    {
        IStudentQuickRegistrationBA _studentQuickRegistrationBA = null;
        public StudentQuickRegistrationServiceAccess()
        {
            _studentQuickRegistrationBA = new StudentQuickRegistrationBA();
        }
        public IBaseEntityResponse<StudentQuickRegistration> InsertStudentQuickRegistration(StudentQuickRegistration item)
        {
            return _studentQuickRegistrationBA.InsertStudentQuickRegistration(item);
        }
        public IBaseEntityResponse<StudentQuickRegistration> UpdateStudentQuickRegistration(StudentQuickRegistration item)
        {
            return _studentQuickRegistrationBA.UpdateStudentQuickRegistration(item);
        }
        public IBaseEntityResponse<StudentQuickRegistration> DeleteStudentQuickRegistration(StudentQuickRegistration item)
        {
            return _studentQuickRegistrationBA.DeleteStudentQuickRegistration(item);
        }
        public IBaseEntityCollectionResponse<StudentQuickRegistration> GetBySearch(StudentQuickRegistrationSearchRequest searchRequest)
        {
            return _studentQuickRegistrationBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<StudentQuickRegistration> SelectByID(StudentQuickRegistration item)
        {
            return _studentQuickRegistrationBA.SelectByID(item);
        }
    }
}
