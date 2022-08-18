using AMS.Base.DTO;
using System;

namespace AMS.DTO
{
    public class GetIngredientsList : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public Int16 InventoryVariationMasterID
        {
            get;
            set;
        }
        public Int32 ItemNumber
        {
            get;
            set;
        }
        public decimal Quantity
        {
            get;
            set;
        }
        public string UOMCode
        {
            get;
            set;
        }
        public decimal Cost
        {
            get;
            set;
        }
        public string ItemDescription
        {
            get;
            set;
        }
    }
}
