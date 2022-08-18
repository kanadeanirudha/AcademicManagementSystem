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
    public class SalePromotionGetOfflineBA : ISalePromotionGetOfflineBA
    {
        ISalePromotionGetOfflineDataProvider _SalePromotionGetOfflineDataProvider;
        IUserMasterBR _userMasterBR;
        private ILogger _logException;

        public SalePromotionGetOfflineBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _userMasterBR = new UserMasterBR();
            _SalePromotionGetOfflineDataProvider = new SalePromotionGetOfflineDataProvider();
        }


        public IBaseEntityCollectionResponse<SalePromotionGetOffline> GetSalePromotionActivityMaster(SalePromotionGetOfflineSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalePromotionGetOffline> entityResponse = new BaseEntityCollectionResponse<SalePromotionGetOffline>();
            try
            {

                if (_SalePromotionGetOfflineDataProvider != null)
                {
                    entityResponse = _SalePromotionGetOfflineDataProvider.GetSalePromotionActivityMaster(searchRequest);
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

        public IBaseEntityCollectionResponse<SalePromotionGetOffline> GetSalePromotionActivityDetails(SalePromotionGetOfflineSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalePromotionGetOffline> entityResponse = new BaseEntityCollectionResponse<SalePromotionGetOffline>();
            try
            {

                if (_SalePromotionGetOfflineDataProvider != null)
                {
                    entityResponse = _SalePromotionGetOfflineDataProvider.GetSalePromotionActivityDetails(searchRequest);
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

        public IBaseEntityCollectionResponse<SalePromotionGetOffline> GetPromotionActivityDiscounteItemList(SalePromotionGetOfflineSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalePromotionGetOffline> entityResponse = new BaseEntityCollectionResponse<SalePromotionGetOffline>();
            try
            {

                if (_SalePromotionGetOfflineDataProvider != null)
                {
                    entityResponse = _SalePromotionGetOfflineDataProvider.GetPromotionActivityDiscounteItemList(searchRequest);
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


        public IBaseEntityCollectionResponse<SalePromotionGetOffline> GetSalePromotionPlan(SalePromotionGetOfflineSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalePromotionGetOffline> entityResponse = new BaseEntityCollectionResponse<SalePromotionGetOffline>();
            try
            {

                if (_SalePromotionGetOfflineDataProvider != null)
                {
                    entityResponse = _SalePromotionGetOfflineDataProvider.GetSalePromotionPlan(searchRequest);
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

        public IBaseEntityCollectionResponse<SalePromotionGetOffline> GetSalePromotionPlanDetails(SalePromotionGetOfflineSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalePromotionGetOffline> entityResponse = new BaseEntityCollectionResponse<SalePromotionGetOffline>();
            try
            {

                if (_SalePromotionGetOfflineDataProvider != null)
                {
                    entityResponse = _SalePromotionGetOfflineDataProvider.GetSalePromotionPlanDetails(searchRequest);
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
