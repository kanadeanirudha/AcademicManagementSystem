using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
    public interface IEmployeeLanguageDetailsServiceAccess
    {
        IBaseEntityResponse<EmployeeLanguageDetails> InsertEmployeeLanguageDetails(EmployeeLanguageDetails item);
        IBaseEntityResponse<EmployeeLanguageDetails> UpdateEmployeeLanguageDetails(EmployeeLanguageDetails item);
        IBaseEntityResponse<EmployeeLanguageDetails> DeleteEmployeeLanguageDetails(EmployeeLanguageDetails item);
        IBaseEntityCollectionResponse<EmployeeLanguageDetails> GetBySearch(EmployeeLanguageDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<EmployeeLanguageDetails> GetBySearchList(EmployeeLanguageDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<EmployeeLanguageDetails> GetEmployeeLanguageDetailsByID(EmployeeLanguageDetailsSearchRequest searchRequest);
        IBaseEntityResponse<EmployeeLanguageDetails> SelectByID(EmployeeLanguageDetails item);
    }
}
