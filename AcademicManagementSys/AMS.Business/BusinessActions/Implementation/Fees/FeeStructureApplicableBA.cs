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
namespace AMS.Business.BusinessActions
{
	public class FeeStructureApplicableBA : IFeeStructureApplicableBA
	{
		IFeeStructureApplicableDataProvider _FeeStructureApplicableDataProvider;
		IFeeStructureApplicableBR _FeeStructureApplicableBR;
		private ILogger _logException;
		public FeeStructureApplicableBA()
		{
			_logException = new ExceptionManager.ExceptionManager(); //This need to change later
			_FeeStructureApplicableBR = new FeeStructureApplicableBR();
			_FeeStructureApplicableDataProvider = new FeeStructureApplicableDataProvider();
		}
		/// <summary>
		/// Create new record of FeeStructureApplicable.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<FeeStructureApplicable> InsertFeeStructureApplicable(FeeStructureApplicable item)
		{
			IBaseEntityResponse<FeeStructureApplicable> entityResponse = new BaseEntityResponse<FeeStructureApplicable>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _FeeStructureApplicableBR.InsertFeeStructureApplicableValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _FeeStructureApplicableDataProvider.InsertFeeStructureApplicable(item);
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
		/// Update a specific record  of FeeStructureApplicable.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<FeeStructureApplicable> UpdateFeeStructureApplicable(FeeStructureApplicable item)
		{
			IBaseEntityResponse<FeeStructureApplicable> entityResponse = new BaseEntityResponse<FeeStructureApplicable>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _FeeStructureApplicableBR.UpdateFeeStructureApplicableValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _FeeStructureApplicableDataProvider.UpdateFeeStructureApplicable(item);
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
		/// Delete a selected record from FeeStructureApplicable.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<FeeStructureApplicable> DeleteFeeStructureApplicable(FeeStructureApplicable item)
		{
			IBaseEntityResponse<FeeStructureApplicable> entityResponse = new BaseEntityResponse<FeeStructureApplicable>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _FeeStructureApplicableBR.DeleteFeeStructureApplicableValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _FeeStructureApplicableDataProvider.DeleteFeeStructureApplicable(item);
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
		/// Select all record from FeeStructureApplicable table with search parameters.
		/// <summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
		public IBaseEntityCollectionResponse<FeeStructureApplicable> GetBySearch(FeeStructureApplicableSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<FeeStructureApplicable> FeeStructureApplicableCollection = new BaseEntityCollectionResponse<FeeStructureApplicable>();
			try
			{
				if (_FeeStructureApplicableDataProvider != null)
				FeeStructureApplicableCollection = _FeeStructureApplicableDataProvider.GetFeeStructureApplicableBySearch(searchRequest);
				else
				{
					FeeStructureApplicableCollection.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					FeeStructureApplicableCollection.CollectionResponse = null;
				}
			}
			catch (Exception ex)
			{
				FeeStructureApplicableCollection.Message.Add(new MessageDTO
				{
					ErrorMessage = ex.Message,
					 MessageType = MessageTypeEnum.Error
				});
				FeeStructureApplicableCollection.CollectionResponse = null;
				if (_logException != null)
				{
					_logException.Error(ex.Message);
				}
			}
			return FeeStructureApplicableCollection;
		}
		/// <summary>
		/// Select all record from FeeStructureApplicable table with search parameters.
		/// <summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
        public IBaseEntityCollectionResponse<FeeStructureApplicable> GetStudentListAccordingToFeeStructure(FeeStructureApplicableSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<FeeStructureApplicable> FeeStructureApplicableCollection = new BaseEntityCollectionResponse<FeeStructureApplicable>();
			try
			{
				if (_FeeStructureApplicableDataProvider != null)
                    FeeStructureApplicableCollection = _FeeStructureApplicableDataProvider.GetStudentListAccordingToFeeStructure(searchRequest);
				else
				{
					FeeStructureApplicableCollection.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					FeeStructureApplicableCollection.CollectionResponse = null;
				}
			}
			catch (Exception ex)
			{
				FeeStructureApplicableCollection.Message.Add(new MessageDTO
				{
					ErrorMessage = ex.Message,
					 MessageType = MessageTypeEnum.Error
				});
				FeeStructureApplicableCollection.CollectionResponse = null;
				if (_logException != null)
				{
					_logException.Error(ex.Message);
				}
			}
			return FeeStructureApplicableCollection;
		}        
		/// <summary>
		/// Select a record from FeeStructureApplicable table by ID
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<FeeStructureApplicable> SelectByID(FeeStructureApplicable item)
		{
			IBaseEntityResponse<FeeStructureApplicable> entityResponse = new BaseEntityResponse<FeeStructureApplicable>();
			try
			{
				 entityResponse = _FeeStructureApplicableDataProvider.GetFeeStructureApplicableByID(item);
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

        public IBaseEntityCollectionResponse<FeeStructureApplicable> GetFeeStructureCriteriaApprovalList(FeeStructureApplicableSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FeeStructureApplicable> FeeStructureApprovalCollection = new BaseEntityCollectionResponse<FeeStructureApplicable>();
            try
            {
                if (_FeeStructureApplicableDataProvider != null)
                    FeeStructureApprovalCollection = _FeeStructureApplicableDataProvider.GetFeeStructureCriteriaApprovalList(searchRequest);
                else
                {
                    FeeStructureApprovalCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    FeeStructureApprovalCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                FeeStructureApprovalCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                FeeStructureApprovalCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return FeeStructureApprovalCollection;
        }

        public IBaseEntityResponse<FeeStructureApplicable> CreateFeeStructureRequestApproval(FeeStructureApplicable item)
        {
            IBaseEntityResponse<FeeStructureApplicable> entityResponse = new BaseEntityResponse<FeeStructureApplicable>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _FeeStructureApplicableBR.CreateFeeStructureRequestApproval(item);
                if (brResponse.Passed)
                {
                    entityResponse = _FeeStructureApplicableDataProvider.CreateFeeStructureRequestApproval(item);
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

        //for fee structure not applicable student list
        public IBaseEntityCollectionResponse<FeeStructureApplicable> GetFeeStructureNotApplicableStudentList(FeeStructureApplicableSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<FeeStructureApplicable> FeeStructureApprovalCollection = new BaseEntityCollectionResponse<FeeStructureApplicable>();
            try
            {
                if (_FeeStructureApplicableDataProvider != null)
                    FeeStructureApprovalCollection = _FeeStructureApplicableDataProvider.GetFeeStructureNotApplicableStudentList(searchRequest);
                else
                {
                    FeeStructureApprovalCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    FeeStructureApprovalCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                FeeStructureApprovalCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                FeeStructureApprovalCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return FeeStructureApprovalCollection;
        }
	}
}
