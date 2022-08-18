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
using AMS.DataProvider;
namespace AMS.Web.UI.Controllers
{
    public class AccountMasterReportController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        IAccountMasterReportServiceAccess _AccountMasterReportServiceAccess = null;
        IAccountHeadMasterReportServiceAccess _accountHeadMasterReportServiceAccess = null;
        IAccountCategoryMasterReportServiceAccess _accountCategoryMasterReportServiceAccess = null;

        private readonly ILogger _logException;
        protected string _centreCode = string.Empty;
        //protected static int _balanesheetMstID;
        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public AccountMasterReportController()
        {
            _AccountMasterReportServiceAccess = new AccountMasterReportServiceAccess();
            _accountCategoryMasterReportServiceAccess = new AccountCategoryMasterReportServiceAccess();
            _accountHeadMasterReportServiceAccess = new AccountHeadMasterReportServiceAccess();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            if (Convert.ToInt32(Session["SuperUser"]) > 0 || Convert.ToInt32(Session["FinMgr"]) > 0)
            {
                //_balanesheetMstID = Convert.ToInt32(Session["BalancesheetID"].ToString());
                return View("/Views/Accounts/AccountMasterReport/Index.cshtml");
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------

        public List<OrganisationStudyCentreMaster> GetReportHeader()
        {
            List<OrganisationStudyCentreMaster> listOrganisationStudyCentreMaster = new List<OrganisationStudyCentreMaster>();
            listOrganisationStudyCentreMaster = GetStudyCentreDetailsForReports(_centreCode, 0);
            return listOrganisationStudyCentreMaster;
        }

        public List<AccountMasterReport> GetAccountDetailsForReport()
        {
            try
            {
                List<AccountMasterReport> listAccountMasterReport = new List<AccountMasterReport>();
                AccountMasterReportSearchRequest searchRequest = new AccountMasterReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                //  Session["SuperUser"].ToString();
                // string aaa = Session["BalancesheetID"].ToString();
                //if (_balanesheetMstID > 0)
                //{

                //    searchRequest.AccMstBalsheetID = _balanesheetMstID;

                    IBaseEntityCollectionResponse<AccountMasterReport> baseEntityCollectionResponse = _AccountMasterReportServiceAccess.GetBySearch(searchRequest);
                    if (baseEntityCollectionResponse != null)
                    {
                        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                        {
                            listAccountMasterReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                        }
                    }
                //}
                return listAccountMasterReport;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
            finally
            {
             //   _balanesheetMstID = 0;
            }

        }
        #endregion



    }
}
