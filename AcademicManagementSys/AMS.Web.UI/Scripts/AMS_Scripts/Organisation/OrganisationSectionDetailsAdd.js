////this class contain methods related to nationality functionality
//var OrganisationSectionDetailsAdd = {
//    //Member variables
//    ActionName: null,

//    //Class intialisation method
//    Initialize: function () {
//        //organisationStudyCentre.loadData();

//        OrganisationSectionDetailsAdd.constructor();
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
//                    url: '/OrganisationSectionDetailsAdd/GetUniversityByCentreCode',
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
//            $('#MediumID').val("");
//            $('#StandardID').val("");
//            $('#StreamID').val("");



//            return false;
//        });


//        //$('#checkboxlist').click(function () {
//        //  
//        //    $('input:checkbox').selected;
//        //});

//        $('#SelectedUniversityID').on("change", function () {
//            $('#myDataTable').html("");
//            $('#myDataTable_info').text("No entries to show");
//            $('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');

//        });
//        $("#btnShowList").on("click", function () {
//            var valuCentreCode = $('#SelectedCentreCode :selected').val();
//            var valuUniversityID = $('#SelectedUniversityID :selected').val();
           
//            if (valuCentreCode != "" && valuUniversityID > 0) {
//                OrganisationSectionDetailsAdd.LoadListByCentreCodeAndUniversityID(valuCentreCode, valuUniversityID);
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
//        $('#SectionCapacity').on("keydown", function (e) {
//            AMSValidation.AllowNumbersOnly(e);
//        });
//        $('#Duration').on("keydown", function (e) {
//            AMSValidation.AllowNumbersOnly(e);
//        });
//        $('#PresentIntake').on("keydown", function (e) {
//            AMSValidation.AllowNumbersOnly(e);
//        });
//        // Create new record
//        $('#CreateOrganisationSectionDetailsAddRecord').on("click", function () {
//            OrganisationSectionDetailsAdd.ActionName = "Create";
           
//            OrganisationSectionDetailsAdd.AjaxCallOrganisationSectionDetailsAdd();
//        });



//        $('#EditOrganisationSectionDetailsAddRecord').on("click", function () {
           

//            OrganisationSectionDetailsAdd.ActionName = "Edit";
           
//            OrganisationSectionDetailsAdd.CountValueUsingParentTag();
//            OrganisationSectionDetailsAdd.getValueUsingParentTag_Check_UnCheck();

//            OrganisationSectionDetailsAdd.AjaxCallOrganisationSectionDetailsAdd();
//        });

//        $('#DeleteOrganisationSectionDetailsAddRecord').on("click", function () {

//            OrganisationSectionDetailsAdd.ActionName = "Delete";
//            OrganisationSectionDetailsAdd.AjaxCallOrganisationSectionDetailsAdd();
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
//             url: '/OrganisationSectionDetailsAdd/List',
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
//            url: '/OrganisationSectionDetailsAdd/List',
//            success: function (data) {
//                //Rebind Grid Data
//                $("#ListViewModel").empty().append(data);
//                //twitter type notification
//                $('#SuccessMessage').html(message);
//                $('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
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
//              url: '/OrganisationSectionDetailsAdd/List',
//              success: function (result) {
//                  //Rebind Grid Data                
//                  $('#ListViewModel').html(result);

//              }
//          });
//    },

//    //Fire ajax call to insert update and delete record
//    AjaxCallOrganisationSectionDetailsAdd: function () {
//        var OrganisationSectionDetailsAddData = null;
//        if (OrganisationSectionDetailsAdd.ActionName == "Create") {
//            $("#FormCreateOrganisationSectionDetailsAdd").validate();
//            if ($("#FormCreateOrganisationSectionDetailsAdd").valid()) {
//                OrganisationSectionDetailsAddData = null;
//                OrganisationSectionDetailsAddData = OrganisationSectionDetailsAdd.GetOrganisationSectionDetailsAdd();

//                ajaxRequest.makeRequest("/OrganisationSectionDetailsAdd/Create", "POST", OrganisationSectionDetailsAddData, OrganisationSectionDetailsAdd.Success);
//            }


//        }
//        else if (OrganisationSectionDetailsAdd.ActionName == "Edit") {
//            $("#FormEditOrganisationSectionDetailsAdd").validate();
//            if ($("#FormEditOrganisationSectionDetailsAdd").valid()) {
//                OrganisationSectionDetailsAddData = null;

