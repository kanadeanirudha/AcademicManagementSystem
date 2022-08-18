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
    public class ToolQualifyingExamSubjectBA : IToolQualifyingExamSubjectBA
    {
        IToolQualifyingExamSubjectDataProvider _toolQualifyingExamSubjectDataProvider;
        IToolQualifyingExamSubjectBR _toolQualifyingExamSubjectBR;
        private ILogger _logException;
        public ToolQualifyingExamSubjectBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _toolQualifyingExamSubjectBR = new ToolQualifyingExamSubjectBR();
            _toolQualifyingExamSubjectDataProvider = new ToolQualifyingExamSubjectDataProvider();
        }
        /// <summary>
        /// Create new record of ToolQualifyingExamSubject.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<ToolQualifyingExamSubject> InsertToolQualifyingExamSubject(ToolQualifyingExamSubject item)
        {
            IBaseEntityResponse<ToolQualifyingExamSubject> entityResponse = new BaseEntityResponse<ToolQualifyingExamSubject>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _toolQualifyingExamSubjectBR.InsertToolQualifyingExamSubjectValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _toolQualifyingExamSubjectDataProvider.InsertToolQualifyingExamSubject(item);
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
        /// Update a specific record  of ToolQualifyingExamSubject.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<ToolQualifyingExamSubject> UpdateToolQualifyingExamSubject(ToolQualifyingExamSubject item)
        {
            IBaseEntityResponse<ToolQualifyingExamSubject> entityResponse = new BaseEntityResponse<ToolQualifyingExamSubject>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _toolQualifyingExamSubjectBR.UpdateToolQualifyingExamSubjectValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _toolQualifyingExamSubjectDataProvider.UpdateToolQualifyingExamSubject(item);
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
        /// Delete a selected record from ToolQualifyingExamSubject.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<ToolQualifyingExamSubject> DeleteToolQualifyingExamSubject(ToolQualifyingExamSubject item)
        {
            IBaseEntityResponse<ToolQualifyingExamSubject> entityResponse = new BaseEntityResponse<ToolQualifyingExamSubject>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _toolQualifyingExamSubjectBR.DeleteToolQualifyingExamSubjectValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _toolQualifyingExamSubjectDataProvider.DeleteToolQualifyingExamSubject(item);
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
        /// Select all record from ToolQualifyingExamSubject table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<ToolQualifyingExamSubject> GetBySearch(ToolQualifyingExamSubjectSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<ToolQualifyingExamSubject> ToolQualifyingExamSubjectCollection = new BaseEntityCollectionResponse<ToolQualifyingExamSubject>();
            try
            {
                if (_toolQualifyingExamSubjectDataProvider != null)
                    ToolQualifyingExamSubjectCollection = _toolQualifyingExamSubjectDataProvider.GetToolQualifyingExamSubjectBySearch(searchRequest);
                else
                {
                    ToolQualifyingExamSubjectCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    ToolQualifyingExamSubjectCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                ToolQualifyingExamSubjectCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                ToolQualifyingExamSubjectCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return ToolQualifyingExamSubjectCollection;
        }
        /// <summary>
        /// Select a record from ToolQualifyingExamSubject table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<ToolQualifyingExamSubject> SelectByID(ToolQualifyingExamSubject item)
        {
            IBaseEntityResponse<ToolQualifyingExamSubject> entityResponse = new BaseEntityResponse<ToolQualifyingExamSubject>();
            try
            {
                entityResponse = _toolQualifyingExamSubjectDataProvider.GetToolQualifyingExamSubjectByID(item);
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
        /// Select all record from ToolQualifyingExamSubject table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<ToolQualifyingExamSubject> GetByQualifyingExamSubjectList(ToolQualifyingExamSubjectSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<ToolQualifyingExamSubject> ToolQualifyingExamSubjectCollection = new BaseEntityCollectionResponse<ToolQualifyingExamSubject>();
            try
            {
                if (_toolQualifyingExamSubjectDataProvider != null)
                    ToolQualifyingExamSubjectCollection = _toolQualifyingExamSubjectDataProvider.GetByQualifyingExamSubjectList(searchRequest);
                else
                {
                    ToolQualifyingExamSubjectCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    ToolQualifyingExamSubjectCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                ToolQualifyingExamSubjectCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                ToolQualifyingExamSubjectCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return ToolQualifyingExamSubjectCollection;
        }
    }
}
