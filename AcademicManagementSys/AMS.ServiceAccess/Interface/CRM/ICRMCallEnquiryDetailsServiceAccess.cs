using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface ICRMCallEnquiryDetailsServiceAccess
    {
        IBaseEntityResponse<CRMCallEnquiryDetails> InsertCRMCallEnquiryDetails(CRMCallEnquiryDetails item);
        IBaseEntityResponse<CRMCallEnquiryDetails> UpdateCRMCallEnquiryDetails(CRMCallEnquiryDetails item);
        IBaseEntityResponse<CRMCallEnquiryDetails> DeleteCRMCallEnquiryDetails(CRMCallEnquiryDetails item);
        IBaseEntityCollectionResponse<CRMCallEnquiryDetails> GetBySearch(CRMCallEnquiryDetailsSearchRequest searchRequest);
        IBaseEntityResponse<CRMCallEnquiryDetails> SelectByID(CRMCallEnquiryDetails item);
        IBaseEntityCollectionResponse<CRMCallEnquiryDetails> GetCRMCallEnquiryDetailsList(CRMCallEnquiryDetailsSearchRequest searchRequest);
        IBaseEntityResponse<CRMCallEnquiryDetails> SelectPendingCallEnquiryCount(CRMCallEnquiryDetails item);
        //For Call Forward
        IBaseEntityCollectionResponse<CRMCallEnquiryDetails> GetBySearchCallForward(CRMCallEnquiryDetailsSearchRequest searchRequest);
        IBaseEntityResponse<CRMCallEnquiryDetails> InsertCRMCallEnquiryDetailsCallForward(CRMCallEnquiryDetails item);
        
    }
}
