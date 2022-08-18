////this class contain methods related to nationality functionality
//var OrganisationBranchDetails = {
//    //Member variables
//    ActionName: null,
//    //Class intialisation method
//    Initialize: function () {
//        //organisationStudyCentre.loadData();

//        OrganisationBranchDetails.constructor();
//        //generalCountryMaster.initializeValidation();
//    },
//    //Attach all event of page
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
//                    url: "/OrganisationBranchDetails/GetUniversityByCentreCode",
                   
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
//                OrganisationBranchDetails.LoadListByCentreCodeAndUniversityID(valuCentreCode, valuUniversityID);
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
//        $('#CreateOrganisationBranchDetailsRecord').on("click", function () {
//            OrganisationBranchDetails.ActionName = "Create";
//            OrganisationBranchDetails.AjaxCallOrganisationBranchDetails();
//        });

//        $('#EditOrganisationBranchDetailsRecord').on("click", function () {
            
//            OrganisationBranchDetails.ActionName = "Edit";
//            OrganisationBranchDetails.AjaxCallOrganisationBranchDetails();
//        });

//        $('#DeleteOrganisationBranchDetailsRecord').on("click", function () {

//            OrganisationBranchDetails.ActionName = "Delete";
//            OrganisationBranchDetails.AjaxCallOrganisationBranchDetails();
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
//             url: '/OrganisationBranchDetails/List',
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
//            url: '/OrganisationBranchDetails/List',
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
//              url: '/OrganisationBranchDetails/List',
//              success: function (result) {
//                  //Rebind Grid Data                
//                  $('#ListViewModel').html(result);

//              }
//          });
//    },

//    //Fire ajax call to insert update and delete record
//    AjaxCallOrganisationBranchDetails: function () {
//        var OrganisationBranchDetailsData = null;
//        if (OrganisationBranchDetails.ActionName == "Create") {
//            $("#FormCreateOrganisationBranchDetails").validate();
//            if ($("#FormCreateOrganisationBranchDetails").valid()) {
//                OrganisationBranchDetailsData = null;
//                OrganisationBranchDetailsData = OrganisationBranchDetails.GetOrganisationBranchDetails();
//                ajaxRequest.makeRequest("/OrganisationBranchDetails/Create", "POST", OrganisationBranchDetailsData, OrganisationBranchDetails.Success);
//            }
//        }
//        else if (OrganisationBranchDetails.ActionName == "Edit") {
//            $("#FormEditOrganisationBranchDetails").validate();
//            if ($("#FormEditOrganisationBranchDetails").valid()) {
//                OrganisationBranchDetailsData = null;
//                OrganisationBranchDetailsData = OrganisationBranchDetails.GetOrganisationBranchDetails();
//                ajaxRequest.makeRequest("/OrganisationBranchDetails/Edit", "POST", OrganisationBranchDetailsData, OrganisationBranchDetails.Success);
//            }
//        }
//        else if (OrganisationBranchDetails.ActionName == "Delete") {
//            OrganisationBranchDetailsData = null;
//            //$("#FormCreateOrganisationBranchDetails").validate();
//            OrganisationBranchDetailsData = OrganisationBranchDetails.GetOrganisationBranchDetails();
            
//            ajaxRequest.makeRequest("/OrganisationBranchDetails/Delete", "POST", OrganisationBranchDetailsData, OrganisationBranchDetails.Success);

//        }
//    },
//    //Get properties data from the Create, Update and Delete page
//    GetOrganisationBranchDetails: function () {
   
//        var Data = {
//        };
//        if (OrganisationBranchDetails.ActionName == "Create" || OrganisationBranchDetails.ActionName == "Edit") {
//            Data.ID = $('input[name=ID]').val();
//            Data.BranchID = $('#BranchID').val();
//           // Data.SelectedStreamID = $('#SelectedStreamID').val();
//            Data.CentreCode = $('#CentreCode').val();
//            Data.CentreName = $('#SelectedCentreCode').text();
//            Data.PresentIntake = $('#PresentIntake').val();
//            Data.IntroductionYear = $('#IntroductionYear').val();
//            Data.StreamID = $('#StreamID').val();
//            Data.UniversityIDWithName = $("#SelectedUniversityID").val();
//            Data.DteCode = $('#DteCode').val();
//            Data.BranchPrintingSequence = $('#BranchPrintingSequence').val();

//            //if (OrganisationBranchDetails.ActionName == "Create") {

//            //}
//            if (OrganisationBranchDetails.ActionName == "Edit") {
           
//                Data.SelectedStreamID = $('#SelectedStreamID').val();
//                Data.CentreCode = $('#CentreCode').val();
//                Data.UniversityIdWithName = $('input[name=SelectedUniversityID]').val();
               
//            }
//        }
//        else if (OrganisationBranchDetails.ActionName == "Delete") {
//            Data.ID = $('input[name=ID]').val();
           
//        }
//        return Data;
//    },
//    //this is used to for showing successfully record creation message and reload the list view
//    Success: function (data) {
    
//        var CentreCode = data.CentreCodeWithName;//splitdata[1].split(":");
//        var UniversityID = data.UniversityIDWithName;//splitdata[2].split(":");
//        var splitData = data.errorMessage.split(',');
//        OrganisationBranchDetails.ReloadList(splitData[0], splitData[1], splitData[2], UniversityID, CentreCode);
//        parent.$.colorbox.close();
//    },
//    ////this is used to for showing successfully record updation message and reload the list view
//    //editSuccess: function (data) {
        
