////this class contain methods related to nationality functionality
//var OrganisationSessionCryrAllocation = {
//    //Member variables
//    ActionName: null,
//    //Class intialisation method
//    Initialize: function () {
//        OrganisationSessionCryrAllocation.constructor();
//    },
//    //Attach all event of page
//    constructor: function () {
//        $('#SemesterFromDate').prop('readonly', true);       
//        $('#SemesterUptoDate').prop('readonly', true);      
//        $('#PeriodStartDate').prop('readonly', true);       
//        $('#PeriodEndDate').prop('readonly', true);
      
//        $('#TotalExpectedWeeks').prop('readonly', true);

//        $("#SemesterFromDate").datepicker({
//            numberOfMonths: 1,
//            dateFormat: 'd M yy',
//            onSelect: function (selected) {
//                $("#SemesterUptoDate").datepicker("option", "minDate", selected)
//            }
//        });
//        $("#SemesterUptoDate").datepicker({
//            numberOfMonths: 1,
//            dateFormat: 'd M yy',
//            onSelect: function (selected) {
//                $("#SemesterFromDate").datepicker("option", "maxDate", selected)
//            }
//        });


//        $("#PeriodStartDate").datepicker({
//            numberOfMonths: 1,
//            dateFormat: 'dd/mm/yy',
//            onSelect: function (selected) {
//                $("#PeriodEndDate").datepicker("option", "minDate", selected)
//            }
//        });
//        $("#PeriodEndDate").datepicker({
//            numberOfMonths: 1,
//            dateFormat: 'dd/mm/yy',
//            onSelect: function (selected) {
//                $("#PeriodStartDate").datepicker("option", "maxDate", selected);
//                var PeriodStartDateArray = [];
//                PeriodStartDateArray = $('#PeriodStartDate').val().split('/');
//                var PeriodEndDateArray = [];
//                PeriodEndDateArray = $('#PeriodEndDate').val().split('/');
//                var oneDay = 24 * 60 * 60 * 1000; // hours*minutes*seconds*milliseconds
                
//                var firstDate = new Date(PeriodStartDateArray[2], PeriodStartDateArray[1], PeriodStartDateArray[0]);
//                var secondDate = new Date(PeriodEndDateArray[2], PeriodEndDateArray[1], PeriodEndDateArray[0]);
                
//                var diffDays = Math.round(Math.abs((firstDate.getTime() - secondDate.getTime()) / (oneDay)));
//                var TotalExpectedWeeks = Math.round(Math.abs(diffDays / 7));
//                $('#TotalExpectedWeeks').val(TotalExpectedWeeks);
//            }
//        });


//        $("#SelectedCentreCode").change(function () {
//            var selectedItem = $(this).val();
//            var $ddlUniversity = $("#SelectedUniversityID");
//            var $UniversityProgress = $("#states-loading-progress");
//            $UniversityProgress.show();
//            if ($("#SelectedCentreCode").val() != "") {
//                $.ajax({
//                    cache: false,
//                    type: "GET",
//                    url: "/OrganisationSessionCryrAllocation/GetUniversityByCentreCode",

//                    data: { "SelectedCentreCode": selectedItem },
//                    success: function (data) {
//                        $ddlUniversity.html('');
//                        $ddlUniversity.append('<option value="">--Select University-</option>');
//                        $.each(data, function (id, option) {

//                            $ddlUniversity.append($('<option></option>').val(option.id).html(option.name));
//                        });
//                        $UniversityProgress.hide();
//                    },
//                    error: function (xhr, ajaxOptions, thrownError) {
//                        alert('Failed to retrieve University.');
//                        $UniversityProgress.hide();
//                    }
//                });
//            }
//            else {
//                $('#myDataTable tbody').empty();
//                $('#SelectedUniversityID').find('option').remove().end().append('<option value>---Select University---</option>');
//                $('#btnCreate').hide();
//            }
//            $('#LiSessionName').hide(true);
//            $('#myDataTable').html("");
//            $('#myDataTable_info').text("No entries to show");
//            $('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
//        });

