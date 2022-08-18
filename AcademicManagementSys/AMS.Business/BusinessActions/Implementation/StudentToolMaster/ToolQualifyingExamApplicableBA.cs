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
    public class ToolQualifyingExamApplicableBA : IToolQualifyingExamApplicableBA
    {
        IToolQualifyingExamApplicableDataProvider _toolQualifyingExamApplicableDataProvider;
        IToolQualifyingExamApplicableBR _toolQualifyingExamApplicableBR;
        private ILogger _logException;
        public ToolQualifyingExamApplicableBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _toolQualifyingExamApplicableBR = new ToolQualifyingExamApplicableBR();
            _toolQualifyingExamApplicableDataProvider = new ToolQualifyingExamApplicableDataProvider();
        }
        /// <summary>
        /// Create new record of ToolQualifyingExamApplicable.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<ToolQualifyingExamApplicable> InsertToolQualifyingExamApplicable(ToolQualifyingExamApplicable item)
        {
            IBaseEntityResponse<ToolQualifyingExamApplicable> entityResponse = new BaseEntityResponse<ToolQualifyingExamApplicable>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _toolQualifyingExamApplicableBR.InsertToolQualifyingExamApplicableValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _toolQualifyingExamApplicableDataProvider.InsertToolQualifyingExamApplicable(item);
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
        /// Update a specific record  of ToolQualifyingExamApplicable.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<ToolQualifyingExamApplicable> UpdateToolQualifyingExamApplicable(ToolQualifyingExamApplicable item)
        {
            IBaseEntityResponse<ToolQualifyingExamApplicable> entityResponse = new BaseEntityResponse<ToolQualifyingExamApplicable>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _toolQualifyingExamApplicableBR.UpdateToolQualifyingExamApplicableValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _toolQualifyingExamApplicableDataProvider.UpdateToolQualifyingExamApplicable(item);
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
        /// Delete a selected record from ToolQualifyingExamApplicable.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<ToolQualifyingExamApplicable> DeleteToolQualifyingExamApplicable(ToolQualifyingExamApplicable item)
        {
            IBaseEntityResponse<ToolQualifyingExamApplicable> entityResponse = new BaseEntityResponse<ToolQualifyingExamApplicable>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _toolQualifyingExamApplicableBR.DeleteToolQualifyingExamApplicableValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _toolQualifyingExamApplicableDataProvider.DeleteToolQualifyingExamApplicable(item);
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
        /// Select all record from ToolQualifyingExamApplicable table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<ToolQualifyingExamApplicable> GetBySearch(ToolQualifyingExamApplicableSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<ToolQualifyingExamApplicable> ToolQualifyingExamApplicableCollection = new BaseEntityCollectionResponse<ToolQualifyingExamApplicable>();
            try
            {
                if (_toolQualifyingExamApplicableDataProvider != null)
                    ToolQualifyingExamApplicableCollection = _toolQualifyingExamApplicableDataProvider.GetToolQualifyingExamApplicableBySearch(searchRequest);
                else
                {
                    ToolQualifyingExamApplicableCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    ToolQualifyingExamApplicableCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                ToolQualifyingExamApplicableCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                ToolQualifyingExamApplicableCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return ToolQualifyingExamApplicableCollection;
        }
        /// <summary>
        /// Select a record from ToolQualifyingExamApplicable table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<ToolQualifyingExamApplicable> SelectByID(ToolQualifyingExamApplicable item)
        {
            IBaseEntityResponse<ToolQualifyingExamApplicable> entityResponse = new BaseEntityResponse<ToolQualifyingExamApplicable>();
            try
            {
                entityResponse = _toolQualifyingExamApplicableDataProvider.GetToolQualifyingExamApplicableByID(item);
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
        /// Select all record from ToolQualifyingExamApplicable table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<ToolQualifyingExamApplicable> GetBySearchListBranchDetails(ToolQualifyingExamApplicableSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<ToolQualifyingExamApplicable> ToolQualifyingExamApplicableCollection = new BaseEntityCollectionResponse<ToolQualifyingExamApplicable>();
            try
            {
                if (_toolQualifyingExamApplicableDataProvider != null)
                    ToolQualifyingExamApplicableCollection = _toolQualifyingExamApplicableDataProvider.GetToolQualifyingExamApplicableBySearchListBranchDetails(searchRequest);
                else
                {
                    ToolQualifyingExamApplicableCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    ToolQualifyingExamApplicableCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                ToolQualifyingExamApplicableCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                ToolQualifyingExamApplicableCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return ToolQualifyingExamApplicableCollection;
        }
    }
}
