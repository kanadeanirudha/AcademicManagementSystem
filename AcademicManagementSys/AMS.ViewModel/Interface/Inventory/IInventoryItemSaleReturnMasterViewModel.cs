using AMS.DTO;
using System;

namespace AMS.ViewModel
{
    public interface IInventoryItemSaleReturnMasterViewModel
    {
        InventoryItemSaleReturnMaster InventoryItemSaleReturnMasterDTO { get; set; }

        //---------------------------------------InventorySalesReturnMaster-----------------------------
        int InvSalesReturnMasterID { get; set; }
        string TransactionDate { get; set; }
        string BillNumber { get; set; }
        decimal SalesReturnAmount { get; set; }
        string CustomerName { get; set; }
        int BalanceSheetID { get; set; }
        int CounterLogID { get; set; }
        int LocationID { get; set; }
        decimal PaymentByCustomer { get; set; }
        decimal ReturnChange { get; set; }
        decimal TotalTaxAmount { get; set; }
        decimal TotalDiscountAmount { get; set; }

              
        //--------------------------------------InventorySalesRetrunTransaction------------------------------
        int InvSalesRetrunTransactionID { get; set; }       
        int ItemID { get; set; }
        decimal Quantity { get; set; }
        decimal Rate { get; set; }
        decimal TaxAmount { get; set; }
        decimal DiscountAmount { get; set; }
        int GenTaxGroupMasterID { get; set; }

        //-----------------------------------------Comman Property--------------------------------------------------
        bool IsActive { get; set; }
        bool IsDeleted { get; set; }
        int CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        int ModifiedBy { get; set; }
        DateTime ModifiedDate { get; set; }
        int DeletedBy { get; set; }
        DateTime DeletedDate { get; set; }


        //------------------------------------------Extra Property--------------------------------------------------------
        string ErrorMessage { get; set; }
        int InvBufferSalesMasterID { get; set; }

    }
}
