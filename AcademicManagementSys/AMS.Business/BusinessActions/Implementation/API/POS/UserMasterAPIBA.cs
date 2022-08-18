using AMS.Base.DTO;
using AMS.Common;
using AMS.DataProvider;
using AMS.DTO;
using AMS.ExceptionManager;
using System;
namespace AMS.Business.BusinessAction
{
    public class UserMasterAPIBA : IUserMasterAPIBA
    {
        IUserMasterAPIDataProvider _UserMasterAPIDataProvider;
        private ILogger _logException;
        public UserMasterAPIBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _UserMasterAPIDataProvider = new UserMasterAPIDataProvider();
        }
        /// <summary>
        /// Create new record of UserMasterAPI.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// <summary>
        /// Select all record from UserMasterAPI table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<UserMasterAPI> GetUserMasterAPI(UserMasterAPISearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<UserMasterAPI> UserMasterAPICollection = new BaseEntityCollectionResponse<UserMasterAPI>();
            try
            {
                if (_UserMasterAPIDataProvider != null)
                    UserMasterAPICollection = _UserMasterAPIDataProvider.GetUserMasterAPI(searchRequest);
                else
                {
                    UserMasterAPICollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    UserMasterAPICollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                UserMasterAPICollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                UserMasterAPICollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return UserMasterAPICollection;
        }

        public IBaseEntityResponse<UserMasterAPI> PostUserLogAndLogsData(UserMasterAPI item)
        {
            IBaseEntityResponse<UserMasterAPI> entityResponse = new BaseEntityResponse<UserMasterAPI>();
            try
            {

                if (_UserMasterAPIDataProvider != null)
                {
                    entityResponse = _UserMasterAPIDataProvider.PostUserLogAndLogsData(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null;
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

        public IBaseEntityCollectionResponse<UserMasterAPI> GetAccountSessionMaster(UserMasterAPISearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<UserMasterAPI> UserMasterAPICollection = new BaseEntityCollectionResponse<UserMasterAPI>();
            try
            {
                if (_UserMasterAPIDataProvider != null)
                    UserMasterAPICollection = _UserMasterAPIDataProvider.GetAccountSessionMaster(searchRequest);
                else
                {
                    UserMasterAPICollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    UserMasterAPICollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                UserMasterAPICollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                UserMasterAPICollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return UserMasterAPICollection;
        }
    }
}
