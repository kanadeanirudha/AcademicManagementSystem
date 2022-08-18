
using AMS.Base.DTO;
using AMS.DTO;
using AMS.ServiceAccess;
using AMS.ExceptionManager;
using AMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AMS.Common;

namespace AMS.Web.UI.Controllers
{
    [AllowAnonymous]
    public class CronJobLeaveEmployeeAttendanceJobController : BaseController
    {
      
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public CronJobLeaveEmployeeAttendanceJobController()
        {
        }

        // Controller Methods
        #region Controller Methods
        [AllowAnonymous]
        public ActionResult Index()
        {
           IGeneralCronJobServiceAccess _GeneralCronJobServiceAccess = new GeneralCronJobServiceAccess();
            GeneralCronJob item = new GeneralCronJob();
            item.ConnectionString = _connectioString;
            item.CentreCode = "HO";
            IBaseEntityResponse<GeneralCronJob> response = _GeneralCronJobServiceAccess.LeaveEmployeeAttendanceJob(item);
            return null;
        }

     

        #endregion

    }
}