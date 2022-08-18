using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IToolTemplateApplicableBR
    {
        IValidateBusinessRuleResponse InsertToolTemplateApplicableValidate(ToolTemplateApplicable item);
        IValidateBusinessRuleResponse UpdateToolTemplateApplicableValidate(ToolTemplateApplicable item);
        IValidateBusinessRuleResponse DeleteToolTemplateApplicableValidate(ToolTemplateApplicable item);
    }
}
