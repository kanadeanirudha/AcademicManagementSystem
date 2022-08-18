using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class UserMasterAPIServiceAccess : IUserMasterAPIServiceAccess
    {
        IUserMasterAPIBA _UserMasterAPIBA = null;
        public UserMasterAPIServiceAccess()
        {
            _UserMasterAPIBA = new UserMasterAPIBA();
        }
        public IBaseEntityCollectionResponse<UserMasterAPI> GetUserMasterAPI(UserMasterAPISearchRequest searchRequest)
        {
            return _UserMasterAPIBA.GetUserMasterAPI(searchRequest);
        }

        public IBaseEntityResponse<UserMasterAPI> PostUserLogAndLogsData(UserMasterAPI searchRequest)
        {
            return _UserMasterAPIBA.PostUserLogAndLogsData(searchRequest);
        }
        //Account session Master
        public IBaseEntityCollectionResponse<UserMasterAPI> GetAccountSessionMaster(UserMasterAPISearchRequest searchRequest)
        {
            return _UserMasterAPIBA.GetAccountSessionMaster(searchRequest);
        }
    }
}
