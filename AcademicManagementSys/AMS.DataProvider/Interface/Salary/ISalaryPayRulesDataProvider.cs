using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface ISalaryPayRulesDataProvider
    {
        IBaseEntityResponse<SalaryPayRules> InsertSalaryPayRules(SalaryPayRules item);
        IBaseEntityResponse<SalaryPayRules> UpdateSalaryPayRules(SalaryPayRules item);
        IBaseEntityResponse<SalaryPayRules> DeleteSalaryPayRules(SalaryPayRules item);
       // IBaseEntityCollectionResponse<SalaryPayRules> GetSalaryPayRulesBySearch(SalaryPayRulesSearchRequest searchRequest);
        IBaseEntityResponse<SalaryPayRules> GetSalaryPayRulesByID(SalaryPayRules item);
        IBaseEntityCollectionResponse<SalaryPayRules> GetBySearchList(SalaryPayRulesSearchRequest searchRequest);

        IBaseEntityCollectionResponse<SalaryPayRules> GetBySearch(SalaryPayRulesSearchRequest searchRequest);
    }
}
