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
    public class EntranceExamScheduleAndScheduleDetailBR : IEntranceExamScheduleAndScheduleDetailBR
    {
        public EntranceExamScheduleAndScheduleDetailBR()
		{
		}

        // EntranceExamSchedule Method
        #region EntranceExamSchedule

        /// Validate method to insert record from EntranceExamSchedule.        
        public IValidateBusinessRuleResponse InsertEntranceExamScheduleValidate(EntranceExamScheduleAndScheduleDetail item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateInsertEntranceExamSchedule(item))
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
        
        /// Validate method to update record from EntranceExamSchedule.        
        public IValidateBusinessRuleResponse UpdateEntranceExamScheduleValidate(EntranceExamScheduleAndScheduleDetail item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateUpdateEntranceExamSchedule(item))
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
        
        /// Validate method to delete record from EntranceExamSchedule.        
        public IValidateBusinessRuleResponse DeleteEntranceExamScheduleValidate(EntranceExamScheduleAndScheduleDetail item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateDeleteEntranceExamSchedule(item))
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
        
        /// Validation on insert EntranceExamScheduleproperty.        
        private bool ValidateInsertEntranceExamSchedule(EntranceExamScheduleAndScheduleDetail request)
        {
            //We need to Implment this validation method properly
            return true;
        }
        
        /// Validation on update EntranceExamScheduleproperty.        
        private bool ValidateUpdateEntranceExamSchedule(EntranceExamScheduleAndScheduleDetail request)
        {
            //We need to Implment this validation method properly
            return (request.EntranceExamScheduleID > 0);
        }
        
        /// Validation on delete EntranceExamScheduleproperty.        
        private bool ValidateDeleteEntranceExamSchedule(EntranceExamScheduleAndScheduleDetail request)
        {
            try
            {
                return (!string.IsNullOrEmpty(Convert.ToString(request.EntranceExamScheduleID)));
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        #endregion

        // EntranceExamScheduleDetail Method
        #region EntranceExamScheduleDetail

        /// Validate method to insert record from EntranceExamScheduleDetail.        
        public IValidateBusinessRuleResponse InsertEntranceExamScheduleDetailValidate(EntranceExamScheduleAndScheduleDetail item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateInsertEntranceExamScheduleDetail(item))
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

        /// Validate method to update record from EntranceExamScheduleDetail.        
        public IValidateBusinessRuleResponse UpdateEntranceExamScheduleDetailValidate(EntranceExamScheduleAndScheduleDetail item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateUpdateEntranceExamScheduleDetail(item))
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

        /// Validate method to delete record from EntranceExamScheduleDetail.        
        public IValidateBusinessRuleResponse DeleteEntranceExamScheduleDetailValidate(EntranceExamScheduleAndScheduleDetail item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateDeleteEntranceExamScheduleDetail(item))
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

        /// Validation on insert EntranceExamScheduleDetailproperty.        
        private bool ValidateInsertEntranceExamScheduleDetail(EntranceExamScheduleAndScheduleDetail request)
        {
            //We need to Implment this validation method properly
            return true;
        }

        /// Validation on update EntranceExamScheduleproperty.        
        private bool ValidateUpdateEntranceExamScheduleDetail(EntranceExamScheduleAndScheduleDetail request)
        {
            //We need to Implment this validation method properly
            return (request.EntranceExamScheduleDetailID > 0);
        }

        /// Validation on delete EntranceExamScheduleproperty.        
        private bool ValidateDeleteEntranceExamScheduleDetail(EntranceExamScheduleAndScheduleDetail request)
        {
            try
            {
                return (!string.IsNullOrEmpty(Convert.ToString(request.EntranceExamScheduleDetailID)));
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion

    }
}
