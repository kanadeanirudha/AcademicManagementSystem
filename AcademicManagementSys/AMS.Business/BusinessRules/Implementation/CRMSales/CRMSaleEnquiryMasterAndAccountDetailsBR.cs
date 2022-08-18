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
    class CRMSaleEnquiryMasterAndAccountDetailsBR : ICRMSaleEnquiryMasterAndAccountDetailsBR
    {
        public CRMSaleEnquiryMasterAndAccountDetailsBR()
        {
        }

        //CRMSaleEnquiryMaster
        public IValidateBusinessRuleResponse InsertCRMSaleEnquiryMasterValidate(CRMSaleEnquiryMasterAndAccountDetails item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateInsertCRMSaleEnquiryMaster(item))
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
        public IValidateBusinessRuleResponse UpdateCRMSaleEnquiryMasterValidate(CRMSaleEnquiryMasterAndAccountDetails item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateUpdateCRMSaleEnquiryMaster(item))
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
        public IValidateBusinessRuleResponse DeleteCRMSaleEnquiryMasterValidate(CRMSaleEnquiryMasterAndAccountDetails item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateDeleteCRMSaleEnquiryMaster(item))
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
        private bool ValidateInsertCRMSaleEnquiryMaster(CRMSaleEnquiryMasterAndAccountDetails request)
        {
            //We need to Implment this validation method properly
            return true;
        }
        private bool ValidateUpdateCRMSaleEnquiryMaster(CRMSaleEnquiryMasterAndAccountDetails request)
        {
            //We need to Implment this validation method properly
            return true;
        }
        private bool ValidateDeleteCRMSaleEnquiryMaster(CRMSaleEnquiryMasterAndAccountDetails request)
        {
            try
            {
                return (!string.IsNullOrEmpty(Convert.ToString(request.CRMSaleEnquiryMasterID)));
            }
            catch (Exception)
            {
                return false;
            }
        }

        //CRMSaleEnquiryAccountMaster

        public IValidateBusinessRuleResponse InsertCRMSaleEnquiryAccountMasterValidate(CRMSaleEnquiryMasterAndAccountDetails item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateInsertCRMSaleEnquiryAccountMaster(item))
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
        public IValidateBusinessRuleResponse UpdateCRMSaleEnquiryAccountMasterValidate(CRMSaleEnquiryMasterAndAccountDetails item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateUpdateCRMSaleEnquiryAccountMaster(item))
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
        public IValidateBusinessRuleResponse DeleteCRMSaleEnquiryAccountMasterValidate(CRMSaleEnquiryMasterAndAccountDetails item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateDeleteCRMSaleEnquiryAccountMaster(item))
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
        private bool ValidateInsertCRMSaleEnquiryAccountMaster(CRMSaleEnquiryMasterAndAccountDetails request)
        {
            //We need to Implment this validation method properly
            return true;
        }
        private bool ValidateUpdateCRMSaleEnquiryAccountMaster(CRMSaleEnquiryMasterAndAccountDetails request)
        {
            //We need to Implment this validation method properly
            return true;
        }
        private bool ValidateDeleteCRMSaleEnquiryAccountMaster(CRMSaleEnquiryMasterAndAccountDetails request)
        {
            try
            {
                return (!string.IsNullOrEmpty(Convert.ToString(request.CRMSaleEnquiryMasterID)));
            }
            catch (Exception)
            {
                return false;
            }
        }

        //CRMSaleEnquiryAccountContactPerson

        public IValidateBusinessRuleResponse InsertCRMSaleEnquiryAccountContactPersonValidate(CRMSaleEnquiryMasterAndAccountDetails item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateInsertCRMSaleEnquiryAccountContactPerson(item))
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
        public IValidateBusinessRuleResponse UpdateCRMSaleEnquiryAccountContactPersonValidate(CRMSaleEnquiryMasterAndAccountDetails item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateUpdateCRMSaleEnquiryAccountContactPerson(item))
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
        public IValidateBusinessRuleResponse DeleteCRMSaleEnquiryAccountContactPersonValidate(CRMSaleEnquiryMasterAndAccountDetails item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateDeleteCRMSaleEnquiryAccountContactPerson(item))
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
        private bool ValidateInsertCRMSaleEnquiryAccountContactPerson(CRMSaleEnquiryMasterAndAccountDetails request)
        {
            //We need to Implment this validation method properly
            return true;
        }
        private bool ValidateUpdateCRMSaleEnquiryAccountContactPerson(CRMSaleEnquiryMasterAndAccountDetails request)
        {
            //We need to Implment this validation method properly
            return true;
        }
        private bool ValidateDeleteCRMSaleEnquiryAccountContactPerson(CRMSaleEnquiryMasterAndAccountDetails request)
        {
            try
            {
                return (!string.IsNullOrEmpty(Convert.ToString(request.CRMSaleEnquiryMasterID)));
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
