using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceAccess
{
	public interface IStudentMasterServiceAccess
	{
		IBaseEntityResponse<StudentMaster> InsertStudentMaster(StudentMaster item);
		IBaseEntityResponse<StudentMaster> UpdateStudentMaster(StudentMaster item);
		IBaseEntityResponse<StudentMaster> DeleteStudentMaster(StudentMaster item);
        IBaseEntityCollectionResponse<StudentMaster> GetStudentSearchList(StudentMasterSearchRequest searchRequest);
		IBaseEntityCollectionResponse<StudentMaster> GetBySearch(StudentMasterSearchRequest searchRequest);
		IBaseEntityResponse<StudentMaster> SelectByID(StudentMaster item);
        IBaseEntityResponse<StudentMaster> GetStudentDetails(StudentMaster item);
        IBaseEntityResponse<StudentMaster> GetStudentCentreByID(StudentMaster item);
        IBaseEntityResponse<StudentMaster> GetCentreFromStudentMasterByStudentID(StudentMaster item);
        IBaseEntityCollectionResponse<StudentMaster> GetStudentAdmissionCancel(StudentMasterSearchRequest searchRequest);
	}
}
