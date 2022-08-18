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
    public class ToolQualificationMasterSubjectBA : IToolQualificationMasterSubjectBA
    {
        IToolQualificationMasterSubjectDataProvider _ToolQualificationMasterSubjectDataProvider;
        IToolQualificationMasterSubjectBR _ToolQualificationMasterSubjectBR;
        private ILogger _logException;
        public ToolQualificationMasterSubjectBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _ToolQualificationMasterSubjectBR = new ToolQualificationMasterSubjectBR();
            _ToolQualificationMasterSubjectDataProvider = new ToolQualificationMasterSubjectDataProvider();
        }
        /// <summary>
        /// Create new record of ToolQualificationMasterSubject.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<ToolQualificationMasterSubject> InsertToolQualificationMasterSubject(ToolQualificationMasterSubject item)
        {
            IBaseEntityResponse<ToolQualificationMasterSubject> entityResponse = new BaseEntityResponse<ToolQualificationMasterSubject>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _ToolQualificationMasterSubjectBR.InsertToolQualificationMasterSubjectValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _ToolQualificationMasterSubjectDataProvider.InsertToolQualificationMasterSubject(item);
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
        /// Update a specific record  of ToolQualificationMasterSubject.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<ToolQualificationMasterSubject> UpdateToolQualificationMasterSubject(ToolQualificationMasterSubject item)
        {
            IBaseEntityResponse<ToolQualificationMasterSubject> entityResponse = new BaseEntityResponse<ToolQualificationMasterSubject>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _ToolQualificationMasterSubjectBR.UpdateToolQualificationMasterSubjectValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _ToolQualificationMasterSubjectDataProvider.UpdateToolQualificationMasterSubject(item);
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
        /// Delete a selected record from ToolQualificationMasterSubject.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<ToolQualificationMasterSubject> DeleteToolQualificationMasterSubject(ToolQualificationMasterSubject item)
        {
            IBaseEntityResponse<ToolQualificationMasterSubject> entityResponse = new BaseEntityResponse<ToolQualificationMasterSubject>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _ToolQualificationMasterSubjectBR.DeleteToolQualificationMasterSubjectValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _ToolQualificationMasterSubjectDataProvider.DeleteToolQualificationMasterSubject(item);
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
        /// Select all record from ToolQualificationMasterSubject table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<ToolQualificationMasterSubject> GetBySearch(ToolQualificationMasterSubjectSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<ToolQualificationMasterSubject> ToolQualificationMasterSubjectCollection = new BaseEntityCollectionResponse<ToolQualificationMasterSubject>();
            try
            {
                if (_ToolQualificationMasterSubjectDataProvider != null)
                    ToolQualificationMasterSubjectCollection = _ToolQualificationMasterSubjectDataProvider.GetToolQualificationMasterSubjectBySearch(searchRequest);
                else
                {
                    ToolQualificationMasterSubjectCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    ToolQualificationMasterSubjectCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                ToolQualificationMasterSubjectCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                ToolQualificationMasterSubjectCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return ToolQualificationMasterSubjectCollection;
        }
        /// <summary>
        /// Select a record from ToolQualificationMasterSubject table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<ToolQualificationMasterSubject> SelectByID(ToolQualificationMasterSubject item)
        {
            IBaseEntityResponse<ToolQualificationMasterSubject> entityResponse = new BaseEntityResponse<ToolQualificationMasterSubject>();
            try
            {
                entityResponse = _ToolQualificationMasterSubjectDataProvider.GetToolQualificationMasterSubjectByID(item);
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
        /// Select all record from ToolQualificationMasterSubject table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<ToolQualificationMasterSubject> GetByQualificationMasterSubjectList(ToolQualificationMasterSubjectSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<ToolQualificationMasterSubject> ToolQualificationMasterSubjectCollection = new BaseEntityCollectionResponse<ToolQualificationMasterSubject>();
            try
            {
                if (_ToolQualificationMasterSubjectDataProvider != null)
                    ToolQualificationMasterSubjectCollection = _ToolQualificationMasterSubjectDataProvider.GetByQualificationMasterSubjectList(searchRequest);
                else
                {
                    ToolQualificationMasterSubjectCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    ToolQualificationMasterSubjectCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                ToolQualificationMasterSubjectCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                ToolQualificationMasterSubjectCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return ToolQualificationMasterSubjectCollection;
        }

        /// <summary>
        /// Select all record from ToolQualificationMasterSubject table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<ToolQualificationMasterSubject> GetByQualificationMasterSubjectListByBranchDetailID_StandardNumber_EducationType(ToolQualificationMasterSubjectSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<ToolQualificationMasterSubject> ToolQualificationMasterSubjectCollection = new BaseEntityCollectionResponse<ToolQualificationMasterSubject>();
            try
            {
                if (_ToolQualificationMasterSubjectDataProvider != null)
                    ToolQualificationMasterSubjectCollection = _ToolQualificationMasterSubjectDataProvider.GetByQualificationMasterSubjectListByBranchDetailID_StandardNumber_EducationType(searchRequest);
                else
                {
                    ToolQualificationMasterSubjectCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    ToolQualificationMasterSubjectCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                ToolQualificationMasterSubjectCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                ToolQualificationMasterSubjectCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return ToolQualificationMasterSubjectCollection;
        }
    }
}
