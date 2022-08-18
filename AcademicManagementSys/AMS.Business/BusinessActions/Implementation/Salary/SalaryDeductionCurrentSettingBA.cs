using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
	public class SalaryDeductionCurrentSettingBA : ISalaryDeductionCurrentSettingBA
	{
		ISalaryDeductionCurrentSettingDataProvider _SalaryDeductionCurrentSettingDataProvider;
		ISalaryDeductionCurrentSettingBR _SalaryDeductionCurrentSettingBR;
		private ILogger _logException;
		public SalaryDeductionCurrentSettingBA()
		{
			_logException = new ExceptionManager.ExceptionManager(); //This need to change later
			_SalaryDeductionCurrentSettingBR = new SalaryDeductionCurrentSettingBR();
			_SalaryDeductionCurrentSettingDataProvider = new SalaryDeductionCurrentSettingDataProvider();
		}
		/// <summary>
		/// Create new record of SalaryDeductionCurrentSetting.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<SalaryDeductionCurrentSetting> InsertSalaryDeductionCurrentSetting(SalaryDeductionCurrentSetting item)
		{
			IBaseEntityResponse<SalaryDeductionCurrentSetting> entityResponse = new BaseEntityResponse<SalaryDeductionCurrentSetting>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _SalaryDeductionCurrentSettingBR.InsertSalaryDeductionCurrentSettingValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _SalaryDeductionCurrentSettingDataProvider.InsertSalaryDeductionCurrentSetting(item);
				}
				else
				{
					entityResponse.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					entityResponse.Entity = null;;
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
		/// Update a specific record  of SalaryDeductionCurrentSetting.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<SalaryDeductionCurrentSetting> UpdateSalaryDeductionCurrentSetting(SalaryDeductionCurrentSetting item)
		{
			IBaseEntityResponse<SalaryDeductionCurrentSetting> entityResponse = new BaseEntityResponse<SalaryDeductionCurrentSetting>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _SalaryDeductionCurrentSettingBR.UpdateSalaryDeductionCurrentSettingValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _SalaryDeductionCurrentSettingDataProvider.UpdateSalaryDeductionCurrentSetting(item);
				}
				else
				{
					entityResponse.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					entityResponse.Entity = null;;
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
		/// Delete a selected record from SalaryDeductionCurrentSetting.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<SalaryDeductionCurrentSetting> DeleteSalaryDeductionCurrentSetting(SalaryDeductionCurrentSetting item)
		{
			IBaseEntityResponse<SalaryDeductionCurrentSetting> entityResponse = new BaseEntityResponse<SalaryDeductionCurrentSetting>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _SalaryDeductionCurrentSettingBR.DeleteSalaryDeductionCurrentSettingValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _SalaryDeductionCurrentSettingDataProvider.DeleteSalaryDeductionCurrentSetting(item);
				}
				else
				{
					entityResponse.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					entityResponse.Entity = null;;
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
		/// Select all record from SalaryDeductionCurrentSetting table with search parameters.
		/// <summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
		public IBaseEntityCollectionResponse<SalaryDeductionCurrentSetting> GetBySearch(SalaryDeductionCurrentSettingSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<SalaryDeductionCurrentSetting> SalaryDeductionCurrentSettingCollection = new BaseEntityCollectionResponse<SalaryDeductionCurrentSetting>();
			try
			{
				if (_SalaryDeductionCurrentSettingDataProvider != null)
				SalaryDeductionCurrentSettingCollection = _SalaryDeductionCurrentSettingDataProvider.GetSalaryDeductionCurrentSettingBySearch(searchRequest);
				else
				{
					SalaryDeductionCurrentSettingCollection.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					SalaryDeductionCurrentSettingCollection.CollectionResponse = null;
				}
			}
			catch (Exception ex)
			{
				SalaryDeductionCurrentSettingCollection.Message.Add(new MessageDTO
				{
					ErrorMessage = ex.Message,
					 MessageType = MessageTypeEnum.Error
				});
				SalaryDeductionCurrentSettingCollection.CollectionResponse = null;
				if (_logException != null)
				{
					_logException.Error(ex.Message);
				}
			}
			return SalaryDeductionCurrentSettingCollection;
		}
		/// <summary>
		/// Select a record from SalaryDeductionCurrentSetting table by ID
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<SalaryDeductionCurrentSetting> SelectByID(SalaryDeductionCurrentSetting item)
		{
			IBaseEntityResponse<SalaryDeductionCurrentSetting> entityResponse = new BaseEntityResponse<SalaryDeductionCurrentSetting>();
			try
			{
				 entityResponse = _SalaryDeductionCurrentSettingDataProvider.GetSalaryDeductionCurrentSettingByID(item);
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
        /// Select all record from SalaryDeductionCurrentSetting table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<SalaryDeductionCurrentSetting> GetAllowanceHeadNameList(SalaryDeductionCurrentSettingSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalaryDeductionCurrentSetting> SalaryDeductionCurrentSettingCollection = new BaseEntityCollectionResponse<SalaryDeductionCurrentSetting>();
            try
            {
                if (_SalaryDeductionCurrentSettingDataProvider != null)
                    SalaryDeductionCurrentSettingCollection = _SalaryDeductionCurrentSettingDataProvider.GetAllowanceHeadNameList(searchRequest);
                else
                {
                    SalaryDeductionCurrentSettingCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SalaryDeductionCurrentSettingCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SalaryDeductionCurrentSettingCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SalaryDeductionCurrentSettingCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SalaryDeductionCurrentSettingCollection;
        }
	}
}
