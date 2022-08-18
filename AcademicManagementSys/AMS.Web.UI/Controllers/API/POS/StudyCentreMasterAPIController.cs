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
    public class StudyCentreMasterAPIController : BaseApiController
    {
        private readonly ILogger _logException;
        IStudyCentreMasterServiceAccess _StudyCentreMasterAPIServiceAccess = null;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        public StudyCentreMasterAPIController()
        {
            _StudyCentreMasterAPIServiceAccess = new StudyCentreMasterServiceAccess();
        }
        [HttpPost]
        [AllowAnonymous]
        public object GetCentres(StudyCentreMasterViewModel model)
        {
            try
            {
                StudyCentreMasterSearchRequest searchRequest = new StudyCentreMasterSearchRequest();
                searchRequest.ConnectionString = _connectioString;
                searchRequest.LastSyncDate = model.LastSyncDate;
                searchRequest.DeviceCode = model.DeviceCode;
                IBaseEntityCollectionResponse<StudyCentreMaster> baseEntityCollectionResponse = _StudyCentreMasterAPIServiceAccess.GetStudyCentreMaster(searchRequest);
                List<StudyCentreMaster> StudyCentreMasterAPIList = new List<StudyCentreMaster>();
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        StudyCentreMasterAPIList = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }

                Dictionary<string, object> _dict = new Dictionary<string, object>
               {
                    {"StatusCode", "200"},
                    {"Message", "Study centre List retrived successfully."},
                    {"Data", StudyCentreMasterAPIList}};
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
