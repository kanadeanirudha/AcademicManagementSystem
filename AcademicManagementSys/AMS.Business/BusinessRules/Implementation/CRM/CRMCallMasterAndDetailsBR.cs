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
    class CRMCallMasterAndDetailsBR : ICRMCallMasterAndDetailsBR
    {
        public CRMCallMasterAndDetailsBR()
        {
        }
        /// <summary>
        /// Validate method to insert record from CRMCallMasterAndDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IValidateBusinessRuleResponse InsertCRMCallMasterAndDetailsValidate(CRMCallMasterAndDetails item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }

                if (!ValidateInsertCRMCallMasterAndDetails(item))
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
        /// Validate method to update record from CRMCallMasterAndDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IValidateBusinessRuleResponse UpdateCRMCallMasterAndDetailsValidate(CRMCallMasterAndDetails item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }

                if (!ValidateUpdateCRMCallMasterAndDetails(item))
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
        /// Validate method to delete record from CRMCallMasterAndDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IValidateBusinessRuleResponse DeleteCRMCallMasterAndDetailsValidate(CRMCallMasterAndDetails item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }

                if (!ValidateDeleteCRMCallMasterAndDetails(item))
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
        /// Validation on insert CRMCallMasterAndDetails property.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool ValidateInsertCRMCallMasterAndDetails(CRMCallMasterAndDetails request)
        {
            //We need to Implment this validation method properly
            return true;
        }

        /// <summary>
        /// Validation on update CRMCallMasterAndDetails property.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool ValidateUpdateCRMCallMasterAndDetails(CRMCallMasterAndDetails request)
        {
            //We need to Implment this validation method properly
            return (request.ID > 0);
        }

        /// <summary>
        /// Validation on dalete CRMCallMasterAndDetails property.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool ValidateDeleteCRMCallMasterAndDetails(CRMCallMasterAndDetails request)
        {
            try
            {
                return (request.ID > 0);
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}





