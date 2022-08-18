////this class contain methods related to nationality functionality
//var OrganisationSectionDetails = {
//    //Member variables
//    ActionName: null,
//    //Class intialisation method
//    Initialize: function () {
//        //organisationStudyCentre.loadData();

//        OrganisationSectionDetails.constructor();
//        //generalCountryMaster.initializeValidation();
//    },
//    //Attach all event of page
//    constructor: function () {

//        $("#SelectedCentreCode").change(function () {
            
//            var selectedItem = $(this).val();
//            var $ddlUniversity = $("#SelectedUniversityID");
//            var $UniversityProgress = $("#University-loading-progress");
//            $UniversityProgress.show();
//            if ($("#SelectedCentreCode").val() != "") {
//                $.ajax({
//                    cache: false,
//                    type: "GET",
//                    url: '/OrganisationSectionDetails/GetUniversityByCentreCode',
//                    //  url: '/OrganisationSectionDetailsAdd/List',
//                    data: { "SelectedCentreCode": selectedItem },
//                    success: function (data) {
//                        $ddlUniversity.html('');
//                        $ddlUniversity.append('<option value="">-------Select University------</option>');
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
//                $('#SelectedUniversityID').find('option').remove().end().append('<option value>-------Select University------</option>');
//                $('#btnCreate').hide();
//            }
//            $('#myDataTable').html("");
//            $('#myDataTable_info').text("No entries to show");
//            $('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');

//        });

//        $("#reset").click(function () {

//            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
//            $('input:checkbox,input:radio').removeAttr('checked');
//            $('#StreamID').focus();
//            var dt = new Date();
//            $('#StreamID').val("");
//            $('#PresentIntake').val(0);
//            $('#IntroductionYear').val(dt.getFullYear());
//            $('#BranchPrintingSequence').val('0');
//            return false;
//        });



//        $('#SelectedUniversityID').on("change", function () {
//            $('#myDataTable').html("");
//            $('#myDataTable_info').text("No entries to show");
//            $('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');

//        });
//        $("#btnShowList").on("click", function () {
//            var valuCentreCode = $('#SelectedCentreCode :selected').val();
//            var valuUniversityID = $('#SelectedUniversityID :selected').val();
            
//            if (valuCentreCode != "" && valuUniversityID > 0) {
//                OrganisationSectionDetails.LoadListByCentreCodeAndUniversityID(valuCentreCode, valuUniversityID);
//            }
//            else if (valuCentreCode != "" && valuUniversityID <= 0) {
//                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectUniversity", "SuccessMessage", "#FFCC80");
//                //$('#SuccessMessage').html("Please select university");
//                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', "#FFCC80");
//            }
//            else if ((valuCentreCode == "" && valuUniversityID <= 0)) {
//                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectCentre", "SuccessMessage", "#FFCC80");
//                //$('#SuccessMessage').html("Please select centre");
//                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', "#FFCC80");
//            }
//        });

//        $('#IntroductionYear').on("keydown", function (e) {
//            AMSValidation.AllowNumbersOnly(e);
//        });
//        $('#PresentIntake').on("keydown", function (e) {
//            AMSValidation.AllowNumbersOnly(e);
//        });
//        // Create new record
//        $('#CreateOrganisationSectionDetailsRecord').on("click", function () {
            
//            OrganisationSectionDetails.ActionName = "Create";
//            OrganisationSectionDetails.AjaxCallOrganisationSectionDetails();
//        });

//        $('#EditOrganisationSectionDetailsRecord').on("click", function () {
//            OrganisationSectionDetails.ActionName = "Edit";
//            OrganisationSectionDetails.AjaxCallOrganisationSectionDetails();
//        });

//        $('#DeleteOrganisationSectionDetailsRecord').on("click", function () {

//            OrganisationSectionDetails.ActionName = "Delete";
//            OrganisationSectionDetails.AjaxCallOrganisationSectionDetails();
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
//             url: '/OrganisationSectionDetails/List',
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
//            url: '/OrganisationSectionDetails/List',
//            success: function (data) {
//                //Rebind Grid Data
//                $("#ListViewModel").empty().append(data);
//                //twitter type notification
//                $('#SuccessMessage').html(message);
//                $('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', colorCode);
//            }
//        });
//    },
//    //ReloadList method is used to load List page
//    LoadListByCentreCodeAndUniversityID: function (SelectedCentreCode, SelectedUniversityID) {

