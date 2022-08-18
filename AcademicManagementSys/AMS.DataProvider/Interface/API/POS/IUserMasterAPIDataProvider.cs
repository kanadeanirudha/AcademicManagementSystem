using AMS.Base.DTO;
using AMS.DTO;
namespace AMS.DataProvider
{
    public interface IUserMasterAPIDataProvider
    {
        IBaseEntityCollectionResponse<UserMasterAPI> GetUserMasterAPI(UserMasterAPISearchRequest searchRequest);
        IBaseEntityResponse<UserMasterAPI> PostUserLogAndLogsData(UserMasterAPI item);
        IBaseEntityCollectionResponse<UserMasterAPI> GetAccountSessionMaster(UserMasterAPISearchRequest searchRequest);
    }
}
