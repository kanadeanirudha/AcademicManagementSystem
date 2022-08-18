using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IEmployeeContactDetailsDataProvider
    {
        IBaseEntityResponse<EmployeeContactDetails> InsertEmployeeContactDetails(EmployeeContactDetails item);
        IBaseEntityResponse<EmployeeContactDetails> UpdateEmployeeContactDetails(EmployeeContactDetails item);
        IBaseEntityResponse<EmployeeContactDetails> DeleteEmployeeContactDetails(EmployeeContactDetails item);
        IBaseEntityCollectionResponse<EmployeeContactDetails> GetEmployeeContactDetailsBySearch(EmployeeContactDetailsSearchRequest searchRequest);
        IBaseEntityResponse<EmployeeContactDetails> GetEmployeeContactDetailsByID(EmployeeContactDetails item);
    }
}
