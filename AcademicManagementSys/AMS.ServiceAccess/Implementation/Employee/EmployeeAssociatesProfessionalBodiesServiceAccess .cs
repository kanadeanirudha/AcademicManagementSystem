using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class EmployeeAssociatesProfessionalBodiesServiceAccess : IEmployeeAssociatesProfessionalBodiesServiceAccess
    {
        IEmployeeAssociatesProfessionalBodiesBA _employeeAssociatesProfessionalBodiesBA = null;
        public EmployeeAssociatesProfessionalBodiesServiceAccess()
        {
            _employeeAssociatesProfessionalBodiesBA = new EmployeeAssociatesProfessionalBodiesBA();
        }
        public IBaseEntityResponse<EmployeeAssociatesProfessionalBodies> InsertEmployeeAssociatesProfessionalBodies(EmployeeAssociatesProfessionalBodies item)
        {
            return _employeeAssociatesProfessionalBodiesBA.InsertEmployeeAssociatesProfessionalBodies(item);
        }
        public IBaseEntityResponse<EmployeeAssociatesProfessionalBodies> UpdateEmployeeAssociatesProfessionalBodies(EmployeeAssociatesProfessionalBodies item)
        {
            return _employeeAssociatesProfessionalBodiesBA.UpdateEmployeeAssociatesProfessionalBodies(item);
        }
        public IBaseEntityResponse<EmployeeAssociatesProfessionalBodies> DeleteEmployeeAssociatesProfessionalBodies(EmployeeAssociatesProfessionalBodies item)
        {
            return _employeeAssociatesProfessionalBodiesBA.DeleteEmployeeAssociatesProfessionalBodies(item);
        }
        public IBaseEntityCollectionResponse<EmployeeAssociatesProfessionalBodies> GetBySearch(EmployeeAssociatesProfessionalBodiesSearchRequest searchRequest)
        {
            return _employeeAssociatesProfessionalBodiesBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<EmployeeAssociatesProfessionalBodies> SelectByID(EmployeeAssociatesProfessionalBodies item)
        {
            return _employeeAssociatesProfessionalBodiesBA.SelectByID(item);
        }
    }
}
