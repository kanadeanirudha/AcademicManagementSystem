////this class contain methods related to nationality functionality
//var GeneralPolicyDetails = {
//    //Member variables
//    ActionName: null,
//    //Class intialisation method
//    Initialize: function () {
//        //organisationStudyCentre.loadData();

//        GeneralPolicyDetails.constructor();
//        //GeneralPolicyDetails.initializeValidation();
//    },
//    //Attach all event of page
//    constructor: function () {

//        $('#SelectedCentreCode').on("change", function () {

//            $('#myDataTable').html("");
//            $('#myDataTable_info').text("No entries to show");
//            $('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
//        });
//        $("#btnShowList").on("click", function () {
            
//            var SelectedCentreCode = $("#SelectedCentreCode").val();
//            var SelectedCentreName = $("#SelectedCentreCode option:selected").text();
//            if (SelectedCentreCode != "" && SelectedCentreName != "") {
//                $.ajax(
//                     {
//                         cache: false,
//                         type: "GET",
//                         data: { "centreCode": SelectedCentreCode, "centreName": SelectedCentreName },
//                         dataType: "html",
//                         url: '/GeneralPolicyDetails/List',
//                         success: function (data) {
//                             //Rebind Grid Data
//                             $('#ListViewModel').html(data);
//                             $('#CreateCentrewiseSession').show();

//                             //OrganisationCentrewiseSession.LoadList(SelectedCentreCode);
//                         }
//                     });
//            }

//            else if ((SelectedCentreCode == "" || SelectedCentreCode != null)) {
//                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectCentre", "SuccessMessage", "#FFCC80");
//                $('#CreateCentrewiseSession').hide(true);
//                //$('#SuccessMessage').html("Please select centre");
//                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', "#FFCC80");
//            }

//        });
//        $("#SelectedCentreCode").change(function () {
//            $('#myDataTable').html("");
//            $('#myDataTable_info').text("No entries to show");
//            $('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');

//        });


//        $('#PolicyCode').focus();

//        $("#reset").click(function () {

//            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
//            $('input:checkbox,input:radio').removeAttr('checked');


//        });


//        // Create new record

//        $('#CreateGeneralPolicyDetailsRecord').on("click", function () {
//            GeneralPolicyDetails.ActionName = "Create";
//            GeneralPolicyDetails.AjaxCallGeneralPolicyDetails();
//        });

//        $('#EditGeneralPolicyDetailsRecord').on("click", function () {

//            GeneralPolicyDetails.ActionName = "Edit";
//            GeneralPolicyDetails.AjaxCallGeneralPolicyDetails();
//        });

//        $('#DeleteGeneralPolicyDetailsRecord').on("click", function () {

//            GeneralPolicyDetails.ActionName = "Delete";
//            GeneralPolicyDetails.AjaxCallGeneralPolicyDetails();
//        });


//        $('#PolicyCode').on("keydown", function (e) {
//            AMSValidation.NotAllowSpaces(e);

//        });


//        $("#UserSearch").keyup(function () {
//            var oTable = $("#myDataTable").dataTable();
//            oTable.fnFilter(this.value);
//        });

//        $("#searchBtn").click(function () {
//            $("#UserSearch").focus();
//        });
//        $("#ApplicableUptoDate").prop('readonly', true);
//        $("#ApplicableFromDate").prop('readonly', true);
//        $('#ApplicableFromDate').datepicker({
//            numberOfMonths: 1,
//            dateFormat: 'd M yy',
//            minDate: 0,
//            onSelect: function (selected) {
//                $("#ApplicableUptoDate").datepicker("option", "minDate", selected)
//            }
//        })

//        $('#ApplicableUptoDate').datepicker({
//            numberOfMonths: 1,
//            dateFormat: 'd M yy',

//            onSelect: function (selected) {
//                $("#ApplicableFromDate").datepicker("option", "maxDate", selected)
//            }
//        })

//        $('#ApplicableUptoDate_Update').datepicker({
//            numberOfMonths: 1,
//            dateFormat: 'd M yy',
//            minDate: 0,

//        })



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
//             url: '/GeneralPolicyDetails/List',
//             success: function (data) {
//                 //Rebind Grid Data
//                 $('#ListViewModel').html(data);
//             }
//         });
//    },

