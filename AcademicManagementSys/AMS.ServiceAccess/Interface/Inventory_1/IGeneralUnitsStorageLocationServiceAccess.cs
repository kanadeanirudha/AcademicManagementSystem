
using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IGeneralUnitsStorageLocationServiceAccess
    {
        IBaseEntityResponse<GeneralUnitsStorageLocation> InsertGeneralUnitsStorageLocation(GeneralUnitsStorageLocation item);
        IBaseEntityResponse<GeneralUnitsStorageLocation> UpdateGeneralUnitsStorageLocation(GeneralUnitsStorageLocation item);
        IBaseEntityResponse<GeneralUnitsStorageLocation> DeleteGeneralUnitsStorageLocation(GeneralUnitsStorageLocation item);
        IBaseEntityCollectionResponse<GeneralUnitsStorageLocation> GetBySearch(GeneralUnitsStorageLocationSearchRequest searchRequest);
        IBaseEntityResponse<GeneralUnitsStorageLocation> SelectByID(GeneralUnitsStorageLocation item);
        IBaseEntityCollectionResponse<GeneralUnitsStorageLocation> GetGeneralUnitsStorageLocationSearchList(GeneralUnitsStorageLocationSearchRequest searchRequest);
        IBaseEntityResponse<GeneralUnitsStorageLocation> CheckFocusOnAction(GeneralUnitsStorageLocation item);
        IBaseEntityCollectionResponse<GeneralUnitsStorageLocation> GetStorageLocationForRequisition(GeneralUnitsStorageLocationSearchRequest searchRequest);
    }
}
