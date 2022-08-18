using AMS.Common;
using AMS.DTO;
using System;
using System.ComponentModel.DataAnnotations;

namespace AMS.ViewModel
{
    public class CheckTabRegistrationViewModel : ICheckTabRegistrationViewModel
    {
        public CheckTabRegistrationViewModel()
        {
            CheckTabRegistrationDTO = new CheckTabRegistration();
        }

        public CheckTabRegistration CheckTabRegistrationDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (CheckTabRegistrationDTO != null && CheckTabRegistrationDTO.ID > 0) ? CheckTabRegistrationDTO.ID : new int();
            }
            set
            {
                CheckTabRegistrationDTO.ID = value;
            }
        }
        public string DeviceToken
        {
            get
            {
                return CheckTabRegistrationDTO.DeviceToken;
            }
            set
            {
                CheckTabRegistrationDTO.DeviceToken = value;
            }
        }
        
        public string ErrorMessage
        {
            get
            {
                return CheckTabRegistrationDTO.ErrorMessage;
            }
            set
            {
                CheckTabRegistrationDTO.ErrorMessage = value;
            }
        }



    }
}
