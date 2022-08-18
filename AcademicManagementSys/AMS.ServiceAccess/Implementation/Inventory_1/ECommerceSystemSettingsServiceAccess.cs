
using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class ECommerceSystemSettingsServiceAccess : IECommerceSystemSettingsServiceAccess
    {
        IECommerceSystemSettingsBA _ECommerceSystemSettingsBA = null;
        public ECommerceSystemSettingsServiceAccess()
        {
            _ECommerceSystemSettingsBA = new ECommerceSystemSettingsBA();
        }
        public IBaseEntityResponse<ECommerceSystemSettings> InsertECommerceSystemSettings(ECommerceSystemSettings item)
        {
            return _ECommerceSystemSettingsBA.InsertECommerceSystemSettings(item);
        }
        public IBaseEntityCollectionResponse<ECommerceSystemSettings> GetBySearch(ECommerceSystemSettingsSearchRequest searchRequest)
        {
            return _ECommerceSystemSettingsBA.GetBySearch(searchRequest);
        }
    
    }
}
