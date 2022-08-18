using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IUserMasterBR
    {
        IValidateBusinessRuleResponse InsertUserMasterValidate(UserMaster item);

        IValidateBusinessRuleResponse UpdateUserMasterValidate(UserMaster item);

        IValidateBusinessRuleResponse DeleteUserMasterValidate(UserMaster item);
    }
}
