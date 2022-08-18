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
    public class GeneralCounterPOSApllicableController : BaseApiController
    {
        private readonly ILogger _logException;
        IGeneralCounterPOSApllicableServiceAccess _GeneralCounterPOSApllicableServiceAccess = null;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        public GeneralCounterPOSApllicableController()
        {
            _GeneralCounterPOSApllicableServiceAccess = new GeneralCounterPOSApllicableServiceAccess();
        }
        [HttpPost]
        [AllowAnonymous]
        public object GetGeneralCounterPOSApllicable(GeneralCounterPOSApllicableViewModel model)
        {
            try
            {
                GeneralCounterPOSApllicableSearchRequest searchRequest = new GeneralCounterPOSApllicableSearchRequest();
                searchRequest.ConnectionString = _connectioString;
                searchRequest.LastSyncDate = model.LastSyncDate;
                searchRequest.DeviceCode = model.DeviceCode;                
                IBaseEntityCollectionResponse<GeneralCounterPOSApllicable> baseEntityCollectionResponse = _GeneralCounterPOSApllicableServiceAccess.GetGeneralCounterPOSApllicable(searchRequest);
                List<GeneralCounterPOSApllicable> GeneralCounterPOSApllicableList = new List<GeneralCounterPOSApllicable>();
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        GeneralCounterPOSApllicableList = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }

                    Dictionary<string, object> _dict = new Dictionary<string, object>
               {
                    {"StatusCode", "200"},
                    {"Message", "POS allocation List retrived successfully."},
                    {"Data", GeneralCounterPOSApllicableList}};
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
        public object PostPOSSelfAssignData(GeneralCounterPOSApllicableViewModel model)
        {
            try
            {
                GeneralCounterPOSApllicableViewModel _generalCounterPOSApllicableViewModel = new GeneralCounterPOSApllicableViewModel();
                var dictionary = new object();
                if (ModelState.IsValid && model != null)
                {
                    _generalCounterPOSApllicableViewModel.GeneralCounterPOSApllicableDTO = new GeneralCounterPOSApllicable();
                    _generalCounterPOSApllicableViewModel.GeneralCounterPOSApllicableDTO.InventoryAllocatePosOperatorXML = model.InventoryAllocatePosOperatorXML;
                    _generalCounterPOSApllicableViewModel.GeneralCounterPOSApllicableDTO.InventoryCounterLogXML = model.InventoryCounterLogXML;
                    _generalCounterPOSApllicableViewModel.GeneralCounterPOSApllicableDTO.ConnectionString = _connectioString;
                    IBaseEntityResponse<GeneralCounterPOSApllicable> response = _GeneralCounterPOSApllicableServiceAccess.PostPOSSelfAssignData(_generalCounterPOSApllicableViewModel.GeneralCounterPOSApllicableDTO);
                    
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
        public object CheckPOSSelfAssignDataCount(GeneralCounterPOSApllicableViewModel model)
        {
            try
            {
                GeneralCounterPOSApllicableViewModel _generalCounterPOSApllicableViewModel = new GeneralCounterPOSApllicableViewModel();
                var dictionary = new object();
                if (ModelState.IsValid && model != null)
                {
                    _generalCounterPOSApllicableViewModel.GeneralCounterPOSApllicableDTO = new GeneralCounterPOSApllicable();
                    _generalCounterPOSApllicableViewModel.GeneralCounterPOSApllicableDTO.ConnectionString = _connectioString;
                    IBaseEntityResponse<GeneralCounterPOSApllicable> response = _GeneralCounterPOSApllicableServiceAccess.CheckPOSSelfAssignDataCount(_generalCounterPOSApllicableViewModel.GeneralCounterPOSApllicableDTO);

                    Dictionary<string, object> _dict = new Dictionary<string, object>
                    {
                    {"StatusCode", response.Entity.ErrorCode},
                    {"Message", response.Entity.ErrorMessage},
                    {"IsDataAvailable", response.Entity.IsDataAvailable}};
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
