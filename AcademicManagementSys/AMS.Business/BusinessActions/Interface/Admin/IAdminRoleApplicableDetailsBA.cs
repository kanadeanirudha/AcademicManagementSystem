using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessAction
{
    public interface IAdminRoleApplicableDetailsBA
    {
        IBaseEntityResponse<AdminRoleApplicableDetails> InsertAdminRoleApplicableDetails(AdminRoleApplicableDetails item);

        IBaseEntityResponse<AdminRoleApplicableDetails> UpdateAdminRoleApplicableDetails(AdminRoleApplicableDetails item);

        IBaseEntityResponse<AdminRoleApplicableDetails> DeleteAdminRoleApplicableDetails(AdminRoleApplicableDetails item);

        IBaseEntityCollectionResponse<AdminRoleApplicableDetails> GetBySearch(AdminRoleApplicableDetailsSearchRequest searchRequest);

        IBaseEntityCollectionResponse<AdminRoleApplicableDetails> GetAdminRegularListBySearch(AdminRoleApplicableDetailsSearchRequest searchRequest);

        IBaseEntityCollectionResponse<AdminRoleApplicableDetails> GetAdminAdditionalListBySearch(AdminRoleApplicableDetailsSearchRequest searchRequest);

        IBaseEntityCollectionResponse<AdminRoleApplicableDetails> GetRoleListForLoginUserIDBySearch(AdminRoleApplicableDetailsSearchRequest searchRequest);

        IBaseEntityCollectionResponse<AdminRoleApplicableDetails> GetStudyCentreListByAdminRoleMasterID(AdminRoleApplicableDetailsSearchRequest searchRequest);

        IBaseEntityCollectionResponse<AdminRoleApplicableDetails> GetStudyCentreListForAcademicManagerByAdminRoleMasterID(AdminRoleApplicableDetailsSearchRequest searchRequest);

        IBaseEntityCollectionResponse<AdminRoleApplicableDetails> GetStudyCentreListForFinanceManagerByAdminRoleMasterID(AdminRoleApplicableDetailsSearchRequest searchRequest);

        IBaseEntityResponse<AdminRoleApplicableDetails> SelectActiveAdminRoleCodeByEmployeeID(AdminRoleApplicableDetails item);

        IBaseEntityResponse<AdminRoleApplicableDetails> SelectByID(AdminRoleApplicableDetails item);

    }
}
