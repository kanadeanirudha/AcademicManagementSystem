using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
    public interface IStudentQuickRegistrationServiceAccess
    {
        IBaseEntityResponse<StudentQuickRegistration> InsertStudentQuickRegistration(StudentQuickRegistration item);
        IBaseEntityResponse<StudentQuickRegistration> UpdateStudentQuickRegistration(StudentQuickRegistration item);
        IBaseEntityResponse<StudentQuickRegistration> DeleteStudentQuickRegistration(StudentQuickRegistration item);
        IBaseEntityCollectionResponse<StudentQuickRegistration> GetBySearch(StudentQuickRegistrationSearchRequest searchRequest);
        IBaseEntityResponse<StudentQuickRegistration> SelectByID(StudentQuickRegistration item);
    }
}
