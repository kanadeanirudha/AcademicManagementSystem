using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class ToolTemplateRegistrationServiceAccess : IToolTemplateRegistrationServiceAccess
    {
        IToolTemplateRegistrationBA _ToolTemplateRegistrationBA = null;
        public ToolTemplateRegistrationServiceAccess()
        {
            _ToolTemplateRegistrationBA = new ToolTemplateRegistrationBA();
        }
        public IBaseEntityResponse<ToolTemplateRegistration> InsertToolTemplateRegistration(ToolTemplateRegistration item)
        {
            return _ToolTemplateRegistrationBA.InsertToolTemplateRegistration(item);
        }
        public IBaseEntityResponse<ToolTemplateRegistration> UpdateToolTemplateRegistration(ToolTemplateRegistration item)
        {
            return _ToolTemplateRegistrationBA.UpdateToolTemplateRegistration(item);
        }
        public IBaseEntityResponse<ToolTemplateRegistration> DeleteToolTemplateRegistration(ToolTemplateRegistration item)
        {
            return _ToolTemplateRegistrationBA.DeleteToolTemplateRegistration(item);
        }
        public IBaseEntityCollectionResponse<ToolTemplateRegistration> GetBySearch(ToolTemplateRegistrationSearchRequest searchRequest)
        {
            return _ToolTemplateRegistrationBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<ToolTemplateRegistration> SelectByID(ToolTemplateRegistration item)
        {
            return _ToolTemplateRegistrationBA.SelectByID(item);
        }
        public IBaseEntityCollectionResponse<ToolTemplateRegistration> GetByToolRegistrationFieldList(ToolTemplateRegistrationSearchRequest searchRequest)
        {
            return _ToolTemplateRegistrationBA.GetByToolRegistrationFieldList(searchRequest);
        }
    }
}
