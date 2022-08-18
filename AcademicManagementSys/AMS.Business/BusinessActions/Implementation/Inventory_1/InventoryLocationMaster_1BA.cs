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
    public class InventoryLocationMaster_1BA : IInventoryLocationMaster_1BA
    {
        IInventoryLocationMaster_1DataProvider _InventoryLocationMaster_1DataProvider;
        IInventoryLocationMaster_1BR _InventoryLocationMaster_1BR;
        private ILogger _logException;
        public InventoryLocationMaster_1BA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _InventoryLocationMaster_1BR = new InventoryLocationMaster_1BR();
            _InventoryLocationMaster_1DataProvider = new InventoryLocationMaster_1DataProvider();
        }
        /// <summary>
        /// Create new record of InventoryLocationMaster_1.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryLocationMaster_1> InsertInventoryLocationMaster_1(InventoryLocationMaster_1 item)
        {
            IBaseEntityResponse<InventoryLocationMaster_1> entityResponse = new BaseEntityResponse<InventoryLocationMaster_1>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryLocationMaster_1BR.InsertInventoryLocationMaster_1Validate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryLocationMaster_1DataProvider.InsertInventoryLocationMaster_1(item);
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
        /// Update a specific record  of InventoryLocationMaster_1.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryLocationMaster_1> UpdateInventoryLocationMaster_1(InventoryLocationMaster_1 item)
        {
            IBaseEntityResponse<InventoryLocationMaster_1> entityResponse = new BaseEntityResponse<InventoryLocationMaster_1>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryLocationMaster_1BR.UpdateInventoryLocationMaster_1Validate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryLocationMaster_1DataProvider.UpdateInventoryLocationMaster_1(item);
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
        /// Delete a selected record from InventoryLocationMaster_1.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryLocationMaster_1> DeleteInventoryLocationMaster_1(InventoryLocationMaster_1 item)
        {
            IBaseEntityResponse<InventoryLocationMaster_1> entityResponse = new BaseEntityResponse<InventoryLocationMaster_1>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryLocationMaster_1BR.DeleteInventoryLocationMaster_1Validate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryLocationMaster_1DataProvider.DeleteInventoryLocationMaster_1(item);
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
        /// Select all record from InventoryLocationMaster_1 table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<InventoryLocationMaster_1> GetBySearch(InventoryLocationMaster_1SearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryLocationMaster_1> InventoryLocationMaster_1Collection = new BaseEntityCollectionResponse<InventoryLocationMaster_1>();
            try
            {
                if (_InventoryLocationMaster_1DataProvider != null)
                    InventoryLocationMaster_1Collection = _InventoryLocationMaster_1DataProvider.GetInventoryLocationMaster_1BySearch(searchRequest);
                else
                {
                    InventoryLocationMaster_1Collection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryLocationMaster_1Collection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryLocationMaster_1Collection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryLocationMaster_1Collection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryLocationMaster_1Collection;
        }

        public IBaseEntityCollectionResponse<InventoryLocationMaster_1> GetInventoryLocationMaster_1List(InventoryLocationMaster_1SearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryLocationMaster_1> InventoryLocationMaster_1Collection = new BaseEntityCollectionResponse<InventoryLocationMaster_1>();
            try
            {
                if (_InventoryLocationMaster_1DataProvider != null)
                    InventoryLocationMaster_1Collection = _InventoryLocationMaster_1DataProvider.GetInventoryLocationMaster_1List(searchRequest);
                else
                {
                    InventoryLocationMaster_1Collection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryLocationMaster_1Collection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryLocationMaster_1Collection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryLocationMaster_1Collection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryLocationMaster_1Collection;
        }
        /// <summary>
        /// Select a record from InventoryLocationMaster_1 table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryLocationMaster_1> SelectByID(InventoryLocationMaster_1 item)
        {
            IBaseEntityResponse<InventoryLocationMaster_1> entityResponse = new BaseEntityResponse<InventoryLocationMaster_1>();
            try
            {
                entityResponse = _InventoryLocationMaster_1DataProvider.GetInventoryLocationMaster_1ByID(item);
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

        public IBaseEntityCollectionResponse<InventoryLocationMaster_1> GetInventoryLocationMasterSearchList(InventoryLocationMaster_1SearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryLocationMaster_1> InventoryLocationMaster_1Collection = new BaseEntityCollectionResponse<InventoryLocationMaster_1>();
            try
            {
                if (_InventoryLocationMaster_1DataProvider != null)
                    InventoryLocationMaster_1Collection = _InventoryLocationMaster_1DataProvider.GetInventoryLocationMasterSearchList(searchRequest);
                else
                {
                    InventoryLocationMaster_1Collection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryLocationMaster_1Collection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryLocationMaster_1Collection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryLocationMaster_1Collection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryLocationMaster_1Collection;
        }

        public IBaseEntityCollectionResponse<InventoryLocationMaster_1> GetInventoryLocationMasterlistCenterCodeWise(InventoryLocationMaster_1SearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryLocationMaster_1> InventoryLocationMaster_1Collection = new BaseEntityCollectionResponse<InventoryLocationMaster_1>();
            try
            {
                if (_InventoryLocationMaster_1DataProvider != null)
                    InventoryLocationMaster_1Collection = _InventoryLocationMaster_1DataProvider.GetInventoryLocationMasterlistCenterCodeWise(searchRequest);
                else
                {
                    InventoryLocationMaster_1Collection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryLocationMaster_1Collection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryLocationMaster_1Collection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryLocationMaster_1Collection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryLocationMaster_1Collection;
        }

        public IBaseEntityCollectionResponse<InventoryLocationMaster_1> GetInventoryLocationMasterlistByAdminRole(InventoryLocationMaster_1SearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryLocationMaster_1> InventoryLocationMaster_1Collection = new BaseEntityCollectionResponse<InventoryLocationMaster_1>();
            try
            {
                if (_InventoryLocationMaster_1DataProvider != null)
                    InventoryLocationMaster_1Collection = _InventoryLocationMaster_1DataProvider.GetInventoryLocationMasterlistByAdminRole(searchRequest);
                else
                {
                    InventoryLocationMaster_1Collection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryLocationMaster_1Collection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryLocationMaster_1Collection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryLocationMaster_1Collection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryLocationMaster_1Collection;
        }
    }
}
