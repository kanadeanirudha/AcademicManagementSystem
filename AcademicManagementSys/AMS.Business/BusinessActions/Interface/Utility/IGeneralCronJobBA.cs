using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessAction
{
    public interface IGeneralCronJobBA
    {
        IBaseEntityResponse<GeneralCronJob> LeaveEmployeeAttendanceJob(GeneralCronJob item);
    }
}
