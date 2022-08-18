using AMS.Base.DTO;
using AMS.Business.BusinessRules;
using AMS.Common;
using AMS.DataProvider;
using AMS.DTO;
using AMS.ExceptionManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
    public class SalaryAllowanceCurrentSettingBA : ISalaryAllowanceCurrentSettingBA
    {
        ISalaryAllowanceCurrentSettingDataProvider _salaryAllowanceCurrentSettingDataProvider;
        ISalaryAllowanceCurrentSettingBR _salaryAllowanceCurrentSettingBR;
        private ILogger _logException;
        public SalaryAllowanceCurrentSettingBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _salaryAllowanceCurrentSettingBR = new SalaryAllowanceCurrentSettingBR();
            _salaryAllowanceCurrentSettingDataProvider = new SalaryAllowanceCurrentSettingDataProvider();
        }
        /// <summary>
        /// Create new record of SalaryAllowanceCurrentSetting.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalaryAllowanceCurrentSetting> InsertSalaryAllowanceCurrentSetting(SalaryAllowanceCurrentSetting item)
        {
            IBaseEntityResponse<SalaryAllowanceCurrentSetting> entityResponse = new BaseEntityResponse<SalaryAllowanceCurrentSetting>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _salaryAllowanceCurrentSettingBR.InsertSalaryAllowanceCurrentSettingValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _salaryAllowanceCurrentSettingDataProvider.InsertSalaryAllowanceCurrentSetting(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null; ;
                }
            }
            catch (Exception ex)
            {
                entityResponse.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                entityResponse.Entity = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return entityResponse;
        }
        /// <summary>
        /// Update a specific record  of SalaryAllowanceCurrentSetting.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalaryAllowanceCurrentSetting> UpdateSalaryAllowanceCurrentSetting(SalaryAllowanceCurrentSetting item)
        {
            IBaseEntityResponse<SalaryAllowanceCurrentSetting> entityResponse = new BaseEntityResponse<SalaryAllowanceCurrentSetting>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _salaryAllowanceCurrentSettingBR.UpdateSalaryAllowanceCurrentSettingValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _salaryAllowanceCurrentSettingDataProvider.UpdateSalaryAllowanceCurrentSetting(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null; ;
                }
            }
            catch (Exception ex)
            {
                entityResponse.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                entityResponse.Entity = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return entityResponse;
        }
        /// <summary>
        /// Delete a selected record from SalaryAllowanceCurrentSetting.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalaryAllowanceCurrentSetting> DeleteSalaryAllowanceCurrentSetting(SalaryAllowanceCurrentSetting item)
        {
            IBaseEntityResponse<SalaryAllowanceCurrentSetting> entityResponse = new BaseEntityResponse<SalaryAllowanceCurrentSetting>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _salaryAllowanceCurrentSettingBR.DeleteSalaryAllowanceCurrentSettingValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _salaryAllowanceCurrentSettingDataProvider.DeleteSalaryAllowanceCurrentSetting(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null; ;
                }
            }
            catch (Exception ex)
            {
                entityResponse.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                entityResponse.Entity = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return entityResponse;
        }
        /// <summary>
        /// Select all record from SalaryAllowanceCurrentSetting table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<SalaryAllowanceCurrentSetting> GetBySearch(SalaryAllowanceCurrentSettingSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalaryAllowanceCurrentSetting> SalaryAllowanceCurrentSettingCollection = new BaseEntityCollectionResponse<SalaryAllowanceCurrentSetting>();
            try
            {
                if (_salaryAllowanceCurrentSettingDataProvider != null)
                    SalaryAllowanceCurrentSettingCollection = _salaryAllowanceCurrentSettingDataProvider.GetSalaryAllowanceCurrentSettingBySearch(searchRequest);
                else
                {
                    SalaryAllowanceCurrentSettingCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SalaryAllowanceCurrentSettingCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SalaryAllowanceCurrentSettingCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SalaryAllowanceCurrentSettingCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SalaryAllowanceCurrentSettingCollection;
        }
        /// <summary>
        /// Select a record from SalaryAllowanceCurrentSetting table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalaryAllowanceCurrentSetting> SelectByID(SalaryAllowanceCurrentSetting item)
        {
            IBaseEntityResponse<SalaryAllowanceCurrentSetting> entityResponse = new BaseEntityResponse<SalaryAllowanceCurrentSetting>();
            try
            {
                entityResponse = _salaryAllowanceCurrentSettingDataProvider.GetSalaryAllowanceCurrentSettingByID(item);
            }
            catch (Exception ex)
            {
                entityResponse.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                entityResponse.Entity = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return entityResponse;
        }
    }
}
