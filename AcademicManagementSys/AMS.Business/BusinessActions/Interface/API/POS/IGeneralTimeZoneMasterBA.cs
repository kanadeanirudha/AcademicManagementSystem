using AMS.Base.DTO;
using AMS.DTO;
namespace AMS.Business.BusinessAction
{
    public interface IGeneralTimeZoneMasterBA
    {
        IBaseEntityCollectionResponse<GeneralTimeZoneMaster> GetGeneralTimeZoneMaster(GeneralTimeZoneMasterSearchRequest searchRequest);
    }
}
