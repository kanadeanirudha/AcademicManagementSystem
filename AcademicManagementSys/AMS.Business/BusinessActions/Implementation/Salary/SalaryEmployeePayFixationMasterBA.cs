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
    public class SalaryEmployeePayFixationMasterBA : ISalaryEmployeePayFixationMasterBA
    {
        ISalaryEmployeePayFixationMasterDataProvider _SalaryEmployeePayFixationMasterDataProvider;
        ISalaryEmployeePayFixationMasterBR _SalaryEmployeePayFixationMasterBR;
        private ILogger _logException;
        public SalaryEmployeePayFixationMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _SalaryEmployeePayFixationMasterBR = new SalaryEmployeePayFixationMasterBR();
            _SalaryEmployeePayFixationMasterDataProvider = new SalaryEmployeePayFixationMasterDataProvider();
        }
        /// <summary>
        /// Create new record of SalaryEmployeePayFixationMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalaryEmployeePayFixationMaster> InsertSalaryEmployeePayFixationMaster(SalaryEmployeePayFixationMaster item)
        {
            IBaseEntityResponse<SalaryEmployeePayFixationMaster> entityResponse = new BaseEntityResponse<SalaryEmployeePayFixationMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _SalaryEmployeePayFixationMasterBR.InsertSalaryEmployeePayFixationMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _SalaryEmployeePayFixationMasterDataProvider.InsertSalaryEmployeePayFixationMaster(item);
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
        /// Update a specific record  of SalaryEmployeePayFixationMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalaryEmployeePayFixationMaster> UpdateSalaryEmployeePayFixationMaster(SalaryEmployeePayFixationMaster item)
        {
            IBaseEntityResponse<SalaryEmployeePayFixationMaster> entityResponse = new BaseEntityResponse<SalaryEmployeePayFixationMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _SalaryEmployeePayFixationMasterBR.UpdateSalaryEmployeePayFixationMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _SalaryEmployeePayFixationMasterDataProvider.UpdateSalaryEmployeePayFixationMaster(item);
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
        /// Delete a selected record from SalaryEmployeePayFixationMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalaryEmployeePayFixationMaster> DeleteSalaryEmployeePayFixationMaster(SalaryEmployeePayFixationMaster item)
        {
            IBaseEntityResponse<SalaryEmployeePayFixationMaster> entityResponse = new BaseEntityResponse<SalaryEmployeePayFixationMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _SalaryEmployeePayFixationMasterBR.DeleteSalaryEmployeePayFixationMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _SalaryEmployeePayFixationMasterDataProvider.DeleteSalaryEmployeePayFixationMaster(item);
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
        /// Select all record from SalaryEmployeePayFixationMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<SalaryEmployeePayFixationMaster> GetBySearch(SalaryEmployeePayFixationMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalaryEmployeePayFixationMaster> SalaryEmployeePayFixationMasterCollection = new BaseEntityCollectionResponse<SalaryEmployeePayFixationMaster>();
            try
            {
                if (_SalaryEmployeePayFixationMasterDataProvider != null)
                    SalaryEmployeePayFixationMasterCollection = _SalaryEmployeePayFixationMasterDataProvider.GetBySearch(searchRequest);
                else
                {
                    SalaryEmployeePayFixationMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SalaryEmployeePayFixationMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SalaryEmployeePayFixationMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SalaryEmployeePayFixationMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SalaryEmployeePayFixationMasterCollection;
        }
        /// <summary>
        /// Select a record from SalaryEmployeePayFixationMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalaryEmployeePayFixationMaster> SelectByID(SalaryEmployeePayFixationMaster item)
        {
            IBaseEntityResponse<SalaryEmployeePayFixationMaster> entityResponse = new BaseEntityResponse<SalaryEmployeePayFixationMaster>();
            try
            {
                entityResponse = _SalaryEmployeePayFixationMasterDataProvider.GetSalaryEmployeePayFixationMasterByID(item);
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
        /// Select all record from SalaryEmployeePayFixationMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<SalaryEmployeePayFixationMaster> GetBySearchList(SalaryEmployeePayFixationMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalaryEmployeePayFixationMaster> SalaryEmployeePayFixationMasterCollection = new BaseEntityCollectionResponse<SalaryEmployeePayFixationMaster>();
            try
            {
                if (_SalaryEmployeePayFixationMasterDataProvider != null)
                    SalaryEmployeePayFixationMasterCollection = _SalaryEmployeePayFixationMasterDataProvider.GetBySearchList(searchRequest);
                else
                {
                    SalaryEmployeePayFixationMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SalaryEmployeePayFixationMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SalaryEmployeePayFixationMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SalaryEmployeePayFixationMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SalaryEmployeePayFixationMasterCollection;
        }
    }
}
