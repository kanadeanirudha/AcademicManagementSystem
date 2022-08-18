using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;

namespace AMS.ServiceAccess
{
    public class AdminRoleApplicableDetailsServiceAccess : IAdminRoleApplicableDetailsServiceAccess
    {
        IAdminRoleApplicableDetailsBA _adminRoleApplicableDetailsBA = null;

        public AdminRoleApplicableDetailsServiceAccess()
        {
            _adminRoleApplicableDetailsBA = new AdminRoleApplicableDetailsBA();
        }

        public IBaseEntityResponse<AdminRoleApplicableDetails> InsertAdminRoleApplicableDetails(AdminRoleApplicableDetails item)
        {
            return _adminRoleApplicableDetailsBA.InsertAdminRoleApplicableDetails(item);
        }

        public IBaseEntityResponse<AdminRoleApplicableDetails> UpdateAdminRoleApplicableDetails(AdminRoleApplicableDetails item)
        {
            return _adminRoleApplicableDetailsBA.UpdateAdminRoleApplicableDetails(item);
        }

        public IBaseEntityResponse<AdminRoleApplicableDetails> DeleteAdminRoleApplicableDetails(AdminRoleApplicableDetails item)
        {
            return _adminRoleApplicableDetailsBA.DeleteAdminRoleApplicableDetails(item);
        }

        public IBaseEntityCollectionResponse<AdminRoleApplicableDetails> GetBySearch(AdminRoleApplicableDetailsSearchRequest searchRequest)
        {
            return _adminRoleApplicableDetailsBA.GetBySearch(searchRequest);
        }


        public IBaseEntityResponse<AdminRoleApplicableDetails> SelectByID(AdminRoleApplicableDetails item)
        {
            return _adminRoleApplicableDetailsBA.SelectByID(item);
        }

        public IBaseEntityCollectionResponse<AdminRoleApplicableDetails> GetAdminRegularListBySearch(AdminRoleApplicableDetailsSearchRequest searchRequest)
        {
            return _adminRoleApplicableDetailsBA.GetAdminRegularListBySearch(searchRequest);
        }

        public IBaseEntityCollectionResponse<AdminRoleApplicableDetails> GetAdminAdditionalListBySearch(AdminRoleApplicableDetailsSearchRequest searchRequest)
        {
            return _adminRoleApplicableDetailsBA.GetAdminAdditionalListBySearch(searchRequest);
        }

        //for getting role list according to the login user id
        public IBaseEntityCollectionResponse<AdminRoleApplicableDetails> GetRoleListForLoginUserIDBySearch(AdminRoleApplicableDetailsSearchRequest searchRequest)
        {
            return _adminRoleApplicableDetailsBA.GetRoleListForLoginUserIDBySearch(searchRequest);
        }

        public IBaseEntityCollectionResponse<AdminRoleApplicableDetails> GetStudyCentreListByAdminRoleMasterID(AdminRoleApplicableDetailsSearchRequest searchRequest)
        {
            return _adminRoleApplicableDetailsBA.GetStudyCentreListByAdminRoleMasterID(searchRequest);
        }

        public IBaseEntityCollectionResponse<AdminRoleApplicableDetails> GetStudyCentreListForAcademicManagerByAdminRoleMasterID(AdminRoleApplicableDetailsSearchRequest searchRequest)
        {
            return _adminRoleApplicableDetailsBA.GetStudyCentreListForAcademicManagerByAdminRoleMasterID(searchRequest);
        }
        public IBaseEntityCollectionResponse<AdminRoleApplicableDetails> GetStudyCentreListForFinanceManagerByAdminRoleMasterID(AdminRoleApplicableDetailsSearchRequest searchRequest)
        {
            return _adminRoleApplicableDetailsBA.GetStudyCentreListForFinanceManagerByAdminRoleMasterID(searchRequest);
        }

        public IBaseEntityResponse<AdminRoleApplicableDetails> SelectActiveAdminRoleCodeByEmployeeID(AdminRoleApplicableDetails item)
        {
            return _adminRoleApplicableDetailsBA.SelectActiveAdminRoleCodeByEmployeeID(item);
        }
    }
}
