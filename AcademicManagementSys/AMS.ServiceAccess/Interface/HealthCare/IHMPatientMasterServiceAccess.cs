using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IHMPatientMasterServiceAccess
    {
        IBaseEntityResponse<HMPatientMaster> InsertHMPatientMaster(HMPatientMaster item);
        IBaseEntityResponse<HMPatientMaster> UpdateHMPatientMaster(HMPatientMaster item);
        IBaseEntityResponse<HMPatientMaster> DeleteHMPatientMaster(HMPatientMaster item);
        IBaseEntityCollectionResponse<HMPatientMaster> GetBySearch(HMPatientMasterSearchRequest searchRequest);
        IBaseEntityResponse<HMPatientMaster> SelectByID(HMPatientMaster item);
        IBaseEntityCollectionResponse<HMPatientMaster> GetHMPatientMasterSearchList(HMPatientMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<HMPatientMaster> GetListOfPatient(HMPatientMasterSearchRequest searchRequest);

    }
}
