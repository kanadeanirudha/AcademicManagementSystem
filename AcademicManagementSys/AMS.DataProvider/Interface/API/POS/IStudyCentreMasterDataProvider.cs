using AMS.Base.DTO;
using AMS.DTO;
namespace AMS.DataProvider
{
    public interface IStudyCentreMasterDataProvider
    {
        IBaseEntityCollectionResponse<StudyCentreMaster> GetStudyCentreMaster(StudyCentreMasterSearchRequest searchRequest);
    }
}
