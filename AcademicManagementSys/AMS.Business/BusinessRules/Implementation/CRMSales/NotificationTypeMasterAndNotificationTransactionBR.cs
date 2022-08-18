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
    class NotificationTypeMasterAndNotificationTransactionBR : INotificationTypeMasterAndNotificationTransactionBR
    {
        public NotificationTypeMasterAndNotificationTransactionBR()
        {
        }

        //NotificationTypeMaster
        public IValidateBusinessRuleResponse InsertNotificationTypeMasterValidate(NotificationTypeMasterAndNotificationTransaction item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateInsertNotificationTypeMaster(item))
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

        public IValidateBusinessRuleResponse UpdateNotificationTypeMasterValidate(NotificationTypeMasterAndNotificationTransaction item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateUpdateNotificationTypeMaster(item))
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

        public IValidateBusinessRuleResponse DeleteNotificationTypeMasterValidate(NotificationTypeMasterAndNotificationTransaction item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateDeleteNotificationTypeMaster(item))
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
        private bool ValidateInsertNotificationTypeMaster(NotificationTypeMasterAndNotificationTransaction request)
        {
            //We need to Implment this validation method properly
            return true;
        }
        private bool ValidateUpdateNotificationTypeMaster(NotificationTypeMasterAndNotificationTransaction request)
        {
            //We need to Implment this validation method properly
            return true;
        }
        private bool ValidateDeleteNotificationTypeMaster(NotificationTypeMasterAndNotificationTransaction request)
        {
            try
            {
                return (!string.IsNullOrEmpty(Convert.ToString(request.NotificationTypeMasterID)));
            }
            catch (Exception)
            {
                return false;
            }
        }

        //NotificationTransaction
        public IValidateBusinessRuleResponse InsertNotificationTransactionValidate(NotificationTypeMasterAndNotificationTransaction item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateInsertNotificationTransaction(item))
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

        public IValidateBusinessRuleResponse UpdateNotificationTransactionValidate(NotificationTypeMasterAndNotificationTransaction item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateUpdateNotificationTransaction(item))
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

        public IValidateBusinessRuleResponse DeleteNotificationTransactionValidate(NotificationTypeMasterAndNotificationTransaction item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateDeleteNotificationTransaction(item))
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
        private bool ValidateInsertNotificationTransaction(NotificationTypeMasterAndNotificationTransaction request)
        {
            //We need to Implment this validation method properly
            return true;
        }
        private bool ValidateUpdateNotificationTransaction(NotificationTypeMasterAndNotificationTransaction request)
        {
            //We need to Implment this validation method properly
            return true;
        }
        private bool ValidateDeleteNotificationTransaction(NotificationTypeMasterAndNotificationTransaction request)
        {
            try
            {
                return (!string.IsNullOrEmpty(Convert.ToString(request.NotificationTypeMasterID)));
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
