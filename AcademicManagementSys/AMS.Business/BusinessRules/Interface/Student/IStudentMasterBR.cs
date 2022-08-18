using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
	public interface IStudentMasterBR
	{
		IValidateBusinessRuleResponse InsertStudentMasterValidate(StudentMaster item);
		IValidateBusinessRuleResponse UpdateStudentMasterValidate(StudentMaster item);
		IValidateBusinessRuleResponse DeleteStudentMasterValidate(StudentMaster item);
	}
}
