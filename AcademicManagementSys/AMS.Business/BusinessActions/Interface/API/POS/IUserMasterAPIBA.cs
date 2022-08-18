using AMS.Base.DTO;
using AMS.DTO;
namespace AMS.Business.BusinessAction
{
    public interface IUserMasterAPIBA
    {
        IBaseEntityCollectionResponse<UserMasterAPI> GetUserMasterAPI(UserMasterAPISearchRequest searchRequest);
        IBaseEntityResponse<UserMasterAPI> PostUserLogAndLogsData(UserMasterAPI item);

        IBaseEntityCollectionResponse<UserMasterAPI> GetAccountSessionMaster(UserMasterAPISearchRequest searchRequest);
    }
}
