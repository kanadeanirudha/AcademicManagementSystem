using AMS.Base.DTO;
using System;
namespace AMS.DTO
{

    public interface IInventoryOpeningBalanceViewModel
    {
        InventoryOpeningBalance InventoryOpeningBalanceDTO
        {
            get;
            set;
        }

        int ID
        {
            get;
            set;
        }


        //string CentreCode
        //{
        //    get;
        //    set;
        //}
        string ItemName { get; set; }
        string TransactionDate
        {
            get;
            set;
        }

        decimal OpeningAmount
        {
            get;
            set;
        }

        Int16 BalanceSheetID
        {
            get;
            set;
        }

        int ItemID
        {
            get;
            set;

        }

        string CategoryDescription
        {
            get;
            set;
        }
        string CategoryCode
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
        int ModifiedBy
        {
            get;
            set;
        }
        DateTime ModifiedDate
        {
            get;
            set;
        }
        int DeletedBy
        {
            get;
            set;
        }
        DateTime DeletedDate
        {
            get;
            set;
        }
        string errorMessage { get; set; }
    }
}
