using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IGeneralPolicyRulesServiceAccess
    {
        IBaseEntityResponse<GeneralPolicyRules> InsertGeneralPolicyRules(GeneralPolicyRules item);
        IBaseEntityResponse<GeneralPolicyRules> UpdateGeneralPolicyRules(GeneralPolicyRules item);
        IBaseEntityResponse<GeneralPolicyRules> DeleteGeneralPolicyRules(GeneralPolicyRules item);
        IBaseEntityCollectionResponse<GeneralPolicyRules> GetBySearch(GeneralPolicyRulesSearchRequest searchRequest);
        IBaseEntityResponse<GeneralPolicyRules> SelectByID(GeneralPolicyRules item);
        IBaseEntityCollectionResponse<GeneralPolicyRules> GetGeneralPolicyRulesForPolicyRange(GeneralPolicyRulesSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralPolicyRules> GetGeneralPolicyRulesGetBySearchList(GeneralPolicyRulesSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralPolicyRules> GetPolicyAnswerByPolicyStatus(GeneralPolicyRulesSearchRequest searchRequest);
        IBaseEntityResponse<GeneralPolicyRules> GetPolicyApplicableStatus(GeneralPolicyRules item);
    }
}
