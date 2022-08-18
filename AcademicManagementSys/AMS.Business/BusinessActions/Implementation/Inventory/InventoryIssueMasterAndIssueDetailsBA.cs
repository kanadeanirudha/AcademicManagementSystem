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
    public class InventoryIssueMasterAndIssueDetailsBA : IInventoryIssueMasterAndIssueDetailsBA
    {
        IInventoryIssueMasterAndIssueDetailsDataProvider _inventoryIssueMasterAndIssueDetailsDataProvider;
        IInventoryIssueMasterAndIssueDetailsBR _inventoryIssueMasterAndIssueDetailsBR;
        private ILogger _logException;

        public InventoryIssueMasterAndIssueDetailsBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _inventoryIssueMasterAndIssueDetailsBR = new InventoryIssueMasterAndIssueDetailsBR();
            _inventoryIssueMasterAndIssueDetailsDataProvider = new InventoryIssueMasterAndIssueDetailsDataProvider();
        }

        //Insert.
        public IBaseEntityResponse<InventoryIssueMasterAndIssueDetails> InsertInventoryIssueMaster(InventoryIssueMasterAndIssueDetails item)
        {
            IBaseEntityResponse<InventoryIssueMasterAndIssueDetails> entityResponse = new BaseEntityResponse<InventoryIssueMasterAndIssueDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _inventoryIssueMasterAndIssueDetailsBR.InsertInventoryIssueMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _inventoryIssueMasterAndIssueDetailsDataProvider.InsertInsertInventoryIssueMaster(item);
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

        //Update.
        public IBaseEntityResponse<InventoryIssueMasterAndIssueDetails> UpdateInventoryIssueMaster(InventoryIssueMasterAndIssueDetails item)
        {
            IBaseEntityResponse<InventoryIssueMasterAndIssueDetails> entityResponse = new BaseEntityResponse<InventoryIssueMasterAndIssueDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _inventoryIssueMasterAndIssueDetailsBR.UpdateInventoryIssueMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _inventoryIssueMasterAndIssueDetailsDataProvider.UpdateInventoryIssueMaster(item);
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

        //Delete
        public IBaseEntityResponse<InventoryIssueMasterAndIssueDetails> DeleteInventoryIssueMaster(InventoryIssueMasterAndIssueDetails item)
        {
            IBaseEntityResponse<InventoryIssueMasterAndIssueDetails> entityResponse = new BaseEntityResponse<InventoryIssueMasterAndIssueDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _inventoryIssueMasterAndIssueDetailsBR.DeleteInventoryIssueMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _inventoryIssueMasterAndIssueDetailsDataProvider.DeleteInventoryIssueMaster(item);
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

        //Select All
        public IBaseEntityCollectionResponse<InventoryIssueMasterAndIssueDetails> GetInventoryIssueMasterBySearch(InventoryIssueMasterAndIssueDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryIssueMasterAndIssueDetails> inventoryIssueMasterCollection = new BaseEntityCollectionResponse<InventoryIssueMasterAndIssueDetails>();
            try
            {
                if (_inventoryIssueMasterAndIssueDetailsDataProvider != null)
                    inventoryIssueMasterCollection = _inventoryIssueMasterAndIssueDetailsDataProvider.GetInventoryIssueMasterBySearch(searchRequest);
                else
                {
                    inventoryIssueMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    inventoryIssueMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                inventoryIssueMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                inventoryIssueMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return inventoryIssueMasterCollection;
        }

       //Select One.
        public IBaseEntityCollectionResponse<InventoryIssueMasterAndIssueDetails> GetInventoryIssueMasterByID(InventoryIssueMasterAndIssueDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryIssueMasterAndIssueDetails> entityResponse = new BaseEntityCollectionResponse<InventoryIssueMasterAndIssueDetails>();
            try
            {
                entityResponse = _inventoryIssueMasterAndIssueDetailsDataProvider.GetInventoryIssueMasterByID(searchRequest);
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
        public IBaseEntityCollectionResponse<InventoryIssueMasterAndIssueDetails> GetInventoryIssueMasterSearchList(InventoryIssueMasterAndIssueDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryIssueMasterAndIssueDetails> inventoryIssueMasterCollection = new BaseEntityCollectionResponse<InventoryIssueMasterAndIssueDetails>();
            try
            {
                if (_inventoryIssueMasterAndIssueDetailsDataProvider != null)
                    inventoryIssueMasterCollection = _inventoryIssueMasterAndIssueDetailsDataProvider.GetInventoryIssueMasterSearchList(searchRequest);
                else
                {
                    inventoryIssueMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    inventoryIssueMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                inventoryIssueMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                inventoryIssueMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return inventoryIssueMasterCollection;
        }

        //==============================InventoryIssueDetails Table Property.=======================================

        //Insert.
        public IBaseEntityResponse<InventoryIssueMasterAndIssueDetails> InsertInventoryIssueDetails(InventoryIssueMasterAndIssueDetails item)
        {
            IBaseEntityResponse<InventoryIssueMasterAndIssueDetails> entityResponse = new BaseEntityResponse<InventoryIssueMasterAndIssueDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _inventoryIssueMasterAndIssueDetailsBR.InsertInventoryIssueDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _inventoryIssueMasterAndIssueDetailsDataProvider.InsertInventoryIssueDetails(item);
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

        //Update.
        public IBaseEntityResponse<InventoryIssueMasterAndIssueDetails> UpdateInventoryIssueDetails(InventoryIssueMasterAndIssueDetails item)
        {
            IBaseEntityResponse<InventoryIssueMasterAndIssueDetails> entityResponse = new BaseEntityResponse<InventoryIssueMasterAndIssueDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _inventoryIssueMasterAndIssueDetailsBR.UpdateInventoryIssueDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _inventoryIssueMasterAndIssueDetailsDataProvider.UpdateInventoryIssueDetails(item);
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

        //Delete
        public IBaseEntityResponse<InventoryIssueMasterAndIssueDetails> DeleteInventoryIssueDetails(InventoryIssueMasterAndIssueDetails item)
        {
            IBaseEntityResponse<InventoryIssueMasterAndIssueDetails> entityResponse = new BaseEntityResponse<InventoryIssueMasterAndIssueDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _inventoryIssueMasterAndIssueDetailsBR.DeleteInventoryIssueDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _inventoryIssueMasterAndIssueDetailsDataProvider.DeleteInventoryIssueDetails(item);
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

        //Select All
        public IBaseEntityCollectionResponse<InventoryIssueMasterAndIssueDetails> GetInventoryIssueDetailsBySearch(InventoryIssueMasterAndIssueDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryIssueMasterAndIssueDetails> inventoryIssueDetailsCollection = new BaseEntityCollectionResponse<InventoryIssueMasterAndIssueDetails>();
            try
            {
                if (_inventoryIssueMasterAndIssueDetailsDataProvider != null)
                    inventoryIssueDetailsCollection = _inventoryIssueMasterAndIssueDetailsDataProvider.GetInventoryIssueDetailsBySearch(searchRequest);
                else
                {
                    inventoryIssueDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    inventoryIssueDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                inventoryIssueDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                inventoryIssueDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return inventoryIssueDetailsCollection;
        }


        //Select One.
        public IBaseEntityResponse<InventoryIssueMasterAndIssueDetails> GetInventoryIssueDetailsByID(InventoryIssueMasterAndIssueDetails item)
        {
            IBaseEntityResponse<InventoryIssueMasterAndIssueDetails> entityResponse = new BaseEntityResponse<InventoryIssueMasterAndIssueDetails>();
            try
            {
                entityResponse = _inventoryIssueMasterAndIssueDetailsDataProvider.GetInventoryIssueDetailsByID(item);
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


        //Search List.        
        public IBaseEntityCollectionResponse<InventoryIssueMasterAndIssueDetails> GetInventoryIssueDetailsSearchList(InventoryIssueMasterAndIssueDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryIssueMasterAndIssueDetails> inventoryIssueDetailsCollection = new BaseEntityCollectionResponse<InventoryIssueMasterAndIssueDetails>();
            try
            {
                if (_inventoryIssueMasterAndIssueDetailsDataProvider != null)
                    inventoryIssueDetailsCollection = _inventoryIssueMasterAndIssueDetailsDataProvider.GetInventoryIssueDetailsSearchList(searchRequest);
                else
                {
                    inventoryIssueDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    inventoryIssueDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                inventoryIssueDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                inventoryIssueDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return inventoryIssueDetailsCollection;
        }


        //Inv List for Loation Master.
        public IBaseEntityCollectionResponse<InventoryLocationMaster> GetInventoryIssueLocationMasterList(InventoryLocationMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryLocationMaster> issueLocationCollection = new BaseEntityCollectionResponse<InventoryLocationMaster>();
            try
            {
                if (_inventoryIssueMasterAndIssueDetailsDataProvider != null)
                    issueLocationCollection = _inventoryIssueMasterAndIssueDetailsDataProvider.GetInventoryIssueLocationMasterList(searchRequest);
                else
                {
                    issueLocationCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    issueLocationCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                issueLocationCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                issueLocationCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return issueLocationCollection;
        }
    }
}
