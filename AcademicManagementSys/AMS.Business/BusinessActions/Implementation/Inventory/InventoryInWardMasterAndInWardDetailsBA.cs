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
    public class InventoryInWardMasterAndInWardDetailsBA : IInventoryInWardMasterAndInWardDetailsBA
    {
        IInventoryInWardMasterAndInWardDetailsDataProvider _inventoryInWardMasterAndInWardDetailsDataProvider;
        IInventoryInWardMasterAndInWardDetailsBR _inventoryInWardMasterAndInWardDetailsBR;
        private ILogger _logException;
        public InventoryInWardMasterAndInWardDetailsBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _inventoryInWardMasterAndInWardDetailsBR = new InventoryInWardMasterAndInWardDetailsBR();
            _inventoryInWardMasterAndInWardDetailsDataProvider = new InventoryInWardMasterAndInWardDetailsDataProvider();
        }


        // InventoryInWardMaster Method
        #region InventoryInWardMaster                  
        public IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> InsertInventoryInWardMaster(InventoryInWardMasterAndInWardDetails item)
        {
            IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> entityResponse = new BaseEntityResponse<InventoryInWardMasterAndInWardDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _inventoryInWardMasterAndInWardDetailsBR.InsertInventoryInWardMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _inventoryInWardMasterAndInWardDetailsDataProvider.InsertInventoryInWardMaster(item);
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

        /// Update a specific record  of InventoryInWardMaster.       
        public IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> UpdateInventoryInWardMaster(InventoryInWardMasterAndInWardDetails item)
        {
            IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> entityResponse = new BaseEntityResponse<InventoryInWardMasterAndInWardDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _inventoryInWardMasterAndInWardDetailsBR.UpdateInventoryInWardMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _inventoryInWardMasterAndInWardDetailsDataProvider.UpdateInventoryInWardMaster(item);
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

        /// Delete a selected record from InventoryInWardMaster.        
        public IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> DeleteInventoryInWardMaster(InventoryInWardMasterAndInWardDetails item)
        {
            IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> entityResponse = new BaseEntityResponse<InventoryInWardMasterAndInWardDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _inventoryInWardMasterAndInWardDetailsBR.DeleteInventoryInWardMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _inventoryInWardMasterAndInWardDetailsDataProvider.DeleteInventoryInWardMaster(item);
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

        /// Select all record from InventoryInWardMaster.        
        public IBaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails> GetInventoryInWardMasterBySearch(InventoryInWardMasterAndInWardDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails> inWardMasterCollection = new BaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails>();
            try
            {
                if (_inventoryInWardMasterAndInWardDetailsDataProvider != null)
                    inWardMasterCollection = _inventoryInWardMasterAndInWardDetailsDataProvider.GetInventoryInWardMasterBySearch(searchRequest);
                else
                {
                    inWardMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    inWardMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                inWardMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                inWardMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return inWardMasterCollection;
        }

        /// Select a record from InventoryInWardMaster       
        public IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> GetInventoryInWardMasterByID(InventoryInWardMasterAndInWardDetails item)
        {
            IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> entityResponse = new BaseEntityResponse<InventoryInWardMasterAndInWardDetails>();
            try
            {
                entityResponse = _inventoryInWardMasterAndInWardDetailsDataProvider.GetInventoryInWardMasterByID(item);
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



        public IBaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails> GetInWardRequestForApproval(InventoryInWardMasterAndInWardDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails> InventoryDumpAndShrinkMasterAndDetailsCollection = new BaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails>();
            try
            {
                if (_inventoryInWardMasterAndInWardDetailsDataProvider != null)
                    InventoryDumpAndShrinkMasterAndDetailsCollection = _inventoryInWardMasterAndInWardDetailsDataProvider.GetInWardRequestForApproval(searchRequest);
                else
                {
                    InventoryDumpAndShrinkMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryDumpAndShrinkMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryDumpAndShrinkMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryDumpAndShrinkMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryDumpAndShrinkMasterAndDetailsCollection;
        }                




        // InventoryInWardMaster table to search list.
        public IBaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails> GetInventoryInWardMasterSearchList(InventoryInWardMasterAndInWardDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails> inWardMasterCollection = new BaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails>();
            try
            {
                if (_inventoryInWardMasterAndInWardDetailsDataProvider != null)
                    inWardMasterCollection = _inventoryInWardMasterAndInWardDetailsDataProvider.GetInventoryInWardMasterSearchList(searchRequest);
                else
                {
                    inWardMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    inWardMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                inWardMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                inWardMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return inWardMasterCollection;
        }
        #endregion



        // InventoryInWardDetails Method
        #region InventoryInWardDetails
        public IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> InsertInventoryInWardDetails(InventoryInWardMasterAndInWardDetails item)
        {
            IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> entityResponse = new BaseEntityResponse<InventoryInWardMasterAndInWardDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _inventoryInWardMasterAndInWardDetailsBR.InsertInventoryInWardDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _inventoryInWardMasterAndInWardDetailsDataProvider.InsertInventoryInWardDetails(item);
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

        /// Update a specific record  of InventoryInWardMaster.       
        public IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> UpdateInventoryInWardDetails(InventoryInWardMasterAndInWardDetails item)
        {
            IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> entityResponse = new BaseEntityResponse<InventoryInWardMasterAndInWardDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _inventoryInWardMasterAndInWardDetailsBR.UpdateInventoryInWardDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _inventoryInWardMasterAndInWardDetailsDataProvider.UpdateInventoryInWardDetails(item);
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

        /// Delete a selected record from InventoryInWardDetails.        
        public IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> DeleteInventoryInWardDetails(InventoryInWardMasterAndInWardDetails item)
        {
            IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> entityResponse = new BaseEntityResponse<InventoryInWardMasterAndInWardDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _inventoryInWardMasterAndInWardDetailsBR.DeleteInventoryInWardDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _inventoryInWardMasterAndInWardDetailsDataProvider.DeleteInventoryInWardDetails(item);
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

        /// Select all record from InventoryInWardDetails.        
        public IBaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails> GetInventoryInWardDetailsBySearch(InventoryInWardMasterAndInWardDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails> inWardDetailsCollection = new BaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails>();
            try
            {
                if (_inventoryInWardMasterAndInWardDetailsDataProvider != null)
                    inWardDetailsCollection = _inventoryInWardMasterAndInWardDetailsDataProvider.GetInventoryInWardDetailsBySearch(searchRequest);
                else
                {
                    inWardDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    inWardDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                inWardDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                inWardDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return inWardDetailsCollection;
        }

        /// Select a record from InventoryInWardDetails       
        public IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> GetInventoryInWardDetailsByID(InventoryInWardMasterAndInWardDetails item)
        {
            IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> entityResponse = new BaseEntityResponse<InventoryInWardMasterAndInWardDetails>();
            try
            {
                entityResponse = _inventoryInWardMasterAndInWardDetailsDataProvider.GetInventoryInWardDetailsByID(item);
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

        // InventoryInWardDetails table to search list.
        public IBaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails> GetInventoryInWardDetailsSearchList(InventoryInWardMasterAndInWardDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails> inWardDetailsCollection = new BaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails>();
            try
            {
                if (_inventoryInWardMasterAndInWardDetailsDataProvider != null)
                    inWardDetailsCollection = _inventoryInWardMasterAndInWardDetailsDataProvider.GetInventoryInWardDetailsSearchList(searchRequest);
                else
                {
                    inWardDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    inWardDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                inWardDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                inWardDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return inWardDetailsCollection;
        }

        //Laayer For InvSystemSettingMaster list
        public IBaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails> GetInvSystemSetting(InventoryInWardMasterAndInWardDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails> inWardDetailsCollection = new BaseEntityCollectionResponse<InventoryInWardMasterAndInWardDetails>();
            try
            {
                if (_inventoryInWardMasterAndInWardDetailsDataProvider != null)
                    inWardDetailsCollection = _inventoryInWardMasterAndInWardDetailsDataProvider.GetInvSystemSetting(searchRequest);
                else
                {
                    inWardDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    inWardDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                inWardDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                inWardDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return inWardDetailsCollection;
        }


        //Laayer For Inv Sync History Count  
        public IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> GetInvSyncHistoryCount(InventoryInWardMasterAndInWardDetails item)
        {
            IBaseEntityResponse<InventoryInWardMasterAndInWardDetails> entityResponse = new BaseEntityResponse<InventoryInWardMasterAndInWardDetails>();
            try
            {
                entityResponse = _inventoryInWardMasterAndInWardDetailsDataProvider.GetInvSyncHistoryCount(item);
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
        #endregion

    }
}
