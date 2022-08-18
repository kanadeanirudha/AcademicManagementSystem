using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface ICRMSaleAccountProgressTypeMasterAndRuleBA
    {

        //CRMSaleAccountProgressTypeRule
        IBaseEntityResponse<CRMSaleAccountProgressTypeMasterAndRule> InsertCRMSaleAccountProgressTypeRule(CRMSaleAccountProgressTypeMasterAndRule item);
        IBaseEntityResponse<CRMSaleAccountProgressTypeMasterAndRule> UpdateCRMSaleAccountProgressTypeRule(CRMSaleAccountProgressTypeMasterAndRule item);
        IBaseEntityResponse<CRMSaleAccountProgressTypeMasterAndRule> DeleteCRMSaleAccountProgressTypeRule(CRMSaleAccountProgressTypeMasterAndRule item);
        IBaseEntityCollectionResponse<CRMSaleAccountProgressTypeMasterAndRule> GetBySearchCRMSaleAccountProgressTypeRule(CRMSaleAccountProgressTypeMasterAndRuleSearchRequest searchRequest);
        IBaseEntityResponse<CRMSaleAccountProgressTypeMasterAndRule> SelectByCRMSaleAccountProgressTypeRuleID(CRMSaleAccountProgressTypeMasterAndRule item);
        IBaseEntityCollectionResponse<CRMSaleAccountProgressTypeMasterAndRule> GetCRMSaleAccountProgressTypeRuleSearchList(CRMSaleAccountProgressTypeMasterAndRuleSearchRequest searchRequest);
      
        //CRMSaleAccountProgressTypeMaster
        IBaseEntityCollectionResponse<CRMSaleAccountProgressTypeMasterAndRule> GetCRMSaleAccountProgressTypeMasterSearchList(CRMSaleAccountProgressTypeMasterAndRuleSearchRequest searchRequest);
    }
}
