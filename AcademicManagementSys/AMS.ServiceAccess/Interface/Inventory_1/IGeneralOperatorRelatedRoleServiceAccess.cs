using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
    public interface IGeneralOperatorRelatedRoleServiceAccess
    {
        IBaseEntityResponse<GeneralOperatorRelatedRole> InsertGeneralOperatorRelatedRole(GeneralOperatorRelatedRole item);
        IBaseEntityResponse<GeneralOperatorRelatedRole> UpdateGeneralOperatorRelatedRole(GeneralOperatorRelatedRole item);
        IBaseEntityResponse<GeneralOperatorRelatedRole> DeleteGeneralOperatorRelatedRole(GeneralOperatorRelatedRole item);
        IBaseEntityCollectionResponse<GeneralOperatorRelatedRole> GetBySearch(GeneralOperatorRelatedRoleSearchRequest searchRequest);
        IBaseEntityResponse<GeneralOperatorRelatedRole> SelectByID(GeneralOperatorRelatedRole item);
        IBaseEntityCollectionResponse<GeneralOperatorRelatedRole> GetGeneralOperatorRelatedRoleList(GeneralOperatorRelatedRoleSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralOperatorRelatedRole> GetAdminRoleCodeList(GeneralOperatorRelatedRoleSearchRequest searchRequest);
    }
}
