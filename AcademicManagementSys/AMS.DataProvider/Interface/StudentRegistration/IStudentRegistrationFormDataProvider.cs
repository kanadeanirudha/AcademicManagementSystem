﻿using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IStudentRegistrationFormDataProvider
    {

        IBaseEntityCollectionResponse<StudentRegistrationForm> GetStudentRegistrationFormFieldBySearchList(StudentRegistrationFormSearchRequest searchRequest);
        IBaseEntityCollectionResponse<PreviousWorkExperience> GetPreviousWorkExperience(PreviousWorkExperienceSearchRequest searchRequest); 
        IBaseEntityResponse<StudentRegistrationForm> SelectByEmailIDAndPassword(StudentRegistrationForm item);
        IBaseEntityResponse<StudentRegistrationForm> SelectByID(StudentRegistrationForm item);
        
        IBaseEntityCollectionResponse<StudentRegistrationForm> GetListQualifyingExamSelectList(StudentRegistrationFormSearchRequest searchRequest);
        IBaseEntityResponse<StudentRegistrationForm> InsertStudentRegistrationForm(StudentRegistrationForm item);
        IBaseEntityResponse<StudentRegistrationForm> UpdateStudentRegistrationForm(StudentRegistrationForm item);
        
    }
}
