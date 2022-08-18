//var OrganisationSubGrpRuleSessionwise = {
//    ActionName: null,
//    Initialize: function () {

//        OrganisationSubGrpRuleSessionwise.constructor();       
//    },
//    constructor: function () {

//        $("#SelectedCentreCode").change(function () {
//            var selectedItem = $(this).val();
//            var $ddlUniversity = $("#SelectedUniversityID");
//            var $UniversityProgress = $("#states-loading-progress");
//            $UniversityProgress.show();
//            if ($("#SelectedCentreCode").val() != "") {
//                $.ajax({
//                    cache: false,
//                    type: "GET",
//                    url: "/OrganisationSubGrpRuleSessionwise/GetUniversityByCentreCode",

//                    data: { "SelectedCentreCode": selectedItem },
//                    success: function (data) {
//                        $ddlUniversity.html('');
//                        $ddlUniversity.append('<option value="">--------Select University-------</option>');
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
//                OrganisationSubGrpRuleSessionwise.LoadListByCentreCodeAndUniversityID(valuCentreCode, valuUniversityID);
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

//            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
//            $('input:checkbox,input:radio').removeAttr('checked');
//            $('#StreamID').focus();
//            var dt = new Date();
//            $('#StreamID').val(0);
//            $('#PresentIntake').val(0);
//            $('#IntroductionYear').val(dt.getFullYear());
//            $('#BranchPrintingSequence').val('0');
//            return false;
//        });






//        $('#IntroductionYear').on("keydown", function (e) {
//            AMSValidation.AllowNumbersOnly(e);
//        });
//        $('#PresentIntake').on("keydown", function (e) {
//            AMSValidation.AllowNumbersOnly(e);
//        });
//        // Create new record
//        $('#CreateOrganisationSubGrpRuleSessionwiseRecord').on("click", function () {
            
//            OrganisationSubGrpRuleSessionwise.ActionName = "Create";
//            OrganisationSubGrpRuleSessionwise.AjaxCallOrganisationSubGrpRuleSessionwise();
//        });

//        $('#EditOrganisationSubGrpRuleSessionwiseRecord').on("click", function () {

//            OrganisationSubGrpRuleSessionwise.ActionName = "Edit";
//            OrganisationSubGrpRuleSessionwise.AjaxCallOrganisationSubGrpRuleSessionwise();
//        });

//        $('#DeleteOrganisationSubGrpRuleSessionwiseRecord').on("click", function () {

//            OrganisationSubGrpRuleSessionwise.ActionName = "Delete";
//            OrganisationSubGrpRuleSessionwise.AjaxCallOrganisationSubGrpRuleSessionwise();
//        });

//        $("#UserSearch").keyup(function () {
//            var oTable = $("#myDataTable").dataTable();
//            oTable.fnFilter(this.value);
//        });

//        $("#searchBtn").click(function () {
//            $("#UserSearch").focus();
//        });

//        $('#closeBtn').on("click", function () {
//            parent.$.colorbox.close();
//        });
//        $("#showrecord").change(function () {
//            var showRecord = $("#showrecord").val();
//            $("select[name*='myDataTable_length']").val(showRecord);
//            $("select[name*='myDataTable_length']").change();
//        });

//        $(".ajax").colorbox();


//    },
   
//    LoadList: function () {

//        $.ajax(

//         {
//             cache: false,
//             type: "POST",

//             dataType: "html",
//             url: '/OrganisationSubGrpRuleSessionwise/List',
//             success: function (data) {
//                 //Rebind Grid Data
//                 $('#ListViewModel').html(data);
//             }
//         });
//    },
   
//    ReloadList: function (message, colorCode, actionMode) {

//        var SelectedCentreCode = $('#SelectedCentreCode option:selected').val();
//        var SelectedUniversityID = $('#SelectedUniversityID option:selected').val();
//        var SelectedSessionID = $('#SelectedSessionID option:selected').val();
//        var SelectedSessionName = $('#SelectedSessionID option:selected').text();
//        $.ajax(
//        {
//            cache: false,
//            type: "POST",
//            data: { centerCode: SelectedCentreCode, universityID: SelectedUniversityID, sessionID: SelectedSessionID, sessionName: SelectedSessionName ,actionMode:actionMode },
//            dataType: "html",
//            url: '/OrganisationSubGrpRuleSessionwise/List',
//            success: function (data) {
//                //Rebind Grid Data
//                $("#ListViewModel").empty().append(data);
//                //twitter type notification
//                $('#SuccessMessage').html(message);
//                $('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', colorCode);

//            }
//        });
//    },

