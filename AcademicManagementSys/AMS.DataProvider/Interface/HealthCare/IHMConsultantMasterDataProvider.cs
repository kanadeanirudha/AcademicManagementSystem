using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IHMConsultantMasterDataProvider
    {
        IBaseEntityResponse<HMConsultantMaster> InsertHMConsultantMaster(HMConsultantMaster item);
        IBaseEntityResponse<HMConsultantMaster> UpdateHMConsultantMaster(HMConsultantMaster item);
        IBaseEntityResponse<HMConsultantMaster> DeleteHMConsultantMaster(HMConsultantMaster item);
        IBaseEntityCollectionResponse<HMConsultantMaster> GetHMConsultantMasterBySearch(HMConsultantMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<HMConsultantMaster> GetHMConsultantMasterSearchList(HMConsultantMasterSearchRequest searchRequest);
        IBaseEntityResponse<HMConsultantMaster> GetHMConsultantMasterByID(HMConsultantMaster item);
    }
}
