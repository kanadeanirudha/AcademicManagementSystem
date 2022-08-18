using AMS.Base.DTO;
using AMS.ExceptionManager;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Data.Mapping;
using System.Web.Http;
using AMS.ServiceAccess;
using AMS.ViewModel;
using AMS.DTO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
namespace AMS.Web.UI.Controllers.API
{
    public class PurchaseGRNController : BaseApiController
    {
        private readonly ILogger _logException;
        IPurchaseGRNServiceAccess _PurchaseGRNServiceAccess = null;

        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        public PurchaseGRNController()
        {
            _PurchaseGRNServiceAccess = new PurchaseGRNServiceAccess();
        }
        //----------------------------------Post GRN------------------------------
        [HttpPost]
        [AllowAnonymous]
        public object PostPurchaseGRN(PurchaseGRNViewModel model)
        {
            try
            {
                PurchaseGRNViewModel _PurchaseGRNViewModel = new PurchaseGRNViewModel();
                var dictionary = new object();
                if (ModelState.IsValid && model != null)
                {
                    _PurchaseGRNViewModel.PurchaseGRNDTO = new PurchaseGRN();
                    _PurchaseGRNViewModel.PurchaseGRNDTO.PurchaseOrderMasterID = model.PurchaseOrderMasterID;
                    _PurchaseGRNViewModel.PurchaseGRNDTO.GRNTransDate = model.GRNTransDate;
                    _PurchaseGRNViewModel.PurchaseGRNDTO.IsLocked = model.IsLocked;
                    _PurchaseGRNViewModel.PurchaseGRNDTO.XMLstring = model.XMLstring;
                    _PurchaseGRNViewModel.PurchaseGRNDTO.CreatedBy = model.CreatedBy;
                    _PurchaseGRNViewModel.PurchaseGRNDTO.ConnectionString = _connectioString;
                    IBaseEntityResponse<PurchaseGRN> response = _PurchaseGRNServiceAccess.PostPurchaseGRN(_PurchaseGRNViewModel.PurchaseGRNDTO);

                    Dictionary<string, object> _dict = new Dictionary<string, object>
                    {{"StatusCode", response.Entity.ErrorCode},
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
        //-----------------------------------FOR VENDOR SEARCH LIST-----------------------------
        [HttpPost]
        [AllowAnonymous]
        public object GetPurchaseGRNVendorSearchList(PurchaseGRNViewModel model)
        {
            try
            {
                PurchaseGRNSearchRequest searchRequest = new PurchaseGRNSearchRequest();
                searchRequest.ConnectionString = _connectioString;
                searchRequest.SearchWord = model.SearchWord;
                IBaseEntityCollectionResponse<PurchaseGRN> baseEntityCollectionResponse = _PurchaseGRNServiceAccess.GetPurchaseGRNVendorList(searchRequest);
                List<PurchaseGRN> PurchaseGRNList = new List<PurchaseGRN>();
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        PurchaseGRNList = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }

                Dictionary<string, object> _dict = new Dictionary<string, object>
                    {
                    {"StatusCode", "200"},
                    {"Message", "GRN List retrieved successfully."},
                    {"GetOnline", PurchaseGRNList}};
                return _dict;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        //------------------------------------------FOR SELECTALL PO LIST --------------------------------------
        [HttpPost]
        [AllowAnonymous]
        public object GetPurchaseGRNPOList(PurchaseGRNViewModel model)
        {
            try
            {
                PurchaseGRNSearchRequest searchRequest = new PurchaseGRNSearchRequest();
                searchRequest.ConnectionString = _connectioString;
                searchRequest.StartRow = model.StartRow;
                searchRequest.EndRow = model.EndRow;
                searchRequest.VendorName = model.VendorName;
                searchRequest.POStatus = model.POStatus;
                IBaseEntityCollectionResponse<PurchaseGRN> baseEntityCollectionResponse = _PurchaseGRNServiceAccess.GetPurchaseGRNPOList(searchRequest);
                List<PurchaseGRN> PurchaseGRNList = new List<PurchaseGRN>();
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        PurchaseGRNList = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }

                Dictionary<string, object> _dict = new Dictionary<string, object>
                    {
                    {"StatusCode", "200"},
                    {"Message", "Purchase Order List retrieved successfully."},
                    {"GetOnline", PurchaseGRNList}};
                return _dict;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        //--------------------------------------------------------FOR PO LIST---------------------------------------

        [HttpPost]
        [AllowAnonymous]
        public object GetPOList(PurchaseGRNViewModel model)
        {
            try
            {
                PurchaseGRNSearchRequest searchRequest = new PurchaseGRNSearchRequest();
                searchRequest.ConnectionString = _connectioString;
                searchRequest.StartRow = model.StartRow;
                searchRequest.EndRow = model.EndRow;
                searchRequest.VendorName = model.VendorName;
                searchRequest.POStatus = model.POStatus;
                IBaseEntityCollectionResponse<PurchaseGRN> baseEntityCollectionResponse = _PurchaseGRNServiceAccess.GetPOList(searchRequest);
                List<PurchaseGRN> PurchaseGRNList = new List<PurchaseGRN>();
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        PurchaseGRNList = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }

                Dictionary<string, object> _dict = new Dictionary<string, object>
                    {
                    {"StatusCode", "200"},
                    {"Message", "Purchase Order List retrieved successfully."},
                    {"GetOnline", PurchaseGRNList}};
                return _dict;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
//---------------------------------------------FOR GRN LIST-------------------------------------

        [HttpPost]
        [AllowAnonymous]
        public object GetGRNList(PurchaseGRNViewModel model)
        {
            try
            {
                PurchaseGRNSearchRequest searchRequest = new PurchaseGRNSearchRequest();
                searchRequest.ConnectionString = _connectioString;
                searchRequest.PurchaseOrderMasterID = model.PurchaseOrderMasterID;
                IBaseEntityCollectionResponse<PurchaseGRN> baseEntityCollectionResponse = _PurchaseGRNServiceAccess.GetGRNList(searchRequest);
                List<PurchaseGRN> PurchaseGRNList = new List<PurchaseGRN>();
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        PurchaseGRNList = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }

                Dictionary<string, object> _dict = new Dictionary<string, object>
                    {
                    {"StatusCode", "200"},
                    {"Message", "Purchase Order List retrieved successfully."},
                    {"GetOnline", PurchaseGRNList}};
                return _dict;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
 //--------------------------------------------- FOR VIEW GRN LIST--------------------------------------
        [HttpPost]
        [AllowAnonymous]
        public object GetPurchaseGRNView(PurchaseGRNViewModel model)
        {
            try
            {
                PurchaseGRNSearchRequest searchRequest = new PurchaseGRNSearchRequest();
                searchRequest.ConnectionString = _connectioString;
                searchRequest.PurchaseGRNMasterID = model.PurchaseGRNMasterID;
                searchRequest.PurchaseOrderMasterID = model.PurchaseOrderMasterID;
                IBaseEntityCollectionResponse<PurchaseGRN> baseEntityCollectionResponse = _PurchaseGRNServiceAccess.GetPurchaseGRNView(searchRequest);
                List<PurchaseGRN> PurchaseGRNList = new List<PurchaseGRN>();
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        PurchaseGRNList = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }

                Dictionary<string, object> _dict = new Dictionary<string, object>
                    {
                    {"StatusCode", "200"},
                    {"Message", "Purchase Order List retrieved successfully."},
                    {"GetOnline", PurchaseGRNList}};
                return _dict;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
//-----------------------------------------------Batch Search List--------------------------------------------
        [HttpPost]
        [AllowAnonymous]
        public object GetPurchaseGRNBatchList(PurchaseGRNViewModel model)
        {
            try
            {
                PurchaseGRNSearchRequest searchRequest = new PurchaseGRNSearchRequest();
                searchRequest.ConnectionString = _connectioString;
                searchRequest.SearchWord = model.SearchWord;
                searchRequest.ItemNumber = model.ItemNumber;
                IBaseEntityCollectionResponse<PurchaseGRN> baseEntityCollectionResponse = _PurchaseGRNServiceAccess.GetPurchaseGRNBatchList(searchRequest);
                List<PurchaseGRN> PurchaseGRNList = new List<PurchaseGRN>();
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        PurchaseGRNList = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }

                Dictionary<string, object> _dict = new Dictionary<string, object>
                    {
                    {"StatusCode", "200"},
                    {"Message", "Purchase Order List retrieved successfully."},
                    {"GetOnline", PurchaseGRNList}};
                return _dict;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        //---------------------------------FOR ITEM LIST ------------------------------------------
        [HttpPost]
        [AllowAnonymous]
        public object GetPurchaseOrderItemList(PurchaseGRNViewModel model)
        {
            try
            {
                PurchaseGRNSearchRequest searchRequest = new PurchaseGRNSearchRequest();
                searchRequest.ConnectionString = _connectioString;
                searchRequest.PurchaseOrderMasterID = model.PurchaseOrderMasterID;
                IBaseEntityCollectionResponse<PurchaseGRN> baseEntityCollectionResponse = _PurchaseGRNServiceAccess.GetPurchaseOrderItemList(searchRequest);
                List<PurchaseGRN> PurchaseGRNList = new List<PurchaseGRN>();
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        PurchaseGRNList = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }

                Dictionary<string, object> _dict = new Dictionary<string, object>
                    {
                    {"StatusCode", "200"},
                    {"Message", "Purchase Order List retrieved successfully."},
                    {"GetOnline", PurchaseGRNList}};
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
