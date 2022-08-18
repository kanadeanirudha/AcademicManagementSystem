
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
    public class InventoryMachineMasterBA : IInventoryMachineMasterBA
    {
        IInventoryMachineMasterDataProvider _InventoryMachineMasterDataProvider;
        IInventoryMachineMasterBR _InventoryMachineMasterBR;
        private ILogger _logException;
        public InventoryMachineMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _InventoryMachineMasterBR = new InventoryMachineMasterBR();
            _InventoryMachineMasterDataProvider = new InventoryMachineMasterDataProvider();
        }
        /// <summary>
        /// Create new record of InventoryMachineMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryMachineMaster> InsertInventoryMachineMaster(InventoryMachineMaster item)
        {
            IBaseEntityResponse<InventoryMachineMaster> entityResponse = new BaseEntityResponse<InventoryMachineMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryMachineMasterBR.InsertInventoryMachineMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryMachineMasterDataProvider.InsertInventoryMachineMaster(item);
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
        /// Update a specific record  of InventoryMachineMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryMachineMaster> UpdateInventoryMachineMaster(InventoryMachineMaster item)
        {
            IBaseEntityResponse<InventoryMachineMaster> entityResponse = new BaseEntityResponse<InventoryMachineMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryMachineMasterBR.UpdateInventoryMachineMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryMachineMasterDataProvider.UpdateInventoryMachineMaster(item);
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
        /// Delete a selected record from InventoryMachineMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryMachineMaster> DeleteInventoryMachineMaster(InventoryMachineMaster item)
        {
            IBaseEntityResponse<InventoryMachineMaster> entityResponse = new BaseEntityResponse<InventoryMachineMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryMachineMasterBR.DeleteInventoryMachineMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryMachineMasterDataProvider.DeleteInventoryMachineMaster(item);
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
        /// Select all record from InventoryMachineMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<InventoryMachineMaster> GetBySearch(InventoryMachineMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryMachineMaster> InventoryMachineMasterCollection = new BaseEntityCollectionResponse<InventoryMachineMaster>();
            try
            {
                if (_InventoryMachineMasterDataProvider != null)
                    InventoryMachineMasterCollection = _InventoryMachineMasterDataProvider.GetInventoryMachineMasterBySearch(searchRequest);
                else
                {
                    InventoryMachineMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryMachineMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryMachineMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryMachineMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryMachineMasterCollection;
        }

        public IBaseEntityCollectionResponse<InventoryMachineMaster> GetInventoryMachineMasterList(InventoryMachineMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryMachineMaster> InventoryMachineMasterCollection = new BaseEntityCollectionResponse<InventoryMachineMaster>();
            try
            {
                if (_InventoryMachineMasterDataProvider != null)
                    InventoryMachineMasterCollection = _InventoryMachineMasterDataProvider.GetInventoryMachineMasterList(searchRequest);
                else
                {
                    InventoryMachineMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryMachineMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryMachineMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryMachineMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryMachineMasterCollection;
        }
        /// <summary>
        /// Select a record from InventoryMachineMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// 



        public IBaseEntityCollectionResponse<InventoryMachineMaster> GetInventoryMachineCounterApplicableList(InventoryMachineMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryMachineMaster> InventoryMachineMasterCollection = new BaseEntityCollectionResponse<InventoryMachineMaster>();
            try
            {
                if (_InventoryMachineMasterDataProvider != null)
                    InventoryMachineMasterCollection = _InventoryMachineMasterDataProvider.GetInventoryMachineCounterApplicableList(searchRequest);
                else
                {
                    InventoryMachineMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryMachineMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryMachineMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryMachineMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryMachineMasterCollection;
        }
        public IBaseEntityResponse<InventoryMachineMaster> SelectByID(InventoryMachineMaster item)
        {
            IBaseEntityResponse<InventoryMachineMaster> entityResponse = new BaseEntityResponse<InventoryMachineMaster>();
            try
            {
                entityResponse = _InventoryMachineMasterDataProvider.GetInventoryMachineMasterByID(item);
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
