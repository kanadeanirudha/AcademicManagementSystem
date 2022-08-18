using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IOnlineExamAllocateSupportStaffServiceAccess
    {
        IBaseEntityResponse<OnlineExamAllocateSupportStaff> InsertOnlineExamAllocateSupportStaff(OnlineExamAllocateSupportStaff item);
        IBaseEntityResponse<OnlineExamAllocateSupportStaff> UpdateOnlineExamAllocateSupportStaff(OnlineExamAllocateSupportStaff item);
        IBaseEntityResponse<OnlineExamAllocateSupportStaff> DeleteOnlineExamAllocateSupportStaff(OnlineExamAllocateSupportStaff item);
        IBaseEntityCollectionResponse<OnlineExamAllocateSupportStaff> GetBySearch(OnlineExamAllocateSupportStaffSearchRequest searchRequest);
        //IBaseEntityResponse<OnlineExamAllocateSupportStaff> GetSessionNameList(OnlineExamAllocateSupportStaff item);
        IBaseEntityCollectionResponse<OnlineExamAllocateSupportStaff> GetOnlineExamAllocateSupportStaffSearchList(OnlineExamAllocateSupportStaffSearchRequest searchRequest);
        IBaseEntityResponse<OnlineExamAllocateSupportStaff> SelectByID(OnlineExamAllocateSupportStaff item);
        IBaseEntityResponse<OnlineExamAllocateSupportStaff> InsertOnlineExamAllocateJobSupportStaff(OnlineExamAllocateSupportStaff item);
    }
}
