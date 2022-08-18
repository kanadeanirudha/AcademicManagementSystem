
using System;
using System.Collections.Generic;
using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class OnlineExamResultServiceAccess : IOnlineExamResultServiceAccess
    {
        IOnlineExamResultBA _OnlineExamResultBA = null;
        public OnlineExamResultServiceAccess()
        {
            _OnlineExamResultBA = new OnlineExamResultBA();
        }

        public IBaseEntityCollectionResponse<OnlineExamResult> GetOnlineExamResultBySearch_AllVendorList(OnlineExamResultSearchRequest searchRequest)
        {
            return _OnlineExamResultBA.GetOnlineExamResultBySearch_AllVendorList(searchRequest);
        }

        public IBaseEntityCollectionResponse<OnlineExamResult> GetOnlineExamResultBySearch_ItemList(OnlineExamResultSearchRequest searchRequest)
        {
            return _OnlineExamResultBA.GetOnlineExamResultBySearch_ItemList(searchRequest);
        }
    }
}
