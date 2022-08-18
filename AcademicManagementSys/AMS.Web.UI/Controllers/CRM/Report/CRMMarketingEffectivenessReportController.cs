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
using System.Data;
using System.Data.SqlClient;
namespace AMS.Web.UI.Controllers
{
    public class CRMMarketingEffectivenessReportController : BaseController
    {
        ICRMCallMasterAndDetailsServiceAccess _CRMCallMasterAndDetailsServiceAccess = null;

        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public CRMMarketingEffectivenessReportController()
        {
            _CRMCallMasterAndDetailsServiceAccess = new CRMCallMasterAndDetailsServiceAccess();

        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            return View("/Views/CRM/CRMMarketingEffectivenessReport/Index.cshtml");
        }
      
        public ActionResult MarketingEffectivenessPieChart(string FromDate, string UptoDate)
        {
            CRMCallMasterAndDetailsViewModel model = new CRMCallMasterAndDetailsViewModel();
            return PartialView("/Views/CRM/CRMMarketingEffectivenessReport/MarketingEffectivenessPieChart.cshtml", model);
        }

        [HttpGet]
        public JsonResult MarketingEffectivenessData(string FromDate, string UptoDate)
        {

            var crmCallerCallDetails = CRMMarketingEffectivenessDetailsList(FromDate, UptoDate);
            var result = (from s in crmCallerCallDetails
                          select new
                          {
                              countSource = s.CountSource,
                              source = s.Source,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }  
        #endregion

        // Non-Action Method
        #region Methods


        protected List<CRMCallMasterAndDetails> CRMMarketingEffectivenessDetailsList(string fromDate, string uptoDate)
        {
            CRMCallMasterAndDetailsSearchRequest searchRequest = new CRMCallMasterAndDetailsSearchRequest();
            searchRequest.FromDate = fromDate;
            searchRequest.UptoDate = uptoDate;
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<CRMCallMasterAndDetails> CRMCallerCallDetailsList = new List<CRMCallMasterAndDetails>();

            IBaseEntityCollectionResponse<CRMCallMasterAndDetails> baseEntityCollectionResponse = _CRMCallMasterAndDetailsServiceAccess.CRMMarketingEffectivenessReport(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    CRMCallerCallDetailsList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return CRMCallerCallDetailsList;
        }


        #endregion

    }
}