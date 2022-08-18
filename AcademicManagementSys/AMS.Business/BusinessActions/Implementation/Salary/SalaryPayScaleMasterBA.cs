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
    public class SalaryPayScaleMasterBA : ISalaryPayScaleMasterBA
    {
        ISalaryPayScaleMasterDataProvider _salaryPayScaleMasterDataProvider;
        ISalaryPayScaleMasterBR _salaryPayScaleMasterBR;
        private ILogger _logException;
        public SalaryPayScaleMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _salaryPayScaleMasterBR = new SalaryPayScaleMasterBR();
            _salaryPayScaleMasterDataProvider = new SalaryPayScaleMasterDataProvider();
        }
        /// <summary>
        /// Create new record of SalaryPayScaleMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalaryPayScaleMaster> InsertSalaryPayScaleMaster(SalaryPayScaleMaster item)
        {
            IBaseEntityResponse<SalaryPayScaleMaster> entityResponse = new BaseEntityResponse<SalaryPayScaleMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _salaryPayScaleMasterBR.InsertSalaryPayScaleMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _salaryPayScaleMasterDataProvider.InsertSalaryPayScaleMaster(item);
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
        /// Update a specific record  of SalaryPayScaleMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalaryPayScaleMaster> UpdateSalaryPayScaleMaster(SalaryPayScaleMaster item)
        {
            IBaseEntityResponse<SalaryPayScaleMaster> entityResponse = new BaseEntityResponse<SalaryPayScaleMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _salaryPayScaleMasterBR.UpdateSalaryPayScaleMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _salaryPayScaleMasterDataProvider.UpdateSalaryPayScaleMaster(item);
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
        /// Delete a selected record from SalaryPayScaleMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalaryPayScaleMaster> DeleteSalaryPayScaleMaster(SalaryPayScaleMaster item)
        {
            IBaseEntityResponse<SalaryPayScaleMaster> entityResponse = new BaseEntityResponse<SalaryPayScaleMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _salaryPayScaleMasterBR.DeleteSalaryPayScaleMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _salaryPayScaleMasterDataProvider.DeleteSalaryPayScaleMaster(item);
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
        /// Select all record from SalaryPayScaleMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<SalaryPayScaleMaster> GetBySearch(SalaryPayScaleMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalaryPayScaleMaster> SalaryPayScaleMasterCollection = new BaseEntityCollectionResponse<SalaryPayScaleMaster>();
            try
            {
                if (_salaryPayScaleMasterDataProvider != null)
                    SalaryPayScaleMasterCollection = _salaryPayScaleMasterDataProvider.GetSalaryPayScaleMasterBySearch(searchRequest);
                else
                {
                    SalaryPayScaleMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SalaryPayScaleMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SalaryPayScaleMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SalaryPayScaleMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SalaryPayScaleMasterCollection;
        }
        /// <summary>
        /// Select a record from SalaryPayScaleMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalaryPayScaleMaster> SelectByID(SalaryPayScaleMaster item)
        {
            IBaseEntityResponse<SalaryPayScaleMaster> entityResponse = new BaseEntityResponse<SalaryPayScaleMaster>();
            try
            {
                entityResponse = _salaryPayScaleMasterDataProvider.GetSalaryPayScaleMasterByID(item);
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
        /// Select all record from SalaryPayScaleMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<SalaryPayScaleMaster> GetSalaryPayRangeScale(SalaryPayScaleMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalaryPayScaleMaster> SalaryPayScaleMasterCollection = new BaseEntityCollectionResponse<SalaryPayScaleMaster>();
            try
            {
                if (_salaryPayScaleMasterDataProvider != null)
                    SalaryPayScaleMasterCollection = _salaryPayScaleMasterDataProvider.GetSalaryPayRangeScale(searchRequest);
                else
                {
                    SalaryPayScaleMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SalaryPayScaleMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SalaryPayScaleMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SalaryPayScaleMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SalaryPayScaleMasterCollection;
        }
    }
}
