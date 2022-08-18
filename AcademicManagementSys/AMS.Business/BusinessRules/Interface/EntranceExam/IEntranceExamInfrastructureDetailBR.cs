using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IEntranceExamInfrastructureDetailBR
    {
        // EntranceExamAvailableCentres Method
        IValidateBusinessRuleResponse InsertEntranceExamAvailableCentresValidate(EntranceExamInfrastructureDetail item);
        IValidateBusinessRuleResponse UpdateEntranceExamAvailableCentresValidate(EntranceExamInfrastructureDetail item);
        IValidateBusinessRuleResponse DeleteEntranceExamAvailableCentresValidate(EntranceExamInfrastructureDetail item);

        // EntranceExamInfrastructureDetail Method
        IValidateBusinessRuleResponse InsertEntranceExamInfrastructureDetailValidate(EntranceExamInfrastructureDetail item);
        IValidateBusinessRuleResponse UpdateEntranceExamInfrastructureDetailValidate(EntranceExamInfrastructureDetail item);
        IValidateBusinessRuleResponse DeleteEntranceExamInfrastructureDetailValidate(EntranceExamInfrastructureDetail item);
    }
}
