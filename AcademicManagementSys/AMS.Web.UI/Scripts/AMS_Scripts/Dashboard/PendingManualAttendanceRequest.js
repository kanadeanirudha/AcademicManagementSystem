//this class contain methods related to nationality functionality
var PendingManualAttendanceRequest = {
    //Member variables
    ActionName: null,
    XMLstring: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        PendingManualAttendanceRequest.constructor();
        //PendingManualAttendanceRequest.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {
        $('#btnApproved').on("click", function () {
            PendingManualAttendanceRequest.ActionName = "Approved";
            PendingManualAttendanceRequest.GetXmlData();
            PendingManualAttendanceRequest.AjaxCallPendingManualAttendanceRequest();
        });

        $('#btnReject').on("click", function () {
            PendingManualAttendanceRequest.ActionName = "Rejected";
            PendingManualAttendanceRequest.GetXmlData();
            PendingManualAttendanceRequest.AjaxCallPendingManualAttendanceRequest();
        });


        $('#CreatePendingManualAttendanceRequestRecord').on("click", function () {
            PendingManualAttendanceRequest.ActionName = "Create";
            PendingManualAttendanceRequest.AjaxCallPendingManualAttendanceRequest();
        });

        $('#EditPendingManualAttendanceRequestRecord').on("click", function () {

            PendingManualAttendanceRequest.ActionName = "Edit";
            PendingManualAttendanceRequest.AjaxCallPendingManualAttendanceRequest();
        });

        $('#DeletePendingManualAttendanceRequestRecord').on("click", function () {

            PendingManualAttendanceRequest.ActionName = "Delete";
            PendingManualAttendanceRequest.AjaxCallPendingManualAttendanceRequest();
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
            debugger;

            var TaskCode = $(this).attr('id');
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


        //$('#MyDataTablePendingLeaveRequest').checkall - user

    },
    ////Load method is used to load *-Load-* page
    LoadList: function () {
        debugger;
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
        var TaskCode = 'MA'
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { "actionMode": actionMode, "TaskCode": TaskCode },
            url: '/Home/NotificationList',
            success: function (data) {
                //Rebind Grid Data
                //$("#ListViewModel").empty().append(data);
                $('#main-content').html(data);
                //twitter type notification
                $('#SuccessMessage').html(message);
                $('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallPendingManualAttendanceRequest: function () {
        var PendingManualAttendanceRequestData = null;
        if (PendingManualAttendanceRequest.ActionName == "Create") {
            $("#FormCreatePendingManualAttendanceRequest").validate();
            if ($("#FormCreatePendingManualAttendanceRequest").valid()) {
                PendingManualAttendanceRequestData = null;
                PendingManualAttendanceRequestData = PendingManualAttendanceRequest.GetPendingManualAttendanceRequest();
                ajaxRequest.makeRequest("/PendingManualAttendanceRequest/Create", "POST", PendingManualAttendanceRequestData, PendingManualAttendanceRequest.Success);
            }
        }
        else if (PendingManualAttendanceRequest.ActionName == "Edit") {
            $("#FormEditPendingManualAttendanceRequest").validate();
            if ($("#FormEditPendingManualAttendanceRequest").valid()) {
                PendingManualAttendanceRequestData = null;
                PendingManualAttendanceRequestData = PendingManualAttendanceRequest.GetPendingManualAttendanceRequest();
                ajaxRequest.makeRequest("/PendingManualAttendanceRequest/Edit", "POST", PendingManualAttendanceRequestData, PendingManualAttendanceRequest.Success);
            }
        }
        else if (PendingManualAttendanceRequest.ActionName == "Delete") {
            PendingManualAttendanceRequestData = null;
            //$("#FormCreatePendingManualAttendanceRequest").validate();
            PendingManualAttendanceRequestData = PendingManualAttendanceRequest.GetPendingManualAttendanceRequest();
            ajaxRequest.makeRequest("/PendingManualAttendanceRequest/Delete", "POST", PendingManualAttendanceRequestData, PendingManualAttendanceRequest.Success);

        }
        else if (PendingManualAttendanceRequest.ActionName == "Approved" || PendingManualAttendanceRequest.ActionName == "Rejected") {
            debugger;
            PendingManualAttendanceRequestData = null;
            PendingManualAttendanceRequestData = PendingManualAttendanceRequest.GetPendingManualAttendanceRequest();
            ajaxRequest.makeRequest("/Home/ApproveAllMARequest", "POST", PendingManualAttendanceRequestData, PendingManualAttendanceRequest.Success);
        }

    },
    //Get properties data from the Create, Update and Delete page
    GetPendingManualAttendanceRequest: function () {
        var Data = {
        };
        if (PendingManualAttendanceRequest.ActionName == "Create" || PendingManualAttendanceRequest.ActionName == "Edit") {
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
        else if (PendingManualAttendanceRequest.ActionName == "Approved" || PendingManualAttendanceRequest.ActionName == "Rejected") {
            Data.XMLString = PendingManualAttendanceRequest.XMLstring;
            debugger;
            
            
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (data != null) {
            parent.$.colorbox.close();
            PendingManualAttendanceRequest.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            parent.$.colorbox.close();
            PendingManualAttendanceRequest.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
    },
    CheckedAll: function () {
        $("#MyDataTablePendingManualAttendanceRequest-MA thead tr th input[class='checkall-user']").on('click', function () {
            var $this = $(this);
            if ($this.is(":checked")) {
                $("#MyDataTablePendingManualAttendanceRequest-MA tbody tr td p input[class='check-user']").prop("checked", true);
                $("#btnApproved").prop("disabled", false);
                $("#btnReject").prop("disabled", false);
                //$("#MyDataTablePendingLeaveRequest tbody tr").prop("color", '#fff');
            }
            else {
                $("#MyDataTablePendingManualAttendanceRequest-MA tbody tr td p input[class='check-user']").prop("checked", false);
                //$("#MyDataTablePendingLeaveRequest tbody tr").prop("color", '#fff');
                $("#btnApproved").prop("disabled", true);
                $("#btnReject").prop("disabled", true);
            }
        });
    },

    CheckedSingle: function () {
        $("#MyDataTablePendingManualAttendanceRequest-MA tbody tr td p input[class='check-user']").on('click', function () {
            var CheckedArray = [];
            var table = $('#MyDataTablePendingManualAttendanceRequest-MA').DataTable();
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
        var table = $('#MyDataTablePendingManualAttendanceRequest-MA').DataTable();
        var data = table.$("input[class='check-user']").each(function () {
            var $this = $(this);
            if ($this.is(":checked")) {
                var checkboxVal = $this.val();
                var splitedVal = checkboxVal.split('~');
                var EmployeeID = (splitedVal[0].split('='))[1];
                
                //var TotalDay = parseFloat(splitedVal[12]) + parseFloat(splitedVal[13] / 2);
                if (PendingManualAttendanceRequest.ActionName == "Approved") {
                    //ParameterXml = ParameterXml + "<row><EmployeeID>" + EmployeeID + "</EmployeeID><LeaveApplicationID>" + splitedVal[9] + "</LeaveApplicationID><IsLast>" + splitedVal[4] + "</IsLast><TaskNotificationMasterID>" + splitedVal[1] + "</TaskNotificationMasterID><TaskNotificationDetailsID>" + splitedVal[0] + "</TaskNotificationDetailsID><GeneralTaskReportingDetailsID>" + splitedVal[2] + "</GeneralTaskReportingDetailsID><ApprovalStatus>1</ApprovalStatus><CentreCode>" + splitedVal[8] + "</CentreCode><LeaveMasterID>" + splitedVal[10] + "</LeaveMasterID><StageSequenceNumber>" + splitedVal[3] + "</StageSequenceNumber><TotalDay>" + TotalDay + "</TotalDay><TotalApprovedFullDay>" + splitedVal[12] + "</TotalApprovedFullDay><TotalApprovedHalfDay>" + splitedVal[13] + "</TotalApprovedHalfDay></row>";
                    ParameterXml = ParameterXml + "<row><EmployeeID>"+EmployeeID+"</EmployeeID><TaskCode>"+splitedVal[1]+"</TaskCode><IsLast>"+splitedVal[2]+"</IsLast><TaskNotificationMasterID>"+splitedVal[3]+"</TaskNotificationMasterID><TaskNotificationDetailsID>"+splitedVal[4]+"</TaskNotificationDetailsID><GeneralTaskReportingDetailsID>"+splitedVal[5]+"</GeneralTaskReportingDetailsID><ApprovalStatus>1</ApprovalStatus><StageSequenceNumber>"+splitedVal[7]+"</StageSequenceNumber><Reason>Approve All</Reason></row>";

                }
                else if (PendingManualAttendanceRequest.ActionName == "Rejected") {
                    ParameterXml = ParameterXml + "<row><EmployeeID>" + EmployeeID + "</EmployeeID><TaskCode>" + splitedVal[1] + "</TaskCode><IsLast>" + splitedVal[2] + "</IsLast><TaskNotificationMasterID>" + splitedVal[3] + "</TaskNotificationMasterID><TaskNotificationDetailsID>" + splitedVal[4] + "</TaskNotificationDetailsID><GeneralTaskReportingDetailsID>" + splitedVal[5] + "</GeneralTaskReportingDetailsID><ApprovalStatus>0</ApprovalStatus><StageSequenceNumber>" + splitedVal[7] + "</StageSequenceNumber><Reason>Reject All</Reason></row>";
                }
            }
        });

        PendingManualAttendanceRequest.XMLstring = ParameterXml + "</rows>";
       

    },

};

