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
    public interface IHMConsultantTypeMasterBA
    {
        IBaseEntityResponse<HMConsultantTypeMaster> InsertHMConsultantTypeMaster(HMConsultantTypeMaster item);
        IBaseEntityResponse<HMConsultantTypeMaster> UpdateHMConsultantTypeMaster(HMConsultantTypeMaster item);
        IBaseEntityResponse<HMConsultantTypeMaster> DeleteHMConsultantTypeMaster(HMConsultantTypeMaster item);
        IBaseEntityCollectionResponse<HMConsultantTypeMaster> GetBySearch(HMConsultantTypeMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<HMConsultantTypeMaster> GetHMConsultantTypeMasterSearchList(HMConsultantTypeMasterSearchRequest searchRequest);
        IBaseEntityResponse<HMConsultantTypeMaster> SelectByID(HMConsultantTypeMaster item);
        IBaseEntityCollectionResponse<HMConsultantTypeMaster> GetConsultantTypeList(HMConsultantTypeMasterSearchRequest searchRequest);
       // IBaseEntityResponse<HMConsultantTypeMaster> GetConsultantTypeList(HMConsultantTypeMasterSearchRequest searchRequest);
    }
}

