using System;
using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class InventoryLablePrintingFormatSearchRequest : BaseDTO
    {
        
        public int ItemNumber
        { get; 
          set; 
        }
        public string ItemDescription
        { 
            get; 
            set; 
        }
        public int GeneralUnitsID
        {
            get;
            set;
        }
        public string SaleUoM
        {
            get;
            set;
        }
        public int ToItemNumber
        {
            get;
            set;
        }
        public int FromItemNumber
        {
            get;
            set;
        }
    }
}


       
       
    
