using AMS.Base.DTO;
using System;

namespace AMS.DTO
{
    public class FishFishermenMasterSearchRequest : Request
    {
        public int ID { get; set; }
        public string FishermenCode { get; set; }
        public int NameTitleID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PostalAddress { get; set; }
        public string MobileNumber { get; set; }
        public string EmailID { get; set; }
        public bool IsLocalMember { get; set; }
        public int LocalMemberId { get; set; }
        public bool IsFederationMember { get; set; }
        public int FederationMemberId { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public int NationalityID { get; set; }
        public string PanNumber { get; set; }
        public string AdharCardNumber { get; set; }
        public string BankName { get; set; }
        public string BankNumber { get; set; }
        public string CentreCode { get; set; }
        //public int DepartmentID { get; set; }
        public DateTime JoiningDate { get; set; }
        public DateTime DateOfLeaving { get; set; }
        public int BioMatrixID { get; set; }
        public string SortOrder { get; set; }
        public string SortBy { get; set; }
        public int StartRow { get; set; }
        public int RowLength { get; set; }
        public int EndRow { get; set; }


        public string SearchBy { get; set; }
        public string SortDirection { get; set; }
        
        //public string AdminRoleMasterID { get; set; } 
    }
}
