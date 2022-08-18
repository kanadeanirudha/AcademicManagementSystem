using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class EntranceExamInfrastructureDetailViewModel : IEntranceExamInfrastructureDetailViewModel
    {
        public EntranceExamInfrastructureDetailViewModel()
        {
            EntranceExamInfrastructureDetailDTO = new EntranceExamInfrastructureDetail();
        }
        public EntranceExamInfrastructureDetail EntranceExamInfrastructureDetailDTO { get; set; }


        //-----------------------------------EntranceExamAvailableCentres Table Property-------------------------------//
        public int EntranceExamAvailableCentresID
        {
            get
            {
                return (EntranceExamInfrastructureDetailDTO != null && EntranceExamInfrastructureDetailDTO.EntranceExamAvailableCentresID > 0) ? EntranceExamInfrastructureDetailDTO.EntranceExamAvailableCentresID : new int();
            }
            set
            {
                EntranceExamInfrastructureDetailDTO.EntranceExamAvailableCentresID = value;
            }
        }

        [Display(Name = "DisplayName_CentreName", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CentreNameRequired")]
        public string CentreName
        {
            get
            {
                return (EntranceExamInfrastructureDetailDTO != null && EntranceExamInfrastructureDetailDTO.CentreName != "") ? EntranceExamInfrastructureDetailDTO.CentreName : string.Empty;
            }
            set
            {
                EntranceExamInfrastructureDetailDTO.CentreName = value;
            }
        }
        [Display(Name = "DisplayName_LocationAddress", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_LocationAddressRequired")]
        public string LocationAddress
        {
            get
            {
                return (EntranceExamInfrastructureDetailDTO != null) ? EntranceExamInfrastructureDetailDTO.LocationAddress : string.Empty;
            }
            set
            {
                EntranceExamInfrastructureDetailDTO.LocationAddress = value;
            }
        }
        public int GenLocationID
        {
            get
            {
                return (EntranceExamInfrastructureDetailDTO != null && EntranceExamInfrastructureDetailDTO.GenLocationID > 0) ? EntranceExamInfrastructureDetailDTO.GenLocationID : new int();
            }
            set
            {
                EntranceExamInfrastructureDetailDTO.GenLocationID = value;
            }
        }

        public int TotalRoom
        {
            get
            {
                return (EntranceExamInfrastructureDetailDTO != null && EntranceExamInfrastructureDetailDTO.TotalRoom > 0) ? EntranceExamInfrastructureDetailDTO.TotalRoom : new int();
            }
            set
            {
                EntranceExamInfrastructureDetailDTO.TotalRoom = value;
            }
        }


        [Display(Name = "DisplayName_Address", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_Address1Required")]
        public string Address
        {
            get
            {
                return (EntranceExamInfrastructureDetailDTO != null && EntranceExamInfrastructureDetailDTO.Address != "") ? EntranceExamInfrastructureDetailDTO.Address : string.Empty;
            }
            set
            {
                EntranceExamInfrastructureDetailDTO.Address = value;
            }
        }

       
        [Display(Name = "DisplayName_ActiveFrom", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_ActiveFromRequired")]
        public string ActiveFrom
        {
            get
            {

                return (EntranceExamInfrastructureDetailDTO != null && EntranceExamInfrastructureDetailDTO.ActiveFrom != "") ? EntranceExamInfrastructureDetailDTO.ActiveFrom : string.Empty;
            }
            set
            {
                EntranceExamInfrastructureDetailDTO.ActiveFrom = value;
            }
        }

        
        [Display(Name = "DisplayName_ActiveUpto", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_ActiveUptoRequired")]
        public string ActiveUpto
        {
            get
            {
                return (EntranceExamInfrastructureDetailDTO != null && EntranceExamInfrastructureDetailDTO.ActiveUpto != "") ? EntranceExamInfrastructureDetailDTO.ActiveUpto : string.Empty;
            }
            set
            {
                EntranceExamInfrastructureDetailDTO.ActiveUpto = value;
            }
        }



        //-----------------------------------EntranceExamInfrastructureDetail Table Property-------------------------------//

        public int EntranceExamInfrastructureDetailID
        {
            get
            {
                return (EntranceExamInfrastructureDetailDTO != null && EntranceExamInfrastructureDetailDTO.EntranceExamInfrastructureDetailID > 0) ? EntranceExamInfrastructureDetailDTO.EntranceExamInfrastructureDetailID : new int();
            }
            set
            {
                EntranceExamInfrastructureDetailDTO.EntranceExamInfrastructureDetailID = value;
            }
        }

        //public int EntranceExamAvailbleCentreID 
        //{
        //    get
        //    {
        //        return (EntranceExamInfrastructureDetailDTO != null && EntranceExamInfrastructureDetailDTO.EntranceExamAvailbleCentreID > 0) ? EntranceExamInfrastructureDetailDTO.EntranceExamAvailbleCentreID : new int();
        //    }
        //    set
        //    {
        //        EntranceExamInfrastructureDetailDTO.EntranceExamAvailbleCentreID = value;
        //    }
        //}

        
        [Display(Name = "DisplayName_RoomName", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_RoomNameRequired")]
        public string RoomName
        {
            get
            {
                return (EntranceExamInfrastructureDetailDTO != null && EntranceExamInfrastructureDetailDTO.RoomName != "") ? EntranceExamInfrastructureDetailDTO.RoomName : string.Empty;
            }
            set
            {
                EntranceExamInfrastructureDetailDTO.RoomName = value;
            }
        }
        [Range(1, 240, ErrorMessage = " Room number should not be greater then 240.")]
        [Display(Name = "DisplayName_RoomNumber", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_RoomNumberRequired")]
        public int RoomNumber
        {
            get
            {
                return (EntranceExamInfrastructureDetailDTO != null && EntranceExamInfrastructureDetailDTO.RoomNumber > 0) ? EntranceExamInfrastructureDetailDTO.RoomNumber : new int();
            }
            set
            {
                EntranceExamInfrastructureDetailDTO.RoomNumber = value;
            }
        }

       
        [Display(Name = "DisplayName_ExtraDescription", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_ExtraDescriptionRequired")]
        public string ExtraDescription
        {
            get
            {
                return (EntranceExamInfrastructureDetailDTO != null && EntranceExamInfrastructureDetailDTO.ExtraDescription != "") ? EntranceExamInfrastructureDetailDTO.ExtraDescription : string.Empty;
            }
            set
            {
                EntranceExamInfrastructureDetailDTO.ExtraDescription = value;
            }
        }
        [Range(1, 240, ErrorMessage = " Room Capacity should not be greater then 240.")]
        [Display(Name = "DisplayName_RoomCapacity", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_RoomCapacityRequired")]
       
        public int RoomCapacity
        {
            get
            {
                return (EntranceExamInfrastructureDetailDTO != null && EntranceExamInfrastructureDetailDTO.RoomCapacity > 0) ? EntranceExamInfrastructureDetailDTO.RoomCapacity : new int();
            }
            set
            {
                EntranceExamInfrastructureDetailDTO.RoomCapacity = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return EntranceExamInfrastructureDetailDTO.IsDeleted != null ? EntranceExamInfrastructureDetailDTO.IsDeleted : false;
            }
            set
            {
                EntranceExamInfrastructureDetailDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (EntranceExamInfrastructureDetailDTO.CreatedBy != null && EntranceExamInfrastructureDetailDTO.CreatedBy > 0) ? EntranceExamInfrastructureDetailDTO.CreatedBy : new int();
            }
            set
            {
                EntranceExamInfrastructureDetailDTO.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (EntranceExamInfrastructureDetailDTO.CreatedDate != null) ? EntranceExamInfrastructureDetailDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                EntranceExamInfrastructureDetailDTO.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public Nullable<int> ModifiedBy
        {
            get
            {
                return EntranceExamInfrastructureDetailDTO.ModifiedBy != null ? EntranceExamInfrastructureDetailDTO.ModifiedBy : new int();
            }
            set
            {
                EntranceExamInfrastructureDetailDTO.ModifiedBy = value;
            }
        }

        public Nullable<DateTime> ModifiedDate
        {
            get
            {
                return (EntranceExamInfrastructureDetailDTO.ModifiedDate != null && EntranceExamInfrastructureDetailDTO.ModifiedDate.HasValue) ? EntranceExamInfrastructureDetailDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                EntranceExamInfrastructureDetailDTO.ModifiedDate = value;
            }
        }
        [Display(Name = "Delete By")]
        public Nullable<int> DeletedBy
        {
            get
            {
                return (EntranceExamInfrastructureDetailDTO != null && EntranceExamInfrastructureDetailDTO.DeletedBy > 0) ? EntranceExamInfrastructureDetailDTO.DeletedBy : new int();
            }
            set
            {
                EntranceExamInfrastructureDetailDTO.DeletedBy = value;
            }
        }

        [Display(Name = "Delete Date")]
        public Nullable<DateTime> DeletedDate
        {
            get
            {
                return (EntranceExamInfrastructureDetailDTO.DeletedDate != null && EntranceExamInfrastructureDetailDTO.DeletedDate.HasValue) ? EntranceExamInfrastructureDetailDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                EntranceExamInfrastructureDetailDTO.DeletedDate = value;
            }
        }

        public string ErrorMessage
        {
            get
            {
                return (EntranceExamInfrastructureDetailDTO != null && EntranceExamInfrastructureDetailDTO.ErrorMessage != "") ? EntranceExamInfrastructureDetailDTO.ErrorMessage : string.Empty;
            }
            set
            {
                EntranceExamInfrastructureDetailDTO.ErrorMessage = value;
            }
        }

    }
}
