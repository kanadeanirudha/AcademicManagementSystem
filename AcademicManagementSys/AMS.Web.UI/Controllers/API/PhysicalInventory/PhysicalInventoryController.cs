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
    public class PhysicalInventoryController : BaseApiController
    {
        private readonly ILogger _logException;
        IPhysicalInventoryServiceAccess _PhysicalInventoryServiceAccess = null;

        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        public PhysicalInventoryController()
        {
            _PhysicalInventoryServiceAccess = new PhysicalInventoryServiceAccess();
        }

        [HttpPost]
        [AllowAnonymous]
        public object PostPhysicalInventory(PhysicalInventoryViewModel model)
        {
            try
            {
                PhysicalInventoryViewModel _PhysicalInventoryViewModel = new PhysicalInventoryViewModel();
                var dictionary = new object();
                if (ModelState.IsValid && model != null)
                {
                    _PhysicalInventoryViewModel.PhysicalInventoryDTO = new PhysicalInventory();
                    _PhysicalInventoryViewModel.PhysicalInventoryDTO.TransactionDate = model.TransactionDate;
                    _PhysicalInventoryViewModel.PhysicalInventoryDTO.GeneralUnitsID = model.GeneralUnitsID;
                    _PhysicalInventoryViewModel.PhysicalInventoryDTO.PhysicalInventoryStockDetails = model.PhysicalInventoryStockDetails;
                    _PhysicalInventoryViewModel.PhysicalInventoryDTO.PhysicalInventoryVoucherXml = model.PhysicalInventoryVoucherXml;
                    _PhysicalInventoryViewModel.PhysicalInventoryDTO.ActionStatus = model.ActionStatus;
                    _PhysicalInventoryViewModel.PhysicalInventoryDTO.CreatedBy = model.CreatedBy;
                    _PhysicalInventoryViewModel.PhysicalInventoryDTO.ConnectionString = _connectioString;
                    IBaseEntityResponse<PhysicalInventory> response = _PhysicalInventoryServiceAccess.PostPhysicalInventory(_PhysicalInventoryViewModel.PhysicalInventoryDTO);

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
        public object GetPhysicalInventory(PhysicalInventoryViewModel model)
        {
            try
            {
                PhysicalInventorySearchRequest searchRequest = new PhysicalInventorySearchRequest();
                searchRequest.ConnectionString = _connectioString;
                searchRequest.GeneralUnitsID = model.GeneralUnitsID;
                searchRequest.ItemBarCode = model.ItemBarCode;
            
                IBaseEntityCollectionResponse<PhysicalInventory> baseEntityCollectionResponse = _PhysicalInventoryServiceAccess.GetPhysicalInventory(searchRequest);
                List<PhysicalInventory> PhysicalInventoryrList = new List<PhysicalInventory>();
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        PhysicalInventoryrList = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }

                Dictionary<string, object> _dict = new Dictionary<string, object>
                    {
                    {"StatusCode", "200"},
                    {"Message", "Stock retrieved successfully."},
                    {"GetOnline", PhysicalInventoryrList}};
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
