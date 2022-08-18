using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IToolTemplateRegistrationDataProvider
    {
        IBaseEntityResponse<ToolTemplateRegistration> InsertToolTemplateRegistration(ToolTemplateRegistration item);
        IBaseEntityResponse<ToolTemplateRegistration> UpdateToolTemplateRegistration(ToolTemplateRegistration item);
        IBaseEntityResponse<ToolTemplateRegistration> DeleteToolTemplateRegistration(ToolTemplateRegistration item);
        IBaseEntityCollectionResponse<ToolTemplateRegistration> GetToolTemplateRegistrationBySearch(ToolTemplateRegistrationSearchRequest searchRequest);
        IBaseEntityResponse<ToolTemplateRegistration> GetToolTemplateRegistrationByID(ToolTemplateRegistration item);

        IBaseEntityCollectionResponse<ToolTemplateRegistration> GetToolTemplateRegistrationFieldBySearchList(ToolTemplateRegistrationSearchRequest searchRequest);
    }
}
