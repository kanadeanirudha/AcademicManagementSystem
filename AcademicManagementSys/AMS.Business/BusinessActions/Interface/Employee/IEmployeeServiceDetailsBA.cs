using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
    public interface IEmployeeServiceDetailsBA
    {
        IBaseEntityResponse<EmployeeServiceDetails> InsertEmployeeServiceDetails(EmployeeServiceDetails item);
        IBaseEntityResponse<EmployeeServiceDetails> UpdateEmployeeServiceDetails(EmployeeServiceDetails item);
        IBaseEntityResponse<EmployeeServiceDetails> DeleteEmployeeServiceDetails(EmployeeServiceDetails item);
        IBaseEntityCollectionResponse<EmployeeServiceDetails> GetBySearch(EmployeeServiceDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<EmployeeServiceDetails> GetBySearchList(EmployeeServiceDetailsSearchRequest searchRequest);
        IBaseEntityResponse<EmployeeServiceDetails> SelectByID(EmployeeServiceDetails item);
        IBaseEntityResponse<EmployeeServiceDetails> SelectByEmployeeID(EmployeeServiceDetails item);
         
    }
}
