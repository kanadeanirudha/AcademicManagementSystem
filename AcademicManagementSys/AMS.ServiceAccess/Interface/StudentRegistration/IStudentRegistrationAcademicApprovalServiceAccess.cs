using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
    public interface IStudentRegistrationAcademicApprovalServiceAccess
    {
        IBaseEntityResponse<StudentRegistrationAcademicApproval> InsertStudentRegistrationAcademicApproval(StudentRegistrationAcademicApproval item);
        IBaseEntityResponse<StudentRegistrationAcademicApproval> UpdateStudentRegistrationAcademicApproval(StudentRegistrationAcademicApproval item);
        IBaseEntityResponse<StudentRegistrationAcademicApproval> DeleteStudentRegistrationAcademicApproval(StudentRegistrationAcademicApproval item);
        IBaseEntityCollectionResponse<StudentRegistrationAcademicApproval> GetBySearch(StudentRegistrationAcademicApprovalSearchRequest searchRequest);
        IBaseEntityResponse<StudentRegistrationAcademicApproval> SelectByID(StudentRegistrationAcademicApproval item);
        IBaseEntityCollectionResponse<StudentRegistrationAcademicApproval> GetByQualifyingExamSubjectList(StudentRegistrationAcademicApprovalSearchRequest searchRequest);
        IBaseEntityCollectionResponse<StudentRegistrationAcademicApproval> GetByQualificationSubjectListByStudentRegistrationIDAndEducationType(StudentRegistrationAcademicApprovalSearchRequest searchRequest);
        IBaseEntityCollectionResponse<PreviousWorkExperienceAcademicApproval> GetPreviousWorkExperienceAcademicApproval(PreviousWorkExperienceAcademicApprovalSearchRequest searchRequest); 

    }
}
