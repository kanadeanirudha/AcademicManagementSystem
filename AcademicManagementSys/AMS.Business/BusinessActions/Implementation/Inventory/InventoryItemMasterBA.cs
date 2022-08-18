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
    public class InventoryItemMasterBA : IInventoryItemMasterBA
    {
		IInventoryItemMasterDataProvider _InventoryItemMasterDataProvider;
		IInventoryItemMasterBR _InventoryItemMasterBR;
		private ILogger _logException;
		public InventoryItemMasterBA()
		{
			_logException = new ExceptionManager.ExceptionManager(); //This need to change later
			_InventoryItemMasterBR = new InventoryItemMasterBR();
			_InventoryItemMasterDataProvider = new InventoryItemMasterDataProvider();
		}
		/// <summary>
		/// Create new record of InventoryItemMaster.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<InventoryItemMaster> InsertInventoryItemMaster(InventoryItemMaster item)
		{
			IBaseEntityResponse<InventoryItemMaster> entityResponse = new BaseEntityResponse<InventoryItemMaster>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _InventoryItemMasterBR.InsertInventoryItemMasterValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _InventoryItemMasterDataProvider.InsertInventoryItemMaster(item);
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
		/// Update a specific record  of InventoryItemMaster.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<InventoryItemMaster> UpdateInventoryItemMaster(InventoryItemMaster item)
		{
			IBaseEntityResponse<InventoryItemMaster> entityResponse = new BaseEntityResponse<InventoryItemMaster>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _InventoryItemMasterBR.UpdateInventoryItemMasterValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _InventoryItemMasterDataProvider.UpdateInventoryItemMaster(item);
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
		/// Delete a selected record from InventoryItemMaster.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<InventoryItemMaster> DeleteInventoryItemMaster(InventoryItemMaster item)
		{
			IBaseEntityResponse<InventoryItemMaster> entityResponse = new BaseEntityResponse<InventoryItemMaster>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _InventoryItemMasterBR.DeleteInventoryItemMasterValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _InventoryItemMasterDataProvider.DeleteInventoryItemMaster(item);
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
		/// Select all record from InventoryItemMaster table with search parameters.
		/// <summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
		public IBaseEntityCollectionResponse<InventoryItemMaster> GetBySearch(InventoryItemMasterSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<InventoryItemMaster> InventoryItemMasterCollection = new BaseEntityCollectionResponse<InventoryItemMaster>();
			try
			{
				if (_InventoryItemMasterDataProvider != null)
				InventoryItemMasterCollection = _InventoryItemMasterDataProvider.GetInventoryItemMasterBySearch(searchRequest);
				else
				{
					InventoryItemMasterCollection.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					InventoryItemMasterCollection.CollectionResponse = null;
				}
			}
			catch (Exception ex)
			{
				InventoryItemMasterCollection.Message.Add(new MessageDTO
				{
					ErrorMessage = ex.Message,
					 MessageType = MessageTypeEnum.Error
				});
				InventoryItemMasterCollection.CollectionResponse = null;
				if (_logException != null)
				{
					_logException.Error(ex.Message);
				}
			}
			return InventoryItemMasterCollection;
		}
        /// <summary>
        /// Select all record from InventoryItemMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<InventoryItemMaster> GetInventoryItemSearchList(InventoryItemMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryItemMaster> InventoryItemMasterCollection = new BaseEntityCollectionResponse<InventoryItemMaster>();
            try
            {
                if (_InventoryItemMasterDataProvider != null)
                    InventoryItemMasterCollection = _InventoryItemMasterDataProvider.GetInventoryItemSearchList(searchRequest);
                else
                {
                    InventoryItemMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryItemMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryItemMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryItemMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryItemMasterCollection;
        }
		/// <summary>
		/// Select a record from InventoryItemMaster table by ID
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<InventoryItemMaster> SelectByID(InventoryItemMaster item)
		{
			IBaseEntityResponse<InventoryItemMaster> entityResponse = new BaseEntityResponse<InventoryItemMaster>();
			try
			{
				 entityResponse = _InventoryItemMasterDataProvider.GetInventoryItemMasterByID(item);
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
        public IBaseEntityResponse<InventoryItemMaster> GetItemCode(InventoryItemMaster item)
        {
            IBaseEntityResponse<InventoryItemMaster> entityResponse = new BaseEntityResponse<InventoryItemMaster>();
            try
            {
                entityResponse = _InventoryItemMasterDataProvider.GetItemCode(item);
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
        public IBaseEntityCollectionResponse<InventoryItemMaster> GetInventoryItemSearchListForSale(InventoryItemMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryItemMaster> InventoryItemMasterCollection = new BaseEntityCollectionResponse<InventoryItemMaster>();
            try
            {
                if (_InventoryItemMasterDataProvider != null)
                    InventoryItemMasterCollection = _InventoryItemMasterDataProvider.GetInventoryItemSearchListForSale(searchRequest);
                else
                {
                    InventoryItemMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryItemMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryItemMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryItemMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryItemMasterCollection;
        }



        public IBaseEntityCollectionResponse<InventoryItemMaster> GetBatchList(InventoryItemMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryItemMaster> InventoryItemMasterCollection = new BaseEntityCollectionResponse<InventoryItemMaster>();
            try
            {
                if (_InventoryItemMasterDataProvider != null)
                    InventoryItemMasterCollection = _InventoryItemMasterDataProvider.GetBatchList(searchRequest);
                else
                {
                    InventoryItemMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryItemMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryItemMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryItemMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryItemMasterCollection;
        }
        /// Select all record from InventoryItemMaster table.        
        public IBaseEntityCollectionResponse<InventoryItemMaster> GetInventoryItemMasterList(InventoryItemMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryItemMaster> InventoryItemMasterCollection = new BaseEntityCollectionResponse<InventoryItemMaster>();
            try
            {
                if (_InventoryItemMasterDataProvider != null)
                    InventoryItemMasterCollection = _InventoryItemMasterDataProvider.GetInventoryItemMasterList(searchRequest);
                else
                {
                    InventoryItemMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryItemMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryItemMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryItemMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryItemMasterCollection;
        }

        public IBaseEntityCollectionResponse<InventoryItemMaster> GetInventoryItemSearchListForEstimation(InventoryItemMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryItemMaster> InventoryItemMasterCollection = new BaseEntityCollectionResponse<InventoryItemMaster>();
            try
            {
                if (_InventoryItemMasterDataProvider != null)
                    InventoryItemMasterCollection = _InventoryItemMasterDataProvider.GetInventoryItemSearchListForEstimation(searchRequest);
                else
                {
                    InventoryItemMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryItemMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryItemMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryItemMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryItemMasterCollection;
        }

        public IBaseEntityCollectionResponse<InventoryItemMaster> GetItemFamilySearchList(InventoryItemMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryItemMaster> InventoryItemFamilyMasterCollection = new BaseEntityCollectionResponse<InventoryItemMaster>();
            try
            {
                if (_InventoryItemMasterDataProvider != null)
                    InventoryItemFamilyMasterCollection = _InventoryItemMasterDataProvider.GetItemFamilySearchList(searchRequest);
                else
                {
                    InventoryItemFamilyMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryItemFamilyMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryItemFamilyMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryItemFamilyMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryItemFamilyMasterCollection;
        }

        public IBaseEntityCollectionResponse<InventoryItemMaster> GetItemPackingUnitSearchList(InventoryItemMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryItemMaster> itemPackingUnitCollection = new BaseEntityCollectionResponse<InventoryItemMaster>();
            try
            {
                if (_InventoryItemMasterDataProvider != null)
                    itemPackingUnitCollection = _InventoryItemMasterDataProvider.GetItemPackingUnitSearchList(searchRequest);
                else
                {
                    itemPackingUnitCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    itemPackingUnitCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                itemPackingUnitCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                itemPackingUnitCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return itemPackingUnitCollection;
        }

        public IBaseEntityCollectionResponse<InventoryItemMaster> GetItemPackingTypeSearchList(InventoryItemMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryItemMaster> itemPackingTypeCollection = new BaseEntityCollectionResponse<InventoryItemMaster>();
            try
            {
                if (_InventoryItemMasterDataProvider != null)
                    itemPackingTypeCollection = _InventoryItemMasterDataProvider.GetItemPackingTypeSearchList(searchRequest);
                else
                {
                    itemPackingTypeCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    itemPackingTypeCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                itemPackingTypeCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                itemPackingTypeCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return itemPackingTypeCollection;
        }

        public IBaseEntityResponse<InventoryItemMaster> CheckFocusOnAction(InventoryItemMaster item)
        {
            IBaseEntityResponse<InventoryItemMaster> entityResponse = new BaseEntityResponse<InventoryItemMaster>();
            try
            {
                entityResponse = _InventoryItemMasterDataProvider.CheckFocusOnAction(item);
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
