////this class contain methods related to nationality functionality
//var OrganisationSubjectMaster = {
//    //Member variables
//    ActionName: null,
//    //Class intialisation method
//    Initialize: function () {
//        //organisationStudyCentre.loadData();

//        OrganisationSubjectMaster.constructor();
//        //OrganisationSubjectMaster.initializeValidation();
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
//                    url: "/OrganisationSubjectMaster/GetUniversityByCentreCode",

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
//                $('#SelectedUniversityID').find('option').remove().end().append('<option value>---------Select University---------</option>');
//                $('#btnCreate').hide();
//            }
//            $('#DivCreateNew').hide(true);
//            $('#myDataTable').html("");
//            $('#myDataTable_info').text("No entries to show");
//            $('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
//        });

//        $('#SelectedUniversityID').on("change", function () {
//            $('#DivCreateNew').hide(true);
//            $('#myDataTable').html("");
//            $('#myDataTable_info').text("No entries to show");
//            $('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
//        });

//        $("#btnShowList").on("click", function () {
            
//            var valuCentreCode = $('#SelectedCentreCode :selected').val();
//            var valuUniversityID = $('#SelectedUniversityID :selected').val();
//            if (valuCentreCode != "" && valuUniversityID > 0) {
//                OrganisationSubjectMaster.LoadListByCentreCodeAndUniversityID(valuCentreCode, valuUniversityID);
//            }
//            else if (valuCentreCode != "" && valuUniversityID <= 0) {
//                 ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectUniversity", "SuccessMessage", "#FFCC80");
//                //$('#SuccessMessage').html("Please select university");
//                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', "#FFCC80");
//                $('#DivCreateNew').hide(true);
//            }
//            else if ((valuCentreCode == "" && valuUniversityID <= 0)) {
//                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectCentre", "SuccessMessage", "#FFCC80");
//                //$('#SuccessMessage').html("Please select centre");
//                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', "#FFCC80");
//                $('#DivCreateNew').hide(true);
//            }
//        });


//        $('#reset').on("click", function () {
//            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
          
//            $('#Descriptions').focus();
//            $('#LanguageID').val("");
//            return false;
//        });
//        $('#DisableDate_Clear').on("click", function () {
           
//            $('#SubjectIntroYear').val("");
           
//        });
   
//        $("#SubjectIntroYear").datepicker({
//            dateFormat: 'd-M-yy',
//            changeMonth: true,
//            changeYear: true,
//            yearRange: '1850:document.write(currentYear.getFullYear()',
   
//        });

//        // Create new record
//        $('#CreateOrganisationSubjectMasterRecord').on("click", function () {
            
//            OrganisationSubjectMaster.ActionName = "Create";
//            OrganisationSubjectMaster.AjaxCallOrganisationSubjectMaster();
//        });

//        $('#EditOrganisationSubjectMasterRecord').on("click", function () {
            
//            OrganisationSubjectMaster.ActionName = "Edit";
//            OrganisationSubjectMaster.AjaxCallOrganisationSubjectMaster();
//        });

//        $('#DeleteOrganisationSubjectMasterRecord').on("click", function () {

//            OrganisationSubjectMaster.ActionName = "Delete";
//            OrganisationSubjectMaster.AjaxCallOrganisationSubjectMaster();
//        });
//        $('#closeBtn').on("click", function () {
//            parent.$.colorbox.close();
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

//        $("#Descriptions").change("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
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
//              url: '/OrganisationSubjectMaster/List',
//              success: function (result) {
//                  //Rebind Grid Data                
//                  $('#ListViewModel').html(result);

//                  $('#DivCreateNew').show(true);
//              }
//          });
//    },

//    //LoadList method is used to load List page
//    LoadList: function () {

//        $.ajax(

//         {

//             cache: false,
//             type: "POST",

//             dataType: "html",
//             url: '/OrganisationSubjectMaster/List',
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
//            url: '/OrganisationSubjectMaster/List',
//            success: function (data) {
//                //Rebind Grid Data
//                $("#ListViewModel").empty().append(data);
//                //twitter type notification
//                $('#SuccessMessage').html(message);
//                $('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', colorCode);
//                $('#DivCreateNew').show(true);
//            }
//        });
//    },


