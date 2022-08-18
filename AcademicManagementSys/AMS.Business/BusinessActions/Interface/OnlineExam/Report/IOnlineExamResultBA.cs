using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessActions
{
    public interface IOnlineExamResultBA
    {
        //IBaseEntityCollectionResponse<OnlineExamResult> GetOnlineExamResultBySearch_AllVendorList(OnlineExamResultSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OnlineExamResult> GetOnlineExamResultBySearch_ItemList(OnlineExamResultSearchRequest searchRequest);


        IBaseEntityCollectionResponse<OnlineExamResult> GetOnlineExamResultBySearch_AllVendorList(OnlineExamResultSearchRequest searchRequest);
    }
}
