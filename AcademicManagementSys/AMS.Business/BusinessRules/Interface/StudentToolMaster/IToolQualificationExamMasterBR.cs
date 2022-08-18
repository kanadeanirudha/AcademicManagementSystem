using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IToolQualificationExamMasterBR
    {
        IValidateBusinessRuleResponse InsertToolQualificationExamMasterValidate(ToolQualificationExamMaster item);
        IValidateBusinessRuleResponse UpdateToolQualificationExamMasterValidate(ToolQualificationExamMaster item);
        IValidateBusinessRuleResponse DeleteToolQualificationExamMasterValidate(ToolQualificationExamMaster item);
    }
}
