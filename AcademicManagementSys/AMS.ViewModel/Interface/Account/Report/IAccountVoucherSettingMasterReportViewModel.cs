using AMS.DTO;
using System;

namespace AMS.ViewModel
{
    public interface IAccountVoucherSettingMasterReportViewModel
    {
        AccountVoucherSettingMasterReport AccountVoucherSettingMasterReportDTO
        {
            get;
            set;
        }
   //     Int16 ID { get; set; }
        int AccSessionID { get; set; }
        string TransactionType { get; set; }
        string SessionName { get; set; }
        string TransactionTypeCode { get; set; }
        int VoucherNumber { get; set; }
        bool IsActive { get; set; }

    }
}
