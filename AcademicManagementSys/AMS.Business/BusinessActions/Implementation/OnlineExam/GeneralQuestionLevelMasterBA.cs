
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
    public class GeneralQuestionLevelMasterBA : IGeneralQuestionLevelMasterBA
    {
        IGeneralQuestionLevelMasterDataProvider _GeneralQuestionLevelMasterDataProvider;
        IGeneralQuestionLevelMasterBR _GeneralQuestionLevelMasterBR;
        private ILogger _logException;
        public GeneralQuestionLevelMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _GeneralQuestionLevelMasterBR = new GeneralQuestionLevelMasterBR();
            _GeneralQuestionLevelMasterDataProvider = new GeneralQuestionLevelMasterDataProvider();
        }
        /// <summary>
        /// Create new record of GeneralQuestionLevelMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralQuestionLevelMaster> InsertGeneralQuestionLevelMaster(GeneralQuestionLevelMaster item)
        {
            IBaseEntityResponse<GeneralQuestionLevelMaster> entityResponse = new BaseEntityResponse<GeneralQuestionLevelMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralQuestionLevelMasterBR.InsertGeneralQuestionLevelMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralQuestionLevelMasterDataProvider.InsertGeneralQuestionLevelMaster(item);
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
        /// Update a specific record  of GeneralQuestionLevelMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralQuestionLevelMaster> UpdateGeneralQuestionLevelMaster(GeneralQuestionLevelMaster item)
        {
            IBaseEntityResponse<GeneralQuestionLevelMaster> entityResponse = new BaseEntityResponse<GeneralQuestionLevelMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralQuestionLevelMasterBR.UpdateGeneralQuestionLevelMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralQuestionLevelMasterDataProvider.UpdateGeneralQuestionLevelMaster(item);
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
        /// Delete a selected record from GeneralQuestionLevelMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralQuestionLevelMaster> DeleteGeneralQuestionLevelMaster(GeneralQuestionLevelMaster item)
        {
            IBaseEntityResponse<GeneralQuestionLevelMaster> entityResponse = new BaseEntityResponse<GeneralQuestionLevelMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralQuestionLevelMasterBR.DeleteGeneralQuestionLevelMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralQuestionLevelMasterDataProvider.DeleteGeneralQuestionLevelMaster(item);
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
        /// Select all record from GeneralQuestionLevelMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralQuestionLevelMaster> GetBySearch(GeneralQuestionLevelMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralQuestionLevelMaster> GeneralQuestionLevelMasterCollection = new BaseEntityCollectionResponse<GeneralQuestionLevelMaster>();
            try
            {
                if (_GeneralQuestionLevelMasterDataProvider != null)
                    GeneralQuestionLevelMasterCollection = _GeneralQuestionLevelMasterDataProvider.GetGeneralQuestionLevelMasterBySearch(searchRequest);
                else
                {
                    GeneralQuestionLevelMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralQuestionLevelMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralQuestionLevelMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralQuestionLevelMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralQuestionLevelMasterCollection;
        }

        public IBaseEntityCollectionResponse<GeneralQuestionLevelMaster> GetGeneralQuestionLevelMasterSearchList(GeneralQuestionLevelMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralQuestionLevelMaster> GeneralQuestionLevelMasterCollection = new BaseEntityCollectionResponse<GeneralQuestionLevelMaster>();
            try
            {
                if (_GeneralQuestionLevelMasterDataProvider != null)
                    GeneralQuestionLevelMasterCollection = _GeneralQuestionLevelMasterDataProvider.GetGeneralQuestionLevelMasterSearchList(searchRequest);
                else
                {
                    GeneralQuestionLevelMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralQuestionLevelMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralQuestionLevelMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralQuestionLevelMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralQuestionLevelMasterCollection;
        }
        /// <summary>
        /// Select a record from GeneralQuestionLevelMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralQuestionLevelMaster> SelectByID(GeneralQuestionLevelMaster item)
        {
            IBaseEntityResponse<GeneralQuestionLevelMaster> entityResponse = new BaseEntityResponse<GeneralQuestionLevelMaster>();
            try
            {
                entityResponse = _GeneralQuestionLevelMasterDataProvider.GetGeneralQuestionLevelMasterByID(item);
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

