using AMS.Base.DTO;
using AMS.DTO;
using AMS.Business.BusinessAction;
namespace AMS.ServiceAccess
{
	public class OnlineExaminationHallTicketServiceAccess : IOnlineExaminationHallTicketServiceAccess
	{
		IOnlineExaminationHallTicketBA _OnlineExaminationHallTicketBA = null;
        public OnlineExaminationHallTicketServiceAccess()
		{
            _OnlineExaminationHallTicketBA = new OnlineExaminationHallTicketBA();
		}


        public IBaseEntityResponse<OnlineExaminationHallTicket> SelectByID(OnlineExaminationHallTicket item)
		{
            return _OnlineExaminationHallTicketBA.SelectByID(item);
		}
	}
}
