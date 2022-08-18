using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IHMOPDHealthCentreBA
    {
        IBaseEntityResponse<HMOPDHealthCentre> InsertHMOPDHealthCentre(HMOPDHealthCentre item);
        IBaseEntityResponse<HMOPDHealthCentre> UpdateHMOPDHealthCentre(HMOPDHealthCentre item);
        IBaseEntityResponse<HMOPDHealthCentre> DeleteHMOPDHealthCentre(HMOPDHealthCentre item);
        IBaseEntityCollectionResponse<HMOPDHealthCentre> GetBySearch(HMOPDHealthCentreSearchRequest searchRequest);
        IBaseEntityCollectionResponse<HMOPDHealthCentre> GetHMOPDHealthCentreSearchList(HMOPDHealthCentreSearchRequest searchRequest);
        IBaseEntityCollectionResponse<HMOPDHealthCentre> GetListHMOPDHealthCentre(HMOPDHealthCentreSearchRequest searchRequest);
        
        IBaseEntityResponse<HMOPDHealthCentre> SelectByID(HMOPDHealthCentre item);
    }
}

