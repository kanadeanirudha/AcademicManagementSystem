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
    public class HMIPDTypeBR : IHMIPDTypeBR
    {
        public HMIPDTypeBR()
        {
        }
        /// <summary>
        /// Validate method to insert record from HMIPDType.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IValidateBusinessRuleResponse InsertHMIPDTypeValidate(HMIPDType item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateInsertHMIPDType(item))
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
        /// Validate method to update record from HMIPDType.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IValidateBusinessRuleResponse UpdateHMIPDTypeValidate(HMIPDType item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateUpdateHMIPDType(item))
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
        /// Validate method to delete record from HMIPDType.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IValidateBusinessRuleResponse DeleteHMIPDTypeValidate(HMIPDType item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateDeleteHMIPDType(item))
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
        /// Validation on insert HMIPDTypeproperty.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool ValidateInsertHMIPDType(HMIPDType request)
        {
            //We need to Implment this validation method properly
            return true;
        }
        /// <summary>
        /// Validation on update HMIPDTypeproperty.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool ValidateUpdateHMIPDType(HMIPDType request)
        {
            //We need to Implment this validation method properly
            return true;
        }
        /// <summary>
        /// Validation on delete HMIPDTypeproperty.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool ValidateDeleteHMIPDType(HMIPDType request)
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
