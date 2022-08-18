using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IHMConsultantTypeMasterDataProvider
    {
        IBaseEntityResponse<HMConsultantTypeMaster> InsertHMConsultantTypeMaster(HMConsultantTypeMaster item);
        IBaseEntityResponse<HMConsultantTypeMaster> UpdateHMConsultantTypeMaster(HMConsultantTypeMaster item);
        IBaseEntityResponse<HMConsultantTypeMaster> DeleteHMConsultantTypeMaster(HMConsultantTypeMaster item);
        IBaseEntityCollectionResponse<HMConsultantTypeMaster> GetHMConsultantTypeMasterBySearch(HMConsultantTypeMasterSearchRequest searchRequest);
       // IBaseEntityCollectionResponse<HMConsultantTypeMaster> GetHMConsultantTypeMasterSearchList(HMConsultantTypeMasterSearchRequest searchRequest);
        IBaseEntityResponse<HMConsultantTypeMaster> GetHMConsultantTypeMasterByID(HMConsultantTypeMaster item);
        IBaseEntityCollectionResponse<HMConsultantTypeMaster> GetConsultantTypeList(HMConsultantTypeMasterSearchRequest searchRequest);
    }
}
