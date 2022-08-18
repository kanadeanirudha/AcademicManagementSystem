using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IGeneralItemMerchantiseDepartmentServiceAccess
    {
        IBaseEntityResponse<GeneralItemMerchantiseDepartment> InsertGeneralItemMerchantiseDepartment(GeneralItemMerchantiseDepartment item);
        IBaseEntityResponse<GeneralItemMerchantiseDepartment> UpdateGeneralItemMerchantiseDepartment(GeneralItemMerchantiseDepartment item);
        IBaseEntityResponse<GeneralItemMerchantiseDepartment> DeleteGeneralItemMerchantiseDepartment(GeneralItemMerchantiseDepartment item);
        IBaseEntityCollectionResponse<GeneralItemMerchantiseDepartment> GetBySearch(GeneralItemMerchantiseDepartmentSearchRequest searchRequest);
        IBaseEntityResponse<GeneralItemMerchantiseDepartment> SelectByID(GeneralItemMerchantiseDepartment item);
        IBaseEntityCollectionResponse<GeneralItemMerchantiseDepartment> GetGeneralItemMerchantiseDepartmentSearchList(GeneralItemMerchantiseDepartmentSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralItemMerchantiseDepartment> GetGeneralItemMerchantiseDepartmentCodeByGroupCode(GeneralItemMerchantiseDepartmentSearchRequest searchRequest);


    }
}
