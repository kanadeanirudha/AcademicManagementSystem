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
    public class InventorySyncController : BaseApiController
    {
        private readonly ILogger _logException;
        IAPIInventoryServiceAccess _apiInventoryServiceAccess = null;

        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        public InventorySyncController()
        {
            _apiInventoryServiceAccess = new APIInventoryServiceAccess();
        }

        [HttpPost]
        [AllowAnonymous]
        public object PostOnline(APIInventoryViewModel model)
        {
            try
            {
                APIInventoryViewModel _apiInventoryViewModel = new APIInventoryViewModel();
                var dictionary = new object();
                if (ModelState.IsValid && model != null)
                {
                    _apiInventoryViewModel.APIInventoryDTO = new APIInventory();
                    _apiInventoryViewModel.APIInventoryDTO.InvSaleMasterXML = model.InvSaleMasterXML;
                    _apiInventoryViewModel.APIInventoryDTO.InvSaleTransactionXML = model.InvSaleTransactionXML;
                    _apiInventoryViewModel.APIInventoryDTO.InvSaleVoucherXML = model.InvSaleVoucherXML;
                    _apiInventoryViewModel.APIInventoryDTO.CreatedBy = model.UserID;
                    _apiInventoryViewModel.APIInventoryDTO.ConnectionString = _connectioString;
                    IBaseEntityResponse<APIInventory> response = _apiInventoryServiceAccess.PostOnline(_apiInventoryViewModel.APIInventoryDTO);
                    //dictionary = (IDictionary<string, object>)response;  
                    Dictionary<string, object> _dict = new Dictionary<string, object>
                    {
	                {"StatusCode", response.Entity.Status},
	                {"Message", response.Entity.ErrorMessage},
	                {"PostOnline", response.Entity}};
                    return _dict;
                }
                return 0;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public object SingleBillPostOnline(APIInventoryViewModel model)
        {
            try
            {
                APIInventoryViewModel _apiInventoryViewModel = new APIInventoryViewModel();
                var dictionary = new object();
                if (ModelState.IsValid && model != null)
                {
                    _apiInventoryViewModel.APIInventoryDTO = new APIInventory();
                    _apiInventoryViewModel.APIInventoryDTO.InvSaleMasterXML = model.InvSaleMasterXML;
                    _apiInventoryViewModel.APIInventoryDTO.InvSaleTransactionXML = model.InvSaleTransactionXML.Replace("&", "[and]"); 
                    _apiInventoryViewModel.APIInventoryDTO.InvSaleVoucherXML = model.InvSaleVoucherXML;
                    _apiInventoryViewModel.APIInventoryDTO.CreatedBy = model.UserID;
                    _apiInventoryViewModel.APIInventoryDTO.ConnectionString = _connectioString;
                    IBaseEntityResponse<APIInventory> response = _apiInventoryServiceAccess.SingleBillPostOnline(_apiInventoryViewModel.APIInventoryDTO);
                    //dictionary = (IDictionary<string, object>)response;  
                    Dictionary<string, object> _dict = new Dictionary<string, object>
                    {
	                {"StatusCode", response.Entity.Status},
	                {"Message", response.Entity.ErrorMessage},
                    {"BillNumbers", response.Entity.BillNumbers},
	                {"PostOnline", response.Entity}};
                    return _dict;
                }
                return 0;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        [HttpPost]
        [AllowAnonymous]
        public object GetOnline(APIInventoryViewModel model)
        {
            try
            {
                APIInventorySearchRequest searchRequest = new APIInventorySearchRequest();

                searchRequest.GeneralUnitsID = model.GeneralUnitsID;
                searchRequest.LastSyncDate = model.LastSyncDate;
                searchRequest.ConnectionString = _connectioString;
                IBaseEntityCollectionResponse<APIInventory> baseEntityCollectionResponse = _apiInventoryServiceAccess.InventoryGetOnline(searchRequest);
                List<APIInventory> APIInventoryMasterList = new List<APIInventory>();
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        APIInventoryMasterList = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }

                Dictionary<string, object> _dict = new Dictionary<string, object>
                    {
	                {"StatusCode", "200"},
	                {"Message", "Inventory Master is retrived successfully."},
	                {"GetOnline", APIInventoryMasterList}};
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
        public object GetLocalInvoiceNo(APIInventoryViewModel model)
        {
            try
            {
                APIInventoryViewModel _apiInventoryViewModel = new APIInventoryViewModel();

                var dictionary = new object();
                if (ModelState.IsValid && model != null)
                {
                    _apiInventoryViewModel.APIInventoryDTO = new APIInventory();
                    _apiInventoryViewModel.APIInventoryDTO.GeneralUnitsID = model.GeneralUnitsID;
                    _apiInventoryViewModel.APIInventoryDTO.CounterMstID = model.CounterMstID;
                    _apiInventoryViewModel.APIInventoryDTO.KeyField = model.KeyField;
                    _apiInventoryViewModel.APIInventoryDTO.ConnectionString = _connectioString;
                    IBaseEntityResponse<APIInventory> response = _apiInventoryServiceAccess.GetLocalInvoiceNo(_apiInventoryViewModel.APIInventoryDTO);
                    Dictionary<string, object> _dict = new Dictionary<string, object>
                    {
	                {"StatusCode", response.Entity.Status},
	                {"Message", response.Entity.ErrorMessage},
	                {"PostOnline", response.Entity}};
                    return _dict;
                }
                return 0;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }


        [HttpPost]
        [AllowAnonymous]
        public object PostSaleReturnOnline(APIInventoryViewModel model)
        {
            try
            {
                APIInventoryViewModel _apiInventoryViewModel = new APIInventoryViewModel();
                var dictionary = new object();
                if (ModelState.IsValid && model != null)
                {
                    _apiInventoryViewModel.APIInventoryDTO = new APIInventory();
                    _apiInventoryViewModel.APIInventoryDTO.InvSaleReturnMasterXML = model.InvSaleReturnMasterXML;
                    _apiInventoryViewModel.APIInventoryDTO.InvSaleReturnTransactionXML = model.InvSaleReturnTransactionXML;
                    _apiInventoryViewModel.APIInventoryDTO.InvSaleReturnVoucherXML = model.InvSaleReturnVoucherXML;
                    _apiInventoryViewModel.APIInventoryDTO.CreatedBy = model.UserID;
                    _apiInventoryViewModel.APIInventoryDTO.ConnectionString = _connectioString;
                    IBaseEntityResponse<APIInventory> response = _apiInventoryServiceAccess.PostSaleReturnOnline(_apiInventoryViewModel.APIInventoryDTO);
                    //dictionary = (IDictionary<string, object>)response;  
                    Dictionary<string, object> _dict = new Dictionary<string, object>
                    {
	                {"StatusCode", response.Entity.Status},
	                {"Message", response.Entity.ErrorMessage},
	                {"PostOnline", response.Entity}};
                    return _dict;
                }
                return 0;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }


    }
}
