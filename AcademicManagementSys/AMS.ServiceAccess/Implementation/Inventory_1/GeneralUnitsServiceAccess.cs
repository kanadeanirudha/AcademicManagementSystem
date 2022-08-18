using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class GeneralUnitsServiceAccess : IGeneralUnitsServiceAccess
    {
        IGeneralUnitsBA _GeneralUnitsBA = null;
        public GeneralUnitsServiceAccess()
        {
            _GeneralUnitsBA = new GeneralUnitsBA();
        }
        public IBaseEntityResponse<GeneralUnits> InsertGeneralUnits(GeneralUnits item)
        {
            return _GeneralUnitsBA.InsertGeneralUnits(item);
        }
        public IBaseEntityResponse<GeneralUnits> UpdateGeneralUnits(GeneralUnits item)
        {
            return _GeneralUnitsBA.UpdateGeneralUnits(item);
        }
        public IBaseEntityResponse<GeneralUnits> DeleteGeneralUnits(GeneralUnits item)
        {
            return _GeneralUnitsBA.DeleteGeneralUnits(item);
        }
        public IBaseEntityCollectionResponse<GeneralUnits> GetBySearch(GeneralUnitsSearchRequest searchRequest)
        {
            return _GeneralUnitsBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<GeneralUnits> GetGeneralUnitsSearchList(GeneralUnitsSearchRequest searchRequest)
        {
            return _GeneralUnitsBA.GetGeneralUnitsSearchList(searchRequest);
        }
        public IBaseEntityResponse<GeneralUnits> SelectByID(GeneralUnits item)
        {
            return _GeneralUnitsBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<GeneralUnits> GetGeneralUnitsByCentreCode(GeneralUnitsSearchRequest searchRequest)
        {
            return _GeneralUnitsBA.GetGeneralUnitsByCentreCode(searchRequest);
        }
    }
}
