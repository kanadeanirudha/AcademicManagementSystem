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
    class CRMSaleGroupMasterAndAllocateEmployeeInGroupBR : ICRMSaleGroupMasterAndAllocateEmployeeInGroupBR
    {
        public CRMSaleGroupMasterAndAllocateEmployeeInGroupBR()
        {
        }

        //CRMSaleGroupMaster
        public IValidateBusinessRuleResponse InsertCRMSaleGroupMasterValidate(CRMSaleGroupMasterAndAllocateEmployeeInGroup item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateInsertCRMSaleGroupMaster(item))
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
        public IValidateBusinessRuleResponse UpdateCRMSaleGroupMasterValidate(CRMSaleGroupMasterAndAllocateEmployeeInGroup item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateUpdateCRMSaleGroupMaster(item))
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
        public IValidateBusinessRuleResponse DeleteCRMSaleGroupMasterValidate(CRMSaleGroupMasterAndAllocateEmployeeInGroup item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateDeleteCRMSaleGroupMaster(item))
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
        private bool ValidateInsertCRMSaleGroupMaster(CRMSaleGroupMasterAndAllocateEmployeeInGroup request)
        {
            //We need to Implment this validation method properly
            return true;
        }
        private bool ValidateUpdateCRMSaleGroupMaster(CRMSaleGroupMasterAndAllocateEmployeeInGroup request)
        {
            //We need to Implment this validation method properly
            return true;
        }
        private bool ValidateDeleteCRMSaleGroupMaster(CRMSaleGroupMasterAndAllocateEmployeeInGroup request)
        {
            try
            {
                return (!string.IsNullOrEmpty(Convert.ToString(request.CRMSaleGroupMasterID)));
            }
            catch (Exception)
            {
                return false;
            }
        }

        //CRMSaleAllocateEmployeeInGroup

        public IValidateBusinessRuleResponse InsertCRMSaleAllocateEmployeeInGroupValidate(CRMSaleGroupMasterAndAllocateEmployeeInGroup item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateInsertCRMSaleAllocateEmployeeInGroup(item))
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
        public IValidateBusinessRuleResponse UpdateCRMSaleAllocateEmployeeInGroupValidate(CRMSaleGroupMasterAndAllocateEmployeeInGroup item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateUpdateCRMSaleAllocateEmployeeInGroup(item))
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
        public IValidateBusinessRuleResponse DeleteCRMSaleAllocateEmployeeInGroupValidate(CRMSaleGroupMasterAndAllocateEmployeeInGroup item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateDeleteCRMSaleAllocateEmployeeInGroup(item))
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
        private bool ValidateInsertCRMSaleAllocateEmployeeInGroup(CRMSaleGroupMasterAndAllocateEmployeeInGroup request)
        {
            //We need to Implment this validation method properly
            return true;
        }
        private bool ValidateUpdateCRMSaleAllocateEmployeeInGroup(CRMSaleGroupMasterAndAllocateEmployeeInGroup request)
        {
            //We need to Implment this validation method properly
            return true;
        }
        private bool ValidateDeleteCRMSaleAllocateEmployeeInGroup(CRMSaleGroupMasterAndAllocateEmployeeInGroup request)
        {
            try
            {
                return (!string.IsNullOrEmpty(Convert.ToString(request.CRMSaleGroupMasterID)));
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
