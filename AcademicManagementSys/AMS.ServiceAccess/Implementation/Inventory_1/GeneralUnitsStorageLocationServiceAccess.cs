using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class GeneralUnitsStorageLocationServiceAccess : IGeneralUnitsStorageLocationServiceAccess
    {
        IGeneralUnitsStorageLocationBA _GeneralUnitsStorageLocationBA = null;
        public GeneralUnitsStorageLocationServiceAccess()
        {
            _GeneralUnitsStorageLocationBA = new GeneralUnitsStorageLocationBA();
        }
        public IBaseEntityResponse<GeneralUnitsStorageLocation> InsertGeneralUnitsStorageLocation(GeneralUnitsStorageLocation item)
        {
            return _GeneralUnitsStorageLocationBA.InsertGeneralUnitsStorageLocation(item);
        }
        public IBaseEntityResponse<GeneralUnitsStorageLocation> UpdateGeneralUnitsStorageLocation(GeneralUnitsStorageLocation item)
        {
            return _GeneralUnitsStorageLocationBA.UpdateGeneralUnitsStorageLocation(item);
        }
        public IBaseEntityResponse<GeneralUnitsStorageLocation> DeleteGeneralUnitsStorageLocation(GeneralUnitsStorageLocation item)
        {
            return _GeneralUnitsStorageLocationBA.DeleteGeneralUnitsStorageLocation(item);
        }
        public IBaseEntityCollectionResponse<GeneralUnitsStorageLocation> GetBySearch(GeneralUnitsStorageLocationSearchRequest searchRequest)
        {
            return _GeneralUnitsStorageLocationBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<GeneralUnitsStorageLocation> GetGeneralUnitsStorageLocationSearchList(GeneralUnitsStorageLocationSearchRequest searchRequest)
        {
            return _GeneralUnitsStorageLocationBA.GetGeneralUnitsStorageLocationSearchList(searchRequest);
        }
        public IBaseEntityResponse<GeneralUnitsStorageLocation> SelectByID(GeneralUnitsStorageLocation item)
        {
            return _GeneralUnitsStorageLocationBA.SelectByID(item);
        }
        public IBaseEntityResponse<GeneralUnitsStorageLocation> CheckFocusOnAction(GeneralUnitsStorageLocation item)
        {
            return _GeneralUnitsStorageLocationBA.CheckFocusOnAction(item);
        }
        public IBaseEntityCollectionResponse<GeneralUnitsStorageLocation> GetStorageLocationForRequisition(GeneralUnitsStorageLocationSearchRequest searchRequest)
        {
            return _GeneralUnitsStorageLocationBA.GetStorageLocationForRequisition(searchRequest);
        }
    }
}
