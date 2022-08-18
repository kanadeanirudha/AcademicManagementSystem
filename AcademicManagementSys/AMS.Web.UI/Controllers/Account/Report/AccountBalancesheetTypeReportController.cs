using AMS.Base.DTO;
using AMS.DTO;
using AMS.ServiceAccess;
using AMS.ViewModel;
using System;
using AMS.ExceptionManager;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AMS.Common;

namespace AMS.Web.UI.Controllers
{
    public class AccountBalancesheetTypeReportController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        IAccountBalancesheetTypeReportServiceAccess _accountBalancesheetTypeReportServiceAccess = null;
        private readonly ILogger _logException;

        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public AccountBalancesheetTypeReportController()
        {
            _accountBalancesheetTypeReportServiceAccess = new AccountBalancesheetTypeReportServiceAccess();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            try
            {
                if (Convert.ToInt32(Session["SuperUser"]) > 0 || Convert.ToInt32(Session["FinMgr"]) > 0)
                {
                    return View("/Views/Accounts/AccountBalancesheetTypeReport/Index.cshtml");
                }
                else
                {
                    return RedirectToAction("UnauthorizedAccess", "Home");
                }
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
      
        #endregion

         #region ------------CONTROLLER NON ACTION METHODS------------

        public List<OrganisationStudyCentreMaster> GetReportHeader()
        {
            List<OrganisationStudyCentreMaster> listOrganisationStudyCentreMaster = new List<OrganisationStudyCentreMaster>();
            listOrganisationStudyCentreMaster = GetStudyCentreDetailsForReports(string.Empty, 0);
            return listOrganisationStudyCentreMaster;
        }

        public List<AccountBalancesheetTypeReport> GetListAccountBalancesheetTypeReport()
         {
             try
             {
                 List<AccountBalancesheetTypeReport> listAccountBalancesheetTypeReport =  new List<AccountBalancesheetTypeReport>();
                 AccountBalancesheetTypeReportSearchRequest searchRequest = new AccountBalancesheetTypeReportSearchRequest();
                 searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                    
                IBaseEntityCollectionResponse<AccountBalancesheetTypeReport> baseEntityCollectionResponse = _accountBalancesheetTypeReportServiceAccess.GetBySearch(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listAccountBalancesheetTypeReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                return listAccountBalancesheetTypeReport;
             }
             catch (Exception ex)
             {
                 _logException.Error(ex.Message);
                 throw;
             }
             finally
             {
             }
         }
         #endregion
    }
}