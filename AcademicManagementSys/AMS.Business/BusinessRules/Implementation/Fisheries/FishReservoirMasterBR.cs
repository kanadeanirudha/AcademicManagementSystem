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
    public class FishReservoirMasterBR : IFishReservoirMasterBR
    {
        public FishReservoirMasterBR()
        {
        }
        /// <summary>
        /// Validate method to insert record from FishReservoirMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IValidateBusinessRuleResponse InsertFishReservoirMasterValidate(FishReservoirMaster item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateInsertFishReservoirMaster(item))
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
        /// Validate method to update record from FishReservoirMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IValidateBusinessRuleResponse UpdateFishReservoirMasterValidate(FishReservoirMaster item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateUpdateFishReservoirMaster(item))
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
        /// Validate method to delete record from FishReservoirMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IValidateBusinessRuleResponse DeleteFishReservoirMasterValidate(FishReservoirMaster item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateDeleteFishReservoirMaster(item))
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
        /// Validation on insert FishReservoirMasterproperty.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool ValidateInsertFishReservoirMaster(FishReservoirMaster request)
        {
            //We need to Implment this validation method properly
            return true;
        }
        /// <summary>
        /// Validation on update FishReservoirMasterproperty.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool ValidateUpdateFishReservoirMaster(FishReservoirMaster request)
        {
            //We need to Implment this validation method properly
            return (request.ID > 0);
        }
        /// <summary>
        /// Validation on delete FishReservoirMasterproperty.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool ValidateDeleteFishReservoirMaster(FishReservoirMaster request)
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
