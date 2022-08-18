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
    public class ToolQualificationExamMasterBA : IToolQualificationExamMasterBA
    {
        IToolQualificationExamMasterDataProvider _toolQualificationExamMasterDataProvider;
        IToolQualificationExamMasterBR _toolQualificationExamMasterBR;
        private ILogger _logException;
        public ToolQualificationExamMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _toolQualificationExamMasterBR = new ToolQualificationExamMasterBR();
            _toolQualificationExamMasterDataProvider = new ToolQualificationExamMasterDataProvider();
        }
        /// <summary>
        /// Create new record of ToolQualificationExamMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<ToolQualificationExamMaster> InsertToolQualificationExamMaster(ToolQualificationExamMaster item)
        {
            IBaseEntityResponse<ToolQualificationExamMaster> entityResponse = new BaseEntityResponse<ToolQualificationExamMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _toolQualificationExamMasterBR.InsertToolQualificationExamMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _toolQualificationExamMasterDataProvider.InsertToolQualificationExamMaster(item);
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
        /// Update a specific record  of ToolQualificationExamMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<ToolQualificationExamMaster> UpdateToolQualificationExamMaster(ToolQualificationExamMaster item)
        {
            IBaseEntityResponse<ToolQualificationExamMaster> entityResponse = new BaseEntityResponse<ToolQualificationExamMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _toolQualificationExamMasterBR.UpdateToolQualificationExamMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _toolQualificationExamMasterDataProvider.UpdateToolQualificationExamMaster(item);
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
        /// Delete a selected record from ToolQualificationExamMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<ToolQualificationExamMaster> DeleteToolQualificationExamMaster(ToolQualificationExamMaster item)
        {
            IBaseEntityResponse<ToolQualificationExamMaster> entityResponse = new BaseEntityResponse<ToolQualificationExamMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _toolQualificationExamMasterBR.DeleteToolQualificationExamMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _toolQualificationExamMasterDataProvider.DeleteToolQualificationExamMaster(item);
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
        /// Select all record from ToolQualificationExamMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<ToolQualificationExamMaster> GetBySearch(ToolQualificationExamMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<ToolQualificationExamMaster> ToolQualificationExamMasterCollection = new BaseEntityCollectionResponse<ToolQualificationExamMaster>();
            try
            {
                if (_toolQualificationExamMasterDataProvider != null)
                    ToolQualificationExamMasterCollection = _toolQualificationExamMasterDataProvider.GetToolQualificationExamMasterBySearch(searchRequest);
                else
                {
                    ToolQualificationExamMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    ToolQualificationExamMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                ToolQualificationExamMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                ToolQualificationExamMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return ToolQualificationExamMasterCollection;
        }
        /// <summary>
        /// Select a record from ToolQualificationExamMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<ToolQualificationExamMaster> SelectByID(ToolQualificationExamMaster item)
        {
            IBaseEntityResponse<ToolQualificationExamMaster> entityResponse = new BaseEntityResponse<ToolQualificationExamMaster>();
            try
            {
                entityResponse = _toolQualificationExamMasterDataProvider.GetToolQualificationExamMasterByID(item);
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
