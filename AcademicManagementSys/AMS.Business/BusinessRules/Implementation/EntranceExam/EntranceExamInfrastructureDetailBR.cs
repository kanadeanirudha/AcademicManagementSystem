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
    public class EntranceExamInfrastructureDetailBR : IEntranceExamInfrastructureDetailBR
    {
        public EntranceExamInfrastructureDetailBR()
        {
        }

        // EntranceExamAvailableCentres Method
        #region EntranceExamAvailableCentres

        /// Validate method to insert record from EntranceExamAvailableCentres.        
        public IValidateBusinessRuleResponse InsertEntranceExamAvailableCentresValidate(EntranceExamInfrastructureDetail item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateInsertEntranceExamAvailableCentres(item))
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

        /// Validate method to update record from EntranceExamAvailableCentres.        
        public IValidateBusinessRuleResponse UpdateEntranceExamAvailableCentresValidate(EntranceExamInfrastructureDetail item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateUpdateEntranceExamAvailableCentres(item))
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

        /// Validate method to delete record from EntranceExamAvailableCentres.       
        public IValidateBusinessRuleResponse DeleteEntranceExamAvailableCentresValidate(EntranceExamInfrastructureDetail item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateDeleteEntranceExamAvailableCentres(item))
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

        /// Validation on insert EntranceExamAvailableCentres.        
        private bool ValidateInsertEntranceExamAvailableCentres(EntranceExamInfrastructureDetail request)
        {           
            return true;
        }

        /// Validation on update EntranceExamAvailableCentres.        
        private bool ValidateUpdateEntranceExamAvailableCentres(EntranceExamInfrastructureDetail request)
        {
            return (request.EntranceExamAvailableCentresID > 0);
        }

        /// Validation on delete EntranceExamAvailableCentres.        
        private bool ValidateDeleteEntranceExamAvailableCentres(EntranceExamInfrastructureDetail request)
        {
            try
            {
                return (request.EntranceExamAvailableCentresID > 0);
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion


        // EntranceExamInfrastructureDetail Method
        #region EntranceExamInfrastructureDetail

        /// Validate method to insert record from EntranceExamInfrastructureDetail.        
        public IValidateBusinessRuleResponse InsertEntranceExamInfrastructureDetailValidate(EntranceExamInfrastructureDetail item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateInsertEntranceExamInfrastructureDetail(item))
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

        /// Validate method to update record from EntranceExamInfrastructureDetail.        
        public IValidateBusinessRuleResponse UpdateEntranceExamInfrastructureDetailValidate(EntranceExamInfrastructureDetail item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateUpdateEntranceExamInfrastructureDetail(item))
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

        /// Validate method to delete record from EntranceExamInfrastructureDetail.       
        public IValidateBusinessRuleResponse DeleteEntranceExamInfrastructureDetailValidate(EntranceExamInfrastructureDetail item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateDeleteEntranceExamInfrastructureDetail(item))
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

        /// Validation on insert EntranceExamInfrastructureDetailproperty.        
        private bool ValidateInsertEntranceExamInfrastructureDetail(EntranceExamInfrastructureDetail request)
        {
            return true;
        }

        /// Validation on update EntranceExamInfrastructureDetailproperty.        
        private bool ValidateUpdateEntranceExamInfrastructureDetail(EntranceExamInfrastructureDetail request)
        {
            return (request.EntranceExamInfrastructureDetailID > 0);
        }

        /// Validation on delete EntranceExamInfrastructureDetailproperty.        
        private bool ValidateDeleteEntranceExamInfrastructureDetail(EntranceExamInfrastructureDetail request)
        {
            try
            {
                return (request.EntranceExamInfrastructureDetailID > 0);
            }
            catch (Exception)
            {
                return false;
            }
        }


        #endregion
    }
}
