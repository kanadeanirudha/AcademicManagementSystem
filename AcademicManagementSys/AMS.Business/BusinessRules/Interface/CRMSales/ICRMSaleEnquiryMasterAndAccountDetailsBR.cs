using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface ICRMSaleEnquiryMasterAndAccountDetailsBR
    {
        //CRMSaleEnquiryMaster
        IValidateBusinessRuleResponse InsertCRMSaleEnquiryMasterValidate(CRMSaleEnquiryMasterAndAccountDetails item);

        IValidateBusinessRuleResponse UpdateCRMSaleEnquiryMasterValidate(CRMSaleEnquiryMasterAndAccountDetails item);

        IValidateBusinessRuleResponse DeleteCRMSaleEnquiryMasterValidate(CRMSaleEnquiryMasterAndAccountDetails item);

        //CRMSaleEnquiryAccountMaster

        IValidateBusinessRuleResponse InsertCRMSaleEnquiryAccountMasterValidate(CRMSaleEnquiryMasterAndAccountDetails item);

        IValidateBusinessRuleResponse UpdateCRMSaleEnquiryAccountMasterValidate(CRMSaleEnquiryMasterAndAccountDetails item);

        IValidateBusinessRuleResponse DeleteCRMSaleEnquiryAccountMasterValidate(CRMSaleEnquiryMasterAndAccountDetails item);

        //CRMSaleEnquiryAccountContactPerson

        IValidateBusinessRuleResponse InsertCRMSaleEnquiryAccountContactPersonValidate(CRMSaleEnquiryMasterAndAccountDetails item);

        IValidateBusinessRuleResponse UpdateCRMSaleEnquiryAccountContactPersonValidate(CRMSaleEnquiryMasterAndAccountDetails item);

        IValidateBusinessRuleResponse DeleteCRMSaleEnquiryAccountContactPersonValidate(CRMSaleEnquiryMasterAndAccountDetails item);
    }
}
