using AMS.Base.DTO;
using System;

namespace AMS.DTO
{
    public class GeneralCronJob : BaseDTO
    {
       
        public string CentreCode
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
