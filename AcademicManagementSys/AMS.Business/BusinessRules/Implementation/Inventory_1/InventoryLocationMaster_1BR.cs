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
    public class InventoryLocationMaster_1BR : IInventoryLocationMaster_1BR
    {
        public InventoryLocationMaster_1BR()
        {
        }
        /// <summary>
        /// Validate method to insert record from InventoryLocationMaster_1.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IValidateBusinessRuleResponse InsertInventoryLocationMaster_1Validate(InventoryLocationMaster_1 item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateInsertInventoryLocationMaster_1(item))
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
        /// Validate method to update record from InventoryLocationMaster_1.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IValidateBusinessRuleResponse UpdateInventoryLocationMaster_1Validate(InventoryLocationMaster_1 item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateUpdateInventoryLocationMaster_1(item))
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
        /// Validate method to delete record from InventoryLocationMaster_1.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IValidateBusinessRuleResponse DeleteInventoryLocationMaster_1Validate(InventoryLocationMaster_1 item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateDeleteInventoryLocationMaster_1(item))
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
        /// Validation on insert InventoryLocationMaster_1property.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool ValidateInsertInventoryLocationMaster_1(InventoryLocationMaster_1 request)
        {
            //We need to Implment this validation method properly
            return true;
        }
        /// <summary>
        /// Validation on update InventoryLocationMaster_1property.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool ValidateUpdateInventoryLocationMaster_1(InventoryLocationMaster_1 request)
        {
            //We need to Implment this validation method properly
            return true;
        }
        /// <summary>
        /// Validation on delete InventoryLocationMaster_1property.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool ValidateDeleteInventoryLocationMaster_1(InventoryLocationMaster_1 request)
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
