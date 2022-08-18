using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class SalaryPayRulesServiceAccess : ISalaryPayRulesServiceAccess
    {
        ISalaryPayRulesBA _SalaryPayRulesBA = null;
        public SalaryPayRulesServiceAccess()
        {
            _SalaryPayRulesBA = new SalaryPayRulesBA();
        }
        public IBaseEntityResponse<SalaryPayRules> InsertSalaryPayRules(SalaryPayRules item)
        {
            return _SalaryPayRulesBA.InsertSalaryPayRules(item);
        }
        public IBaseEntityResponse<SalaryPayRules> UpdateSalaryPayRules(SalaryPayRules item)
        {
            return _SalaryPayRulesBA.UpdateSalaryPayRules(item);
        }
        public IBaseEntityResponse<SalaryPayRules> DeleteSalaryPayRules(SalaryPayRules item)
        {
            return _SalaryPayRulesBA.DeleteSalaryPayRules(item);
        }
        public IBaseEntityCollectionResponse<SalaryPayRules> GetBySearch(SalaryPayRulesSearchRequest searchRequest)
        {
            return _SalaryPayRulesBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<SalaryPayRules> SelectByID(SalaryPayRules item)
        {
            return _SalaryPayRulesBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<SalaryPayRules> GetBySearchList(SalaryPayRulesSearchRequest searchRequest)
        {
            return _SalaryPayRulesBA.GetBySearchList(searchRequest);
        }
    }
}
