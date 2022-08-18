
using AMS.Base.DTO;
using AMS.ExceptionManager;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Http;
using AMS.DTO;
using AMS.ViewModel;
using AMS.ServiceAccess;
namespace AMS.Web.UI.Controllers.API
{
    public class InventoryStoreBillingPrintingInfoController : BaseApiController
    {
        private readonly ILogger _logException;
        IInventoryStoreBillingPrintingInfoServiceAccess _InventoryStoreBillingPrintingInfoAPIServiceAccess = null;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        public InventoryStoreBillingPrintingInfoController()
        {
            _InventoryStoreBillingPrintingInfoAPIServiceAccess = new InventoryStoreBillingPrintingInfoServiceAccess();
        }
        [HttpPost]
        [AllowAnonymous]
        public object GetInventoryStoreBillingPrintingInfo(InventoryStoreBillingPrintingInfoViewModel model)
        {
            try
            {
                InventoryStoreBillingPrintingInfoSearchRequest searchRequest = new InventoryStoreBillingPrintingInfoSearchRequest();
                searchRequest.ConnectionString = _connectioString;
                searchRequest.GeneralUnitsID = model.GeneralUnitsID;
                searchRequest.LastSyncDate = model.LastSyncDate;
                IBaseEntityCollectionResponse<InventoryStoreBillingPrintingInfo> baseEntityCollectionResponse = _InventoryStoreBillingPrintingInfoAPIServiceAccess.GetInventoryStoreBillingPrintingInfo(searchRequest);
                List<InventoryStoreBillingPrintingInfo> InventoryStoreBillingPrintingInfoAPIList = new List<InventoryStoreBillingPrintingInfo>();
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        InventoryStoreBillingPrintingInfoAPIList = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }

                Dictionary<string, object> _dict = new Dictionary<string, object>
               {
                    {"StatusCode", "200"},
                    {"Message", "Billing printing List retrived successfully."},
                    {"Data", InventoryStoreBillingPrintingInfoAPIList}};
                return _dict;

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

    }
}
