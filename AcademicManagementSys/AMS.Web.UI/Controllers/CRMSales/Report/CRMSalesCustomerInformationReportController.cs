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
using AMS.Business.BusinessActions;
namespace AMS.Web.UI.Controllers
{
    public class CRMSalesCustomerInformationReportController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        ICRMSalesCustomerInformationReportServiceAccess _CRMSalesCustomerInformationReportServiceAccess = null;
        private readonly ILogger _logException;
        protected string _centreCode = string.Empty;
        
        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public CRMSalesCustomerInformationReportController()
        {
            _CRMSalesCustomerInformationReportServiceAccess = new CRMSalesCustomerInformationReportServiceAccess();          
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {               
           return View("/Views/CRMSales/Report/CRMSalesCustomerInformationReport/Index.cshtml");
        }

        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------

        public List<CRMSalesCustomerInformationReport> GetCRMSalesCustomerInformationReport()
        {
            try
            {
                List<CRMSalesCustomerInformationReport> listCRMSalesCustomerInformationReport = new List<CRMSalesCustomerInformationReport>();
                CRMSalesCustomerInformationReportSearchRequest searchRequest = new CRMSalesCustomerInformationReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                IBaseEntityCollectionResponse<CRMSalesCustomerInformationReport> baseEntityCollectionResponse = _CRMSalesCustomerInformationReportServiceAccess.GetCRMSalesCustomerInformationReportBySearch_Account(searchRequest);
                    if (baseEntityCollectionResponse != null)
                    {
                        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                        {
                            listCRMSalesCustomerInformationReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                        }
                    }
                return listCRMSalesCustomerInformationReport;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
       
        
        #endregion



    }
}
