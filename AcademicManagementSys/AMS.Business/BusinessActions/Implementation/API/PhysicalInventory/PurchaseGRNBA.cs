using AMS.Base.DTO;
using AMS.Business.BusinessRules;
using AMS.Common;
using AMS.DataProvider;
using AMS.DTO;
using AMS.ExceptionManager;
using System;

namespace AMS.Business.BusinessAction
{
    public class PurchaseGRNBA : IPurchaseGRNBA
    {
        IPurchaseGRNDataProvider _PurchaseGRNDataProvider;
        IUserMasterBR _userMasterBR;
        private ILogger _logException;

        public PurchaseGRNBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _userMasterBR = new UserMasterBR();
            _PurchaseGRNDataProvider = new PurchaseGRNDataProvider();
        }

        public IBaseEntityResponse<PurchaseGRN> PostPurchaseGRN(PurchaseGRN item)
        {
            IBaseEntityResponse<PurchaseGRN> entityResponse = new BaseEntityResponse<PurchaseGRN>();
            try
            {

                if (_PurchaseGRNDataProvider != null)
                {
                    entityResponse = _PurchaseGRNDataProvider.PostPurchaseGRN(item);
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

        public IBaseEntityCollectionResponse<PurchaseGRN> GetPurchaseGRNVendorList(PurchaseGRNSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseGRN> entityResponse = new BaseEntityCollectionResponse<PurchaseGRN>();
            try
            {

                if (_PurchaseGRNDataProvider != null)
                {
                    entityResponse = _PurchaseGRNDataProvider.GetPurchaseGRNVendorList(searchRequest);
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
        public IBaseEntityCollectionResponse<PurchaseGRN> GetPurchaseGRNPOList(PurchaseGRNSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseGRN> entityResponse = new BaseEntityCollectionResponse<PurchaseGRN>();
            try
            {

                if (_PurchaseGRNDataProvider != null)
                {
                    entityResponse = _PurchaseGRNDataProvider.GetPurchaseGRNPOList(searchRequest);
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
        public IBaseEntityCollectionResponse<PurchaseGRN> GetPOList(PurchaseGRNSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseGRN> entityResponse = new BaseEntityCollectionResponse<PurchaseGRN>();
            try
            {

                if (_PurchaseGRNDataProvider != null)
                {
                    entityResponse = _PurchaseGRNDataProvider.GetPOList(searchRequest);
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
        public IBaseEntityCollectionResponse<PurchaseGRN> GetGRNList(PurchaseGRNSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseGRN> entityResponse = new BaseEntityCollectionResponse<PurchaseGRN>();
            try
            {

                if (_PurchaseGRNDataProvider != null)
                {
                    entityResponse = _PurchaseGRNDataProvider.GetGRNList(searchRequest);
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
        public IBaseEntityCollectionResponse<PurchaseGRN> GetPurchaseGRNView(PurchaseGRNSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseGRN> entityResponse = new BaseEntityCollectionResponse<PurchaseGRN>();
            try
            {

                if (_PurchaseGRNDataProvider != null)
                {
                    entityResponse = _PurchaseGRNDataProvider.GetPurchaseGRNView(searchRequest);
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
        public IBaseEntityCollectionResponse<PurchaseGRN> GetPurchaseGRNBatchList(PurchaseGRNSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseGRN> entityResponse = new BaseEntityCollectionResponse<PurchaseGRN>();
            try
            {

                if (_PurchaseGRNDataProvider != null)
                {
                    entityResponse = _PurchaseGRNDataProvider.GetPurchaseGRNBatchList(searchRequest);
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
        public IBaseEntityCollectionResponse<PurchaseGRN> GetPurchaseOrderItemList(PurchaseGRNSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseGRN> entityResponse = new BaseEntityCollectionResponse<PurchaseGRN>();
            try
            {

                if (_PurchaseGRNDataProvider != null)
                {
                    entityResponse = _PurchaseGRNDataProvider.GetPurchaseOrderItemList(searchRequest);
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
       
    }
}
