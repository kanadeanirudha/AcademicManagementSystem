using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class StudentSelfRegistrationServiceAccess : IStudentSelfRegistrationServiceAccess
    {

        IGeneralCasteMasterBA _generalCasteMasterBA = null;
        IStudentSelfRegistrationBA _StudentSelfRegistrationBA = null;
        public StudentSelfRegistrationServiceAccess()
        {
            _StudentSelfRegistrationBA = new StudentSelfRegistrationBA();
        }
        public IBaseEntityResponse<StudentSelfRegistration> InsertStudentSelfRegistration(StudentSelfRegistration item)
        {
            return _StudentSelfRegistrationBA.InsertStudentSelfRegistration(item);
        }
        public IBaseEntityResponse<StudentSelfRegistration> UpdateStudentSelfRegistration(StudentSelfRegistration item)
        {
            return _StudentSelfRegistrationBA.UpdateStudentSelfRegistration(item);
        }
        public IBaseEntityResponse<StudentSelfRegistration> DeleteStudentSelfRegistration(StudentSelfRegistration item)
        {
            return _StudentSelfRegistrationBA.DeleteStudentSelfRegistration(item);
        }
        public IBaseEntityCollectionResponse<StudentSelfRegistration> GetBySearch(StudentSelfRegistrationSearchRequest searchRequest)
        {
            return _StudentSelfRegistrationBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<StudentSelfRegistration> SelectByStudentEmailIDPassword(StudentSelfRegistration item)
        {
            return _StudentSelfRegistrationBA.SelectByStudentEmailIDPassword(item);
        }
        public IBaseEntityCollectionResponse<StudentSelfRegistration> GetListOrgStudyCentreMasterOfApplicableToStudentTemplate(StudentSelfRegistrationSearchRequest searchRequest)
        {
            return _StudentSelfRegistrationBA.GetListOrgStudyCentreMasterOfApplicableToStudentTemplate(searchRequest);
        }
        public IBaseEntityCollectionResponse<StudentSelfRegistration> GetListBranchDetailsOfApplicableToStudentTemplate(StudentSelfRegistrationSearchRequest searchRequest)
        {
            return _StudentSelfRegistrationBA.GetListBranchDetailsOfApplicableToStudentTemplate(searchRequest);
        }
        public IBaseEntityCollectionResponse<StudentSelfRegistration> GetListStandardNumberOfApplicableToStudentTemplate(StudentSelfRegistrationSearchRequest searchRequest)
        {
            return _StudentSelfRegistrationBA.GetListStandardNumberOfApplicableToStudentTemplate(searchRequest);
        }
    }
}
