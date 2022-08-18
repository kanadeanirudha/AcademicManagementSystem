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
    public class InventoryReportMasterBA : IInventoryReportMasterBA
    {
        IInventoryReportMasterDataProvider _inventoryReportMasterDataProvider;
        IInventoryReportMasterBR _inventoryReportMasterBR;
        private ILogger _logException;

        public InventoryReportMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _inventoryReportMasterBR = new InventoryReportMasterBR();
            _inventoryReportMasterDataProvider = new InventoryReportMasterDataProvider();
        }

        // InventoryReportMaster Method
        #region InventoryReportMaster

        /// Create new record of InventoryReportMaster.        
        public IBaseEntityResponse<InventoryReportMaster> InsertInventoryReportMaster(InventoryReportMaster item)
        {
            IBaseEntityResponse<InventoryReportMaster> entityResponse = new BaseEntityResponse<InventoryReportMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _inventoryReportMasterBR.InsertInventoryReportMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _inventoryReportMasterDataProvider.InsertInventoryReportMaster(item);
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

        /// Update a specific record  of InventoryReportMaster.       
        public IBaseEntityResponse<InventoryReportMaster> UpdateInventoryReportMaster(InventoryReportMaster item)
        {
            IBaseEntityResponse<InventoryReportMaster> entityResponse = new BaseEntityResponse<InventoryReportMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _inventoryReportMasterBR.UpdateInventoryReportMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _inventoryReportMasterDataProvider.UpdateInventoryReportMaster(item);
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

        /// Delete a selected record from InventoryReportMaster.        
        public IBaseEntityResponse<InventoryReportMaster> DeleteInventoryReportMaster(InventoryReportMaster item)
        {
            IBaseEntityResponse<InventoryReportMaster> entityResponse = new BaseEntityResponse<InventoryReportMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _inventoryReportMasterBR.DeleteInventoryReportMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _inventoryReportMasterDataProvider.DeleteInventoryReportMaster(item);
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

        
        /// Select a record from InventoryReportMaster table by ID        
        public IBaseEntityResponse<InventoryReportMaster> SelectInventoryReportMasterByID(InventoryReportMaster item)
        {
            IBaseEntityResponse<InventoryReportMaster> entityResponse = new BaseEntityResponse<InventoryReportMaster>();
            try
            {
                entityResponse = _inventoryReportMasterDataProvider.GetInventoryReportMasterByID(item);
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

        // Select all record from InventoryReportMaster table to search list.
        public IBaseEntityCollectionResponse<InventoryReportMaster> GetInventoryReportMasterSearchList(InventoryReportMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryReportMaster> InventoryReportMasterCollection = new BaseEntityCollectionResponse<InventoryReportMaster>();
            try
            {
                if (_inventoryReportMasterDataProvider != null)
                    InventoryReportMasterCollection = _inventoryReportMasterDataProvider.GetInventoryReportMasterSearchList(searchRequest);
                else
                {
                    InventoryReportMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryReportMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryReportMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryReportMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryReportMasterCollection;
        }


        /// Select all record from item wise consumption.        
        public IBaseEntityCollectionResponse<InventoryReportMaster> GetItemWiseConsumptionBySearch(InventoryReportMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryReportMaster> ItemWiseConsumptionCollection = new BaseEntityCollectionResponse<InventoryReportMaster>();
            try
            {
                if (_inventoryReportMasterDataProvider != null)
                    ItemWiseConsumptionCollection = _inventoryReportMasterDataProvider.GetItemWiseConsumptionBySearch(searchRequest);
                else
                {
                    ItemWiseConsumptionCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    ItemWiseConsumptionCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                ItemWiseConsumptionCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                ItemWiseConsumptionCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return ItemWiseConsumptionCollection;
        }

        /// Select all record from Daily Rate Change.        
        public IBaseEntityCollectionResponse<InventoryReportMaster> GetDailyRateChangeBySearch(InventoryReportMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryReportMaster> DailyRateChangeCollection = new BaseEntityCollectionResponse<InventoryReportMaster>();
            try
            {
                if (_inventoryReportMasterDataProvider != null)
                    DailyRateChangeCollection = _inventoryReportMasterDataProvider.GetDailyRateChangeBySearch(searchRequest);
                else
                {
                    DailyRateChangeCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    DailyRateChangeCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                DailyRateChangeCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                DailyRateChangeCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return DailyRateChangeCollection;
        }


        /// Select all record from Dump And Shrink Report.        
        public IBaseEntityCollectionResponse<InventoryReportMaster> GetDumpAndShrinkReportBySearch(InventoryReportMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryReportMaster> DumpAndShrinkReportCollection = new BaseEntityCollectionResponse<InventoryReportMaster>();
            try
            {
                if (_inventoryReportMasterDataProvider != null)
                    DumpAndShrinkReportCollection = _inventoryReportMasterDataProvider.GetDumpAndShrinkReportBySearch(searchRequest);
                else
                {
                    DumpAndShrinkReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    DumpAndShrinkReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                DumpAndShrinkReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                DumpAndShrinkReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return DumpAndShrinkReportCollection;
        }

        ///   For DailyItemRateChange Report     
        public IBaseEntityCollectionResponse<InventoryReportMaster> GetDailyItemRateChangeReportBySearch(InventoryReportMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryReportMaster> DailyRateChangeCollection = new BaseEntityCollectionResponse<InventoryReportMaster>();
            try
            {
                if (_inventoryReportMasterDataProvider != null)
                    DailyRateChangeCollection = _inventoryReportMasterDataProvider.GetDailyItemRateChangeReportBySearch(searchRequest);
                else
                {
                    DailyRateChangeCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    DailyRateChangeCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                DailyRateChangeCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                DailyRateChangeCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return DailyRateChangeCollection;
        }


        //For Below Indend Level Report.                
        public IBaseEntityCollectionResponse<InventoryReportMaster> GetBelowIndendLevelReportBySearch(InventoryReportMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryReportMaster> BelowIndendLevelReportCollection = new BaseEntityCollectionResponse<InventoryReportMaster>();
            try
            {
                if (_inventoryReportMasterDataProvider != null)
                    BelowIndendLevelReportCollection = _inventoryReportMasterDataProvider.GetBelowIndendLevelReportBySearch(searchRequest);
                else
                {
                    BelowIndendLevelReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    BelowIndendLevelReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                BelowIndendLevelReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                BelowIndendLevelReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return BelowIndendLevelReportCollection;
        }

        #endregion
    }
}
