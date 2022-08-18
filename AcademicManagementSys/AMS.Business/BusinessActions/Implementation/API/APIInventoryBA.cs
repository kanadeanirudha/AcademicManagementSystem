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
    public class APIInventoryBA : IAPIInventoryBA
    {
        IAPIInventoryDataProvider _apiInventoryDataProvider;
        IUserMasterBR _userMasterBR;
        private ILogger _logException;

        public APIInventoryBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _userMasterBR = new UserMasterBR();
            _apiInventoryDataProvider = new APIInventoryDataProvider();
        }

        public IBaseEntityResponse<APIInventory> InventoryCounterLogin(APIInventory item)
        {
            IBaseEntityResponse<APIInventory> entityResponse = new BaseEntityResponse<APIInventory>();
            try
            {

                if (_apiInventoryDataProvider != null)
                {
                    entityResponse = _apiInventoryDataProvider.InventoryCounterLogin(item);
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

        public IBaseEntityResponse<APIInventory> PostOnline(APIInventory item)
        {
            IBaseEntityResponse<APIInventory> entityResponse = new BaseEntityResponse<APIInventory>();
            try
            {

                if (_apiInventoryDataProvider != null)
                {
                    entityResponse = _apiInventoryDataProvider.PostOnline(item);
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

        public IBaseEntityResponse<APIInventory> SingleBillPostOnline(APIInventory item)
        {
            IBaseEntityResponse<APIInventory> entityResponse = new BaseEntityResponse<APIInventory>();
            try
            {

                if (_apiInventoryDataProvider != null)
                {
                    entityResponse = _apiInventoryDataProvider.SingleBillPostOnline(item);
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

        public IBaseEntityResponse<APIInventory> GetLocalInvoiceNo(APIInventory item)
        {
            IBaseEntityResponse<APIInventory> entityResponse = new BaseEntityResponse<APIInventory>();
            try
            {

                if (_apiInventoryDataProvider != null)
                {
                    entityResponse = _apiInventoryDataProvider.GetLocalInvoiceNo(item);
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

        public IBaseEntityCollectionResponse<APIInventory> InventoryGetOnline(APIInventorySearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<APIInventory> entityResponse = new BaseEntityCollectionResponse<APIInventory>();
            try
            {

                if (_apiInventoryDataProvider != null)
                {
                    entityResponse = _apiInventoryDataProvider.InventoryGetOnline(searchRequest);
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


        public IBaseEntityResponse<APIInventory> PostSaleReturnOnline(APIInventory item)
        {
            IBaseEntityResponse<APIInventory> entityResponse = new BaseEntityResponse<APIInventory>();
            try
            {

                if (_apiInventoryDataProvider != null)
                {
                    entityResponse = _apiInventoryDataProvider.PostSaleReturnOnline(item);
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
