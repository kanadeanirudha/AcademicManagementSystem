using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IGeneralItemMasterServiceAccess
    {
        IBaseEntityResponse<GeneralItemMaster> InsertGeneralItemMaster(GeneralItemMaster item);
        IBaseEntityResponse<GeneralItemMaster> UpdateGeneralItemMaster(GeneralItemMaster item);
        IBaseEntityResponse<GeneralItemMaster> DeleteGeneralItemMaster(GeneralItemMaster item);
        IBaseEntityCollectionResponse<GeneralItemMaster> GetBySearch(GeneralItemMasterSearchRequest searchRequest);
        IBaseEntityResponse<GeneralItemMaster> SelectByID(GeneralItemMaster item);
        IBaseEntityCollectionResponse<GeneralItemMaster> GetGeneralItemMasterSearchList(GeneralItemMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralItemMaster>SearchListForGeneralPackingTypeInfo(GeneralItemMasterSearchRequest searchRequest);
        IBaseEntityResponse<GeneralItemMaster> GetGeneralItemSupliersDataByItemNumber(GeneralItemMaster item);
        //IBaseEntityResponse<GeneralItemMaster> GetGeneralItemSalesDataByItemNumber(GeneralItemMaster item);
        IBaseEntityResponse<GeneralItemMaster> GetGeneralItemGeneralDataByItemNumber(GeneralItemMaster item);
        IBaseEntityResponse<GeneralItemMaster> GetGeneralItemStockDataByItemNumber(GeneralItemMaster item);
        IBaseEntityCollectionResponse<GeneralItemMaster> GetGeneralItemDetailsForSupliersDataSearchList(GeneralItemMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralItemMaster> GetUomDetailsForGeneralItemMaster(GeneralItemMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralItemMaster> GetGeneralItemSalesDataByItemNumber(GeneralItemMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralItemMaster> GetGeneralItemAttributeDataByItemNumber(GeneralItemMasterSearchRequest searchRequest);

        IBaseEntityResponse<GeneralItemMaster> GetRestaurantDataByItemNumber(GeneralItemMaster item);
        IBaseEntityCollectionResponse<GeneralItemMaster> GetVariantDetailsForGeneralItemMasters(GeneralItemMasterSearchRequest searchRequest);

        IBaseEntityResponse<GeneralItemMaster> InsertGeneralItemBarcodes(GeneralItemMaster item);
        IBaseEntityCollectionResponse<GeneralItemMaster> GetBarcodesBySearch(GeneralItemMasterSearchRequest searchRequest);
        IBaseEntityResponse<GeneralItemMaster> DeleteGeneralItemBarcodes(GeneralItemMaster item);

        IBaseEntityResponse<GeneralItemMaster> InsertInventoryStoreSpecificInformation(GeneralItemMaster item);
        IBaseEntityResponse<GeneralItemMaster> SelectOneInventoryStoreSpecificInformation(GeneralItemMaster item);

        IBaseEntityResponse<GeneralItemMaster> CheckFocusOnAction(GeneralItemMaster item);
        IBaseEntityCollectionResponse<GeneralItemMaster> GetGeneralItemStoreData(GeneralItemMasterSearchRequest searchRequest);

        IBaseEntityResponse<GeneralItemMaster> InsertGeneralitemMasterExcel(GeneralItemMaster item);
        IBaseEntityResponse<GeneralItemMaster> GetDataValidationListsForExcel(GeneralItemMaster item);
        IBaseEntityCollectionResponse<GeneralItemMaster> GetGeneralItemAttributeData(GeneralItemMasterSearchRequest searchRequest);
        //For sale Promotion plan 
        IBaseEntityCollectionResponse<GeneralItemMaster> GetItemSearchListForVarientsMenu(GeneralItemMasterSearchRequest searchRequest);
        //******************************** Reports searchlist **********
        IBaseEntityCollectionResponse<GeneralItemMaster> GetGeneralItemMasterSearchListForReport(GeneralItemMasterSearchRequest searchRequest);
        //****************Vendor specific item search list
        IBaseEntityCollectionResponse<GeneralItemMaster> GetVendorWiseItemSearchListForRequisition(GeneralItemMasterSearchRequest searchRequest);
        //****************Multiple Vendor
        IBaseEntityResponse<GeneralItemMaster> InsertGeneralItemSupplierDataForVendorDetails(GeneralItemMaster item);
        IBaseEntityCollectionResponse<GeneralItemMaster> GetMultipleVendorListItemWise(GeneralItemMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralItemMaster> GetGeneralItemSupliersDataByItemNumberandVendorID(GeneralItemMasterSearchRequest searchRequest);
        IBaseEntityResponse<GeneralItemMaster> GetGeneralItemEcommerceDataByItemNumber(GeneralItemMaster item);
        IBaseEntityResponse<GeneralItemMaster> DeleteGeneralItemMasterEComImages(GeneralItemMaster item);


    }
}
