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
    public class RestaurantKOTOrderDetailsController : BaseApiController
    {
        private readonly ILogger _logException;
        IRestaurantKOTOrderDetailsServiceAccess _RestaurantKOTOrderDetailsServiceAccess = null;

        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        public RestaurantKOTOrderDetailsController()
        {
            _RestaurantKOTOrderDetailsServiceAccess = new RestaurantKOTOrderDetailsServiceAccess();
        }

        [HttpPost]
        [AllowAnonymous]
        public object PostRestaurantKOTOrder(RestaurantKOTOrderDetailsViewModel model)
        {
            try
            {
                RestaurantKOTOrderDetailsViewModel _RestaurantKOTOrderDetailsViewModel = new RestaurantKOTOrderDetailsViewModel();
                var dictionary = new object();
                if (ModelState.IsValid && model != null)
                {
                    _RestaurantKOTOrderDetailsViewModel.RestaurantKOTOrderDetailsDTO = new RestaurantKOTOrderDetails();
                    _RestaurantKOTOrderDetailsViewModel.RestaurantKOTOrderDetailsDTO.KOTOrderXML = model.KOTOrderXML;
                    _RestaurantKOTOrderDetailsViewModel.RestaurantKOTOrderDetailsDTO.CreatedBy = model.CreatedBy;
                    _RestaurantKOTOrderDetailsViewModel.RestaurantKOTOrderDetailsDTO.ConnectionString = _connectioString;
                    IBaseEntityResponse<RestaurantKOTOrderDetails> response = _RestaurantKOTOrderDetailsServiceAccess.PostRestaurantKOTOrder(_RestaurantKOTOrderDetailsViewModel.RestaurantKOTOrderDetailsDTO);

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

        [HttpPost]
        [AllowAnonymous]
        public object GetRestaurantKOTOrder(RestaurantKOTOrderDetailsViewModel model)
        {
            try
            {
                RestaurantKOTOrderDetailsSearchRequest searchRequest = new RestaurantKOTOrderDetailsSearchRequest();
                searchRequest.ConnectionString = _connectioString;
                searchRequest.GeneralUnitsID = model.GeneralUnitsId;
                searchRequest.IsRelatedWithCafe = model.IsRelatedWithCafe;
                IBaseEntityCollectionResponse<RestaurantKOTOrderDetails> baseEntityCollectionResponse = _RestaurantKOTOrderDetailsServiceAccess.GetRestaurantKOTOrder(searchRequest);
                List<RestaurantKOTOrderDetails> RestaurantKOTOrderDetailsMasterList = new List<RestaurantKOTOrderDetails>();
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        RestaurantKOTOrderDetailsMasterList = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }

                int orderID = 0; string tableNumber = string.Empty; int j = 0; int i = 0; ;
                List<KotDetails> _data = new List<KotDetails>();                
                for (; i < RestaurantKOTOrderDetailsMasterList.Count;)
                {
                    orderID = RestaurantKOTOrderDetailsMasterList[i].ID;
                    tableNumber = RestaurantKOTOrderDetailsMasterList[i].TableNumber;
                    
                    List<RestaurantKOTOrderDetails> KotOrderDetailsList = new List<RestaurantKOTOrderDetails>();
                    KotDetails objData = new KotDetails();
                    for (;j < RestaurantKOTOrderDetailsMasterList.Count;)
                    {                       
                        if (orderID == RestaurantKOTOrderDetailsMasterList[j].ID)
                        {
                            RestaurantKOTOrderDetails objKotDetails = new RestaurantKOTOrderDetails();
                            objKotDetails.ID = RestaurantKOTOrderDetailsMasterList[j].ID;
                            objKotDetails.MenuName = RestaurantKOTOrderDetailsMasterList[j].MenuName ;
                            objKotDetails.ComplitedDateTime = RestaurantKOTOrderDetailsMasterList[j].ComplitedDateTime;
                            objKotDetails.CookById = RestaurantKOTOrderDetailsMasterList[j].CookById;
                            objKotDetails.CreatedBy = RestaurantKOTOrderDetailsMasterList[j].CreatedBy;
                            objKotDetails.CreatedDate = RestaurantKOTOrderDetailsMasterList[j].CreatedDate ;
                            objKotDetails.DeletedBy = RestaurantKOTOrderDetailsMasterList[j].DeletedBy;
                            objKotDetails.DeletedDate = RestaurantKOTOrderDetailsMasterList[j].DeletedDate ;
                            objKotDetails.ExpectedTimeForDelevery = RestaurantKOTOrderDetailsMasterList[j].ExpectedTimeForDelevery ;
                            objKotDetails.GeneralItemMasterID = RestaurantKOTOrderDetailsMasterList[j].GeneralItemMasterID;
                            objKotDetails.GeneralUnitsId = RestaurantKOTOrderDetailsMasterList[j].GeneralUnitsId;
                            objKotDetails.InventoryLocationMasterID = RestaurantKOTOrderDetailsMasterList[j].InventoryLocationMasterID;
                            objKotDetails.InventoryVariationMasterID = RestaurantKOTOrderDetailsMasterList[j].InventoryVariationMasterID;
                            objKotDetails.IsBOMRelevant = RestaurantKOTOrderDetailsMasterList[j].IsBOMRelevant;
                            objKotDetails.IsDeleted = RestaurantKOTOrderDetailsMasterList[j].IsDeleted;
                            objKotDetails.IsRelatedWithCafe = RestaurantKOTOrderDetailsMasterList[j].IsRelatedWithCafe;
                            objKotDetails.JobStatus = RestaurantKOTOrderDetailsMasterList[j].JobStatus;
                            objKotDetails.KOTOrderXML = RestaurantKOTOrderDetailsMasterList[j].KOTOrderXML ;
                            objKotDetails.ModifiedBy = RestaurantKOTOrderDetailsMasterList[j].ModifiedBy;
                            objKotDetails.ModifiedDate = RestaurantKOTOrderDetailsMasterList[j].ModifiedDate ;
                            objKotDetails.Price = RestaurantKOTOrderDetailsMasterList[j].Price;
                            objKotDetails.Qty = RestaurantKOTOrderDetailsMasterList[j].Qty;
                            objKotDetails.Remark = RestaurantKOTOrderDetailsMasterList[j].Remark;
                            objKotDetails.ResponseFlag = RestaurantKOTOrderDetailsMasterList[j].ResponseFlag;
                            objKotDetails.RestaurantKOTOrderDetailID = RestaurantKOTOrderDetailsMasterList[j].RestaurantKOTOrderDetailID;
                            objKotDetails.RestaurantKOTOrderDetailJobStatus = RestaurantKOTOrderDetailsMasterList[j].RestaurantKOTOrderDetailJobStatus;
                            objKotDetails.RestaurantKOTOrderDetailRestaurantKOTOrderID = RestaurantKOTOrderDetailsMasterList[j].RestaurantKOTOrderDetailRestaurantKOTOrderID;
                            objKotDetails.RestaurantKOTOrderDetailTransactionDate = RestaurantKOTOrderDetailsMasterList[j].RestaurantKOTOrderDetailTransactionDate ;
                            objKotDetails.RestaurantKOTOrderID = RestaurantKOTOrderDetailsMasterList[j].RestaurantKOTOrderID;
                            objKotDetails.RestaurantTableOrdersDetailID = RestaurantKOTOrderDetailsMasterList[j].RestaurantTableOrdersDetailID;
                            objKotDetails.RestaurantTableOrdersID = RestaurantKOTOrderDetailsMasterList[j].RestaurantTableOrdersID;
                            objKotDetails.TableNumber = RestaurantKOTOrderDetailsMasterList[j].TableNumber ;
                            objKotDetails.TransactionDate = RestaurantKOTOrderDetailsMasterList[j].TransactionDate ;
                            objKotDetails.UomCode = RestaurantKOTOrderDetailsMasterList[j].UomCode ;
                            objKotDetails.IsTakeAway = RestaurantKOTOrderDetailsMasterList[j].IsTakeAway;
                            objKotDetails.PaidBillNumber = RestaurantKOTOrderDetailsMasterList[j].PaidBillNumber;
                            KotOrderDetailsList.Add(objKotDetails);
                        }
                        else
                        {                            
                            break;
                        }
                       j++;
                        i = j;
                    }
                    objData.KotOrderID = orderID;
                    objData.TableNumber = tableNumber;
                    objData.KotDetailsList = KotOrderDetailsList;
                    _data.Add(objData);
               }


                Dictionary<string, object> _dict = new Dictionary<string, object>
                    {
                    {"StatusCode", "200"},
                    {"Message", "Restaurant KOT Order retrived successfully."},
                    {"GetOnline", _data}};
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
        public object GetCompleteKOTOrder(RestaurantKOTOrderDetailsViewModel model)
        {
            try
            {
                RestaurantKOTOrderDetailsSearchRequest searchRequest = new RestaurantKOTOrderDetailsSearchRequest();
                searchRequest.ConnectionString = _connectioString;
                searchRequest.FromDate = model.FromDate;
                searchRequest.UptoDate = model.UptoDate;
                searchRequest.StatusFlag = model.StatusFlag;
                searchRequest.GeneralUnitsID = model.GeneralUnitsId;
                IBaseEntityCollectionResponse<RestaurantKOTOrderDetails> baseEntityCollectionResponse = _RestaurantKOTOrderDetailsServiceAccess.GetCompleteKOTOrder(searchRequest);
                List<RestaurantKOTOrderDetails> RestaurantKOTOrderDetailsMasterList = new List<RestaurantKOTOrderDetails>();
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        RestaurantKOTOrderDetailsMasterList = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                int RestaurantorderID = 0; string LocalInvoiceNumber = string.Empty; int j = 0; int i = 0; ;
                List<KotDetails> _data = new List<KotDetails>();
                for (; i < RestaurantKOTOrderDetailsMasterList.Count; )
                {
                    RestaurantorderID = RestaurantKOTOrderDetailsMasterList[i].RestaurantTableOrdersID;
                    LocalInvoiceNumber = RestaurantKOTOrderDetailsMasterList[i].LocalInvoiceNumber;

                    List<RestaurantKOTOrderDetails> KotOrderDetailsList = new List<RestaurantKOTOrderDetails>();
                    KotDetails objData = new KotDetails();
                    for (; j < RestaurantKOTOrderDetailsMasterList.Count; )
                    {
                        if (RestaurantorderID == RestaurantKOTOrderDetailsMasterList[j].RestaurantTableOrdersID)
                        {
                            RestaurantKOTOrderDetails objKotDetails = new RestaurantKOTOrderDetails();
                            objKotDetails.ID = RestaurantKOTOrderDetailsMasterList[j].ID;
                            objKotDetails.MenuName = RestaurantKOTOrderDetailsMasterList[j].MenuName;
                            objKotDetails.ComplitedDateTime = RestaurantKOTOrderDetailsMasterList[j].ComplitedDateTime;
                            objKotDetails.CookById = RestaurantKOTOrderDetailsMasterList[j].CookById;
                            objKotDetails.CreatedBy = RestaurantKOTOrderDetailsMasterList[j].CreatedBy;
                            objKotDetails.CreatedDate = RestaurantKOTOrderDetailsMasterList[j].CreatedDate;
                            objKotDetails.DeletedBy = RestaurantKOTOrderDetailsMasterList[j].DeletedBy;
                            objKotDetails.DeletedDate = RestaurantKOTOrderDetailsMasterList[j].DeletedDate;
                            objKotDetails.ExpectedTimeForDelevery = RestaurantKOTOrderDetailsMasterList[j].ExpectedTimeForDelevery;
                            objKotDetails.GeneralItemMasterID = RestaurantKOTOrderDetailsMasterList[j].GeneralItemMasterID;
                            objKotDetails.GeneralUnitsId = RestaurantKOTOrderDetailsMasterList[j].GeneralUnitsId;
                            objKotDetails.InventoryLocationMasterID = RestaurantKOTOrderDetailsMasterList[j].InventoryLocationMasterID;
                            objKotDetails.InventoryVariationMasterID = RestaurantKOTOrderDetailsMasterList[j].InventoryVariationMasterID;
                            objKotDetails.IsBOMRelevant = RestaurantKOTOrderDetailsMasterList[j].IsBOMRelevant;
                            objKotDetails.IsDeleted = RestaurantKOTOrderDetailsMasterList[j].IsDeleted;
                            objKotDetails.IsRelatedWithCafe = RestaurantKOTOrderDetailsMasterList[j].IsRelatedWithCafe;
                            objKotDetails.JobStatus = RestaurantKOTOrderDetailsMasterList[j].JobStatus;
                            objKotDetails.KOTOrderXML = RestaurantKOTOrderDetailsMasterList[j].KOTOrderXML;
                            objKotDetails.ModifiedBy = RestaurantKOTOrderDetailsMasterList[j].ModifiedBy;
                            objKotDetails.ModifiedDate = RestaurantKOTOrderDetailsMasterList[j].ModifiedDate;
                            objKotDetails.Price = RestaurantKOTOrderDetailsMasterList[j].Price;
                            objKotDetails.Qty = RestaurantKOTOrderDetailsMasterList[j].Qty;
                            objKotDetails.Remark = RestaurantKOTOrderDetailsMasterList[j].Remark;
                            objKotDetails.ResponseFlag = RestaurantKOTOrderDetailsMasterList[j].ResponseFlag;
                            objKotDetails.RestaurantKOTOrderDetailID = RestaurantKOTOrderDetailsMasterList[j].RestaurantKOTOrderDetailID;
                            objKotDetails.RestaurantKOTOrderDetailJobStatus = RestaurantKOTOrderDetailsMasterList[j].RestaurantKOTOrderDetailJobStatus;
                            objKotDetails.RestaurantKOTOrderDetailRestaurantKOTOrderID = RestaurantKOTOrderDetailsMasterList[j].RestaurantKOTOrderDetailRestaurantKOTOrderID;
                            objKotDetails.RestaurantKOTOrderDetailTransactionDate = RestaurantKOTOrderDetailsMasterList[j].RestaurantKOTOrderDetailTransactionDate;
                            objKotDetails.RestaurantKOTOrderID = RestaurantKOTOrderDetailsMasterList[j].RestaurantKOTOrderID;
                            objKotDetails.RestaurantTableOrdersDetailID = RestaurantKOTOrderDetailsMasterList[j].RestaurantTableOrdersDetailID;
                            objKotDetails.RestaurantTableOrdersID = RestaurantKOTOrderDetailsMasterList[j].RestaurantTableOrdersID;
                            objKotDetails.TableNumber = RestaurantKOTOrderDetailsMasterList[j].TableNumber;
                            objKotDetails.TransactionDate = RestaurantKOTOrderDetailsMasterList[j].TransactionDate;
                            objKotDetails.UomCode = RestaurantKOTOrderDetailsMasterList[j].UomCode;
                            objKotDetails.IsTakeAway = RestaurantKOTOrderDetailsMasterList[j].IsTakeAway;
                            objKotDetails.PaidBillNumber = RestaurantKOTOrderDetailsMasterList[j].PaidBillNumber;

                            objKotDetails.RestaurantBillOrderdetailsID = RestaurantKOTOrderDetailsMasterList[j].RestaurantBillOrderdetailsID;
                            objKotDetails.SaleMasterID = RestaurantKOTOrderDetailsMasterList[j].SaleMasterID;
                            objKotDetails.LocalInvoiceNumber = RestaurantKOTOrderDetailsMasterList[j].LocalInvoiceNumber;
                            objKotDetails.RestaurantTableOrdersID = RestaurantKOTOrderDetailsMasterList[j].RestaurantTableOrdersID;
                            objKotDetails.ItemNumber = RestaurantKOTOrderDetailsMasterList[j].ItemNumber;
                            objKotDetails.Quantity = RestaurantKOTOrderDetailsMasterList[j].Quantity;
                            objKotDetails.Price = RestaurantKOTOrderDetailsMasterList[j].Price;
                            objKotDetails.UomCode = RestaurantKOTOrderDetailsMasterList[j].UomCode;
                            objKotDetails.ItemName = RestaurantKOTOrderDetailsMasterList[j].ItemName;
                            objKotDetails.InventoryVariationMasterID = RestaurantKOTOrderDetailsMasterList[j].InventoryVariationMasterID;
                            objKotDetails.SalePromotionActivityDetailsID = RestaurantKOTOrderDetailsMasterList[j].SalePromotionActivityDetailsID;
                            objKotDetails.GeneralUnitsId = RestaurantKOTOrderDetailsMasterList[j].GeneralUnitsId;
                            objKotDetails.IsRestaurant = RestaurantKOTOrderDetailsMasterList[j].IsRestaurant;
                            objKotDetails.IsRelatedWithCafe = RestaurantKOTOrderDetailsMasterList[j].IsRelatedWithCafe;

                            KotOrderDetailsList.Add(objKotDetails);
                        }
                        else
                        {
                            break;
                        }
                        j++;
                        i = j;
                    }
                    objData.RestaurantTableOrdersID = RestaurantorderID;
                    objData.LocalInvoiceNumber = LocalInvoiceNumber;
                    objData.KotDetailsList = KotOrderDetailsList;
                    _data.Add(objData);
                }

                Dictionary<string, object> _dict = new Dictionary<string, object>
                    {
                    {"StatusCode", "200"},
                    {"Message", "Restaurant KOT Order retrived successfully."},
                    {"GetOnline", _data}};
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
        public object GetInCompleteKOTOrder(RestaurantKOTOrderDetailsViewModel model)
        {
            try
            {
                RestaurantKOTOrderDetailsSearchRequest searchRequest = new RestaurantKOTOrderDetailsSearchRequest();
                searchRequest.ConnectionString = _connectioString;
                searchRequest.FromDate = model.FromDate;
                searchRequest.UptoDate = model.UptoDate;
                searchRequest.StatusFlag = model.StatusFlag;
                searchRequest.GeneralUnitsID = model.GeneralUnitsId;
                IBaseEntityCollectionResponse<RestaurantKOTOrderDetails> baseEntityCollectionResponse = _RestaurantKOTOrderDetailsServiceAccess.GetInCompleteKOTOrder(searchRequest);
                List<RestaurantKOTOrderDetails> RestaurantKOTOrderDetailsMasterList = new List<RestaurantKOTOrderDetails>();
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        RestaurantKOTOrderDetailsMasterList = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }

                Dictionary<string, object> _dict = new Dictionary<string, object>
                    {
                    {"StatusCode", "200"},
                    {"Message", "Incomplete KOT Order is retrived successfully."},
                    {"GetOnline", RestaurantKOTOrderDetailsMasterList}};
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
