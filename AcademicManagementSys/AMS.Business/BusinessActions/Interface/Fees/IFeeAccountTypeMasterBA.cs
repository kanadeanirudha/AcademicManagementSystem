using System;
using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IFeeAccountTypeMasterBA
    {
        IBaseEntityResponse<FeeAccountTypeMaster> InsertFeeAccountTypeMaster(FeeAccountTypeMaster item);
        IBaseEntityResponse<FeeAccountTypeMaster> UpdateFeeAccountTypeMaster(FeeAccountTypeMaster item);
        IBaseEntityResponse<FeeAccountTypeMaster> DeleteFeeAccountTypeMaster(FeeAccountTypeMaster item);
        IBaseEntityCollectionResponse<FeeAccountTypeMaster> GetBySearch(FeeAccountTypeMasterSearchRequest searchRequest);
        IBaseEntityResponse<FeeAccountTypeMaster> SelectByID(FeeAccountTypeMaster item);
        IBaseEntityCollectionResponse<FeeAccountTypeMaster> GetFeeAccountTypeMasterSearchList(FeeAccountTypeMasterSearchRequest searchRequest);

    }
}
