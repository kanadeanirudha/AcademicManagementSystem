<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html>
<head id="Head1" runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Student Identity Card</title>
    <script runat="server">
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }
        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvStudentIdentityCardReportList);
            if (!IsPostBack)
            {
                List<AMS.DTO.StudentReport> studentReport = null;
                AMS.Web.UI.Controllers.StudentIdentityCardReportController controller = new AMS.Web.UI.Controllers.StudentIdentityCardReportController();
                string IcardView = string.Empty;
                if (Request.RequestType == "POST")
                {
                    studentReport = controller.GetListStudentIdentityCardReport(out IcardView);
                }

                if (studentReport == null || studentReport.Count == 0)
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;
                    NoRecordDiv.Visible = false;
                    if (IcardView == "F")
                    {
                        rvStudentIdentityCardReportList.LocalReport.ReportPath = Server.MapPath("~/Report/Student/StudentIdentityCardFrontReport.rdlc");
                        rvStudentIdentityCardReportList.LocalReport.ReportEmbeddedResource = "AMS.Web.UI.Report.StudentIdentityCardFrontReport.rdlc";
                    }
                    else
                    {
                        rvStudentIdentityCardReportList.LocalReport.ReportPath = Server.MapPath("~/Report/Student/StudentIdentityCardBackReport.rdlc");
                        rvStudentIdentityCardReportList.LocalReport.ReportEmbeddedResource = "AMS.Web.UI.Report.StudentIdentityCardBackReport.rdlc";
                    }
                    rvStudentIdentityCardReportList.LocalReport.DataSources.Clear();
                    ReportDataSource rdc = new ReportDataSource();
                    rdc.Name = "StudentIdentityCardReportDataSet";
                    rdc.Value = studentReport;
                    rvStudentIdentityCardReportList.LocalReport.DataSources.Add(rdc);
                    rvStudentIdentityCardReportList.LocalReport.Refresh();
                    rvStudentIdentityCardReportList.Visible = true;
                }
            }
        }
       

    </script>

</head>

<body>
    <form id="Form1" runat="server">
        <div id="MainDiv" runat="server">

            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <rsweb:ReportViewer ID="rvStudentIdentityCardReportList" runat="server" AsyncRendering="False" SizeToReportContent="True" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
                <LocalReport ReportEmbeddedResource="AMS.Web.UI.Report.StudentIdentityCardFrontReport.rdlc">
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="StudentIdentityCardReportDataSet" />
                    </DataSources>
                </LocalReport>
            </rsweb:ReportViewer>
            <br />
        </div>
        <div id="NoRecordDiv" runat="server" style="text-align: center;">
            <b>No Record Found</b>
        </div>

    </form>
</body>

</html>
