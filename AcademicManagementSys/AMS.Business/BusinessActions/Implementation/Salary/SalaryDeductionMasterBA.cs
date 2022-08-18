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
	public class SalaryDeductionMasterBA : ISalaryDeductionMasterBA
	{
		ISalaryDeductionMasterDataProvider _SalaryDeductionMasterDataProvider;
		ISalaryDeductionMasterBR _SalaryDeductionMasterBR;
		private ILogger _logException;
		public SalaryDeductionMasterBA()
		{
			_logException = new ExceptionManager.ExceptionManager(); //This need to change later
			_SalaryDeductionMasterBR = new SalaryDeductionMasterBR();
			_SalaryDeductionMasterDataProvider = new SalaryDeductionMasterDataProvider();
		}
		/// <summary>
		/// Create new record of SalaryDeductionMaster.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<SalaryDeductionMaster> InsertSalaryDeductionMaster(SalaryDeductionMaster item)
		{
			IBaseEntityResponse<SalaryDeductionMaster> entityResponse = new BaseEntityResponse<SalaryDeductionMaster>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _SalaryDeductionMasterBR.InsertSalaryDeductionMasterValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _SalaryDeductionMasterDataProvider.InsertSalaryDeductionMaster(item);
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
		/// Update a specific record  of SalaryDeductionMaster.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<SalaryDeductionMaster> UpdateSalaryDeductionMaster(SalaryDeductionMaster item)
		{
			IBaseEntityResponse<SalaryDeductionMaster> entityResponse = new BaseEntityResponse<SalaryDeductionMaster>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _SalaryDeductionMasterBR.UpdateSalaryDeductionMasterValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _SalaryDeductionMasterDataProvider.UpdateSalaryDeductionMaster(item);
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
		/// Delete a selected record from SalaryDeductionMaster.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<SalaryDeductionMaster> DeleteSalaryDeductionMaster(SalaryDeductionMaster item)
		{
			IBaseEntityResponse<SalaryDeductionMaster> entityResponse = new BaseEntityResponse<SalaryDeductionMaster>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _SalaryDeductionMasterBR.DeleteSalaryDeductionMasterValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _SalaryDeductionMasterDataProvider.DeleteSalaryDeductionMaster(item);
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
		/// Select all record from SalaryDeductionMaster table with search parameters.
		/// <summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
		public IBaseEntityCollectionResponse<SalaryDeductionMaster> GetBySearch(SalaryDeductionMasterSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<SalaryDeductionMaster> SalaryDeductionMasterCollection = new BaseEntityCollectionResponse<SalaryDeductionMaster>();
			try
			{
				if (_SalaryDeductionMasterDataProvider != null)
				SalaryDeductionMasterCollection = _SalaryDeductionMasterDataProvider.GetSalaryDeductionMasterBySearch(searchRequest);
				else
				{
					SalaryDeductionMasterCollection.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					SalaryDeductionMasterCollection.CollectionResponse = null;
				}
			}
			catch (Exception ex)
			{
				SalaryDeductionMasterCollection.Message.Add(new MessageDTO
				{
					ErrorMessage = ex.Message,
					 MessageType = MessageTypeEnum.Error
				});
				SalaryDeductionMasterCollection.CollectionResponse = null;
				if (_logException != null)
				{
					_logException.Error(ex.Message);
				}
			}
			return SalaryDeductionMasterCollection;
		}
		/// <summary>
		/// Select a record from SalaryDeductionMaster table by ID
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<SalaryDeductionMaster> SelectByID(SalaryDeductionMaster item)
		{
			IBaseEntityResponse<SalaryDeductionMaster> entityResponse = new BaseEntityResponse<SalaryDeductionMaster>();
			try
			{
				 entityResponse = _SalaryDeductionMasterDataProvider.GetSalaryDeductionMasterByID(item);
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
        /// Select all record from SalaryDeductionMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<SalaryDeductionMaster> GetAllowanceHeadNameList(SalaryDeductionMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalaryDeductionMaster> SalaryDeductionMasterCollection = new BaseEntityCollectionResponse<SalaryDeductionMaster>();
            try
            {
                if (_SalaryDeductionMasterDataProvider != null)
                    SalaryDeductionMasterCollection = _SalaryDeductionMasterDataProvider.GetAllowanceHeadNameList(searchRequest);
                else
                {
                    SalaryDeductionMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SalaryDeductionMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SalaryDeductionMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SalaryDeductionMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SalaryDeductionMasterCollection;
        }
	}
}
