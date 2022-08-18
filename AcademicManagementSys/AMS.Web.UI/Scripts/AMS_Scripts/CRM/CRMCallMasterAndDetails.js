//this class contain methods related to nationality functionality
var CRMCallMasterAndDetails = {
     ActionName: null,
     Initialize: function () {
        CRMCallMasterAndDetails.constructor();
      
    },
    //Attach all event of page
    constructor: function () {


        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#CountryName').focus();
            return false;
        });

        //$("#NextCallDate").datepicker({
        //    numberOfMonths: 1,
        //    minDate: 0,
        //    maxDate: 30,
        //    dateFormat: 'dd M yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    yearRange: '1950:document.write(currentYear.getFullYear()'
        //});

        $('#NextCallDate').datetimepicker({
            format: 'DD MMMM YYYY',
            minDate: moment(),
            maxDate: moment().add(1, 'month'),
        });

        $('#NextCallDate_Clear').on("click", function () {
            $('#NextCallDate').val("");
        });

        $('#IconShowList').on("click", function () {
            // window.location = '/CRMCallMasterAndDetails?jobID=' + $('JobID').val() + '&jobStatus=' + $('SelectedJobCallerStatus').val();
        });


        // Create new record
        $('#CreateNewAdmissionRecord').on("click", function () {


            CRMCallMasterAndDetails.ActionName = "CreateNewAdmission";
            if ($('#Interestlevel').val() == "0") {
                notify("Please select interest level.", "danger");
                return false;
                
            }
            else if ($('#CallerJobStatus').val() == "0") {
                notify("Please select caller job status feedback.", "danger");
                return false;
            }
            if ($('#CallStatus').val() == "0") {
                notify("Please select call status feedback.", "danger");
                return false;

            }

            else if ($('#CallStatus').val() == "2" && $('#NextCallDate').val() == "") {
                notify("Please select call back date.", "danger");
                return false;
            }
            else if ($('#CallStatus').val() == "2" && $('#CallTimeID').val() == "") {
                notify("Please select call time.", "danger");
                return false;

            }
            else if ($('#CalleeTitle').val() == "" && $('#CallStatus').val() == "1") {
                notify("Please select title.", "danger");
                return false;
            }
            else if ($('#CalleeFirstName').val() == "" && $('#CallStatus').val() == "1") {
                notify("Please select first name.", "danger");
                return false;

            }
            else if ($('#CalleeEmailID').val() == "" && $('#CallStatus').val() == "1") {
                notify("Please enter email ID.", "danger");
                return false;
            }
            else if ($('#CalleeQualification').val() == "" && $('#CallStatus').val() == "1") {
                notify("Please select qualification.", "danger");
                return false;
            }
            else if ($('#CenterCode').val() == "" && $('#CallStatus').val() == "1") {
                notify("Please select centre.", "danger");
                return false;
            }
            else if ($('#UniversityID').val() == "" && $('#CallStatus').val() == "1") {
                notify("Please select university.", "danger");
                return false;
            }
            else if ($('#CalleeQualification').val() == "" && $('#CallStatus').val() == "1") {
                notify("Please select qualification.", "danger");
                return false;
            }
            else if ($('#BranchDetailID').val() == "" && $('#CallStatus').val() == "1") {
                notify("Please select course.", "danger");
                return false;
            }
            else if ($('#StandardNumber').val() == "" && $('#CallStatus').val() == "1") {
                notify("Please select standard.", "danger");
                return false;
            }

            else if ($('#ConcernArea').val() == "6" && $('#OtherConcernArea').val() == "") {
                notify("Please enter other concern area.", "danger");
                return false;
            }
            else if ($('#CallerRemark').val() == "") {
                notify("Please enter call remark.", "danger");
                return false;
            }

            else {
                $('#CreateNewAdmissionRecord').attr("disabled", true);
                CRMCallMasterAndDetails.AjaxCallCRMCallMasterAndDetails();
            }
        });

        $("#CenterCode").change(function () {

            var selectedItem = $(this).val();
            var $ddlUniversity = $("#UniversityID");
            var $UniversityProgress = $("#states-loading-progress");
            $UniversityProgress.show();
            if ($("#CenterCode").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/CRMCallMasterAndDetails/GetUniversityByCentreCode",
                    data: { "SelectedCentreCode": selectedItem },
                    success: function (data) {
                        $ddlUniversity.html('');
                        $ddlUniversity.append('<option value="">--Select University--</option>');

                        $.each(data, function (id, option) {

                            $ddlUniversity.append($('<option></option>').val(option.id).html(option.name));

                        });
                        $UniversityProgress.hide();
                        $('#BranchDetailID').find('option').remove().end().append('<option value>--Select Course--</option>');
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve University.');
                        $UniversityProgress.hide();
                    }
                });
            }
            else {
                $('#myDataTable tbody').empty();
                $('#UniversityID').find('option').remove().end().append('<option value>--Select University--</option>');
                $('#BranchDetailID').find('option').remove().end().append('<option value>--Select Course--</option>');
                // $('#btnCreate').hide();
            }
        });

        $("#SelectedJobID").change(function () {
            //alert($(this).val());
            $('#myDataTable').html("");
            $('#myDataTable_info').text("No entries to show");
            $('.pagination').html('');
            $('.pagination').html('<li class="fg-button ui-button ui-state-default first disabled" id="myDataTable_first"><a href="#" aria-controls="myDataTable" data-dt-idx="0" tabindex="0"><i class="zmdi zmdi-more-horiz"></i></a></li><li class="fg-button ui-button ui-state-default previous disabled" id="myDataTable_previous"><a href="#" aria-controls="myDataTable" data-dt-idx="1" tabindex="0"><i class="zmdi zmdi-chevron-left"></i></a></li><li class="fg-button ui-button ui-state-default next disabled" id="myDataTable_next"><a href="#" aria-controls="myDataTable" data-dt-idx="2" tabindex="0"><i class="zmdi zmdi-chevron-right"></i></a></li><li class="fg-button ui-button ui-state-default last disabled" id="myDataTable_last"><a href="#" aria-controls="myDataTable" data-dt-idx="3" tabindex="0"><i class="zmdi zmdi-more-horiz"></i></a></li>');
        });
        $("#SelectedJobStatus").change(function () {
            $('#myDataTable').html("");
            $('#myDataTable_info').text("No entries to show");
            $('.pagination').html('');
            $('.pagination').html('<li class="fg-button ui-button ui-state-default first disabled" id="myDataTable_first"><a href="#" aria-controls="myDataTable" data-dt-idx="0" tabindex="0"><i class="zmdi zmdi-more-horiz"></i></a></li><li class="fg-button ui-button ui-state-default previous disabled" id="myDataTable_previous"><a href="#" aria-controls="myDataTable" data-dt-idx="1" tabindex="0"><i class="zmdi zmdi-chevron-left"></i></a></li><li class="fg-button ui-button ui-state-default next disabled" id="myDataTable_next"><a href="#" aria-controls="myDataTable" data-dt-idx="2" tabindex="0"><i class="zmdi zmdi-chevron-right"></i></a></li><li class="fg-button ui-button ui-state-default last disabled" id="myDataTable_last"><a href="#" aria-controls="myDataTable" data-dt-idx="3" tabindex="0"><i class="zmdi zmdi-more-horiz"></i></a></li>');
        });


        // select for Branch 
        $("#UniversityID").change(function () {
            var selectedItem = $(this).val();
            var centreCode = $("#CenterCode").val();
            var $ddlBranchDetails = $("#BranchDetailID");
            var $BranchDetailsProgress = $("#states-loading-progress");
            $BranchDetailsProgress.show();
            if ($("#UniversityID").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/CRMCallMasterAndDetails/GetBranchDetailByUniversityIDAndCentreCode",
                    data: { "SelectedUniversityID": selectedItem, "SelectedCentreCode": centreCode },
                    success: function (data) {
                        $ddlBranchDetails.html('');
                        $ddlBranchDetails.append('<option value="">--Select Course--</option>');
                        $.each(data, function (id, option) {

                            $ddlBranchDetails.append($('<option></option>').val(option.id).html(option.name));
                        });
                        $BranchDetailsProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Branch.');
                        $BranchDetailsProgress.hide();
                    }
                });
            }
            else {
                $('#myDataTable tbody').empty();
                $('#BranchDetailID').find('option').remove().end().append('<option value>--Select Course--</option>');
                $('#btnCreate').hide();
            }
        });

        // for Admission Pattern
        $("#StandardNumber").change(function () {
            var length = $('#AdmissionPattern > option').length;
            var selectedStandardNumber = $(this).val();
            if (selectedStandardNumber == "1") {
                $("#AdmissionPattern").prop('disabled', true);
                $("#AdmissionPattern").append($('<option></option>').val("1").html("New"));
                $('#AdmissionPattern').val("1");
                $("#AdmissionPattern option[value='2']").remove();
                $("#AdmissionPattern option[value='3']").remove();
                //    $("#AdmissionPattern option[value='4']").remove();

            }
            else if (selectedStandardNumber == "") {
                $("#AdmissionPattern option[value='1']").remove();
                $("#AdmissionPattern option[value='3']").remove();
                $("#AdmissionPattern option[value='2']").remove();
                $("#AdmissionPattern option[value='4']").remove();
                $("#AdmissionPattern").append($('<option></option>').val("").html("--Select Admission Pattern--"));
                $('#AdmissionPattern').val("");
            }
            else {
                if (length == 1) {
                    $("#AdmissionPattern").prop('disabled', false);
                    $("#AdmissionPattern option[value='1']").remove();
                    $("#AdmissionPattern option[value='']").remove();
                    // $("#AdmissionPattern").append($('<option></option>').val("4").html("--Select Admission Pattern--"));
                    $("#AdmissionPattern").append($('<option></option>').val("3").html("Direct"));
                    $("#AdmissionPattern").append($('<option></option>').val("2").html("Tranfary"));
                }
                    //  else if (length == 0) {
                else if (length != 1) {
                    $("#AdmissionPattern").prop('disabled', false);
                    $("#AdmissionPattern option[value='1']").remove();
                    $("#AdmissionPattern option[value='3']").remove();
                    $("#AdmissionPattern option[value='2']").remove();
                    $("#AdmissionPattern option[value='']").remove();
                    $("#AdmissionPattern").append($('<option></option>').val("3").html("Direct"));
                    $("#AdmissionPattern").append($('<option></option>').val("2").html("Tranfary"));

                    $('#AdmissionPattern').val("3");
                }
            }

        });

        $("#CallerJobStatus").change(function () {

            var selectedCallerJobStatus = $(this).val();
            $("#CallStatus option[value='3']").remove();
            $("#CallStatus option[value='2']").remove();
            $("#CallStatus option[value='1']").remove();
            $("#CallStatus option[value='0']").remove();
            $("#DivNextCallDate").hide(true);
            $(".hiddenMandetory").hide();
            if (selectedCallerJobStatus == "1") {

                ///$("#CallStatus").append($('<option></option>').val("0").html("--Select Call Job--"));
                $("#CallStatus").append($('<option></option>').val("3").html("Failed"));
                $("#CallStatus").append($('<option></option>').val("1").html("Converted"));
            }
            else if (selectedCallerJobStatus == "2") {

                $("#DivNextCallDate").show(true);
                $("#CallStatus").append($('<option></option>').val("2").html("Callback"));
            }


        });
        $("#CallStatus").change(function () {

            var selectedCallerJobStatus = $(this).val();
            if (selectedCallerJobStatus == "1") {
                $(".hiddenMandetory").show();
            }
            else {
                $(".hiddenMandetory").hide();
            }


        });
        $('#btnShowList').click(function () {
            var valuJobID = $('#SelectedJobID :selected').val();
            var valuCallerJobStatus = $('#CallerJobStatus').val();
            if (valuJobID != "") {
                CRMCallMasterAndDetails.LoadList(valuJobID, valuCallerJobStatus);
            }
            else {
                // ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectCentre", "SuccessMessage", "#FFCC80");
                //$('#SuccessMessage').html("Please select job.");
                //$('#SuccessMessage').delay(400).slideDown(400).delay(1500).slideUp(400).css('background-color', "#FFCC80");
                notify("Please select job.", "danger");
                return false;
            }
        });

       
        
       

        $('#CalleeMobileNo').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });

        $('#CalleeMobileNo').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });

        $('#CalleeOccupation').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#CalleeDesignation').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#ConcernArea').change(function () {
            if ($(this).val() == "6") {
                $('#divOtherConcernArea').fadeIn("slow");
            }
            else {
                $('#divOtherConcernArea').fadeOut("slow");
            }
        });

        //serachlistfor Location
        //$("#CalleeLocation").autocomplete({

        //    source: function (request, response) {
        //        $.ajax({
        //            url: "/StudentRegistrationForm/GetLocationList",
        //            type: "POST",
        //            dataType: "json",
        //            data: { term: request.term, maxResults: 10 }, //1 for current year student
        //            //{ term: request.term, maxResults: 10, courseYearID: $("#SelectedCourseYearId :selected").val(), sectionDetailID: $("#SelectedSectionDetailID :selected").val(), SessionID: $("#SelectedAcademicYear :selected").val() }, //1 for current year student
        //            success: function (data) {
        //                //alert(data)
        //                response($.map(data, function (item) {
        //                    return { label: item.LocationAddress, value: item.LocationAddress, id: item.id };

        //                }))
        //            }
        //        })
        //    },
        //    select: function (event, ui) {
        //        //alert(ui.item.id);
        //        $(this).val(ui.item.label);                                             // display the selected text
        //        $("#CalleeLocationID").val(ui.item.id);
        //    }
        //});
        InitAnimatedBorder();
        CloseAlert();
    },
    //LoadList method is used to load List page
    LoadList: function (SelectedJobID, SelectedJobStatus) {

        $.ajax(
          {
              cache: false,
              type: "POST",
              //  data: { jobID: SelectedJobID, jobStatus: SelectedJobStatus },
              dataType: "html",
              url: '/CRMCallMasterAndDetails/List',
              success: function (result) {
                  //Rebind Grid Data                
                  $('#ListViewModel').html(result);
              }
          });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallCRMCallMasterAndDetails: function () {
        var CRMCallMasterAndDetailsData = null;
        if (CRMCallMasterAndDetails.ActionName == "CreateNewAdmission") {
            CRMCallMasterAndDetailsData = null;
            CRMCallMasterAndDetailsData = CRMCallMasterAndDetails.GetCRMCallMasterAndDetails();
            ajaxRequest.makeRequest("/CRMCallMasterAndDetails/CreateNewAdmission", "POST", CRMCallMasterAndDetailsData, CRMCallMasterAndDetails.Success);
        }

    },
    //Get properties data from the Create, Update and Delete page
    GetCRMCallMasterAndDetails: function () {
        var Data = {
        };
        if (CRMCallMasterAndDetails.ActionName == "CreateNewAdmission") {

            Data.JobAllocationID = $('input[name=JobAllocationID]').val();
            Data.SelectedJobCallerStatus = $('input[name=SelectedJobCallerStatus]').val();
            Data.JobID = $('input[name=JobID]').val();
            Data.CalleeFirstName = $("#CalleeFirstName").val();
            Data.CalleeEmailID = $("#CalleeEmailID").val();
            Data.CallStatus = $("#CallStatus").val();
            Data.CallerJobStatus = $("#CallerJobStatus").val();
            Data.CallerRemark = $("#CallerRemark").val();
            Data.NextCallDate = $("#NextCallDate").val();
            Data.ConcernArea = $("#ConcernArea").val();
            Data.Interestlevel = $("#Interestlevel").val();
            Data.OtherConcernArea = $("#OtherConcernArea").val();
            if ($("#CallTimeID").val() == '')
            { Data.CallTimeID = 0 }
            else {
                Data.CallTimeID = $("#CallTimeID").val();
            }

            if ($('#Male').is(':checked')) {
                Data.CalleeGender = "M";
            }
            else if ($('#Female').is(':checked')) {
                Data.CalleeGender = "F";
            }
            var CallAnswerXML1 = "<rows><row>";

            if ($("#CalleeTitle").val() != "" && $("#CalleeTitle").val() != null) {
                CallAnswerXML1 = CallAnswerXML1 + "<CalleeTitle>" + $("#CalleeTitle").val() + "</CalleeTitle>";
            }
            else { CallAnswerXML1 = CallAnswerXML1 + "<CalleeTitle></CalleeTitle>"; }

            if ($("#CalleeFirstName").val() != "" && $("#CalleeFirstName").val() != null) {
                CallAnswerXML1 = CallAnswerXML1 + "<CalleeFirstName>" + $("#CalleeFirstName").val() + "</CalleeFirstName>";
            }
            else { CallAnswerXML1 = CallAnswerXML1 + "<CalleeFirstName></CalleeFirstName>"; }

            if ($("#CalleeMiddelName").val() != "" && $("#CalleeMiddelName").val() != null) {
                CallAnswerXML1 = CallAnswerXML1 + "<CalleeMiddelName>" + $("#CalleeMiddelName").val() + "</CalleeMiddelName>";
            }
            else { CallAnswerXML1 = CallAnswerXML1 + "<CalleeMiddelName></CalleeMiddelName>"; }

            if ($("#CalleeLastName").val() != "" && $("#CalleeLastName").val() != null) {
                CallAnswerXML1 = CallAnswerXML1 + "<CalleeLastName>" + $("#CalleeLastName").val() + "</CalleeLastName>";
            }
            else { CallAnswerXML1 = CallAnswerXML1 + "<CalleeLastName></CalleeLastName>"; }

            if ($("#CalleeMobileNo").val() != "" && $("#CalleeMobileNo").val() != null) {
                CallAnswerXML1 = CallAnswerXML1 + "<CalleeMobileNo>" + $("#CalleeMobileNo").val() + "</CalleeMobileNo>";
            }
            else { CallAnswerXML1 = CallAnswerXML1 + "<CalleeMobileNo></CalleeMobileNo>"; }

            if ($("#CalleeEmailID").val() != "" && $("#CalleeEmailID").val() != null) {
                CallAnswerXML1 = CallAnswerXML1 + "<CalleeEmailID>" + $("#CalleeEmailID").val() + "</CalleeEmailID>";
            }
            else { CallAnswerXML1 = CallAnswerXML1 + "<CalleeEmailID></CalleeEmailID>"; }

            if (Data.CalleeGender != "" && Data.CalleeGender != null) {
                CallAnswerXML1 = CallAnswerXML1 + "<CalleeGender>" + Data.CalleeGender + "</CalleeGender>";
            }
            else { CallAnswerXML1 = CallAnswerXML1 + "<CalleeGender></CalleeGender>"; }
            if ($("#Source").val() != "" && $("#Source").val() != null) {
                CallAnswerXML1 = CallAnswerXML1 + "<Source>" + $("#Source").val() + "</Source>";
            }
            else { CallAnswerXML1 = CallAnswerXML1 + "<Source></Source>"; }

            if ($("#CalleeLocation").val() != "" && $("#CalleeLocation").val() != null) {
                CallAnswerXML1 = CallAnswerXML1 + "<CalleeLocation>" + $("#CalleeLocation").val() + "</CalleeLocation>";
            }
            else { CallAnswerXML1 = CallAnswerXML1 + "<CalleeLocation></CalleeLocation>"; }

            if ($("#CalleeLocationID").val() != "" && $("#CalleeLocationID").val() != null) {
                CallAnswerXML1 = CallAnswerXML1 + "<CalleeLocationID>" + $("#CalleeLocationID").val() + "</CalleeLocationID>";
            }
            else { CallAnswerXML1 = CallAnswerXML1 + "<CalleeLocationID>0</CalleeLocationID>"; }

            if ($("#CalleeNationalityID").val() != "" && $("#CalleeNationalityID").val() != null) {
                CallAnswerXML1 = CallAnswerXML1 + "<CalleeNationalityID>" + $("#CalleeNationalityID").val() + "</CalleeNationalityID>";
            }
            else { CallAnswerXML1 = CallAnswerXML1 + "<CalleeNationalityID>0</CalleeNationalityID>"; }

            if ($("#CalleeOccupation").val() != "" && $("#CalleeOccupation").val() != null) {
                CallAnswerXML1 = CallAnswerXML1 + "<CalleeOccupation>" + $("#CalleeOccupation").val() + "</CalleeOccupation>";
            }
            else { CallAnswerXML1 = CallAnswerXML1 + "<CalleeOccupation></CalleeOccupation>"; }

            if ($("#CalleeDesignation").val() != "" && $("#CalleeDesignation").val() != null) {
                CallAnswerXML1 = CallAnswerXML1 + "<CalleeDesignation>" + $("#CalleeDesignation").val() + "</CalleeDesignation>";
            }
            else { CallAnswerXML1 = CallAnswerXML1 + "<CalleeDesignation></CalleeDesignation>"; }

            if ($("#CalleeDepartment").val() != "" && $("#CalleeDepartment").val() != null) {
                CallAnswerXML1 = CallAnswerXML1 + "<CalleeDepartment>" + $("#CalleeDepartment").val() + "</CalleeDepartment>";
            }
            else { CallAnswerXML1 = CallAnswerXML1 + "<CalleeDepartment></CalleeDepartment>"; }

            if ($("#CalleeExperience").val() != "" && $("#CalleeExperience").val() != null) {
                CallAnswerXML1 = CallAnswerXML1 + "<CalleeExperience>" + $("#CalleeExperience").val() + "</CalleeExperience>";
            }
            else { CallAnswerXML1 = CallAnswerXML1 + "<CalleeExperience></CalleeExperience>"; }

            if ($("#CalleeQualification").val() != "" && $("#CalleeQualification").val() != null) {
                CallAnswerXML1 = CallAnswerXML1 + "<CalleeQualification>" + $("#CalleeQualification").val() + "</CalleeQualification>";
            }
            else { CallAnswerXML1 = CallAnswerXML1 + "<CalleeQualification>0</CalleeQualification>"; }

            if ($("#EnglishFluency").val() != "" && $("#EnglishFluency").val() != null) {
                CallAnswerXML1 = CallAnswerXML1 + "<EnglishFluency>" + $("#EnglishFluency").val() + "</EnglishFluency>";
            }
            else { CallAnswerXML1 = CallAnswerXML1 + "<EnglishFluency>0</EnglishFluency>"; }

            if ($("#CenterCode").val() != "" && $("#CenterCode").val() != null) {
                CallAnswerXML1 = CallAnswerXML1 + "<CenterCode>" + $("#CenterCode").val() + "</CenterCode>";
            }
            else { CallAnswerXML1 = CallAnswerXML1 + "<CenterCode></CenterCode>"; }

            if ($("#UniversityID").val() != "" && $("#UniversityID").val() != null) {
                CallAnswerXML1 = CallAnswerXML1 + "<UniversityID>" + $("#UniversityID").val() + "</UniversityID>";
            }
            else { CallAnswerXML1 = CallAnswerXML1 + "<UniversityID>0</UniversityID>"; }

            if ($("#BranchDetailID").val() != "" && $("#BranchDetailID").val() != null) {
                CallAnswerXML1 = CallAnswerXML1 + "<BranchDetailID>" + $("#BranchDetailID").val() + "</BranchDetailID>";
            }
            else { CallAnswerXML1 = CallAnswerXML1 + "<BranchDetailID>0</BranchDetailID>"; }

            if ($("#StandardNumber").val() != "" && $("#StandardNumber").val() != null) {
                CallAnswerXML1 = CallAnswerXML1 + "<StandardNumber>" + $("#StandardNumber").val() + "</StandardNumber>";
            }
            else { CallAnswerXML1 = CallAnswerXML1 + "<StandardNumber>0</StandardNumber>"; }

            if ($("#AdmissionPattern").val() != "" && $("#AdmissionPattern").val() != null) {
                CallAnswerXML1 = CallAnswerXML1 + "<AdmissionPattern>" + $("#AdmissionPattern").val() + "</AdmissionPattern>";
            }
            else { CallAnswerXML1 = CallAnswerXML1 + "<AdmissionPattern>0</AdmissionPattern>"; }

            if ($("#CalleeInterestedProgram").val() != "" && $("#CalleeInterestedProgram").val() != null) {
                CallAnswerXML1 = CallAnswerXML1 + "<CalleeInterestedProgram>" + $("#CalleeInterestedProgram").val() + "</CalleeInterestedProgram>";
            }
            else { CallAnswerXML1 = CallAnswerXML1 + "<CalleeInterestedProgram></CalleeInterestedProgram>"; }


        }
        CallAnswerXML1 = CallAnswerXML1 + "</row></rows>";
        Data.CallAnswerXML = CallAnswerXML1;
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {

        var splitData = data.split(',');
        if (data != null) {
            //$('#SuccessMessage').html(splitData[0]);
            //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', splitData[1]);
            window.location = '/CRMCallMasterAndDetails?jobID=' + splitData[3] + '&callerJobStatus=' + splitData[4];

        } else {
            //$('#SuccessMessage').html(splitData[0]);
            //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', splitData[1]);
            window.location = '/CRMCallMasterAndDetails?jobID=' + splitData[3] + '&callerJobStatus=' + splitData[4];
            

        }

    },

};

