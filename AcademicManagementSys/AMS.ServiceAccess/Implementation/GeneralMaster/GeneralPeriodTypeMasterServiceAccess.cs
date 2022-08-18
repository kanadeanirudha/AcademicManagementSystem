using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class GeneralPeriodTypeMasterServiceAccess : IGeneralPeriodTypeMasterServiceAccess
    {
         IGeneralPeriodTypeMasterBA _generalPeriodTypeMasterBA = null;

        public GeneralPeriodTypeMasterServiceAccess()
        {
            _generalPeriodTypeMasterBA = new GeneralPeriodTypeMasterBA();
        }

        public IBaseEntityResponse<GeneralPeriodTypeMaster> InsertGeneralPeriodTypeMaster(GeneralPeriodTypeMaster item)
        {
            return _generalPeriodTypeMasterBA.InsertGeneralPeriodTypeMaster(item);
        }
        public IBaseEntityResponse<GeneralPeriodTypeMaster> UpdateGeneralPeriodTypeMaster(GeneralPeriodTypeMaster item)
        {
            return _generalPeriodTypeMasterBA.UpdateGeneralPeriodTypeMaster(item);
        }
        public IBaseEntityResponse<GeneralPeriodTypeMaster> DeleteGeneralPeriodTypeMaster(GeneralPeriodTypeMaster item)
        {
            return _generalPeriodTypeMasterBA.DeleteGeneralPeriodTypeMaster(item);
        }
        public IBaseEntityCollectionResponse<GeneralPeriodTypeMaster> GetBySearch(GeneralPeriodTypeMasterSearchRequest searchRequest)
        {
            return _generalPeriodTypeMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<GeneralPeriodTypeMaster> GetBySearchList(GeneralPeriodTypeMasterSearchRequest searchRequest)
        {
            return _generalPeriodTypeMasterBA.GetBySearchList(searchRequest);
        }
        public IBaseEntityResponse<GeneralPeriodTypeMaster> SelectByID(GeneralPeriodTypeMaster item)
        {
            return _generalPeriodTypeMasterBA.SelectByID(item);
        }
    }
}
