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
    public class ScholarShipMasterBA : IScholarShipMasterBA
    {
        IScholarShipMasterDataProvider _scholarShipMasterDataProvider;
        IScholarShipMasterBR _scholarShipMasterBR;
        private ILogger _logException;
        public ScholarShipMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _scholarShipMasterBR = new ScholarShipMasterBR();
            _scholarShipMasterDataProvider = new ScholarShipMasterDataProvider();
        }
        /// <summary>
        /// Create new record of ScholarShipMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<ScholarShipMaster> InsertScholarShipMaster(ScholarShipMaster item)
        {
            IBaseEntityResponse<ScholarShipMaster> entityResponse = new BaseEntityResponse<ScholarShipMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _scholarShipMasterBR.InsertScholarShipMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _scholarShipMasterDataProvider.InsertScholarShipMaster(item);
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
        /// Update a specific record  of ScholarShipMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<ScholarShipMaster> UpdateScholarShipMaster(ScholarShipMaster item)
        {
            IBaseEntityResponse<ScholarShipMaster> entityResponse = new BaseEntityResponse<ScholarShipMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _scholarShipMasterBR.UpdateScholarShipMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _scholarShipMasterDataProvider.UpdateScholarShipMaster(item);
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
        /// Delete a selected record from ScholarShipMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<ScholarShipMaster> DeleteScholarShipMaster(ScholarShipMaster item)
        {
            IBaseEntityResponse<ScholarShipMaster> entityResponse = new BaseEntityResponse<ScholarShipMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _scholarShipMasterBR.DeleteScholarShipMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _scholarShipMasterDataProvider.DeleteScholarShipMaster(item);
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
        /// Select all record from ScholarShipMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<ScholarShipMaster> GetBySearch(ScholarShipMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<ScholarShipMaster> ScholarShipMasterCollection = new BaseEntityCollectionResponse<ScholarShipMaster>();
            try
            {
                if (_scholarShipMasterDataProvider != null)
                    ScholarShipMasterCollection = _scholarShipMasterDataProvider.GetScholarShipMasterBySearch(searchRequest);
                else
                {
                    ScholarShipMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    ScholarShipMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                ScholarShipMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                ScholarShipMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return ScholarShipMasterCollection;
        }
        /// <summary>
        /// Select all record from ScholarShipMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<ScholarShipMaster> GetAccountTypeList(ScholarShipMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<ScholarShipMaster> ScholarShipMasterCollection = new BaseEntityCollectionResponse<ScholarShipMaster>();
            try
            {
                if (_scholarShipMasterDataProvider != null)
                    ScholarShipMasterCollection = _scholarShipMasterDataProvider.GetAccountTypeList(searchRequest);
                else
                {
                    ScholarShipMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    ScholarShipMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                ScholarShipMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                ScholarShipMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return ScholarShipMasterCollection;
        }        
        /// <summary>
        /// Select a record from ScholarShipMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<ScholarShipMaster> SelectByID(ScholarShipMaster item)
        {
            IBaseEntityResponse<ScholarShipMaster> entityResponse = new BaseEntityResponse<ScholarShipMaster>();
            try
            {
                entityResponse = _scholarShipMasterDataProvider.GetScholarShipMasterByID(item);
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
