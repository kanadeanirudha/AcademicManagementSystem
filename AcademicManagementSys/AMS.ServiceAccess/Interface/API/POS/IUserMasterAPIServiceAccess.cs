using AMS.Base.DTO;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public interface IUserMasterAPIServiceAccess
    {
        IBaseEntityCollectionResponse<UserMasterAPI> GetUserMasterAPI(UserMasterAPISearchRequest searchRequest);
        IBaseEntityResponse<UserMasterAPI> PostUserLogAndLogsData(UserMasterAPI item);

        IBaseEntityCollectionResponse<UserMasterAPI> GetAccountSessionMaster(UserMasterAPISearchRequest searchRequest);
    }
}