//    //Fire ajax call to insert update and delete record
//    AjaxCallOrganisationSubjectMaster: function () {
//        var OrganisationSubjectMasterData = null;
//        if (OrganisationSubjectMaster.ActionName == "Create") {
//            $("#FormCreateOrganisationSubjectMaster").validate();
//            if ($("#FormCreateOrganisationSubjectMaster").valid()) {
//                OrganisationSubjectMasterData = null;
//                OrganisationSubjectMasterData = OrganisationSubjectMaster.GetOrganisationSubjectMaster();
//                ajaxRequest.makeRequest("/OrganisationSubjectMaster/Create", "POST", OrganisationSubjectMasterData, OrganisationSubjectMaster.Success);
//            }
//        }
//        else if (OrganisationSubjectMaster.ActionName == "Edit") {
//            $("#FormEditOrganisationSubjectMaster").validate();
//            if ($("#FormEditOrganisationSubjectMaster").valid()) {
//                OrganisationSubjectMasterData = null;
//                OrganisationSubjectMasterData = OrganisationSubjectMaster.GetOrganisationSubjectMaster();
//                ajaxRequest.makeRequest("/OrganisationSubjectMaster/Edit", "POST", OrganisationSubjectMasterData, OrganisationSubjectMaster.Success);
//            }
//        }
//        else if (OrganisationSubjectMaster.ActionName == "Delete") {
//            OrganisationSubjectMasterData = null;
//            //$("#FormCreateOrganisationSubjectMaster").validate();
//            OrganisationSubjectMasterData = OrganisationSubjectMaster.GetOrganisationSubjectMaster();
            
//            ajaxRequest.makeRequest("/OrganisationSubjectMaster/Delete", "POST", OrganisationSubjectMasterData, OrganisationSubjectMaster.Success);

//        }
//    },
//    //Get properties data from the Create, Update and Delete page
//    GetOrganisationSubjectMaster: function () {
        
//        var Data = {
//        };
//        if (OrganisationSubjectMaster.ActionName == "Create" || OrganisationSubjectMaster.ActionName == "Edit") {
//            Data.ID = $('input[name=ID]').val();
//            Data.Descriptions = $('#Descriptions').val();
//            Data.SubjectCode = $('#SubjectCode').val();
//            Data.SubjectIntroYear = $('#SubjectIntroYear').val();
//            Data.PaperCode = $('#PaperCode').val();
//            Data.UniversityID = $('#UniversityID').val();
//            Data.LanguageID = $('#LanguageID').val();
//            Data.SelectedLanguageID = $('#SelectedLanguageID').val();
//            Data.CentreCode = $('input[name=CentreCode]').val();
//        }
//        else if (OrganisationSubjectMaster.ActionName == "Delete") {
//            Data.ID = $('input[name=ID]').val();
//            Data.UniversityID = $('#UniversityID').val();
//            Data.CentreCode = $('input[name=CentreCode]').val();
//        }
//        return Data;
//    },

//    //this is used to for showing successfully record creation message and reload the list view
//    Success: function (data) {
        
//        var CentreCode = data.CentreCodeWithName;//splitdata[1].split(":");
//        var UniversityID = data.UniversityIDWithName;//splitdata[2].split(":");
//        var splitData = data.errorMessage.split(',');
//        OrganisationSubjectMaster.ReloadList(splitData[0], splitData[1], splitData[2], UniversityID, CentreCode);
//        parent.$.colorbox.close();
//    },
  
//};

////////////new js/////////////////


