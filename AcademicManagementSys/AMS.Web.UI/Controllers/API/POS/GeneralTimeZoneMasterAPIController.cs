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
    public class GeneralTimeZoneMasterAPIController : BaseApiController
    {
        private readonly ILogger _logException;
        IGeneralTimeZoneMasterServiceAccess _GeneralTimeZoneMasterAPIServiceAccess = null;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        public GeneralTimeZoneMasterAPIController()
        {
            _GeneralTimeZoneMasterAPIServiceAccess = new GeneralTimeZoneMasterServiceAccess();
        }
        [HttpPost]
        [AllowAnonymous]
        public object GetTimeZone(GeneralTimeZoneMasterViewModel model)
        {
            try
            {
                GeneralTimeZoneMasterSearchRequest searchRequest = new GeneralTimeZoneMasterSearchRequest();
                searchRequest.ConnectionString = _connectioString;
                searchRequest.LastSyncDate = model.LastSyncDate;
                IBaseEntityCollectionResponse<GeneralTimeZoneMaster> baseEntityCollectionResponse = _GeneralTimeZoneMasterAPIServiceAccess.GetGeneralTimeZoneMaster(searchRequest);
                List<GeneralTimeZoneMaster> GeneralTimeZoneMasterAPIList = new List<GeneralTimeZoneMaster>();
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        GeneralTimeZoneMasterAPIList = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }

                Dictionary<string, object> _dict = new Dictionary<string, object>
               {
                    {"StatusCode", "200"},
                    {"Message", "Time zone List retrived successfully."},
                    {"Data", GeneralTimeZoneMasterAPIList}};
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
