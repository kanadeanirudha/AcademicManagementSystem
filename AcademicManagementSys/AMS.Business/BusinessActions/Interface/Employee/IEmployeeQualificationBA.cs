using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
    public interface IEmployeeQualificationBA
    {
        IBaseEntityResponse<EmployeeQualification> InsertEmployeeQualification(EmployeeQualification item);
        IBaseEntityResponse<EmployeeQualification> UpdateEmployeeQualification(EmployeeQualification item);
        IBaseEntityResponse<EmployeeQualification> DeleteEmployeeQualification(EmployeeQualification item);
        IBaseEntityCollectionResponse<EmployeeQualification> GetBySearch(EmployeeQualificationSearchRequest searchRequest);
        IBaseEntityResponse<EmployeeQualification> SelectByID(EmployeeQualification item);
    }
}
