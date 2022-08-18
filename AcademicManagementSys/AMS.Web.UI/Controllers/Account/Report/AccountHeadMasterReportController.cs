using AMS.Base.DTO;
using AMS.DTO;
using AMS.ServiceAccess;
using AMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AMS.Common;
using System.Web.Mvc.Ajax;
using AMS.ExceptionManager;
using System.IO;

namespace AMS.Web.UI.Controllers
{
    public class AccountHeadMasterReportController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        private readonly ILogger _logException;
        protected string _centreCode = string.Empty;
        protected static int _balanesheetMstID;
        IAccountHeadMasterReportServiceAccess _accountHeadMasterReportServiceAccess = null;
        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public AccountHeadMasterReportController()
        {
            _accountHeadMasterReportServiceAccess = new AccountHeadMasterReportServiceAccess();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            try
            {
                if (Convert.ToInt32(Session["SuperUser"]) > 0 || Convert.ToInt32(Session["FinMgr"]) > 0)
                {
                    AccountHeadMasterReportViewModel model = new AccountHeadMasterReportViewModel();
                    _balanesheetMstID = Convert.ToInt32(Session["BalancesheetID"].ToString());
                    return View("/Views/Accounts/AccountHeadMasterReport/Index.cshtml", model);
                }
                else
                {
                    return RedirectToAction("UnauthorizedAccess", "Home");
                }

            }
            catch (Exception)
            {

                throw;
            }

            //  return View("/Views/Accounts/AccountHeadMasterReport/Index.cshtml");
        }

    

        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------
        public List<OrganisationStudyCentreMaster> GetReportHeader()
        {
            List<OrganisationStudyCentreMaster> listOrganisationStudyCentreMaster = new List<OrganisationStudyCentreMaster>();
            listOrganisationStudyCentreMaster = GetStudyCentreDetailsForReports(string.Empty, _balanesheetMstID);
            return listOrganisationStudyCentreMaster;
        }
        [NonAction]
        public List<AccountHeadMasterReport> GetListAccountHeadMaster()
        {
            try
            {
                List<AccountHeadMasterReport> listAccountHeadMaster = new List<AccountHeadMasterReport>();
                AccountHeadMasterReportSearchRequest searchRequest = new AccountHeadMasterReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                IBaseEntityCollectionResponse<AccountHeadMasterReport> baseEntityCollectionResponse = _accountHeadMasterReportServiceAccess.GetBySearch(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listAccountHeadMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                return listAccountHeadMaster;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
            finally
            {
              //  _balanesheetMstID = 0;
            }
        }

        #endregion



    }
}
