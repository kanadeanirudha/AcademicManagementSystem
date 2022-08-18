


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
    public class OnlineExamAllocateSupportStaffBA : IOnlineExamAllocateSupportStaffBA
    {
        IOnlineExamAllocateSupportStaffDataProvider _OnlineExamAllocateSupportStaffDataProvider;
        IOnlineExamAllocateSupportStaffBR _OnlineExamAllocateSupportStaffBR;
        private ILogger _logException;
        public OnlineExamAllocateSupportStaffBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _OnlineExamAllocateSupportStaffBR = new OnlineExamAllocateSupportStaffBR();
            _OnlineExamAllocateSupportStaffDataProvider = new OnlineExamAllocateSupportStaffDataProvider();
        }
        /// <summary>
        /// Create new record of OnlineExamAllocateSupportStaff.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OnlineExamAllocateSupportStaff> InsertOnlineExamAllocateSupportStaff(OnlineExamAllocateSupportStaff item)
        {
            IBaseEntityResponse<OnlineExamAllocateSupportStaff> entityResponse = new BaseEntityResponse<OnlineExamAllocateSupportStaff>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _OnlineExamAllocateSupportStaffBR.InsertOnlineExamAllocateSupportStaffValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _OnlineExamAllocateSupportStaffDataProvider.InsertOnlineExamAllocateSupportStaff(item);
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
        /// Update a specific record  of OnlineExamAllocateSupportStaff.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OnlineExamAllocateSupportStaff> UpdateOnlineExamAllocateSupportStaff(OnlineExamAllocateSupportStaff item)
        {
            IBaseEntityResponse<OnlineExamAllocateSupportStaff> entityResponse = new BaseEntityResponse<OnlineExamAllocateSupportStaff>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _OnlineExamAllocateSupportStaffBR.UpdateOnlineExamAllocateSupportStaffValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _OnlineExamAllocateSupportStaffDataProvider.UpdateOnlineExamAllocateSupportStaff(item);
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
        /// Delete a selected record from OnlineExamAllocateSupportStaff.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OnlineExamAllocateSupportStaff> DeleteOnlineExamAllocateSupportStaff(OnlineExamAllocateSupportStaff item)
        {
            IBaseEntityResponse<OnlineExamAllocateSupportStaff> entityResponse = new BaseEntityResponse<OnlineExamAllocateSupportStaff>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _OnlineExamAllocateSupportStaffBR.DeleteOnlineExamAllocateSupportStaffValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _OnlineExamAllocateSupportStaffDataProvider.DeleteOnlineExamAllocateSupportStaff(item);
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
        /// Select all record from OnlineExamAllocateSupportStaff table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OnlineExamAllocateSupportStaff> GetBySearch(OnlineExamAllocateSupportStaffSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExamAllocateSupportStaff> OnlineExamAllocateSupportStaffCollection = new BaseEntityCollectionResponse<OnlineExamAllocateSupportStaff>();
            try
            {
                if (_OnlineExamAllocateSupportStaffDataProvider != null)
                    OnlineExamAllocateSupportStaffCollection = _OnlineExamAllocateSupportStaffDataProvider.GetOnlineExamAllocateSupportStaffBySearch(searchRequest);
                else
                {
                    OnlineExamAllocateSupportStaffCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OnlineExamAllocateSupportStaffCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OnlineExamAllocateSupportStaffCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OnlineExamAllocateSupportStaffCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OnlineExamAllocateSupportStaffCollection;
        }

        public IBaseEntityCollectionResponse<OnlineExamAllocateSupportStaff> GetOnlineExamAllocateSupportStaffSearchList(OnlineExamAllocateSupportStaffSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExamAllocateSupportStaff> OnlineExamAllocateSupportStaffCollection = new BaseEntityCollectionResponse<OnlineExamAllocateSupportStaff>();
            try
            {
                if (_OnlineExamAllocateSupportStaffDataProvider != null)
                    OnlineExamAllocateSupportStaffCollection = _OnlineExamAllocateSupportStaffDataProvider.GetOnlineExamAllocateSupportStaffSearchList(searchRequest);
                else
                {
                    OnlineExamAllocateSupportStaffCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OnlineExamAllocateSupportStaffCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OnlineExamAllocateSupportStaffCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OnlineExamAllocateSupportStaffCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OnlineExamAllocateSupportStaffCollection;
        }
        /// <summary>
        /// Select a record from OnlineExamAllocateSupportStaff table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OnlineExamAllocateSupportStaff> SelectByID(OnlineExamAllocateSupportStaff item)
        {
            IBaseEntityResponse<OnlineExamAllocateSupportStaff> entityResponse = new BaseEntityResponse<OnlineExamAllocateSupportStaff>();
            try
            {
                entityResponse = _OnlineExamAllocateSupportStaffDataProvider.GetOnlineExamAllocateSupportStaffByID(item);
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
        public IBaseEntityResponse<OnlineExamAllocateSupportStaff> InsertOnlineExamAllocateJobSupportStaff(OnlineExamAllocateSupportStaff item)
        {
            IBaseEntityResponse<OnlineExamAllocateSupportStaff> entityResponse = new BaseEntityResponse<OnlineExamAllocateSupportStaff>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _OnlineExamAllocateSupportStaffBR.InsertOnlineExamAllocateJobSupportStaffValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _OnlineExamAllocateSupportStaffDataProvider.InsertOnlineExamAllocateJobSupportStaff(item);
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
    }
}

