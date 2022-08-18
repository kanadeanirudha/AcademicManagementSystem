using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface ITaskApprovalFormFieldNameMasterBR
    {
        IValidateBusinessRuleResponse InsertTaskApprovalFormFieldNameMasterValidate(TaskApprovalFormFieldNameMaster item);
        IValidateBusinessRuleResponse UpdateTaskApprovalFormFieldNameMasterValidate(TaskApprovalFormFieldNameMaster item);
        IValidateBusinessRuleResponse DeleteTaskApprovalFormFieldNameMasterValidate(TaskApprovalFormFieldNameMaster item);
    }
}
