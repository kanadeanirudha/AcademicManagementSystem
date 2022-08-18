using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface ILeaveMasterBR
    {
        IValidateBusinessRuleResponse InsertLeaveMasterValidate(LeaveMaster item);
        IValidateBusinessRuleResponse UpdateLeaveMasterValidate(LeaveMaster item);
        IValidateBusinessRuleResponse DeleteLeaveMasterValidate(LeaveMaster item);
    }
}
