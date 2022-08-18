

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
    public class OnlineExamExaminationMasterBA : IOnlineExamExaminationMasterBA
    {
        IOnlineExamExaminationMasterDataProvider _OnlineExamExaminationMasterDataProvider;
        IOnlineExamExaminationMasterBR _OnlineExamExaminationMasterBR;
        private ILogger _logException;
        public OnlineExamExaminationMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _OnlineExamExaminationMasterBR = new OnlineExamExaminationMasterBR();
            _OnlineExamExaminationMasterDataProvider = new OnlineExamExaminationMasterDataProvider();
        }
        /// <summary>
        /// Create new record of OnlineExamExaminationMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OnlineExamExaminationMaster> InsertOnlineExamExaminationMaster(OnlineExamExaminationMaster item)
        {
            IBaseEntityResponse<OnlineExamExaminationMaster> entityResponse = new BaseEntityResponse<OnlineExamExaminationMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _OnlineExamExaminationMasterBR.InsertOnlineExamExaminationMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _OnlineExamExaminationMasterDataProvider.InsertOnlineExamExaminationMaster(item);
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
        /// Update a specific record  of OnlineExamExaminationMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OnlineExamExaminationMaster> UpdateOnlineExamExaminationMaster(OnlineExamExaminationMaster item)
        {
            IBaseEntityResponse<OnlineExamExaminationMaster> entityResponse = new BaseEntityResponse<OnlineExamExaminationMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _OnlineExamExaminationMasterBR.UpdateOnlineExamExaminationMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _OnlineExamExaminationMasterDataProvider.UpdateOnlineExamExaminationMaster(item);
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
        /// Delete a selected record from OnlineExamExaminationMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OnlineExamExaminationMaster> DeleteOnlineExamExaminationMaster(OnlineExamExaminationMaster item)
        {
            IBaseEntityResponse<OnlineExamExaminationMaster> entityResponse = new BaseEntityResponse<OnlineExamExaminationMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _OnlineExamExaminationMasterBR.DeleteOnlineExamExaminationMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _OnlineExamExaminationMasterDataProvider.DeleteOnlineExamExaminationMaster(item);
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
        /// Select all record from OnlineExamExaminationMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OnlineExamExaminationMaster> GetBySearch(OnlineExamExaminationMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExamExaminationMaster> OnlineExamExaminationMasterCollection = new BaseEntityCollectionResponse<OnlineExamExaminationMaster>();
            try
            {
                if (_OnlineExamExaminationMasterDataProvider != null)
                    OnlineExamExaminationMasterCollection = _OnlineExamExaminationMasterDataProvider.GetOnlineExamExaminationMasterBySearch(searchRequest);
                else
                {
                    OnlineExamExaminationMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OnlineExamExaminationMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OnlineExamExaminationMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OnlineExamExaminationMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OnlineExamExaminationMasterCollection;
        }

        public IBaseEntityCollectionResponse<OnlineExamExaminationMaster> GetOnlineExamExaminationMasterSearchList(OnlineExamExaminationMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExamExaminationMaster> OnlineExamExaminationMasterCollection = new BaseEntityCollectionResponse<OnlineExamExaminationMaster>();
            try
            {
                if (_OnlineExamExaminationMasterDataProvider != null)
                    OnlineExamExaminationMasterCollection = _OnlineExamExaminationMasterDataProvider.GetOnlineExamExaminationMasterSearchList(searchRequest);
                else
                {
                    OnlineExamExaminationMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OnlineExamExaminationMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OnlineExamExaminationMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OnlineExamExaminationMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OnlineExamExaminationMasterCollection;
        }
        /// <summary>
        /// Select a record from OnlineExamExaminationMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OnlineExamExaminationMaster> SelectByID(OnlineExamExaminationMaster item)
        {
            IBaseEntityResponse<OnlineExamExaminationMaster> entityResponse = new BaseEntityResponse<OnlineExamExaminationMaster>();
            try
            {
                entityResponse = _OnlineExamExaminationMasterDataProvider.GetOnlineExamExaminationMasterByID(item);
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
        //for staff Allocation
        /// <summary>
        /// Select all record from OnlineExamExaminationMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OnlineExamExaminationMaster>GetExaminationNameList(OnlineExamExaminationMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExamExaminationMaster> OnlineExamExaminationMasterCollection = new BaseEntityCollectionResponse<OnlineExamExaminationMaster>();
            try
            {
                if (_OnlineExamExaminationMasterDataProvider != null)
                    OnlineExamExaminationMasterCollection = _OnlineExamExaminationMasterDataProvider.GetExaminationNameList(searchRequest);
                else
                {
                    OnlineExamExaminationMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OnlineExamExaminationMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OnlineExamExaminationMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OnlineExamExaminationMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OnlineExamExaminationMasterCollection;
        }

        public IBaseEntityCollectionResponse<OnlineExamExaminationMaster> OnlineExamGetExaminationListCentreWise(OnlineExamExaminationMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExamExaminationMaster> OnlineExamExaminationMasterCollection = new BaseEntityCollectionResponse<OnlineExamExaminationMaster>();
            try
            {
                if (_OnlineExamExaminationMasterDataProvider != null)
                    OnlineExamExaminationMasterCollection = _OnlineExamExaminationMasterDataProvider.OnlineExamGetExaminationListCentreWise(searchRequest);
                else
                {
                    OnlineExamExaminationMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OnlineExamExaminationMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OnlineExamExaminationMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OnlineExamExaminationMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OnlineExamExaminationMasterCollection;
        }
    }
}

