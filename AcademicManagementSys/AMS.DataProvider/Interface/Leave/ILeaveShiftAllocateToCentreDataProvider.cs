using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
	public interface ILeaveShiftAllocateToCentreDataProvider
	{
		IBaseEntityResponse<LeaveShiftAllocateToCentre> InsertLeaveShiftAllocateToCentre(LeaveShiftAllocateToCentre item);
		IBaseEntityResponse<LeaveShiftAllocateToCentre> UpdateLeaveShiftAllocateToCentre(LeaveShiftAllocateToCentre item);
		IBaseEntityResponse<LeaveShiftAllocateToCentre> DeleteLeaveShiftAllocateToCentre(LeaveShiftAllocateToCentre item);
		IBaseEntityCollectionResponse<LeaveShiftAllocateToCentre> GetLeaveShiftAllocateToCentreBySearch(LeaveShiftAllocateToCentreSearchRequest searchRequest);
		IBaseEntityResponse<LeaveShiftAllocateToCentre> GetLeaveShiftAllocateToCentreByID(LeaveShiftAllocateToCentre item);
	}
}
