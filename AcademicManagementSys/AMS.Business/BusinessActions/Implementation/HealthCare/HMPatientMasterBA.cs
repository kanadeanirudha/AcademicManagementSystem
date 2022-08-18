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
    public class HMPatientMasterBA : IHMPatientMasterBA
    {
        IHMPatientMasterDataProvider _HMPatientMasterDataProvider;
        IHMPatientMasterBR _HMPatientMasterBR;
        private ILogger _logException;
        public HMPatientMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _HMPatientMasterBR = new HMPatientMasterBR();
            _HMPatientMasterDataProvider = new HMPatientMasterDataProvider();
        }
        /// <summary>
        /// Create new record of HMPatientMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<HMPatientMaster> InsertHMPatientMaster(HMPatientMaster item)
        {
            IBaseEntityResponse<HMPatientMaster> entityResponse = new BaseEntityResponse<HMPatientMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _HMPatientMasterBR.InsertHMPatientMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _HMPatientMasterDataProvider.InsertHMPatientMaster(item);
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
        /// Update a specific record  of HMPatientMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<HMPatientMaster> UpdateHMPatientMaster(HMPatientMaster item)
        {
            IBaseEntityResponse<HMPatientMaster> entityResponse = new BaseEntityResponse<HMPatientMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _HMPatientMasterBR.UpdateHMPatientMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _HMPatientMasterDataProvider.UpdateHMPatientMaster(item);
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
        /// Delete a selected record from HMPatientMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<HMPatientMaster> DeleteHMPatientMaster(HMPatientMaster item)
        {
            IBaseEntityResponse<HMPatientMaster> entityResponse = new BaseEntityResponse<HMPatientMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _HMPatientMasterBR.DeleteHMPatientMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _HMPatientMasterDataProvider.DeleteHMPatientMaster(item);
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
        /// Select all record from HMPatientMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<HMPatientMaster> GetBySearch(HMPatientMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<HMPatientMaster> HMPatientMasterCollection = new BaseEntityCollectionResponse<HMPatientMaster>();
            try
            {
                if (_HMPatientMasterDataProvider != null)
                    HMPatientMasterCollection = _HMPatientMasterDataProvider.GetHMPatientMasterBySearch(searchRequest);
                else
                {
                    HMPatientMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    HMPatientMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                HMPatientMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                HMPatientMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return HMPatientMasterCollection;
        }

        public IBaseEntityCollectionResponse<HMPatientMaster> GetHMPatientMasterSearchList(HMPatientMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<HMPatientMaster> HMPatientMasterCollection = new BaseEntityCollectionResponse<HMPatientMaster>();
            try
            {
                if (_HMPatientMasterDataProvider != null)
                    HMPatientMasterCollection = _HMPatientMasterDataProvider.GetHMPatientMasterSearchList(searchRequest);
                else
                {
                    HMPatientMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    HMPatientMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                HMPatientMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                HMPatientMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return HMPatientMasterCollection;
        }
        /// <summary>
        /// Select a record from HMPatientMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<HMPatientMaster> SelectByID(HMPatientMaster item)
        {
            IBaseEntityResponse<HMPatientMaster> entityResponse = new BaseEntityResponse<HMPatientMaster>();
            try
            {
                entityResponse = _HMPatientMasterDataProvider.GetHMPatientMasterByID(item);
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
        //ForSearch list for patient

        /// <summary>
        /// Select all record from HMPatientMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<HMPatientMaster> GetListOfPatient(HMPatientMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<HMPatientMaster> HMPatientMasterCollection = new BaseEntityCollectionResponse<HMPatientMaster>();
            try
            {
                if (_HMPatientMasterDataProvider != null)
                    HMPatientMasterCollection = _HMPatientMasterDataProvider.GetListOfPatient(searchRequest);
                else
                {
                    HMPatientMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    HMPatientMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                HMPatientMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                HMPatientMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return HMPatientMasterCollection;
        }

    }
}
