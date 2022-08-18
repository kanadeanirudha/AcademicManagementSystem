using AMS.Base.DTO;
using System;

namespace AMS.DTO
{
    public class UserDetailSearchRequest : Request
    {
        public string EmailID
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public string FirstName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public int Gender
        {
            get;
            set;
        }

        public DateTime DateOfBirth
        {
            get;
            set;
        }

        public bool IsActive
        {
            get;
            set;
        }
    }
}
