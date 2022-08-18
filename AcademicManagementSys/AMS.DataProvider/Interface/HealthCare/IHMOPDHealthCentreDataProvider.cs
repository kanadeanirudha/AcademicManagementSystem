using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IHMOPDHealthCentreDataProvider
    {
        IBaseEntityResponse<HMOPDHealthCentre> InsertHMOPDHealthCentre(HMOPDHealthCentre item);
        IBaseEntityResponse<HMOPDHealthCentre> UpdateHMOPDHealthCentre(HMOPDHealthCentre item);
        IBaseEntityResponse<HMOPDHealthCentre> DeleteHMOPDHealthCentre(HMOPDHealthCentre item);
        IBaseEntityCollectionResponse<HMOPDHealthCentre> GetHMOPDHealthCentreBySearch(HMOPDHealthCentreSearchRequest searchRequest);
        IBaseEntityCollectionResponse<HMOPDHealthCentre> GetHMOPDHealthCentreSearchList(HMOPDHealthCentreSearchRequest searchRequest);
        IBaseEntityResponse<HMOPDHealthCentre> GetHMOPDHealthCentreByID(HMOPDHealthCentre item);
        IBaseEntityCollectionResponse<HMOPDHealthCentre> GetListHMOPDHealthCentre(HMOPDHealthCentreSearchRequest searchRequest);
    }
}
