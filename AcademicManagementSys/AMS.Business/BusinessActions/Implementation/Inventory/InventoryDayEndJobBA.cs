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
    public class InventoryDayEndJobBA : IInventoryDayEndJobBA
    {
        IInventoryDayEndJobDataProvider _InventoryDayEndJobDataProvider;
        IInventoryDayEndJobBR _InventoryDayEndJobBR;
        private ILogger _logException;
        public InventoryDayEndJobBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _InventoryDayEndJobBR = new InventoryDayEndJobBR();
            _InventoryDayEndJobDataProvider = new InventoryDayEndJobDataProvider();
        }
        /// <summary>
        /// Create new record of InventoryDayEndJob.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryDayEndJob> InsertInventoryDayEndJob(InventoryDayEndJob item)
        {
            IBaseEntityResponse<InventoryDayEndJob> entityResponse = new BaseEntityResponse<InventoryDayEndJob>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryDayEndJobBR.InsertInventoryDayEndJobValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryDayEndJobDataProvider.InsertInventoryDayEndJob(item);
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
        /// Update a specific record  of InventoryDayEndJob.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryDayEndJob> UpdateInventoryDayEndJob(InventoryDayEndJob item)
        {
            IBaseEntityResponse<InventoryDayEndJob> entityResponse = new BaseEntityResponse<InventoryDayEndJob>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryDayEndJobBR.UpdateInventoryDayEndJobValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryDayEndJobDataProvider.UpdateInventoryDayEndJob(item);
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
        /// Delete a selected record from InventoryDayEndJob.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryDayEndJob> DeleteInventoryDayEndJob(InventoryDayEndJob item)
        {
            IBaseEntityResponse<InventoryDayEndJob> entityResponse = new BaseEntityResponse<InventoryDayEndJob>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryDayEndJobBR.DeleteInventoryDayEndJobValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryDayEndJobDataProvider.DeleteInventoryDayEndJob(item);
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
        /// Select all record from InventoryDayEndJob table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<InventoryDayEndJob> GetBySearch(InventoryDayEndJobSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryDayEndJob> InventoryDayEndJobCollection = new BaseEntityCollectionResponse<InventoryDayEndJob>();
            try
            {
                if (_InventoryDayEndJobDataProvider != null)
                    InventoryDayEndJobCollection = _InventoryDayEndJobDataProvider.GetInventoryDayEndJobBySearch(searchRequest);
                else
                {
                    InventoryDayEndJobCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryDayEndJobCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryDayEndJobCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryDayEndJobCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryDayEndJobCollection;
        }

        public IBaseEntityCollectionResponse<InventoryDayEndJob> GetInventoryDayEndJobList(InventoryDayEndJobSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryDayEndJob> InventoryDayEndJobCollection = new BaseEntityCollectionResponse<InventoryDayEndJob>();
            try
            {
                if (_InventoryDayEndJobDataProvider != null)
                    InventoryDayEndJobCollection = _InventoryDayEndJobDataProvider.GetInventoryDayEndJobList(searchRequest);
                else
                {
                    InventoryDayEndJobCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryDayEndJobCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryDayEndJobCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryDayEndJobCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryDayEndJobCollection;
        }
        /// <summary>
        /// Select a record from InventoryDayEndJob table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryDayEndJob> SelectByID(InventoryDayEndJob item)
        {
            IBaseEntityResponse<InventoryDayEndJob> entityResponse = new BaseEntityResponse<InventoryDayEndJob>();
            try
            {
                entityResponse = _InventoryDayEndJobDataProvider.GetInventoryDayEndJobByID(item);
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


        public IBaseEntityResponse<InventoryDayEndJob> GetDayEndJob(InventoryDayEndJob item)
        {
            IBaseEntityResponse<InventoryDayEndJob> entityResponse = new BaseEntityResponse<InventoryDayEndJob>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryDayEndJobBR.GetDayEndJob(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryDayEndJobDataProvider.GetDayEndJob(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null;
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

        public IBaseEntityResponse<InventoryDayEndJob> GetTimeZone(InventoryDayEndJob item)
        {

            IBaseEntityResponse<InventoryDayEndJob> entityResponse = new BaseEntityResponse<InventoryDayEndJob>();
            try
            {
                entityResponse = _InventoryDayEndJobDataProvider.GetTimeZone(item);
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
