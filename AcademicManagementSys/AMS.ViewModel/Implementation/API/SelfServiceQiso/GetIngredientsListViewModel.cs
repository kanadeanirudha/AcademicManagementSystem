using AMS.Common;
using AMS.DTO;
using System;
using System.ComponentModel.DataAnnotations;

namespace AMS.ViewModel
{
    public class GetIngredientsListViewModel : IGetIngredientsListViewModel
    {
        public GetIngredientsListViewModel()
        {
            GetIngredientsListDTO = new GetIngredientsList();
        }

        public GetIngredientsList GetIngredientsListDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (GetIngredientsListDTO != null && GetIngredientsListDTO.ID > 0) ? GetIngredientsListDTO.ID : new int();
            }
            set
            {
                GetIngredientsListDTO.ID = value;
            }
        }

        public string ErrorMessage
        {
            get
            {
                return GetIngredientsListDTO.ErrorMessage;
            }
            set
            {
                GetIngredientsListDTO.ErrorMessage = value;
            }
        }

        public Int16 InventoryVariationMasterID
        {
            get
            {
                return (GetIngredientsListDTO != null && GetIngredientsListDTO.InventoryVariationMasterID > 0) ? GetIngredientsListDTO.InventoryVariationMasterID : new Int16();
            }
            set
            {
                GetIngredientsListDTO.InventoryVariationMasterID = value;
            }
        }
       
    }
}
