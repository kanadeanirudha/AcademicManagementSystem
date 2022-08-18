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
    public class POSCounterBA : IPOSCounterBA
    {
        IPOSCounterDataProvider _POSCounterDataProvider;
        IUserMasterBR _userMasterBR;
        private ILogger _logException;

        public POSCounterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _userMasterBR = new UserMasterBR();
            _POSCounterDataProvider = new POSCounterDataProvider();
        }

        public IBaseEntityCollectionResponse<POSCounter> GeneralCounterPOSApplicableGetOnline(POSCounterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<POSCounter> entityResponse = new BaseEntityCollectionResponse<POSCounter>();
            try
            {

                if (_POSCounterDataProvider != null)
                {
                    entityResponse = _POSCounterDataProvider.GeneralCounterPOSApplicableGetOnline(searchRequest);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                entityResponse.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                entityResponse.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return entityResponse;
        }

        public IBaseEntityCollectionResponse<POSCounter> UserMasterGetOnlineForPOS(POSCounterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<POSCounter> entityResponse = new BaseEntityCollectionResponse<POSCounter>();
            try
            {

                if (_POSCounterDataProvider != null)
                {
                    entityResponse = _POSCounterDataProvider.UserMasterGetOnlineForPOS(searchRequest);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                entityResponse.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                entityResponse.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return entityResponse;
        }

        public IBaseEntityResponse<POSCounter> InventoryPOSSelfAssignPostOnline(POSCounter item)
        {
            IBaseEntityResponse<POSCounter> entityResponse = new BaseEntityResponse<POSCounter>();
            try
            {

                if (_POSCounterDataProvider != null)
                {
                    entityResponse = _POSCounterDataProvider.InventoryPOSSelfAssignPostOnline(item);
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

        public IBaseEntityResponse<POSCounter> CounterLogPostOnline(POSCounter item)
        {
            IBaseEntityResponse<POSCounter> entityResponse = new BaseEntityResponse<POSCounter>();
            try
            {

                if (_POSCounterDataProvider != null)
                {
                    entityResponse = _POSCounterDataProvider.CounterLogPostOnline(item);
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

        public IBaseEntityResponse<POSCounter> UserLogPostOnline(POSCounter item)
        {
            IBaseEntityResponse<POSCounter> entityResponse = new BaseEntityResponse<POSCounter>();
            try
            {

                if (_POSCounterDataProvider != null)
                {
                    entityResponse = _POSCounterDataProvider.UserLogPostOnline(item);
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

        public IBaseEntityResponse<POSCounter> UserLogsPostOnline(POSCounter item)
        {
            IBaseEntityResponse<POSCounter> entityResponse = new BaseEntityResponse<POSCounter>();
            try
            {

                if (_POSCounterDataProvider != null)
                {
                    entityResponse = _POSCounterDataProvider.UserLogsPostOnline(item);
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

    }
}
