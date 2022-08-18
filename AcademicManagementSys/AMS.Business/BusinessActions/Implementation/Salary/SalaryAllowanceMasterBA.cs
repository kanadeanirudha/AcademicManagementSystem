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
	public class SalaryAllowanceMasterBA : ISalaryAllowanceMasterBA
	{
		ISalaryAllowanceMasterDataProvider _salaryAllowanceMasterDataProvider;
		ISalaryAllowanceMasterBR _salaryAllowanceMasterBR;
		private ILogger _logException;
		public SalaryAllowanceMasterBA()
		{
			_logException = new ExceptionManager.ExceptionManager(); //This need to change later
			_salaryAllowanceMasterBR = new SalaryAllowanceMasterBR();
			_salaryAllowanceMasterDataProvider = new SalaryAllowanceMasterDataProvider();
		}
		/// <summary>
		/// Create new record of SalaryAllowanceMaster.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<SalaryAllowanceMaster> InsertSalaryAllowanceMaster(SalaryAllowanceMaster item)
		{
			IBaseEntityResponse<SalaryAllowanceMaster> entityResponse = new BaseEntityResponse<SalaryAllowanceMaster>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _salaryAllowanceMasterBR.InsertSalaryAllowanceMasterValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _salaryAllowanceMasterDataProvider.InsertSalaryAllowanceMaster(item);
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
		/// Update a specific record  of SalaryAllowanceMaster.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<SalaryAllowanceMaster> UpdateSalaryAllowanceMaster(SalaryAllowanceMaster item)
		{
			IBaseEntityResponse<SalaryAllowanceMaster> entityResponse = new BaseEntityResponse<SalaryAllowanceMaster>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _salaryAllowanceMasterBR.UpdateSalaryAllowanceMasterValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _salaryAllowanceMasterDataProvider.UpdateSalaryAllowanceMaster(item);
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
		/// Delete a selected record from SalaryAllowanceMaster.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<SalaryAllowanceMaster> DeleteSalaryAllowanceMaster(SalaryAllowanceMaster item)
		{
			IBaseEntityResponse<SalaryAllowanceMaster> entityResponse = new BaseEntityResponse<SalaryAllowanceMaster>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _salaryAllowanceMasterBR.DeleteSalaryAllowanceMasterValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _salaryAllowanceMasterDataProvider.DeleteSalaryAllowanceMaster(item);
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
		/// Select all record from SalaryAllowanceMaster table with search parameters.
		/// <summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
		public IBaseEntityCollectionResponse<SalaryAllowanceMaster> GetBySearch(SalaryAllowanceMasterSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<SalaryAllowanceMaster> SalaryAllowanceMasterCollection = new BaseEntityCollectionResponse<SalaryAllowanceMaster>();
			try
			{
				if (_salaryAllowanceMasterDataProvider != null)
				SalaryAllowanceMasterCollection = _salaryAllowanceMasterDataProvider.GetSalaryAllowanceMasterBySearch(searchRequest);
				else
				{
					SalaryAllowanceMasterCollection.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					SalaryAllowanceMasterCollection.CollectionResponse = null;
				}
			}
			catch (Exception ex)
			{
				SalaryAllowanceMasterCollection.Message.Add(new MessageDTO
				{
					ErrorMessage = ex.Message,
					 MessageType = MessageTypeEnum.Error
				});
				SalaryAllowanceMasterCollection.CollectionResponse = null;
				if (_logException != null)
				{
					_logException.Error(ex.Message);
				}
			}
			return SalaryAllowanceMasterCollection;
		}
		/// <summary>
		/// Select a record from SalaryAllowanceMaster table by ID
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<SalaryAllowanceMaster> SelectByID(SalaryAllowanceMaster item)
		{
			IBaseEntityResponse<SalaryAllowanceMaster> entityResponse = new BaseEntityResponse<SalaryAllowanceMaster>();
			try
			{
				 entityResponse = _salaryAllowanceMasterDataProvider.GetSalaryAllowanceMasterByID(item);
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
        /// Select all record from SalaryAllowanceMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<SalaryAllowanceMaster> GetAllowanceHeadNameList(SalaryAllowanceMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalaryAllowanceMaster> SalaryAllowanceMasterCollection = new BaseEntityCollectionResponse<SalaryAllowanceMaster>();
            try
            {
                if (_salaryAllowanceMasterDataProvider != null)
                    SalaryAllowanceMasterCollection = _salaryAllowanceMasterDataProvider.GetAllowanceHeadNameList(searchRequest);
                else
                {
                    SalaryAllowanceMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SalaryAllowanceMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SalaryAllowanceMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SalaryAllowanceMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SalaryAllowanceMasterCollection;
        }
	}
}