//this class contain methods related to nationality functionality
var OrganisationSubjectMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        OrganisationSubjectMaster.constructor();
        //OrganisationSubjectMaster.initializeValidation();
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
                    url: "/OrganisationSubjectMaster/GetUniversityByCentreCode",

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
                $('#SelectedUniversityID').find('option').remove().end().append('<option value>---------Select University---------</option>');
                $('#btnCreate').hide();
            }
            $('#DivCreateNew').hide(true);
            //$('#myDataTable').html("");
            //$('#myDataTable_info').text("No entries to show");
            //$('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
        });

        $('#SelectedUniversityID').on("change", function () {
            $('#DivCreateNew').hide(true);
            ///$('#myDataTable').html("");
            //$('#myDataTable_info').text("No entries to show");
            //$('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
        });

        $("#btnShowList").on("click", function () {

            var valuCentreCode = $('#SelectedCentreCode :selected').val();
            var valuUniversityID = $('#SelectedUniversityID :selected').val();
            if (valuCentreCode != "" && valuUniversityID > 0) {
                OrganisationSubjectMaster.LoadListByCentreCodeAndUniversityID(valuCentreCode, valuUniversityID);
            }
            else if (valuCentreCode != "" && valuUniversityID <= 0) {
                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectUniversity", "SuccessMessage", "#FFCC80");
                //$('#SuccessMessage').html("Please select university");
                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', "#FFCC80");
                $('#DivCreateNew').hide(true);
            }
            else if ((valuCentreCode == "" && valuUniversityID <= 0)) {
                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectCentre", "SuccessMessage", "#FFCC80");
                //$('#SuccessMessage').html("Please select centre");
                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', "#FFCC80");
                $('#DivCreateNew').hide(true);
            }
        });


        $('#reset').on("click", function () {
            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");

            $('#Descriptions').focus();
            $('#LanguageID').val("");
            return false;
        });
        $('#DisableDate_Clear').on("click", function () {

            $('#SubjectIntroYear').val("");

        });

        //$("#SubjectIntroYear").datepicker({
        //    dateFormat: 'd-M-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    yearRange: '1850:document.write(currentYear.getFullYear()',

        //});

        $('#SubjectIntroYear').datetimepicker({
            format: 'DD MMMM YYYY',
            ignoreReadonly: true,
            //maxDate: moment(),
        });

        // Create new record
        $('#CreateOrganisationSubjectMasterRecord').on("click", function () {

            OrganisationSubjectMaster.ActionName = "Create";
            OrganisationSubjectMaster.AjaxCallOrganisationSubjectMaster();
        });

        $('#EditOrganisationSubjectMasterRecord').on("click", function () {

            OrganisationSubjectMaster.ActionName = "Edit";
            OrganisationSubjectMaster.AjaxCallOrganisationSubjectMaster();
        });

        $('#DeleteOrganisationSubjectMasterRecord').on("click", function () {

            OrganisationSubjectMaster.ActionName = "Delete";
            OrganisationSubjectMaster.AjaxCallOrganisationSubjectMaster();
        });
        $('#closeBtn').on("click", function () {
            parent.$.colorbox.close();
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

        $("#Descriptions").change("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
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
              url: '/OrganisationSubjectMaster/List',
              success: function (result) {
                  //Rebind Grid Data                
                  $('#ListViewModel').html(result);

                  $('#DivCreateNew').show(true);
              }
          });
    },

    //LoadList method is used to load List page
    LoadList: function () {

        $.ajax(

         {

             cache: false,
             type: "POST",

             dataType: "html",
             url: '/OrganisationSubjectMaster/List',
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
            url: '/OrganisationSubjectMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', colorCode);
                
                notify(message, colorCode);
                $('#DivCreateNew').show(true);

            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallOrganisationSubjectMaster: function () {
        var OrganisationSubjectMasterData = null;
        if (OrganisationSubjectMaster.ActionName == "Create") {
            $("#FormCreateOrganisationSubjectMaster").validate();
            if ($("#FormCreateOrganisationSubjectMaster").valid()) {
                OrganisationSubjectMasterData = null;
                OrganisationSubjectMasterData = OrganisationSubjectMaster.GetOrganisationSubjectMaster();
                ajaxRequest.makeRequest("/OrganisationSubjectMaster/Create", "POST", OrganisationSubjectMasterData, OrganisationSubjectMaster.Success);
            }
        }
        else if (OrganisationSubjectMaster.ActionName == "Edit") {
            $("#FormEditOrganisationSubjectMaster").validate();
            if ($("#FormEditOrganisationSubjectMaster").valid()) {
                OrganisationSubjectMasterData = null;
                OrganisationSubjectMasterData = OrganisationSubjectMaster.GetOrganisationSubjectMaster();
                ajaxRequest.makeRequest("/OrganisationSubjectMaster/Edit", "POST", OrganisationSubjectMasterData, OrganisationSubjectMaster.Success);
            }
        }
        else if (OrganisationSubjectMaster.ActionName == "Delete") {
            OrganisationSubjectMasterData = null;
            //$("#FormCreateOrganisationSubjectMaster").validate();
            OrganisationSubjectMasterData = OrganisationSubjectMaster.GetOrganisationSubjectMaster();

            ajaxRequest.makeRequest("/OrganisationSubjectMaster/Delete", "POST", OrganisationSubjectMasterData, OrganisationSubjectMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetOrganisationSubjectMaster: function () {

        var Data = {
        };
        if (OrganisationSubjectMaster.ActionName == "Create" || OrganisationSubjectMaster.ActionName == "Edit") {
            Data.ID = $('input[name=ID]').val();
            Data.Descriptions = $('#Descriptions').val();
            Data.SubjectCode = $('#SubjectCode').val();
            Data.SubjectIntroYear = $('#SubjectIntroYear').val();
            Data.PaperCode = $('#PaperCode').val();
            Data.UniversityID = $('#UniversityID').val();
            Data.LanguageID = $('#LanguageID').val();
            Data.SelectedLanguageID = $('#SelectedLanguageID').val();
            Data.CentreCode = $('input[name=CentreCode]').val();
        }
        else if (OrganisationSubjectMaster.ActionName == "Delete") {
            Data.ID = $('input[name=ID]').val();
            Data.UniversityID = $('#UniversityID').val();
            Data.CentreCode = $('input[name=CentreCode]').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {

        var CentreCode = data.CentreCodeWithName;//splitdata[1].split(":");
        var UniversityID = data.UniversityIDWithName;//splitdata[2].split(":");
        var splitData = data.errorMessage.split(',');
        OrganisationSubjectMaster.ReloadList(splitData[0], splitData[1], splitData[2], UniversityID, CentreCode);
        //parent.$.colorbox.close();
        $.magnificPopup.close();

    },

};

