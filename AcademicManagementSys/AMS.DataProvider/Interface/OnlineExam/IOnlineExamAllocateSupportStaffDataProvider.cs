using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IOnlineExamAllocateSupportStaffDataProvider
    {
        IBaseEntityResponse<OnlineExamAllocateSupportStaff> InsertOnlineExamAllocateSupportStaff(OnlineExamAllocateSupportStaff item);
        IBaseEntityResponse<OnlineExamAllocateSupportStaff> UpdateOnlineExamAllocateSupportStaff(OnlineExamAllocateSupportStaff item);
        IBaseEntityResponse<OnlineExamAllocateSupportStaff> DeleteOnlineExamAllocateSupportStaff(OnlineExamAllocateSupportStaff item);
        IBaseEntityCollectionResponse<OnlineExamAllocateSupportStaff> GetOnlineExamAllocateSupportStaffBySearch(OnlineExamAllocateSupportStaffSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OnlineExamAllocateSupportStaff> GetOnlineExamAllocateSupportStaffSearchList(OnlineExamAllocateSupportStaffSearchRequest searchRequest);
       // IBaseEntityCollectionResponse<OnlineExamAllocateSupportStaff> GetSessionNameList(OnlineExamAllocateSupportStaff searchRequest);
        IBaseEntityResponse<OnlineExamAllocateSupportStaff> GetOnlineExamAllocateSupportStaffByID(OnlineExamAllocateSupportStaff item);

       // IBaseEntityCollectionResponse<OnlineExamAllocateSupportStaff> GetSessionNameList(OnlineExamAllocateSupportStaffSearchRequest searchRequest);
        IBaseEntityResponse<OnlineExamAllocateSupportStaff> InsertOnlineExamAllocateJobSupportStaff(OnlineExamAllocateSupportStaff item);
    }
}

