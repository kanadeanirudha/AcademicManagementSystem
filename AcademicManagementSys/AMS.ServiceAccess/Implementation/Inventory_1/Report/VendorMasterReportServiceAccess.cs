
using System;
using System.Collections.Generic;
using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class VendorMasterReportServiceAccess : IVendorMasterReportServiceAccess
    {
        IVendorMasterReportBA _VendorMasterReportBA = null;
        public VendorMasterReportServiceAccess()
        {
            _VendorMasterReportBA = new VendorMasterReportBA();
        }

        public IBaseEntityCollectionResponse<VendorMasterReport> GetVendorMasterReportBySearch_AllVendorList(VendorMasterReportSearchRequest searchRequest)
        {
            return _VendorMasterReportBA.GetVendorMasterReportBySearch_AllVendorList(searchRequest);
        }

        public IBaseEntityCollectionResponse<VendorMasterReport> GetVendorMasterReportBySearch_ItemList(VendorMasterReportSearchRequest searchRequest)
        {
            return _VendorMasterReportBA.GetVendorMasterReportBySearch_ItemList(searchRequest);
        }
    }
}
