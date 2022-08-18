namespace AMS.ViewModel
{
    public class IPurchaseGRNViewModel
    {
        int ID
        {
            get;
            set;
        }
        int PurchaseOrderMasterID
        {
            get;
            set;
        }
        string GRNNumber
        {
            get;
            set;
        }
        string GRNTransDate
        {
            get;
            set;
        }

        bool IsLocked
        {
            get;
            set;
        }
    
         string CreatedBy { get; set; }
         string CreatedDate { get; set; }
         string ModifiedBy { get; set; }
         string ModifiedDate { get; set; }
         string DeletedBy { get; set; }
         string DeletedDate { get; set; }
         bool IsDeleted { get; set; }
        /// <summary>
        /// Properties for PurchaseGRNDetails table
        /// </summary>
        int PurchaseGRNDetailsID
        {
            get;
            set;
        }
        int ItemID
        {
            get;
            set;
        }
        decimal ReceivedQuantity
        {
            get;
            set;
        }
        int ReceivingLocationID
        {
            get;
            set;
        }
    }
}
