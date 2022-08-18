using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
    public interface IEmployeePersonalDetailsBA
    {
        IBaseEntityResponse<EmployeePersonalDetails> InsertEmployeePersonalDetails(EmployeePersonalDetails item);
        IBaseEntityResponse<EmployeePersonalDetails> UpdateEmployeePersonalDetails(EmployeePersonalDetails item);
        IBaseEntityResponse<EmployeePersonalDetails> DeleteEmployeePersonalDetails(EmployeePersonalDetails item);
        IBaseEntityCollectionResponse<EmployeePersonalDetails> GetBySearch(EmployeePersonalDetailsSearchRequest searchRequest);
        IBaseEntityResponse<EmployeePersonalDetails> SelectByID(EmployeePersonalDetails item);
    }
}
