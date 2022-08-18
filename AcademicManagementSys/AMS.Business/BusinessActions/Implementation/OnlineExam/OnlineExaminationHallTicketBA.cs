
using AMS.Base.DTO;
using AMS.DTO;
using AMS.Common;
using AMS.DataProvider;
using AMS.Business.BusinessRules;
using AMS.ExceptionManager;
using System;
namespace AMS.Business.BusinessAction
{
	public class OnlineExaminationHallTicketBA : IOnlineExaminationHallTicketBA
	{
        IOnlineExaminationHallTicketDataProvider _OnlineExaminationHallTicketDataProvider;
		//IOnlineExaminationHallTicketBR _OnlineExaminationHallTicketBR;
		private ILogger _logException;
		public OnlineExaminationHallTicketBA()
		{
			_logException = new ExceptionManager.ExceptionManager(); //This need to change later
			//_OnlineExaminationHallTicketBR = new OnlineExaminationHallTicketBR();
			_OnlineExaminationHallTicketDataProvider = new OnlineExaminationHallTicketDataProvider();
		}
		/// <summary>
		/// get new record from OnlineExaminationHallTicket.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
	
		public IBaseEntityResponse<OnlineExaminationHallTicket> SelectByID(OnlineExaminationHallTicket item)
		{
			IBaseEntityResponse<OnlineExaminationHallTicket> entityResponse = new BaseEntityResponse<OnlineExaminationHallTicket>();
			try
			{
				 entityResponse = _OnlineExaminationHallTicketDataProvider.GetOnlineExaminationHallTicketByID(item);
			}
			catch (Exception ex)
			{
				entityResponse.Message.Add(new MessageDTO
				{
					ErrorMessage = ex.Message,
					 MessageType = MessageTypeEnum.Error
				});
				entityResponse.Entity = null;
				if (_logException != null)
				{
					_logException.Error(ex.Message);
				}
			}
			return entityResponse;
		}
	}
}