//    LoadListByCentreCodeAndUniversityID: function (SelectedCentreCode, SelectedUniversityID) {
//        $.ajax(
//          {
//              cache: false,
//              type: "POST",
//              data: { centerCode: SelectedCentreCode, universityID: SelectedUniversityID },
//              dataType: "html",
//              url: '/OrganisationSubGrpRuleSessionwise/List',
//              success: function (result) {
//                  //Rebind Grid Data                
//                  $('#ListViewModel').html(result);
//                  $('#LiSessionName').show(true);
//              }
//          });
//    },
  


  
//    AjaxCallOrganisationSubGrpRuleSessionwise: function () {
//        var OrganisationSubGrpRuleSessionwiseData = null;
//        if (OrganisationSubGrpRuleSessionwise.ActionName == "Create") {
//            $("#FormCreateOrganisationSubGrpRuleSessionwise").validate();
//            if ($("#FormCreateOrganisationSubGrpRuleSessionwise").valid()) {
//                OrganisationSubGrpRuleSessionwiseData = null;
//                OrganisationSubGrpRuleSessionwiseData = OrganisationSubGrpRuleSessionwise.GetOrganisationSubGrpRuleSessionwise();
//                ajaxRequest.makeRequest("/OrganisationSubGrpRuleSessionwise/Create", "POST", OrganisationSubGrpRuleSessionwiseData, OrganisationSubGrpRuleSessionwise.Success);
//            }
//        }
//        else if (OrganisationSubGrpRuleSessionwise.ActionName == "Edit") {
//            $("#FormEditOrganisationSubGrpRuleSessionwise").validate();
//            if ($("#FormEditOrganisationSubGrpRuleSessionwise").valid()) {
//                OrganisationSubGrpRuleSessionwiseData = null;
//                OrganisationSubGrpRuleSessionwiseData = OrganisationSubGrpRuleSessionwise.GetOrganisationSubGrpRuleSessionwise();
//                ajaxRequest.makeRequest("/OrganisationSubGrpRuleSessionwise/Edit", "POST", OrganisationSubGrpRuleSessionwiseData, OrganisationSubGrpRuleSessionwise.Success);
//            }
//        }
//        else if (OrganisationSubGrpRuleSessionwise.ActionName == "Delete") {
//            OrganisationSubGrpRuleSessionwiseData = null;
//            //$("#FormCreateOrganisationSubGrpRuleSessionwise").validate();
//            OrganisationSubGrpRuleSessionwiseData = OrganisationSubGrpRuleSessionwise.GetOrganisationSubGrpRuleSessionwise();
//            ajaxRequest.makeRequest("/OrganisationSubGrpRuleSessionwise/Delete", "POST", OrganisationSubGrpRuleSessionwiseData, OrganisationSubGrpRuleSessionwise.deleteSuccess);

//        }
//    },
   
//    GetOrganisationSubGrpRuleSessionwise: function () {

//        var Data = {
//        };
//        if (OrganisationSubGrpRuleSessionwise.ActionName == "Create" || OrganisationSubGrpRuleSessionwise.ActionName == "Edit") {
//            Data.CourseYearSemesterID = $('input[name=CourseYearSemesterID]').val();
//            Data.ID = $('input[name=ID]').val();
//            Data.SubjectRuleGrpNumber = $('#SubjectRuleGrpNumber').val();
//            Data.SessionID = $('#SessionID').val();
//            Data.OrgSessionCryAllocationID = $('#OrgSessionCryAllocationID').val();
//            Data.IsActive = $('input[name=IsActive]:checked').val() ? true : false;
            
//        }
//        else if (OrganisationSubGrpRuleSessionwise.ActionName == "Delete") {
//            Data.ID = $('input[name=ID]').val();

//        }
//        return Data;
//    },

//    //createSuccess: function (data) {

//    //    var splitdata = data.split("::");
//    //    var splitCentreCode = splitdata[1].split(":");
//    //    var splitUniversityID = splitdata[2].split(":");
//    //    parent.$.colorbox.close();

//    //    //if (data == "True") {
//    //    //    //Reload List
//    //    //OrganisationSubGrpRuleSessionwise.LoadListByCentreCodeAndUniversityID(splitCentreCode[0], splitUniversityID[0]);
//    //    //} else {
//    //    //    $("#update-message").show();
//    //    //}
//    //},
//    Success: function (data) {
       
//        var splitData = data.split(',');
//        if (data != null) {
//            parent.$.colorbox.close();
//            OrganisationSubGrpRuleSessionwise.ReloadList(splitData[0], splitData[1], splitData[2]);
//        } else {
//            parent.$.colorbox.close();
//            OrganisationSubGrpRuleSessionwise.ReloadList(splitData[0], splitData[1], splitData[2]);
//        }
//        //if ($("#update-message").html() == "True") {
//        //    //Reload List
//        //    OrganisationCentrewiseDepartment.ReloadList("Record Created Sucessfully.");
//        //} else {
//        //    $("#update-message").show();
//        //}
//    },
//    //this is used to for showing successfully record updation message and reload the list view
//    //editSuccess: function (data) {

