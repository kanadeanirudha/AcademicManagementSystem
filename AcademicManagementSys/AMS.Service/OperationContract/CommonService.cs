using AMS.Base.DTO;
using AMS.Business;
using AMS.ServiceAccess;
using AMS.DTO;
using AMS.ViewModel;
using AMS.ExceptionManager;
using AMS.Service.DataContract;
using AMS.Service.Enum;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Linq;
using System.Configuration;

namespace AMS.Service
{
    public class CommonService : ICommonService
    {

        private readonly ILogger _logException;
        InventoryWeighingDataServiceAccess _inventoryWeighingDataServiceAcess = null;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);


        public CommonService()
        {
            _inventoryWeighingDataServiceAcess = new InventoryWeighingDataServiceAccess();
            _logException = new ExceptionManager.ExceptionManager();
        }

        public InventoryWeighingDataResponseDTO SaveInventoryWeighingData(InventoryWeighingData item)
        {
            item.ConnectionString = _connectioString;
            InventoryWeighingDataResponseDTO response = new InventoryWeighingDataResponseDTO();
            IBaseEntityResponse<InventoryWeighingData> response1 = _inventoryWeighingDataServiceAcess.InsertInventoryWeighingData(item);
            IBaseEntityResponse<InventoryWeighingData> result = new BaseEntityResponse<InventoryWeighingData>();
            try
            {
                InventoryWeighingData InventoryWeighingData = new InventoryWeighingData();

                result = _inventoryWeighingDataServiceAcess.InsertInventoryWeighingData(item);

                if (response1.Entity != null)
                {
                    response.Status = "Success";
                    response.StatusCode = 200;
                }
                else
                {
                    response.Status = "Fail";
                    response.StatusCode = 100;
                }
                //   response.Message = result.StatusMessage;
            }
            catch (FaultException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                response.ErrorCode = ErrorCodeEnum.NotImplemented;
                response.ErrorDescription = ex.Message;
                _logException.Error(ex.Message);
            }
            finally
            {
            }
            return response;
        }


    }
}
