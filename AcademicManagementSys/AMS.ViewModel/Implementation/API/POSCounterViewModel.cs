using AMS.Common;
using AMS.DTO;
using System;
using System.ComponentModel.DataAnnotations;

namespace AMS.ViewModel
{
    public class POSCounterViewModel : IPOSCounterViewModel
    {
        
        public POSCounterViewModel()
        {
            POSCounterDTO = new POSCounter();
        }

        public POSCounter POSCounterDTO
        {
            get;
            set;
        }

        public int POSMasterID
        {
            get
            {
                return (POSCounterDTO != null && POSCounterDTO.POSMasterID > 0) ? POSCounterDTO.POSMasterID : new int();
            }
            set
            {
                POSCounterDTO.POSMasterID = value;
            }
        }

        public int UserID
        {
            get
            {
                return (POSCounterDTO != null) ? POSCounterDTO.UserID : new int();
            }
            set
            {
                POSCounterDTO.UserID = value;
            }
        }
        public string ErrorMessage
        {
            get
            {
                return POSCounterDTO.ErrorMessage;
            }
            set
            {
                POSCounterDTO.ErrorMessage = value;
            }
        }

        public int CounterMstID
        {
            get
            {
                return (POSCounterDTO != null) ? POSCounterDTO.CounterMstID : new int();
            }
            set
            {
                POSCounterDTO.CounterMstID = value;
            }
        }
    
        public string DeviceToken
        {
            get
            {
                return POSCounterDTO.DeviceToken;
            }
            set
            {
                POSCounterDTO.DeviceToken = value;
            }
        }

        
        public string LastSyncDate
        {
            get;
            set;
        }

        public int GeneralUnitsID
        {
            get
            {
                return (POSCounterDTO != null) ? POSCounterDTO.GeneralUnitsID : new int();
            }
            set
            {
                POSCounterDTO.GeneralUnitsID = value;
            }
        }

        public string InventoryPOSSelfAssignXML
        {
            get
            {
                return (POSCounterDTO != null) ? POSCounterDTO.InventoryPOSSelfAssignXML : string.Empty;
            }
            set
            {
                POSCounterDTO.InventoryPOSSelfAssignXML = value;
            }
        }

        public string InventoryCounterLogXML
        {
            get
            {
                return (POSCounterDTO != null) ? POSCounterDTO.InventoryCounterLogXML : string.Empty;
            }
            set
            {
                POSCounterDTO.InventoryCounterLogXML = value;
            }
        }
        public string UserLogXML
        {
            get
            {
                return (POSCounterDTO != null) ? POSCounterDTO.UserLogXML : string.Empty;
            }
            set
            {
                POSCounterDTO.UserLogXML = value;
            }
        }
        public string UserLogsXML
        {
            get
            {
                return (POSCounterDTO != null) ? POSCounterDTO.UserLogsXML : string.Empty;
            }
            set
            {
                POSCounterDTO.UserLogsXML = value;
            }
        }
    }
}