//    //    parent.$.colorbox.close();
//    //    OrganisationSubGrpRuleSessionwise.ReloadList("Record Deleted Sucessfully.");
//    //    //
//    //    //var splitdata = data.split("::");
//    //    //var splitCentreCode = splitdata[1].split(":");
//    //    //var splitUniversityID = splitdata[2].split(":");
//    //    //parent.$.colorbox.close();
//    //    //OrganisationSubGrpRuleSessionwise.LoadListByCentreCodeAndUniversityID(splitCentreCode[0], splitUniversityID[0]);
//    //},
//    ////this is used to for showing successfully record deletion message and reload the list view
//    //deleteSuccess: function (data) {
//    //    //if ($("#update-message").html() == "True") {
//    //    //    //Reload List

//    //    var splitdata = data.split("::");
//    //    var splitCentreCode = splitdata[1].split(":");
//    //    var splitUniversityID = splitdata[2].split(":");
//    //    parent.$.colorbox.close();
//    //    // OrganisationSubGrpRuleSessionwise.ReloadList("Record Deleted Sucessfully.");
//    //    OrganisationSubGrpRuleSessionwise.LoadListByCentreCodeAndUniversityID(splitCentreCode[0], splitUniversityID[0]);
//    //    //} else {
//    //    //    $("#update-message").show();
//    //    //}
//    //},
//};

/////////////////new js////////////////////


