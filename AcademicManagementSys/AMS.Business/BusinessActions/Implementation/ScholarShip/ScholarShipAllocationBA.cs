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
    public class ScholarShipAllocationBA : IScholarShipAllocationBA
    {
        IScholarShipAllocationDataProvider _scholarShipAllocationDataProvider;
        IScholarShipAllocationBR _scholarShipAllocationBR;
        private ILogger _logException;
        public ScholarShipAllocationBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _scholarShipAllocationBR = new ScholarShipAllocationBR();
            _scholarShipAllocationDataProvider = new ScholarShipAllocationDataProvider();
        }
        /// <summary>
        /// Create new record of ScholarShipAllocation.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<ScholarShipAllocation> InsertScholarShipAllocation(ScholarShipAllocation item)
        {
            IBaseEntityResponse<ScholarShipAllocation> entityResponse = new BaseEntityResponse<ScholarShipAllocation>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _scholarShipAllocationBR.InsertScholarShipAllocationValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _scholarShipAllocationDataProvider.InsertScholarShipAllocation(item);
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
        /// Create new record of ScholarShipAllocation.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<ScholarShipAllocation> InsertScholarShipAllocationApproveRequest(ScholarShipAllocation item)
        {
            IBaseEntityResponse<ScholarShipAllocation> entityResponse = new BaseEntityResponse<ScholarShipAllocation>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _scholarShipAllocationBR.InsertScholarShipAllocationValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _scholarShipAllocationDataProvider.InsertScholarShipAllocationApproveRequest(item);
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
        /// Update a specific record  of ScholarShipAllocation.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<ScholarShipAllocation> UpdateScholarShipAllocation(ScholarShipAllocation item)
        {
            IBaseEntityResponse<ScholarShipAllocation> entityResponse = new BaseEntityResponse<ScholarShipAllocation>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _scholarShipAllocationBR.UpdateScholarShipAllocationValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _scholarShipAllocationDataProvider.UpdateScholarShipAllocation(item);
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
        /// Delete a selected record from ScholarShipAllocation.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<ScholarShipAllocation> DeleteScholarShipAllocation(ScholarShipAllocation item)
        {
            IBaseEntityResponse<ScholarShipAllocation> entityResponse = new BaseEntityResponse<ScholarShipAllocation>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _scholarShipAllocationBR.DeleteScholarShipAllocationValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _scholarShipAllocationDataProvider.DeleteScholarShipAllocation(item);
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
        /// Select all record from ScholarShipAllocation table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<ScholarShipAllocation> GetScholarShipAllocationBySearch(ScholarShipAllocationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<ScholarShipAllocation> ScholarShipAllocationCollection = new BaseEntityCollectionResponse<ScholarShipAllocation>();
            try
            {
                if (_scholarShipAllocationDataProvider != null)
                    ScholarShipAllocationCollection = _scholarShipAllocationDataProvider.GetScholarShipAllocationBySearch(searchRequest);
                else
                {
                    ScholarShipAllocationCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    ScholarShipAllocationCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                ScholarShipAllocationCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                ScholarShipAllocationCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return ScholarShipAllocationCollection;
        }
        /// <summary>
        /// Select all record from ScholarShipAllocation table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<ScholarShipAllocation> GetScholarShipAllocationRequestForApproval(ScholarShipAllocationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<ScholarShipAllocation> ScholarShipAllocationCollection = new BaseEntityCollectionResponse<ScholarShipAllocation>();
            try
            {
                if (_scholarShipAllocationDataProvider != null)
                    ScholarShipAllocationCollection = _scholarShipAllocationDataProvider.GetScholarShipAllocationRequestForApproval(searchRequest);
                else
                {
                    ScholarShipAllocationCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    ScholarShipAllocationCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                ScholarShipAllocationCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                ScholarShipAllocationCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return ScholarShipAllocationCollection;
        }
        /// <summary>
        /// Select all record from ScholarShipAllocation table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<ScholarShipAllocation> GetStudentListBySearch(ScholarShipAllocationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<ScholarShipAllocation> ScholarShipAllocationCollection = new BaseEntityCollectionResponse<ScholarShipAllocation>();
            try
            {
                if (_scholarShipAllocationDataProvider != null)
                    ScholarShipAllocationCollection = _scholarShipAllocationDataProvider.GetStudentListBySearch(searchRequest);
                else
                {
                    ScholarShipAllocationCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    ScholarShipAllocationCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                ScholarShipAllocationCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                ScholarShipAllocationCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return ScholarShipAllocationCollection;
        }
        /// <summary>
        /// Select all record from ScholarShipAllocation table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<ScholarShipAllocation> GetCourseYearList(ScholarShipAllocationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<ScholarShipAllocation> ScholarShipAllocationCollection = new BaseEntityCollectionResponse<ScholarShipAllocation>();
            try
            {
                if (_scholarShipAllocationDataProvider != null)
                    ScholarShipAllocationCollection = _scholarShipAllocationDataProvider.GetCourseYearList(searchRequest);
                else
                {
                    ScholarShipAllocationCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    ScholarShipAllocationCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                ScholarShipAllocationCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                ScholarShipAllocationCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return ScholarShipAllocationCollection;
        }
        /// <summary>
        /// Select all record from ScholarShipAllocation table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<ScholarShipAllocation> GetScholarShipList(ScholarShipAllocationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<ScholarShipAllocation> ScholarShipAllocationCollection = new BaseEntityCollectionResponse<ScholarShipAllocation>();
            try
            {
                if (_scholarShipAllocationDataProvider != null)
                    ScholarShipAllocationCollection = _scholarShipAllocationDataProvider.GetScholarShipList(searchRequest);
                else
                {
                    ScholarShipAllocationCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    ScholarShipAllocationCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                ScholarShipAllocationCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                ScholarShipAllocationCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return ScholarShipAllocationCollection;
        }
        /// <summary>
        /// Select a record from ScholarShipAllocation table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<ScholarShipAllocation> GetScholarShipAllocationByID(ScholarShipAllocation item)
        {
            IBaseEntityResponse<ScholarShipAllocation> entityResponse = new BaseEntityResponse<ScholarShipAllocation>();
            try
            {
                entityResponse = _scholarShipAllocationDataProvider.GetScholarShipAllocationByID(item);
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
    }
}
