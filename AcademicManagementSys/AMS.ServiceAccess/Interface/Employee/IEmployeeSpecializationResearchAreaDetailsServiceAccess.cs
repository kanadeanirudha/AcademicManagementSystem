using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
    public interface IEmployeeSpecializationResearchAreaDetailsServiceAccess
    {
        IBaseEntityResponse<EmployeeSpecializationResearchAreaDetails> InsertEmployeeSpecializationResearchAreaDetails(EmployeeSpecializationResearchAreaDetails item);
        IBaseEntityResponse<EmployeeSpecializationResearchAreaDetails> UpdateEmployeeSpecializationResearchAreaDetails(EmployeeSpecializationResearchAreaDetails item);
        IBaseEntityResponse<EmployeeSpecializationResearchAreaDetails> DeleteEmployeeSpecializationResearchAreaDetails(EmployeeSpecializationResearchAreaDetails item);
        IBaseEntityCollectionResponse<EmployeeSpecializationResearchAreaDetails> GetBySearch(EmployeeSpecializationResearchAreaDetailsSearchRequest searchRequest);
        IBaseEntityResponse<EmployeeSpecializationResearchAreaDetails> SelectByID(EmployeeSpecializationResearchAreaDetails item);
    }
}
