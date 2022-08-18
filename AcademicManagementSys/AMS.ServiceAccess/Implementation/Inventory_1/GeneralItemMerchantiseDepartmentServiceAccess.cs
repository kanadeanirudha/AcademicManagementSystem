using AMS.Base.DTO;
using AMS.Business.BusinessActions;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class GeneralItemMerchantiseDepartmentServiceAccess : IGeneralItemMerchantiseDepartmentServiceAccess
    {
        IGeneralItemMerchantiseDepartmentBA _GeneralItemMerchantiseDepartmentBA = null;
        public GeneralItemMerchantiseDepartmentServiceAccess()
        {
            _GeneralItemMerchantiseDepartmentBA = new GeneralItemMerchantiseDepartmentBA();
        }
        public IBaseEntityResponse<GeneralItemMerchantiseDepartment> InsertGeneralItemMerchantiseDepartment(GeneralItemMerchantiseDepartment item)
        {
            return _GeneralItemMerchantiseDepartmentBA.InsertGeneralItemMerchantiseDepartment(item);
        }
        public IBaseEntityResponse<GeneralItemMerchantiseDepartment> UpdateGeneralItemMerchantiseDepartment(GeneralItemMerchantiseDepartment item)
        {
            return _GeneralItemMerchantiseDepartmentBA.UpdateGeneralItemMerchantiseDepartment(item);
        }
        public IBaseEntityResponse<GeneralItemMerchantiseDepartment> DeleteGeneralItemMerchantiseDepartment(GeneralItemMerchantiseDepartment item)
        {
            return _GeneralItemMerchantiseDepartmentBA.DeleteGeneralItemMerchantiseDepartment(item);
        }
        public IBaseEntityCollectionResponse<GeneralItemMerchantiseDepartment> GetBySearch(GeneralItemMerchantiseDepartmentSearchRequest searchRequest)
        {
            return _GeneralItemMerchantiseDepartmentBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<GeneralItemMerchantiseDepartment> GetGeneralItemMerchantiseDepartmentSearchList(GeneralItemMerchantiseDepartmentSearchRequest searchRequest)
        {
            return _GeneralItemMerchantiseDepartmentBA.GetGeneralItemMerchantiseDepartmentSearchList(searchRequest);
        }
        public IBaseEntityResponse<GeneralItemMerchantiseDepartment> SelectByID(GeneralItemMerchantiseDepartment item)
        {
            return _GeneralItemMerchantiseDepartmentBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<GeneralItemMerchantiseDepartment> GetGeneralItemMerchantiseDepartmentCodeByGroupCode(GeneralItemMerchantiseDepartmentSearchRequest searchRequest)
        {
            return _GeneralItemMerchantiseDepartmentBA.GetGeneralItemMerchantiseDepartmentCodeByGroupCode(searchRequest);
        }
    }
}
