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
    public class InventoryItemSaleReturnMasterBA : IInventoryItemSaleReturnMasterBA
    {
        IInventoryItemSaleReturnMasterDataProvider _inventoryItemSaleReturnMasterDataProvider;
        IInventoryItemSaleReturnMasterBR _inventoryItemSaleReturnMasterBR;
        private ILogger _logException;

        public InventoryItemSaleReturnMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _inventoryItemSaleReturnMasterBR = new InventoryItemSaleReturnMasterBR();
            _inventoryItemSaleReturnMasterDataProvider = new InventoryItemSaleReturnMasterDataProvider();
        }

        
        /// Create new record of InventoryItemSaleReturnMaster.        
        public IBaseEntityResponse<InventoryItemSaleReturnMaster> InsertInventoryItemSaleReturnMaster(InventoryItemSaleReturnMaster item)
        {
            IBaseEntityResponse<InventoryItemSaleReturnMaster> entityResponse = new BaseEntityResponse<InventoryItemSaleReturnMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _inventoryItemSaleReturnMasterBR.InsertInventoryItemSaleReturnMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _inventoryItemSaleReturnMasterDataProvider.InsertInventoryItemSaleReturnMaster(item);
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
       
        /// Update a specific record  of InventoryItemSaleReturnMaster.       
        public IBaseEntityResponse<InventoryItemSaleReturnMaster> UpdateInventoryItemSaleReturnMaster(InventoryItemSaleReturnMaster item)
        {
            IBaseEntityResponse<InventoryItemSaleReturnMaster> entityResponse = new BaseEntityResponse<InventoryItemSaleReturnMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _inventoryItemSaleReturnMasterBR.UpdateInventoryItemSaleReturnMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _inventoryItemSaleReturnMasterDataProvider.UpdateInventoryItemSaleReturnMaster(item);
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
        
        /// Delete a selected record from InventoryItemSaleReturnMaster.        
        public IBaseEntityResponse<InventoryItemSaleReturnMaster> DeleteInventoryItemSaleReturnMaster(InventoryItemSaleReturnMaster item)
        {
            IBaseEntityResponse<InventoryItemSaleReturnMaster> entityResponse = new BaseEntityResponse<InventoryItemSaleReturnMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _inventoryItemSaleReturnMasterBR.DeleteInventoryItemSaleReturnMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _inventoryItemSaleReturnMasterDataProvider.DeleteInventoryItemSaleReturnMaster(item);
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
        
        /// Select all record from InventoryItemSaleReturnMaster table with search parameters.        
        public IBaseEntityCollectionResponse<InventoryItemSaleReturnMaster> GetInventoryItemSaleReturnMasterBySearch(InventoryItemSaleReturnMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryItemSaleReturnMaster> InventoryItemSaleReturnMasterCollection = new BaseEntityCollectionResponse<InventoryItemSaleReturnMaster>();
            try
            {
                if (_inventoryItemSaleReturnMasterDataProvider != null)
                    InventoryItemSaleReturnMasterCollection = _inventoryItemSaleReturnMasterDataProvider.GetInventoryItemSaleReturnMasterBySearch(searchRequest);
                else
                {
                    InventoryItemSaleReturnMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryItemSaleReturnMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryItemSaleReturnMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryItemSaleReturnMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryItemSaleReturnMasterCollection;
        }

        /// Select a record from InventoryItemSaleReturnMaster table by ID        
        public IBaseEntityCollectionResponse<InventoryItemSaleReturnMaster> GetInventoryItemSaleReturnMasterByID(InventoryItemSaleReturnMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryItemSaleReturnMaster> entityResponse = new BaseEntityCollectionResponse<InventoryItemSaleReturnMaster>();
            try
            {
                entityResponse = _inventoryItemSaleReturnMasterDataProvider.GetInventoryItemSaleReturnMasterByID(searchRequest);
            }
            catch (Exception ex)
            {
                entityResponse.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                entityResponse.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return entityResponse;
        }

        //Search List.
        public IBaseEntityCollectionResponse<InventoryItemSaleReturnMaster> GetInventoryItemSaleReturnMasterSearchList(InventoryItemSaleReturnMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryItemSaleReturnMaster> saleReturnCollection = new BaseEntityCollectionResponse<InventoryItemSaleReturnMaster>();
            try
            {
                if (_inventoryItemSaleReturnMasterDataProvider != null)
                    saleReturnCollection = _inventoryItemSaleReturnMasterDataProvider.GetInventoryItemSaleReturnMasterSearchList(searchRequest);
                else
                {
                    saleReturnCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    saleReturnCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                saleReturnCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                saleReturnCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return saleReturnCollection;
        }

        /// Select all record from InventoryItemSaleReturnMaster table with search parameters.        
        public IBaseEntityCollectionResponse<InventoryItemSaleReturnMaster> GetBillDetailsByID(InventoryItemSaleReturnMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryItemSaleReturnMaster> InventoryItemSaleReturnMasterCollection = new BaseEntityCollectionResponse<InventoryItemSaleReturnMaster>();
            try
            {
                if (_inventoryItemSaleReturnMasterDataProvider != null)
                    InventoryItemSaleReturnMasterCollection = _inventoryItemSaleReturnMasterDataProvider.GetBillDetailsByID(searchRequest);
                else
                {
                    InventoryItemSaleReturnMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryItemSaleReturnMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryItemSaleReturnMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryItemSaleReturnMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryItemSaleReturnMasterCollection;
        }       
        
        /// Select a record from InventoryItemSaleReturnMaster table by ID       
        public IBaseEntityResponse<InventoryItemSaleReturnMaster> GetInventoryItemQuantity(InventoryItemSaleReturnMaster item)
        {
            IBaseEntityResponse<InventoryItemSaleReturnMaster> entityResponse = new BaseEntityResponse<InventoryItemSaleReturnMaster>();
            try
            {
                entityResponse = _inventoryItemSaleReturnMasterDataProvider.GetInventoryItemQuantity(item);
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
        public IBaseEntityCollectionResponse<InventoryItemSaleReturnMaster> GetInventoryItemSaleReturnMasterBillPrintList(InventoryItemSaleReturnMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryItemSaleReturnMaster> InventoryItemSaleReturnMasterCollection = new BaseEntityCollectionResponse<InventoryItemSaleReturnMaster>();
            try
            {
                if (_inventoryItemSaleReturnMasterDataProvider != null)
                    InventoryItemSaleReturnMasterCollection = _inventoryItemSaleReturnMasterDataProvider.GetInventoryItemSaleReturnMasterBillPrintList(searchRequest);
                else
                {
                    InventoryItemSaleReturnMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryItemSaleReturnMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryItemSaleReturnMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryItemSaleReturnMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryItemSaleReturnMasterCollection;
        }
        //For Inventory Sale Report To operator
        public IBaseEntityCollectionResponse<InventoryItemSaleReturnMaster> GetInventorySalesReportToOperator(InventoryItemSaleReturnMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryItemSaleReturnMaster> InventoryItemSaleReturnMasterCollection = new BaseEntityCollectionResponse<InventoryItemSaleReturnMaster>();
            try
            {
                if (_inventoryItemSaleReturnMasterDataProvider != null)
                    InventoryItemSaleReturnMasterCollection = _inventoryItemSaleReturnMasterDataProvider.GetInventorySalesReportToOperator(searchRequest);
                else
                {
                    InventoryItemSaleReturnMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryItemSaleReturnMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryItemSaleReturnMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryItemSaleReturnMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryItemSaleReturnMasterCollection;
        }

        
    }
}
