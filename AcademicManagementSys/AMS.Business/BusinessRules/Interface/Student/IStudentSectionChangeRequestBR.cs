using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
	public interface IStudentSectionChangeRequestBR
	{
		IValidateBusinessRuleResponse InsertStudentSectionChangeRequestValidate(StudentSectionChangeRequest item);
		IValidateBusinessRuleResponse UpdateStudentSectionChangeRequestValidate(StudentSectionChangeRequest item);
		IValidateBusinessRuleResponse DeleteStudentSectionChangeRequestValidate(StudentSectionChangeRequest item);
	}
}
