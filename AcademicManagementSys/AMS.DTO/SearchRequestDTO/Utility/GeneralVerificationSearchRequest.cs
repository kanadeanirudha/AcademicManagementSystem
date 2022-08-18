using AMS.Base.DTO;
using System;

namespace AMS.DTO
{
    public class GeneralVerificationSearchRequest : Request
    {
        public string VerificationString
        {
            get;
            set;
        }

    }
}