//                OrganisationSectionDetailsAddData = OrganisationSectionDetailsAdd.GetOrganisationSectionDetailsAdd();
               
//                ajaxRequest.makeRequest("/OrganisationSectionDetailsAdd/Edit", "POST", OrganisationSectionDetailsAddData, OrganisationSectionDetailsAdd.Success);

//            }
//        }
//        else if (OrganisationSectionDetailsAdd.ActionName == "Delete") {
//            OrganisationSectionDetailsAddData = null;
//            //$("#FormCreateOrganisationSectionDetailsAdd").validate();
//            OrganisationSectionDetailsAddData = OrganisationSectionDetailsAdd.GetOrganisationSectionDetailsAdd();
//            ajaxRequest.makeRequest("/OrganisationSectionDetailsAdd/Delete", "POST", OrganisationSectionDetailsAddData, OrganisationSectionDetailsAdd.Success);

//        }
//    },
//    //Get properties data from the Create, Update and Delete page
//    GetOrganisationSectionDetailsAdd: function () {
       
//        var Data = {
//        };
//        if (OrganisationSectionDetailsAdd.ActionName == "Create" || OrganisationSectionDetailsAdd.ActionName == "Edit") {
           
//            Data.ID = $('input[name=ID]').val();
//            Data.BranchID = $('input[name=BranchID]').val();
//            Data.BranchDetID = $('input[name=BranchDetID]').val();
//            Data.StreamID = $('input[name=StreamID]').val();
//            Data.StandardID = $('input[name=StandardID]').val();
//            Data.MediumID = $('input[name=MediumID]').val();
//            Data.ExamPattern = $('input[name=ExamPattern]').val();
//            Data.ExamApplicable = $('input[name=ExamApplicable]').val();
//            Data.Duration = $('input[name=Duration]').val();
//            Data.DegreeName = $('input[name=DegreeName]').val();
//            Data.CourseYearDetailID = $('input[name=CourseYearDetailID]').val();
//            // Data.SectionID = $('#Descriptions').val();

//            Data.UniversityID = $('input[name=UniversityID]').val();
//            Data.CentreCode = $('input[name=CentreCode]').val();

//            Data.SelectedDescriptions = $('#SelectedDescriptions').val();
//            Data.SectionDetailCode = $('#SectionDetailCode').val();
//            Data.SectionCapacity = $('#SectionCapacity').val();
//            Data.OrgShiftCode = $('#OrgShiftCode').val();
//            Data.NumberOfSemester = $('input[name=NumberOfSemester]').val();

//            Data.SectionActive = $('input[name=SectionActive]:checked').val() ? true : false;


//            if (OrganisationSectionDetailsAdd.ActionName == "Edit") {

//                //Data.SelectedStreamID = $('#SelectedStreamID').val();
//                Data.NumberOfSemester = OrganisationSectionDetailsAdd.NumberOfSemester;
//                Data.CentreCodeWithName = $('input[name=SelectedCentreCode]').val();
//                Data.UniversityIdWithName = $('input[name=SelectedUniversityID]').val();

//            }
//        }
//        else if (OrganisationSectionDetailsAdd.ActionName == "Delete") {
//            Data.ID = $('input[name=ID]').val();

//        }
//        return Data;
//    },




//    //this is used to for showing successfully record creation message and reload the list view
//    Success: function (data) {
       
//        var CentreCode = data.CentreCodeWithName;
//        var UniversityID = data.UniversityIDWithName;
//        var splitData = data.errorMessage.split(',');
//        OrganisationSectionDetailsAdd.ReloadList(splitData[0], splitData[1], splitData[2], UniversityID, CentreCode);
//        parent.$.colorbox.close();
//    },
//    //this is used to for showing successfully record updation message and reload the list view
//    //editSuccess: function (data) {

//    //    var splitdata = data.split("::");
//    //    var splitCentreCode = splitdata[1].split(":");
//    //    var splitUniversityID = splitdata[2].split(":");
//    //    parent.$.colorbox.close();
//    //    OrganisationSectionDetailsAdd.LoadListByCentreCodeAndUniversityID(splitdata[1], splitdata[2]);
//    //},
//    ////this is used to for showing successfully record deletion message and reload the list view
//    //deleteSuccess: function (data) {
//    //    //if ($("#update-message").html() == "True") {
//    //    //    //Reload List

