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
    public class InventoryInWardMasterAndInWardDetailsBR : IInventoryInWardMasterAndInWardDetailsBR
    {
        public InventoryInWardMasterAndInWardDetailsBR()
        {
        }

        // InventoryInWardMaster Method
        #region InventoryInWardMaster

        /// Validate method to insert record from InventoryInWardMaster.        
        public IValidateBusinessRuleResponse InsertInventoryInWardMasterValidate(InventoryInWardMasterAndInWardDetails item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateInsertInventoryInWardMaster(item))
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

        /// Validate method to update record from InventoryInWardMaster.        
        public IValidateBusinessRuleResponse UpdateInventoryInWardMasterValidate(InventoryInWardMasterAndInWardDetails item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateUpdateInventoryInWardMaster(item))
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

        /// Validate method to delete record from InventoryInWardMaster.       
        public IValidateBusinessRuleResponse DeleteInventoryInWardMasterValidate(InventoryInWardMasterAndInWardDetails item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateDeleteInventoryInWardMaster(item))
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

        /// Validation on insert InventoryInWardMaster.        
        private bool ValidateInsertInventoryInWardMaster(InventoryInWardMasterAndInWardDetails request)
        {
            return true;
        }

        /// Validation on update InventoryInWardMaster.        
        private bool ValidateUpdateInventoryInWardMaster(InventoryInWardMasterAndInWardDetails request)
        {
            return (request.InventoryInWardMasterID > 0);
        }

        /// Validation on delete InventoryInWardMaster.        
        private bool ValidateDeleteInventoryInWardMaster(InventoryInWardMasterAndInWardDetails request)
        {
            try
            {
                return (request.InventoryInWardMasterID > 0);
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion




        #region InventoryInWardDetails

        /// Validate method to insert record from InventoryInWardDetails.        
        public IValidateBusinessRuleResponse InsertInventoryInWardDetailsValidate(InventoryInWardMasterAndInWardDetails item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateInsertInventoryInWardDetails(item))
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

        /// Validate method to update record from InventoryInWardDetails.        
        public IValidateBusinessRuleResponse UpdateInventoryInWardDetailsValidate(InventoryInWardMasterAndInWardDetails item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateUpdateInventoryInWardDetails(item))
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

        /// Validate method to delete record from InventoryInWardDetails.       
        public IValidateBusinessRuleResponse DeleteInventoryInWardDetailsValidate(InventoryInWardMasterAndInWardDetails item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateDeleteInventoryInWardDetails(item))
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

        /// Validation on insert InventoryInWardDetails.        
        private bool ValidateInsertInventoryInWardDetails(InventoryInWardMasterAndInWardDetails request)
        {
            return true;
        }

        /// Validation on update InventoryInWardDetails.        
        private bool ValidateUpdateInventoryInWardDetails(InventoryInWardMasterAndInWardDetails request)
        {
            return (request.InventoryInWardDetailsID > 0);
        }

        /// Validation on delete InventoryInWardDetails.        
        private bool ValidateDeleteInventoryInWardDetails(InventoryInWardMasterAndInWardDetails request)
        {
            try
            {
                return (request.InventoryInWardDetailsID > 0);
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion
    }
}
