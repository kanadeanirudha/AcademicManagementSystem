using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AMS.ServiceAccess;
using AMS.Base.DTO;
using AMS.ExceptionManager;
using AMS.Common;
using System.Configuration;
using AMS.DTO;
using AMS.ViewModel;
using System.Globalization;
namespace AMS.Web.UI.Controllers.API
{
    public class SalePromotionOnFixAmountPlanController : BaseApiController
    {
        private readonly ILogger _logException;
        ISalePromotionOnFixAmountPlanServiceAccess _SalePromotionOnFixAmountPlanServiceAccess = null;

        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        public SalePromotionOnFixAmountPlanController()
        {
            _SalePromotionOnFixAmountPlanServiceAccess = new SalePromotionOnFixAmountPlanServiceAccess();
        }


        [HttpPost]
        [AllowAnonymous]
        public object SalePromotionOnFixAmountPlan(SalePromotionOnFixAmountPlanViewModel model)
        {
            try
            {
                SalePromotionOnFixAmountPlanSearchRequest searchRequest = new SalePromotionOnFixAmountPlanSearchRequest();

                searchRequest.ConnectionString = _connectioString;
                searchRequest.GeneralUnitsID = model.GeneralUnitsID;
                IBaseEntityCollectionResponse<SalePromotionOnFixAmountPlan> baseEntityCollectionResponse = _SalePromotionOnFixAmountPlanServiceAccess.SalePromotionPriceDiscountOnFixAmountPlan(searchRequest);
                List<SalePromotionOnFixAmountPlan> SalePromotionOnFixAmountPlanMasterList = new List<SalePromotionOnFixAmountPlan>();
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        SalePromotionOnFixAmountPlanMasterList = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }

                Dictionary<string, object> _dict = new Dictionary<string, object>
                    {
	                {"StatusCode", "200"},
	                {"Message", "Sale promotion discount data  retrived successfully."},
	                {"SalePromotionOnFixAmountPlan", SalePromotionOnFixAmountPlanMasterList}};
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
