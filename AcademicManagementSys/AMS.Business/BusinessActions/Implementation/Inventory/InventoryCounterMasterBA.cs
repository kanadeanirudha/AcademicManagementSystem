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
    public class InventoryCounterMasterBA : IInventoryCounterMasterBA
    {
        IInventoryCounterMasterDataProvider _InventoryCounterMasterDataProvider;
        IInventoryCounterMasterBR _InventoryCounterMasterBR;
        private ILogger _logException;
        public InventoryCounterMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _InventoryCounterMasterBR = new InventoryCounterMasterBR();
            _InventoryCounterMasterDataProvider = new InventoryCounterMasterDataProvider();
        }
        /// <summary>
        /// Create new record of InventoryCounterMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryCounterMaster> InsertInventoryCounterMaster(InventoryCounterMaster item)
        {
            IBaseEntityResponse<InventoryCounterMaster> entityResponse = new BaseEntityResponse<InventoryCounterMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryCounterMasterBR.InsertInventoryCounterMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryCounterMasterDataProvider.InsertInventoryCounterMaster(item);
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
        /// Update a specific record  of InventoryCounterMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryCounterMaster> UpdateInventoryCounterMaster(InventoryCounterMaster item)
        {
            IBaseEntityResponse<InventoryCounterMaster> entityResponse = new BaseEntityResponse<InventoryCounterMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryCounterMasterBR.UpdateInventoryCounterMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryCounterMasterDataProvider.UpdateInventoryCounterMaster(item);
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
        /// Delete a selected record from InventoryCounterMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryCounterMaster> DeleteInventoryCounterMaster(InventoryCounterMaster item)
        {
            IBaseEntityResponse<InventoryCounterMaster> entityResponse = new BaseEntityResponse<InventoryCounterMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryCounterMasterBR.DeleteInventoryCounterMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryCounterMasterDataProvider.DeleteInventoryCounterMaster(item);
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
        /// Select all record from InventoryCounterMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<InventoryCounterMaster> GetBySearch(InventoryCounterMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryCounterMaster> InventoryCounterMasterCollection = new BaseEntityCollectionResponse<InventoryCounterMaster>();
            try
            {
                if (_InventoryCounterMasterDataProvider != null)
                    InventoryCounterMasterCollection = _InventoryCounterMasterDataProvider.GetInventoryCounterMasterBySearch(searchRequest);
                else
                {
                    InventoryCounterMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryCounterMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryCounterMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryCounterMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryCounterMasterCollection;
        }

        public IBaseEntityCollectionResponse<InventoryCounterMaster> GetInventoryCounterMasterList(InventoryCounterMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryCounterMaster> InventoryCounterMasterCollection = new BaseEntityCollectionResponse<InventoryCounterMaster>();
            try
            {
                if (_InventoryCounterMasterDataProvider != null)
                    InventoryCounterMasterCollection = _InventoryCounterMasterDataProvider.GetInventoryCounterMasterList(searchRequest);
                else
                {
                    InventoryCounterMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryCounterMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryCounterMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryCounterMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryCounterMasterCollection;
        }
        /// <summary>
        /// Select a record from InventoryCounterMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryCounterMaster> SelectByID(InventoryCounterMaster item)
        {
            IBaseEntityResponse<InventoryCounterMaster> entityResponse = new BaseEntityResponse<InventoryCounterMaster>();
            try
            {
                entityResponse = _InventoryCounterMasterDataProvider.GetInventoryCounterMasterByID(item);
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
