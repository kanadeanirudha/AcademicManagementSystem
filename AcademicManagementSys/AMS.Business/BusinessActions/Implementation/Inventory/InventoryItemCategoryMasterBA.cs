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
    public class InventoryItemCategoryMasterBA : IInventoryItemCategoryMasterBA
    {
        IInventoryItemCategoryMasterDataProvider _InventoryItemCategoryMasterDataProvider;
        IInventoryItemCategoryMasterBR _InventoryItemCategoryMasterBR;
        private ILogger _logException;
        public InventoryItemCategoryMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _InventoryItemCategoryMasterBR = new InventoryItemCategoryMasterBR();
            _InventoryItemCategoryMasterDataProvider = new InventoryItemCategoryMasterDataProvider();
        }
        /// <summary>
        /// Create new record of InventoryItemCategoryMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryItemCategoryMaster> InsertInventoryItemCategoryMaster(InventoryItemCategoryMaster item)
        {
            IBaseEntityResponse<InventoryItemCategoryMaster> entityResponse = new BaseEntityResponse<InventoryItemCategoryMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryItemCategoryMasterBR.InsertInventoryItemCategoryMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryItemCategoryMasterDataProvider.InsertInventoryItemCategoryMaster(item);
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
        /// Update a specific record  of InventoryItemCategoryMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryItemCategoryMaster> UpdateInventoryItemCategoryMaster(InventoryItemCategoryMaster item)
        {
            IBaseEntityResponse<InventoryItemCategoryMaster> entityResponse = new BaseEntityResponse<InventoryItemCategoryMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryItemCategoryMasterBR.UpdateInventoryItemCategoryMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryItemCategoryMasterDataProvider.UpdateInventoryItemCategoryMaster(item);
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
        /// Delete a selected record from InventoryItemCategoryMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryItemCategoryMaster> DeleteInventoryItemCategoryMaster(InventoryItemCategoryMaster item)
        {
            IBaseEntityResponse<InventoryItemCategoryMaster> entityResponse = new BaseEntityResponse<InventoryItemCategoryMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryItemCategoryMasterBR.DeleteInventoryItemCategoryMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryItemCategoryMasterDataProvider.DeleteInventoryItemCategoryMaster(item);
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
        /// Select all record from InventoryItemCategoryMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<InventoryItemCategoryMaster> GetBySearch(InventoryItemCategoryMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryItemCategoryMaster> InventoryItemCategoryMasterCollection = new BaseEntityCollectionResponse<InventoryItemCategoryMaster>();
            try
            {
                if (_InventoryItemCategoryMasterDataProvider != null)
                    InventoryItemCategoryMasterCollection = _InventoryItemCategoryMasterDataProvider.GetInventoryItemCategoryMasterBySearch(searchRequest);
                else
                {
                    InventoryItemCategoryMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryItemCategoryMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryItemCategoryMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryItemCategoryMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryItemCategoryMasterCollection;
        }

        public IBaseEntityCollectionResponse<InventoryItemCategoryMaster> GetInventoryItemCategoryMasterList(InventoryItemCategoryMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryItemCategoryMaster> InventoryItemCategoryMasterCollection = new BaseEntityCollectionResponse<InventoryItemCategoryMaster>();
            try
            {
                if (_InventoryItemCategoryMasterDataProvider != null)
                    InventoryItemCategoryMasterCollection = _InventoryItemCategoryMasterDataProvider.GetInventoryItemCategoryMasterList(searchRequest);
                else
                {
                    InventoryItemCategoryMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryItemCategoryMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryItemCategoryMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryItemCategoryMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryItemCategoryMasterCollection;
        }
        /// <summary>
        /// Select a record from InventoryItemCategoryMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryItemCategoryMaster> SelectByID(InventoryItemCategoryMaster item)
        {
            IBaseEntityResponse<InventoryItemCategoryMaster> entityResponse = new BaseEntityResponse<InventoryItemCategoryMaster>();
            try
            {
                entityResponse = _InventoryItemCategoryMasterDataProvider.GetInventoryItemCategoryMasterByID(item);
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
