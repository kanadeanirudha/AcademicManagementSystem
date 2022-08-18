using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class StudentRegistrationAcademicApprovalServiceAccess : IStudentRegistrationAcademicApprovalServiceAccess
    {
        IStudentRegistrationAcademicApprovalBA _StudentRegistrationAcademicApprovalBA = null;
        public StudentRegistrationAcademicApprovalServiceAccess()
        {
            _StudentRegistrationAcademicApprovalBA = new StudentRegistrationAcademicApprovalBA();
        }
        public IBaseEntityResponse<StudentRegistrationAcademicApproval> InsertStudentRegistrationAcademicApproval(StudentRegistrationAcademicApproval item)
        {
            return _StudentRegistrationAcademicApprovalBA.InsertStudentRegistrationAcademicApproval(item);
        }
        public IBaseEntityResponse<StudentRegistrationAcademicApproval> UpdateStudentRegistrationAcademicApproval(StudentRegistrationAcademicApproval item)
        {
            return _StudentRegistrationAcademicApprovalBA.UpdateStudentRegistrationAcademicApproval(item);
        }
        public IBaseEntityResponse<StudentRegistrationAcademicApproval> DeleteStudentRegistrationAcademicApproval(StudentRegistrationAcademicApproval item)
        {
            return _StudentRegistrationAcademicApprovalBA.DeleteStudentRegistrationAcademicApproval(item);
        }
        public IBaseEntityCollectionResponse<StudentRegistrationAcademicApproval> GetBySearch(StudentRegistrationAcademicApprovalSearchRequest searchRequest)
        {
            return _StudentRegistrationAcademicApprovalBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<StudentRegistrationAcademicApproval> SelectByID(StudentRegistrationAcademicApproval item)
        {
            return _StudentRegistrationAcademicApprovalBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<StudentRegistrationAcademicApproval> GetByQualifyingExamSubjectList(StudentRegistrationAcademicApprovalSearchRequest searchRequest)
        {
            return _StudentRegistrationAcademicApprovalBA.GetByQualifyingExamSubjectList(searchRequest);
        }
        public IBaseEntityCollectionResponse<StudentRegistrationAcademicApproval> GetByQualificationSubjectListByStudentRegistrationIDAndEducationType(StudentRegistrationAcademicApprovalSearchRequest searchRequest)
        {
            return _StudentRegistrationAcademicApprovalBA.GetByQualificationSubjectListByStudentRegistrationIDAndEducationType(searchRequest);
        }
        public IBaseEntityCollectionResponse<PreviousWorkExperienceAcademicApproval> GetPreviousWorkExperienceAcademicApproval(PreviousWorkExperienceAcademicApprovalSearchRequest searchRequest)
        {
            return _StudentRegistrationAcademicApprovalBA.GetPreviousWorkExperienceAcademicApproval(searchRequest);
        }
        
    }
}
