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
    public class SalaryPayRulesBA : ISalaryPayRulesBA
    {
        ISalaryPayRulesDataProvider _salaryPayRulesDataProvider;
        ISalaryPayRulesBR _salaryPayRulesBR;
        private ILogger _logException;
        public SalaryPayRulesBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _salaryPayRulesBR = new SalaryPayRulesBR();
            _salaryPayRulesDataProvider = new SalaryPayRulesDataProvider();
        }
        /// <summary>
        /// Create new record of SalaryPayRules.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalaryPayRules> InsertSalaryPayRules(SalaryPayRules item)
        {
            IBaseEntityResponse<SalaryPayRules> entityResponse = new BaseEntityResponse<SalaryPayRules>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _salaryPayRulesBR.InsertSalaryPayRulesValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _salaryPayRulesDataProvider.InsertSalaryPayRules(item);
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
        /// Update a specific record  of SalaryPayRules.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalaryPayRules> UpdateSalaryPayRules(SalaryPayRules item)
        {
            IBaseEntityResponse<SalaryPayRules> entityResponse = new BaseEntityResponse<SalaryPayRules>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _salaryPayRulesBR.UpdateSalaryPayRulesValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _salaryPayRulesDataProvider.UpdateSalaryPayRules(item);
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
        /// Delete a selected record from SalaryPayRules.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalaryPayRules> DeleteSalaryPayRules(SalaryPayRules item)
        {
            IBaseEntityResponse<SalaryPayRules> entityResponse = new BaseEntityResponse<SalaryPayRules>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _salaryPayRulesBR.DeleteSalaryPayRulesValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _salaryPayRulesDataProvider.DeleteSalaryPayRules(item);
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
        /// Select all record from SalaryPayRules table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<SalaryPayRules> GetBySearch(SalaryPayRulesSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalaryPayRules> SalaryPayRulesCollection = new BaseEntityCollectionResponse<SalaryPayRules>();
            try
            {
                if (_salaryPayRulesDataProvider != null)
                    SalaryPayRulesCollection = _salaryPayRulesDataProvider.GetBySearch(searchRequest);
                else
                {
                    SalaryPayRulesCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SalaryPayRulesCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SalaryPayRulesCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SalaryPayRulesCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SalaryPayRulesCollection;
        }
        /// <summary>
        /// Select a record from SalaryPayRules table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalaryPayRules> SelectByID(SalaryPayRules item)
        {
            IBaseEntityResponse<SalaryPayRules> entityResponse = new BaseEntityResponse<SalaryPayRules>();
            try
            {
                entityResponse = _salaryPayRulesDataProvider.GetSalaryPayRulesByID(item);
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
        //***************
        /// <summary>
        /// Select all record from SalaryPayRules table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<SalaryPayRules> GetBySearchList(SalaryPayRulesSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalaryPayRules> SalaryPayRulesCollection = new BaseEntityCollectionResponse<SalaryPayRules>();
            try
            {
                if (_salaryPayRulesDataProvider != null)
                    SalaryPayRulesCollection = _salaryPayRulesDataProvider.GetBySearchList(searchRequest);
                else
                {
                    SalaryPayRulesCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SalaryPayRulesCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SalaryPayRulesCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SalaryPayRulesCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SalaryPayRulesCollection;
        }
    }
}
