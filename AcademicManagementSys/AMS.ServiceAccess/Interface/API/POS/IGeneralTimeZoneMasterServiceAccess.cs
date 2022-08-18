using AMS.Base.DTO;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public interface IGeneralTimeZoneMasterServiceAccess
    {
        IBaseEntityCollectionResponse<GeneralTimeZoneMaster> GetGeneralTimeZoneMaster(GeneralTimeZoneMasterSearchRequest searchRequest);
    }
}
