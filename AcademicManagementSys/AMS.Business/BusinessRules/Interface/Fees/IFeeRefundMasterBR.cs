using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IFeeRefundMasterBR
    {
        IValidateBusinessRuleResponse InsertFeeRefundMasterValidate(FeeRefundMaster item);
        IValidateBusinessRuleResponse UpdateFeeRefundMasterValidate(FeeRefundMaster item);
        IValidateBusinessRuleResponse DeleteFeeRefundMasterValidate(FeeRefundMaster item);
    }
}
