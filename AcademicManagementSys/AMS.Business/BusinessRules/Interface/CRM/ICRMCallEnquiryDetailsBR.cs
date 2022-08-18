using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface ICRMCallEnquiryDetailsBR
    {
        IValidateBusinessRuleResponse InsertCRMCallEnquiryDetailsValidate(CRMCallEnquiryDetails item);
        IValidateBusinessRuleResponse UpdateCRMCallEnquiryDetailsValidate(CRMCallEnquiryDetails item);
        IValidateBusinessRuleResponse DeleteCRMCallEnquiryDetailsValidate(CRMCallEnquiryDetails item);
        IValidateBusinessRuleResponse InsertCRMCallEnquiryDetailsCallForward(CRMCallEnquiryDetails item);
    }
}
