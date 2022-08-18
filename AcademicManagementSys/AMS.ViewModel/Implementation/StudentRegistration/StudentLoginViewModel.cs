using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace AMS.ViewModel
{
    public class StudentLoginBaseViewModel : IStudentLoginBaseViewModel
    {
        public StudentLoginBaseViewModel()
        {

        }

        public StudentLogin StudentLoginDTO
        {
            get;
            set;
        }


    }
    public class StudentLoginViewModel : IStudentLoginViewModel
    {

        public StudentLoginViewModel()
        {
            StudentLoginDTO = new StudentLogin();
        }

        public StudentLogin StudentLoginDTO { get; set; }
       

        public int ID
        {
            get
            {
                return (StudentLoginDTO != null && StudentLoginDTO.ID > 0) ? StudentLoginDTO.ID : new int();
            }
            set
            {
                StudentLoginDTO.ID = value;
            }
        }

        [Required(ErrorMessage = "Email Address is required")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "EmailID")]
        [RegularExpression("^([a-zA-Z0-9_\\-\\.]+)@[a-z0-9-]+(\\.[a-z0-9-]+)*(\\.[a-z]{2,3})$", ErrorMessage = "Please enter your email address in the format someone@example.com.")]
        public string EmailID
        {
            get
            {
                return (StudentLoginDTO != null) ? StudentLoginDTO.EmailID : string.Empty;
            }
            set
            {
                StudentLoginDTO.EmailID = value;
            }
        }
        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Password")]
        public string Password
        {
            get
            {
                return (StudentLoginDTO != null) ? StudentLoginDTO.Password : string.Empty;
            }
            set
            {
                StudentLoginDTO.Password = value;
            }
        }


        public bool RememberMe
        {
            get
            {
                return (StudentLoginDTO != null) ? StudentLoginDTO.RememberMe : false;
            }
            set
            {
                StudentLoginDTO.RememberMe = value;
            }
        }


    }
}
