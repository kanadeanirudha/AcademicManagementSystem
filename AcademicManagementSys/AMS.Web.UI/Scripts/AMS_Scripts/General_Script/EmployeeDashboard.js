﻿//this class contain methods related to nationality functionality
var EmployeeDashboard = {
    //Member variables
    ActionName: null,
    XMLstring: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        EmployeeDashboard.constructor();
        //EmployeeDashboard.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {


        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#LeaveDescription').focus();
            $('#LeaveType').val(" ");
            return false;
        });

        // Create new record

        $('#btnApproved').on("click", function () {
            EmployeeDashboard.ActionName = "Approved";
            EmployeeDashboard.GetXmlData();
            EmployeeDashboard.AjaxCallEmployeeDashboard();
        });

        $('#btnReject').on("click", function () {
            EmployeeDashboard.ActionName = "Rejected";
            EmployeeDashboard.GetXmlData();
            EmployeeDashboard.AjaxCallEmployeeDashboard();
        });

        $('#CreateEmployeeDashboardRecord').on("click", function () {
            EmployeeDashboard.ActionName = "Create";
            EmployeeDashboard.AjaxCallEmployeeDashboard();
        });

        $('#EditEmployeeDashboardRecord').on("click", function () {

            EmployeeDashboard.ActionName = "Edit";
            EmployeeDashboard.AjaxCallEmployeeDashboard();
        });

        $('#DeleteEmployeeDashboardRecord').on("click", function () {

            EmployeeDashboard.ActionName = "Delete";
            EmployeeDashboard.AjaxCallEmployeeDashboard();
        });

        $('#LeaveDescription').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#LeaveCode').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
            AMSValidation.NotAllowSpaces(e);
        });

        $("#UserSearch").keyup(function () {
            var oTable = $("#MyDataTablePendingLeaveRequest").dataTable();
            oTable.fnFilter(this.value);
        });

        $("#searchBtn").click(function () {
            $("#UserSearch").focus();
        });


        $("#showrecord").change(function () {
            var showRecord = $("#showrecord").val();
            $("select[name*='MyDataTablePendingLeaveRequest_length']").val(showRecord);
            $("select[name*='MyDataTablePendingLeaveRequest_length']").change();
        });

        $(".ajax").colorbox();

        $('ul#pending_Request li').click(function () {
            

            var TaskCode = $(this).attr('id');
            alert(TaskCode);
            var RequestName = $(this).text();
            $.ajax(
                  {
                      cache: false,
                      type: "GET",
                      dataType: "html",
                      data: { "TaskCode": TaskCode },
                      url: '/Home/List',
                      success: function (result) {
                          $('#ListViewModel').html(result);
                      }
                  });
        });


        $('ul#TaskList li').click(function () {            
            var Newurl = '';
            var TaskCode = $(this).attr('id');
           
            if (TaskCode == "MA")
            {
                Newurl = '/Home/PendingManualAttendanceRequest';
            }
            else if (TaskCode == "LA") {
                Newurl = '/Home/PendingLeaveRequest';
            }
            else if (TaskCode == "ASA") {
                Newurl = '/Home/SPAttendancePendingRequest';
            }
            else if (TaskCode == "CODA") {
                Newurl = '/Home/CODAPendingRequest';
            }
            else if (TaskCode == "DAST") {
                Newurl = '/Home/DASTPendingRequest';
            }
            else if (TaskCode == "INWARD") {
                Newurl = '/Home/INWARDPendingRequest';
            }
            else if (TaskCode == "FSAA") {
                Newurl = '/Home/FSAAPendingRequest';
            }
            else if (TaskCode == "SRAA") {
                Newurl = '/StudentRegistrationAcademicApproval/List';
            }
            else if (TaskCode == "PR") {
                Newurl = '/Home/PurchaseRequirementPendingRequest';
            }
            else if (TaskCode == "PRQA") {
                Newurl = '/Home/PurchaseRequsitionPendingRequest';
            }
            else if (TaskCode == "SSA") {
                Newurl = '/Home/SSAPendingRequest';
            }
            else if (TaskCode == "AVAR") {
                Newurl = '/Home/AVARPendingRequest';
            }
            $.ajax(
                  {
                      cache: false,
                      type: "GET",
                      dataType: "html",
                      data: { "TaskCode": TaskCode },
                      url: Newurl,
                      success: function (result) {
                          //alert(result);
                          $('.tab-content').html(result);
                      }
                  });
        });



        //$('#MyDataTablePendingLeaveRequest').checkall - user

    },
    ////Load method is used to load *-Load-* page
    LoadList: function () {
        
        $.ajax(
         {
             cache: false,
             type: "POST",

             dataType: "html",
             url: '/Home/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        var TaskCode = $('input[name=TaskCode]').val();      
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { "actionMode": actionMode, "TaskCode": TaskCode },
            url: '/Home/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                $('#SuccessMessage').html(message);
                $('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallEmployeeDashboard: function () {
        var EmployeeDashboardData = null;
        if (EmployeeDashboard.ActionName == "Create") {
            $("#FormCreateEmployeeDashboard").validate();
            if ($("#FormCreateEmployeeDashboard").valid()) {
                EmployeeDashboardData = null;
                EmployeeDashboardData = EmployeeDashboard.GetEmployeeDashboard();
                ajaxRequest.makeRequest("/EmployeeDashboard/Create", "POST", EmployeeDashboardData, EmployeeDashboard.Success);
            }
        }
        else if (EmployeeDashboard.ActionName == "Edit") {
            $("#FormEditEmployeeDashboard").validate();
            if ($("#FormEditEmployeeDashboard").valid()) {
                EmployeeDashboardData = null;
                EmployeeDashboardData = EmployeeDashboard.GetEmployeeDashboard();
                ajaxRequest.makeRequest("/EmployeeDashboard/Edit", "POST", EmployeeDashboardData, EmployeeDashboard.Success);
            }
        }
        else if (EmployeeDashboard.ActionName == "Delete") {
            EmployeeDashboardData = null;
            //$("#FormCreateEmployeeDashboard").validate();
            EmployeeDashboardData = EmployeeDashboard.GetEmployeeDashboard();
            ajaxRequest.makeRequest("/EmployeeDashboard/Delete", "POST", EmployeeDashboardData, EmployeeDashboard.Success);

        }
        else if (EmployeeDashboard.ActionName == "Approved" || EmployeeDashboard.ActionName == "Rejected") {
            EmployeeDashboardData = null;
            EmployeeDashboardData = EmployeeDashboard.GetEmployeeDashboard();
            ajaxRequest.makeRequest("/Home/ApproveAll", "POST", EmployeeDashboardData, EmployeeDashboard.Success);
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetEmployeeDashboard: function () {
        var Data = {
        };
        if (EmployeeDashboard.ActionName == "Create" || EmployeeDashboard.ActionName == "Edit") {
            Data.ID = $('input[name=ID]').val();
            Data.LeaveDescription = $('#LeaveDescription').val();
            Data.LeaveCode = $('#LeaveCode').val();
            Data.LeaveType = $('#LeaveType').val();
            Data.IsCarryForwardForNextYear = $("input[id=IsCarryForwardForNextYear]:checked").val();
            Data.MinServiceRequire = $("input[id=MinServiceRequire]:checked").val();
            Data.HalfDayFlag = $("input[id=HalfDayFlag]:checked").val();
            Data.DocumentsNeeded = $("input[id=DocumentsNeeded]:checked").val();
            Data.AttendanceNeeded = $("input[id=AttendanceNeeded]:checked").val();
            Data.LossOfPay = $("input[id=LossOfPay]:checked").val();
            Data.NoCredit = $("input[id=NoCredit]:checked").val();
            Data.IsEnCash = $("input[id=IsEnCash]:checked").val();
            Data.OnDuty = $("input[id=OnDuty]:checked").val();
        }
        else if (EmployeeDashboard.ActionName == "Approved" || EmployeeDashboard.ActionName == "Rejected") {
            Data.XMLString = EmployeeDashboard.XMLstring;
        }        
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {      
        var splitData = data.split(',');
        if (data != null) {
            parent.$.colorbox.close();
            EmployeeDashboard.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            parent.$.colorbox.close();
            EmployeeDashboard.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
    },

    CheckedAll: function () {
        $("#MyDataTablePendingLeaveRequest thead tr th input[class='checkall-user']").on('click', function () {
            var $this = $(this);
            if ($this.is(":checked")) {
                $("#MyDataTablePendingLeaveRequest tbody tr td p input[class='check-user']").prop("checked", true);
                $("#btnApproved").prop("disabled", false);
                $("#btnReject").prop("disabled", false);
                //$("#MyDataTablePendingLeaveRequest tbody tr").prop("color", '#fff');
            }
            else {
                $("#MyDataTablePendingLeaveRequest tbody tr td p input[class='check-user']").prop("checked", false);
                //$("#MyDataTablePendingLeaveRequest tbody tr").prop("color", '#fff');
                $("#btnApproved").prop("disabled", true);
                $("#btnReject").prop("disabled", true);
            }
        });
    },

    CheckedSingle: function () {
        $("#MyDataTablePendingLeaveRequest tbody tr td p input[class='check-user']").on('click', function () {
            var CheckedArray = [];
            var table = $('#MyDataTablePendingLeaveRequest').DataTable();
            var TotalCheckedRecord;
            var data = table.$("input[class='check-user']").each(function () {
                CheckedArray.push($(this).val());
                var $this = $(this);
                if ($this.is(":checked")) {
                    CheckedArray.push($(this).val());
                    TotalCheckedRecord = CheckedArray.length;
                }
            });
            if (TotalCheckedRecord > 0) {
                $("#btnApproved").prop("disabled", false);
                $("#btnReject").prop("disabled", false);
            }
            else {
                $("#btnApproved").prop("disabled", true);
                $("#btnReject").prop("disabled", true);
            }
        });
    },

    GetXmlData: function () {       
        var DataArray = [];
        ParameterXml = "<rows>";
        var table = $('#MyDataTablePendingLeaveRequest').DataTable();
        var data = table.$("input[class='check-user']").each(function () {
            var $this = $(this);
            if ($this.is(":checked")) {
                var checkboxVal = $this.val();
                var splitedVal = checkboxVal.split('~');              
                var EmployeeID = (splitedVal[5].split('='))[1];
                var TotalDay = parseFloat(splitedVal[12])+parseFloat(splitedVal[13]/2);               
               
                if (EmployeeDashboard.ActionName == "Approved") {
                    ParameterXml = ParameterXml + "<row><EmployeeID>" + EmployeeID + "</EmployeeID><LeaveApplicationID>" + splitedVal[9] + "</LeaveApplicationID><IsLast>" + splitedVal[4] + "</IsLast><TaskNotificationMasterID>" + splitedVal[1] + "</TaskNotificationMasterID><TaskNotificationDetailsID>" + splitedVal[0] + "</TaskNotificationDetailsID><GeneralTaskReportingDetailsID>" + splitedVal[2] + "</GeneralTaskReportingDetailsID><ApprovalStatus>1</ApprovalStatus><CentreCode>" + splitedVal[8] + "</CentreCode><LeaveMasterID>" + splitedVal[10] + "</LeaveMasterID><StageSequenceNumber>" + splitedVal[3] + "</StageSequenceNumber><TotalDay>" + TotalDay + "</TotalDay><TotalApprovedFullDay>" + splitedVal[12] + "</TotalApprovedFullDay><TotalApprovedHalfDay>" + splitedVal[13] + "</TotalApprovedHalfDay></row>";
                }
                else if (EmployeeDashboard.ActionName == "Rejected") {
                    ParameterXml = ParameterXml + "<row><EmployeeID>" + EmployeeID + "</EmployeeID><LeaveApplicationID>" + splitedVal[9] + "</LeaveApplicationID><IsLast>" + splitedVal[4] + "</IsLast><TaskNotificationMasterID>" + splitedVal[1] + "</TaskNotificationMasterID><TaskNotificationDetailsID>" + splitedVal[0] + "</TaskNotificationDetailsID><GeneralTaskReportingDetailsID>" + splitedVal[2] + "</GeneralTaskReportingDetailsID><ApprovalStatus>0</ApprovalStatus><CentreCode>" + splitedVal[8] + "</CentreCode><LeaveMasterID>" + splitedVal[10] + "</LeaveMasterID><StageSequenceNumber>" + splitedVal[3] + "</StageSequenceNumber><TotalDay>" + TotalDay + "</TotalDay><TotalApprovedFullDay>" + splitedVal[12] + "</TotalApprovedFullDay><TotalApprovedHalfDay>" + splitedVal[13] + "</TotalApprovedHalfDay></row>";
                }
            }
        });
        EmployeeDashboard.XMLstring = ParameterXml + "</rows>";
        
    },      
};

