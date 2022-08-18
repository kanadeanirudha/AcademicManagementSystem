using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IFeeCriteriaMasterAndDetailsBR
    {
        IValidateBusinessRuleResponse InsertFeeCriteriaMasterAndDetailsValidate(FeeCriteriaMasterAndDetails item);
        IValidateBusinessRuleResponse UpdateFeeCriteriaMasterAndDetailsValidate(FeeCriteriaMasterAndDetails item);
        IValidateBusinessRuleResponse DeleteFeeCriteriaMasterAndDetailsValidate(FeeCriteriaMasterAndDetails item);
    }
}
