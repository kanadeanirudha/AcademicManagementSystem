//this class contain methods related to nationality functionality
var FSAAPendingRequest = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        FSAAPendingRequest.constructor();
        //FSAAPendingRequest.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {
        // Create new record



        $('#CreateFSAAPendingRequestRecord').on("click", function () {
            FSAAPendingRequest.ActionName = "Create";
            FSAAPendingRequest.AjaxCallFSAAPendingRequest();
        });

        $('#EditFSAAPendingRequestRecord').on("click", function () {

            FSAAPendingRequest.ActionName = "Edit";
            FSAAPendingRequest.AjaxCallFSAAPendingRequest();
        });

        $('#DeleteFSAAPendingRequestRecord').on("click", function () {

            FSAAPendingRequest.ActionName = "Delete";
            FSAAPendingRequest.AjaxCallFSAAPendingRequest();
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

        //$('ul#pending_Request li').click(function () {
        //    debugger;

        //    var TaskCode = $(this).attr('id');
        //    var RequestName = $(this).text();
        //    $.ajax(
        //          {
        //              cache: false,
        //              type: "GET",
        //              dataType: "html",
        //              data: { "TaskCode": TaskCode },
        //              url: '/Home/List',
        //              success: function (result) {
        //                  $('#ListViewModel').html(result);
        //              }
        //          });
        //});


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

        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { "actionMode": actionMode },
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
    AjaxCallFSAAPendingRequest: function () {
        var FSAAPendingRequestData = null;
        if (FSAAPendingRequest.ActionName == "Create") {
            $("#FormCreateFSAAPendingRequest").validate();
            if ($("#FormCreateFSAAPendingRequest").valid()) {
                FSAAPendingRequestData = null;
                FSAAPendingRequestData = FSAAPendingRequest.GetFSAAPendingRequest();
                ajaxRequest.makeRequest("/FSAAPendingRequest/Create", "POST", FSAAPendingRequestData, FSAAPendingRequest.Success);
            }
        }
        else if (FSAAPendingRequest.ActionName == "Edit") {
            $("#FormEditFSAAPendingRequest").validate();
            if ($("#FormEditFSAAPendingRequest").valid()) {
                FSAAPendingRequestData = null;
                FSAAPendingRequestData = FSAAPendingRequest.GetFSAAPendingRequest();
                ajaxRequest.makeRequest("/FSAAPendingRequest/Edit", "POST", FSAAPendingRequestData, FSAAPendingRequest.Success);
            }
        }
        else if (FSAAPendingRequest.ActionName == "Delete") {
            FSAAPendingRequestData = null;
            //$("#FormCreateFSAAPendingRequest").validate();
            FSAAPendingRequestData = FSAAPendingRequest.GetFSAAPendingRequest();
            ajaxRequest.makeRequest("/FSAAPendingRequest/Delete", "POST", FSAAPendingRequestData, FSAAPendingRequest.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetFSAAPendingRequest: function () {
        var Data = {
        };
        if (FSAAPendingRequest.ActionName == "Create" || FSAAPendingRequest.ActionName == "Edit") {
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
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (data != null) {
            parent.$.colorbox.close();
            FSAAPendingRequest.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            parent.$.colorbox.close();
            FSAAPendingRequest.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
    },


};