//        $('#SelectedUniversityID').on("change", function () {
//            $('#LiSessionName').hide(true);
//            $('#myDataTable').html("");
//            $('#myDataTable_info').text("No entries to show");
//            $('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
//        });

//        $('#btnShowList').click(function () {
            
//            var valuCentreCode = $('#SelectedCentreCode :selected').val();
//            var valuUniversityID = $('#SelectedUniversityID').val();
//            if (valuCentreCode != "" && valuUniversityID > 0) {
//                OrganisationSessionCryrAllocation.LoadListByCentreCodeAndUniversityID(valuCentreCode, valuUniversityID);
//            }

//            else if (valuCentreCode != "" && valuUniversityID <= 0) {
//                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectUniversity", "SuccessMessage", "#FFCC80");
//                //$('#SuccessMessage').html("Please select university");
//                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', "#FFCC80");
//                $('#LiSessionName').hide(true);
//            }
//            else if ((valuCentreCode == "" && valuUniversityID <= 0)) {
//                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectCentre", "SuccessMessage", "#FFCC80");
//                //$('#SuccessMessage').html("Please select centre");
//                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', "#FFCC80");
//                $('#LiSessionName').hide(true);
//            }
//        });

//        $("#reset").click(function () {

//           // $("input,textarea").not(':reset,:submit,:CreateOrganisationSessionCryrAllocationRecord, :button, :checkbox,:radio').val("");
//            $('#CurrentActiveSemesterFlag').removeAttr('checked');
          
//            $('#SemesterFromDate').val("");
//            $('#SemesterUptoDate').val("");
//            $('#PeriodStartDate').val("");
//            $('#PeriodEndDate').val("");
//            $('#TotalExpectedWeeks').val("");
//            $('#SemesterFromDate').focus();
           
            
//        });


//        ////$('#PeriodEndDate').on("change", function () {
//        ////    
//        ////    var PeriodStartDateArray = [];
//        ////    PeriodStartDateArray = $('#PeriodStartDate').val().split('/');
//        ////    var PeriodEndDateArray = [];
//        ////    PeriodEndDateArray = $('#PeriodEndDate').val().split('/');
//        ////    var oneDay = 24 * 60 * 60 * 1000; // hours*minutes*seconds*milliseconds
//        ////    var firstDate = new Date(PeriodStartDateArray[2], PeriodStartDateArray[1], PeriodStartDateArray[0]);
//        ////    var secondDate = new Date(PeriodEndDateArray[2], PeriodEndDateArray[1], PeriodEndDateArray[0]);
//        ////    var diffDays = Math.round(Math.abs((firstDate.getTime() - secondDate.getTime()) / (oneDay)));
//        ////    var TotalExpectedWeeks = Math.round(Math.abs(diffDays / 7));
//        ////     $('#TotalExpectedWeeks').val(TotalExpectedWeeks);
              

//        ////});




//        // Create new record
//        $('#CreateOrganisationSessionCryrAllocationRecord').on("click", function () {
//            OrganisationSessionCryrAllocation.ActionName = "Create";

//            OrganisationSessionCryrAllocation.AjaxCallOrganisationSessionCryrAllocation();
//        });




//        $('#EditOrganisationSessionCryrAllocationRecord').on("click", function () {
            
//            OrganisationSessionCryrAllocation.ActionName = "Edit";

//            OrganisationSessionCryrAllocation.AjaxCallOrganisationSessionCryrAllocation();
//        });

//        $("#UserSearch").keyup(function () {
//            var oTable = $("#myDataTable").dataTable();
//            oTable.fnFilter(this.value);
//        });

//        $("#searchBtn").click(function () {
//            $("#UserSearch").focus();
//        });


//        $("#showrecord").change(function () {
//            var showRecord = $("#showrecord").val();
//            $("select[name*='myDataTable_length']").val(showRecord);
//            $("select[name*='myDataTable_length']").change();
//        });

