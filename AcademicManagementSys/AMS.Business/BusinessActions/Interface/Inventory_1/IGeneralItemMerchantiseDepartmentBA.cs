using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IGeneralItemMerchantiseDepartmentBA
    {
        IBaseEntityResponse<GeneralItemMerchantiseDepartment> InsertGeneralItemMerchantiseDepartment(GeneralItemMerchantiseDepartment item);
        IBaseEntityResponse<GeneralItemMerchantiseDepartment> UpdateGeneralItemMerchantiseDepartment(GeneralItemMerchantiseDepartment item);
        IBaseEntityResponse<GeneralItemMerchantiseDepartment> DeleteGeneralItemMerchantiseDepartment(GeneralItemMerchantiseDepartment item);
        IBaseEntityCollectionResponse<GeneralItemMerchantiseDepartment> GetBySearch(GeneralItemMerchantiseDepartmentSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralItemMerchantiseDepartment> GetGeneralItemMerchantiseDepartmentSearchList(GeneralItemMerchantiseDepartmentSearchRequest searchRequest);
        IBaseEntityResponse<GeneralItemMerchantiseDepartment> SelectByID(GeneralItemMerchantiseDepartment item);
        IBaseEntityCollectionResponse<GeneralItemMerchantiseDepartment> GetGeneralItemMerchantiseDepartmentCodeByGroupCode(GeneralItemMerchantiseDepartmentSearchRequest searchRequest);
    }
}

