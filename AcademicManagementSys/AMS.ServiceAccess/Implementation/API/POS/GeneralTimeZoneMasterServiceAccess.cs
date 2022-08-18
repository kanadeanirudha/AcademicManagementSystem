using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class GeneralTimeZoneMasterServiceAccess : IGeneralTimeZoneMasterServiceAccess
    {
        IGeneralTimeZoneMasterBA _GeneralTimeZoneMasterBA = null;
        public GeneralTimeZoneMasterServiceAccess()
        {
            _GeneralTimeZoneMasterBA = new GeneralTimeZoneMasterBA();
        }
        public IBaseEntityCollectionResponse<GeneralTimeZoneMaster> GetGeneralTimeZoneMaster(GeneralTimeZoneMasterSearchRequest searchRequest)
        {
            return _GeneralTimeZoneMasterBA.GetGeneralTimeZoneMaster(searchRequest);
        }
    }
}
