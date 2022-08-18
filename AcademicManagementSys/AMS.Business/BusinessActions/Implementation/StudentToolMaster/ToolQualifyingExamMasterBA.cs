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
namespace AMS.Business.BusinessAction
{
    public class ToolQualifyingExamMasterBA : IToolQualifyingExamMasterBA
    {
        IToolQualifyingExamMasterDataProvider _toolQualifyingExamMasterDataProvider;
        IToolQualifyingExamMasterBR _toolQualifyingExamMasterBR;
        private ILogger _logException;
        public ToolQualifyingExamMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _toolQualifyingExamMasterBR = new ToolQualifyingExamMasterBR();
            _toolQualifyingExamMasterDataProvider = new ToolQualifyingExamMasterDataProvider();
        }
        /// <summary>
        /// Create new record of ToolQualifyingExamMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<ToolQualifyingExamMaster> InsertToolQualifyingExamMaster(ToolQualifyingExamMaster item)
        {
            IBaseEntityResponse<ToolQualifyingExamMaster> entityResponse = new BaseEntityResponse<ToolQualifyingExamMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _toolQualifyingExamMasterBR.InsertToolQualifyingExamMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _toolQualifyingExamMasterDataProvider.InsertToolQualifyingExamMaster(item);
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
        /// Update a specific record  of ToolQualifyingExamMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<ToolQualifyingExamMaster> UpdateToolQualifyingExamMaster(ToolQualifyingExamMaster item)
        {
            IBaseEntityResponse<ToolQualifyingExamMaster> entityResponse = new BaseEntityResponse<ToolQualifyingExamMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _toolQualifyingExamMasterBR.UpdateToolQualifyingExamMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _toolQualifyingExamMasterDataProvider.UpdateToolQualifyingExamMaster(item);
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
        /// Delete a selected record from ToolQualifyingExamMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<ToolQualifyingExamMaster> DeleteToolQualifyingExamMaster(ToolQualifyingExamMaster item)
        {
            IBaseEntityResponse<ToolQualifyingExamMaster> entityResponse = new BaseEntityResponse<ToolQualifyingExamMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _toolQualifyingExamMasterBR.DeleteToolQualifyingExamMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _toolQualifyingExamMasterDataProvider.DeleteToolQualifyingExamMaster(item);
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
        /// Select all record from ToolQualifyingExamMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<ToolQualifyingExamMaster> GetBySearch(ToolQualifyingExamMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<ToolQualifyingExamMaster> ToolQualifyingExamMasterCollection = new BaseEntityCollectionResponse<ToolQualifyingExamMaster>();
            try
            {
                if (_toolQualifyingExamMasterDataProvider != null)
                    ToolQualifyingExamMasterCollection = _toolQualifyingExamMasterDataProvider.GetToolQualifyingExamMasterBySearch(searchRequest);
                else
                {
                    ToolQualifyingExamMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    ToolQualifyingExamMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                ToolQualifyingExamMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                ToolQualifyingExamMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return ToolQualifyingExamMasterCollection;
        }
        /// <summary>
        /// Select a record from ToolQualifyingExamMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<ToolQualifyingExamMaster> SelectByID(ToolQualifyingExamMaster item)
        {
            IBaseEntityResponse<ToolQualifyingExamMaster> entityResponse = new BaseEntityResponse<ToolQualifyingExamMaster>();
            try
            {
                entityResponse = _toolQualifyingExamMasterDataProvider.GetToolQualifyingExamMasterByID(item);
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