//    //    var splitdata = data.split("::");
//    //    var splitCentreCode = splitdata[1].split(":");
//    //    var splitUniversityID = splitdata[2].split(":");
//    //    parent.$.colorbox.close();
//    //    // OrganisationSectionDetailsAdd.ReloadList("Record Deleted Sucessfully.");
//    //    OrganisationSectionDetailsAdd.LoadListByCentreCodeAndUniversityID(splitCentreCode[0], splitUniversityID[0]);
//    //    //} else {
//    //    //    $("#update-message").show();
//    //    //}
//    //},
//};

////////////////new js/////////////////////////


//this class contain methods related to nationality functionality
var OrganisationSectionDetailsAdd = {
    //Member variables
    ActionName: null,

    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        OrganisationSectionDetailsAdd.constructor();
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
                    url: '/OrganisationSectionDetailsAdd/GetUniversityByCentreCode',
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
            $('#MediumID').val("");
            $('#StandardID').val("");
            $('#StreamID').val("");



            return false;
        });


        //$('#checkboxlist').click(function () {
        //  
        //    $('input:checkbox').selected;
        //});

        $('#SelectedUniversityID').on("change", function () {
            //$('#myDataTable').html("");
            //$('#myDataTable_info').text("No entries to show");
            //$('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');

        });
        $("#btnShowList").on("click", function () {
            var valuCentreCode = $('#SelectedCentreCode :selected').val();
            var valuUniversityID = $('#SelectedUniversityID :selected').val();

            if (valuCentreCode != "" && valuUniversityID > 0) {
                OrganisationSectionDetailsAdd.LoadListByCentreCodeAndUniversityID(valuCentreCode, valuUniversityID);
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
        $('#SectionCapacity').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        $('#Duration').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        $('#PresentIntake').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        // Create new record
        $('#CreateOrganisationSectionDetailsAddRecord').on("click", function () {
            //alert();
            OrganisationSectionDetailsAdd.ActionName = "Create";

            OrganisationSectionDetailsAdd.AjaxCallOrganisationSectionDetailsAdd();
        });



        $('#EditOrganisationSectionDetailsAddRecord').on("click", function () {


            OrganisationSectionDetailsAdd.ActionName = "Edit";

            OrganisationSectionDetailsAdd.CountValueUsingParentTag();
            OrganisationSectionDetailsAdd.getValueUsingParentTag_Check_UnCheck();

            OrganisationSectionDetailsAdd.AjaxCallOrganisationSectionDetailsAdd();
        });

        $('#DeleteOrganisationSectionDetailsAddRecord').on("click", function () {

            OrganisationSectionDetailsAdd.ActionName = "Delete";
            OrganisationSectionDetailsAdd.AjaxCallOrganisationSectionDetailsAdd();
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
             url: '/OrganisationSectionDetailsAdd/List',
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
            url: '/OrganisationSectionDetailsAdd/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
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
              url: '/OrganisationSectionDetailsAdd/List',
              success: function (result) {
                  //Rebind Grid Data                
                  $('#ListViewModel').html(result);

              }
          });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallOrganisationSectionDetailsAdd: function () {
        var OrganisationSectionDetailsAddData = null;
        if (OrganisationSectionDetailsAdd.ActionName == "Create") {

            

            $("#FormCreateOrganisationSectionDetailsAdd").validate();
            if ($("#FormCreateOrganisationSectionDetailsAdd").valid()) {

                
                OrganisationSectionDetailsAddData = null;
                OrganisationSectionDetailsAddData = OrganisationSectionDetailsAdd.GetOrganisationSectionDetailsAdd();

                ajaxRequest.makeRequest("/OrganisationSectionDetailsAdd/Create", "POST", OrganisationSectionDetailsAddData, OrganisationSectionDetailsAdd.Success);
            }


        }
        else if (OrganisationSectionDetailsAdd.ActionName == "Edit") {
            $("#FormEditOrganisationSectionDetailsAdd").validate();
            if ($("#FormEditOrganisationSectionDetailsAdd").valid()) {
                OrganisationSectionDetailsAddData = null;

                OrganisationSectionDetailsAddData = OrganisationSectionDetailsAdd.GetOrganisationSectionDetailsAdd();

                ajaxRequest.makeRequest("/OrganisationSectionDetailsAdd/Edit", "POST", OrganisationSectionDetailsAddData, OrganisationSectionDetailsAdd.Success);

            }
        }
        else if (OrganisationSectionDetailsAdd.ActionName == "Delete") {
            OrganisationSectionDetailsAddData = null;
            //$("#FormCreateOrganisationSectionDetailsAdd").validate();
            OrganisationSectionDetailsAddData = OrganisationSectionDetailsAdd.GetOrganisationSectionDetailsAdd();
            ajaxRequest.makeRequest("/OrganisationSectionDetailsAdd/Delete", "POST", OrganisationSectionDetailsAddData, OrganisationSectionDetailsAdd.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetOrganisationSectionDetailsAdd: function () {

        var Data = {
        };
        if (OrganisationSectionDetailsAdd.ActionName == "Create" || OrganisationSectionDetailsAdd.ActionName == "Edit") {

            Data.ID = $('input[name=ID]').val();
            Data.BranchID = $('input[name=BranchID]').val();
            Data.BranchDetID = $('input[name=BranchDetID]').val();
            Data.StreamID = $('input[name=StreamID]').val();
            Data.StandardID = $('input[name=StandardID]').val();
            Data.MediumID = $('input[name=MediumID]').val();
            Data.ExamPattern = $('input[name=ExamPattern]').val();
            Data.ExamApplicable = $('input[name=ExamApplicable]').val();
            Data.Duration = $('input[name=Duration]').val();
            Data.DegreeName = $('input[name=DegreeName]').val();
            Data.CourseYearDetailID = $('input[name=CourseYearDetailID]').val();
            // Data.SectionID = $('#Descriptions').val();

            Data.UniversityID = $('input[name=UniversityID]').val();
            Data.CentreCode = $('input[name=CentreCode]').val();

            Data.SelectedDescriptions = $('#SelectedDescriptions').val();
            Data.SectionDetailCode = $('#SectionDetailCode').val();
            Data.SectionCapacity = $('#SectionCapacity').val();
            Data.OrgShiftCode = $('#OrgShiftCode').val();
            Data.NumberOfSemester = $('input[name=NumberOfSemester]').val();

            //Data.SectionActive = $('input[name=SectionActive]:checked').val() ? true : false;
            Data.SectionActive = $('input[id=SectionActive]:checked').val() ? true : false;


            if (OrganisationSectionDetailsAdd.ActionName == "Edit") {

                //Data.SelectedStreamID = $('#SelectedStreamID').val();
                Data.NumberOfSemester = OrganisationSectionDetailsAdd.NumberOfSemester;
                Data.CentreCodeWithName = $('input[name=SelectedCentreCode]').val();
                Data.UniversityIdWithName = $('input[name=SelectedUniversityID]').val();

            }
        }
        else if (OrganisationSectionDetailsAdd.ActionName == "Delete") {
            Data.ID = $('input[name=ID]').val();

        }
        return Data;
    },




    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {

        var CentreCode = data.CentreCodeWithName;
        var UniversityID = data.UniversityIDWithName;
        var splitData = data.errorMessage.split(',');
        OrganisationSectionDetailsAdd.ReloadList(splitData[0], splitData[1], splitData[2], UniversityID, CentreCode);
        //parent.$.colorbox.close();
        $.magnificPopup.close();

    },
    //this is used to for showing successfully record updation message and reload the list view
    //editSuccess: function (data) {

    //    var splitdata = data.split("::");
    //    var splitCentreCode = splitdata[1].split(":");
    //    var splitUniversityID = splitdata[2].split(":");
    //    parent.$.colorbox.close();
    //    OrganisationSectionDetailsAdd.LoadListByCentreCodeAndUniversityID(splitdata[1], splitdata[2]);
    //},
    ////this is used to for showing successfully record deletion message and reload the list view
    //deleteSuccess: function (data) {
    //    //if ($("#update-message").html() == "True") {
    //    //    //Reload List

    //    var splitdata = data.split("::");
    //    var splitCentreCode = splitdata[1].split(":");
    //    var splitUniversityID = splitdata[2].split(":");
    //    parent.$.colorbox.close();
    //    // OrganisationSectionDetailsAdd.ReloadList("Record Deleted Sucessfully.");
    //    OrganisationSectionDetailsAdd.LoadListByCentreCodeAndUniversityID(splitCentreCode[0], splitUniversityID[0]);
    //    //} else {
    //    //    $("#update-message").show();
    //    //}
    //},
};

