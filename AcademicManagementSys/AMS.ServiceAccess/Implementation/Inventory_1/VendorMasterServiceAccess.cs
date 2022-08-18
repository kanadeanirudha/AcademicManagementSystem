using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class VendorMasterServiceAccess : IVendorMasterServiceAccess
    {
        IVendorMasterBA _VendorMasterBA = null;
        public VendorMasterServiceAccess()
        {
            _VendorMasterBA = new VendorMasterBA();
        }
        public IBaseEntityResponse<VendorMaster> InsertVendorMaster(VendorMaster item)
        {
            return _VendorMasterBA.InsertVendorMaster(item);
        }
        public IBaseEntityResponse<VendorMaster> UpdateVendorMaster(VendorMaster item)
        {
            return _VendorMasterBA.UpdateVendorMaster(item);
        }
        public IBaseEntityResponse<VendorMaster> DeleteVendorMaster(VendorMaster item)
        {
            return _VendorMasterBA.DeleteVendorMaster(item);
        }
        public IBaseEntityCollectionResponse<VendorMaster> GetBySearch(VendorMasterSearchRequest searchRequest)
        {
            return _VendorMasterBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<VendorMaster> GetVendorMasterSearchList(VendorMasterSearchRequest searchRequest)
        {
            return _VendorMasterBA.GetVendorMasterSearchList(searchRequest);
        }
        public IBaseEntityResponse<VendorMaster> SelectByID(VendorMaster item)
        {
            return _VendorMasterBA.SelectByID(item);
        }
        public IBaseEntityResponse<VendorMaster> GetLeadTimeByVendorID(VendorMaster item)
        {
            return _VendorMasterBA.GetLeadTimeByVendorID(item);
        }
        //public IBaseEntityResponse<VendorMaster> GetReplenishmentDataByVendorNumber(VendorMaster item)
        //{
        //    return _VendorMasterBA.GetReplenishmentDataByVendorNumber(item);
        //}
        public IBaseEntityResponse<VendorMaster> GetGeneralDataByVendorNumber(VendorMaster item)
        {
            return _VendorMasterBA.GetGeneralDataByVendorNumber(item);
        }
        public IBaseEntityResponse<VendorMaster> InsertVendorMasterExcel(VendorMaster item)
        {
            return _VendorMasterBA.InsertVendorMasterExcel(item);
        }
        public IBaseEntityCollectionResponse<VendorMaster> GetContactPersonDetailsForVendorMaster(VendorMasterSearchRequest searchRequest)
        {
            return _VendorMasterBA.GetContactPersonDetailsForVendorMaster(searchRequest);
        }
        public IBaseEntityCollectionResponse<VendorMaster> GetReplenishmentDataByVendorNumber(VendorMasterSearchRequest searchRequest)
        {
            return _VendorMasterBA.GetReplenishmentDataByVendorNumber(searchRequest);
        }
        public IBaseEntityResponse<VendorMaster> GetFinanceDataByVendorNumber(VendorMaster item)
        {
            return _VendorMasterBA.GetFinanceDataByVendorNumber(item);
        }
        public IBaseEntityResponse<VendorMaster> GetDataValidationListsForExcel(VendorMaster item)
        {
            return _VendorMasterBA.GetDataValidationListsForExcel(item);
        }
    }
}
