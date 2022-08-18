using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IFeeReceiptMasterBR
    {
        IValidateBusinessRuleResponse InsertFeeReceiptMasterValidate(FeeReceiptMaster item);
        IValidateBusinessRuleResponse UpdateFeeReceiptMasterValidate(FeeReceiptMaster item);
        IValidateBusinessRuleResponse DeleteFeeReceiptMasterValidate(FeeReceiptMaster item);
        IValidateBusinessRuleResponse CreateFeeStructureRequestApproval(FeeReceiptMaster item);
    }
}
