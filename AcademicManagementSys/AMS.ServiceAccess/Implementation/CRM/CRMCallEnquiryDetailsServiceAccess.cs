using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class CRMCallEnquiryDetailsServiceAccess : ICRMCallEnquiryDetailsServiceAccess
    {
        ICRMCallEnquiryDetailsBA _CRMCallEnquiryDetailsBA = null;
        public CRMCallEnquiryDetailsServiceAccess()
        {
            _CRMCallEnquiryDetailsBA = new CRMCallEnquiryDetailsBA();
        }
        public IBaseEntityResponse<CRMCallEnquiryDetails> InsertCRMCallEnquiryDetails(CRMCallEnquiryDetails item)
        {
            return _CRMCallEnquiryDetailsBA.InsertCRMCallEnquiryDetails(item);
        }
        public IBaseEntityResponse<CRMCallEnquiryDetails> UpdateCRMCallEnquiryDetails(CRMCallEnquiryDetails item)
        {
            return _CRMCallEnquiryDetailsBA.UpdateCRMCallEnquiryDetails(item);
        }
        public IBaseEntityResponse<CRMCallEnquiryDetails> DeleteCRMCallEnquiryDetails(CRMCallEnquiryDetails item)
        {
            return _CRMCallEnquiryDetailsBA.DeleteCRMCallEnquiryDetails(item);
        }
        public IBaseEntityCollectionResponse<CRMCallEnquiryDetails> GetBySearch(CRMCallEnquiryDetailsSearchRequest searchRequest)
        {
            return _CRMCallEnquiryDetailsBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<CRMCallEnquiryDetails> GetCRMCallEnquiryDetailsList(CRMCallEnquiryDetailsSearchRequest searchRequest)
        {
            return _CRMCallEnquiryDetailsBA.GetCRMCallEnquiryDetailsList(searchRequest);
        }
        public IBaseEntityResponse<CRMCallEnquiryDetails> SelectByID(CRMCallEnquiryDetails item)
        {
            return _CRMCallEnquiryDetailsBA.SelectByID(item);
        }
        //For Call Forward
        public IBaseEntityCollectionResponse<CRMCallEnquiryDetails> GetBySearchCallForward(CRMCallEnquiryDetailsSearchRequest searchRequest)
        {
            return _CRMCallEnquiryDetailsBA.GetBySearchCallForward(searchRequest);
        }
        public IBaseEntityResponse<CRMCallEnquiryDetails> InsertCRMCallEnquiryDetailsCallForward(CRMCallEnquiryDetails item)
        {
            return _CRMCallEnquiryDetailsBA.InsertCRMCallEnquiryDetailsCallForward(item);
        }
        //End of layer Call Forward
        public IBaseEntityResponse<CRMCallEnquiryDetails> SelectPendingCallEnquiryCount(CRMCallEnquiryDetails item)
        {
            return _CRMCallEnquiryDetailsBA.SelectPendingCallEnquiryCount(item);
        }
        
    }
}
