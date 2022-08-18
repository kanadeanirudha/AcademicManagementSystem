using AMS.Base.DTO;
using AMS.Common;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    class CRMSaleAccountProgressTypeMasterAndRuleBR : ICRMSaleAccountProgressTypeMasterAndRuleBR
    {
        public CRMSaleAccountProgressTypeMasterAndRuleBR()
        {
        }

        //CRMSaleAccountProgressTypeRule
        public IValidateBusinessRuleResponse InsertCRMSaleAccountProgressTypeRuleValidate(CRMSaleAccountProgressTypeMasterAndRule item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateInsertCRMSaleAccountProgressTypeRule(item))
                {
                    businessResponse.Passed = true;
                    businessResponse.Message.Add(new MessageDTO
                    {
                        MessageType = MessageTypeEnum.Error,
                        ErrorMessage = "pass error message"
                    });
                }
                else
                {
                    businessResponse.Passed = true;
                }
            }
            catch (Exception ex)
            {
                businessResponse.Message.Add(new MessageDTO
                {
                    MessageType = MessageTypeEnum.Error,
                    ErrorMessage = ex.Message
                });
            }
            return businessResponse;
        }
        public IValidateBusinessRuleResponse UpdateCRMSaleAccountProgressTypeRuleValidate(CRMSaleAccountProgressTypeMasterAndRule item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateUpdateCRMSaleAccountProgressTypeRule(item))
                {
                    businessResponse.Passed = true;
                    businessResponse.Message.Add(new MessageDTO
                    {
                        MessageType = MessageTypeEnum.Error,
                        ErrorMessage = "pass error message"
                    });
                }
                else
                {
                    businessResponse.Passed = true;
                }
            }
            catch (Exception ex)
            {
                businessResponse.Message.Add(new MessageDTO
                {
                    MessageType = MessageTypeEnum.Error,
                    ErrorMessage = ex.Message
                });
            }
            return businessResponse;
        }
        public IValidateBusinessRuleResponse DeleteCRMSaleAccountProgressTypeRuleValidate(CRMSaleAccountProgressTypeMasterAndRule item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateDeleteCRMSaleAccountProgressTypeRule(item))
                {
                    businessResponse.Passed = false;
                    businessResponse.Message.Add(new MessageDTO
                    {
                        MessageType = MessageTypeEnum.Error,
                        ErrorMessage = "pass error message"
                    });
                }
                else
                {
                    businessResponse.Passed = true;
                }
            }
            catch (Exception ex)
            {
                businessResponse.Message.Add(new MessageDTO
                {
                    MessageType = MessageTypeEnum.Error,
                    ErrorMessage = ex.Message
                });
            }
            return businessResponse;
        }
        private bool ValidateInsertCRMSaleAccountProgressTypeRule(CRMSaleAccountProgressTypeMasterAndRule request)
        {
            //We need to Implment this validation method properly
            return true;
        }
        private bool ValidateUpdateCRMSaleAccountProgressTypeRule(CRMSaleAccountProgressTypeMasterAndRule request)
        {
            //We need to Implment this validation method properly
            return true;
        }
        private bool ValidateDeleteCRMSaleAccountProgressTypeRule(CRMSaleAccountProgressTypeMasterAndRule request)
        {
            try
            {
                return (!string.IsNullOrEmpty(Convert.ToString(request.CRMSaleAccountProgressTypeRuleID)));
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
