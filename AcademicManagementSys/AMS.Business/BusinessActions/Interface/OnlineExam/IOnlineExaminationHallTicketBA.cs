using AMS.Base.DTO;
using AMS.DTO;
namespace AMS.Business.BusinessAction
{
	public interface IOnlineExaminationHallTicketBA
	{
        IBaseEntityResponse<OnlineExaminationHallTicket> SelectByID(OnlineExaminationHallTicket item);
	}
}