//        $(".ajax").colorbox();

       
           
      
//    },



//    //LoadList method is used to load List page
//    LoadList: function () {

//        $.ajax(

//         {

//             cache: false,
//             type: "POST",

//             dataType: "html",
//             url: '/OrganisationSessionCryrAllocation/List',
//             success: function (data) {
//                 //Rebind Grid Data
//                 $('#ListViewModel').html(data);
//             }
//         });
//    },
//    //ReloadList method is used to load List page
//    ReloadList: function (message, colorCode, actionMode, UniversityID, CentreCode) {

//        $.ajax(
//        {
//            cache: false,
//            type: "POST",
//            dataType: "html",
//            data: { centerCode: CentreCode, universityID: UniversityID, actionMode: actionMode },
//            url: '/OrganisationSessionCryrAllocation/List',
//            success: function (data) {
//                //Rebind Grid Data
//                $("#ListViewModel").empty().append(data);
//                //twitter type notification
//                $('#SuccessMessage').html(message);
//                $('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', colorCode);
//                $('#LiSessionName').show(true);
//            }
//        });
//    },
//    //ReloadList method is used to load List page
//    LoadListByCentreCodeAndUniversityID: function (SelectedCentreCode, SelectedUniversityID) {


//        $.ajax(
//          {
//              cache: false,
//              type: "POST",
//              data: { centerCode: SelectedCentreCode, universityID: SelectedUniversityID },

//              dataType: "html",
//              url: '/OrganisationSessionCryrAllocation/List',
//              success: function (result) {
//                  //Rebind Grid Data                
//                  $('#ListViewModel').html(result);
//                  $('#LiSessionName').show(true);
//              }
//          });
//    },

//    //Fire ajax call to insert update and delete record
//    AjaxCallOrganisationSessionCryrAllocation: function () {
//        var OrganisationSessionCryrAllocationData = null;
//        if (OrganisationSessionCryrAllocation.ActionName == "Create") {
//            $("#FormCreateOrganisationSessionCryrAllocation").validate();
//            if ($("#FormCreateOrganisationSessionCryrAllocation").valid()) {
//                OrganisationSessionCryrAllocationData = null;
//                OrganisationSessionCryrAllocationData = OrganisationSessionCryrAllocation.GetOrganisationSessionCryrAllocation();

//                ajaxRequest.makeRequest("/OrganisationSessionCryrAllocation/Create", "POST", OrganisationSessionCryrAllocationData, OrganisationSessionCryrAllocation.Success);
//            }


//        }
//        else if (OrganisationSessionCryrAllocation.ActionName == "Edit") {
//            $("#FormEditOrganisationSessionCryrAllocation").validate();
//            if ($("#FormEditOrganisationSessionCryrAllocation").valid()) {
//                OrganisationSessionCryrAllocationData = null;
//                OrganisationSessionCryrAllocationData = OrganisationSessionCryrAllocation.GetOrganisationSessionCryrAllocation();
//                ajaxRequest.makeRequest("/OrganisationSessionCryrAllocation/Edit", "POST", OrganisationSessionCryrAllocationData, OrganisationSessionCryrAllocation.Success);

//            }
//        }
      
//    },
//    //Get properties data from the Create, Update and Delete page
//    GetOrganisationSessionCryrAllocation: function () {
//        var Data=null
//         Data = {
//        };

