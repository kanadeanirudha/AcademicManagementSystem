using System;
using System.Collections.Generic;
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
    public class EntranceExamValidationParameterBR : IEntranceExamValidationParameterBR
    {
        public EntranceExamValidationParameterBR()
        {
        }
        /// <summary>
        /// Validate method to insert record from EntranceExamValidationParameter.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IValidateBusinessRuleResponse InsertEntranceExamValidationParameterValidate(EntranceExamValidationParameter item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateInsertEntranceExamValidationParameter(item))
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
        /// <summary>
        /// Validate method to update record from EntranceExamValidationParameter.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IValidateBusinessRuleResponse UpdateEntranceExamValidationParameterValidate(EntranceExamValidationParameter item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateUpdateEntranceExamValidationParameter(item))
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
        /// <summary>
        /// Validate method to delete record from EntranceExamValidationParameter.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IValidateBusinessRuleResponse DeleteEntranceExamValidationParameterValidate(EntranceExamValidationParameter item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateDeleteEntranceExamValidationParameter(item))
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
        /// <summary>
        /// Validation on insert EntranceExamValidationParameterproperty.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool ValidateInsertEntranceExamValidationParameter(EntranceExamValidationParameter request)
        {
            //We need to Implment this validation method properly
            return true;
        }
        /// <summary>
        /// Validation on update EntranceExamValidationParameterproperty.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool ValidateUpdateEntranceExamValidationParameter(EntranceExamValidationParameter request)
        {
            //We need to Implment this validation method properly
            return true;
        }
        /// <summary>
        /// Validation on delete EntranceExamValidationParameterproperty.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool ValidateDeleteEntranceExamValidationParameter(EntranceExamValidationParameter request)
        {
            try
            {
                return (!string.IsNullOrEmpty(Convert.ToString(request.ID)));
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
