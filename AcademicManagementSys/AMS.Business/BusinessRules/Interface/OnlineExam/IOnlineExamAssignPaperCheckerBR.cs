
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
    public interface IOnlineExamAssignPaperCheckerBR
    {
        IValidateBusinessRuleResponse InsertOnlineExamAssignPaperCheckerValidate(OnlineExamAssignPaperChecker item);
        IValidateBusinessRuleResponse UpdateOnlineExamAssignPaperCheckerValidate(OnlineExamAssignPaperChecker item);
        IValidateBusinessRuleResponse DeleteOnlineExamAssignPaperCheckerValidate(OnlineExamAssignPaperChecker item);
    }
}
