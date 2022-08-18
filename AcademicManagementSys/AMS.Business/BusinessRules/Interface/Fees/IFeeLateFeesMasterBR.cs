using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IFeeLateFeesMasterBR
    {
        IValidateBusinessRuleResponse InsertFeeLateFeesMasterValidate(FeeLateFeesMaster item);
        IValidateBusinessRuleResponse UpdateFeeLateFeesMasterValidate(FeeLateFeesMaster item);
        IValidateBusinessRuleResponse DeleteFeeLateFeesMasterValidate(FeeLateFeesMaster item);
    }
}
