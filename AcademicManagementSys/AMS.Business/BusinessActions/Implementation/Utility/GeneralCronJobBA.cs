using AMS.Base.DTO;
using AMS.Business.BusinessRules;
using AMS.Common;
using AMS.DataProvider;
using AMS.DTO;
using AMS.ExceptionManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessAction
{
    public class GeneralCronJobBA : IGeneralCronJobBA
    {
        IGeneralCronJobDataProvider _GeneralCronJobDataProvider;
        private ILogger _logException;

        public GeneralCronJobBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _GeneralCronJobDataProvider = new GeneralCronJobDataProvider();
        }


        public IBaseEntityResponse<GeneralCronJob> LeaveEmployeeAttendanceJob(GeneralCronJob item)
        {

            IBaseEntityResponse<GeneralCronJob> entityResponse = new BaseEntityResponse<GeneralCronJob>();
            try
            {
                entityResponse = _GeneralCronJobDataProvider.LeaveEmployeeAttendanceJob(item);
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
