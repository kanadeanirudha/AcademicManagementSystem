using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
	public interface IStudentReadmissionBR
	{
		IValidateBusinessRuleResponse InsertStudentReadmissionValidate(StudentReadmission item);
		IValidateBusinessRuleResponse UpdateStudentReadmissionValidate(StudentReadmission item);
		IValidateBusinessRuleResponse DeleteStudentReadmissionValidate(StudentReadmission item);
	}
}
