using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
    public interface ISalaryPayRulesBA
    {
        IBaseEntityResponse<SalaryPayRules> InsertSalaryPayRules(SalaryPayRules item);
        IBaseEntityResponse<SalaryPayRules> UpdateSalaryPayRules(SalaryPayRules item);
        IBaseEntityResponse<SalaryPayRules> DeleteSalaryPayRules(SalaryPayRules item);
        IBaseEntityCollectionResponse<SalaryPayRules> GetBySearch(SalaryPayRulesSearchRequest searchRequest);
        IBaseEntityResponse<SalaryPayRules> SelectByID(SalaryPayRules item);
        IBaseEntityCollectionResponse<SalaryPayRules> GetBySearchList(SalaryPayRulesSearchRequest searchRequest);
    }
}
