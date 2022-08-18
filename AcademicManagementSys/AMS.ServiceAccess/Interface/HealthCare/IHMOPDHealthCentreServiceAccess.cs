using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IHMOPDHealthCentreServiceAccess
    {
        IBaseEntityResponse<HMOPDHealthCentre> InsertHMOPDHealthCentre(HMOPDHealthCentre item);
        IBaseEntityResponse<HMOPDHealthCentre> UpdateHMOPDHealthCentre(HMOPDHealthCentre item);
        IBaseEntityResponse<HMOPDHealthCentre> DeleteHMOPDHealthCentre(HMOPDHealthCentre item);
        IBaseEntityCollectionResponse<HMOPDHealthCentre> GetBySearch(HMOPDHealthCentreSearchRequest searchRequest);
        IBaseEntityResponse<HMOPDHealthCentre> SelectByID(HMOPDHealthCentre item);
        IBaseEntityCollectionResponse<HMOPDHealthCentre> GetHMOPDHealthCentreSearchList(HMOPDHealthCentreSearchRequest searchRequest);
        IBaseEntityCollectionResponse<HMOPDHealthCentre> GetListHMOPDHealthCentre(HMOPDHealthCentreSearchRequest searchRequest);

    }
}
