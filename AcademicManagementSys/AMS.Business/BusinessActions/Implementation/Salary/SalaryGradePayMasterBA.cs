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
	public class SalaryGradePayMasterBA : ISalaryGradePayMasterBA
	{
		ISalaryGradePayMasterDataProvider _salaryGradePayMasterDataProvider;
		ISalaryGradePayMasterBR _salaryGradePayMasterBR;
		private ILogger _logException;
		public SalaryGradePayMasterBA()
		{
			_logException = new ExceptionManager.ExceptionManager(); //This need to change later
			_salaryGradePayMasterBR = new SalaryGradePayMasterBR();
			_salaryGradePayMasterDataProvider = new SalaryGradePayMasterDataProvider();
		}
		/// <summary>
		/// Create new record of SalaryGradePayMaster.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<SalaryGradePayMaster> InsertSalaryGradePayMaster(SalaryGradePayMaster item)
		{
			IBaseEntityResponse<SalaryGradePayMaster> entityResponse = new BaseEntityResponse<SalaryGradePayMaster>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _salaryGradePayMasterBR.InsertSalaryGradePayMasterValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _salaryGradePayMasterDataProvider.InsertSalaryGradePayMaster(item);
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
		/// Update a specific record  of SalaryGradePayMaster.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<SalaryGradePayMaster> UpdateSalaryGradePayMaster(SalaryGradePayMaster item)
		{
			IBaseEntityResponse<SalaryGradePayMaster> entityResponse = new BaseEntityResponse<SalaryGradePayMaster>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _salaryGradePayMasterBR.UpdateSalaryGradePayMasterValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _salaryGradePayMasterDataProvider.UpdateSalaryGradePayMaster(item);
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
		/// Delete a selected record from SalaryGradePayMaster.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<SalaryGradePayMaster> DeleteSalaryGradePayMaster(SalaryGradePayMaster item)
		{
			IBaseEntityResponse<SalaryGradePayMaster> entityResponse = new BaseEntityResponse<SalaryGradePayMaster>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _salaryGradePayMasterBR.DeleteSalaryGradePayMasterValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _salaryGradePayMasterDataProvider.DeleteSalaryGradePayMaster(item);
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
		/// Select all record from SalaryGradePayMaster table with search parameters.
		/// <summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
		public IBaseEntityCollectionResponse<SalaryGradePayMaster> GetBySearch(SalaryGradePayMasterSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<SalaryGradePayMaster> SalaryGradePayMasterCollection = new BaseEntityCollectionResponse<SalaryGradePayMaster>();
			try
			{
				if (_salaryGradePayMasterDataProvider != null)
				SalaryGradePayMasterCollection = _salaryGradePayMasterDataProvider.GetSalaryGradePayMasterBySearch(searchRequest);
				else
				{
					SalaryGradePayMasterCollection.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					SalaryGradePayMasterCollection.CollectionResponse = null;
				}
			}
			catch (Exception ex)
			{
				SalaryGradePayMasterCollection.Message.Add(new MessageDTO
				{
					ErrorMessage = ex.Message,
					 MessageType = MessageTypeEnum.Error
				});
				SalaryGradePayMasterCollection.CollectionResponse = null;
				if (_logException != null)
				{
					_logException.Error(ex.Message);
				}
			}
			return SalaryGradePayMasterCollection;
		}
		/// <summary>
		/// Select a record from SalaryGradePayMaster table by ID
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<SalaryGradePayMaster> SelectByID(SalaryGradePayMaster item)
		{
			IBaseEntityResponse<SalaryGradePayMaster> entityResponse = new BaseEntityResponse<SalaryGradePayMaster>();
			try
			{
				 entityResponse = _salaryGradePayMasterDataProvider.GetSalaryGradePayMasterByID(item);
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
        /// Select all record from SalaryGradePayMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<SalaryGradePayMaster> GetListGradePayAmount(SalaryGradePayMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalaryGradePayMaster> SalaryGradePayMasterCollection = new BaseEntityCollectionResponse<SalaryGradePayMaster>();
            try
            {
                if (_salaryGradePayMasterDataProvider != null)
                    SalaryGradePayMasterCollection = _salaryGradePayMasterDataProvider.GetListGradePayAmount(searchRequest);
                else
                {
                    SalaryGradePayMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SalaryGradePayMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SalaryGradePayMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SalaryGradePayMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SalaryGradePayMasterCollection;
        }
	}
}
