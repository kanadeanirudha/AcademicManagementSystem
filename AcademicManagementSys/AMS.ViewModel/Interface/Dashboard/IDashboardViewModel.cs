using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public interface IDashboardViewModel
    {

        #region -------------- TaskNotificationMaster ---------------
        int TaskNotificationMasterID
        {
            get;
            set;
        }
        string TaskCode
        {
            get;
            set;
        }
        int GeneralTaskReportingMasterID
        {
            get;
            set;
        }
        string EntitytableName
        {
            get;
            set;
        }
        string EntityPKName
        {
            get;
            set;
        }
        int EntityPKValue
        {
            get;
            set;
        }
        int PersonID
        {
            get;
            set;
        }
        string PersonType
        {
            get;
            set;
        }
        string PersonName
        {
            get;
            set;
        }
        string Status
        {
            get;
            set;
        }
        int LastApprovalStatus
        {
            get;
            set;
        }
        bool IsActive
        {
            get;
            set;
        }
        bool IsDeleted
        {
            get;
            set;
        }
        int CreatedBy
        {
            get;
            set;
        }
        DateTime CreatedDate
        {
            get;
            set;
        }
        int? ModifiedBy
        {
            get;
            set;
        }
        DateTime? ModifiedDate
        {
            get;
            set;
        }
        int? DeletedBy
        {
            get;
            set;
        }
        DateTime? DeletedDate
        {
            get;
            set;
        }
        int AdminRoleMasterID
        {
            get;
            set;
        }
        int ApplicationID
        {
            get;
            set;
        }
        #endregion


        #region -------------- TaskNotificationDetails ---------------
        int TaskNotificationDetailsID
        {
            get;
            set;
        }
        int GeneralTaskReportingDetailsID
        {
            get;
            set;
        }
        int NextGeneralTaskReportingDetailsID
        {
            get;
            set;
        }
        bool IsLastRecordFlag
        {
            get;
            set;
        }
        int ApprovalStatus
        {
            get;
            set;
        }
        string MenuCodeLink
        {
            get;
            set;
        }
        string Description
        {
            get;
            set;
        }
        string Remark
        {
            get;
            set;
        }
        int TotalRecords
        {
            get;
            set;
        }
        int StageSequenceNumber
        {
            get;
            set;
        }
        bool IsEngaged
        {
            get;
            set;
        }
        int EngagedByUserID
        {
            get;
            set;
        }

        #endregion

        #region -------------- RequestNotificationDetails ---------------
        int GeneralRequestTransactionID
        {
            get;
            set;
        }
        string RequestCode
        {
            get;
            set;
        }

        #endregion

        int ApprovedByUserID
        {
            get;
            set;
        }


        string FormName
        {
            get;
            set;
        }
        string Lable
        {
            get;
            set;
        }
        string LableValue
        {
            get;
            set;
        }
        int ColumnNumber
        {
            get;
            set;
        }
        bool IsLastRecord
        {
            get;
            set;
        }
        string ApplicationDate
        {
            get;
            set;
        }
        List<Dashboard> RequestApprovalFieldMasterList { get; set; }

        List<Dashboard> GeneralRequestApprovalFieldMasterList { get; set; }

        List<Dashboard> TaskCodeList { get; set; }

        List<UserModuleMaster> ModuleList { get; set; }

        List<Dashboard> DashboardContentList { get; set; }
    }
}
