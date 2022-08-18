using AMS.Base.DTO;
using AMS.ExceptionManager;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Http;
using AMS.ServiceAccess;
using AMS.ViewModel;
using AMS.DTO;
namespace AMS.Web.UI.Controllers.API
{
    public class RestaurantSettleAndPrintBillController : BaseApiController
    {
        private readonly ILogger _logException;
        IRestaurantSettleAndPrintBillServiceAccess _RestaurantSettleAndPrintBillServiceAccess = null;

        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        public RestaurantSettleAndPrintBillController()
        {
            _RestaurantSettleAndPrintBillServiceAccess = new RestaurantSettleAndPrintBillServiceAccess();
        }

        [HttpPost]
        [AllowAnonymous]
        public object GetRestaurantPrintBill(RestaurantSettleAndPrintBillViewModel model)
        {
            try
            {
                RestaurantSettleAndPrintBillSearchRequest searchRequest = new RestaurantSettleAndPrintBillSearchRequest();
                searchRequest.ConnectionString = _connectioString;
                searchRequest.GeneralUnitsID = model.GeneralUnitsID;
                searchRequest.BillNumber = model.BillNumber;
                IBaseEntityCollectionResponse<RestaurantSettleAndPrintBill> baseEntityCollectionResponse = _RestaurantSettleAndPrintBillServiceAccess.GetRestaurantPrintBill(searchRequest);
                List<RestaurantSettleAndPrintBill> RestaurantSettleAndPrintBillMasterList = new List<RestaurantSettleAndPrintBill>();
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        RestaurantSettleAndPrintBillMasterList = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }

