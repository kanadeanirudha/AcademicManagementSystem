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
    public class StudentIdentityCardBA : IStudentIdentityCardBA
    {
        IStudentIdentityCardDataProvider _studentIdentityCardDataProvider;
        IStudentIdentityCardBR _studentIdentityCardBR;
        private ILogger _logException;
        public StudentIdentityCardBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _studentIdentityCardBR = new StudentIdentityCardBR();
            _studentIdentityCardDataProvider = new StudentIdentityCardDataProvider();
        }
        /// <summary>
        /// Create new record of StudentIdentityCard.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<StudentIdentityCard> InsertStudentIdentityCard(StudentIdentityCard item)
        {
            IBaseEntityResponse<StudentIdentityCard> entityResponse = new BaseEntityResponse<StudentIdentityCard>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _studentIdentityCardBR.InsertStudentIdentityCardValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _studentIdentityCardDataProvider.InsertStudentIdentityCard(item);
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
        /// Update a specific record  of StudentIdentityCard.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<StudentIdentityCard> UpdateStudentIdentityCard(StudentIdentityCard item)
        {
            IBaseEntityResponse<StudentIdentityCard> entityResponse = new BaseEntityResponse<StudentIdentityCard>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _studentIdentityCardBR.UpdateStudentIdentityCardValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _studentIdentityCardDataProvider.UpdateStudentIdentityCard(item);
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
        /// Delete a selected record from StudentIdentityCard.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<StudentIdentityCard> DeleteStudentIdentityCard(StudentIdentityCard item)
        {
            IBaseEntityResponse<StudentIdentityCard> entityResponse = new BaseEntityResponse<StudentIdentityCard>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _studentIdentityCardBR.DeleteStudentIdentityCardValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _studentIdentityCardDataProvider.DeleteStudentIdentityCard(item);
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
        /// Select all record from StudentIdentityCard table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<StudentIdentityCard> GetBySearch(StudentIdentityCardSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<StudentIdentityCard> StudentIdentityCardCollection = new BaseEntityCollectionResponse<StudentIdentityCard>();
            try
            {
                if (_studentIdentityCardDataProvider != null)
                    StudentIdentityCardCollection = _studentIdentityCardDataProvider.GetStudentIdentityCardBySearch(searchRequest);
                else
                {
                    StudentIdentityCardCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    StudentIdentityCardCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                StudentIdentityCardCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                StudentIdentityCardCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return StudentIdentityCardCollection;
        }
        /// <summary>
        /// Select a record from StudentIdentityCard table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<StudentIdentityCard> SelectByID(StudentIdentityCard item)
        {
            IBaseEntityResponse<StudentIdentityCard> entityResponse = new BaseEntityResponse<StudentIdentityCard>();
            try
            {
                entityResponse = _studentIdentityCardDataProvider.GetStudentIdentityCardByID(item);
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
