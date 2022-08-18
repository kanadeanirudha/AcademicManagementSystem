using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IToolQualificationApplicableBR
    {
        IValidateBusinessRuleResponse InsertToolQualificationApplicableValidate(ToolQualificationApplicable item);
        IValidateBusinessRuleResponse UpdateToolQualificationApplicableValidate(ToolQualificationApplicable item);
        IValidateBusinessRuleResponse DeleteToolQualificationApplicableValidate(ToolQualificationApplicable item);
    }
}