//        var selectedText = $('#SelectedUniversityID').text();
//        var selectedVal = $('#SelectedUniversityID').val();
//        $.ajax(
//          {
//              cache: false,
//              type: "POST",
//              data: { centerCode: SelectedCentreCode, universityID: SelectedUniversityID },

//              dataType: "html",
//              url: '/OrganisationSectionDetails/List',
//              success: function (result) {
//                  //Rebind Grid Data                
//                  $('#ListViewModel').html(result);

//              }
//          });
//    },

//    //Fire ajax call to insert update and delete record
//    AjaxCallOrganisationSectionDetails: function () {
//        var OrganisationSectionDetailsData = null;
//        if (OrganisationSectionDetails.ActionName == "Create") {
//            $("#FormCreateOrganisationSectionDetails").validate();
//            if ($("#FormCreateOrganisationSectionDetails").valid()) {
//                OrganisationSectionDetailsData = null;
//                OrganisationSectionDetailsData = OrganisationSectionDetails.GetOrganisationSectionDetails();
//                ajaxRequest.makeRequest("/OrganisationSectionDetails/Create", "POST", OrganisationSectionDetailsData, OrganisationSectionDetails.Success);
//            }
//        }
//        else if (OrganisationSectionDetails.ActionName == "Edit") {
//            $("#FormEditOrganisationSectionDetails").validate();
//            if ($("#FormEditOrganisationSectionDetails").valid()) {
//                OrganisationSectionDetailsData = null;
//                OrganisationSectionDetailsData = OrganisationSectionDetails.GetOrganisationSectionDetails();
//                ajaxRequest.makeRequest("/OrganisationSectionDetails/Edit", "POST", OrganisationSectionDetailsData, OrganisationSectionDetails.Success);
//            }
//        }
//        else if (OrganisationSectionDetails.ActionName == "Delete") {
//            OrganisationSectionDetailsData = null;
//            //$("#FormCreateOrganisationSectionDetails").validate();
//            OrganisationSectionDetailsData = OrganisationSectionDetails.GetOrganisationSectionDetails();
//            ajaxRequest.makeRequest("/OrganisationSectionDetails/Delete", "POST", OrganisationSectionDetailsData, OrganisationSectionDetails.Success);

//        }
//    },
//    //Get properties data from the Create, Update and Delete page
//    GetOrganisationSectionDetails: function () {

//        var Data = {
//        };
//        if (OrganisationSectionDetails.ActionName == "Create" || OrganisationSectionDetails.ActionName == "Edit") {
//            Data.ID = $('input[name=ID]').val();
//            Data.NextSectionDetailID = $('#NextSectionDetailID').val();
//            Data.IsFinalCourseYear = $('input[name=IsFinalCourseYear]:checked').val() ? true : false;
//        }
       
//        return Data;
//    },
//    //this is used to for showing successfully record creation message and reload the list view
//    Success: function (data) {
        
//        var CentreCode = data.CentreCodeWithName;
//        var UniversityID = data.UniversityIDWithName;
//        var splitData = data.errorMessage.split(',');
//        if (data != null) {
//            OrganisationSectionDetails.ReloadList(splitData[0], splitData[1], splitData[2], UniversityID, CentreCode);
//            parent.$.colorbox.close();
//        } else {
//            OrganisationSectionDetails.ReloadList(splitData[0], splitData[1], splitData[2], UniversityID, CentreCode);
//            parent.$.colorbox.close();
//        }


//        //
//        //var splitdata = data.split("::");
//        //var dataSuccess = splitdata[0];
//        //var splitCentreCode = splitdata[1].split(":");
//        //var splitUniversityID = splitdata[2].split(":");
//        //parent.$.colorbox.close();

//        //if (dataSuccess == "True") {
//        //    //Reload List
//        //    OrganisationSectionDetails.LoadListByCentreCodeAndUniversityID(splitdata[1], splitdata[2]);
//        //} else {
//        //    $("#update-message").show();
//        //}
//    },
//    ////this is used to for showing successfully record updation message and reload the list view
//    //editSuccess: function (data) {

//    //    var splitdata = data.split("::");
//    //    var splitCentreCode = splitdata[1].split(":");
//    //    var splitUniversityID = splitdata[2].split(":");
//    //    parent.$.colorbox.close();
//    //    OrganisationSectionDetails.LoadListByCentreCodeAndUniversityID(splitdata[1], splitdata[2]);
//    //},
//    ////this is used to for showing successfully record deletion message and reload the list view
//    //deleteSuccess: function (data) {
//    //    //if ($("#update-message").html() == "True") {
//    //    //    //Reload List

