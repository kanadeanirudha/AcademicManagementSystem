using AMS.DTO;
using System;

namespace AMS.ViewModel
{
    public interface IStudentLoginViewModel
    {

        StudentLogin StudentLoginDTO
        {
            get;
            set;
        }

        int ID
        {
            get;
            set;
        }
        string EmailID
        {
            get;
            set;
        }
        string Password
        {
            get;
            set;
        }
        bool RememberMe
        {
            get;
            set;
        }
      
    }
    public interface IStudentLoginBaseViewModel
    {


    }
}
