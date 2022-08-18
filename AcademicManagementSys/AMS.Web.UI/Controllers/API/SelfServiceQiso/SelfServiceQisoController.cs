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
    public class SelfServiceQisoController : BaseApiController
    {
        private readonly ILogger _logException;
        ISelfServiceQisoServiceAccess _SelfServiceQisoServiceAccess = null;

        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        public SelfServiceQisoController()
        {
            _SelfServiceQisoServiceAccess = new SelfServiceQisoServiceAccess();
        }

        [HttpPost]
        [AllowAnonymous]
        public object PostTableOrder(SelfServiceQisoViewModel model)
        {
            try
            {
                SelfServiceQisoViewModel _SelfServiceQisoViewModel = new SelfServiceQisoViewModel();
                var dictionary = new object();
                if (ModelState.IsValid && model != null)
                {
                    _SelfServiceQisoViewModel.SelfServiceQisoDTO = new SelfServiceQiso();
                    _SelfServiceQisoViewModel.SelfServiceQisoDTO.ID = model.ID;
                    _SelfServiceQisoViewModel.SelfServiceQisoDTO.CentreCode = model.CentreCode;
                    _SelfServiceQisoViewModel.SelfServiceQisoDTO.TableNumber = model.TableNumber;
                    _SelfServiceQisoViewModel.SelfServiceQisoDTO.OrderXML = model.OrderXML;
                    _SelfServiceQisoViewModel.SelfServiceQisoDTO.PaymentReferenceCode = model.PaymentReferenceCode;
                    _SelfServiceQisoViewModel.SelfServiceQisoDTO.IsTakeAway = model.IsTakeAway;
                    _SelfServiceQisoViewModel.SelfServiceQisoDTO.PaidBillNumber = model.PaidBillNumber;
                    _SelfServiceQisoViewModel.SelfServiceQisoDTO.TotalBillAmount = model.TotalBillAmount;
                    _SelfServiceQisoViewModel.SelfServiceQisoDTO.CreatedBy = model.CreatedBy;
                    _SelfServiceQisoViewModel.SelfServiceQisoDTO.ConnectionString = _connectioString;
                    IBaseEntityResponse<SelfServiceQiso> response = _SelfServiceQisoServiceAccess.PostTableOrder(_SelfServiceQisoViewModel.SelfServiceQisoDTO);
                    //dictionary = (IDictionary<string, object>)response;  
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
        public object RestaurantSettleBillPost(SelfServiceQisoViewModel model)
        {
            try
            {
                var dictionary = new object();
                if (ModelState.IsValid && model != null)
                {

                    model.SelfServiceQisoDTO.RestaurantTableOrderID = model.RestaurantTableOrderID;
                    model.SelfServiceQisoDTO.IsBillPaid = model.IsBillPaid;
                    model.SelfServiceQisoDTO.InventorySaleMasterID = model.InventorySaleMasterID; 
                    model.SelfServiceQisoDTO.CentreCode = model.CentreCode;
                    model.SelfServiceQisoDTO.GeneralUnitsID = model.GeneralUnitsID;
                    model.SelfServiceQisoDTO.CounterID = model.CounterID;
                    model.SelfServiceQisoDTO.TotalDiscountAmount = model.TotalDiscountAmount;
                    model.SelfServiceQisoDTO.TotalTaxAmount = model.TotalTaxAmount;
                    model.SelfServiceQisoDTO.NetAmount = model.NetAmount;
                    model.SelfServiceQisoDTO.BillAmount = model.BillAmount;
                    model.SelfServiceQisoDTO.ReturnChange = model.ReturnChange;
                    model.SelfServiceQisoDTO.PaymentByCustomer = model.PaymentByCustomer;
                    model.SelfServiceQisoDTO.RoundUpAmount = model.RoundUpAmount;
                    model.SelfServiceQisoDTO.PaymentMode = model.PaymentMode;
                    model.SelfServiceQisoDTO.Customer = model.Customer;
                    model.SelfServiceQisoDTO.CustomerCode = model.CustomerCode;
                    model.SelfServiceQisoDTO.BillNumber = model.BillNumber;
                    model.SelfServiceQisoDTO.IsAvailableForPOS = model.IsAvailableForPOS;
                    model.SelfServiceQisoDTO.SaleTransactionXML = model.SaleTransactionXML;
                    model.SelfServiceQisoDTO.CreatedBy = model.CreatedBy;
                    model.SelfServiceQisoDTO.ConnectionString = _connectioString;
                    IBaseEntityResponse<SelfServiceQiso> response = _SelfServiceQisoServiceAccess.RestaurantSettleBillPost(model.SelfServiceQisoDTO);
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
    }
}
