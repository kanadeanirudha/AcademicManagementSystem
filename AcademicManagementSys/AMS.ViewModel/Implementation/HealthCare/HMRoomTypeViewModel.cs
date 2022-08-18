using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class HMRoomTypeViewModel : IHMRoomTypeViewModel
    {

        public HMRoomTypeViewModel()
        {
            HMRoomTypeDTO = new HMRoomType();
        }
      
        public HMRoomType HMRoomTypeDTO
        {
            get;
            set;
        }

        public Int16  ID
        {
            get
            {
                return (HMRoomTypeDTO != null) ? HMRoomTypeDTO.ID : new Int16();
            }
            set
            {
                HMRoomTypeDTO.ID = value;
            }
        }
        [Required(ErrorMessage = "Please Select Room Type")]
        [Display(Name = "Room Type")]
        public string RoomType
        {
            get
            {
                return (HMRoomTypeDTO != null) ? HMRoomTypeDTO.RoomType : string.Empty;
            }
            set
            {
                HMRoomTypeDTO.RoomType = value;
            }
        }

       
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (HMRoomTypeDTO != null) ? HMRoomTypeDTO.IsDeleted : false;
            }
            set
            {
                HMRoomTypeDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (HMRoomTypeDTO != null && HMRoomTypeDTO.CreatedBy > 0) ? HMRoomTypeDTO.CreatedBy : new int();
            }
            set
            {
                HMRoomTypeDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (HMRoomTypeDTO != null) ? HMRoomTypeDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                HMRoomTypeDTO.CreatedDate = value;
            }
        }


        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (HMRoomTypeDTO != null) ? HMRoomTypeDTO.ModifiedBy : new int();
            }
            set
            {
                HMRoomTypeDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (HMRoomTypeDTO != null) ? HMRoomTypeDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                HMRoomTypeDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (HMRoomTypeDTO != null) ? HMRoomTypeDTO.DeletedBy : new int();
            }
            set
            {
                HMRoomTypeDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (HMRoomTypeDTO != null) ? HMRoomTypeDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                HMRoomTypeDTO.DeletedDate = value;
            }
        }
        public string errorMessage { get; set; }
    }
}

