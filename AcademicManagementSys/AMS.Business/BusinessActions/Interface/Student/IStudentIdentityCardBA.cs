using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
    public interface IStudentIdentityCardBA
    {
        IBaseEntityResponse<StudentIdentityCard> InsertStudentIdentityCard(StudentIdentityCard item);
        IBaseEntityResponse<StudentIdentityCard> UpdateStudentIdentityCard(StudentIdentityCard item);
        IBaseEntityResponse<StudentIdentityCard> DeleteStudentIdentityCard(StudentIdentityCard item);
        IBaseEntityCollectionResponse<StudentIdentityCard> GetBySearch(StudentIdentityCardSearchRequest searchRequest);
        IBaseEntityResponse<StudentIdentityCard> SelectByID(StudentIdentityCard item);
    }
}
