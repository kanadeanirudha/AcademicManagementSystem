
using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using AMS.Business.BusinessRules.Interface.OnlineExam;

namespace AMS.Business.BusinessRules
{
    public interface IOnlineExamAllocateSupportStaffBR
    {
        IValidateBusinessRuleResponse InsertOnlineExamAllocateSupportStaffValidate(OnlineExamAllocateSupportStaff item);
        IValidateBusinessRuleResponse UpdateOnlineExamAllocateSupportStaffValidate(OnlineExamAllocateSupportStaff item);
        IValidateBusinessRuleResponse DeleteOnlineExamAllocateSupportStaffValidate(OnlineExamAllocateSupportStaff item);
        IValidateBusinessRuleResponse InsertOnlineExamAllocateJobSupportStaffValidate(OnlineExamAllocateSupportStaff item);

    }
}
