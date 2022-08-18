using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class FishFishermenMasterViewModel : IFishFishermenMasterViewModel
    {
        public FishFishermenMasterViewModel()
        {
            FishFishermenMasterDTO = new FishFishermenMaster();
            ListGetAdminRoleApplicableCentre =new List <AdminRoleApplicableDetails>();
        }

        public FishFishermenMaster FishFishermenMasterDTO { get; set; }

        public List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
        }

        public IEnumerable<SelectListItem> ListGetAdminRoleApplicableCentreItems
        {
            get
            {
                return new SelectList(ListGetAdminRoleApplicableCentre, "CentreCode", "CentreName");
            }
        }


        public int ID
        {
            get
            {
                return (FishFishermenMasterDTO != null && FishFishermenMasterDTO.ID > 0) ? FishFishermenMasterDTO.ID : new int();
            }
            set
            {
                FishFishermenMasterDTO.ID = value;
            }
        }

        [Display(Name = "Fishermen Code")]
        [Required(ErrorMessage = "Fishermen code should not be blank.")]
        public string FishermenCode
        {
            get
            {
                return FishFishermenMasterDTO != null ? FishFishermenMasterDTO.FishermenCode : string.Empty;
            }
            set
            {
               FishFishermenMasterDTO.FishermenCode = value;
            }
        }

        [Display(Name="Name Title")]
        [Required(ErrorMessage= "Name title id should not be blank.")]
        public int NameTitleID
        {
            get
            {
                return (FishFishermenMasterDTO != null && FishFishermenMasterDTO.NameTitleID > 0) ? FishFishermenMasterDTO.NameTitleID : new int();
            }
            set
            {
                FishFishermenMasterDTO.NameTitleID = value;
            }
        }

        [Display(Name="First name")]
        [Required(ErrorMessage="First name should not be blank.")]
        public string FirstName
        {
            get
            {
                return FishFishermenMasterDTO.FirstName != null ? FishFishermenMasterDTO.FirstName : string.Empty;
            }
            set
            {
                FishFishermenMasterDTO.FirstName = value;
            }
        }


        [Display(Name="Middle name")]
        [Required(ErrorMessage="Middle name should not be blank.")]
        public string MiddleName
        {
            get
            {
                return FishFishermenMasterDTO.MiddleName != null ? FishFishermenMasterDTO.MiddleName : string.Empty;
            }
            set
            {
                FishFishermenMasterDTO.MiddleName = value;
            }
        }

        [Display(Name="Last name")]
        [Required(ErrorMessage="Last name should not be blank.")]
        public string LastName
        {
            get
            {
                return FishFishermenMasterDTO.LastName != null ? FishFishermenMasterDTO.LastName : string.Empty;
            }
            set
            {
                FishFishermenMasterDTO.LastName = value;
            }
        }

        [Required(ErrorMessage="Address should not be blank.")]
        public string Address
        {
            get
            {
                return FishFishermenMasterDTO.Address != null ? FishFishermenMasterDTO.Address : string.Empty;
            }
            set
            {
                FishFishermenMasterDTO.Address = value;
            }
        }

        [Display(Name="Postal address")]
        [Required(ErrorMessage = "Postal address should not be blank")]
        public string PostalAddress
        {
            get
            {
                return FishFishermenMasterDTO.PostalAddress != null ? FishFishermenMasterDTO.PostalAddress : string.Empty;
            }
            set
            {
                FishFishermenMasterDTO.PostalAddress = value;
            }
        }

        [Display(Name="Mobile number")]
        [Required(ErrorMessage =" Mobile number should not be blank.")]
        public string MobileNumber
        {
            get
            {
                return FishFishermenMasterDTO.MobileNumber != null ? FishFishermenMasterDTO.MobileNumber : string.Empty;
            }
            set
            {
                FishFishermenMasterDTO.MobileNumber = value;
            }
        }

        [Display(Name="Email id")]
        [Required(ErrorMessage="Email id should not be blank.")]
        public string EmailID
        {
            get
            {
                return FishFishermenMasterDTO.EmailID != null ? FishFishermenMasterDTO.EmailID : string.Empty;
            }
            set
            {
                FishFishermenMasterDTO.EmailID = value;
            }
        }

        [Display(Name = "Is Local Member")]
        [Required(ErrorMessage = " Is local member should not blank.")]
        public bool IsLocalMember
        {
            get
            {
                return FishFishermenMasterDTO.IsLocalMember != null ? FishFishermenMasterDTO.IsLocalMember : false;
            }
            set
            {
                FishFishermenMasterDTO.IsLocalMember = value;
            }
        }

        [Display(Name="Local member id")]
        [Required(ErrorMessage = "Local member id should not blank.")]
        public int LocalMemberId
        {
            get
            {
                return FishFishermenMasterDTO.LocalMemberId != null ? FishFishermenMasterDTO.LocalMemberId : new int();
            }
            set
            {
                FishFishermenMasterDTO.LocalMemberId = value;
            }
        }

        [Display(Name="Is federation member")]
        [Required(ErrorMessage = "Is federation member should not blank.")]
        public bool IsFederationMember
        {
            get
            {
                return FishFishermenMasterDTO.IsFederationMember != null ? FishFishermenMasterDTO.IsFederationMember : false;
            }
            set
            {
                FishFishermenMasterDTO.IsFederationMember = value;
            }
        }

        [Display(Name="Federation member id")]
        [Required(ErrorMessage = "Federation member id should not blank.")]
        public int FederationMemberId
        {
            get
            {
                return FishFishermenMasterDTO.FederationMemberId != null ? FishFishermenMasterDTO.FederationMemberId : new int();
            }
            set
            {
                FishFishermenMasterDTO.FederationMemberId = value;
            }
        }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Gender should not blank.")]
        public string Gender
        {
            get
            {
                return FishFishermenMasterDTO.Gender != null ? FishFishermenMasterDTO.Gender : string.Empty;
            }
            set
            {
                FishFishermenMasterDTO.Gender = value;
            }
        }

        
        [Display(Name = "BirthDate")]
        [Required(ErrorMessage = "BirthDate should not blank.")]
        public string BirthDate
        {
            get
            {
                return FishFishermenMasterDTO.BirthDate != null ? FishFishermenMasterDTO.BirthDate : string.Empty;
            }
            set
            {
                FishFishermenMasterDTO.BirthDate = value;
            }
        }

        [Display(Name = "Nationality id")]
        [Required(ErrorMessage = "Nationality id should not blank.")]
        public int NationalityID
        {
            get
            {
                return FishFishermenMasterDTO.NationalityID != null ? FishFishermenMasterDTO.NationalityID : new int();
            }
            set
            {
                FishFishermenMasterDTO.NationalityID = value;
            }
        }

        [Display(Name = "Pan number")]
        [Required(ErrorMessage = "Pan number should not blank.")]
        public string PanNumber
        {
            get
            {
                return FishFishermenMasterDTO.PanNumber != null ? FishFishermenMasterDTO.PanNumber : string.Empty;
            }
            set
            {
                FishFishermenMasterDTO.PanNumber = value;
            }
        }

        [Display(Name = "AdharCard number")]
        [Required(ErrorMessage = "Adhar card number should not blank.")]
        public string AdharCardNumber
        {
            get
            {
                return FishFishermenMasterDTO.AdharCardNumber != null ? FishFishermenMasterDTO.AdharCardNumber : string.Empty;
            }
            set
            {
                FishFishermenMasterDTO.AdharCardNumber = value;
            }
        }

        [Display(Name = "Bank name")]
        [Required(ErrorMessage = "Bank name should not blank.")]
        public string BankName
        {
            get
            {
                return FishFishermenMasterDTO.BankName != null ? FishFishermenMasterDTO.BankName : string.Empty;
            }
            set
            {
                FishFishermenMasterDTO.BankName = value;
            }
        }

        [Display(Name = "Bank number")]
        [Required(ErrorMessage = "Bank number should not blank.")]
        public string BankNumber
        {
            get
            {
                return FishFishermenMasterDTO.BankNumber != null ? FishFishermenMasterDTO.BankNumber : string.Empty;
            }
            set
            {
                FishFishermenMasterDTO.BankNumber = value;
            }
        }

        [Display(Name = "Centre code")]
        [Required(ErrorMessage = "Centre code should not blank.")]
        public string CentreCode
        {
            get
            {
                return FishFishermenMasterDTO.CentreCode != null ? FishFishermenMasterDTO.CentreCode : string.Empty;
            }
            set
            {
                FishFishermenMasterDTO.CentreCode = value;
            }
        }

        //[Display(Name = "Department id")]
        //[Required(ErrorMessage = "Department id should not blank.")]
        //public int DepartmentID
        //{
        //    get
        //    {
        //        return FishFishermenMasterDTO.DepartmentID != null ? FishFishermenMasterDTO.DepartmentID : new int();
        //    }
        //    set
        //    {
        //        FishFishermenMasterDTO.DepartmentID = value;
        //    }
        //}

        [Display(Name = "Joining Date")]
        [Required(ErrorMessage = "JoiningDate should not blank.")]
        public string  JoiningDate
        {
            get
            {
                return FishFishermenMasterDTO.JoiningDate != null ? FishFishermenMasterDTO.JoiningDate : string .Empty;
            }
            set
            {
                FishFishermenMasterDTO.JoiningDate = value;
            }
        }

        [Display(Name = "Date Of Leaving")]
        [Required(ErrorMessage = "Date Of Leaving should not blank.")]
        public string DateOfLeaving
        {
            get
            {
                return FishFishermenMasterDTO.DateOfLeaving != null ? FishFishermenMasterDTO.DateOfLeaving : string.Empty;
            }
            set
            {
                FishFishermenMasterDTO.DateOfLeaving = value;
            }
        }

        [Display(Name = "BioMatrix ID")]
        [Required(ErrorMessage = "BioMatrix id should not blank.")]
        public int BioMatrixID
        {
            get
            {
                return FishFishermenMasterDTO.BioMatrixID != null ? FishFishermenMasterDTO.BioMatrixID : new int();
            }
            set
            {
                FishFishermenMasterDTO.BioMatrixID = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return FishFishermenMasterDTO.IsDeleted != null ? FishFishermenMasterDTO.IsDeleted : false;
            }
            set
            {
                FishFishermenMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (FishFishermenMasterDTO.CreatedBy != null && FishFishermenMasterDTO.CreatedBy > 0) ? FishFishermenMasterDTO.CreatedBy : new int();
            }
            set
            {
                FishFishermenMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (FishFishermenMasterDTO.CreatedDate != null) ? FishFishermenMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                FishFishermenMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public Nullable<int> ModifiedBy
        {
            get
            {
                return FishFishermenMasterDTO.ModifiedBy != null ? FishFishermenMasterDTO.ModifiedBy : new int();
            }
            set
            {
                FishFishermenMasterDTO.ModifiedBy = value;
            }
        }

        public Nullable<DateTime> ModifiedDate
        {
            get
            {
                return (FishFishermenMasterDTO.ModifiedDate != null && FishFishermenMasterDTO.ModifiedDate.HasValue) ? FishFishermenMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                FishFishermenMasterDTO.ModifiedDate = value;
            }
        }
        [Display(Name = "Delete By")]
        public Nullable<int> DeletedBy
        {
            get
            {
                return (FishFishermenMasterDTO != null && FishFishermenMasterDTO.DeletedBy > 0) ? FishFishermenMasterDTO.DeletedBy : new int();
            }
            set
            {
                FishFishermenMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "Delete Date")]
        public Nullable<DateTime> DeletedDate
        {
            get
            {
                return (FishFishermenMasterDTO.DeletedDate != null && FishFishermenMasterDTO.DeletedDate.HasValue) ? FishFishermenMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                FishFishermenMasterDTO.DeletedDate = value;
            }
        }

        public string CentreName
        {
            get
            {
                return (FishFishermenMasterDTO != null) ? FishFishermenMasterDTO.CentreName : string.Empty;
            }
            set
            {
                FishFishermenMasterDTO.CentreName = value;
            }
        }

        //public string EntityLevel
        //{
        //    get
        //    {
        //        return (FishFishermenMasterDTO != null) ? FishFishermenMasterDTO.EntityLevel : string.Empty;
        //    }
        //    set
        //    {
        //        FishFishermenMasterDTO.EntityLevel = value;
        //    }
        //}

    }
}