//    //    var splitdata = data.split("::");
//    //    var splitCentreCode = splitdata[1].split(":");
//    //    var splitUniversityID = splitdata[2].split(":");
//    //    parent.$.colorbox.close();
//    //    // OrganisationSectionDetails.ReloadList("Record Deleted Sucessfully.");
//    //    OrganisationSectionDetails.LoadListByCentreCodeAndUniversityID(splitCentreCode[0], splitUniversityID[0]);
//    //    //} else {
//    //    //    $("#update-message").show();
//    //    //}
//    //},
//};

/////////////////////new js/////////////

//this class contain methods related to nationality functionality
var OrganisationSectionDetails = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        OrganisationSectionDetails.constructor();
        //generalCountryMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $("#SelectedCentreCode").change(function () {

            var selectedItem = $(this).val();
            var $ddlUniversity = $("#SelectedUniversityID");
            var $UniversityProgress = $("#University-loading-progress");
            $UniversityProgress.show();
            if ($("#SelectedCentreCode").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: '/OrganisationSectionDetails/GetUniversityByCentreCode',
                    //  url: '/OrganisationSectionDetailsAdd/List',
                    data: { "SelectedCentreCode": selectedItem },
                    success: function (data) {
                        $ddlUniversity.html('');
                        $ddlUniversity.append('<option value="">-------Select University------</option>');
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
                $('#SelectedUniversityID').find('option').remove().end().append('<option value>-------Select University------</option>');
                $('#btnCreate').hide();
            }
            //$('#myDataTable').html("");
            //$('#myDataTable_info').text("No entries to show");
            //$('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');

        });

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#StreamID').focus();
            var dt = new Date();
            $('#StreamID').val("");
            $('#PresentIntake').val(0);
            $('#IntroductionYear').val(dt.getFullYear());
            $('#BranchPrintingSequence').val('0');
            return false;
        });



        $('#SelectedUniversityID').on("change", function () {
            //$('#myDataTable').html("");
            //$('#myDataTable_info').text("No entries to show");
            //$('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');

        });
        $("#btnShowList").on("click", function () {
            var valuCentreCode = $('#SelectedCentreCode :selected').val();
            var valuUniversityID = $('#SelectedUniversityID :selected').val();

            if (valuCentreCode != "" && valuUniversityID > 0) {
                OrganisationSectionDetails.LoadListByCentreCodeAndUniversityID(valuCentreCode, valuUniversityID);
            }
            else if (valuCentreCode != "" && valuUniversityID <= 0) {
                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectUniversity", "SuccessMessage", "#FFCC80");
                //$('#SuccessMessage').html("Please select university");
                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', "#FFCC80");
            }
            else if ((valuCentreCode == "" && valuUniversityID <= 0)) {
                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectCentre", "SuccessMessage", "#FFCC80");
                //$('#SuccessMessage').html("Please select centre");
                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', "#FFCC80");
            }
        });

        $('#IntroductionYear').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        $('#PresentIntake').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        // Create new record
        $('#CreateOrganisationSectionDetailsRecord').on("click", function () {

            OrganisationSectionDetails.ActionName = "Create";
            OrganisationSectionDetails.AjaxCallOrganisationSectionDetails();
        });

        $('#EditOrganisationSectionDetailsRecord').on("click", function () {
            OrganisationSectionDetails.ActionName = "Edit";
            OrganisationSectionDetails.AjaxCallOrganisationSectionDetails();
        });

        $('#DeleteOrganisationSectionDetailsRecord').on("click", function () {

            OrganisationSectionDetails.ActionName = "Delete";
            OrganisationSectionDetails.AjaxCallOrganisationSectionDetails();
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
             url: '/OrganisationSectionDetails/List',
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
            url: '/OrganisationSectionDetails/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', colorCode);
                notify(message,colorCode);
            }
        });
    },
    //ReloadList method is used to load List page
    LoadListByCentreCodeAndUniversityID: function (SelectedCentreCode, SelectedUniversityID) {

        var selectedText = $('#SelectedUniversityID').text();
        var selectedVal = $('#SelectedUniversityID').val();
        $.ajax(
          {
              cache: false,
              type: "POST",
              data: { centerCode: SelectedCentreCode, universityID: SelectedUniversityID },

              dataType: "html",
              url: '/OrganisationSectionDetails/List',
              success: function (result) {
                  //Rebind Grid Data                
                  $('#ListViewModel').html(result);

              }
          });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallOrganisationSectionDetails: function () {
        var OrganisationSectionDetailsData = null;
        if (OrganisationSectionDetails.ActionName == "Create") {
            $("#FormCreateOrganisationSectionDetails").validate();
            if ($("#FormCreateOrganisationSectionDetails").valid()) {
                OrganisationSectionDetailsData = null;
                OrganisationSectionDetailsData = OrganisationSectionDetails.GetOrganisationSectionDetails();
                ajaxRequest.makeRequest("/OrganisationSectionDetails/Create", "POST", OrganisationSectionDetailsData, OrganisationSectionDetails.Success);
            }
        }
        else if (OrganisationSectionDetails.ActionName == "Edit") {
            $("#FormEditOrganisationSectionDetails").validate();
            if ($("#FormEditOrganisationSectionDetails").valid()) {
                OrganisationSectionDetailsData = null;
                OrganisationSectionDetailsData = OrganisationSectionDetails.GetOrganisationSectionDetails();
                ajaxRequest.makeRequest("/OrganisationSectionDetails/Edit", "POST", OrganisationSectionDetailsData, OrganisationSectionDetails.Success);
            }
        }
        else if (OrganisationSectionDetails.ActionName == "Delete") {
            OrganisationSectionDetailsData = null;
            //$("#FormCreateOrganisationSectionDetails").validate();
            OrganisationSectionDetailsData = OrganisationSectionDetails.GetOrganisationSectionDetails();
            ajaxRequest.makeRequest("/OrganisationSectionDetails/Delete", "POST", OrganisationSectionDetailsData, OrganisationSectionDetails.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetOrganisationSectionDetails: function () {

        var Data = {
        };
        if (OrganisationSectionDetails.ActionName == "Create" || OrganisationSectionDetails.ActionName == "Edit") {
            Data.ID = $('input[name=ID]').val();
            Data.NextSectionDetailID = $('#NextSectionDetailID').val();
            //Data.IsFinalCourseYear = $('input[name=IsFinalCourseYear]:checked').val() ? true : false;
            Data.IsFinalCourseYear = $('input[id=IsFinalCourseYear]:checked').val() ? true : false;
        }

        return Data;
    },
    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {

        var CentreCode = data.CentreCodeWithName;
        var UniversityID = data.UniversityIDWithName;
        var splitData = data.errorMessage.split(',');
        if (data != null) {
            OrganisationSectionDetails.ReloadList(splitData[0], splitData[1], splitData[2], UniversityID, CentreCode);
            //parent.$.colorbox.close();
            $.magnificPopup.close();

        } else {
            OrganisationSectionDetails.ReloadList(splitData[0], splitData[1], splitData[2], UniversityID, CentreCode);
            //parent.$.colorbox.close();
            $.magnificPopup.close();
        }


        //
        //var splitdata = data.split("::");
        //var dataSuccess = splitdata[0];
        //var splitCentreCode = splitdata[1].split(":");
        //var splitUniversityID = splitdata[2].split(":");
        //parent.$.colorbox.close();

        //if (dataSuccess == "True") {
        //    //Reload List
        //    OrganisationSectionDetails.LoadListByCentreCodeAndUniversityID(splitdata[1], splitdata[2]);
        //} else {
        //    $("#update-message").show();
        //}
    },
    ////this is used to for showing successfully record updation message and reload the list view
    //editSuccess: function (data) {

    //    var splitdata = data.split("::");
    //    var splitCentreCode = splitdata[1].split(":");
    //    var splitUniversityID = splitdata[2].split(":");
    //    parent.$.colorbox.close();
    //    OrganisationSectionDetails.LoadListByCentreCodeAndUniversityID(splitdata[1], splitdata[2]);
    //},
    ////this is used to for showing successfully record deletion message and reload the list view
    //deleteSuccess: function (data) {
    //    //if ($("#update-message").html() == "True") {
    //    //    //Reload List

    //    var splitdata = data.split("::");
    //    var splitCentreCode = splitdata[1].split(":");
    //    var splitUniversityID = splitdata[2].split(":");
    //    parent.$.colorbox.close();
    //    // OrganisationSectionDetails.ReloadList("Record Deleted Sucessfully.");
    //    OrganisationSectionDetails.LoadListByCentreCodeAndUniversityID(splitCentreCode[0], splitUniversityID[0]);
    //    //} else {
    //    //    $("#update-message").show();
    //    //}
    //},
};

