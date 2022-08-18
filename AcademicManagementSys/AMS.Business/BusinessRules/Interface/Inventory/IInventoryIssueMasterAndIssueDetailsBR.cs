using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IInventoryIssueMasterAndIssueDetailsBR
    {
        // InventoryIssueMaster Method
        IValidateBusinessRuleResponse InsertInventoryIssueMasterValidate(InventoryIssueMasterAndIssueDetails item);
        IValidateBusinessRuleResponse UpdateInventoryIssueMasterValidate(InventoryIssueMasterAndIssueDetails item);
        IValidateBusinessRuleResponse DeleteInventoryIssueMasterValidate(InventoryIssueMasterAndIssueDetails item);

        // InventoryIssueDetails Method
        IValidateBusinessRuleResponse InsertInventoryIssueDetailsValidate(InventoryIssueMasterAndIssueDetails item);
        IValidateBusinessRuleResponse UpdateInventoryIssueDetailsValidate(InventoryIssueMasterAndIssueDetails item);
        IValidateBusinessRuleResponse DeleteInventoryIssueDetailsValidate(InventoryIssueMasterAndIssueDetails item);
    }
}
