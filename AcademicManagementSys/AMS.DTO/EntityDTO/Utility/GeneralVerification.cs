using AMS.Base.DTO;
using System;

namespace AMS.DTO
{
    public class GeneralVerification : BaseDTO
    {
       
        public string VerificationString
        {
            get;
            set;
        }
        public bool Status 
        {
            get;
            set;
        }

    }
}
