using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IEmployeeExperienceDataProvider
    {
        IBaseEntityResponse<EmployeeExperience> InsertEmployeeExperience(EmployeeExperience item);
        IBaseEntityResponse<EmployeeExperience> UpdateEmployeeExperience(EmployeeExperience item);
        IBaseEntityResponse<EmployeeExperience> DeleteEmployeeExperience(EmployeeExperience item);
        IBaseEntityCollectionResponse<EmployeeExperience> GetEmployeeExperienceBySearch(EmployeeExperienceSearchRequest searchRequest);
        IBaseEntityResponse<EmployeeExperience> GetEmployeeExperienceByID(EmployeeExperience item);
    }
}
