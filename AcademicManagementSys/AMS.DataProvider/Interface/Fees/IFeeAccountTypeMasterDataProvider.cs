using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IFeeAccountTypeMasterDataProvider
    {
        IBaseEntityResponse<FeeAccountTypeMaster> InsertFeeAccountTypeMaster(FeeAccountTypeMaster item);
        IBaseEntityResponse<FeeAccountTypeMaster> UpdateFeeAccountTypeMaster(FeeAccountTypeMaster item);
        IBaseEntityResponse<FeeAccountTypeMaster> DeleteFeeAccountTypeMaster(FeeAccountTypeMaster item);
        IBaseEntityCollectionResponse<FeeAccountTypeMaster> GetFeeAccountTypeMasterBySearch(FeeAccountTypeMasterSearchRequest searchRequest);
        IBaseEntityResponse<FeeAccountTypeMaster> GetFeeAccountTypeMasterByID(FeeAccountTypeMaster item);
        IBaseEntityCollectionResponse<FeeAccountTypeMaster> GetFeeAccountTypeMasterSearchList(FeeAccountTypeMasterSearchRequest searchRequest);
    }
}
