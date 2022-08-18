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
    public class HMIPDTypeViewModel : IHMIPDTypeViewModel
    {

        public HMIPDTypeViewModel()
        {
            HMIPDTypeDTO = new HMIPDType();
        }
      
        public HMIPDType HMIPDTypeDTO
        {
            get;
            set;
        }

        public Int16  ID
        {
            get
            {
                return (HMIPDTypeDTO != null) ? HMIPDTypeDTO.ID : new Int16();
            }
            set
            {
                HMIPDTypeDTO.ID = value;
            }
        }
        [Required(ErrorMessage = "Name should not be blank")]
        [Display(Name = "Name")]
        public string Name
        {
            get
            {
                return (HMIPDTypeDTO != null) ? HMIPDTypeDTO.Name : string.Empty;
            }
            set
            {
                HMIPDTypeDTO.Name = value;
            }
        }
        public string Type
        {
            get
            {
                return (HMIPDTypeDTO != null) ? HMIPDTypeDTO.Type : string.Empty;
            }
            set
            {
                HMIPDTypeDTO.Type = value;
            }
        }

       
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (HMIPDTypeDTO != null) ? HMIPDTypeDTO.IsDeleted : false;
            }
            set
            {
                HMIPDTypeDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (HMIPDTypeDTO != null && HMIPDTypeDTO.CreatedBy > 0) ? HMIPDTypeDTO.CreatedBy : new int();
            }
            set
            {
                HMIPDTypeDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (HMIPDTypeDTO != null) ? HMIPDTypeDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                HMIPDTypeDTO.CreatedDate = value;
            }
        }


        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (HMIPDTypeDTO != null) ? HMIPDTypeDTO.ModifiedBy : new int();
            }
            set
            {
                HMIPDTypeDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (HMIPDTypeDTO != null) ? HMIPDTypeDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                HMIPDTypeDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (HMIPDTypeDTO != null) ? HMIPDTypeDTO.DeletedBy : new int();
            }
            set
            {
                HMIPDTypeDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (HMIPDTypeDTO != null) ? HMIPDTypeDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                HMIPDTypeDTO.DeletedDate = value;
            }
        }
        public string errorMessage { get; set; }
    }
}

