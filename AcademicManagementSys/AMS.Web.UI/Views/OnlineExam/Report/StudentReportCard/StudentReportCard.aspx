<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Report Card</title>
    <script runat="server">
      
        AMS.Web.UI.Controllers.StudentReportCardController controller = new AMS.Web.UI.Controllers.StudentReportCardController();

        protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }
       
        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvStudentReportCard);
            if (!IsPostBack)
            {
                rvStudentReportCard.ProcessingMode = ProcessingMode.Local;
                List<AMS.DTO.StudentReportCard> OnlineExamResult = null;
                //List<AMS.DTO.OrganisationStudyCentreMaster> OrganisationStudyCentreMasterDetails = null;

                OnlineExamResult = controller.GetStudentReportCardData();
                if (OnlineExamResult == null)
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;
                    NoRecordDiv.Visible = false;
                    rvStudentReportCard.LocalReport.ReportPath = Server.MapPath("~/Report/OnlineExam/StudentReportCard.rdlc");
                    rvStudentReportCard.LocalReport.DataSources.Clear();//collection Of Reports

                    ReportDataSource rdc = new ReportDataSource();
                    rdc.Name = "ReportCardDataSet";//Data Set Name
                    rdc.Value = OnlineExamResult;                //DTO object
                    rvStudentReportCard.LocalReport.DataSources.Add(rdc);

                    ReportParameter[] param = new ReportParameter[3];
                    param[0] = new ReportParameter("ExaminationName", OnlineExamResult.Count > 0 ? OnlineExamResult[0].ExaminationName : string.Empty, false);
                    param[1] = new ReportParameter("OverAllTotalMarks", OnlineExamResult.Count > 0 ? Convert.ToString(OnlineExamResult[0].OverAllTotalMarks) : string.Empty, false);
                    param[2] = new ReportParameter("TotalMarkObtained", OnlineExamResult.Count > 0 ? Convert.ToString(OnlineExamResult[0].TotalMarkObtained) : string.Empty, false);
                    rvStudentReportCard.LocalReport.SetParameters(param);
                    
                    rvStudentReportCard.LocalReport.Refresh();
                    rvStudentReportCard.Visible = true;
                }
            }
        
        }
        
    </script>
</head>
<body>
    <form runat="server">
        <div id="MainDiv" runat="server">
            <div id="categoryPrint">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
               <%-- Please Select Report :&nbsp&nbsp&nbsp;--%>
               
                 <rsweb:ReportViewer ID="rvStudentReportCard" runat="server" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="" SizeToReportContent="True" ShowPageNavigationControls ="false" ShowBackButton="false" ShowFindControls="false">
                    <LocalReport ReportEmbeddedResource="AMS.Web.UI.Report.Inventory_1.StudentReportCard.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="ReportCardDataSet" />
                       
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>

              
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="ReportCardDataSetTableAdapters.StudentReportCardTableAdapter"></asp:ObjectDataSource>

            </div>

        </div>
        <div id="NoRecordDiv" runat="server" style="text-align: center;">

            <b>No Record Found</b>

        </div>
       
    </form>
</body>
</html>


