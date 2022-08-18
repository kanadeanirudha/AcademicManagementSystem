﻿using AMS.Base.DTO;
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
    public class AccountVoucherSettingMasterReportController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        private readonly ILogger _logException;
        protected string _centreCode = string.Empty;
        protected static int _balanesheetMstID;
        IAccountVoucherSettingMasterReportServiceAccess _accountVoucherSettingMasterReportServiceAccess = null;
        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public AccountVoucherSettingMasterReportController()
        {
            _accountVoucherSettingMasterReportServiceAccess = new AccountVoucherSettingMasterReportServiceAccess();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            try
            {
                if (Convert.ToInt32(Session["SuperUser"]) > 0 || Convert.ToInt32(Session["FinMgr"]) > 0)
                {
                    AccountVoucherSettingMasterReportViewModel model = new AccountVoucherSettingMasterReportViewModel();
                    _balanesheetMstID = Convert.ToInt32(Session["BalancesheetID"].ToString());
                    return View("/Views/Accounts/AccountVoucherSettingMasterReport/Index.cshtml", model);
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

            //  return View("/Views/Accounts/AccountVoucherSettingMasterReport/Index.cshtml");
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
        public List<AccountVoucherSettingMasterReport> GetListAccountSessionMaster()
        {
            try
            {
                List<AccountVoucherSettingMasterReport> listAccountSessionMaster = new List<AccountVoucherSettingMasterReport>();
                AccountVoucherSettingMasterReportSearchRequest searchRequest = new AccountVoucherSettingMasterReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                searchRequest.BalanesheetMstID = _balanesheetMstID;
                IBaseEntityCollectionResponse<AccountVoucherSettingMasterReport> baseEntityCollectionResponse = _accountVoucherSettingMasterReportServiceAccess.GetBySearch(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listAccountSessionMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                return listAccountSessionMaster;
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
