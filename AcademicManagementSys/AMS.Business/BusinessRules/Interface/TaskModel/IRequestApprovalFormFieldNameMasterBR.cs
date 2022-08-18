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
    public interface IRequestApprovalFormFieldNameMasterBR
    {
        IValidateBusinessRuleResponse InsertRequestApprovalFormFieldNameMasterValidate(RequestApprovalFormFieldNameMaster item);
        IValidateBusinessRuleResponse UpdateRequestApprovalFormFieldNameMasterValidate(RequestApprovalFormFieldNameMaster item);
        IValidateBusinessRuleResponse DeleteRequestApprovalFormFieldNameMasterValidate(RequestApprovalFormFieldNameMaster item);
    }
}
