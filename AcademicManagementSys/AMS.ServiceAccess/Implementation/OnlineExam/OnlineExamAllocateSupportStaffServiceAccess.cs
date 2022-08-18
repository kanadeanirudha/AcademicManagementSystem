
using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class OnlineExamAllocateSupportStaffServiceAccess : IOnlineExamAllocateSupportStaffServiceAccess
    {
        IOnlineExamAllocateSupportStaffBA _OnlineExamAllocateSupportStaffBA = null;
        public OnlineExamAllocateSupportStaffServiceAccess()
        {
            _OnlineExamAllocateSupportStaffBA = new OnlineExamAllocateSupportStaffBA();
        }
        public IBaseEntityResponse<OnlineExamAllocateSupportStaff> InsertOnlineExamAllocateSupportStaff(OnlineExamAllocateSupportStaff item)
        {
            return _OnlineExamAllocateSupportStaffBA.InsertOnlineExamAllocateSupportStaff(item);
        }
        public IBaseEntityResponse<OnlineExamAllocateSupportStaff> UpdateOnlineExamAllocateSupportStaff(OnlineExamAllocateSupportStaff item)
        {
            return _OnlineExamAllocateSupportStaffBA.UpdateOnlineExamAllocateSupportStaff(item);
        }
        public IBaseEntityResponse<OnlineExamAllocateSupportStaff> DeleteOnlineExamAllocateSupportStaff(OnlineExamAllocateSupportStaff item)
        {
            return _OnlineExamAllocateSupportStaffBA.DeleteOnlineExamAllocateSupportStaff(item);
        }
        public IBaseEntityCollectionResponse<OnlineExamAllocateSupportStaff> GetBySearch(OnlineExamAllocateSupportStaffSearchRequest searchRequest)
        {
            return _OnlineExamAllocateSupportStaffBA.GetBySearch(searchRequest);
        }
        //public IBaseEntityCollectionResponse<OnlineExamAllocateSupportStaff> GetSessionNameList(OnlineExamAllocateSupportStaffSearchRequest searchRequest)
        //{
        //    return _OnlineExamAllocateSupportStaffBA.GetBySearch(searchRequest);
        //}
        public IBaseEntityCollectionResponse<OnlineExamAllocateSupportStaff> GetOnlineExamAllocateSupportStaffSearchList(OnlineExamAllocateSupportStaffSearchRequest searchRequest)
        {
            return _OnlineExamAllocateSupportStaffBA.GetOnlineExamAllocateSupportStaffSearchList(searchRequest);
        }
        public IBaseEntityResponse<OnlineExamAllocateSupportStaff> SelectByID(OnlineExamAllocateSupportStaff item)
        {
            return _OnlineExamAllocateSupportStaffBA.SelectByID(item);
        }
        public IBaseEntityResponse<OnlineExamAllocateSupportStaff> InsertOnlineExamAllocateJobSupportStaff(OnlineExamAllocateSupportStaff item)
        {
            return _OnlineExamAllocateSupportStaffBA.InsertOnlineExamAllocateJobSupportStaff(item);
        }

    }
}
