using System;
using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IGeneralRequestMasterDataProvider
    {
        IBaseEntityResponse<GeneralRequestMaster> InsertGeneralRequestMaster(GeneralRequestMaster item);
        IBaseEntityResponse<GeneralRequestMaster> UpdateGeneralRequestMaster(GeneralRequestMaster item);
        IBaseEntityResponse<GeneralRequestMaster> DeleteGeneralRequestMaster(GeneralRequestMaster item);
        IBaseEntityCollectionResponse<GeneralRequestMaster> GetGeneralRequestMasterBySearch(GeneralRequestMasterSearchRequest searchRequest);
       
        IBaseEntityCollectionResponse<GeneralRequestMaster> GetGeneralRequestMasterSearchList(GeneralRequestMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralRequestMaster> GetRequestCode(GeneralRequestMasterSearchRequest searchRequest);    
        IBaseEntityResponse<GeneralRequestMaster> GetGeneralRequestMasterByID(GeneralRequestMaster item);
    }
}
