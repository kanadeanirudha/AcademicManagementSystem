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
    public class HMComfirtTypeViewModel : IHMComfirtTypeVewModel
    {

        public HMComfirtTypeViewModel()
        {
            HMComfirtTypeDTO = new HMComfirtType();
        }
      
        public HMComfirtType HMComfirtTypeDTO
        {
            get;
            set;
        }

        public Int16  ID
        {
            get
            {
                return (HMComfirtTypeDTO != null) ? HMComfirtTypeDTO.ID : new Int16();
            }
            set
            {
                HMComfirtTypeDTO.ID = value;
            }
        }
       // [Required(ErrorMessage = "Please Select Room Type")]
        [Display(Name = "Comfirt Type")]
        public string ComfirtType
        {
            get
            {
                return (HMComfirtTypeDTO != null) ? HMComfirtTypeDTO.ComfirtType : string.Empty;
            }
            set
            {
                HMComfirtTypeDTO.ComfirtType = value;
            }
        }

       
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (HMComfirtTypeDTO != null) ? HMComfirtTypeDTO.IsDeleted : false;
            }
            set
            {
                HMComfirtTypeDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (HMComfirtTypeDTO != null && HMComfirtTypeDTO.CreatedBy > 0) ? HMComfirtTypeDTO.CreatedBy : new int();
            }
            set
            {
                HMComfirtTypeDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (HMComfirtTypeDTO != null) ? HMComfirtTypeDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                HMComfirtTypeDTO.CreatedDate = value;
            }
        }


        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (HMComfirtTypeDTO != null) ? HMComfirtTypeDTO.ModifiedBy : new int();
            }
            set
            {
                HMComfirtTypeDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (HMComfirtTypeDTO != null) ? HMComfirtTypeDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                HMComfirtTypeDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (HMComfirtTypeDTO != null) ? HMComfirtTypeDTO.DeletedBy : new int();
            }
            set
            {
                HMComfirtTypeDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (HMComfirtTypeDTO != null) ? HMComfirtTypeDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                HMComfirtTypeDTO.DeletedDate = value;
            }
        }
        public string errorMessage { get; set; }
    }
}

