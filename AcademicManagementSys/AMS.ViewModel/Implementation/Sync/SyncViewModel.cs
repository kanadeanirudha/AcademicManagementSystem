using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
     public class SyncViewModel : ISyncViewModel
    {

        public SyncViewModel()
        {
            SyncDTO = new Sync();
        }

        public Sync SyncDTO
        {
            get;
            set;
        }
        public int CreatedBy
        {
            get
            {
                return (SyncDTO != null && SyncDTO.CreatedBy > 0) ? SyncDTO.CreatedBy : new int();
            }
            set
            {
                SyncDTO.CreatedBy = value;
            }
        }
        public int ID
        {
            get
            {
                return (SyncDTO != null && SyncDTO.ID > 0) ? SyncDTO.ID : new int();
            }
            set
            {
                SyncDTO.ID = value;
            }
        }
        public bool IsValidUserCount
        {
            get
            {
                return (SyncDTO != null) ? SyncDTO.IsValidUserCount : false;
            }
            set
            {
                SyncDTO.IsValidUserCount = value;
            }
        }
        public int BalancesheetID
        {
            get
            {
                return (SyncDTO != null && SyncDTO.BalancesheetID > 0) ? SyncDTO.BalancesheetID : new int();
            }
            set
            {
                SyncDTO.BalancesheetID = value;
            }
        }
        public string errorMessage { get; set; }
    }
}

