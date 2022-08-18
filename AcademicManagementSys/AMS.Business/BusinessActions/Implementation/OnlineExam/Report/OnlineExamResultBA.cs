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
    public class OnlineExamResultBA : IOnlineExamResultBA
    {
        IOnlineExamResultDataProvider _OnlineExamResultDataProvider;
        private ILogger _logException;
        public OnlineExamResultBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _OnlineExamResultDataProvider = new OnlineExamResultDataProvider();
        }

        public IBaseEntityCollectionResponse<OnlineExamResult> GetOnlineExamResultBySearch_AllVendorList(OnlineExamResultSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExamResult> OnlineExamResultCollection = new BaseEntityCollectionResponse<OnlineExamResult>();
            try
            {
                if (_OnlineExamResultDataProvider != null)
                    OnlineExamResultCollection = _OnlineExamResultDataProvider.GetOnlineExamResultBySearch_AllVendorList(searchRequest);
                else
                {
                    OnlineExamResultCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OnlineExamResultCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OnlineExamResultCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OnlineExamResultCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OnlineExamResultCollection;
        }
        //Item Master Missing Exaception Report
        public IBaseEntityCollectionResponse<OnlineExamResult> GetOnlineExamResultBySearch_ItemList(OnlineExamResultSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OnlineExamResult> OnlineExamResultCollection = new BaseEntityCollectionResponse<OnlineExamResult>();
            try
            {
                if (_OnlineExamResultDataProvider != null)
                    OnlineExamResultCollection = _OnlineExamResultDataProvider.GetOnlineExamResultBySearch_ItemList(searchRequest);
                else
                {
                    OnlineExamResultCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OnlineExamResultCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OnlineExamResultCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OnlineExamResultCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OnlineExamResultCollection;
        }
    }
}
