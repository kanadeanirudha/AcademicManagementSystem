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
    public class InventoryWeighingDataBA : IInventoryWeighingDataBA
    {
        IInventoryWeighingDataDataProvider _InventoryWeighingDataDataProvider;
        IInventoryWeighingDataBR _InventoryWeighingDataBR;
        private ILogger _logException;
        public InventoryWeighingDataBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _InventoryWeighingDataBR = new InventoryWeighingDataBR();
            _InventoryWeighingDataDataProvider = new InventoryWeighingDataDataProvider();
        }
        /// <summary>
        /// Create new record of InventoryWeighingData.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryWeighingData> InsertInventoryWeighingData(InventoryWeighingData item)
        {
            IBaseEntityResponse<InventoryWeighingData> entityResponse = new BaseEntityResponse<InventoryWeighingData>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryWeighingDataBR.InsertInventoryWeighingDataValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryWeighingDataDataProvider.InsertInventoryWeighingData(item);
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
        /// Update a specific record  of InventoryWeighingData.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryWeighingData> UpdateInventoryWeighingData(InventoryWeighingData item)
        {
            IBaseEntityResponse<InventoryWeighingData> entityResponse = new BaseEntityResponse<InventoryWeighingData>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryWeighingDataBR.UpdateInventoryWeighingDataValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryWeighingDataDataProvider.UpdateInventoryWeighingData(item);
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
        /// Delete a selected record from InventoryWeighingData.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryWeighingData> DeleteInventoryWeighingData(InventoryWeighingData item)
        {
            IBaseEntityResponse<InventoryWeighingData> entityResponse = new BaseEntityResponse<InventoryWeighingData>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryWeighingDataBR.DeleteInventoryWeighingDataValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryWeighingDataDataProvider.DeleteInventoryWeighingData(item);
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
        /// Select all record from InventoryWeighingData table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<InventoryWeighingData> GetBySearch(InventoryWeighingDataSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryWeighingData> InventoryWeighingDataCollection = new BaseEntityCollectionResponse<InventoryWeighingData>();
            try
            {
                if (_InventoryWeighingDataDataProvider != null)
                    InventoryWeighingDataCollection = _InventoryWeighingDataDataProvider.GetInventoryWeighingDataBySearch(searchRequest);
                else
                {
                    InventoryWeighingDataCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryWeighingDataCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryWeighingDataCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryWeighingDataCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryWeighingDataCollection;
        }
        /// <summary>
        /// Select all record from InventoryWeighingData table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<InventoryWeighingData> GetInventoryItemSearchList(InventoryWeighingDataSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryWeighingData> InventoryWeighingDataCollection = new BaseEntityCollectionResponse<InventoryWeighingData>();
            try
            {
                if (_InventoryWeighingDataDataProvider != null)
                    InventoryWeighingDataCollection = _InventoryWeighingDataDataProvider.GetInventoryItemSearchList(searchRequest);
                else
                {
                    InventoryWeighingDataCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryWeighingDataCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryWeighingDataCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryWeighingDataCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryWeighingDataCollection;
        }
        /// <summary>
        /// Select a record from InventoryWeighingData table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryWeighingData> SelectByID(InventoryWeighingData item)
        {
            IBaseEntityResponse<InventoryWeighingData> entityResponse = new BaseEntityResponse<InventoryWeighingData>();
            try
            {
                entityResponse = _InventoryWeighingDataDataProvider.GetInventoryWeighingDataByID(item);
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
