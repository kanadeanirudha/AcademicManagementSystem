using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataProvider
{
    public interface IVendorMasterReportDataProvider
    {
         IBaseEntityCollectionResponse<VendorMasterReport> GetVendorMasterReportBySearch_AllVendorList(VendorMasterReportSearchRequest searchRequest);
         IBaseEntityCollectionResponse<VendorMasterReport> GetVendorMasterReportBySearch_ItemList(VendorMasterReportSearchRequest searchRequest);
    }
}
