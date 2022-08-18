
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
    public class InventoryCustomerMasterBA : IInventoryCustomerMasterBA
    {
        IInventoryCustomerMasterDataProvider _InventoryCustomerMasterDataProvider;
        IInventoryCustomerMasterBR _InventoryCustomerMasterBR;
        private ILogger _logException;
        public InventoryCustomerMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _InventoryCustomerMasterBR = new InventoryCustomerMasterBR();
            _InventoryCustomerMasterDataProvider = new InventoryCustomerMasterDataProvider();
        }
        /// <summary>
        /// Create new record of InventoryCustomerMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryCustomerMaster> InsertInventoryCustomerMaster(InventoryCustomerMaster item)
        {
            IBaseEntityResponse<InventoryCustomerMaster> entityResponse = new BaseEntityResponse<InventoryCustomerMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryCustomerMasterBR.InsertInventoryCustomerMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryCustomerMasterDataProvider.InsertInventoryCustomerMaster(item);
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
        /// Update a specific record  of InventoryCustomerMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryCustomerMaster> UpdateInventoryCustomerMaster(InventoryCustomerMaster item)
        {
            IBaseEntityResponse<InventoryCustomerMaster> entityResponse = new BaseEntityResponse<InventoryCustomerMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryCustomerMasterBR.UpdateInventoryCustomerMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryCustomerMasterDataProvider.UpdateInventoryCustomerMaster(item);
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
        /// Delete a selected record from InventoryCustomerMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryCustomerMaster> DeleteInventoryCustomerMaster(InventoryCustomerMaster item)
        {
            IBaseEntityResponse<InventoryCustomerMaster> entityResponse = new BaseEntityResponse<InventoryCustomerMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryCustomerMasterBR.DeleteInventoryCustomerMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryCustomerMasterDataProvider.DeleteInventoryCustomerMaster(item);
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
        /// Select all record from InventoryCustomerMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<InventoryCustomerMaster> GetBySearch(InventoryCustomerMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryCustomerMaster> InventoryCustomerMasterCollection = new BaseEntityCollectionResponse<InventoryCustomerMaster>();
            try
            {
                if (_InventoryCustomerMasterDataProvider != null)
                    InventoryCustomerMasterCollection = _InventoryCustomerMasterDataProvider.GetInventoryCustomerMasterBySearch(searchRequest);
                else
                {
                    InventoryCustomerMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryCustomerMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryCustomerMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryCustomerMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryCustomerMasterCollection;
        }

        public IBaseEntityCollectionResponse<InventoryCustomerMaster> GetInventoryCustomerMasterSelectList(InventoryCustomerMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryCustomerMaster> InventoryCustomerMasterCollection = new BaseEntityCollectionResponse<InventoryCustomerMaster>();
            try
            {
                if (_InventoryCustomerMasterDataProvider != null)
                    InventoryCustomerMasterCollection = _InventoryCustomerMasterDataProvider.GetInventoryCustomerMasterSelectList(searchRequest);
                else
                {
                    InventoryCustomerMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryCustomerMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryCustomerMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryCustomerMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryCustomerMasterCollection;
        }
        /// <summary>
        /// Select a record from InventoryCustomerMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// 

        public IBaseEntityResponse<InventoryCustomerMaster> SelectByID(InventoryCustomerMaster item)
        {
            IBaseEntityResponse<InventoryCustomerMaster> entityResponse = new BaseEntityResponse<InventoryCustomerMaster>();
            try
            {
                entityResponse = _InventoryCustomerMasterDataProvider.GetInventoryCustomerMasterByID(item);
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
