using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IEmployeeDependentsDataProvider
    {
        IBaseEntityResponse<EmployeeDependents> InsertEmployeeDependents(EmployeeDependents item);
        IBaseEntityResponse<EmployeeDependents> UpdateEmployeeDependents(EmployeeDependents item);
        IBaseEntityResponse<EmployeeDependents> DeleteEmployeeDependents(EmployeeDependents item);
        IBaseEntityCollectionResponse<EmployeeDependents> GetEmployeeDependentsBySearch(EmployeeDependentsSearchRequest searchRequest);
        IBaseEntityResponse<EmployeeDependents> GetEmployeeDependentsByID(EmployeeDependents item);
    }
}
