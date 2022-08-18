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
namespace AMS.Business.BusinessActions
{
    public class CRMSaleJobUserJobScheduleSheetBA : ICRMSaleJobUserJobScheduleSheetBA
    {
        ICRMSaleJobUserJobScheduleSheetDataProvider cRMSaleJobUserJobScheduleSheetDataProvider;
        ICRMSaleJobUserJobScheduleSheetBR cRMSaleJobUserJobScheduleSheetBR;

        private ILogger _logException;

        public CRMSaleJobUserJobScheduleSheetBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            cRMSaleJobUserJobScheduleSheetBR = new CRMSaleJobUserJobScheduleSheetBR();
            cRMSaleJobUserJobScheduleSheetDataProvider = new CRMSaleJobUserJobScheduleSheetDataProviderDataProvider();
        }

        //CRMSaleJobUserJobScheduleSheet
        public IBaseEntityResponse<CRMSaleJobUserJobScheduleSheet> InsertCRMSaleJobUserJobScheduleSheet(CRMSaleJobUserJobScheduleSheet item)
        {
            IBaseEntityResponse<CRMSaleJobUserJobScheduleSheet> entityResponse = new BaseEntityResponse<CRMSaleJobUserJobScheduleSheet>();
            try
            {
                IValidateBusinessRuleResponse brResponse = cRMSaleJobUserJobScheduleSheetBR.InsertCRMSaleJobUserJobScheduleSheetValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = cRMSaleJobUserJobScheduleSheetDataProvider.InsertCRMSaleJobUserJobScheduleSheet(item);
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
        public IBaseEntityResponse<CRMSaleJobUserJobScheduleSheet> UpdateCRMSaleJobUserJobScheduleSheet(CRMSaleJobUserJobScheduleSheet item)
        {
            IBaseEntityResponse<CRMSaleJobUserJobScheduleSheet> entityResponse = new BaseEntityResponse<CRMSaleJobUserJobScheduleSheet>();
            try
            {
                IValidateBusinessRuleResponse brResponse = cRMSaleJobUserJobScheduleSheetBR.UpdateCRMSaleJobUserJobScheduleSheetValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = cRMSaleJobUserJobScheduleSheetDataProvider.UpdateCRMSaleJobUserJobScheduleSheet(item);
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
        public IBaseEntityResponse<CRMSaleJobUserJobScheduleSheet> DeleteCRMSaleJobUserJobScheduleSheet(CRMSaleJobUserJobScheduleSheet item)
        {
            IBaseEntityResponse<CRMSaleJobUserJobScheduleSheet> entityResponse = new BaseEntityResponse<CRMSaleJobUserJobScheduleSheet>();
            try
            {
                IValidateBusinessRuleResponse brResponse = cRMSaleJobUserJobScheduleSheetBR.DeleteCRMSaleJobUserJobScheduleSheetValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = cRMSaleJobUserJobScheduleSheetDataProvider.DeleteCRMSaleJobUserJobScheduleSheet(item);
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
        public IBaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet> GetCRMSaleJobUserJobScheduleSheetSearchList(CRMSaleJobUserJobScheduleSheetSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet> cRMSaleJobUserJobScheduleSheetCollection = new BaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet>();
            try
            {
                if (cRMSaleJobUserJobScheduleSheetDataProvider != null)
                    cRMSaleJobUserJobScheduleSheetCollection = cRMSaleJobUserJobScheduleSheetDataProvider.GetCRMSaleJobUserJobScheduleSheetSearchList(searchRequest);
                else
                {
                    cRMSaleJobUserJobScheduleSheetCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    cRMSaleJobUserJobScheduleSheetCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                cRMSaleJobUserJobScheduleSheetCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                cRMSaleJobUserJobScheduleSheetCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return cRMSaleJobUserJobScheduleSheetCollection;
        }
        public IBaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet> SelectByCRMSaleJobUserJobScheduleSheetID(CRMSaleJobUserJobScheduleSheetSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet> entityResponse = new BaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet>();
            try
            {
                entityResponse = cRMSaleJobUserJobScheduleSheetDataProvider.SelectByCRMSaleJobUserJobScheduleSheetID(searchRequest);
            }
            catch (Exception ex)
            {
                entityResponse.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });                
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return entityResponse;
        }
        public IBaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet> GetEmployeeJobsList(CRMSaleJobUserJobScheduleSheetSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet> JobCollection = new BaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet>();
            try
            {
                if (cRMSaleJobUserJobScheduleSheetDataProvider != null)
                    JobCollection = cRMSaleJobUserJobScheduleSheetDataProvider.GetEmployeeJobsList(searchRequest);
                else
                {
                    JobCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    JobCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                JobCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                JobCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return JobCollection;
        }
        public IBaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet> GetBySearchCRMSaleJobUserJobScheduleSheet(CRMSaleJobUserJobScheduleSheetSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet> CRMSaleJobUserJobScheduleSheetCollection = new BaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet>();
            try
            {
                if (cRMSaleJobUserJobScheduleSheetDataProvider != null)
                    CRMSaleJobUserJobScheduleSheetCollection = cRMSaleJobUserJobScheduleSheetDataProvider.GetBySearchCRMSaleJobUserJobScheduleSheet(searchRequest);
                else
                {
                    CRMSaleJobUserJobScheduleSheetCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CRMSaleJobUserJobScheduleSheetCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CRMSaleJobUserJobScheduleSheetCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CRMSaleJobUserJobScheduleSheetCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CRMSaleJobUserJobScheduleSheetCollection;
        }

        public IBaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet> GetGeneralOtherJobTypeList(CRMSaleJobUserJobScheduleSheetSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet> JobTypeCollection = new BaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet>();
            try
            {
                if (cRMSaleJobUserJobScheduleSheetDataProvider != null)
                    JobTypeCollection = cRMSaleJobUserJobScheduleSheetDataProvider.GetGeneralOtherJobTypeList(searchRequest);
                else
                {
                    JobTypeCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    JobTypeCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                JobTypeCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                JobTypeCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return JobTypeCollection;
        }

        //CRMSaleJobUserJobScheduleSheetUpdate
        public IBaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet> GetBySearchCRMSaleJobUserJobScheduleSheetUpdate(CRMSaleJobUserJobScheduleSheetSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet> CRMSaleJobUserJobScheduleSheetCollection = new BaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet>();
            try
            {
                if (cRMSaleJobUserJobScheduleSheetDataProvider != null)
                    CRMSaleJobUserJobScheduleSheetCollection = cRMSaleJobUserJobScheduleSheetDataProvider.GetBySearchCRMSaleJobUserJobScheduleSheetUpdate(searchRequest);
                else
                {
                    CRMSaleJobUserJobScheduleSheetCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CRMSaleJobUserJobScheduleSheetCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CRMSaleJobUserJobScheduleSheetCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CRMSaleJobUserJobScheduleSheetCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CRMSaleJobUserJobScheduleSheetCollection;
        }
        public IBaseEntityResponse<CRMSaleJobUserJobScheduleSheet> UpdateCRMSaleJobUserJobScheduleSheetUpdate(CRMSaleJobUserJobScheduleSheet item)
        {
            IBaseEntityResponse<CRMSaleJobUserJobScheduleSheet> entityResponse = new BaseEntityResponse<CRMSaleJobUserJobScheduleSheet>();
            try
            {
                IValidateBusinessRuleResponse brResponse = cRMSaleJobUserJobScheduleSheetBR.UpdateCRMSaleJobUserJobScheduleSheetUpdateValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = cRMSaleJobUserJobScheduleSheetDataProvider.UpdateCRMSaleJobUserJobScheduleSheetUpdate(item);
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



        public IBaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet> GetAllocatedJobEmployeeList(CRMSaleJobUserJobScheduleSheetSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet> allocatedJobEmployee = new BaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet>();
            try
            {
                if (cRMSaleJobUserJobScheduleSheetDataProvider != null)
                    allocatedJobEmployee = cRMSaleJobUserJobScheduleSheetDataProvider.GetAllocatedJobEmployeeList(searchRequest);
                else
                {
                    allocatedJobEmployee.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    allocatedJobEmployee.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                allocatedJobEmployee.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                allocatedJobEmployee.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return allocatedJobEmployee;
        }

        //public IBaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet> GetListTodaysMeetingSchedule(CRMSaleJobUserJobScheduleSheetSearchRequest searchRequest)
        //{
        //    IBaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet> todaysSchedule = new BaseEntityCollectionResponse<CRMSaleJobUserJobScheduleSheet>();
        //    try
        //    {
        //        if (cRMSaleJobUserJobScheduleSheetDataProvider != null)
        //            todaysSchedule = cRMSaleJobUserJobScheduleSheetDataProvider.GetListTodaysMeetingSchedule(searchRequest);
        //        else
        //        {
        //            todaysSchedule.Message.Add(new MessageDTO
        //            {
        //                ErrorMessage = Resources.Null_Object_Exception,
        //                MessageType = MessageTypeEnum.Error
        //            });
        //            todaysSchedule.CollectionResponse = null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        todaysSchedule.Message.Add(new MessageDTO
        //        {
        //            ErrorMessage = ex.Message,
        //            MessageType = MessageTypeEnum.Error
        //        });
        //        todaysSchedule.CollectionResponse = null;
        //        if (_logException != null)
        //        {
        //            _logException.Error(ex.Message);
        //        }
        //    }
        //    return todaysSchedule;
        //}

    }
}
