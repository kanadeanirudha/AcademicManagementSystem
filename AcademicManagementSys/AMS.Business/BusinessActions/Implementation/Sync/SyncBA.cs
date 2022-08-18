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
    public class SyncBA : ISyncBA
    {
        ISyncDataProvider _generalRegionMasterDataProvider;
        ISyncBR _generalRegionMasterBR;
        private ILogger _logException;

        public SyncBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _generalRegionMasterBR = new SyncBR();
            _generalRegionMasterDataProvider = new SyncDataProvider();
        }

        /// <summary>
        /// Create new record of Sync.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<Sync> InventorySyncProcess(Sync item)
        {
            IBaseEntityResponse<Sync> entityResponse = new BaseEntityResponse<Sync>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalRegionMasterBR.InsertSyncValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalRegionMasterDataProvider.InventorySyncProcess(item);
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

        /// <summary>
        /// Update a specific record of Sync.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<Sync> UpdateSync(Sync item)
        {
            IBaseEntityResponse<Sync> entityResponse = new BaseEntityResponse<Sync>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalRegionMasterBR.UpdateSyncValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalRegionMasterDataProvider.UpdateSync(item);
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

        /// <summary>
        /// Delete a selected record from Sync.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<Sync> DeleteSync(Sync item)
        {
            IBaseEntityResponse<Sync> entityResponse = new BaseEntityResponse<Sync>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalRegionMasterBR.DeleteSyncValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalRegionMasterDataProvider.DeleteSync(item);
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

        /// <summary>
        /// Select all record from Sync table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>

        public IBaseEntityCollectionResponse<Sync> GetBySearch(SyncSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<Sync> categoryMasterCollection = new BaseEntityCollectionResponse<Sync>();
            try
            {
                if (_generalRegionMasterDataProvider != null)
                {
                    categoryMasterCollection = _generalRegionMasterDataProvider.GetSyncBySearch(searchRequest);
                }
                else
                {
                    categoryMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    categoryMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                categoryMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                categoryMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return categoryMasterCollection;
        }

        /// <summary>
        /// Select all record from Sync table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>

        public IBaseEntityCollectionResponse<Sync> GetBySearchList(SyncSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<Sync> categoryMasterCollection = new BaseEntityCollectionResponse<Sync>();
            try
            {
                if (_generalRegionMasterDataProvider != null)
                {
                    categoryMasterCollection = _generalRegionMasterDataProvider.GetSyncGetBySearchList(searchRequest);
                }
                else
                {
                    categoryMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    categoryMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                categoryMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                categoryMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return categoryMasterCollection;
        }


        /// <summary>
        /// Select a record from Sync table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<Sync> GetLastSyncDate(Sync item)
        {

            IBaseEntityResponse<Sync> entityResponse = new BaseEntityResponse<Sync>();
            try
            {
                entityResponse = _generalRegionMasterDataProvider.GetLastSyncDate(item);
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
        /// Select a record from Sync table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<Sync> CheckLoggedInUserCount(Sync item)
        {

            IBaseEntityResponse<Sync> entityResponse = new BaseEntityResponse<Sync>();
            try
            {
                entityResponse = _generalRegionMasterDataProvider.CheckLoggedInUserCount(item);
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