using AMS.Base.DTO;
using AMS.DTO;
namespace AMS.DataProvider
{
	public interface IOnlineExaminationHallTicketDataProvider
	{
		
		IBaseEntityResponse<OnlineExaminationHallTicket> GetOnlineExaminationHallTicketByID(OnlineExaminationHallTicket item);

        
	}
}
