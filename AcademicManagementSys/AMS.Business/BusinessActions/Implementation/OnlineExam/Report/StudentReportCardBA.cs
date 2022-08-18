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

namespace AMS.Business.BusinessActions
{
    public class StudentReportCardBA : IStudentReportCardBA
    {
        IStudentReportCardDataProvider _StudentReportCardDataProvider;
        private ILogger _logException;
        public StudentReportCardBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _StudentReportCardDataProvider = new StudentReportCardDataProvider();
        }

        public IBaseEntityCollectionResponse<StudentReportCard> GetStudentReportCardData(StudentReportCardSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<StudentReportCard> StudentReportCardCollection = new BaseEntityCollectionResponse<StudentReportCard>();
            try
            {
                if (_StudentReportCardDataProvider != null)
                    StudentReportCardCollection = _StudentReportCardDataProvider.GetStudentReportCardData(searchRequest);
                else
                {
                    StudentReportCardCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    StudentReportCardCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                StudentReportCardCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                StudentReportCardCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return StudentReportCardCollection;
        }
    }
}
