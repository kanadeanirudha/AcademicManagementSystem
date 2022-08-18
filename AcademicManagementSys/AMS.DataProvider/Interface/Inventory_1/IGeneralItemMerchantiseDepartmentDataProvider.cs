using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IGeneralItemMerchantiseDepartmentDataProvider
    {
        IBaseEntityResponse<GeneralItemMerchantiseDepartment> InsertGeneralItemMerchantiseDepartment(GeneralItemMerchantiseDepartment item);
        IBaseEntityResponse<GeneralItemMerchantiseDepartment> UpdateGeneralItemMerchantiseDepartment(GeneralItemMerchantiseDepartment item);
        IBaseEntityResponse<GeneralItemMerchantiseDepartment> DeleteGeneralItemMerchantiseDepartment(GeneralItemMerchantiseDepartment item);
        IBaseEntityCollectionResponse<GeneralItemMerchantiseDepartment> GetGeneralItemMerchantiseDepartmentBySearch(GeneralItemMerchantiseDepartmentSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralItemMerchantiseDepartment> GetGeneralItemMerchantiseDepartmentSearchList(GeneralItemMerchantiseDepartmentSearchRequest searchRequest);
        IBaseEntityResponse<GeneralItemMerchantiseDepartment> GetGeneralItemMerchantiseDepartmentByID(GeneralItemMerchantiseDepartment item);
        IBaseEntityCollectionResponse<GeneralItemMerchantiseDepartment> GetGeneralItemMerchantiseDepartmentCodeByGroupCode(GeneralItemMerchantiseDepartmentSearchRequest searchRequest);
    }
}
