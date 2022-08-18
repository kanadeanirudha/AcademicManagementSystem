using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class GeneralTemperatureMasterServiceAccess : IGeneralTemperatureMasterServiceAccess
    {
        IGeneralTemperatureMasterBA _GeneralTemperatureMasterBA = null;
        public GeneralTemperatureMasterServiceAccess()
        {
            _GeneralTemperatureMasterBA = new GeneralTemperatureMasterBA();
        }
        public IBaseEntityResponse<GeneralTemperatureMaster> InsertGeneralTemperatureMaster(GeneralTemperatureMaster item)
        {
            return _GeneralTemperatureMasterBA.InsertGeneralTemperatureMaster(item);
        }
        public IBaseEntityResponse<GeneralTemperatureMaster> UpdateGeneralTemperatureMaster(GeneralTemperatureMaster item)
        {
            return _GeneralTemperatureMasterBA.UpdateGeneralTemperatureMaster(item);
        }
        public IBaseEntityResponse<GeneralTemperatureMaster> DeleteGeneralTemperatureMaster(GeneralTemperatureMaster item)
        {
            return _GeneralTemperatureMasterBA.DeleteGeneralTemperatureMaster(item);
        }
        public IBaseEntityCollectionResponse<GeneralTemperatureMaster> GetBySearch(GeneralTemperatureMasterSearchRequest searchRequest)
        {
            return _GeneralTemperatureMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<GeneralTemperatureMaster> GetGeneralTemperatureMasterSearchList(GeneralTemperatureMasterSearchRequest searchRequest)
        {
            return _GeneralTemperatureMasterBA.GetGeneralTemperatureMasterSearchList(searchRequest);
        }
        public IBaseEntityResponse<GeneralTemperatureMaster> SelectByID(GeneralTemperatureMaster item)
        {
            return _GeneralTemperatureMasterBA.SelectByID(item);
        }
    }
}
