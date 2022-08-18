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
    public class ToolTemplateRegistrationBA : IToolTemplateRegistrationBA
    {
        IToolTemplateRegistrationDataProvider _ToolTemplateRegistrationDataProvider;
        IToolTemplateRegistrationBR _ToolTemplateRegistrationBR;
        private ILogger _logException;
        public ToolTemplateRegistrationBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _ToolTemplateRegistrationBR = new ToolTemplateRegistrationBR();
            _ToolTemplateRegistrationDataProvider = new ToolTemplateRegistrationDataProvider();
        }
        /// <summary>
        /// Create new record of ToolTemplateRegistration.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<ToolTemplateRegistration> InsertToolTemplateRegistration(ToolTemplateRegistration item)
        {
            IBaseEntityResponse<ToolTemplateRegistration> entityResponse = new BaseEntityResponse<ToolTemplateRegistration>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _ToolTemplateRegistrationBR.InsertToolTemplateRegistrationValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _ToolTemplateRegistrationDataProvider.InsertToolTemplateRegistration(item);
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
        /// Update a specific record  of ToolTemplateRegistration.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<ToolTemplateRegistration> UpdateToolTemplateRegistration(ToolTemplateRegistration item)
        {
            IBaseEntityResponse<ToolTemplateRegistration> entityResponse = new BaseEntityResponse<ToolTemplateRegistration>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _ToolTemplateRegistrationBR.UpdateToolTemplateRegistrationValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _ToolTemplateRegistrationDataProvider.UpdateToolTemplateRegistration(item);
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
        /// Delete a selected record from ToolTemplateRegistration.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<ToolTemplateRegistration> DeleteToolTemplateRegistration(ToolTemplateRegistration item)
        {
            IBaseEntityResponse<ToolTemplateRegistration> entityResponse = new BaseEntityResponse<ToolTemplateRegistration>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _ToolTemplateRegistrationBR.DeleteToolTemplateRegistrationValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _ToolTemplateRegistrationDataProvider.DeleteToolTemplateRegistration(item);
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
        /// Select all record from ToolTemplateRegistration table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<ToolTemplateRegistration> GetBySearch(ToolTemplateRegistrationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<ToolTemplateRegistration> ToolTemplateRegistrationCollection = new BaseEntityCollectionResponse<ToolTemplateRegistration>();
            try
            {
                if (_ToolTemplateRegistrationDataProvider != null)
                    ToolTemplateRegistrationCollection = _ToolTemplateRegistrationDataProvider.GetToolTemplateRegistrationBySearch(searchRequest);
                else
                {
                    ToolTemplateRegistrationCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    ToolTemplateRegistrationCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                ToolTemplateRegistrationCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                ToolTemplateRegistrationCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return ToolTemplateRegistrationCollection;
        }
        /// <summary>
        /// Select a record from ToolTemplateRegistration table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<ToolTemplateRegistration> SelectByID(ToolTemplateRegistration item)
        {
            IBaseEntityResponse<ToolTemplateRegistration> entityResponse = new BaseEntityResponse<ToolTemplateRegistration>();
            try
            {
                entityResponse = _ToolTemplateRegistrationDataProvider.GetToolTemplateRegistrationByID(item);
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
        /// Select all record from ToolTemplateRegistration table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<ToolTemplateRegistration> GetByToolRegistrationFieldList(ToolTemplateRegistrationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<ToolTemplateRegistration> ToolTemplateRegistrationCollection = new BaseEntityCollectionResponse<ToolTemplateRegistration>();
            try
            {
                if (_ToolTemplateRegistrationDataProvider != null)
                    ToolTemplateRegistrationCollection = _ToolTemplateRegistrationDataProvider.GetToolTemplateRegistrationFieldBySearchList(searchRequest);
                else
                {
                    ToolTemplateRegistrationCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    ToolTemplateRegistrationCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                ToolTemplateRegistrationCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                ToolTemplateRegistrationCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return ToolTemplateRegistrationCollection;
        }
    }
}
