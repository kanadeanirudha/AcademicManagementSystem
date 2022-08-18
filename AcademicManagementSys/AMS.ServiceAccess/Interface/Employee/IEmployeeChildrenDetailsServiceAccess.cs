using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
    public interface IEmployeeChildrenDetailsServiceAccess
    {
        IBaseEntityResponse<EmployeeChildrenDetails> InsertEmployeeChildrenDetails(EmployeeChildrenDetails item);
        IBaseEntityResponse<EmployeeChildrenDetails> UpdateEmployeeChildrenDetails(EmployeeChildrenDetails item);
        IBaseEntityResponse<EmployeeChildrenDetails> DeleteEmployeeChildrenDetails(EmployeeChildrenDetails item);
        IBaseEntityCollectionResponse<EmployeeChildrenDetails> GetBySearch(EmployeeChildrenDetailsSearchRequest searchRequest);
        IBaseEntityResponse<EmployeeChildrenDetails> SelectByID(EmployeeChildrenDetails item);
    }
}
