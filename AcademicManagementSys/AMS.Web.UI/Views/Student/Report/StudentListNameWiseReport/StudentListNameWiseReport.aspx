<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html>
<head id="Head1" runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Student Original Branch Wise</title>
    <script runat="server">
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }
        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvStudentListNameWiseList);
            if (!IsPostBack)
            {
                List<AMS.DTO.StudentReport> studentReport = null;
                AMS.Web.UI.Controllers.StudentListNameWiseReportController controller = new AMS.Web.UI.Controllers.StudentListNameWiseReportController();

                if (Request.RequestType == "POST")
                {
                    studentReport = controller.GetListStudentListNameWiseReport();
                }

                if (studentReport == null || (Request.RequestType == "POST" && studentReport.Count == 0 ? true : false))
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;
                    NoRecordDiv.Visible = false;

                    rvStudentListNameWiseList.LocalReport.ReportPath = Server.MapPath("~/Report/Student/StudentListNameWiseReport.rdlc");
                    rvStudentListNameWiseList.LocalReport.DataSources.Clear();
                    ReportDataSource rdc = new ReportDataSource();
                    rdc.Name = "StudentListNameWiseDataSet";
                    rdc.Value = studentReport;
                    rvStudentListNameWiseList.LocalReport.DataSources.Add(rdc);

                    ReportParameter[] param = new ReportParameter[6];
                    param[0] = new ReportParameter("AcademicYear", studentReport.Count > 0 ? studentReport[0].AcademicYear : string.Empty, false);
                    param[1] = new ReportParameter("PrintingLine1", studentReport.Count > 0 ? studentReport[0].PrintingLine1 : string.Empty, false);
                    param[2] = new ReportParameter("PrintingLine2", studentReport.Count > 0 ? studentReport[0].PrintingLine2 : string.Empty, false);
                    param[3] = new ReportParameter("PrintingLine3", studentReport.Count > 0 ? studentReport[0].PrintingLine3 : string.Empty, false);
                    param[4] = new ReportParameter("PrintingLine4", studentReport.Count > 0 ? studentReport[0].PrintingLine4 : string.Empty, false);
                    param[5] = new ReportParameter("SortBy", studentReport.Count > 0 ? studentReport[0].SortByList : string.Empty, false);

                    rvStudentListNameWiseList.LocalReport.SetParameters(param);
                    rvStudentListNameWiseList.LocalReport.Refresh();
                    rvStudentListNameWiseList.Visible = true;
                }
            }
        }
       

    </script>

</head>

<body>
    <form id="Form1" runat="server">
        <div id="MainDiv" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <rsweb:ReportViewer ID="rvStudentListNameWiseList" runat="server" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="100%" SizeToReportContent="True">
                <LocalReport ReportEmbeddedResource="AMS.Web.UI.Report.Student.StudentListNameWiseReport.rdlc">
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="StudentListNameWiseDataSet" />
                    </DataSources>
                </LocalReport>
            </rsweb:ReportViewer>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="AMSDBTableAdapters.USP_StuRptNameWiseStudentListTableAdapter"></asp:ObjectDataSource>
            <br />
        </div>
        <div id="NoRecordDiv" runat="server" style="text-align: center;">
            <b>No Record Found</b>
        </div>
    </form>
</body>

</html>
