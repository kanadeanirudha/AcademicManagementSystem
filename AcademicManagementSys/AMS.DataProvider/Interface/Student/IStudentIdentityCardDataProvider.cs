using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IStudentIdentityCardDataProvider
    {
        IBaseEntityResponse<StudentIdentityCard> InsertStudentIdentityCard(StudentIdentityCard item);
        IBaseEntityResponse<StudentIdentityCard> UpdateStudentIdentityCard(StudentIdentityCard item);
        IBaseEntityResponse<StudentIdentityCard> DeleteStudentIdentityCard(StudentIdentityCard item);
        IBaseEntityCollectionResponse<StudentIdentityCard> GetStudentIdentityCardBySearch(StudentIdentityCardSearchRequest searchRequest);
        IBaseEntityResponse<StudentIdentityCard> GetStudentIdentityCardByID(StudentIdentityCard item);
    }
}
