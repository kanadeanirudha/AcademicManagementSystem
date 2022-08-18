using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
    public interface IEmployeeExperienceServiceAccess
    {
        IBaseEntityResponse<EmployeeExperience> InsertEmployeeExperience(EmployeeExperience item);
        IBaseEntityResponse<EmployeeExperience> UpdateEmployeeExperience(EmployeeExperience item);
        IBaseEntityResponse<EmployeeExperience> DeleteEmployeeExperience(EmployeeExperience item);
        IBaseEntityCollectionResponse<EmployeeExperience> GetBySearch(EmployeeExperienceSearchRequest searchRequest);
        IBaseEntityResponse<EmployeeExperience> SelectByID(EmployeeExperience item);
    }
}
