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
    public class ToolTemplateApplicableBA : IToolTemplateApplicableBA
    {
        IToolTemplateApplicableDataProvider _toolTemplateApplicableDataProvider;
        IToolTemplateApplicableBR _toolTemplateApplicableBR;
        private ILogger _logException;
        public ToolTemplateApplicableBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _toolTemplateApplicableBR = new ToolTemplateApplicableBR();
            _toolTemplateApplicableDataProvider = new ToolTemplateApplicableDataProvider();
        }
        /// <summary>
        /// Create new record of ToolTemplateApplicable.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<ToolTemplateApplicable> InsertToolTemplateApplicable(ToolTemplateApplicable item)
        {
            IBaseEntityResponse<ToolTemplateApplicable> entityResponse = new BaseEntityResponse<ToolTemplateApplicable>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _toolTemplateApplicableBR.InsertToolTemplateApplicableValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _toolTemplateApplicableDataProvider.InsertToolTemplateApplicable(item);
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
        /// Update a specific record  of ToolTemplateApplicable.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<ToolTemplateApplicable> UpdateToolTemplateApplicable(ToolTemplateApplicable item)
        {
            IBaseEntityResponse<ToolTemplateApplicable> entityResponse = new BaseEntityResponse<ToolTemplateApplicable>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _toolTemplateApplicableBR.UpdateToolTemplateApplicableValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _toolTemplateApplicableDataProvider.UpdateToolTemplateApplicable(item);
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
        /// Delete a selected record from ToolTemplateApplicable.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<ToolTemplateApplicable> DeleteToolTemplateApplicable(ToolTemplateApplicable item)
        {
            IBaseEntityResponse<ToolTemplateApplicable> entityResponse = new BaseEntityResponse<ToolTemplateApplicable>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _toolTemplateApplicableBR.DeleteToolTemplateApplicableValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _toolTemplateApplicableDataProvider.DeleteToolTemplateApplicable(item);
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
        /// Select all record from ToolTemplateApplicable table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<ToolTemplateApplicable> GetBySearch(ToolTemplateApplicableSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<ToolTemplateApplicable> ToolTemplateApplicableCollection = new BaseEntityCollectionResponse<ToolTemplateApplicable>();
            try
            {
                if (_toolTemplateApplicableDataProvider != null)
                    ToolTemplateApplicableCollection = _toolTemplateApplicableDataProvider.GetToolTemplateApplicableBySearch(searchRequest);
                else
                {
                    ToolTemplateApplicableCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    ToolTemplateApplicableCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                ToolTemplateApplicableCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                ToolTemplateApplicableCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return ToolTemplateApplicableCollection;
        }
        /// <summary>
        /// Select a record from ToolTemplateApplicable table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<ToolTemplateApplicable> SelectByID(ToolTemplateApplicable item)
        {
            IBaseEntityResponse<ToolTemplateApplicable> entityResponse = new BaseEntityResponse<ToolTemplateApplicable>();
            try
            {
                entityResponse = _toolTemplateApplicableDataProvider.GetToolTemplateApplicableByID(item);
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
        /// Select all record from ToolTemplateApplicable table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<ToolTemplateApplicable> GetBySearchListBranchDetails(ToolTemplateApplicableSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<ToolTemplateApplicable> ToolTemplateApplicableCollection = new BaseEntityCollectionResponse<ToolTemplateApplicable>();
            try
            {
                if (_toolTemplateApplicableDataProvider != null)
                    ToolTemplateApplicableCollection = _toolTemplateApplicableDataProvider.GetToolTemplateApplicableBySearchBranchDetails(searchRequest);
                else
                {
                    ToolTemplateApplicableCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    ToolTemplateApplicableCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                ToolTemplateApplicableCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                ToolTemplateApplicableCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return ToolTemplateApplicableCollection;
        }
    }
}
