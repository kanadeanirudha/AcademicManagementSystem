using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IEmpEmployeeMasterBR
    {
        IValidateBusinessRuleResponse InsertEmpEmployeeMasterValidate(EmpEmployeeMaster item);
        IValidateBusinessRuleResponse UpdateEmpEmployeeMasterValidate(EmpEmployeeMaster item);
        IValidateBusinessRuleResponse DeleteEmpEmployeeMasterValidate(EmpEmployeeMaster item);
    }
}
