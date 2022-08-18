using AMS.Base.DTO;
using AMS.DTO;
namespace AMS.Business.BusinessAction
{
    public interface IStudyCentreMasterBA
    {
        IBaseEntityCollectionResponse<StudyCentreMaster> GetStudyCentreMaster(StudyCentreMasterSearchRequest searchRequest);
    }
}
