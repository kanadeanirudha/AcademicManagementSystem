using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class StudentRegistrationFormServiceAccess : IStudentRegistrationFormServiceAccess
    {
        IStudentRegistrationFormBA _StudentRegistrationFormBA = null;
        public StudentRegistrationFormServiceAccess()
        {
            _StudentRegistrationFormBA = new StudentRegistrationFormBA();
        }
        
        public IBaseEntityCollectionResponse<StudentRegistrationForm> GetByToolRegistrationFieldList(StudentRegistrationFormSearchRequest searchRequest)
        {
            return _StudentRegistrationFormBA.GetByToolRegistrationFieldList(searchRequest);
        }
        public IBaseEntityCollectionResponse<PreviousWorkExperience> GetPreviousWorkExperience(PreviousWorkExperienceSearchRequest searchRequest)
        {
            return _StudentRegistrationFormBA.GetPreviousWorkExperience(searchRequest);
        }
        

        public IBaseEntityResponse<StudentRegistrationForm> SelectByEmailIDAndPassword(StudentRegistrationForm item)
        {
            return _StudentRegistrationFormBA.SelectByEmailIDAndPassword(item);
        }
        public IBaseEntityResponse<StudentRegistrationForm> InsertStudentRegistrationForm(StudentRegistrationForm item)
        {
            return _StudentRegistrationFormBA.InsertStudentRegistrationForm(item);
        }
        public IBaseEntityResponse<StudentRegistrationForm> SelectByID(StudentRegistrationForm item)
        {
            return _StudentRegistrationFormBA.SelectByID(item);
        }
        public IBaseEntityResponse<StudentRegistrationForm> UpdateStudentRegistrationForm(StudentRegistrationForm item)
        {
            return _StudentRegistrationFormBA.UpdateStudentRegistrationForm(item);
        }
        
    }
}
