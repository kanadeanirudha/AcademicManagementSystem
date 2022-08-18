
using System;
using System.Collections.Generic;
using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IOnlineExamStudentApplicableBR
    {
        IValidateBusinessRuleResponse InsertGeneralPaperSetMasterValidate(GeneralPaperSetMaster item);
        IValidateBusinessRuleResponse UpdateGeneralPaperSetMasterValidate(GeneralPaperSetMaster item);
        IValidateBusinessRuleResponse DeleteGeneralPaperSetMasterValidate(GeneralPaperSetMaster item);
    }
}
