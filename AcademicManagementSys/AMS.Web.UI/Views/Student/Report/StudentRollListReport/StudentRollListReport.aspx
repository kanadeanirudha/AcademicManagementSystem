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
            scriptManager.RegisterPostBackControl(this.rvOriginalBranchwiseList);
            if (!IsPostBack)
            {
                List<AMS.DTO.StudentReport> studentReport = null;
                AMS.Web.UI.Controllers.StudentRollListReportController controller = new AMS.Web.UI.Controllers.StudentRollListReportController();
                if (Request.RequestType == "POST")
                {
                    studentReport = controller.GetListStudentRollListReport();
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
                    rvOriginalBranchwiseList.LocalReport.ReportPath = Server.MapPath("~/Report/Student/StudentRollListReport.rdlc");
                    rvOriginalBranchwiseList.LocalReport.DataSources.Clear();
                    ReportDataSource rdc = new ReportDataSource();
                    rdc.Name = "StudentRollListDataSet";
                    rdc.Value = studentReport;
                    rvOriginalBranchwiseList.LocalReport.DataSources.Add(rdc);
                    rvOriginalBranchwiseList.LocalReport.Refresh();
                    rvOriginalBranchwiseList.Visible = true;
                }
            }
        }
    </script>

</head>

<body>
    <form id="Form1" runat="server">
        <div id="MainDiv" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <rsweb:ReportViewer ID="rvOriginalBranchwiseList" runat="server" AsyncRendering="False" SizeToReportContent="True" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
                <LocalReport ReportEmbeddedResource="AMS.Web.UI.Report.StudentRollListReport.rdlc">
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="StudentRollListDataSet" />
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
