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
    public class InventoryReportMasterBR : IInventoryReportMasterBR
    {
        public InventoryReportMasterBR()
        {   
        }

        // InventoryReportMasterBR Method
        #region InventoryReportMasterBR

        /// Validate method to insert record from InventoryReportMaster.        
        public IValidateBusinessRuleResponse InsertInventoryReportMasterValidate(InventoryReportMaster item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateInsertInventoryReportMaster(item))
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

        /// Validate method to update record from InventoryReportMaster.        
        public IValidateBusinessRuleResponse UpdateInventoryReportMasterValidate(InventoryReportMaster item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateUpdateInventoryReportMaster(item))
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

        /// Validate method to delete record from InventoryReportMaster.       
        public IValidateBusinessRuleResponse DeleteInventoryReportMasterValidate(InventoryReportMaster item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateDeleteInventoryReportMaster(item))
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

        /// Validation on insert InventoryReportMaster.        
        private bool ValidateInsertInventoryReportMaster(InventoryReportMaster request)
        {
            return true;
        }

        /// Validation on update InventoryReportMaster.        
        private bool ValidateUpdateInventoryReportMaster(InventoryReportMaster request)
        {
            return (request.LocationID > 0);
        }

        /// Validation on delete InventoryReportMaster.        
        private bool ValidateDeleteInventoryReportMaster(InventoryReportMaster request)
        {
            try
            {
                return (request.LocationID > 0);
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion
    }
}
