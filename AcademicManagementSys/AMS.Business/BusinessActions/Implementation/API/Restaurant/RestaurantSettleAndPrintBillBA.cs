using AMS.Base.DTO;
using AMS.Business.BusinessRules;
using AMS.Common;
using AMS.DataProvider;
using AMS.DTO;
using AMS.ExceptionManager;
using System;

namespace AMS.Business.BusinessAction
{
    public class RestaurantSettleAndPrintBillBA : IRestaurantSettleAndPrintBillBA
    {
        IRestaurantSettleAndPrintBillDataProvider _RestaurantSettleAndPrintBillDataProvider;
        IUserMasterBR _userMasterBR;
        private ILogger _logException;

        public RestaurantSettleAndPrintBillBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _userMasterBR = new UserMasterBR();
            _RestaurantSettleAndPrintBillDataProvider = new RestaurantSettleAndPrintBillDataProvider();
        }

        public IBaseEntityResponse<RestaurantSettleAndPrintBill> RestaurantSettleBillPost(RestaurantSettleAndPrintBill item)
        {
            IBaseEntityResponse<RestaurantSettleAndPrintBill> entityResponse = new BaseEntityResponse<RestaurantSettleAndPrintBill>();
            try
            {

                if (_RestaurantSettleAndPrintBillDataProvider != null)
                {
                    entityResponse = _RestaurantSettleAndPrintBillDataProvider.RestaurantSettleBillPost(item);
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

        public IBaseEntityCollectionResponse<RestaurantSettleAndPrintBill> GetRestaurantPrintBill(RestaurantSettleAndPrintBillSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RestaurantSettleAndPrintBill> entityResponse = new BaseEntityCollectionResponse<RestaurantSettleAndPrintBill>();
            try
            {


                if (_RestaurantSettleAndPrintBillDataProvider != null)
                {
                    entityResponse = _RestaurantSettleAndPrintBillDataProvider.GetRestaurantPrintBill(searchRequest);
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

        public IBaseEntityCollectionResponse<RestaurantSettleAndPrintBill> GetRestaurantBillList(RestaurantSettleAndPrintBillSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RestaurantSettleAndPrintBill> entityResponse = new BaseEntityCollectionResponse<RestaurantSettleAndPrintBill>();
            try
            {


                if (_RestaurantSettleAndPrintBillDataProvider != null)
                {
                    entityResponse = _RestaurantSettleAndPrintBillDataProvider.GetRestaurantBillList(searchRequest);
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