//        if (OrganisationSessionCryrAllocation.ActionName == "Create" || OrganisationSessionCryrAllocation.ActionName == "Edit") {
//            Data.ID = $('input[name=ID]').val();
//            Data.SessionID = $('#SessionID').val();
//            Data.SemesterMasterID = $('#SemesterMasterID').val();
//            Data.SemesterType = $('#SemesterType').val();
//            Data.CourseYearSemesterID = $('#CourseYearSemesterID').val();
//            Data.SemesterFromDate = $('#SemesterFromDate').val();
//            Data.SemesterUptoDate = $('#SemesterUptoDate').val();
//            Data.CurrentActiveSemesterFlag = $('input[name=CurrentActiveSemesterFlag]:checked').val() ? true : false;
//          //  Data.CurrentActiveSemesterFlag = $('#CurrentActiveSemesterFlag').val();
//            Data.TotalExpectedWeeks = $('#TotalExpectedWeeks').val();
//            Data.PeriodStartDate = $('#PeriodStartDate').val();
//            Data.PeriodEndDate = $('#PeriodEndDate').val();
//            Data.CentreCode = $("#CentreCode").val();
//            Data.UniversityIDWithName = $("#UniversityIDWithName").val();
//        }
//        return Data;
//    },


//    //this is used to for showing successfully record creation message and reload the list view
//    Success: function (data) {
        
//        var CentreCode = data.CentreCode;
//        var UniversityID = data.UniversityIDWithName;
//        var splitData = data.errorMessage.split(',');
//        parent.$.colorbox.close();
//        OrganisationSessionCryrAllocation.ReloadList(splitData[0], splitData[1], splitData[2], UniversityID, CentreCode);
 
//    },
//    //this is used to for showing successfully record updation message and reload the list view
//    //editSuccess: function (data) {

//    //    var splitdata = data.split("::");
//    //    var splitCentreCode = splitdata[1].split(":");
//    //    var splitUniversityID = splitdata[2].split(":");
//    //    parent.$.colorbox.close();
//    //    OrganisationSessionCryrAllocation.LoadListByCentreCodeAndUniversityID(splitdata[1], splitdata[2]);
//    //},
//    ////this is used to for showing successfully record deletion message and reload the list view
//    //deleteSuccess: function (data) {
//    //    //if ($("#update-message").html() == "True") {
//    //    //    //Reload List

//    //    var splitdata = data.split("::");
//    //    var splitCentreCode = splitdata[1].split(":");
//    //    var splitUniversityID = splitdata[2].split(":");
//    //    parent.$.colorbox.close();
//    //    // OrganisationSessionCryrAllocation.ReloadList("Record Deleted Sucessfully.");
//    //    OrganisationSessionCryrAllocation.LoadListByCentreCodeAndUniversityID(splitCentreCode[0], splitUniversityID[0]);
//    //    //} else {
//    //    //    $("#update-message").show();
//    //    //}
//    //},
//};

////////////new js////////////////////////


