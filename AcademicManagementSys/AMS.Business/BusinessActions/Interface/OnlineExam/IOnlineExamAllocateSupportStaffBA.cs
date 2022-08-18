
using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IOnlineExamAllocateSupportStaffBA
    {
        IBaseEntityResponse<OnlineExamAllocateSupportStaff> InsertOnlineExamAllocateSupportStaff(OnlineExamAllocateSupportStaff item);
         IBaseEntityResponse<OnlineExamAllocateSupportStaff> UpdateOnlineExamAllocateSupportStaff(OnlineExamAllocateSupportStaff item);
        IBaseEntityResponse<OnlineExamAllocateSupportStaff> DeleteOnlineExamAllocateSupportStaff(OnlineExamAllocateSupportStaff item);
        IBaseEntityCollectionResponse<OnlineExamAllocateSupportStaff> GetBySearch(OnlineExamAllocateSupportStaffSearchRequest searchRequest);
        //IBaseEntityCollectionResponse<OnlineExamAllocateSupportSfaff> GetSessionNameList(OnlineExamAllocateSupportSfaff searchRequest);
        IBaseEntityCollectionResponse<OnlineExamAllocateSupportStaff> GetOnlineExamAllocateSupportStaffSearchList(OnlineExamAllocateSupportStaffSearchRequest searchRequest);
        IBaseEntityResponse<OnlineExamAllocateSupportStaff> SelectByID(OnlineExamAllocateSupportStaff item);

        IBaseEntityResponse<OnlineExamAllocateSupportStaff> InsertOnlineExamAllocateJobSupportStaff(OnlineExamAllocateSupportStaff item);
    }

}