//    //    var splitdata = data.split("::");
//    //    var splitCentreCode = splitdata[1].split(":");
//    //    var splitUniversityID = splitdata[2].split(":");
//    //    parent.$.colorbox.close();
//    //    OrganisationBranchDetails.LoadListByCentreCodeAndUniversityID(splitdata[1], splitdata[2]);
//    //},
//    ////this is used to for showing successfully record deletion message and reload the list view
//    //deleteSuccess: function (data) {
//    //    //if ($("#update-message").html() == "True") {
//    //    //    //Reload List
       
//    //    var splitdata = data.split("::");
//    //    var splitCentreCode = splitdata[1].split(":");
//    //    var splitUniversityID = splitdata[2].split(":");
//    //    parent.$.colorbox.close();
//    //    // OrganisationBranchDetails.ReloadList("Record Deleted Sucessfully.");
//    //    OrganisationBranchDetails.LoadListByCentreCodeAndUniversityID(splitCentreCode[0], splitUniversityID[0]);
//    //    //} else {
//    //    //    $("#update-message").show();
//    //    //}
//    //},
//};

///////new js/////////////////


//this class contain methods related to nationality functionality
var OrganisationBranchDetails = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        OrganisationBranchDetails.constructor();
        //generalCountryMaster.initializeValidation();
    },
    //Attach all event of page
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
                    url: "/OrganisationBranchDetails/GetUniversityByCentreCode",

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
                OrganisationBranchDetails.LoadListByCentreCodeAndUniversityID(valuCentreCode, valuUniversityID);
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
        $('#CreateOrganisationBranchDetailsRecord').on("click", function () {
            OrganisationBranchDetails.ActionName = "Create";
            OrganisationBranchDetails.AjaxCallOrganisationBranchDetails();
        });

        $('#EditOrganisationBranchDetailsRecord').on("click", function () {

            OrganisationBranchDetails.ActionName = "Edit";
            OrganisationBranchDetails.AjaxCallOrganisationBranchDetails();
        });

        $('#DeleteOrganisationBranchDetailsRecord').on("click", function () {

            OrganisationBranchDetails.ActionName = "Delete";
            OrganisationBranchDetails.AjaxCallOrganisationBranchDetails();
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
             url: '/OrganisationBranchDetails/List',
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
            url: '/OrganisationBranchDetails/List',
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
              url: '/OrganisationBranchDetails/List',
              success: function (result) {
                  //Rebind Grid Data                
                  $('#ListViewModel').html(result);

              }
          });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallOrganisationBranchDetails: function () {
        var OrganisationBranchDetailsData = null;
        if (OrganisationBranchDetails.ActionName == "Create") {
            $("#FormCreateOrganisationBranchDetails").validate();
            if ($("#FormCreateOrganisationBranchDetails").valid()) {
                OrganisationBranchDetailsData = null;
                OrganisationBranchDetailsData = OrganisationBranchDetails.GetOrganisationBranchDetails();
                ajaxRequest.makeRequest("/OrganisationBranchDetails/Create", "POST", OrganisationBranchDetailsData, OrganisationBranchDetails.Success);
            }
        }
        else if (OrganisationBranchDetails.ActionName == "Edit") {
            $("#FormEditOrganisationBranchDetails").validate();
            if ($("#FormEditOrganisationBranchDetails").valid()) {
                OrganisationBranchDetailsData = null;
                OrganisationBranchDetailsData = OrganisationBranchDetails.GetOrganisationBranchDetails();
                ajaxRequest.makeRequest("/OrganisationBranchDetails/Edit", "POST", OrganisationBranchDetailsData, OrganisationBranchDetails.Success);
            }
        }
        else if (OrganisationBranchDetails.ActionName == "Delete") {
            OrganisationBranchDetailsData = null;
            //$("#FormCreateOrganisationBranchDetails").validate();
            OrganisationBranchDetailsData = OrganisationBranchDetails.GetOrganisationBranchDetails();

            ajaxRequest.makeRequest("/OrganisationBranchDetails/Delete", "POST", OrganisationBranchDetailsData, OrganisationBranchDetails.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetOrganisationBranchDetails: function () {

        var Data = {
        };
        if (OrganisationBranchDetails.ActionName == "Create" || OrganisationBranchDetails.ActionName == "Edit") {
            Data.ID = $('input[name=ID]').val();
            Data.BranchID = $('#BranchID').val();
            // Data.SelectedStreamID = $('#SelectedStreamID').val();
            Data.CentreCode = $('#CentreCode').val();
            Data.CentreName = $('#SelectedCentreCode').text();
            Data.PresentIntake = $('#PresentIntake').val();
            Data.IntroductionYear = $('#IntroductionYear').val();
            Data.StreamID = $('#StreamID').val();
            Data.UniversityIDWithName = $("#SelectedUniversityID").val();
            Data.DteCode = $('#DteCode').val();
            Data.BranchPrintingSequence = $('#BranchPrintingSequence').val();

            //if (OrganisationBranchDetails.ActionName == "Create") {

            //}
            if (OrganisationBranchDetails.ActionName == "Edit") {

                Data.SelectedStreamID = $('#SelectedStreamID').val();
                Data.CentreCode = $('#CentreCode').val();
                Data.UniversityIdWithName = $('input[name=SelectedUniversityID]').val();

            }
        }
        else if (OrganisationBranchDetails.ActionName == "Delete") {
            Data.ID = $('input[name=ID]').val();

        }
        return Data;
    },
    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {

        var CentreCode = data.CentreCodeWithName;//splitdata[1].split(":");
        var UniversityID = data.UniversityIDWithName;//splitdata[2].split(":");
        var splitData = data.errorMessage.split(',');
        OrganisationBranchDetails.ReloadList(splitData[0], splitData[1], splitData[2], UniversityID, CentreCode);
        //parent.$.colorbox.close();
        $.magnificPopup.close();

    },
    
};

