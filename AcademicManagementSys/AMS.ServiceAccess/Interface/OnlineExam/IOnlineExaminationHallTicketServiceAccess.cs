using AMS.Base.DTO;
using AMS.DTO;
namespace AMS.ServiceAccess
{
	public interface IOnlineExaminationHallTicketServiceAccess
	{

        IBaseEntityResponse<OnlineExaminationHallTicket> SelectByID(OnlineExaminationHallTicket item);
	}
}
