using AMS.Base.DTO;
using System;

namespace AMS.DTO
{
    public class GeneralCronJobSearchRequest : Request
    {
        public string CentreCode
        {
            get;
            set;
        }

    }
}
