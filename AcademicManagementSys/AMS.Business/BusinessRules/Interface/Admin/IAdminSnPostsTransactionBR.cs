using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IAdminSnPostsTransactionBR
    {
        IValidateBusinessRuleResponse InsertAdminSnPostsTransactionValidate(AdminSnPostsTransaction item);

        IValidateBusinessRuleResponse UpdateAdminSnPostsTransactionValidate(AdminSnPostsTransaction item);

        IValidateBusinessRuleResponse DeleteAdminSnPostsTransactionValidate(AdminSnPostsTransaction item);
    }
}
