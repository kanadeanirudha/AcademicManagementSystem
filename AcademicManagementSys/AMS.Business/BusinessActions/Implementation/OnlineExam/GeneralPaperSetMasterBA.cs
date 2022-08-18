
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
    public class GeneralPaperSetMasterBA : IGeneralPaperSetMasterBA
    {
        IGeneralPaperSetMasterDataProvider _GeneralPaperSetMasterDataProvider;
        IGeneralPaperSetMasterBR _GeneralPaperSetMasterBR;
        private ILogger _logException;
        public GeneralPaperSetMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _GeneralPaperSetMasterBR = new GeneralPaperSetMasterBR();
            _GeneralPaperSetMasterDataProvider = new GeneralPaperSetMasterDataProvider();
        }
        /// <summary>
        /// Create new record of GeneralPaperSetMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralPaperSetMaster> InsertGeneralPaperSetMaster(GeneralPaperSetMaster item)
        {
            IBaseEntityResponse<GeneralPaperSetMaster> entityResponse = new BaseEntityResponse<GeneralPaperSetMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralPaperSetMasterBR.InsertGeneralPaperSetMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralPaperSetMasterDataProvider.InsertGeneralPaperSetMaster(item);
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
        /// Update a specific record  of GeneralPaperSetMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralPaperSetMaster> UpdateGeneralPaperSetMaster(GeneralPaperSetMaster item)
        {
            IBaseEntityResponse<GeneralPaperSetMaster> entityResponse = new BaseEntityResponse<GeneralPaperSetMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralPaperSetMasterBR.UpdateGeneralPaperSetMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralPaperSetMasterDataProvider.UpdateGeneralPaperSetMaster(item);
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
        /// Delete a selected record from GeneralPaperSetMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralPaperSetMaster> DeleteGeneralPaperSetMaster(GeneralPaperSetMaster item)
        {
            IBaseEntityResponse<GeneralPaperSetMaster> entityResponse = new BaseEntityResponse<GeneralPaperSetMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralPaperSetMasterBR.DeleteGeneralPaperSetMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralPaperSetMasterDataProvider.DeleteGeneralPaperSetMaster(item);
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
        /// Select all record from GeneralPaperSetMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralPaperSetMaster> GetBySearch(GeneralPaperSetMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralPaperSetMaster> GeneralPaperSetMasterCollection = new BaseEntityCollectionResponse<GeneralPaperSetMaster>();
            try
            {
                if (_GeneralPaperSetMasterDataProvider != null)
                    GeneralPaperSetMasterCollection = _GeneralPaperSetMasterDataProvider.GetGeneralPaperSetMasterBySearch(searchRequest);
                else
                {
                    GeneralPaperSetMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralPaperSetMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralPaperSetMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralPaperSetMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralPaperSetMasterCollection;
        }

        public IBaseEntityCollectionResponse<GeneralPaperSetMaster> GetGeneralPaperSetMasterSearchList(GeneralPaperSetMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralPaperSetMaster> GeneralPaperSetMasterCollection = new BaseEntityCollectionResponse<GeneralPaperSetMaster>();
            try
            {
                if (_GeneralPaperSetMasterDataProvider != null)
                    GeneralPaperSetMasterCollection = _GeneralPaperSetMasterDataProvider.GetGeneralPaperSetMasterSearchList(searchRequest);
                else
                {
                    GeneralPaperSetMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralPaperSetMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralPaperSetMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralPaperSetMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralPaperSetMasterCollection;
        }
        /// <summary>
        /// Select a record from GeneralPaperSetMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralPaperSetMaster> SelectByID(GeneralPaperSetMaster item)
        {
            IBaseEntityResponse<GeneralPaperSetMaster> entityResponse = new BaseEntityResponse<GeneralPaperSetMaster>();
            try
            {
                entityResponse = _GeneralPaperSetMasterDataProvider.GetGeneralPaperSetMasterByID(item);
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