//    //ReloadList method is used to load List page
//    ReloadList: function (message, colorCode, actionMode, CentreCode) {

//        $.ajax(
//        {
//            cache: false,
//            type: "GET",
//            data: { actionMode: actionMode, centerCode: CentreCode },
//            dataType: "html",
//            url: '/GeneralPolicyDetails/List',
//            success: function (data) {
//                //Rebind Grid Data
//                $("#ListViewModel").empty().append(data);
//                //twitter type notification
//                $('#SuccessMessage').html(message);
//                $('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
//            }
//        });
//    },




//    //Fire ajax call to insert update and delete record
//    AjaxCallGeneralPolicyDetails: function () {
//        var GeneralPolicyDetailsData = null;
//        if (GeneralPolicyDetails.ActionName == "Create") {
//            $("#FormCreateGeneralPolicyDetails").validate();
//            if ($("#FormCreateGeneralPolicyDetails").valid()) {
//                GeneralPolicyDetailsData = null;
//                GeneralPolicyDetailsData = GeneralPolicyDetails.GetGeneralPolicyDetails();
//                ajaxRequest.makeRequest("/GeneralPolicyDetails/Create", "POST", GeneralPolicyDetailsData, GeneralPolicyDetails.Success);
//            }
//        }
//        else if (GeneralPolicyDetails.ActionName == "Edit") {
//            $("#FormEditGeneralPolicyDetails").validate();
//            if ($("#FormEditGeneralPolicyDetails").valid()) {
//                GeneralPolicyDetailsData = null;
//                GeneralPolicyDetailsData = GeneralPolicyDetails.GetGeneralPolicyDetails();
//                ajaxRequest.makeRequest("/GeneralPolicyDetails/Edit", "POST", GeneralPolicyDetailsData, GeneralPolicyDetails.Success);
//            }
//        }
//        else if (GeneralPolicyDetails.ActionName == "Delete") {
//            GeneralPolicyDetailsData = null;
//            //$("#FormCreateGeneralPolicyDetails").validate();
//            GeneralPolicyDetailsData = GeneralPolicyDetails.GetGeneralPolicyDetails();
//            ajaxRequest.makeRequest("/GeneralPolicyDetails/Delete", "POST", GeneralPolicyDetailsData, GeneralPolicyDetails.Success);

//        }
//    },
//    //Get properties data from the Create, Update and Delete page
//    GetGeneralPolicyDetails: function () {
//        var Data = {
//        };
//        if (GeneralPolicyDetails.ActionName == "Create" || GeneralPolicyDetails.ActionName == "Edit") {

//            Data.ID = $('#ID').val();
//            Data.GeneralPolicyRulesID = $('#GeneralPolicyRulesID').val();
//            Data.PolicyCode = $('input[name=PolicyCode]').val();
//            Data.PolicyAnswered = $('#PolicyAnswered').val();
//            Data.ApplicableFromDate = $('#ApplicableFromDate').val();
//            Data.CentreCode = $('#CentreCode').val();
//            if (GeneralPolicyDetails.ActionName == "Edit") {
//                Data.ApplicableUptoDate = $('#ApplicableUptoDate_Update').val();
//            }
//            else {
//                Data.ApplicableUptoDate = $('#ApplicableUptoDate').val();
//            }

//            Data.SelectedCentreName = $('#SelectedCentreName').val();

//        }
//        else if (GeneralPolicyDetails.ActionName == "Delete") {
//            Data.ID = $('#ID').val();
//        }
//        return Data;

//    },

//    //this is used to for showing successfully record creation message and reload the list view
//    Success: function (data) {
        
//        //var CentreCode = data.SelectedCentreCode;
//        //var splitData = data.errorMessage.split(',');
//        //parent.$.colorbox.close();
//        //GeneralPolicyDetails.ReloadList(splitData[0], splitData[1], splitData[2], CentreCode);


        
//        var CentreCode = data.SelectedCentreCode;//splitdata[1].split(":");
//        ////var splitData = data.errorMessage.split(',');
//        var splitData = data.split(',');
//        if (data != null) {
//            parent.$.colorbox.close();
//            GeneralPolicyDetails.ReloadList(splitData[0], splitData[1], splitData[2], CentreCode);
//        } else {
//            parent.$.colorbox.close();
//            GeneralPolicyDetails.ReloadList(splitData[0], splitData[1], splitData[2], CentreCode);
//        }




