using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface ICRMCallEnquiryDetailsDataProvider
    {
        IBaseEntityResponse<CRMCallEnquiryDetails> InsertCRMCallEnquiryDetails(CRMCallEnquiryDetails item);
        IBaseEntityResponse<CRMCallEnquiryDetails> UpdateCRMCallEnquiryDetails(CRMCallEnquiryDetails item);
        IBaseEntityResponse<CRMCallEnquiryDetails> DeleteCRMCallEnquiryDetails(CRMCallEnquiryDetails item);
        IBaseEntityCollectionResponse<CRMCallEnquiryDetails> GetCRMCallEnquiryDetailsBySearch(CRMCallEnquiryDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CRMCallEnquiryDetails> GetCRMCallEnquiryDetailsList(CRMCallEnquiryDetailsSearchRequest searchRequest);
        IBaseEntityResponse<CRMCallEnquiryDetails> GetCRMCallEnquiryDetailsByID(CRMCallEnquiryDetails item);
        IBaseEntityCollectionResponse<CRMCallEnquiryDetails> GetBySearchCallForward(CRMCallEnquiryDetailsSearchRequest searchRequest);
        IBaseEntityResponse<CRMCallEnquiryDetails> InsertCRMCallEnquiryDetailsCallForward(CRMCallEnquiryDetails item);
        IBaseEntityResponse<CRMCallEnquiryDetails> SelectPendingCallEnquiryCount(CRMCallEnquiryDetails item);
     
        
    }
}
