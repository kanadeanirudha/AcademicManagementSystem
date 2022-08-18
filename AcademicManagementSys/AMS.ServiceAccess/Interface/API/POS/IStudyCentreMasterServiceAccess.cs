using AMS.Base.DTO;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public interface IStudyCentreMasterServiceAccess
    {
        IBaseEntityCollectionResponse<StudyCentreMaster> GetStudyCentreMaster(StudyCentreMasterSearchRequest searchRequest);
    }
}
