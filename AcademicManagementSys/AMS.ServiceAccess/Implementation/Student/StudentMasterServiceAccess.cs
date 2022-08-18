using AMS.Base.DTO;
using AMS.Business;
using AMS.DTO;
namespace AMS.ServiceAccess
{
	public class StudentMasterServiceAccess : IStudentMasterServiceAccess
	{
		IStudentMasterBA _StudentMasterBA = null;
		public StudentMasterServiceAccess()
		{
			_StudentMasterBA = new StudentMasterBA();
		}
		public IBaseEntityResponse<StudentMaster> InsertStudentMaster(StudentMaster item)
		{
			return _StudentMasterBA.InsertStudentMaster(item);
		}
		public IBaseEntityResponse<StudentMaster> UpdateStudentMaster(StudentMaster item)
		{
			return _StudentMasterBA.UpdateStudentMaster(item);
		}
		public IBaseEntityResponse<StudentMaster> DeleteStudentMaster(StudentMaster item)
		{
			return _StudentMasterBA.DeleteStudentMaster(item);
		}
        public IBaseEntityCollectionResponse<StudentMaster> GetStudentSearchList(StudentMasterSearchRequest searchRequest)
        {
            return _StudentMasterBA.GetStudentSearchList(searchRequest);
        }
		public IBaseEntityCollectionResponse<StudentMaster> GetBySearch(StudentMasterSearchRequest searchRequest)
		{
			return _StudentMasterBA.GetBySearch(searchRequest);
		}
		public IBaseEntityResponse<StudentMaster> SelectByID(StudentMaster item)
		{
			return _StudentMasterBA.SelectByID(item);
		}
        public IBaseEntityResponse<StudentMaster> GetStudentDetails(StudentMaster item)
		{
            return _StudentMasterBA.GetStudentDetails(item);
		}
        public IBaseEntityResponse<StudentMaster> GetStudentCentreByID(StudentMaster item)
		{
            return _StudentMasterBA.GetStudentCentreByID(item);
		}
        public IBaseEntityResponse<StudentMaster> GetCentreFromStudentMasterByStudentID(StudentMaster item)
		{
            return _StudentMasterBA.GetCentreFromStudentMasterByStudentID(item);
		}
        public IBaseEntityCollectionResponse<StudentMaster> GetStudentAdmissionCancel(StudentMasterSearchRequest searchRequest)
        {
            return _StudentMasterBA.GetStudentAdmissionCancel(searchRequest);
        }
        
	}
}
