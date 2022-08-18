using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class GeneralItemMasterServiceAccess : IGeneralItemMasterServiceAccess
    {
        IGeneralItemMasterBA _GeneralItemMasterBA = null;
        public GeneralItemMasterServiceAccess()
        {
            _GeneralItemMasterBA = new GeneralItemMasterBA();
        }
        public IBaseEntityResponse<GeneralItemMaster> InsertGeneralItemMaster(GeneralItemMaster item)
        {
            return _GeneralItemMasterBA.InsertGeneralItemMaster(item);
        }
        public IBaseEntityResponse<GeneralItemMaster> UpdateGeneralItemMaster(GeneralItemMaster item)
        {
            return _GeneralItemMasterBA.UpdateGeneralItemMaster(item);
        }
        public IBaseEntityResponse<GeneralItemMaster> DeleteGeneralItemMaster(GeneralItemMaster item)
        {
            return _GeneralItemMasterBA.DeleteGeneralItemMaster(item);
        }
        public IBaseEntityCollectionResponse<GeneralItemMaster> GetBySearch(GeneralItemMasterSearchRequest searchRequest)
        {
            return _GeneralItemMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<GeneralItemMaster> GetGeneralItemMasterSearchList(GeneralItemMasterSearchRequest searchRequest)
        {
            return _GeneralItemMasterBA.GetGeneralItemMasterSearchList(searchRequest);
        }
        public IBaseEntityResponse<GeneralItemMaster> SelectByID(GeneralItemMaster item)
        {
            return _GeneralItemMasterBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<GeneralItemMaster> SearchListForGeneralPackingTypeInfo(GeneralItemMasterSearchRequest searchRequest)
        {
            return _GeneralItemMasterBA.SearchListForGeneralPackingTypeInfo(searchRequest);
        }
        public IBaseEntityResponse<GeneralItemMaster> GetGeneralItemSupliersDataByItemNumber(GeneralItemMaster item)
        {
            return _GeneralItemMasterBA.GetGeneralItemSupliersDataByItemNumber(item);
        }
        //public IBaseEntityResponse<GeneralItemMaster> GetGeneralItemSalesDataByItemNumber(GeneralItemMaster item)
        //{
        //    return _GeneralItemMasterBA.GetGeneralItemSalesDataByItemNumber(item);
        //}
        public IBaseEntityResponse<GeneralItemMaster> GetGeneralItemGeneralDataByItemNumber(GeneralItemMaster item)
        {
            return _GeneralItemMasterBA.GetGeneralItemGeneralDataByItemNumber(item);
        }
        public IBaseEntityResponse<GeneralItemMaster> GetGeneralItemStockDataByItemNumber(GeneralItemMaster item)
        {
            return _GeneralItemMasterBA.GetGeneralItemStockDataByItemNumber(item);
        }
        public IBaseEntityCollectionResponse<GeneralItemMaster> GetGeneralItemDetailsForSupliersDataSearchList(GeneralItemMasterSearchRequest searchRequest)
        {
            return _GeneralItemMasterBA.GetGeneralItemDetailsForSupliersDataSearchList(searchRequest);
        }
        public IBaseEntityCollectionResponse<GeneralItemMaster> GetUomDetailsForGeneralItemMaster(GeneralItemMasterSearchRequest searchRequest)
        {
            return _GeneralItemMasterBA.GetUomDetailsForGeneralItemMaster(searchRequest);
        }


        public IBaseEntityResponse<GeneralItemMaster> InsertGeneralItemBarcodes(GeneralItemMaster item)
        {
            return _GeneralItemMasterBA.InsertGeneralItemBarcodes(item);
        }

        public IBaseEntityResponse<GeneralItemMaster> DeleteGeneralItemBarcodes(GeneralItemMaster item)
        {
            return _GeneralItemMasterBA.DeleteGeneralItemBarcodes(item);
        }
        public IBaseEntityCollectionResponse<GeneralItemMaster> GetBarcodesBySearch(GeneralItemMasterSearchRequest searchRequest)
        {
            return _GeneralItemMasterBA.GetBarcodesBySearch(searchRequest);
        }

        public IBaseEntityResponse<GeneralItemMaster> InsertInventoryStoreSpecificInformation(GeneralItemMaster item)
        {
            return _GeneralItemMasterBA.InsertInventoryStoreSpecificInformation(item);
        }
        public IBaseEntityResponse<GeneralItemMaster> SelectOneInventoryStoreSpecificInformation(GeneralItemMaster item)
        {
            return _GeneralItemMasterBA.SelectOneInventoryStoreSpecificInformation(item);
        }

        public IBaseEntityResponse<GeneralItemMaster> CheckFocusOnAction(GeneralItemMaster item)
        {
            return _GeneralItemMasterBA.CheckFocusOnAction(item);
        }
        public IBaseEntityResponse<GeneralItemMaster> GetRestaurantDataByItemNumber(GeneralItemMaster item)
        {
            return _GeneralItemMasterBA.GetRestaurantDataByItemNumber(item);
        }
        public IBaseEntityCollectionResponse<GeneralItemMaster> GetVariantDetailsForGeneralItemMasters(GeneralItemMasterSearchRequest searchRequest)
        {
            return _GeneralItemMasterBA.GetVariantDetailsForGeneralItemMasters(searchRequest);
        }
        public IBaseEntityCollectionResponse<GeneralItemMaster> GetGeneralItemStoreData(GeneralItemMasterSearchRequest searchRequest)
        {
            return _GeneralItemMasterBA.GetGeneralItemStoreData(searchRequest);
        }

        public IBaseEntityCollectionResponse<GeneralItemMaster> GetGeneralItemSalesDataByItemNumber(GeneralItemMasterSearchRequest searchRequest)
        {
            return _GeneralItemMasterBA.GetGeneralItemSalesDataByItemNumber(searchRequest);
        }

        public IBaseEntityResponse<GeneralItemMaster> InsertGeneralitemMasterExcel(GeneralItemMaster item)
        {
            return _GeneralItemMasterBA.InsertGeneralitemMasterExcel(item);
        }

        public IBaseEntityResponse<GeneralItemMaster> GetDataValidationListsForExcel(GeneralItemMaster item)
        {
            return _GeneralItemMasterBA.GetDataValidationListsForExcel(item);
        }
        public IBaseEntityCollectionResponse<GeneralItemMaster> GetGeneralItemAttributeData(GeneralItemMasterSearchRequest searchRequest)
        {
            return _GeneralItemMasterBA.GetGeneralItemAttributeData(searchRequest);
        }

        public IBaseEntityCollectionResponse<GeneralItemMaster> GetGeneralItemAttributeDataByItemNumber(GeneralItemMasterSearchRequest searchRequest)
        {
            return _GeneralItemMasterBA.GetGeneralItemAttributeDataByItemNumber(searchRequest);
        }

        public IBaseEntityCollectionResponse<GeneralItemMaster> GetItemSearchListForVarientsMenu(GeneralItemMasterSearchRequest searchRequest)
        {
            return _GeneralItemMasterBA.GetItemSearchListForVarientsMenu(searchRequest);
        }
        //******************************** Reports searchlist **********
        public IBaseEntityCollectionResponse<GeneralItemMaster> GetGeneralItemMasterSearchListForReport(GeneralItemMasterSearchRequest searchRequest)
        {
            return _GeneralItemMasterBA.GetGeneralItemMasterSearchListForReport(searchRequest);
        }
        //****************Vendor specific item search list
        public IBaseEntityCollectionResponse<GeneralItemMaster> GetVendorWiseItemSearchListForRequisition(GeneralItemMasterSearchRequest searchRequest)
        {
            return _GeneralItemMasterBA.GetVendorWiseItemSearchListForRequisition(searchRequest);
        }
        //****************Multiple Vendor
        public IBaseEntityResponse<GeneralItemMaster> InsertGeneralItemSupplierDataForVendorDetails(GeneralItemMaster item)
        {
            return _GeneralItemMasterBA.InsertGeneralItemSupplierDataForVendorDetails(item);
        }
        public IBaseEntityCollectionResponse<GeneralItemMaster> GetMultipleVendorListItemWise(GeneralItemMasterSearchRequest searchRequest)
        {
            return _GeneralItemMasterBA.GetMultipleVendorListItemWise(searchRequest);
        }
        public IBaseEntityCollectionResponse<GeneralItemMaster> GetGeneralItemSupliersDataByItemNumberandVendorID(GeneralItemMasterSearchRequest searchRequest)
        {
            return _GeneralItemMasterBA.GetGeneralItemSupliersDataByItemNumberandVendorID(searchRequest);
        }

        public IBaseEntityResponse<GeneralItemMaster> GetGeneralItemEcommerceDataByItemNumber(GeneralItemMaster item)
        {
            return _GeneralItemMasterBA.GetGeneralItemEcommerceDataByItemNumber(item);
        }
        public IBaseEntityResponse<GeneralItemMaster> DeleteGeneralItemMasterEComImages(GeneralItemMaster item)
        {
            return _GeneralItemMasterBA.DeleteGeneralItemMasterEComImages(item);
        }
    }
}
