using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IUserDetailBR
    {
        IValidateBusinessRuleResponse InsertUserDetailValidate(UserDetail item);

        IValidateBusinessRuleResponse UpdateUserDetailValidate(UserDetail item);

        IValidateBusinessRuleResponse DeleteUserDetailValidate(UserDetail item);
    }
}
