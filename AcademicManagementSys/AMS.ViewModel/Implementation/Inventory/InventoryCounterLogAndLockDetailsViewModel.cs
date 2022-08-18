using AMS.Common;
using AMS.DTO;
using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AMS.ViewModel
{
    public class InventoryCounterLogAndLockDetailsViewModel : IInventoryCounterLogAndLockDetailsViewModel
    {
        public InventoryCounterLogAndLockDetailsViewModel()
        {
            InventoryCounterLogAndLockDetailsDTO = new InventoryCounterLogAndLockDetails();
          
        }
        public InventoryCounterLogAndLockDetails InventoryCounterLogAndLockDetailsDTO { get; set; }

        public int CounterLockID
        {
            get
            {
                return (InventoryCounterLogAndLockDetailsDTO != null && InventoryCounterLogAndLockDetailsDTO.CounterLockID > 0) ? InventoryCounterLogAndLockDetailsDTO.CounterLockID : new short();
            }
            set
            {
                InventoryCounterLogAndLockDetailsDTO.CounterLockID = value;
            }
        }
        public decimal OpeningCash
        {
            get
            {
                return (InventoryCounterLogAndLockDetailsDTO != null && InventoryCounterLogAndLockDetailsDTO.OpeningCash > 0) ? InventoryCounterLogAndLockDetailsDTO.OpeningCash : new decimal();
            }
            set
            {
                InventoryCounterLogAndLockDetailsDTO.OpeningCash = value;
            }
        }
        public decimal ClosingCash
        {
            get
            {
                return (InventoryCounterLogAndLockDetailsDTO != null && InventoryCounterLogAndLockDetailsDTO.ClosingCash > 0) ? InventoryCounterLogAndLockDetailsDTO.ClosingCash : new decimal();
            }
            set
            {
                InventoryCounterLogAndLockDetailsDTO.ClosingCash = value;
            }
        }

        public int UserID
        {
            get
            {
                return (InventoryCounterLogAndLockDetailsDTO != null && InventoryCounterLogAndLockDetailsDTO.UserID > 0) ? InventoryCounterLogAndLockDetailsDTO.UserID : new short();
            }
            set
            {
                InventoryCounterLogAndLockDetailsDTO.UserID = value;
            }
        }

        public DateTime LoginDateTime
        {
            get
            {
                return (InventoryCounterLogAndLockDetailsDTO != null) ? InventoryCounterLogAndLockDetailsDTO.LoginDateTime : DateTime.Now;
            }
            set
            {
                InventoryCounterLogAndLockDetailsDTO.LoginDateTime = value;
            }
        }
        public DateTime LogOutDateTime
        {
            get
            {
                return (InventoryCounterLogAndLockDetailsDTO != null) ? InventoryCounterLogAndLockDetailsDTO.LoginDateTime : DateTime.Now;
            }
            set
            {
                InventoryCounterLogAndLockDetailsDTO.LoginDateTime = value;
            }
        }
        public int LocationID
        {
            get
            {
                return (InventoryCounterLogAndLockDetailsDTO != null && InventoryCounterLogAndLockDetailsDTO.LocationID > 0) ? InventoryCounterLogAndLockDetailsDTO.LocationID : new short();
            }
            set
            {
                InventoryCounterLogAndLockDetailsDTO.LocationID = value;
            }
        }

        public int CounterLogID
        {
            get
            {
                return (InventoryCounterLogAndLockDetailsDTO != null && InventoryCounterLogAndLockDetailsDTO.CounterLogID > 0) ? InventoryCounterLogAndLockDetailsDTO.CounterLogID : new short();
            }
            set
            {
                InventoryCounterLogAndLockDetailsDTO.CounterLogID = value;
            }
        }

        public int InvCounterApplicableDetailsID
        {
            get
            {
                return (InventoryCounterLogAndLockDetailsDTO != null && InventoryCounterLogAndLockDetailsDTO.InvCounterApplicableDetailsID > 0) ? InventoryCounterLogAndLockDetailsDTO.InvCounterApplicableDetailsID : new short();
            }
            set
            {
                InventoryCounterLogAndLockDetailsDTO.InvCounterApplicableDetailsID = value;
            }
        }
        public int LoginUserCount
        {
            get
            {
                return (InventoryCounterLogAndLockDetailsDTO != null && InventoryCounterLogAndLockDetailsDTO.LoginUserCount > 0) ? InventoryCounterLogAndLockDetailsDTO.LoginUserCount : new short();
            }
            set
            {
                InventoryCounterLogAndLockDetailsDTO.LoginUserCount = value;
            }
        }

        public string TokenCode
        {
            get
            {
                return (InventoryCounterLogAndLockDetailsDTO != null) ? InventoryCounterLogAndLockDetailsDTO.TokenCode : string.Empty;
            }
            set
            {
                InventoryCounterLogAndLockDetailsDTO.TokenCode = value;
            }
        }
      
        public int CreatedBy
        {
            get
            {
                return (InventoryCounterLogAndLockDetailsDTO != null && InventoryCounterLogAndLockDetailsDTO.CreatedBy > 0) ? InventoryCounterLogAndLockDetailsDTO.CreatedBy : new short();
            }
            set
            {
                InventoryCounterLogAndLockDetailsDTO.CreatedBy = value;
            }
        }
        public DateTime CreatedDate
        {
            get
            {
                return (InventoryCounterLogAndLockDetailsDTO != null) ? InventoryCounterLogAndLockDetailsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                InventoryCounterLogAndLockDetailsDTO.CreatedDate = value;
            }
        }
        public int ModifiedBy
        {
            get
            {
                return (InventoryCounterLogAndLockDetailsDTO != null && InventoryCounterLogAndLockDetailsDTO.ModifiedBy > 0) ? InventoryCounterLogAndLockDetailsDTO.ModifiedBy : new short();
            }
            set
            {
                InventoryCounterLogAndLockDetailsDTO.ModifiedBy = value;
            }
        }
        public DateTime ModifiedDate
        {
            get
            {
                return (InventoryCounterLogAndLockDetailsDTO != null) ? InventoryCounterLogAndLockDetailsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                InventoryCounterLogAndLockDetailsDTO.ModifiedDate = value;
            }
        }
        public int DeletedBy
        {
            get
            {
                return (InventoryCounterLogAndLockDetailsDTO != null && InventoryCounterLogAndLockDetailsDTO.DeletedBy > 0) ? InventoryCounterLogAndLockDetailsDTO.DeletedBy : new short();
            }
            set
            {
                InventoryCounterLogAndLockDetailsDTO.DeletedBy = value;
            }
        }
        public DateTime DeletedDate
        {
            get
            {
                return (InventoryCounterLogAndLockDetailsDTO != null) ? InventoryCounterLogAndLockDetailsDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                InventoryCounterLogAndLockDetailsDTO.DeletedDate = value;
            }
        }
        public string errorMessage { get; set; }
        public int BalanceSheetID
        {
            get
            {
                return (InventoryCounterLogAndLockDetailsDTO != null && InventoryCounterLogAndLockDetailsDTO.BalanceSheetID > 0) ? InventoryCounterLogAndLockDetailsDTO.BalanceSheetID : new int();
            }
            set
            {
                InventoryCounterLogAndLockDetailsDTO.BalanceSheetID = value;
            }
        }
    }
}