//this class contain methods related to nationality functionality
var OrganisationSessionCryrAllocation = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        OrganisationSessionCryrAllocation.constructor();
    },
    //Attach all event of page
    constructor: function () {
        $('#SemesterFromDate').prop('readonly', true);
        $('#SemesterUptoDate').prop('readonly', true);
        $('#PeriodStartDate').prop('readonly', true);
        $('#PeriodEndDate').prop('readonly', true);

        $('#TotalExpectedWeeks').prop('readonly', true);

        //$("#SemesterFromDate").datepicker({
        //    numberOfMonths: 1,
        //    dateFormat: 'd M yy',
        //    onSelect: function (selected) {
        //        $("#SemesterUptoDate").datepicker("option", "minDate", selected)
        //    }
        //});

        //$("#SemesterUptoDate").datepicker({
        //    numberOfMonths: 1,
        //    dateFormat: 'd M yy',
        //    onSelect: function (selected) {
        //        $("#SemesterFromDate").datepicker("option", "maxDate", selected)
        //    }
        //});

        //$("#PeriodStartDate").datepicker({
        //    numberOfMonths: 1,
        //    dateFormat: 'dd/mm/yy',
        //    onSelect: function (selected) {
        //        $("#PeriodEndDate").datepicker("option", "minDate", selected)
        //    }
        //});

        //$("#PeriodEndDate").datepicker({
        //    numberOfMonths: 1,
        //    dateFormat: 'dd/mm/yy',
        //    onSelect: function (selected) {
        //        $("#PeriodStartDate").datepicker("option", "maxDate", selected);
        //        var PeriodStartDateArray = [];
        //        PeriodStartDateArray = $('#PeriodStartDate').val().split('/');
        //        var PeriodEndDateArray = [];
        //        PeriodEndDateArray = $('#PeriodEndDate').val().split('/');
        //        var oneDay = 24 * 60 * 60 * 1000; // hours*minutes*seconds*milliseconds
        //        var firstDate = new Date(PeriodStartDateArray[2], PeriodStartDateArray[1], PeriodStartDateArray[0]);
        //        var secondDate = new Date(PeriodEndDateArray[2], PeriodEndDateArray[1], PeriodEndDateArray[0]);
        //        var diffDays = Math.round(Math.abs((firstDate.getTime() - secondDate.getTime()) / (oneDay)));
        //        var TotalExpectedWeeks = Math.round(Math.abs(diffDays / 7));
        //        $('#TotalExpectedWeeks').val(TotalExpectedWeeks);
        //    }
        //});

        $('#SemesterFromDate').datetimepicker({
            format: 'DD MMMM YYYY',
            ignoreReadonly: true,
            //maxDate: moment(),
            sideBySide: true,
            widgetPositioning: {
                horizontal: 'left',
                vertical: 'bottom'
            }
        });

        $("#SemesterFromDate").on("dp.hide", function (e) {
            var minDate = new Date(e.date.valueOf());
            minDate.setDate(minDate.getDate());
            $('#SemesterUptoDate').data("DateTimePicker").minDate(minDate);
        });

        $('#SemesterUptoDate').datetimepicker({
            format: 'DD MMMM YYYY',
            ignoreReadonly: true,
            //maxDate: moment(),
            sideBySide: true,
            widgetPositioning: {
                horizontal: 'left',
                vertical: 'bottom'
            }
        });

        $("#SemesterUptoDate").on("dp.hide", function (e) {
            var maxDate = new Date(e.date.valueOf());
            maxDate.setDate(maxDate.getDate());
            $('#SemesterFromDate').data("DateTimePicker").maxDate(maxDate);
        });


        $('#PeriodStartDate').datetimepicker({
            format: 'DD MMMM YYYY',
            ignoreReadonly: true,
            //maxDate: moment(),
            sideBySide: true,
            widgetPositioning: {
                horizontal: 'left',
                vertical: 'bottom'
            }
        });

        $("#PeriodStartDate").on("dp.hide", function (e) {
            var minDate = new Date(e.date.valueOf());
            minDate.setDate(minDate.getDate());
            $('#PeriodEndDate').data("DateTimePicker").minDate(minDate);
        });
        

        $('#PeriodEndDate').datetimepicker({
            format: 'DD MMMM YYYY',
            ignoreReadonly: true,
            //maxDate: moment(),
        });

        $("#PeriodEndDate").on("dp.hide", function (e) {
            var maxDate = new Date(e.date.valueOf());
            maxDate.setDate(maxDate.getDate());
            $('#PeriodStartDate').data("DateTimePicker").maxDate(maxDate);

            var firstDate = $('#PeriodStartDate').data("DateTimePicker").date();
            var secondDate = $('#PeriodEndDate').data("DateTimePicker").date();
            var oneDay = 24 * 60 * 60 * 1000; // hours*minutes*seconds*milliseconds
            var timeDiff = new Date(secondDate) - new Date(firstDate);
            var days = Math.round(timeDiff / oneDay);
            var week = days / 7;
            
            $('#TotalExpectedWeeks').val(Math.round(week));
            


        });

        $("#SelectedCentreCode").change(function () {
            var selectedItem = $(this).val();
            var $ddlUniversity = $("#SelectedUniversityID");
            var $UniversityProgress = $("#states-loading-progress");
            $UniversityProgress.show();
            if ($("#SelectedCentreCode").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/OrganisationSessionCryrAllocation/GetUniversityByCentreCode",

                    data: { "SelectedCentreCode": selectedItem },
                    success: function (data) {
                        $ddlUniversity.html('');
                        $ddlUniversity.append('<option value="">--Select University-</option>');
                        $.each(data, function (id, option) {

                            $ddlUniversity.append($('<option></option>').val(option.id).html(option.name));
                        });
                        $UniversityProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve University.');
                        $UniversityProgress.hide();
                    }
                });
            }
            else {
                $('#myDataTable tbody').empty();
                $('#SelectedUniversityID').find('option').remove().end().append('<option value>---Select University---</option>');
                $('#btnCreate').hide();
            }
            $('#LiSessionName').hide(true);
            //$('#myDataTable').html("");
            //$('#myDataTable_info').text("No entries to show");
            //$('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
        });

        $('#SelectedUniversityID').on("change", function () {
            $('#LiSessionName').hide(true);
            //$('#myDataTable').html("");
           //$('#myDataTable_info').text("No entries to show");
           // $('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
        });

        $('#btnShowList').click(function () {

            var valuCentreCode = $('#SelectedCentreCode :selected').val();
            var valuUniversityID = $('#SelectedUniversityID').val();
            if (valuCentreCode != "" && valuUniversityID > 0) {
                OrganisationSessionCryrAllocation.LoadListByCentreCodeAndUniversityID(valuCentreCode, valuUniversityID);
            }

            else if (valuCentreCode != "" && valuUniversityID <= 0) {
                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectUniversity", "SuccessMessage", "#FFCC80");
                //$('#SuccessMessage').html("Please select university");
                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', "#FFCC80");
                $('#LiSessionName').hide(true);
            }
            else if ((valuCentreCode == "" && valuUniversityID <= 0)) {
                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectCentre", "SuccessMessage", "#FFCC80");
                //$('#SuccessMessage').html("Please select centre");
                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', "#FFCC80");
                $('#LiSessionName').hide(true);
            }
        });

        $("#reset").click(function () {

            // $("input,textarea").not(':reset,:submit,:CreateOrganisationSessionCryrAllocationRecord, :button, :checkbox,:radio').val("");
            $('#CurrentActiveSemesterFlag').removeAttr('checked');

            $('#SemesterFromDate').val("");
            $('#SemesterUptoDate').val("");
            $('#PeriodStartDate').val("");
            $('#PeriodEndDate').val("");
            $('#TotalExpectedWeeks').val("");
            $('#SemesterFromDate').focus();


        });


        




        // Create new record
        $('#CreateOrganisationSessionCryrAllocationRecord').on("click", function () {
            OrganisationSessionCryrAllocation.ActionName = "Create";

            OrganisationSessionCryrAllocation.AjaxCallOrganisationSessionCryrAllocation();
        });




        $('#EditOrganisationSessionCryrAllocationRecord').on("click", function () {

            OrganisationSessionCryrAllocation.ActionName = "Edit";

            OrganisationSessionCryrAllocation.AjaxCallOrganisationSessionCryrAllocation();
        });

        $("#UserSearch").keyup(function () {
            var oTable = $("#myDataTable").dataTable();
            oTable.fnFilter(this.value);
        });

        $("#searchBtn").click(function () {
            $("#UserSearch").focus();
        });


        $("#showrecord").change(function () {
            var showRecord = $("#showrecord").val();
            $("select[name*='myDataTable_length']").val(showRecord);
            $("select[name*='myDataTable_length']").change();
        });

        //$(".ajax").colorbox();
        InitAnimatedBorder();
        CloseAlert();




    },



    //LoadList method is used to load List page
    LoadList: function () {

        $.ajax(

         {

             cache: false,
             type: "POST",

             dataType: "html",
             url: '/OrganisationSessionCryrAllocation/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode, UniversityID, CentreCode) {

        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { centerCode: CentreCode, universityID: UniversityID, actionMode: actionMode },
            url: '/OrganisationSessionCryrAllocation/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', colorCode);
                notify(message,colorCode);
                $('#LiSessionName').show(true);
            }
        });
    },
    //ReloadList method is used to load List page
    LoadListByCentreCodeAndUniversityID: function (SelectedCentreCode, SelectedUniversityID) {


        $.ajax(
          {
              cache: false,
              type: "POST",
              data: { centerCode: SelectedCentreCode, universityID: SelectedUniversityID },

              dataType: "html",
              url: '/OrganisationSessionCryrAllocation/List',
              success: function (result) {
                  //Rebind Grid Data                
                  $('#ListViewModel').html(result);
                  $('#LiSessionName').show(true);
              }
          });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallOrganisationSessionCryrAllocation: function () {
        var OrganisationSessionCryrAllocationData = null;
        if (OrganisationSessionCryrAllocation.ActionName == "Create") {
            $("#FormCreateOrganisationSessionCryrAllocation").validate();
            if ($("#FormCreateOrganisationSessionCryrAllocation").valid()) {
                OrganisationSessionCryrAllocationData = null;
                OrganisationSessionCryrAllocationData = OrganisationSessionCryrAllocation.GetOrganisationSessionCryrAllocation();

                ajaxRequest.makeRequest("/OrganisationSessionCryrAllocation/Create", "POST", OrganisationSessionCryrAllocationData, OrganisationSessionCryrAllocation.Success);
            }


        }
        else if (OrganisationSessionCryrAllocation.ActionName == "Edit") {
            $("#FormEditOrganisationSessionCryrAllocation").validate();
            if ($("#FormEditOrganisationSessionCryrAllocation").valid()) {
                OrganisationSessionCryrAllocationData = null;
                OrganisationSessionCryrAllocationData = OrganisationSessionCryrAllocation.GetOrganisationSessionCryrAllocation();
                ajaxRequest.makeRequest("/OrganisationSessionCryrAllocation/Edit", "POST", OrganisationSessionCryrAllocationData, OrganisationSessionCryrAllocation.Success);

            }
        }

    },
    //Get properties data from the Create, Update and Delete page
    GetOrganisationSessionCryrAllocation: function () {
        var Data = null
        Data = {
        };

        if (OrganisationSessionCryrAllocation.ActionName == "Create" || OrganisationSessionCryrAllocation.ActionName == "Edit") {
            Data.ID = $('input[name=ID]').val();
            Data.SessionID = $('#SessionID').val();
            Data.SemesterMasterID = $('#SemesterMasterID').val();
            Data.SemesterType = $('#SemesterType').val();
            Data.CourseYearSemesterID = $('#CourseYearSemesterID').val();
            Data.SemesterFromDate = $('#SemesterFromDate').val();
            Data.SemesterUptoDate = $('#SemesterUptoDate').val();
            //Data.CurrentActiveSemesterFlag = $('input[name=CurrentActiveSemesterFlag]:checked').val() ? true : false;
            Data.CurrentActiveSemesterFlag = $('input[id=CurrentActiveSemesterFlag]:checked').val() ? true : false;
            //  Data.CurrentActiveSemesterFlag = $('#CurrentActiveSemesterFlag').val();
            Data.TotalExpectedWeeks = $('#TotalExpectedWeeks').val();
            Data.PeriodStartDate = $('#PeriodStartDate').val();
            Data.PeriodEndDate = $('#PeriodEndDate').val();
            Data.CentreCode = $("#CentreCode").val();
            Data.UniversityIDWithName = $("#UniversityIDWithName").val();
        }
        return Data;
    },


    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {

        var CentreCode = data.CentreCode;
        var UniversityID = data.UniversityIDWithName;
        var splitData = data.errorMessage.split(',');
        //parent.$.colorbox.close();
        $.magnificPopup.close();

        OrganisationSessionCryrAllocation.ReloadList(splitData[0], splitData[1], splitData[2], UniversityID, CentreCode);

    },
    
};

