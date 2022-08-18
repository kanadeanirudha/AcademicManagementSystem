using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IStudentSelfRegistrationDataProvider
    {
        IBaseEntityResponse<StudentSelfRegistration> InsertStudentSelfRegistration(StudentSelfRegistration item);
        IBaseEntityResponse<StudentSelfRegistration> UpdateStudentSelfRegistration(StudentSelfRegistration item);
        IBaseEntityResponse<StudentSelfRegistration> DeleteStudentSelfRegistration(StudentSelfRegistration item);
        IBaseEntityCollectionResponse<StudentSelfRegistration> GetStudentSelfRegistrationBySearch(StudentSelfRegistrationSearchRequest searchRequest);
        IBaseEntityResponse<StudentSelfRegistration> SelectByStudentEmailIDPassword(StudentSelfRegistration item);
        IBaseEntityCollectionResponse<GeneralCountryMaster> GetGeneralCountryMasterGetBySearchList(GeneralCountryMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<StudentSelfRegistration> GetListOrgStudyCentreMasterOfApplicableToStudentTemplate(StudentSelfRegistrationSearchRequest searchRequest);
        IBaseEntityCollectionResponse<StudentSelfRegistration> GetListBranchDetailsOfApplicableToStudentTemplate(StudentSelfRegistrationSearchRequest searchRequest);
        IBaseEntityCollectionResponse<StudentSelfRegistration> GetListStandardNumberOfApplicableToStudentTemplate(StudentSelfRegistrationSearchRequest searchRequest);
    }
}
