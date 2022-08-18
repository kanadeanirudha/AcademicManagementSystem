<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Exam Result</title>
    <script runat="server">
      
        AMS.Web.UI.Controllers.OnlineExamResultController controller = new AMS.Web.UI.Controllers.OnlineExamResultController();

        protected void Page_PreInit(object sender, EventArgs e)
        {
            Context.Handler = this.Page;
        }
       
        void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.rvOnlineExamResult);
            if (!IsPostBack)
            {
                rvOnlineExamResult.ProcessingMode = ProcessingMode.Local;
                List<AMS.DTO.OnlineExamResult> OnlineExamResult = null;
                //List<AMS.DTO.OrganisationStudyCentreMaster> OrganisationStudyCentreMasterDetails = null;

                OnlineExamResult = controller.GetOnlineExaminationData();
                if (OnlineExamResult == null)
                {
                    MainDiv.Visible = false;
                    NoRecordDiv.Visible = true;
                }
                else
                {
                    MainDiv.Visible = true;
                    NoRecordDiv.Visible = false;
                    rvOnlineExamResult.LocalReport.ReportPath = Server.MapPath("~/Report/OnlineExam/OnlineExamResult.rdlc");
                    rvOnlineExamResult.LocalReport.DataSources.Clear();//collection Of Reports

                    ReportDataSource rdc = new ReportDataSource();
                    rdc.Name = "OnlineExamResultDataSet2";//Data Set Name
                    rdc.Value = OnlineExamResult;                //DTO object
                    rvOnlineExamResult.LocalReport.DataSources.Add(rdc);

                    ReportParameter[] param = new ReportParameter[3];
                    param[0] = new ReportParameter("ExamName", OnlineExamResult.Count > 0 ? OnlineExamResult[0].ExamName : string.Empty, false);
                    param[1] = new ReportParameter("ExamDate", OnlineExamResult.Count > 0 ? OnlineExamResult[0].ExamDate : string.Empty, false);
                    param[2] = new ReportParameter("SubjectName", OnlineExamResult.Count > 0 ? OnlineExamResult[0].SubjectName : string.Empty, false);
                    rvOnlineExamResult.LocalReport.SetParameters(param);
                    
                    rvOnlineExamResult.LocalReport.Refresh();
                    rvOnlineExamResult.Visible = true;
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
               
                 <rsweb:ReportViewer ID="rvOnlineExamResult" runat="server" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="" Width="" SizeToReportContent="True" ShowPageNavigationControls ="false" ShowBackButton="false" ShowFindControls="false">
                    <LocalReport ReportEmbeddedResource="AMS.Web.UI.Report.Inventory_1.OnlineExamResult.rdlc">
                        <DataSources>
                            <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="OnlineExamResultDataSet2" />
                       
                        </DataSources>
                    </LocalReport>
                </rsweb:ReportViewer>

              
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="OnlineExamResultDataSet2TableAdapters.OnlineExamResultTableAdapter"></asp:ObjectDataSource>

            </div>

        </div>
        <div id="NoRecordDiv" runat="server" style="text-align: center;">

            <b>No Record Found</b>

        </div>
       
    </form>
</body>
</html>


