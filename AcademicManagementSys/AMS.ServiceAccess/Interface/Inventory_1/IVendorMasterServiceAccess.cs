using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IVendorMasterServiceAccess
    {
        IBaseEntityResponse<VendorMaster> InsertVendorMaster(VendorMaster item);
        IBaseEntityResponse<VendorMaster> UpdateVendorMaster(VendorMaster item);
        IBaseEntityResponse<VendorMaster> DeleteVendorMaster(VendorMaster item);
        IBaseEntityResponse<VendorMaster> InsertVendorMasterExcel(VendorMaster item);

        IBaseEntityCollectionResponse<VendorMaster> GetBySearch(VendorMasterSearchRequest searchRequest);
        IBaseEntityResponse<VendorMaster> SelectByID(VendorMaster item);
        //IBaseEntityResponse<VendorMaster> GetReplenishmentDataByVendorNumber(VendorMaster item);
        IBaseEntityResponse<VendorMaster> GetGeneralDataByVendorNumber(VendorMaster item);
        IBaseEntityResponse<VendorMaster> GetFinanceDataByVendorNumber(VendorMaster item);
        IBaseEntityCollectionResponse<VendorMaster> GetVendorMasterSearchList(VendorMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<VendorMaster> GetContactPersonDetailsForVendorMaster(VendorMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<VendorMaster> GetReplenishmentDataByVendorNumber(VendorMasterSearchRequest searchRequest);
        IBaseEntityResponse<VendorMaster> GetLeadTimeByVendorID(VendorMaster item);
        IBaseEntityResponse<VendorMaster> GetDataValidationListsForExcel(VendorMaster item);
    }
}
