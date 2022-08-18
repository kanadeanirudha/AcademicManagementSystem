using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
	public interface ILeaveShiftAllocateToCentreBR
	{
		IValidateBusinessRuleResponse InsertLeaveShiftAllocateToCentreValidate(LeaveShiftAllocateToCentre item);
		IValidateBusinessRuleResponse UpdateLeaveShiftAllocateToCentreValidate(LeaveShiftAllocateToCentre item);
		IValidateBusinessRuleResponse DeleteLeaveShiftAllocateToCentreValidate(LeaveShiftAllocateToCentre item);
	}
}
