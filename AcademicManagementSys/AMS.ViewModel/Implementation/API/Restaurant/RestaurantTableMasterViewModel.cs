using AMS.Common;
using AMS.DTO;
using System;
using System.ComponentModel.DataAnnotations;

namespace AMS.ViewModel
{
    public class RestaurantTableMasterViewModel : IRestaurantTableMasterViewModel
    {
        public RestaurantTableMasterViewModel()
        {
            RestaurantTableMasterDTO = new RestaurantTableMaster();
        }

        public RestaurantTableMaster RestaurantTableMasterDTO
        {
            get;
            set;
        }



        public Int16 ID
        {
            
            get
            {
                return (RestaurantTableMasterDTO != null && RestaurantTableMasterDTO.ID > 0) ? RestaurantTableMasterDTO.ID : new Int16();
            }
            set
            {
                RestaurantTableMasterDTO.ID = value;
            }

        }

        public string TableName
        {
            get
            {
                return (RestaurantTableMasterDTO != null && RestaurantTableMasterDTO.TableName != null) ? RestaurantTableMasterDTO.TableName : String.Empty;
            }
            set
            {
                RestaurantTableMasterDTO.TableName = value;
            }
        }
        public string TableCode
        {
            get
            {
                return (RestaurantTableMasterDTO != null && RestaurantTableMasterDTO.TableCode != null) ? RestaurantTableMasterDTO.TableCode : String.Empty;
            }
            set
            {
                RestaurantTableMasterDTO.TableCode = value;
            }
        }
        public short Shape
        {
            get
            {
                return (RestaurantTableMasterDTO != null && RestaurantTableMasterDTO.Shape > 0) ? RestaurantTableMasterDTO.Shape : new short();
            }
            set
            {
                RestaurantTableMasterDTO.Shape = value;
            }
        }
        [Display(Name = "Maximum Capacity")]
        public Int16 MaxCapicity
        {
            get
            {
                return (RestaurantTableMasterDTO != null) ? RestaurantTableMasterDTO.MinCapacity : new Int16();
            }
            set
            {
                RestaurantTableMasterDTO.MaxCapicity = value;
            }
        }
         [Display(Name = "Minimum Capacity")]
        public Int16 MinCapacity
        {
            get
            {
                return (RestaurantTableMasterDTO != null) ? RestaurantTableMasterDTO.MinCapacity : new Int16();
                
            }
            set
            {
                RestaurantTableMasterDTO.MinCapacity = value;
            }
        }
        public bool IsActive
        {
            get
            {
                return (RestaurantTableMasterDTO != null ) ? RestaurantTableMasterDTO.IsActive : false;
            }
            set
            {
                RestaurantTableMasterDTO.IsActive = value;
            }
        }

        public int GeneralUnitsID
        {

            get
            {
                return (RestaurantTableMasterDTO != null && RestaurantTableMasterDTO.GeneralUnitsID > 0) ? RestaurantTableMasterDTO.GeneralUnitsID : new int();
            }
            set
            {
                RestaurantTableMasterDTO.GeneralUnitsID = value;
            }

        }
        


        //public int CreatedBy
        //{
        //    get
        //    {
        //        return (RestaurantTableMasterDTO != null) ? RestaurantTableMasterDTO.CreatedBy : new int();
        //    }
        //    set
        //    {
        //        RestaurantTableMasterDTO.CreatedBy = value;
        //    }
        //}
        //public int Status
        //{
        //    get
        //    {
        //        return (RestaurantTableMasterDTO != null) ? RestaurantTableMasterDTO.Status : new int();
        //    }
        //    set
        //    {
        //        RestaurantTableMasterDTO.Status = value;
        //    }
        //}
        public string ErrorMessage
        {
            get
            {
                return RestaurantTableMasterDTO.ErrorMessage;
            }
            set
            {
                RestaurantTableMasterDTO.ErrorMessage = value;
            }
        }
          [Required(ErrorMessage = "Table Name should not be blank.")]
        [Display(Name = "Table Name")]
        public string Name
        {
            get
            {
                return (RestaurantTableMasterDTO != null) ? RestaurantTableMasterDTO.Name : String.Empty;
            }
            set
            {
                RestaurantTableMasterDTO.Name = value;
            }
        }
          [Required(ErrorMessage = "Table Number should not be blank.")]  
        [Display(Name = "Table Number")]
        public string TableNumber
        {
            get
            {
                return (RestaurantTableMasterDTO != null) ? RestaurantTableMasterDTO.TableNumber : String.Empty;
            }
            set
            {
                RestaurantTableMasterDTO.TableNumber = value;
            }
        }
        

        //Common fields
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (RestaurantTableMasterDTO != null) ? RestaurantTableMasterDTO.IsDeleted : false;
            }
            set
            {
                RestaurantTableMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (RestaurantTableMasterDTO != null && RestaurantTableMasterDTO.CreatedBy > 0) ? RestaurantTableMasterDTO.CreatedBy : new int();
            }
            set
            {
                RestaurantTableMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (RestaurantTableMasterDTO != null) ? RestaurantTableMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                RestaurantTableMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (RestaurantTableMasterDTO != null) ? RestaurantTableMasterDTO.ModifiedBy : new int();
            }
            set
            {
                RestaurantTableMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (RestaurantTableMasterDTO != null) ? RestaurantTableMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                RestaurantTableMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (RestaurantTableMasterDTO != null) ? RestaurantTableMasterDTO.DeletedBy : new int();
            }
            set
            {
                RestaurantTableMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (RestaurantTableMasterDTO != null) ? RestaurantTableMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                RestaurantTableMasterDTO.DeletedDate = value;
            }
        }

    }
}
