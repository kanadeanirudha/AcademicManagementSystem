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
    public class SalePromotionGetOfflineController : BaseApiController
    {
        private readonly ILogger _logException;
        ISalePromotionGetOfflineServiceAccess _SalePromotionGetOfflineServiceAccess = null;

        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        public SalePromotionGetOfflineController()
        {
            _SalePromotionGetOfflineServiceAccess = new SalePromotionGetOfflineServiceAccess();
        }


        [HttpPost]
        [AllowAnonymous]
        public object GetSalePromotionActivityMaster(SalePromotionGetOfflineViewModel model)
        {
            try
            {
                SalePromotionGetOfflineSearchRequest searchRequest = new SalePromotionGetOfflineSearchRequest ();

                searchRequest.ConnectionString = _connectioString;
                searchRequest.LastSyncDate = model.LastSyncDate;
                IBaseEntityCollectionResponse<SalePromotionGetOffline> baseEntityCollectionResponse = _SalePromotionGetOfflineServiceAccess.GetSalePromotionActivityMaster(searchRequest);
                List<SalePromotionGetOffline> SalePromotionGetOfflineMasterList = new List<SalePromotionGetOffline>();
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        SalePromotionGetOfflineMasterList = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }

                Dictionary<string, object> _dict = new Dictionary<string, object>
                    {
	                {"StatusCode", "200"},
	                {"Message", "Sale promotion Activity retrived successfully."},
	                {"SalePromotionOnFixAmountPlan", SalePromotionGetOfflineMasterList}};
                return _dict;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
         [HttpPost]
        [AllowAnonymous]
        public object GetSalePromotionActivityDetails(SalePromotionGetOfflineViewModel model)
        {
            try
            {
                SalePromotionGetOfflineSearchRequest searchRequest = new SalePromotionGetOfflineSearchRequest();

                searchRequest.ConnectionString = _connectioString;
                searchRequest.LastSyncDate = model.LastSyncDate;
                IBaseEntityCollectionResponse<SalePromotionGetOffline> baseEntityCollectionResponse = _SalePromotionGetOfflineServiceAccess.GetSalePromotionActivityDetails(searchRequest);
                List<SalePromotionGetOffline> SalePromotionActivityDetailsMasterList = new List<SalePromotionGetOffline>();
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        SalePromotionActivityDetailsMasterList = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }

                Dictionary<string, object> _dict = new Dictionary<string, object>
                    {
	                {"StatusCode", "200"},
	                {"Message", "Sale promotion Activity Details retrived successfully."},
	                {"SalePromotionOnFixAmountPlan", SalePromotionActivityDetailsMasterList}};
                return _dict;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        [AllowAnonymous]
         public object GetPromotionActivityDiscounteItemList(SalePromotionGetOfflineViewModel model)
        {
            try
            {
                SalePromotionGetOfflineSearchRequest searchRequest = new SalePromotionGetOfflineSearchRequest();

                searchRequest.ConnectionString = _connectioString;
                searchRequest.LastSyncDate = model.LastSyncDate;
                IBaseEntityCollectionResponse<SalePromotionGetOffline> baseEntityCollectionResponse = _SalePromotionGetOfflineServiceAccess.GetPromotionActivityDiscounteItemList(searchRequest);
                List<SalePromotionGetOffline> SalePromotionActivityDiscounteItemMasterList = new List<SalePromotionGetOffline>();
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        SalePromotionActivityDiscounteItemMasterList = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }

                Dictionary<string, object> _dict = new Dictionary<string, object>
                    {
	                {"StatusCode", "200"},
	                {"Message", "Sale promotion Activity discount Item List retrived successfully."},
	                {"SalePromotionOnFixAmountPlan", SalePromotionActivityDiscounteItemMasterList}};
                return _dict;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

      [HttpPost]
      [AllowAnonymous]
        public object GetSalePromotionPlan(SalePromotionGetOfflineViewModel model)
        {
            try
            {
                SalePromotionGetOfflineSearchRequest searchRequest = new SalePromotionGetOfflineSearchRequest();

                searchRequest.ConnectionString = _connectioString;
                searchRequest.LastSyncDate = model.LastSyncDate;
                IBaseEntityCollectionResponse<SalePromotionGetOffline> baseEntityCollectionResponse = _SalePromotionGetOfflineServiceAccess.GetSalePromotionPlan(searchRequest);
                List<SalePromotionGetOffline> SalePromotionPlanMasterList = new List<SalePromotionGetOffline>();
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        SalePromotionPlanMasterList = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }

                Dictionary<string, object> _dict = new Dictionary<string, object>
                    {
	                {"StatusCode", "200"},
	                {"Message", "Sale promotion Plan data  retrived successfully."},
	                {"SalePromotionOnFixAmountPlan", SalePromotionPlanMasterList}};
                return _dict;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

      [HttpPost]
      [AllowAnonymous]
      public object GetSalePromotionPlanDetails(SalePromotionGetOfflineViewModel model)
        {
            try
            {
                SalePromotionGetOfflineSearchRequest searchRequest = new SalePromotionGetOfflineSearchRequest();

                searchRequest.ConnectionString = _connectioString;
                searchRequest.LastSyncDate = model.LastSyncDate;
                IBaseEntityCollectionResponse<SalePromotionGetOffline> baseEntityCollectionResponse = _SalePromotionGetOfflineServiceAccess.GetSalePromotionPlanDetails(searchRequest);
                List<SalePromotionGetOffline> SalePromotionPlanDetailsMasterList = new List<SalePromotionGetOffline>();
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        SalePromotionPlanDetailsMasterList = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }

                Dictionary<string, object> _dict = new Dictionary<string, object>
                    {
	                {"StatusCode", "200"},
	                {"Message", "Sale promotion Plan Details data  retrived successfully."},
	                {"SalePromotionOnFixAmountPlan", SalePromotionPlanDetailsMasterList}};
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