                Dictionary<string, object> _dict = new Dictionary<string, object>
                    {
                    {"StatusCode", "200"},
                    {"Message", "Print Bill is retrived successfully."},
                    {"GetOnline", RestaurantSettleAndPrintBillMasterList}};
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
        public object RestaurantSettleBillPost(RestaurantSettleAndPrintBillViewModel model)
        {
            try
            {
                RestaurantSettleAndPrintBillViewModel _RestaurantSettleAndPrintBillViewModel = new RestaurantSettleAndPrintBillViewModel();
                var dictionary = new object();
                if (model != null)
                {
                  
                    model.RestaurantSettleAndPrintBillDTO.RestaurantTableOrderID = model.RestaurantTableOrderID;
                    model.RestaurantSettleAndPrintBillDTO.CentreCode = model.CentreCode;
                    model.RestaurantSettleAndPrintBillDTO.GeneralUnitsID = model.GeneralUnitsID;
                    model.RestaurantSettleAndPrintBillDTO.CounterID = model.CounterID;
                    model.RestaurantSettleAndPrintBillDTO.TotalDiscountAmount = model.TotalDiscountAmount;
                    model.RestaurantSettleAndPrintBillDTO.TotalTaxAmount = model.TotalTaxAmount;
                    model.RestaurantSettleAndPrintBillDTO.NetAmount = model.NetAmount;
                    model.RestaurantSettleAndPrintBillDTO.BillAmount = model.BillAmount;
                    model.RestaurantSettleAndPrintBillDTO.ReturnChange = model.ReturnChange;
                    model.RestaurantSettleAndPrintBillDTO.PaymentByCustomer = model.PaymentByCustomer;
                    model.RestaurantSettleAndPrintBillDTO.RoundUpAmount = model.RoundUpAmount;
                    model.RestaurantSettleAndPrintBillDTO.PaymentMode = model.PaymentMode;
                    model.RestaurantSettleAndPrintBillDTO.Customer = model.Customer;
                    model.RestaurantSettleAndPrintBillDTO.CustomerCode = model.CustomerCode;
                    model.RestaurantSettleAndPrintBillDTO.CreatedBy = model.CreatedBy;
                    model.RestaurantSettleAndPrintBillDTO.BillNumber = model.BillNumber;
                    model.RestaurantSettleAndPrintBillDTO.SalePromotionActivityDetailsID = model.SalePromotionActivityDetailsID;
                    model.RestaurantSettleAndPrintBillDTO.ConnectionString = _connectioString;
                    IBaseEntityResponse<RestaurantSettleAndPrintBill> response = _RestaurantSettleAndPrintBillServiceAccess.RestaurantSettleBillPost(model.RestaurantSettleAndPrintBillDTO);
                    Dictionary<string, object> _dict = new Dictionary<string, object>
                    {
                    {"StatusCode", response.Entity.ErrorCode},
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
        public object GetRestaurantBillList(RestaurantSettleAndPrintBillViewModel model)
        {
            try
            {

                RestaurantSettleAndPrintBillSearchRequest searchRequest = new RestaurantSettleAndPrintBillSearchRequest();
                searchRequest.ConnectionString = _connectioString;
                searchRequest.GeneralUnitsID = model.GeneralUnitsID;
                searchRequest.PaidUnpaidFlag = model.PaidUnpaidFlag;
                searchRequest.CounterID = model.CounterID;

                IBaseEntityCollectionResponse<RestaurantSettleAndPrintBill> baseEntityCollectionResponse = _RestaurantSettleAndPrintBillServiceAccess.GetRestaurantBillList(searchRequest);
                List<RestaurantSettleAndPrintBill> RestaurantBillList = new List<RestaurantSettleAndPrintBill>();
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        RestaurantBillList = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }

                int orderID = 0; string billNumber = string.Empty; int inventorySaleMasterID = 0; string tableNumber = string.Empty; int j = 0; int i = 0; 

       
                List<BillDetails> _data = new List<BillDetails>();
                for (; i < RestaurantBillList.Count; )
                {
                    orderID = RestaurantBillList[i].RestaurantTableOrderID;
                    billNumber = RestaurantBillList[i].GlobalInvoiceNumber;
                    inventorySaleMasterID = RestaurantBillList[i].ID;
                    tableNumber = RestaurantBillList[i].TableNumber;

                    List<RestaurantSettleAndPrintBill> BillDetailsList = new List<RestaurantSettleAndPrintBill>();
                    BillDetails objData = new BillDetails();
                    for (; j < RestaurantBillList.Count; )
                    {
                        if (orderID == RestaurantBillList[j].RestaurantTableOrderID)
                        {
                            RestaurantSettleAndPrintBill objBillDetails = new RestaurantSettleAndPrintBill();
                            objBillDetails.ID = RestaurantBillList[j].ID;
                            objBillDetails.SaleTransactionID = RestaurantBillList[j].SaleTransactionID;
                            objBillDetails.GlobalInvoiceNumber = RestaurantBillList[j].GlobalInvoiceNumber;
                            objBillDetails.LocalInvoiceNumber = RestaurantBillList[j].LocalInvoiceNumber;
                            objBillDetails.TransactionDate = RestaurantBillList[j].TransactionDate;
                            objBillDetails.BillAmount = RestaurantBillList[j].BillAmount;
                            objBillDetails.NetAmount = RestaurantBillList[j].NetAmount;
                            objBillDetails.DeliveryCharge = RestaurantBillList[j].DeliveryCharge;
                            objBillDetails.TotalTaxAmount = RestaurantBillList[j].TotalTaxAmount;
                            objBillDetails.TotalDiscountAmount = RestaurantBillList[j].TotalDiscountAmount;
                            objBillDetails.CounterID = RestaurantBillList[j].CounterID;
                            objBillDetails.RoundUpAmount = RestaurantBillList[j].RoundUpAmount;
                            objBillDetails.GeneralUnitsID = RestaurantBillList[j].GeneralUnitsID;
                            objBillDetails.Customer = RestaurantBillList[j].Customer;
                            objBillDetails.PaymentMode = RestaurantBillList[j].PaymentMode;
                            objBillDetails.BillRelevantTo = RestaurantBillList[j].BillRelevantTo;
                            objBillDetails.TransactionNumber = RestaurantBillList[j].TransactionNumber;
                            objBillDetails.IsPaid = RestaurantBillList[j].IsPaid;
                            objBillDetails.IsAvailableForPOS = RestaurantBillList[j].IsAvailableForPOS; 
                            objBillDetails.ItemNumber = RestaurantBillList[j].ItemNumber;
                            objBillDetails.GeneralItemCodeID = RestaurantBillList[j].GeneralItemCodeID;
                            objBillDetails.TaxAmount = RestaurantBillList[j].TaxAmount;
                            objBillDetails.DiscountAmount = RestaurantBillList[j].DiscountAmount;
                            objBillDetails.DiscountInPercentage = RestaurantBillList[j].DiscountInPercentage;
                            objBillDetails.TaxInPercentage = RestaurantBillList[j].TaxInPercentage;
                            objBillDetails.Quantity = RestaurantBillList[j].Quantity;
                            objBillDetails.GenTaxGroupMasterID = RestaurantBillList[j].GenTaxGroupMasterID;
                            objBillDetails.Price = RestaurantBillList[j].Price;
                            objBillDetails.BatchNumber = RestaurantBillList[j].BatchNumber;
                            objBillDetails.ExpiryDate = RestaurantBillList[j].ExpiryDate;
                            objBillDetails.UOMCode = RestaurantBillList[j].UOMCode;
                            objBillDetails.ItemName = RestaurantBillList[j].ItemName;
                            objBillDetails.VariationMasterId = RestaurantBillList[j].VariationMasterId;
                            objBillDetails.RestaurantTableOrderID = RestaurantBillList[j].RestaurantTableOrderID;
                            objBillDetails.TableNumber = RestaurantBillList[j].TableNumber;
                            objBillDetails.DiscountInPercent = RestaurantBillList[j].DiscountInPercent;
                            objBillDetails.SalePromotionActivityDetailsID = RestaurantBillList[j].SalePromotionActivityDetailsID;
                            objBillDetails.PromotionActivityFlag = RestaurantBillList[j].PromotionActivityFlag;
                            objBillDetails.IsRestaurant = RestaurantBillList[j].IsRestaurant;
                            BillDetailsList.Add(objBillDetails);
                        }
                        else
                        {
                            break;
                        }
                        j++;
                        i = j;
                    }
                    objData.RestaurantTableOrderID = orderID;
                    objData.BillNumber = billNumber;
                    objData.InventorySaleMasterID = inventorySaleMasterID;
                    objData.TableNumber = tableNumber;
                    objData.BillDetailsList = BillDetailsList;
                    _data.Add(objData);
                }
                Dictionary<string, object> _dict = new Dictionary<string, object>
                    {
                    {"StatusCode", "200"},
                    {"Message", "Restaurant Bill List is retrived successfully."},
                    {"GetOnline", _data}};

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