using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
	public interface ILeaveShiftAllocateToCentreServiceAccess
	{
		IBaseEntityResponse<LeaveShiftAllocateToCentre> InsertLeaveShiftAllocateToCentre(LeaveShiftAllocateToCentre item);
		IBaseEntityResponse<LeaveShiftAllocateToCentre> UpdateLeaveShiftAllocateToCentre(LeaveShiftAllocateToCentre item);
		IBaseEntityResponse<LeaveShiftAllocateToCentre> DeleteLeaveShiftAllocateToCentre(LeaveShiftAllocateToCentre item);
		IBaseEntityCollectionResponse<LeaveShiftAllocateToCentre> GetBySearch(LeaveShiftAllocateToCentreSearchRequest searchRequest);
		IBaseEntityResponse<LeaveShiftAllocateToCentre> SelectByID(LeaveShiftAllocateToCentre item);
	}
}
