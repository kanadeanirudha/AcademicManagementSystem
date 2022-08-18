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
    public class HMConsultantTypeMasterBA : IHMConsultantTypeMasterBA
    {
        IHMConsultantTypeMasterDataProvider _HMConsultantTypeMasterDataProvider;
        IHMConsultantTypeMasterBR _HMConsultantTypeMasterBR;
        private ILogger _logException;
        public HMConsultantTypeMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _HMConsultantTypeMasterBR = new HMConsultantTypeMasterBR();
            _HMConsultantTypeMasterDataProvider = new HMConsultantTypeMasterDataProvider();
        }
        /// <summary>
        /// Create new record of HMConsultantTypeMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<HMConsultantTypeMaster> InsertHMConsultantTypeMaster(HMConsultantTypeMaster item)
        {
            IBaseEntityResponse<HMConsultantTypeMaster> entityResponse = new BaseEntityResponse<HMConsultantTypeMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _HMConsultantTypeMasterBR.InsertHMConsultantTypeMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _HMConsultantTypeMasterDataProvider.InsertHMConsultantTypeMaster(item);
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
        /// Update a specific record  of HMConsultantTypeMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<HMConsultantTypeMaster> UpdateHMConsultantTypeMaster(HMConsultantTypeMaster item)
        {
            IBaseEntityResponse<HMConsultantTypeMaster> entityResponse = new BaseEntityResponse<HMConsultantTypeMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _HMConsultantTypeMasterBR.UpdateHMConsultantTypeMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _HMConsultantTypeMasterDataProvider.UpdateHMConsultantTypeMaster(item);
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
        /// Delete a selected record from HMConsultantTypeMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<HMConsultantTypeMaster> DeleteHMConsultantTypeMaster(HMConsultantTypeMaster item)
        {
            IBaseEntityResponse<HMConsultantTypeMaster> entityResponse = new BaseEntityResponse<HMConsultantTypeMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _HMConsultantTypeMasterBR.DeleteHMConsultantTypeMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _HMConsultantTypeMasterDataProvider.DeleteHMConsultantTypeMaster(item);
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
        /// Select all record from HMConsultantTypeMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<HMConsultantTypeMaster> GetBySearch(HMConsultantTypeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<HMConsultantTypeMaster> HMConsultantTypeMasterCollection = new BaseEntityCollectionResponse<HMConsultantTypeMaster>();
            try
            {
                if (_HMConsultantTypeMasterDataProvider != null)
                    HMConsultantTypeMasterCollection = _HMConsultantTypeMasterDataProvider.GetHMConsultantTypeMasterBySearch(searchRequest);
                else
                {
                    HMConsultantTypeMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    HMConsultantTypeMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                HMConsultantTypeMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                HMConsultantTypeMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return HMConsultantTypeMasterCollection;
        }

        public IBaseEntityCollectionResponse<HMConsultantTypeMaster> GetHMConsultantTypeMasterSearchList(HMConsultantTypeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<HMConsultantTypeMaster> HMConsultantTypeMasterCollection = new BaseEntityCollectionResponse<HMConsultantTypeMaster>();
            try
            {
                if (_HMConsultantTypeMasterDataProvider != null)
                    HMConsultantTypeMasterCollection = _HMConsultantTypeMasterDataProvider.GetHMConsultantTypeMasterBySearch(searchRequest);
                else
                {
                    HMConsultantTypeMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    HMConsultantTypeMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                HMConsultantTypeMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                HMConsultantTypeMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return HMConsultantTypeMasterCollection;
        }
        /// <summary>
        /// Select a record from HMConsultantTypeMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<HMConsultantTypeMaster> SelectByID(HMConsultantTypeMaster item)
        {
            IBaseEntityResponse<HMConsultantTypeMaster> entityResponse = new BaseEntityResponse<HMConsultantTypeMaster>();
            try
            {
                entityResponse = _HMConsultantTypeMasterDataProvider.GetHMConsultantTypeMasterByID(item);
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
        /// Select all record from HMConsultantTypeMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<HMConsultantTypeMaster> GetConsultantTypeList(HMConsultantTypeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<HMConsultantTypeMaster> HMConsultantTypeMasterCollection = new BaseEntityCollectionResponse<HMConsultantTypeMaster>();
            try
            {
                if (_HMConsultantTypeMasterDataProvider != null)
                    HMConsultantTypeMasterCollection = _HMConsultantTypeMasterDataProvider.GetConsultantTypeList(searchRequest);
                else
                {
                    HMConsultantTypeMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    HMConsultantTypeMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                HMConsultantTypeMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                HMConsultantTypeMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return HMConsultantTypeMasterCollection;
        }
    }
}
