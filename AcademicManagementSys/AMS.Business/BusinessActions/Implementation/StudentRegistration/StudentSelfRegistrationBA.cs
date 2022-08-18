using AMS.Base.DTO;
using AMS.Business.BusinessRules;
using AMS.Common;
using AMS.DataProvider;
using AMS.DTO;
using AMS.ExceptionManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
    public class StudentSelfRegistrationBA : IStudentSelfRegistrationBA
    {
        IGeneralCasteMasterDataProvider _GeneralCasteMasterDataProvider;
        IGeneralCountryMasterDataProvider _GeneralCountryMasterDataProvider; 
        IStudentSelfRegistrationDataProvider _StudentSelfRegistrationDataProvider;
        IStudentSelfRegistrationBR _StudentSelfRegistrationBR;
        private ILogger _logException;
        public StudentSelfRegistrationBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _StudentSelfRegistrationBR = new StudentSelfRegistrationBR();
            _StudentSelfRegistrationDataProvider = new StudentSelfRegistrationDataProvider();
        }
        /// <summary>
        /// Create new record of StudentSelfRegistration.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<StudentSelfRegistration> InsertStudentSelfRegistration(StudentSelfRegistration item)
        {
            IBaseEntityResponse<StudentSelfRegistration> entityResponse = new BaseEntityResponse<StudentSelfRegistration>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _StudentSelfRegistrationBR.InsertStudentSelfRegistrationValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _StudentSelfRegistrationDataProvider.InsertStudentSelfRegistration(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null; ;
                }
            }
            catch (Exception ex)
            {
                entityResponse.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                entityResponse.Entity = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return entityResponse;
        }
        /// <summary>
        /// Update a specific record  of StudentSelfRegistration.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<StudentSelfRegistration> UpdateStudentSelfRegistration(StudentSelfRegistration item)
        {
            IBaseEntityResponse<StudentSelfRegistration> entityResponse = new BaseEntityResponse<StudentSelfRegistration>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _StudentSelfRegistrationBR.UpdateStudentSelfRegistrationValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _StudentSelfRegistrationDataProvider.UpdateStudentSelfRegistration(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null; ;
                }
            }
            catch (Exception ex)
            {
                entityResponse.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                entityResponse.Entity = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return entityResponse;
        }
        /// <summary>
        /// Delete a selected record from StudentSelfRegistration.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<StudentSelfRegistration> DeleteStudentSelfRegistration(StudentSelfRegistration item)
        {
            IBaseEntityResponse<StudentSelfRegistration> entityResponse = new BaseEntityResponse<StudentSelfRegistration>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _StudentSelfRegistrationBR.DeleteStudentSelfRegistrationValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _StudentSelfRegistrationDataProvider.DeleteStudentSelfRegistration(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null; ;
                }
            }
            catch (Exception ex)
            {
                entityResponse.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                entityResponse.Entity = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return entityResponse;
        }
        public IBaseEntityCollectionResponse<GeneralCountryMaster> GetBySearchList(GeneralCountryMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralCountryMaster> categoryMasterCollection = new BaseEntityCollectionResponse<GeneralCountryMaster>();
            try
            {
                if (_GeneralCountryMasterDataProvider != null)
                {
                    categoryMasterCollection = _GeneralCountryMasterDataProvider.GetGeneralCountryMasterGetBySearchList(searchRequest);
                }
                else
                {
                    categoryMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    categoryMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                categoryMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                categoryMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return categoryMasterCollection;
        }

        /// <summary>
        /// Select all record from StudentSelfRegistration table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<StudentSelfRegistration> GetBySearch(StudentSelfRegistrationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<StudentSelfRegistration> StudentSelfRegistrationCollection = new BaseEntityCollectionResponse<StudentSelfRegistration>();
            try
            {
                if (_StudentSelfRegistrationDataProvider != null)
                    StudentSelfRegistrationCollection = _StudentSelfRegistrationDataProvider.GetStudentSelfRegistrationBySearch(searchRequest);
                else
                {
                    StudentSelfRegistrationCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    StudentSelfRegistrationCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                StudentSelfRegistrationCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                StudentSelfRegistrationCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return StudentSelfRegistrationCollection;
        }
        /// <summary>
        /// Select a record from StudentSelfRegistration table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// 

        public IBaseEntityCollectionResponse<StudentSelfRegistration> GetListOrgStudyCentreMasterOfApplicableToStudentTemplate(StudentSelfRegistrationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<StudentSelfRegistration> StudentSelfRegistrationCollection = new BaseEntityCollectionResponse<StudentSelfRegistration>();
            try
            {
                if (_StudentSelfRegistrationDataProvider != null)
                    StudentSelfRegistrationCollection = _StudentSelfRegistrationDataProvider.GetListOrgStudyCentreMasterOfApplicableToStudentTemplate(searchRequest);
                else
                {
                    StudentSelfRegistrationCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    StudentSelfRegistrationCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                StudentSelfRegistrationCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                StudentSelfRegistrationCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return StudentSelfRegistrationCollection;
        }

        public IBaseEntityCollectionResponse<StudentSelfRegistration> GetListBranchDetailsOfApplicableToStudentTemplate(StudentSelfRegistrationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<StudentSelfRegistration> StudentSelfRegistrationCollection = new BaseEntityCollectionResponse<StudentSelfRegistration>();
            try
            {
                if (_StudentSelfRegistrationDataProvider != null)
                    StudentSelfRegistrationCollection = _StudentSelfRegistrationDataProvider.GetListBranchDetailsOfApplicableToStudentTemplate(searchRequest);
                else
                {
                    StudentSelfRegistrationCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    StudentSelfRegistrationCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                StudentSelfRegistrationCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                StudentSelfRegistrationCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return StudentSelfRegistrationCollection;
        }


        public IBaseEntityCollectionResponse<StudentSelfRegistration> GetListStandardNumberOfApplicableToStudentTemplate(StudentSelfRegistrationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<StudentSelfRegistration> StudentSelfRegistrationCollection = new BaseEntityCollectionResponse<StudentSelfRegistration>();
            try
            {
                if (_StudentSelfRegistrationDataProvider != null)
                    StudentSelfRegistrationCollection = _StudentSelfRegistrationDataProvider.GetListStandardNumberOfApplicableToStudentTemplate(searchRequest);
                else
                {
                    StudentSelfRegistrationCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    StudentSelfRegistrationCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                StudentSelfRegistrationCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                StudentSelfRegistrationCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return StudentSelfRegistrationCollection;
        }

        public IBaseEntityResponse<StudentSelfRegistration> SelectByStudentEmailIDPassword(StudentSelfRegistration item)
        {
            IBaseEntityResponse<StudentSelfRegistration> entityResponse = new BaseEntityResponse<StudentSelfRegistration>();
            try
            {
                entityResponse = _StudentSelfRegistrationDataProvider.SelectByStudentEmailIDPassword(item);
            }
            catch (Exception ex)
            {
                entityResponse.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                entityResponse.Entity = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return entityResponse;
        }
    }
}
