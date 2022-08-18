using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface ICRMSaleEnquiryMasterAndAccountDetailsServiceAccess
    {
        //CRMSaleEnquiryMaster		
        IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> InsertCRMSaleEnquiryMaster(CRMSaleEnquiryMasterAndAccountDetails item);
        IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> UpdateCRMSaleEnquiryMaster(CRMSaleEnquiryMasterAndAccountDetails item);
        IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> DeleteCRMSaleEnquiryMaster(CRMSaleEnquiryMasterAndAccountDetails item);
        IBaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails> GetBySearchCRMSaleEnquiryMaster(CRMSaleEnquiryMasterAndAccountDetailsSearchRequest searchRequest);
        IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> SelectByCRMSaleEnquiryMasterID(CRMSaleEnquiryMasterAndAccountDetails item);
        IBaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails> GetCRMSaleEnquiryMasterSearchList(CRMSaleEnquiryMasterAndAccountDetailsSearchRequest searchRequest);

        //CRMSaleEnquiryAccountMaster
        IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> InsertCRMSaleEnquiryAccountMaster(CRMSaleEnquiryMasterAndAccountDetails item);
        IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> UpdateCRMSaleEnquiryAccountMaster(CRMSaleEnquiryMasterAndAccountDetails item);
        IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> DeleteCRMSaleEnquiryAccountMaster(CRMSaleEnquiryMasterAndAccountDetails item);
        IBaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails> GetBySearchCRMSaleEnquiryAccountMaster(CRMSaleEnquiryMasterAndAccountDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails> GetBySearchCRMSaleEnquiryAllAccountMaster(CRMSaleEnquiryMasterAndAccountDetailsSearchRequest searchRequest);
        IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> SelectByCRMSaleEnquiryAccountMasterID(CRMSaleEnquiryMasterAndAccountDetails item);
        IBaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails> GetCRMSaleEnquiryAccountMasterSearchList(CRMSaleEnquiryMasterAndAccountDetailsSearchRequest searchRequest);

        //CRMSaleEnquiryAccountContactPerson
        IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> InsertCRMSaleEnquiryAccountContactPerson(CRMSaleEnquiryMasterAndAccountDetails item);
        IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> UpdateCRMSaleEnquiryAccountContactPerson(CRMSaleEnquiryMasterAndAccountDetails item);
        IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> DeleteCRMSaleEnquiryAccountContactPerson(CRMSaleEnquiryMasterAndAccountDetails item);
        IBaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails> GetBySearchCRMSaleEnquiryAccountContactPerson(CRMSaleEnquiryMasterAndAccountDetailsSearchRequest searchRequest);
        IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> SelectByCRMSaleEnquiryAccountContactPersonID(CRMSaleEnquiryMasterAndAccountDetails item);
        IBaseEntityCollectionResponse<CRMSaleEnquiryMasterAndAccountDetails> GetCRMSaleEnquiryAccountContactPersonSearchList(CRMSaleEnquiryMasterAndAccountDetailsSearchRequest searchRequest);
        IBaseEntityResponse<CRMSaleEnquiryMasterAndAccountDetails> InsertCRMSaleEnquiryAccountTransferRequest(CRMSaleEnquiryMasterAndAccountDetails item);
    }
}
