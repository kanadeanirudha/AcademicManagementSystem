using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
	public class LeaveShiftAllocateToCentreServiceAccess : ILeaveShiftAllocateToCentreServiceAccess
	{
		ILeaveShiftAllocateToCentreBA _LeaveShiftAllocateToCentreBA = null;
		public LeaveShiftAllocateToCentreServiceAccess()
		{
			_LeaveShiftAllocateToCentreBA = new LeaveShiftAllocateToCentreBA();
		}
		public IBaseEntityResponse<LeaveShiftAllocateToCentre> InsertLeaveShiftAllocateToCentre(LeaveShiftAllocateToCentre item)
		{
			return _LeaveShiftAllocateToCentreBA.InsertLeaveShiftAllocateToCentre(item);
		}
		public IBaseEntityResponse<LeaveShiftAllocateToCentre> UpdateLeaveShiftAllocateToCentre(LeaveShiftAllocateToCentre item)
		{
			return _LeaveShiftAllocateToCentreBA.UpdateLeaveShiftAllocateToCentre(item);
		}
		public IBaseEntityResponse<LeaveShiftAllocateToCentre> DeleteLeaveShiftAllocateToCentre(LeaveShiftAllocateToCentre item)
		{
			return _LeaveShiftAllocateToCentreBA.DeleteLeaveShiftAllocateToCentre(item);
		}
		public IBaseEntityCollectionResponse<LeaveShiftAllocateToCentre> GetBySearch(LeaveShiftAllocateToCentreSearchRequest searchRequest)
		{
			return _LeaveShiftAllocateToCentreBA.GetBySearch(searchRequest);
		}
		public IBaseEntityResponse<LeaveShiftAllocateToCentre> SelectByID(LeaveShiftAllocateToCentre item)
		{
			return _LeaveShiftAllocateToCentreBA.SelectByID(item);
		}
	}
}
