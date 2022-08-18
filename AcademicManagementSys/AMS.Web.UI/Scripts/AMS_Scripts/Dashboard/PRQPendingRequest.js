//this class contain methods related to nationality functionality
var PRQPendingRequest = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    XMLstring: null,
    Initialize: function () {
        //organisationStudyCentre.loadData();

        PRQPendingRequest.constructor();
        //PRQPendingRequest.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {
        // Create new record


        $('#btnApproved').on("click", function () {
            PRQPendingRequest.ActionName = "Approved";
            PRQPendingRequest.GetXmlData();
            PRQPendingRequest.AjaxCallPRQPendingRequest();
        });

        $('#btnReject').on("click", function () {
            PRQPendingRequest.ActionName = "Rejected";
            PRQPendingRequest.GetXmlData();
            PRQPendingRequest.AjaxCallPRQPendingRequest();
        });

        $('#CreatePRQPendingRequestRecord').on("click", function () {
            PRQPendingRequest.ActionName = "Create";
            PRQPendingRequest.AjaxCallPRQPendingRequest();
        });

        $('#EditPRQPendingRequestRecord').on("click", function () {

            PRQPendingRequest.ActionName = "Edit";
            PRQPendingRequest.AjaxCallPRQPendingRequest();
        });

        $('#DeletePRQPendingRequestRecord').on("click", function () {

            PRQPendingRequest.ActionName = "Delete";
            PRQPendingRequest.AjaxCallPRQPendingRequest();
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
        var TaskCode = 'PRQA'
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
    AjaxCallPRQPendingRequest: function () {
        var PRQPendingRequestData = null;
        if (PRQPendingRequest.ActionName == "Create") {
            $("#FormCreatePRQPendingRequest").validate();
            if ($("#FormCreatePRQPendingRequest").valid()) {
                PRQPendingRequestData = null;
                PRQPendingRequestData = PRQPendingRequest.GetPRQPendingRequest();
                ajaxRequest.makeRequest("/PRQPendingRequest/Create", "POST", PRQPendingRequestData, PRQPendingRequest.Success);
            }
        }
        else if (PRQPendingRequest.ActionName == "Edit") {
            $("#FormEditPRQPendingRequest").validate();
            if ($("#FormEditPRQPendingRequest").valid()) {
                PRQPendingRequestData = null;
                PRQPendingRequestData = PRQPendingRequest.GetPRQPendingRequest();
                ajaxRequest.makeRequest("/PRQPendingRequest/Edit", "POST", PRQPendingRequestData, PRQPendingRequest.Success);
            }
        }
        else if (PRQPendingRequest.ActionName == "Delete") {
            PRQPendingRequestData = null;
            //$("#FormCreatePRQPendingRequest").validate();
            PRQPendingRequestData = PRQPendingRequest.GetPRQPendingRequest();
            ajaxRequest.makeRequest("/PRQPendingRequest/Delete", "POST", PRQPendingRequestData, PRQPendingRequest.Success);

        }

        else if (PRQPendingRequest.ActionName == "Approved" || PRQPendingRequest.ActionName == "Rejected") {
            PRQPendingRequestData = null;
            PRQPendingRequestData = PRQPendingRequest.GetPRQPendingRequest();
            ajaxRequest.makeRequest("/Home/ApproveAllPRRequest", "POST", PRQPendingRequest, PRQPendingRequest.Success);
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetPRQPendingRequest: function () {
        var Data = {
        };
        if (PRQPendingRequest.ActionName == "Create" || PRQPendingRequest.ActionName == "Edit") {
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

        else if (PRQPendingRequest.ActionName == "Approved" || PRQPendingRequest.ActionName == "Rejected") {
            Data.XMLString = PRQPendingRequest.XMLstring;

        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (data != null) {
            parent.$.colorbox.close();
            PRQPendingRequest.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            parent.$.colorbox.close();
            PRQPendingRequest.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
    },

    CheckedAll: function () {
        $("#MyDataTablePendingRequest-PRQ thead tr th input[class='checkall-user']").on('click', function () {
            var $this = $(this);
            if ($this.is(":checked")) {
                $("#MyDataTablePendingRequest-PR tbody tr td p input[class='check-user']").prop("checked", true);
                $("#btnApproved").prop("disabled", false);
                $("#btnReject").prop("disabled", false);
                //$("#MyDataTablePendingLeaveRequest tbody tr").prop("color", '#fff');
            }
            else {
                $("#MyDataTablePendingRequest-PRQ tbody tr td p input[class='check-user']").prop("checked", false);
                //$("#MyDataTablePendingLeaveRequest tbody tr").prop("color", '#fff');
                $("#btnApproved").prop("disabled", true);
                $("#btnReject").prop("disabled", true);
            }
        });
    },

    CheckedSingle: function () {
        $("#MyDataTablePendingRequest-PRQ tbody tr td p input[class='check-user']").on('click', function () {
            var CheckedArray = [];
            var table = $('#MyDataTablePendingRequest-PR').DataTable();
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
        var table = $('#MyDataTablePendingRequest-PRQ').DataTable();
        var data = table.$("input[class='check-user']").each(function () {
            var $this = $(this);
            if ($this.is(":checked")) {
                var checkboxVal = $this.val();
                var splitedVal = checkboxVal.split('~');
                var EmployeeID = (splitedVal[0].split('='))[1];
                //var TotalDay = parseFloat(splitedVal[12]) + parseFloat(splitedVal[13] / 2);

                if (PRQPendingRequest.ActionName == "Approved") {
                    //ParameterXml = ParameterXml + "<row><EmployeeID>" + EmployeeID + "</EmployeeID><LeaveApplicationID>" + splitedVal[9] + "</LeaveApplicationID><IsLast>" + splitedVal[4] + "</IsLast><TaskNotificationMasterID>" + splitedVal[1] + "</TaskNotificationMasterID><TaskNotificationDetailsID>" + splitedVal[0] + "</TaskNotificationDetailsID><GeneralTaskReportingDetailsID>" + splitedVal[2] + "</GeneralTaskReportingDetailsID><ApprovalStatus>1</ApprovalStatus><CentreCode>" + splitedVal[8] + "</CentreCode><LeaveMasterID>" + splitedVal[10] + "</LeaveMasterID><StageSequenceNumber>" + splitedVal[3] + "</StageSequenceNumber><TotalDay>" + TotalDay + "</TotalDay><TotalApprovedFullDay>" + splitedVal[12] + "</TotalApprovedFullDay><TotalApprovedHalfDay>" + splitedVal[13] + "</TotalApprovedHalfDay></row>";
                    ParameterXml = ParameterXml + "<row><ApplicationID>" + splitedVal[9] + "</ApplicationID><EmployeeID> " + EmployeeID + "</EmployeeID><TaskCode >" + splitedVal[8] + "</TaskCode ><IsLast>" + splitedVal[1] + "</IsLast><TaskNotificationMasterID>" + splitedVal[2] + "</TaskNotificationMasterID><TaskNotificationDetailsID>" + splitedVal[3] + "</TaskNotificationDetailsID><GeneralTaskReportingDetailsID>" + splitedVal[4] + "</GeneralTaskReportingDetailsID><ApprovalStatus>1</ApprovalStatus><CentreCode>" + splitedVal[6] + "</CentreCode><StageSequenceNumber>" + splitedVal[7] + "</StageSequenceNumber><LeaveSessionID>" + 2 + "</LeaveSessionID></row>";

                }
                else if (PRQPendingRequest.ActionName == "Rejected") {
                    ParameterXml = ParameterXml + "<row><ApplicationID> " + splitedVal[9] + "</ApplicationID><EmployeeID> " + EmployeeID + "</EmployeeID><TaskCode >" + splitedVal[8] + "</TaskCode ><IsLast>" + splitedVal[1] + "</IsLast><TaskNotificationMasterID>" + splitedVal[2] + "</TaskNotificationMasterID><TaskNotificationDetailsID>" + splitedVal[3] + "</TaskNotificationDetailsID><GeneralTaskReportingDetailsID>" + splitedVal[4] + "</GeneralTaskReportingDetailsID><ApprovalStatus>0</ApprovalStatus><CentreCode>" + splitedVal[6] + "</CentreCode><StageSequenceNumber>" + splitedVal[7] + "</StageSequenceNumber><LeaveSessionID>" + 2 + "</LeaveSessionID></row>";
                }
            }
        });

        PRQPendingRequest.XMLstring = ParameterXml + "</rows>";

    },

};

