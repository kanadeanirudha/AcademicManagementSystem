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
    public class HMOPDHealthCentreBA : IHMOPDHealthCentreBA
    {
        IHMOPDHealthCentreDataProvider _HMOPDHealthCentreDataProvider;
        IHMOPDHealthCentreBR _HMOPDHealthCentreBR;
        private ILogger _logException;
        public HMOPDHealthCentreBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _HMOPDHealthCentreBR = new HMOPDHealthCentreBR();
            _HMOPDHealthCentreDataProvider = new HMOPDHealthCentreDataProvider();
        }
        /// <summary>
        /// Create new record of HMOPDHealthCentre.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<HMOPDHealthCentre> InsertHMOPDHealthCentre(HMOPDHealthCentre item)
        {
            IBaseEntityResponse<HMOPDHealthCentre> entityResponse = new BaseEntityResponse<HMOPDHealthCentre>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _HMOPDHealthCentreBR.InsertHMOPDHealthCentreValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _HMOPDHealthCentreDataProvider.InsertHMOPDHealthCentre(item);
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
        /// Update a specific record  of HMOPDHealthCentre.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<HMOPDHealthCentre> UpdateHMOPDHealthCentre(HMOPDHealthCentre item)
        {
            IBaseEntityResponse<HMOPDHealthCentre> entityResponse = new BaseEntityResponse<HMOPDHealthCentre>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _HMOPDHealthCentreBR.UpdateHMOPDHealthCentreValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _HMOPDHealthCentreDataProvider.UpdateHMOPDHealthCentre(item);
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
        /// Delete a selected record from HMOPDHealthCentre.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<HMOPDHealthCentre> DeleteHMOPDHealthCentre(HMOPDHealthCentre item)
        {
            IBaseEntityResponse<HMOPDHealthCentre> entityResponse = new BaseEntityResponse<HMOPDHealthCentre>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _HMOPDHealthCentreBR.DeleteHMOPDHealthCentreValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _HMOPDHealthCentreDataProvider.DeleteHMOPDHealthCentre(item);
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
        /// Select all record from HMOPDHealthCentre table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<HMOPDHealthCentre> GetBySearch(HMOPDHealthCentreSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<HMOPDHealthCentre> HMOPDHealthCentreCollection = new BaseEntityCollectionResponse<HMOPDHealthCentre>();
            try
            {
                if (_HMOPDHealthCentreDataProvider != null)
                    HMOPDHealthCentreCollection = _HMOPDHealthCentreDataProvider.GetHMOPDHealthCentreBySearch(searchRequest);
                else
                {
                    HMOPDHealthCentreCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    HMOPDHealthCentreCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                HMOPDHealthCentreCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                HMOPDHealthCentreCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return HMOPDHealthCentreCollection;
        }

        public IBaseEntityCollectionResponse<HMOPDHealthCentre> GetHMOPDHealthCentreSearchList(HMOPDHealthCentreSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<HMOPDHealthCentre> HMOPDHealthCentreCollection = new BaseEntityCollectionResponse<HMOPDHealthCentre>();
            try
            {
                if (_HMOPDHealthCentreDataProvider != null)
                    HMOPDHealthCentreCollection = _HMOPDHealthCentreDataProvider.GetHMOPDHealthCentreSearchList(searchRequest);
                else
                {
                    HMOPDHealthCentreCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    HMOPDHealthCentreCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                HMOPDHealthCentreCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                HMOPDHealthCentreCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return HMOPDHealthCentreCollection;
        }
        /// <summary>
        /// Select a record from HMOPDHealthCentre table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<HMOPDHealthCentre> SelectByID(HMOPDHealthCentre item)
        {
            IBaseEntityResponse<HMOPDHealthCentre> entityResponse = new BaseEntityResponse<HMOPDHealthCentre>();
            try
            {
                entityResponse = _HMOPDHealthCentreDataProvider.GetHMOPDHealthCentreByID(item);
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
        //For OPD Dropdown
        /// <summary>
        /// Select all record from HMOPDHealthCentre table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<HMOPDHealthCentre> GetListHMOPDHealthCentre(HMOPDHealthCentreSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<HMOPDHealthCentre> HMOPDHealthCentreCollection = new BaseEntityCollectionResponse<HMOPDHealthCentre>();
            try
            {
                if (_HMOPDHealthCentreDataProvider != null)
                    HMOPDHealthCentreCollection = _HMOPDHealthCentreDataProvider.GetListHMOPDHealthCentre(searchRequest);
                else
                {
                    HMOPDHealthCentreCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    HMOPDHealthCentreCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                HMOPDHealthCentreCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                HMOPDHealthCentreCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return HMOPDHealthCentreCollection;
        }
    }
}
