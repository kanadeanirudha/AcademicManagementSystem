using AMS.DTO;
using AMS.Service.Enum;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AMS.Service.DataContract
{
    [DataContract]
    public class InventoryWeighingDataResponseDTO
    {
      
        [DataMember]
        public string Status
        {
            get;
            set;
        }

        [DataMember]
        public int StatusCode
        {
            get;
            set;
        }

        [DataMember]
        public string Message
        {
            get;
            set;
        }

        [DataMember]
        public InventoryWeighingData Response
        {
            get;
            set;
        }

        [DataMember]
        public List<UserMaster> ListResponse
        {
            get;
            set;
        }

        [DataMember]
        public ErrorCodeEnum ErrorCode
        {
            get;
            set;
        }

        [DataMember]
        public string ErrorDescription
        {
            get;
            set;
        }
    }
}
