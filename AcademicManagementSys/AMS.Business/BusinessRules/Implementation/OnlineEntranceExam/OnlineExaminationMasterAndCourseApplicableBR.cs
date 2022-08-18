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
    public class OnlineExaminationMasterAndCourseApplicableBR : IOnlineExaminationMasterAndCourseApplicableBR
    {
        public OnlineExaminationMasterAndCourseApplicableBR()
        {
        }

        /// Validate method to insert record from OnlineEntranceExamQuestionBankMaster.
        public IValidateBusinessRuleResponse InsertOnlineExaminationMasterAndCourseApplicableValidate(OnlineExaminationMasterAndCourseApplicable item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateInsertOnlineExaminationMasterAndCourseApplicable(item))
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


        /// Validate method to update record from OnlineExaminationMasterAndCourseApplicable.
        public IValidateBusinessRuleResponse UpdateOnlineExaminationMasterAndCourseApplicableValidate(OnlineExaminationMasterAndCourseApplicable item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateUpdateOnlineExaminationMasterAndCourseApplicable(item))
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
        public IValidateBusinessRuleResponse DeleteOnlineExaminationMasterAndCourseApplicableValidate(OnlineExaminationMasterAndCourseApplicable item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateDeleteOnlineExaminationMasterAndCourseApplicable(item))
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

        /// Validation on insert OnlineExaminationMasterAndCourseApplicable.
        private bool ValidateInsertOnlineExaminationMasterAndCourseApplicable(OnlineExaminationMasterAndCourseApplicable request)
        {
            //We need to Implment this validation method properly
            return true;
        }

        /// Validation on insert OnlineEntranceExamQuestionBankMaster.
        private bool ValidateUpdateOnlineExaminationMasterAndCourseApplicable(OnlineExaminationMasterAndCourseApplicable request)
        {
            //We need to Implment this validation method properly
            return true;
        }       
        /// Validation on delete OnlineEntranceExamQuestionBankMaster.
        private bool ValidateDeleteOnlineExaminationMasterAndCourseApplicable(OnlineExaminationMasterAndCourseApplicable request)
        {
            try
            {
                return (!string.IsNullOrEmpty(Convert.ToString(request.OnlineExamExaminationMasterID)));
            }
            catch (Exception)
            {
                return true;
            }
        }
    }
}
