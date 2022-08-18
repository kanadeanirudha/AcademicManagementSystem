using AMS.DTO;
using AMS.Service.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;


namespace AMS.Service
{
    [ServiceContract]
    public interface ICommonService
    {
      
        [OperationContract]
        [WebInvoke(UriTemplate = "/SaveInventoryWeighingData", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        InventoryWeighingDataResponseDTO SaveInventoryWeighingData(InventoryWeighingData item);

    }
}
