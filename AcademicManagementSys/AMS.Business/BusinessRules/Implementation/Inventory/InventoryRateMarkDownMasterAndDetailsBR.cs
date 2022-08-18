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
    public class InventoryRateMarkDownMasterAndDetailsBR : IInventoryRateMarkDownMasterAndDetailsBR
    {
        public InventoryRateMarkDownMasterAndDetailsBR()
        {
        }
        /// <summary>
        /// Validate method to insert record from InventoryRateMarkDownMasterAndDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IValidateBusinessRuleResponse InsertInventoryRateMarkDownMasterAndDetailsValidate(InventoryRateMarkDownMasterAndDetails item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateInsertInventoryRateMarkDownMasterAndDetails(item))
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
        /// Validate method to update record from InventoryRateMarkDownMasterAndDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IValidateBusinessRuleResponse UpdateInventoryRateMarkDownMasterAndDetailsValidate(InventoryRateMarkDownMasterAndDetails item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateUpdateInventoryRateMarkDownMasterAndDetails(item))
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
        /// Validate method to delete record from InventoryRateMarkDownMasterAndDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IValidateBusinessRuleResponse DeleteInventoryRateMarkDownMasterAndDetailsValidate(InventoryRateMarkDownMasterAndDetails item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateDeleteInventoryRateMarkDownMasterAndDetails(item))
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
        /// Validation on insert InventoryRateMarkDownMasterAndDetailsproperty.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool ValidateInsertInventoryRateMarkDownMasterAndDetails(InventoryRateMarkDownMasterAndDetails request)
        {
            //We need to Implment this validation method properly
            return true;
        }
        /// <summary>
        /// Validation on update InventoryRateMarkDownMasterAndDetailsproperty.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool ValidateUpdateInventoryRateMarkDownMasterAndDetails(InventoryRateMarkDownMasterAndDetails request)
        {
            //We need to Implment this validation method properly
            return true;
        }
        /// <summary>
        /// Validation on delete InventoryRateMarkDownMasterAndDetailsproperty.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool ValidateDeleteInventoryRateMarkDownMasterAndDetails(InventoryRateMarkDownMasterAndDetails request)
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
