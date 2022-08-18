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
    public class InventoryIssueMasterAndIssueDetailsBR : IInventoryIssueMasterAndIssueDetailsBR
    {
        public InventoryIssueMasterAndIssueDetailsBR()
        {
        }

        // InventoryIssueMaster Method
        #region InventoryIssueMaster

        /// Validate method to insert record from InventoryIssueMaster.        
        public IValidateBusinessRuleResponse InsertInventoryIssueMasterValidate(InventoryIssueMasterAndIssueDetails item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateInsertInventoryIssueMaster(item))
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

        /// Validate method to update record from InventoryIssueMaster.        
        public IValidateBusinessRuleResponse UpdateInventoryIssueMasterValidate(InventoryIssueMasterAndIssueDetails item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateUpdateInventoryIssueMaster(item))
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

        /// Validate method to delete record from InventoryIssueMaster.       
        public IValidateBusinessRuleResponse DeleteInventoryIssueMasterValidate(InventoryIssueMasterAndIssueDetails item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateDeleteInventoryIssueMaster(item))
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

        /// Validation on insert InventoryIssueMaster.        
        private bool ValidateInsertInventoryIssueMaster(InventoryIssueMasterAndIssueDetails request)
        {
            return true;
        }

        /// Validation on update EntranceExamAvailableCentres.        
        private bool ValidateUpdateInventoryIssueMaster(InventoryIssueMasterAndIssueDetails request)
        {
            return (request.InventoryIssueMasterID > 0);
        }

        /// Validation on delete InventoryIssueMaster.        
        private bool ValidateDeleteInventoryIssueMaster(InventoryIssueMasterAndIssueDetails request)
        {
            try
            {
                return (request.InventoryIssueMasterID > 0);
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion



        // InventoryIssueDetails Method
        #region InventoryIssueDetails

        /// Validate method to insert record from InventoryIssueDetails.        
        public IValidateBusinessRuleResponse InsertInventoryIssueDetailsValidate(InventoryIssueMasterAndIssueDetails item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateInsertInventoryIssueDetails(item))
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

        /// Validate method to update record from InventoryIssueDetails.        
        public IValidateBusinessRuleResponse UpdateInventoryIssueDetailsValidate(InventoryIssueMasterAndIssueDetails item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateUpdateInventoryIssueDetails(item))
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

        /// Validate method to delete record from InventoryIssueDetails.       
        public IValidateBusinessRuleResponse DeleteInventoryIssueDetailsValidate(InventoryIssueMasterAndIssueDetails item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateDeleteInventoryIssueDetails(item))
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

        /// Validation on insert InventoryIssueDetails.        
        private bool ValidateInsertInventoryIssueDetails(InventoryIssueMasterAndIssueDetails request)
        {
            return true;
        }

        /// Validation on update InventoryIssueDetails.        
        private bool ValidateUpdateInventoryIssueDetails(InventoryIssueMasterAndIssueDetails request)
        {
            return (request.InventoryIssueDetailID > 0);
        }

        /// Validation on delete InventoryIssueDetails.        
        private bool ValidateDeleteInventoryIssueDetails(InventoryIssueMasterAndIssueDetails request)
        {
            try
            {
                return (request.InventoryIssueDetailID > 0);
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion

    }
}
