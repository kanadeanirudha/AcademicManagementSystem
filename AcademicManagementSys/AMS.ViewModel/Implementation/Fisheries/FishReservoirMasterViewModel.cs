using AMS.Common;
using AMS.DTO;
using System;
using System.ComponentModel.DataAnnotations;

namespace AMS.ViewModel
{
    public class FishReservoirMasterViewModel : IFishReservoirMasterViewModel
    {
        public FishReservoirMasterViewModel()
        {
            FishReservoirMasterDTO = new FishReservoirMaster();
        }

        public FishReservoirMaster FishReservoirMasterDTO { get; set; }

        public int ID
        {
            get
            {
                return (FishReservoirMasterDTO != null && FishReservoirMasterDTO.ID > 0) ? FishReservoirMasterDTO.ID : new int();
            }
            set
            {
                FishReservoirMasterDTO.ID = value;
            }
        }

        [Display(Name = "Reservoir Name")]
        [Required(ErrorMessage = "Reservoir Name should not be blank.")]
        public string ReservoirName
        {
            get
            {
                return FishReservoirMasterDTO.ReservoirName != null ? FishReservoirMasterDTO.ReservoirName : string.Empty;
            }
            set
            {
                FishReservoirMasterDTO.ReservoirName = value;
            }
        }

        [Display(Name = "Reservoir Code")]
        [Required(ErrorMessage = "Reservoir Code should not be blank.")]
        public string ReservoirCode
        {
            get
            {
                return FishReservoirMasterDTO.ReservoirCode != null ? FishReservoirMasterDTO.ReservoirCode : string.Empty;
            }
            set
            {
                FishReservoirMasterDTO.ReservoirCode = value;
            }
        }


        [Required(ErrorMessage = "Address should not be blank.")]
        public string Address
        {
            get
            {
                return FishReservoirMasterDTO != null ? FishReservoirMasterDTO.Address : string.Empty;
            }
            set
            {
                FishReservoirMasterDTO.Address = value;
            }
        }

        [Display(Name = "Location Id")]
        public int LocationId
        {
            get
            {
                return (FishReservoirMasterDTO != null && FishReservoirMasterDTO.LocationId > 0) ? FishReservoirMasterDTO.LocationId : new int();
            }
            set
            {
                FishReservoirMasterDTO.LocationId = value;
            }
        }

        [Required(ErrorMessage = "Latitude should not be blank.")]
        public decimal Latitude
        {
            get
            {
                return FishReservoirMasterDTO != null ? FishReservoirMasterDTO.Latitude : new decimal();
            }
            set
            {
                FishReservoirMasterDTO.Latitude = value;
            }
        }

        [Required(ErrorMessage = "Logitude should not be blank.")]
        public decimal Logitude
        {
            get
            {
                return (FishReservoirMasterDTO != null) ? FishReservoirMasterDTO.Logitude :new decimal();
            }
            set
            {
                FishReservoirMasterDTO.Logitude = value;
            }
        }

        [Required(ErrorMessage = "Area should not be blank.")]
        public decimal Area
        {
            get
            {
                return FishReservoirMasterDTO != null ? FishReservoirMasterDTO.Area : new decimal();
            }
            set
            {
                FishReservoirMasterDTO.Area = value;
            }
        }

        [Required(ErrorMessage = "Capacity should not be blank.")]
        public decimal Capacity
        {
            get
            {
                return FishReservoirMasterDTO != null ? FishReservoirMasterDTO.Capacity : new decimal(); 
            }
            set
            {
                FishReservoirMasterDTO.Capacity = value;
            }
        }

        [Display(Name = "Minimum Product Capacity")]
        [Required(ErrorMessage = "Minimun Product Capacity should not be blank.")]
        public decimal MinProductCapacity
        {
            get
            {
                return FishReservoirMasterDTO != null ? FishReservoirMasterDTO.MinProductCapacity : new decimal();
            }
            set
            {
                FishReservoirMasterDTO.MinProductCapacity = value;
            }
        }

        public bool IsDeleted
        {
            get
            {
                return FishReservoirMasterDTO.IsDeleted != null ? FishReservoirMasterDTO.IsDeleted : false;
            }
            set
            {
                FishReservoirMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy By")]
        public Nullable<int> CreatedBy
        {
            get
            {
                return (FishReservoirMasterDTO != null && FishReservoirMasterDTO.CreatedBy > 0) ? FishReservoirMasterDTO.CreatedBy : new int(); 
            }
            set
            {
                FishReservoirMasterDTO.CreatedBy = value;
            }
        }
                
        public DateTime CreatedDate
        {
            get
            {
                return (FishReservoirMasterDTO.CreatedDate != null) ? FishReservoirMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                FishReservoirMasterDTO.CreatedDate = value;
            }
        }

        public Nullable<int> ModifiedBy
        {
            get
            {
                return (FishReservoirMasterDTO != null && FishReservoirMasterDTO.ModifiedBy > 0) ? FishReservoirMasterDTO.ModifiedBy : new int(); 
            }
            set
            {
                FishReservoirMasterDTO.ModifiedBy = value;
            }
        }

        public Nullable<DateTime> ModifiedDate
        {
            get
            {
                return (FishReservoirMasterDTO.ModifiedDate != null && FishReservoirMasterDTO.ModifiedDate.HasValue) ? FishReservoirMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                FishReservoirMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "Delete By")]
        public Nullable<int> DeletedBy
        {
            get
            {
                return (FishReservoirMasterDTO != null && FishReservoirMasterDTO.DeletedBy > 0) ? FishReservoirMasterDTO.DeletedBy : new int();
            }
            set
            {
                FishReservoirMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "Delete Date")]
        public Nullable<DateTime> DeletedDate
        {
            get
            {
                return (FishReservoirMasterDTO.DeletedDate != null && FishReservoirMasterDTO.DeletedDate.HasValue) ? FishReservoirMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                FishReservoirMasterDTO.DeletedDate = value;
            }
        }

        public int BalancesheetID
        {
            get
            {
                return (FishReservoirMasterDTO != null && FishReservoirMasterDTO.BalancesheetID > 0) ? FishReservoirMasterDTO.BalancesheetID : new int();
            }
            set
            {
                FishReservoirMasterDTO.BalancesheetID = value;
            }
        }

        public string BalancesheetName
        {
            get
            {
                return FishReservoirMasterDTO != null ? FishReservoirMasterDTO.BalancesheetName : string.Empty;
            }
            set
            {
                FishReservoirMasterDTO.BalancesheetName = value;
            }
        }

    }
}
