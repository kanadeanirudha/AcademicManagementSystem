using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.ServiceAccess
{
    public interface IToolTemplateRegistrationServiceAccess
    {
        IBaseEntityResponse<ToolTemplateRegistration> InsertToolTemplateRegistration(ToolTemplateRegistration item);
        IBaseEntityResponse<ToolTemplateRegistration> UpdateToolTemplateRegistration(ToolTemplateRegistration item);
        IBaseEntityResponse<ToolTemplateRegistration> DeleteToolTemplateRegistration(ToolTemplateRegistration item);
        IBaseEntityCollectionResponse<ToolTemplateRegistration> GetBySearch(ToolTemplateRegistrationSearchRequest searchRequest);
        IBaseEntityResponse<ToolTemplateRegistration> SelectByID(ToolTemplateRegistration item);

        IBaseEntityCollectionResponse<ToolTemplateRegistration> GetByToolRegistrationFieldList(ToolTemplateRegistrationSearchRequest searchRequest);
    }
}