//    },


//};

/////////////////////new js//////////////////////////


//this class contain methods related to nationality functionality
var GeneralPolicyDetails = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        GeneralPolicyDetails.constructor();
        //GeneralPolicyDetails.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#SelectedCentreCode').on("change", function () {

            //$('#myDataTable').html("");
            //$('#myDataTable_info').text("No entries to show");
            //$('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
        });
        $("#btnShowList").on("click", function () {

            var SelectedCentreCode = $("#SelectedCentreCode").val();
            var SelectedCentreName = $("#SelectedCentreCode option:selected").text();
            if (SelectedCentreCode != "" && SelectedCentreName != "") {
                $.ajax(
                     {
                         cache: false,
                         type: "GET",
                         data: { "centreCode": SelectedCentreCode, "centreName": SelectedCentreName },
                         dataType: "html",
                         url: '/GeneralPolicyDetails/List',
                         success: function (data) {
                             //Rebind Grid Data
                             $('#ListViewModel').html(data);
                             $('#CreateCentrewiseSession').show();

                             //OrganisationCentrewiseSession.LoadList(SelectedCentreCode);
                         }
                     });
            }

            else if ((SelectedCentreCode == "" || SelectedCentreCode != null)) {
                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectCentre", "SuccessMessage", "#FFCC80");
                $('#CreateCentrewiseSession').hide(true);
                //$('#SuccessMessage').html("Please select centre");
                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', "#FFCC80");
            }

        });
        $("#SelectedCentreCode").change(function () {
            //$('#myDataTable').html("");
            //$('#myDataTable_info').text("No entries to show");
            //$('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');

        });


        $('#PolicyCode').focus();

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');


        });


        // Create new record

        $('#CreateGeneralPolicyDetailsRecord').on("click", function () {
            GeneralPolicyDetails.ActionName = "Create";
            GeneralPolicyDetails.AjaxCallGeneralPolicyDetails();
        });

        $('#EditGeneralPolicyDetailsRecord').on("click", function () {

            GeneralPolicyDetails.ActionName = "Edit";
            GeneralPolicyDetails.AjaxCallGeneralPolicyDetails();
        });

        $('#DeleteGeneralPolicyDetailsRecord').on("click", function () {

            GeneralPolicyDetails.ActionName = "Delete";
            GeneralPolicyDetails.AjaxCallGeneralPolicyDetails();
        });


        $('#PolicyCode').on("keydown", function (e) {
            AMSValidation.NotAllowSpaces(e);

        });


        $("#UserSearch").keyup(function () {
            var oTable = $("#myDataTable").dataTable();
            oTable.fnFilter(this.value);
        });

        $("#searchBtn").click(function () {
            $("#UserSearch").focus();
        });
        $("#ApplicableUptoDate").prop('readonly', true);
        $("#ApplicableFromDate").prop('readonly', true);

        //$('#ApplicableFromDate').datepicker({
        //    numberOfMonths: 1,
        //    dateFormat: 'd M yy',
        //    minDate: 0,
        //    onSelect: function (selected) {
        //        $("#ApplicableUptoDate").datepicker("option", "minDate", selected)
        //    }
        //})
        $('#ApplicableFromDate').datetimepicker({
            format: 'DD MMMM YYYY',
            ignoreReadonly: true,
            //minDate: moment(),
        });

        $("#ApplicableFromDate").on("dp.hide", function (e) {
            var minDate = new Date(e.date.valueOf());
            $('#ApplicableUptoDate').data("DateTimePicker").minDate(minDate);
        });

        //$('#ApplicableUptoDate').datepicker({
        //    numberOfMonths: 1,
        //    dateFormat: 'd M yy',

        //    onSelect: function (selected) {
        //        $("#ApplicableFromDate").datepicker("option", "maxDate", selected)
        //    }
        //})

        $('#ApplicableUptoDate').datetimepicker({
            format: 'DD MMMM YYYY',
            ignoreReadonly: true,
            //maxDate: moment(),
        });

        $("#ApplicableUptoDate").on("dp.hide", function (e) {
            var maxDate = new Date(e.date.valueOf());
            $('#ApplicableFromDate').data("DateTimePicker").maxDate(maxDate);
        });

        //$('#ApplicableUptoDate_Update').datepicker({
        //    numberOfMonths: 1,
        //    dateFormat: 'd M yy',
        //    minDate: 0,

        //})

        $('#ApplicableUptoDate_Update').datetimepicker({
            format: 'DD MMMM YYYY',
            ignoreReadonly: true,
            minDate: moment(),
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
             url: '/GeneralPolicyDetails/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },

    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode, CentreCode) {

        $.ajax(
        {
            cache: false,
            type: "GET",
            data: { actionMode: actionMode, centerCode: CentreCode },
            dataType: "html",
            url: '/GeneralPolicyDetails/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
                notify(message, colorCode);
            }
        });
    },




    //Fire ajax call to insert update and delete record
    AjaxCallGeneralPolicyDetails: function () {
        var GeneralPolicyDetailsData = null;
        if (GeneralPolicyDetails.ActionName == "Create") {
            $("#FormCreateGeneralPolicyDetails").validate();
            if ($("#FormCreateGeneralPolicyDetails").valid()) {
                GeneralPolicyDetailsData = null;
                GeneralPolicyDetailsData = GeneralPolicyDetails.GetGeneralPolicyDetails();
                ajaxRequest.makeRequest("/GeneralPolicyDetails/Create", "POST", GeneralPolicyDetailsData, GeneralPolicyDetails.Success);
            }
        }
        else if (GeneralPolicyDetails.ActionName == "Edit") {
            $("#FormEditGeneralPolicyDetails").validate();
            if ($("#FormEditGeneralPolicyDetails").valid()) {
                GeneralPolicyDetailsData = null;
                GeneralPolicyDetailsData = GeneralPolicyDetails.GetGeneralPolicyDetails();
                ajaxRequest.makeRequest("/GeneralPolicyDetails/Edit", "POST", GeneralPolicyDetailsData, GeneralPolicyDetails.Success);
            }
        }
        else if (GeneralPolicyDetails.ActionName == "Delete") {
            GeneralPolicyDetailsData = null;
            //$("#FormCreateGeneralPolicyDetails").validate();
            GeneralPolicyDetailsData = GeneralPolicyDetails.GetGeneralPolicyDetails();
            ajaxRequest.makeRequest("/GeneralPolicyDetails/Delete", "POST", GeneralPolicyDetailsData, GeneralPolicyDetails.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetGeneralPolicyDetails: function () {
        var Data = {
        };
        if (GeneralPolicyDetails.ActionName == "Create" || GeneralPolicyDetails.ActionName == "Edit") {

            Data.ID = $('#ID').val();
            Data.GeneralPolicyRulesID = $('#GeneralPolicyRulesID').val();
            Data.PolicyCode = $('input[name=PolicyCode]').val();
            Data.PolicyAnswered = $('#PolicyAnswered').val();
            Data.ApplicableFromDate = $('#ApplicableFromDate').val();
            Data.CentreCode = $('#CentreCode').val();
            if (GeneralPolicyDetails.ActionName == "Edit") {
                Data.ApplicableUptoDate = $('#ApplicableUptoDate_Update').val();
            }
            else {
                Data.ApplicableUptoDate = $('#ApplicableUptoDate').val();
            }

            Data.SelectedCentreName = $('#SelectedCentreName').val();

        }
        else if (GeneralPolicyDetails.ActionName == "Delete") {
            Data.ID = $('#ID').val();
        }
        return Data;

    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {

        //var CentreCode = data.SelectedCentreCode;
        //var splitData = data.errorMessage.split(',');
        //parent.$.colorbox.close();
        //GeneralPolicyDetails.ReloadList(splitData[0], splitData[1], splitData[2], CentreCode);



        var CentreCode = data.SelectedCentreCode;//splitdata[1].split(":");
        ////var splitData = data.errorMessage.split(',');
        var splitData = data.split(',');
        if (data != null) {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            GeneralPolicyDetails.ReloadList(splitData[0], splitData[1], splitData[2], CentreCode);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            GeneralPolicyDetails.ReloadList(splitData[0], splitData[1], splitData[2], CentreCode);
        }




    },


};

