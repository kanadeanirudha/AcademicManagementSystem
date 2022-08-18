using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class StudentIdentityCardServiceAccess : IStudentIdentityCardServiceAccess
    {
        IStudentIdentityCardBA _studentIdentityCardBA = null;
        public StudentIdentityCardServiceAccess()
        {
            _studentIdentityCardBA = new StudentIdentityCardBA();
        }
        public IBaseEntityResponse<StudentIdentityCard> InsertStudentIdentityCard(StudentIdentityCard item)
        {
            return _studentIdentityCardBA.InsertStudentIdentityCard(item);
        }
        public IBaseEntityResponse<StudentIdentityCard> UpdateStudentIdentityCard(StudentIdentityCard item)
        {
            return _studentIdentityCardBA.UpdateStudentIdentityCard(item);
        }
        public IBaseEntityResponse<StudentIdentityCard> DeleteStudentIdentityCard(StudentIdentityCard item)
        {
            return _studentIdentityCardBA.DeleteStudentIdentityCard(item);
        }
        public IBaseEntityCollectionResponse<StudentIdentityCard> GetBySearch(StudentIdentityCardSearchRequest searchRequest)
        {
            return _studentIdentityCardBA.GetBySearch(searchRequest);
        }
        public IBaseEntityResponse<StudentIdentityCard> SelectByID(StudentIdentityCard item)
        {
            return _studentIdentityCardBA.SelectByID(item);
        }
    }
}
