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
    public class EntranceExamPaymentDetailsBR :IEntranceExamPaymentDetailsBR
    {
        public EntranceExamPaymentDetailsBR()
        {   
        }

        // EntranceExamPaymentDetails Method
        #region EntranceExamPaymentDetails

        /// Validate method to insert record from EntranceExamPaymentDetails.        
        public IValidateBusinessRuleResponse InsertEntranceExamPaymentDetailsValidate(EntranceExamPaymentDetails item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateInsertEntranceExamPaymentDetails(item))
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

        /// Validate method to update record from EntranceExamPaymentDetails.        
        public IValidateBusinessRuleResponse UpdateEntranceExamPaymentDetailsValidate(EntranceExamPaymentDetails item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateUpdateEntranceExamPaymentDetails(item))
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

        /// Validate method to delete record from EntranceExamPaymentDetails.       
        public IValidateBusinessRuleResponse DeleteEntranceExamPaymentDetailsValidate(EntranceExamPaymentDetails item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateDeleteEntranceExamPaymentDetails(item))
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

        /// Validation on insert EntranceExamPaymentDetails.        
        private bool ValidateInsertEntranceExamPaymentDetails(EntranceExamPaymentDetails request)
        {
            return true;
        }

        /// Validation on update EntranceExamPaymentDetails.        
        private bool ValidateUpdateEntranceExamPaymentDetails(EntranceExamPaymentDetails request)
        {
            return (request.ID > 0);
        }

        /// Validation on delete EntranceExamPaymentDetails.        
        private bool ValidateDeleteEntranceExamPaymentDetails(EntranceExamPaymentDetails request)
        {
            try
            {
                return (request.ID > 0);
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion

    }
}
