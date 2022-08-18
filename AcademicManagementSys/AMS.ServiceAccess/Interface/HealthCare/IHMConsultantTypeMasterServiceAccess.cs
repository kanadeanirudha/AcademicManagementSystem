using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IHMConsultantTypeMasterServiceAccess
    {
        IBaseEntityResponse<HMConsultantTypeMaster> InsertHMConsultantTypeMaster(HMConsultantTypeMaster item);
        IBaseEntityResponse<HMConsultantTypeMaster> UpdateHMConsultantTypeMaster(HMConsultantTypeMaster item);
        IBaseEntityResponse<HMConsultantTypeMaster> DeleteHMConsultantTypeMaster(HMConsultantTypeMaster item);
        IBaseEntityCollectionResponse<HMConsultantTypeMaster> GetBySearch(HMConsultantTypeMasterSearchRequest searchRequest);
        IBaseEntityResponse<HMConsultantTypeMaster> SelectByID(HMConsultantTypeMaster item);
        IBaseEntityCollectionResponse<HMConsultantTypeMaster> GetHMConsultantTypeMasterSearchList(HMConsultantTypeMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<HMConsultantTypeMaster> GetConsultantTypeList(HMConsultantTypeMasterSearchRequest searchRequest);
    }
}
