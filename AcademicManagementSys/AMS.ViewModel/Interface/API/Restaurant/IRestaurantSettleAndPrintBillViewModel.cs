using System;
namespace AMS.ViewModel
{
    public interface IRestaurantSettleAndPrintBillViewModel
    {
        int ID { get; set; }
        int RestaurantTableOrderID { get; set; }
        int GeneralUnitsID { get; set; }
        string BillNumber { get; set; }
        int CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        int InventorySaleMasterID { get; set; }
        string ModifiedBy { get; set; }
        DateTime ModifiedDate { get; set; }
        int DeletedBy { get; set; }
        DateTime DeletedDate { get; set; }
        bool IsDeleted { get; set; }

    }
}
