using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class StudentReportCardViewModel
    {
        public StudentReportCardViewModel()
        {
            StudentReportCardDTO = new StudentReportCard();
        }

        public StudentReportCard StudentReportCardDTO { get; set; }

        public Int16 ID
        {
            get
            {
                return (StudentReportCardDTO != null && StudentReportCardDTO.ID > 0) ? StudentReportCardDTO.ID : new Int16();
            }
            set
            {
                StudentReportCardDTO.ID = value;
            }
        }
 
    }

}

