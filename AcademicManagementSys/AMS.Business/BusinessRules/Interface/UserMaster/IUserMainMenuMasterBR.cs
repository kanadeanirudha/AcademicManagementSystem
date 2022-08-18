using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IUserMainMenuMasterBR
    {
        IValidateBusinessRuleResponse InsertUserMainMenuMasterValidate(UserMainMenuMaster item);
        IValidateBusinessRuleResponse UpdateUserMainMenuMasterValidate(UserMainMenuMaster item);
        IValidateBusinessRuleResponse DeleteUserMainMenuMasterValidate(UserMainMenuMaster item);
    }
}
