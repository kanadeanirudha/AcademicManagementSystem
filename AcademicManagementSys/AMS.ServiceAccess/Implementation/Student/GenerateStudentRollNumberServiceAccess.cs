using AMS.Base.DTO;
using AMS.Business.BusinessAction;
using AMS.DTO;
namespace AMS.ServiceAccess
{
    public class GenerateStudentRollNumberServiceAccess : IGenerateStudentRollNumberServiceAccess
    {
        IGenerateStudentRollNumberBA _GenerateStudentRollNumberBA = null;
        public GenerateStudentRollNumberServiceAccess()
        {
            _GenerateStudentRollNumberBA = new GenerateStudentRollNumberBA();
        }
        public IBaseEntityResponse<GenerateStudentRollNumber> InsertGenerateStudentRollNumber(GenerateStudentRollNumber item)
        {
            return _GenerateStudentRollNumberBA.InsertGenerateStudentRollNumber(item);
        }
        public IBaseEntityResponse<GenerateStudentRollNumber> UpdateGenerateStudentRollNumber(GenerateStudentRollNumber item)
        {
            return _GenerateStudentRollNumberBA.UpdateGenerateStudentRollNumber(item);
        }
        public IBaseEntityResponse<GenerateStudentRollNumber> DeleteGenerateStudentRollNumber(GenerateStudentRollNumber item)
        {
            return _GenerateStudentRollNumberBA.DeleteGenerateStudentRollNumber(item);
        }
        public IBaseEntityCollectionResponse<GenerateStudentRollNumber> GetBySearch(GenerateStudentRollNumberSearchRequest searchRequest)
        {
            return _GenerateStudentRollNumberBA.GetBySearch(searchRequest);
        }
        public IBaseEntityCollectionResponse<GenerateStudentRollNumber> GetGenerateStudentRollNumberStudentListBySearch(GenerateStudentRollNumberSearchRequest searchRequest)
        {
            return _GenerateStudentRollNumberBA.GetGenerateStudentRollNumberStudentListBySearch(searchRequest);
        }
        public IBaseEntityResponse<GenerateStudentRollNumber> SelectByID(GenerateStudentRollNumber item)
        {
            return _GenerateStudentRollNumberBA.SelectByID(item);
        }
    }
}
