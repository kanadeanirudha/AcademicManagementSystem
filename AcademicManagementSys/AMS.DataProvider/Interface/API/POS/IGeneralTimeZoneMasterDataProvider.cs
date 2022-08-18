using AMS.Base.DTO;
using AMS.DTO;
namespace AMS.DataProvider
{
    public interface IGeneralTimeZoneMasterDataProvider
    {
        IBaseEntityCollectionResponse<GeneralTimeZoneMaster> GetGeneralTimeZoneMaster(GeneralTimeZoneMasterSearchRequest searchRequest);
    }
}
