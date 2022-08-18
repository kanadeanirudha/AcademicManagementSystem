//this class contain methods related to nationality functionality

var CRMSaleJobUserJobScheduleSheet = {

    ActionName: null,
    ScheduleEmployeeXml: null,

    //Class intialisation method
    Initialize: function () {
        CRMSaleJobUserJobScheduleSheet.constructor();
    },

    constructor: function () {

        $("#SubScheduleType").attr("disabled", true);
        $("#employeeName").hide();
        $("#employeeAccountDetails").hide();

        // Create new record
        $('#CreateCRMSaleUserJobSheetRecord').on("click", function () {
            debugger;
            CRMSaleJobUserJobScheduleSheet.ActionName = "Create";
            var isAttendOther = $("#isAttendOther").is(":checked") ? "true" : "false";

            if ($("#ScheduleType").val() == "") {
                $("#displayErrorMessage").text("Please Select Schedule Type.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                return false;
            }
            else if ($("#ScheduleType").val() == "1" && $("#SubScheduleType").val() == "") {
                $("#displayErrorMessage").text("Please Select Meeting Type.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                return false;
            }
            else if (isAttendOther == "true" && $("#employee").val() != null || isAttendOther == "false") {
                CRMSaleJobUserJobScheduleSheet.AjaxCallCRMSaleJobUserJobScheduleSheet();
            }
            else {
                $("#displayErrorMessage").text("Please Select Employee.").closest('div').fadeIn().closest('div').addClass('alert-' + "warning");
                $("#displayErrorMessage").delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                return false;
            }
        });


        $("#JobType").on("change", function () {
            debugger;
            if ($('#JobType').val() == "CALL" || $('#JobType').val() == "OTHER") {
                $("#AccountNameDiv").hide();
                $("#ContactPersonDiv").hide();
            }
            else {
                $("#AccountNameDiv").show();
                $("#ContactPersonDiv").show();

            }
            $("#employeeAccountDetails").hide();
            $("#AccountName").val('');
            $("#ContactPerson").val('');
            var selectedJobType = $(this).val();
            $(this).attr("disabled", false);
            var $ddlEmployeeJob = $("#Job");
            var $ddlScheduleType = $("#ScheduleType");
            var $ddlSubScheduleType = $("#SubScheduleType");




            if ($(this).val() == "CALL") {
                $("#isAttendOther").prop('checked', false);
                $("#isAttendOther").prop("disabled", true);
                $("select[name=selEmployee]").val('').selectpicker('refresh');
                $("#employeeName").hide();
            } else {
                $("#isAttendOther").prop("disabled", false);
            }

            if ($(this).val() != "") {
                debugger;
                if ($(this).val() != "OTHER") {
                    if ($(this).val() != "CALL") {
                        //Get Job from Job Type.
                        //$.ajax({
                        //    cache: false,
                        //    type: "GET",
                        //    url: "/CRMSaleJobUserJobScheduleSheet/GetEmployeeJobs",
                        //    data: { "jobType": selectedJobType },
                        //    success: function (data) {
                        //        $ddlEmployeeJob.html('');
                        //        $ddlEmployeeJob.append('<option value="">----Select Job----</option>');
                        //        $.each(data, function (id, option) {
                        //            $ddlEmployeeJob.append($('<option></option>').val(option.id).html(option.name));
                        //        });
                        //        $ddlScheduleType.html('');
                        //        $ddlScheduleType.append('<option value="">----Select Schedule Type----</option>');
                        //        $ddlScheduleType.append('<option value="1">Meeting</option>');
                        //        $ddlScheduleType.append('<option value="2">Survey</option>');

                        //        return;
                        //    },
                        //    error: function (xhr, ajaxOptions, thrownError) {
                        //        alert('Failed to retrieve Departments.');
                        //    }
                        //});
                        $ddlEmployeeJob.html('');
                        $ddlEmployeeJob.append('<option value="">----Select Job----</option>');
                        $ddlScheduleType.html('');
                        $ddlScheduleType.append('<option value="">----Select Schedule Type----</option>');
                        $ddlScheduleType.append('<option value="1">Meeting</option>');
                        $ddlScheduleType.append('<option value="2">Survey</option>');
                    } else {
                        //$ddlEmployeeJob.html('');
                        ////$ddlEmployeeJob.append('<option value="">----Select Job----</option>');
                        //$ddlEmployeeJob.append('<option value="0">Call</option>');

                        $.ajax({
                            cache: false,
                            type: "GET",
                            url: "/CRMSaleJobUserJobScheduleSheet/GetGeneralOtherJobType",
                            data: { "jobType": selectedJobType },
                            success: function (data) {
                                $ddlEmployeeJob.html('');
                                $ddlEmployeeJob.append('<option value="">----Select Job----</option>');
                                $.each(data, function (id, option) {
                                    $ddlEmployeeJob.append($('<option></option>').val(option.id).html(option.name));
                                });
                            },
                            error: function (xhr, ajaxOptions, thrownError) {
                                alert('Failed to retrieve Departments.');
                            }
                        });

                        $ddlScheduleType.html('');
                        //$ddlScheduleType.append('<option value="">----Select Schedule Type----</option>');
                        $ddlScheduleType.append('<option value="4">Call</option>');
                    }

                }
                else {

                    $ddlEmployeeJob.html('');
                    //$ddlEmployeeJob.append('<option value="">----Select Job----</option>');
                    $ddlEmployeeJob.append('<option value="0">Other</option>');

                    $ddlScheduleType.html('');
                    //$ddlScheduleType.append('<option value="">----Select Schedule Type----</option>');
                    $ddlScheduleType.append('<option value="3">Other</option>');

                    $("#isAttendOther").prop('checked', false);
                    $("#isAttendOther").prop("disabled", true);
                    $("select[name=selEmployee]").val('').selectpicker('refresh');
                    $("#employeeName").hide();
                }
                $ddlSubScheduleType.html('');
                $ddlSubScheduleType.append('<option value="">----Select Meeting Type----</option>');
                $ddlSubScheduleType.append('<option value="1">Pitch Meeting</option>');
                $ddlSubScheduleType.append('<option value="2">Introductory Meetingrvey</option>');
                $ddlSubScheduleType.append('<option value="3">Presentation</option>');
                $ddlSubScheduleType.append('<option value="4">Follow-up</option>');
                $("#SubScheduleType").attr("disabled", true);

                $("#employeeAccountDetails").hide();
                $("#AccountName").val('');
                $("#ContactPerson").val('');
            }
            else {
                $ddlEmployeeJob.html('');
                $ddlEmployeeJob.append('<option value="">----Select Job----</option>');
                //$("#employeeAccountDetails").hide();
            }

        });

        //$("#Job").on("change", function () {
        //    if ($(this).val() != "" && $(this).val() != 0 && $("#JobType").val() != "CALL") {

        //        $.ajax({
        //            cache: false,
        //            type: "GET",
        //            url: "/CRMSaleJobUserJobScheduleSheet/GetAllocatedJobEmployee",
        //            data: { "jobCreationMasterID": $(this).val() },
        //            success: function (data) {

        //                $.each(data, function (accountName, option) {s
        //                    $("#AccountName").val(option.accountName);
        //                    $("#ContactPerson").val(option.cantactPerson);
        //                });
        //            },
        //            error: function (xhr, ajaxOptions, thrownError) {
        //                alert('Failed to retrieve Departments.');
        //            }
        //        });

        //        $("#employeeAccountDetails").show();
        //    }
        //    else {
        //        $("#employeeAccountDetails").hide();
        //        $("#AccountName").val('');
        //        $("#ContactPerson").val('');
        //    }
        //});

        $("#ScheduleType").on("change", function () {
            debugger;
            var selectedScheduleType = $(this).val();
            if ($(this).val() == "1") {
                $("#SubScheduleType").attr("disabled", false);
            } else {
                $("#SubScheduleType").val('');
                $("#SubScheduleType").attr("disabled", true);
            }
        });

        $('#isAttendOther').change(function () {
            debugger;
            if (this.checked) {
                //CRMSaleJobUserJobScheduleSheet.AttendOther = true;
                $("#employeeName").show();
                //$("#employee").prop("disabled", false);
                return;
            } else {
                $("select[name=selEmployee]").val('').selectpicker('refresh');
                $("#employeeName").hide();
            }
        });

        $("#btnShowList").on("click", function () {
            CRMSaleJobUserJobScheduleSheet.LoadUserJobScheduleSheet($('#CallerJobStatus :selected').val(), $('#SelectedDate').val());
        });

        $('#SelectedDate').datetimepicker({
            format: 'DD MMMM YYYY'
        });

        $("#SelectedDate").on("keydown", function (e) {
            var keycode = (e.keyCode ? e.keyCode : e.which);
            if (keycode != 9) {
                return false;
            }
        })

    },


    //LoadList method is used to load List page
    LoadList: function () {
        $.ajax(
         {
             cache: false,
             type: "POST",
             dataType: "html",
             url: '/CRMSaleJobUserJobScheduleSheet/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },

    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {

        debugger;
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { actionMode: actionMode },
            url: '/CRMSaleJobUserJobScheduleSheet/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },

    LoadUserJobScheduleSheet: function (callerJobStatus, selectedDate) {

        $.ajax(
          {
              cache: false,
              type: "POST",
              data: { CallerJobStatus: callerJobStatus, SelectedDate: selectedDate },
              dataType: "html",
              url: '/CRMSaleJobUserJobScheduleSheet/List',
              success: function (result) {
                  //Rebind Grid Data                
                  $('#ListViewModel').html(result);
              }
          });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallCRMSaleJobUserJobScheduleSheet: function () {
        var CRMSaleJobUserJobScheduleSheetData = null;
        if (CRMSaleJobUserJobScheduleSheet.ActionName == "Create") {
            $("#FormCreateCRMUserJobScheduleSheet").validate();
            if ($("#FormCreateCRMUserJobScheduleSheet").valid()) {
                CRMSaleJobUserJobScheduleSheetData = null;
                CRMSaleJobUserJobScheduleSheetData = CRMSaleJobUserJobScheduleSheet.GetCRMSaleJobUserJobScheduleSheet();
                ajaxRequest.makeRequest("/CRMSaleJobUserJobScheduleSheet/Create", "POST", CRMSaleJobUserJobScheduleSheetData, CRMSaleJobUserJobScheduleSheet.Success, "CreateCRMSaleEnquiryAccountContactPersonRecord");
            }
        }
    },

    //Get properties data from the Create, Update and Delete page
    GetCRMSaleJobUserJobScheduleSheet: function () {
        debugger;
        var Data = {
        };
        if (CRMSaleJobUserJobScheduleSheet.ActionName == "Create") {

            Data.JobType = $("#JobType").val();
            Data.TransactionDate = $("#TransactionDate").val();
            Data.FromTime = $("#FromTime").val();
            Data.UpToTime = $("#UpToTime").val();
            Data.ScheduleType = $("#ScheduleType").val();
            if ($("#ScheduleType").val() == "1") {
                Data.SubScheduleType = $("#SubScheduleType").val();
            }

            var isAttendOther = $("#isAttendOther").is(":checked") ? "true" : "false";
            if (isAttendOther == "true") {
                Data.IsAttendOther = true;
                Data.OtherListEmployeId = $("select[name=selEmployee]").val().toString();
                CRMSaleJobUserJobScheduleSheet.GetScheduleWithEmployeeXml();
                Data.OtherListEmployeIDXml = CRMSaleJobUserJobScheduleSheet.ScheduleEmployeeXml;
            }
            else {
                Data.IsAttendOther = false;
            }

            Data.ScheduleDescription = $("#ScheduleDescription").val();
            Data.CallerJobStatus = 3;     //All ways Pendding=3;

            if (Data.JobType == "CALL") {
                Data.GeneralOtherJobTypeID = $("#Job").val();
                Data.Relatedwith = $("#Job option:selected").text();
                Data.JobCreationAllocationID = 0;
            }
            else {
                Data.JobCreationAllocationID = $("#Job").val();
                Data.GeneralOtherJobTypeID = 0;
                Data.Relatedwith = "";
            }
        }
        return Data;
    },

    GetScheduleWithEmployeeXml: function () {
        debugger;
        var DataArray = "";
        var selectedEmployee = $("select[name=selEmployee]").val().toString();

        if ($("#employee").val() != null && $("#employee").val() != "") {
            DataArray = selectedEmployee.split(',');
        }

        var TotalRecord = selectedEmployee.split(',').length;
        var EmployeeXML = "<rows>";

        for (var i = 0; i < TotalRecord; i++) {
            debugger;
            //EmployeeScheduleXML = EmployeeScheduleXML + "<row><ID>0</ID><EmployeeID>3</EmployeeID></row>";

            if (DataArray[i] != "") {
                EmployeeXML = EmployeeXML + "<row><ID>0</ID><EmployeeID>" + DataArray[i] + "</EmployeeID></row>";
            }
        }
        if (EmployeeXML.length > 6) {
            CRMSaleJobUserJobScheduleSheet.ScheduleEmployeeXml = EmployeeXML + "</rows>";
        } else {
            CRMSaleJobUserJobScheduleSheet.ScheduleEmployeeXml = "";
        }

    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        //alert("ss");
        debugger;
        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            CRMSaleJobUserJobScheduleSheet.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

};