using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IToolQualificationMasterSubjectBR
    {
        IValidateBusinessRuleResponse InsertToolQualificationMasterSubjectValidate(ToolQualificationMasterSubject item);
        IValidateBusinessRuleResponse UpdateToolQualificationMasterSubjectValidate(ToolQualificationMasterSubject item);
        IValidateBusinessRuleResponse DeleteToolQualificationMasterSubjectValidate(ToolQualificationMasterSubject item);
    }
}
