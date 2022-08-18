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
    public class HMConsultantMasterBA : IHMConsultantMasterBA
    {
        IHMConsultantMasterDataProvider _HMConsultantMasterDataProvider;
        IHMConsultantMasterBR _HMConsultantMasterBR;
        private ILogger _logException;
        public HMConsultantMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _HMConsultantMasterBR = new HMConsultantMasterBR();
            _HMConsultantMasterDataProvider = new HMConsultantMasterDataProvider();
        }
        /// <summary>
        /// Create new record of HMConsultantMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<HMConsultantMaster> InsertHMConsultantMaster(HMConsultantMaster item)
        {
            IBaseEntityResponse<HMConsultantMaster> entityResponse = new BaseEntityResponse<HMConsultantMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _HMConsultantMasterBR.InsertHMConsultantMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _HMConsultantMasterDataProvider.InsertHMConsultantMaster(item);
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
        /// Update a specific record  of HMConsultantMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<HMConsultantMaster> UpdateHMConsultantMaster(HMConsultantMaster item)
        {
            IBaseEntityResponse<HMConsultantMaster> entityResponse = new BaseEntityResponse<HMConsultantMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _HMConsultantMasterBR.UpdateHMConsultantMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _HMConsultantMasterDataProvider.UpdateHMConsultantMaster(item);
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
        /// Delete a selected record from HMConsultantMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<HMConsultantMaster> DeleteHMConsultantMaster(HMConsultantMaster item)
        {
            IBaseEntityResponse<HMConsultantMaster> entityResponse = new BaseEntityResponse<HMConsultantMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _HMConsultantMasterBR.DeleteHMConsultantMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _HMConsultantMasterDataProvider.DeleteHMConsultantMaster(item);
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
        /// Select all record from HMConsultantMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<HMConsultantMaster> GetBySearch(HMConsultantMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<HMConsultantMaster> HMConsultantMasterCollection = new BaseEntityCollectionResponse<HMConsultantMaster>();
            try
            {
                if (_HMConsultantMasterDataProvider != null)
                    HMConsultantMasterCollection = _HMConsultantMasterDataProvider.GetHMConsultantMasterBySearch(searchRequest);
                else
                {
                    HMConsultantMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    HMConsultantMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                HMConsultantMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                HMConsultantMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return HMConsultantMasterCollection;
        }

        public IBaseEntityCollectionResponse<HMConsultantMaster> GetHMConsultantMasterSearchList(HMConsultantMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<HMConsultantMaster> HMConsultantMasterCollection = new BaseEntityCollectionResponse<HMConsultantMaster>();
            try
            {
                if (_HMConsultantMasterDataProvider != null)
                    HMConsultantMasterCollection = _HMConsultantMasterDataProvider.GetHMConsultantMasterSearchList(searchRequest);
                else
                {
                    HMConsultantMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    HMConsultantMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                HMConsultantMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                HMConsultantMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return HMConsultantMasterCollection;
        }
        /// <summary>
        /// Select a record from HMConsultantMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<HMConsultantMaster> SelectByID(HMConsultantMaster item)
        {
            IBaseEntityResponse<HMConsultantMaster> entityResponse = new BaseEntityResponse<HMConsultantMaster>();
            try
            {
                entityResponse = _HMConsultantMasterDataProvider.GetHMConsultantMasterByID(item);
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