var OrganisationSubGrpRuleSessionwise = {
    ActionName: null,
    Initialize: function () {

        OrganisationSubGrpRuleSessionwise.constructor();
    },
    constructor: function () {

        $("#SelectedCentreCode").change(function () {
            var selectedItem = $(this).val();
            var $ddlUniversity = $("#SelectedUniversityID");
            var $UniversityProgress = $("#states-loading-progress");
            $UniversityProgress.show();
            if ($("#SelectedCentreCode").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/OrganisationSubGrpRuleSessionwise/GetUniversityByCentreCode",

                    data: { "SelectedCentreCode": selectedItem },
                    success: function (data) {
                        $ddlUniversity.html('');
                        $ddlUniversity.append('<option value="">--------Select University-------</option>');
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
            //$('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
        });

        $('#btnShowList').click(function () {

            var valuCentreCode = $('#SelectedCentreCode :selected').val();
            var valuUniversityID = $('#SelectedUniversityID').val();
            if (valuCentreCode != "" && valuUniversityID > 0) {
                OrganisationSubGrpRuleSessionwise.LoadListByCentreCodeAndUniversityID(valuCentreCode, valuUniversityID);
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

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#StreamID').focus();
            var dt = new Date();
            $('#StreamID').val(0);
            $('#PresentIntake').val(0);
            $('#IntroductionYear').val(dt.getFullYear());
            $('#BranchPrintingSequence').val('0');
            return false;
        });






        $('#IntroductionYear').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        $('#PresentIntake').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        // Create new record
        $('#CreateOrganisationSubGrpRuleSessionwiseRecord').on("click", function () {

            OrganisationSubGrpRuleSessionwise.ActionName = "Create";
            OrganisationSubGrpRuleSessionwise.AjaxCallOrganisationSubGrpRuleSessionwise();
        });

        $('#EditOrganisationSubGrpRuleSessionwiseRecord').on("click", function () {

            OrganisationSubGrpRuleSessionwise.ActionName = "Edit";
            OrganisationSubGrpRuleSessionwise.AjaxCallOrganisationSubGrpRuleSessionwise();
        });

        $('#DeleteOrganisationSubGrpRuleSessionwiseRecord').on("click", function () {

            OrganisationSubGrpRuleSessionwise.ActionName = "Delete";
            OrganisationSubGrpRuleSessionwise.AjaxCallOrganisationSubGrpRuleSessionwise();
        });

        $("#UserSearch").keyup(function () {
            var oTable = $("#myDataTable").dataTable();
            oTable.fnFilter(this.value);
        });

        $("#searchBtn").click(function () {
            $("#UserSearch").focus();
        });

        $('#closeBtn').on("click", function () {
            $.magnificPopup.close();
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

    LoadList: function () {

        $.ajax(

         {
             cache: false,
             type: "POST",

             dataType: "html",
             url: '/OrganisationSubGrpRuleSessionwise/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },

    ReloadList: function (message, colorCode, actionMode) {

        var SelectedCentreCode = $('#SelectedCentreCode option:selected').val();
        var SelectedUniversityID = $('#SelectedUniversityID option:selected').val();
        var SelectedSessionID = $('#SelectedSessionID option:selected').val();
        var SelectedSessionName = $('#SelectedSessionID option:selected').text();
        $.ajax(
        {
            cache: false,
            type: "POST",
            data: { centerCode: SelectedCentreCode, universityID: SelectedUniversityID, sessionID: SelectedSessionID, sessionName: SelectedSessionName, actionMode: actionMode },
            dataType: "html",
            url: '/OrganisationSubGrpRuleSessionwise/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', colorCode);
                notify(message, colorCode);

            }
        });
    },

    LoadListByCentreCodeAndUniversityID: function (SelectedCentreCode, SelectedUniversityID) {
        $.ajax(
          {
              cache: false,
              type: "POST",
              data: { centerCode: SelectedCentreCode, universityID: SelectedUniversityID },
              dataType: "html",
              url: '/OrganisationSubGrpRuleSessionwise/List',
              success: function (result) {
                  //Rebind Grid Data                
                  $('#ListViewModel').html(result);
                  $('#LiSessionName').show(true);
              }
          });
    },




    AjaxCallOrganisationSubGrpRuleSessionwise: function () {
        var OrganisationSubGrpRuleSessionwiseData = null;
        if (OrganisationSubGrpRuleSessionwise.ActionName == "Create") {
            $("#FormCreateOrganisationSubGrpRuleSessionwise").validate();
            if ($("#FormCreateOrganisationSubGrpRuleSessionwise").valid()) {
                OrganisationSubGrpRuleSessionwiseData = null;
                OrganisationSubGrpRuleSessionwiseData = OrganisationSubGrpRuleSessionwise.GetOrganisationSubGrpRuleSessionwise();
                ajaxRequest.makeRequest("/OrganisationSubGrpRuleSessionwise/Create", "POST", OrganisationSubGrpRuleSessionwiseData, OrganisationSubGrpRuleSessionwise.Success);
            }
        }
        else if (OrganisationSubGrpRuleSessionwise.ActionName == "Edit") {
            $("#FormEditOrganisationSubGrpRuleSessionwise").validate();
            if ($("#FormEditOrganisationSubGrpRuleSessionwise").valid()) {
                OrganisationSubGrpRuleSessionwiseData = null;
                OrganisationSubGrpRuleSessionwiseData = OrganisationSubGrpRuleSessionwise.GetOrganisationSubGrpRuleSessionwise();
                ajaxRequest.makeRequest("/OrganisationSubGrpRuleSessionwise/Edit", "POST", OrganisationSubGrpRuleSessionwiseData, OrganisationSubGrpRuleSessionwise.Success);
            }
        }
        else if (OrganisationSubGrpRuleSessionwise.ActionName == "Delete") {
            OrganisationSubGrpRuleSessionwiseData = null;
            //$("#FormCreateOrganisationSubGrpRuleSessionwise").validate();
            OrganisationSubGrpRuleSessionwiseData = OrganisationSubGrpRuleSessionwise.GetOrganisationSubGrpRuleSessionwise();
            ajaxRequest.makeRequest("/OrganisationSubGrpRuleSessionwise/Delete", "POST", OrganisationSubGrpRuleSessionwiseData, OrganisationSubGrpRuleSessionwise.deleteSuccess);

        }
    },

    GetOrganisationSubGrpRuleSessionwise: function () {

        var Data = {
        };
        if (OrganisationSubGrpRuleSessionwise.ActionName == "Create" || OrganisationSubGrpRuleSessionwise.ActionName == "Edit") {
            Data.CourseYearSemesterID = $('input[name=CourseYearSemesterID]').val();
            Data.ID = $('input[name=ID]').val();
            Data.SubjectRuleGrpNumber = $('#SubjectRuleGrpNumber').val();
            Data.SessionID = $('#SessionID').val();
            Data.OrgSessionCryAllocationID = $('#OrgSessionCryAllocationID').val();
            Data.IsActive = $('input[name=IsActive]:checked').val() ? true : false;

        }
        else if (OrganisationSubGrpRuleSessionwise.ActionName == "Delete") {
            Data.ID = $('input[name=ID]').val();

        }
        return Data;
    },

    
    Success: function (data) {

        var splitData = data.split(',');
        if (data != null) {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            OrganisationSubGrpRuleSessionwise.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            OrganisationSubGrpRuleSessionwise.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        //if ($("#update-message").html() == "True") {
        //    //Reload List
        //    OrganisationCentrewiseDepartment.ReloadList("Record Created Sucessfully.");
        //} else {
        //    $("#update-message").show();
        //}
    },
    
};

