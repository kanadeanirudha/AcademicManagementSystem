using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business;
using AMS.Business.BusinessActions;
namespace AMS.ServiceAccess
{
    public class CRMSaleAccountProgressTypeMasterAndRuleServiceAccess : ICRMSaleAccountProgressTypeMasterAndRuleServiceAccess
    {
        ICRMSaleAccountProgressTypeMasterAndRuleBA _CRMSaleAccountProgressTypeMasterAndRuleBA = null;

        public CRMSaleAccountProgressTypeMasterAndRuleServiceAccess()
        {
            _CRMSaleAccountProgressTypeMasterAndRuleBA = new CRMSaleAccountProgressTypeMasterAndRuleBA();
        }

        //CRMSaleAccountProgressTypeRule
        public IBaseEntityResponse<CRMSaleAccountProgressTypeMasterAndRule> InsertCRMSaleAccountProgressTypeRule(CRMSaleAccountProgressTypeMasterAndRule item)
        {
            return _CRMSaleAccountProgressTypeMasterAndRuleBA.InsertCRMSaleAccountProgressTypeRule(item);
        }

        public IBaseEntityResponse<CRMSaleAccountProgressTypeMasterAndRule> UpdateCRMSaleAccountProgressTypeRule(CRMSaleAccountProgressTypeMasterAndRule item)
        {
            return _CRMSaleAccountProgressTypeMasterAndRuleBA.UpdateCRMSaleAccountProgressTypeRule(item);
        }

        public IBaseEntityResponse<CRMSaleAccountProgressTypeMasterAndRule> DeleteCRMSaleAccountProgressTypeRule(CRMSaleAccountProgressTypeMasterAndRule item)
        {
            return _CRMSaleAccountProgressTypeMasterAndRuleBA.DeleteCRMSaleAccountProgressTypeRule(item);
        }

        public IBaseEntityCollectionResponse<CRMSaleAccountProgressTypeMasterAndRule> GetBySearchCRMSaleAccountProgressTypeRule(CRMSaleAccountProgressTypeMasterAndRuleSearchRequest searchRequest)
        {
            return _CRMSaleAccountProgressTypeMasterAndRuleBA.GetBySearchCRMSaleAccountProgressTypeRule(searchRequest);
        }

        public IBaseEntityCollectionResponse<CRMSaleAccountProgressTypeMasterAndRule> GetCRMSaleAccountProgressTypeRuleSearchList(CRMSaleAccountProgressTypeMasterAndRuleSearchRequest searchRequest)
        {
            return _CRMSaleAccountProgressTypeMasterAndRuleBA.GetCRMSaleAccountProgressTypeRuleSearchList(searchRequest);
        }

        public IBaseEntityResponse<CRMSaleAccountProgressTypeMasterAndRule> SelectByCRMSaleAccountProgressTypeRuleID(CRMSaleAccountProgressTypeMasterAndRule item)
        {
            return _CRMSaleAccountProgressTypeMasterAndRuleBA.SelectByCRMSaleAccountProgressTypeRuleID(item);
        }

        //CRMSaleAccountProgressTypeMaster
        public IBaseEntityCollectionResponse<CRMSaleAccountProgressTypeMasterAndRule> GetCRMSaleAccountProgressTypeMasterSearchList(CRMSaleAccountProgressTypeMasterAndRuleSearchRequest searchRequest)
        {
            return _CRMSaleAccountProgressTypeMasterAndRuleBA.GetCRMSaleAccountProgressTypeMasterSearchList(searchRequest);
        }
    }
}

