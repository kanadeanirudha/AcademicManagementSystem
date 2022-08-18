using AMS.Base.DTO;
using System;

namespace AMS.DTO
{
    public class CheckTabRegistration : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }

        public string DeviceToken
        {
            get;
            set;
        }
        public Int16 UnitsID
        {
            get;
            set;
        }
    }
}
