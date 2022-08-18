using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IGeneralUnitsStorageLocationDataProvider
    {
        IBaseEntityResponse<GeneralUnitsStorageLocation> InsertGeneralUnitsStorageLocation(GeneralUnitsStorageLocation item);
        IBaseEntityResponse<GeneralUnitsStorageLocation> UpdateGeneralUnitsStorageLocation(GeneralUnitsStorageLocation item);
        IBaseEntityResponse<GeneralUnitsStorageLocation> DeleteGeneralUnitsStorageLocation(GeneralUnitsStorageLocation item);
        IBaseEntityCollectionResponse<GeneralUnitsStorageLocation> GetGeneralUnitsStorageLocationBySearch(GeneralUnitsStorageLocationSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralUnitsStorageLocation> GetGeneralUnitsStorageLocationSearchList(GeneralUnitsStorageLocationSearchRequest searchRequest);
        IBaseEntityResponse<GeneralUnitsStorageLocation> GetGeneralUnitsStorageLocationByID(GeneralUnitsStorageLocation item);
        IBaseEntityResponse<GeneralUnitsStorageLocation> CheckFocusOnAction(GeneralUnitsStorageLocation item);
        IBaseEntityCollectionResponse<GeneralUnitsStorageLocation> GetStorageLocationForRequisition(GeneralUnitsStorageLocationSearchRequest searchRequest);
    }
}
