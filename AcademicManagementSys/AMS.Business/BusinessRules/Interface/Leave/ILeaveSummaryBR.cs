using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface ILeaveSummaryBR
    {
        IValidateBusinessRuleResponse InsertLeaveSummaryValidate(LeaveSummary item);
        IValidateBusinessRuleResponse UpdateLeaveSummaryValidate(LeaveSummary item);
        IValidateBusinessRuleResponse DeleteLeaveSummaryValidate(LeaveSummary item);
    }
}
