using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IHMConsultantMasterServiceAccess
    {
        IBaseEntityResponse<HMConsultantMaster> InsertHMConsultantMaster(HMConsultantMaster item);
        IBaseEntityResponse<HMConsultantMaster> UpdateHMConsultantMaster(HMConsultantMaster item);
        IBaseEntityResponse<HMConsultantMaster> DeleteHMConsultantMaster(HMConsultantMaster item);
        IBaseEntityCollectionResponse<HMConsultantMaster> GetBySearch(HMConsultantMasterSearchRequest searchRequest);
        IBaseEntityResponse<HMConsultantMaster> SelectByID(HMConsultantMaster item);
        IBaseEntityCollectionResponse<HMConsultantMaster> GetHMConsultantMasterSearchList(HMConsultantMasterSearchRequest searchRequest);
    }
}
