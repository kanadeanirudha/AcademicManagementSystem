using AMS.Base.DTO;
using System;

namespace AMS.DTO
{
    public class FishFishermenMaster : BaseDTO
    {
        public int ID { get; set; }
        public string FishermenCode { get; set; }
        public int NameTitleID { get; set; }
        public string FirstName { get; set;  }
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
        public string BirthDate { get; set; }
        public int NationalityID { get; set; }
        public string PanNumber { get; set; }
        public string AdharCardNumber { get; set; }
        public string BankName { get; set; }
        public string BankNumber { get; set; }
        public string CentreCode { get; set; }
        //public int DepartmentID { get; set; }
        public string  JoiningDate { get; set; }
        public string DateOfLeaving { get; set; }
        public int BioMatrixID { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<DateTime> DeletedDate { get; set; }


        ///////////////////////////Additional fields/////////////////////////////////////////////

        public string CentreName { get; set; }
        
        //public int AdminRoleMasterID { get; set; }
        public int UserID { get; set; }
        public int Status { get; set; }
       
    }
}
