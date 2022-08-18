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
    public class StudentChangeCourseRequestApplicationBR : IStudentChangeCourseRequestApplicationBR
    {
        public StudentChangeCourseRequestApplicationBR()
        {
        }
        /// <summary>
        /// Validate method to insert record from StudentChangeCourseRequestApplication.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IValidateBusinessRuleResponse InsertStudentChangeCourseRequestApplicationValidate(StudentChangeCourseRequestApplication item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateInsertStudentChangeCourseRequestApplication(item))
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
        /// <summary>
        /// Validate method to update record from StudentChangeCourseRequestApplication.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IValidateBusinessRuleResponse UpdateStudentChangeCourseRequestApplicationValidate(StudentChangeCourseRequestApplication item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateUpdateStudentChangeCourseRequestApplication(item))
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
        /// <summary>
        /// Validate method to delete record from StudentChangeCourseRequestApplication.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IValidateBusinessRuleResponse DeleteStudentChangeCourseRequestApplicationValidate(StudentChangeCourseRequestApplication item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateDeleteStudentChangeCourseRequestApplication(item))
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
        /// Validation on insert StudentChangeCourseRequestApplicationproperty.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool ValidateInsertStudentChangeCourseRequestApplication(StudentChangeCourseRequestApplication request)
        {
            //We need to Implment this validation method properly
            return false;
        }
        /// <summary>
        /// Validation on update StudentChangeCourseRequestApplicationproperty.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool ValidateUpdateStudentChangeCourseRequestApplication(StudentChangeCourseRequestApplication request)
        {
            //We need to Implment this validation method properly
            return false;
        }
        /// <summary>
        /// Validation on delete StudentChangeCourseRequestApplicationproperty.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool ValidateDeleteStudentChangeCourseRequestApplication(StudentChangeCourseRequestApplication request)
        {
            try
            {
                return (!string.IsNullOrEmpty(Convert.ToString(request.Id)));
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
