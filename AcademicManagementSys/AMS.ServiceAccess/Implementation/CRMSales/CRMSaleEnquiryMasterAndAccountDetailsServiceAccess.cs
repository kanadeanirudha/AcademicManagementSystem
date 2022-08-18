using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business;
using AMS.Business.BusinessActions;
namespace AMS.ServiceAccess
{
    public class CRMSaleEnquiryMasterAndAccountDetailsServiceAccess : ICRMSaleEnquiryMasterAndAccountDetailsServiceAccess
    {
        ICRMSaleEnquiryMasterAndAccountDetailsBA _CRMSaleEnquiryMasterAndAccountDetailsBA = null;

        public CRMSaleEnquiryMasterAndAccountDetailsServiceAccess()
        {
            _CRMSaleEnquiryMasterAndAccountDetailsBA = new CRMSaleEnquiryMasterAndAccountDetailsBA();
        }

        //CRMSaleEnquiryMaster
        public IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> InsertCRMSaleEnquiryMaster(CRMSaleEnquiryMasterAndAccountDetails item)
        {
            return _CRMSaleEnquiryMasterAndAccountDetailsBA.InsertCRMSaleEnquiryMaster(item);
        }

        public IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> UpdateCRMSaleEnquiryMaster(CRMSaleEnquiryMasterAndAccountDetails item)
        {
            return _CRMSaleEnquiryMasterAndAccountDetailsBA.UpdateCRMSaleEnquiryMaster(item);
        }

        public IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> DeleteCRMSaleEnquiryMaster(CRMSaleEnquiryMasterAndAccountDetails item)
        {
            return _CRMSaleEnquiryMasterAndAccountDetailsBA.DeleteCRMSaleEnquiryMaster(item);
        }

        public IBaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails> GetBySearchCRMSaleEnquiryMaster(CRMSaleEnquiryMasterAndAccountDetailsSearchRequest searchRequest)
        {
            return _CRMSaleEnquiryMasterAndAccountDetailsBA.GetBySearchCRMSaleEnquiryMaster(searchRequest);
        }

        public IBaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails> GetCRMSaleEnquiryMasterSearchList(CRMSaleEnquiryMasterAndAccountDetailsSearchRequest searchRequest)
        {
            return _CRMSaleEnquiryMasterAndAccountDetailsBA.GetCRMSaleEnquiryMasterSearchList(searchRequest);
        }

        public IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> SelectByCRMSaleEnquiryMasterID(CRMSaleEnquiryMasterAndAccountDetails item)
        {
            return _CRMSaleEnquiryMasterAndAccountDetailsBA.SelectByCRMSaleEnquiryMasterID(item);
        }

        //CRMSaleEnquiryAccountMaster

        public IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> InsertCRMSaleEnquiryAccountMaster(CRMSaleEnquiryMasterAndAccountDetails item)
        {
            return _CRMSaleEnquiryMasterAndAccountDetailsBA.InsertCRMSaleEnquiryAccountMaster(item);
        }

        public IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> UpdateCRMSaleEnquiryAccountMaster(CRMSaleEnquiryMasterAndAccountDetails item)
        {
            return _CRMSaleEnquiryMasterAndAccountDetailsBA.UpdateCRMSaleEnquiryAccountMaster(item);
        }

        public IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> DeleteCRMSaleEnquiryAccountMaster(CRMSaleEnquiryMasterAndAccountDetails item)
        {
            return _CRMSaleEnquiryMasterAndAccountDetailsBA.DeleteCRMSaleEnquiryAccountMaster(item);
        }
        public IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> InsertCRMSaleEnquiryAccountTransferRequest(CRMSaleEnquiryMasterAndAccountDetails item)
        {
            return _CRMSaleEnquiryMasterAndAccountDetailsBA.InsertCRMSaleEnquiryAccountTransferRequest(item);
        }
        public IBaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails> GetBySearchCRMSaleEnquiryAccountMaster(CRMSaleEnquiryMasterAndAccountDetailsSearchRequest searchRequest)
        {
            return _CRMSaleEnquiryMasterAndAccountDetailsBA.GetBySearchCRMSaleEnquiryAccountMaster(searchRequest);
        }

        public IBaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails> GetBySearchCRMSaleEnquiryAllAccountMaster(CRMSaleEnquiryMasterAndAccountDetailsSearchRequest searchRequest)
        {
            return _CRMSaleEnquiryMasterAndAccountDetailsBA.GetBySearchCRMSaleEnquiryAllAccountMaster(searchRequest);
        }

        public IBaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails> GetCRMSaleEnquiryAccountMasterSearchList(CRMSaleEnquiryMasterAndAccountDetailsSearchRequest searchRequest)
        {
            return _CRMSaleEnquiryMasterAndAccountDetailsBA.GetCRMSaleEnquiryAccountMasterSearchList(searchRequest);
        }

        public IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> SelectByCRMSaleEnquiryAccountMasterID(CRMSaleEnquiryMasterAndAccountDetails item)
        {
            return _CRMSaleEnquiryMasterAndAccountDetailsBA.SelectByCRMSaleEnquiryAccountMasterID(item);
        }
       
        //CRMSaleEnquiryAccountContactPerson

        public IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> InsertCRMSaleEnquiryAccountContactPerson(CRMSaleEnquiryMasterAndAccountDetails item)
        {
            return _CRMSaleEnquiryMasterAndAccountDetailsBA.InsertCRMSaleEnquiryAccountContactPerson(item);
        }

        public IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> UpdateCRMSaleEnquiryAccountContactPerson(CRMSaleEnquiryMasterAndAccountDetails item)
        {
            return _CRMSaleEnquiryMasterAndAccountDetailsBA.UpdateCRMSaleEnquiryAccountContactPerson(item);
        }

        public IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> DeleteCRMSaleEnquiryAccountContactPerson(CRMSaleEnquiryMasterAndAccountDetails item)
        {
            return _CRMSaleEnquiryMasterAndAccountDetailsBA.DeleteCRMSaleEnquiryAccountContactPerson(item);
        }

        public IBaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails> GetBySearchCRMSaleEnquiryAccountContactPerson(CRMSaleEnquiryMasterAndAccountDetailsSearchRequest searchRequest)
        {
            return _CRMSaleEnquiryMasterAndAccountDetailsBA.GetBySearchCRMSaleEnquiryAccountContactPerson(searchRequest);
        }

        public IBaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails> GetCRMSaleEnquiryAccountContactPersonSearchList(CRMSaleEnquiryMasterAndAccountDetailsSearchRequest searchRequest)
        {
            return _CRMSaleEnquiryMasterAndAccountDetailsBA.GetCRMSaleEnquiryAccountContactPersonSearchList(searchRequest);
        }

        public IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> SelectByCRMSaleEnquiryAccountContactPersonID(CRMSaleEnquiryMasterAndAccountDetails item)
        {
            return _CRMSaleEnquiryMasterAndAccountDetailsBA.SelectByCRMSaleEnquiryAccountContactPersonID(item);
        }
   
    }
}

