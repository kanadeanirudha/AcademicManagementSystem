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
    public class OnlineEntranceExamQuestionBankMasterBR : IOnlineEntranceExamQuestionBankMasterBR
    {
        public OnlineEntranceExamQuestionBankMasterBR()
        {
        }
        
        /// Validate method to insert record from OnlineEntranceExamQuestionBankMaster.
        public IValidateBusinessRuleResponse InsertSubjectOnlineExamQuestionBankValidate(OnlineEntranceExamQuestionBankMaster item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateInsertSubjectOnlineExamQuestionBank(item))
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

        /// Validate method to insert record from OnlineEntranceExamQuestionBankMaster.
        public IValidateBusinessRuleResponse InsertOnlineEntranceExamQuestionBankMasterValidate(OnlineEntranceExamQuestionBankMaster item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateInsertOnlineEntranceExamQuestionBankMaster(item))
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

        /// Validate method to update record from OnlineEntranceExamQuestionBankMaster.
        public IValidateBusinessRuleResponse UpdateOnlineEntranceExamQuestionBankMasterValidate(OnlineEntranceExamQuestionBankMaster item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateUpdateOnlineEntranceExamQuestionBankMaster(item))
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

        /// Validate method to delete record from OnlineEntranceExamQuestionBankMaster.
        public IValidateBusinessRuleResponse DeleteOnlineEntranceExamQuestionBankMasterValidate(OnlineEntranceExamQuestionBankMaster item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateDeleteOnlineEntranceExamQuestionBankMaster(item))
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

        /// Validation on insert OnlineEntranceExamQuestionBankMaster.
        private bool ValidateInsertSubjectOnlineExamQuestionBank(OnlineEntranceExamQuestionBankMaster request)
        {
            //We need to Implment this validation method properly
            return true;
        }

        /// Validation on insert OnlineEntranceExamQuestionBankMaster.
        private bool ValidateInsertOnlineEntranceExamQuestionBankMaster(OnlineEntranceExamQuestionBankMaster request)
        {
            //We need to Implment this validation method properly
            return true;
        }
        /// Validation on update OnlineEntranceExamQuestionBankMaster.
        private bool ValidateUpdateOnlineEntranceExamQuestionBankMaster(OnlineEntranceExamQuestionBankMaster request)
        {
            //We need to Implment this validation method properly
            return true;
        }

        /// Validation on delete OnlineEntranceExamQuestionBankMaster.
        private bool ValidateDeleteOnlineEntranceExamQuestionBankMaster(OnlineEntranceExamQuestionBankMaster request)
        {
            try
            {
                return (!string.IsNullOrEmpty(Convert.ToString(request.OnlineExamQuestionBankMasterID)));
            }
            catch (Exception)
            {
                return true;
            }
        }
    }
}
