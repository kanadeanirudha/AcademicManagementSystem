using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface ICRMCallMasterAndDetailsViewModel
    {
        CRMCallMasterAndDetails CRMCallMasterAndDetailsDTO
        {
            get;
            set;
        }
      
    }
}
