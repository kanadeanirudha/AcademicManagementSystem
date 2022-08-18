using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class GeneralCronJobServiceAccess : IGeneralCronJobServiceAccess
    {
        IGeneralCronJobBA _GeneralCronJobBA = null;

        public GeneralCronJobServiceAccess()
        {
            _GeneralCronJobBA = new GeneralCronJobBA();
        }


        public IBaseEntityResponse<GeneralCronJob> LeaveEmployeeAttendanceJob(GeneralCronJob item)
        {
            return _GeneralCronJobBA.LeaveEmployeeAttendanceJob(item);
        }

    }
}
