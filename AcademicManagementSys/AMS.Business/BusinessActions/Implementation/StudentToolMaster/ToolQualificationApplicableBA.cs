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
    public class ToolQualificationApplicableBA : IToolQualificationApplicableBA
    {
        IToolQualificationApplicableDataProvider _ToolQualificationApplicableDataProvider;
        IToolQualificationApplicableBR _ToolQualificationApplicableBR;
        private ILogger _logException;
        public ToolQualificationApplicableBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _ToolQualificationApplicableBR = new ToolQualificationApplicableBR();
            _ToolQualificationApplicableDataProvider = new ToolQualificationApplicableDataProvider();
        }
        /// <summary>
        /// Create new record of ToolQualificationApplicable.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<ToolQualificationApplicable> InsertToolQualificationApplicable(ToolQualificationApplicable item)
        {
            IBaseEntityResponse<ToolQualificationApplicable> entityResponse = new BaseEntityResponse<ToolQualificationApplicable>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _ToolQualificationApplicableBR.InsertToolQualificationApplicableValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _ToolQualificationApplicableDataProvider.InsertToolQualificationApplicable(item);
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
        /// Update a specific record  of ToolQualificationApplicable.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<ToolQualificationApplicable> UpdateToolQualificationApplicable(ToolQualificationApplicable item)
        {
            IBaseEntityResponse<ToolQualificationApplicable> entityResponse = new BaseEntityResponse<ToolQualificationApplicable>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _ToolQualificationApplicableBR.UpdateToolQualificationApplicableValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _ToolQualificationApplicableDataProvider.UpdateToolQualificationApplicable(item);
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
        /// Delete a selected record from ToolQualificationApplicable.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<ToolQualificationApplicable> DeleteToolQualificationApplicable(ToolQualificationApplicable item)
        {
            IBaseEntityResponse<ToolQualificationApplicable> entityResponse = new BaseEntityResponse<ToolQualificationApplicable>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _ToolQualificationApplicableBR.DeleteToolQualificationApplicableValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _ToolQualificationApplicableDataProvider.DeleteToolQualificationApplicable(item);
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
        /// Select all record from ToolQualificationApplicable table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<ToolQualificationApplicable> GetBySearch(ToolQualificationApplicableSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<ToolQualificationApplicable> ToolQualificationApplicableCollection = new BaseEntityCollectionResponse<ToolQualificationApplicable>();
            try
            {
                if (_ToolQualificationApplicableDataProvider != null)
                    ToolQualificationApplicableCollection = _ToolQualificationApplicableDataProvider.GetToolQualificationApplicableBySearch(searchRequest);
                else
                {
                    ToolQualificationApplicableCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    ToolQualificationApplicableCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                ToolQualificationApplicableCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                ToolQualificationApplicableCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return ToolQualificationApplicableCollection;
        }
        /// <summary>
        /// Select a record from ToolQualificationApplicable table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<ToolQualificationApplicable> SelectByID(ToolQualificationApplicable item)
        {
            IBaseEntityResponse<ToolQualificationApplicable> entityResponse = new BaseEntityResponse<ToolQualificationApplicable>();
            try
            {
                entityResponse = _ToolQualificationApplicableDataProvider.GetToolQualificationApplicableByID(item);
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
        /// Select all record from ToolQualificationApplicable table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<ToolQualificationApplicable> GetBySearchListBranchDetails(ToolQualificationApplicableSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<ToolQualificationApplicable> ToolQualificationApplicableCollection = new BaseEntityCollectionResponse<ToolQualificationApplicable>();
            try
            {
                if (_ToolQualificationApplicableDataProvider != null)
                    ToolQualificationApplicableCollection = _ToolQualificationApplicableDataProvider.GetToolQualificationApplicableBySearchListBranchDetails(searchRequest);
                else
                {
                    ToolQualificationApplicableCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    ToolQualificationApplicableCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                ToolQualificationApplicableCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                ToolQualificationApplicableCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return ToolQualificationApplicableCollection;
        }
    }
}
