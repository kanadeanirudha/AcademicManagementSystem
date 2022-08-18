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
    public interface IGeneralRequestMasterBR
    {
        IValidateBusinessRuleResponse InsertGeneralRequestMasterValidate(GeneralRequestMaster item);
        IValidateBusinessRuleResponse UpdateGeneralRequestMasterValidate(GeneralRequestMaster item);
        IValidateBusinessRuleResponse DeleteGeneralRequestMasterValidate(GeneralRequestMaster item);
    }
}
