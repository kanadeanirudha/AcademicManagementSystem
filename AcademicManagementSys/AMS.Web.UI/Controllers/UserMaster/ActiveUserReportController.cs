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
    public class ActiveUserReportController : BaseController
    {

        #region ------------CONTROLLER CLASS VARIABLE------------

        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        private readonly ILogger _logException;
        protected string _centreCode = string.Empty;
        protected static int _balanesheetMstID;
        IUserMasterServiceAccess _userMasterServiceAccess = null;

        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public ActiveUserReportController()
        {
            _userMasterServiceAccess = new UserMasterServiceAccess();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            try
            {
                UserMasterViewModel model = new UserMasterViewModel();
                return View("/Views/UserMaster/ActiveUserReport/Index.cshtml", model);
            }
            catch(Exception ex)
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
            listOrganisationStudyCentreMaster = GetStudyCentreDetailsForReports(string.Empty, _balanesheetMstID);
            return listOrganisationStudyCentreMaster;
        }

        [NonAction]
        public List<UserMaster> GetListActiveUserReport()
        {
            try
            {
                List<UserMaster> listActiveUser = new List<UserMaster>();
                UserMasterSearchRequest searchRequest = new UserMasterSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                IBaseEntityCollectionResponse<UserMaster> baseEntityCollectionResponse = _userMasterServiceAccess.GetActiveUserBySearch(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listActiveUser = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                return listActiveUser;
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
