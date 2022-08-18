////this class contain methods related to nationality functionality
//var OrganisationCentrewiseSession = {
//    //Member variables
//    ActionName: null,
//    ActiveSessionType: null,
//    //Class intialisation method
//    Initialize: function () {
//        //organisationStudyCentre.loadData();

//        OrganisationCentrewiseSession.constructor();
//        //OrganisationCentrewiseSession.initializeValidation();
//    },
//    //Attach all event of page
//    constructor: function () {


//        $('#SelectedCentreCode').on("change", function () {
//            $('#CreateCentrewiseSession').hide(true);
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
//                         url: '/OrganisationCentrewiseSession/List',
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

//        $("#reset").click(function () {

//            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
//            $('input:checkbox,input:radio').removeAttr('checked');

//            return false;
//        });
//        $('#SessionFromDate').datepicker({
//            dateFormat: 'd-M-yy',
//            changeMonth: true,
//            changeYear: true,
//            minDate: 0,
//            //  yearRange: '1950:document.write(currentYear.getFullYear()',
//            maxDate: "+1D +1M + 1Y",
//            onClose: function (selectedDate) {
//                $("#SessionFromDate").datepicker("option", "minDate", selectedDate);
//            }
//        })

//        $('#SessionUptoDate').datepicker({
//            dateFormat: 'd-M-yy',
//            changeMonth: true,
//            changeYear: true,
//            //   yearRange: '1950:document.write(currentYear.getFullYear()',
//            maxDate: "+1Y",
//            onClose: function (selectedDate) {
//                $("#SessionUptoDate").datepicker("option", "maxDate", selectedDate);
//            }
//        })

//        // Create new record
//        $('#CreateOrganisationCentrewiseSessionRecord').on("click", function () {
            
//            OrganisationCentrewiseSession.ActionName = "Create";
//            OrganisationCentrewiseSession.AjaxCallOrganisationCentrewiseSession();
//        });

//        $('#EditOrganisationCentrewiseSessionRecord').on("click", function () {

//            OrganisationCentrewiseSession.ActionName = "Edit";
//            OrganisationCentrewiseSession.AjaxCallOrganisationCentrewiseSession();
//        });

//        $('#DeleteOrganisationCentrewiseSessionRecord').on("click", function () {

//            OrganisationCentrewiseSession.ActionName = "Delete";
//            OrganisationCentrewiseSession.AjaxCallOrganisationCentrewiseSession();
//        });

//        $("#UserSearch").keyup(function () {
//            var oTable = $("#myDataTable").dataTable();
//            oTable.fnFilter(this.value);
//        });

//        $("#searchBtn").click(function () {
//            $("#UserSearch").focus();
//        });

        
//        $('#ActiveSessionType').change(function () {
//            if(document.getElementById('Odd').checked = true)
//            {
//                OrganisationCentrewiseSession.ActiveSessionType = 'O';
//            }
//            else
//            {
//                OrganisationCentrewiseSession.ActiveSessionType = 'E';
//            }
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
//             url: '/OrganisationCentrewiseSession/List',
//             success: function (data) {
//                 //Rebind Grid Data
//                 $('#ListViewModel').html(data);
//                 //$("#CreateCentrewiseSession").show();
//             }
//         });
//    },
//    //ReloadList method is used to load List page
//    //ReloadList: function (message, colorCode, actionMode, centreCode) {
//    //    
//    //    var aaa = centreCode.split('~');
//    //    var SelectedCentreCode = aaa[0];
//    //    var SelectedCentreName = aaa[1];
//    //    $.ajax(
//    //   {
//    //       cache: false,
//    //       type: "POST",
//    //       data: { "centreCode": SelectedCentreCode, "centreName": SelectedCentreName, "actionMode": actionMode },
//    //       dataType: "html",
//    //       url: '/OrganisationCentrewiseSession/List',
//    //       success: function (data) {
//    //           //Rebind Grid Data
//    //           $("#CreateCentrewiseSession").show();
//    //           $("#ListViewModel").empty().append(data);
              
//    //           //twitter type notification
//    //           $('#SuccessMessage').html(message);
//    //           $('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
//    //       }
//    //   });
//    //},

//    ReloadList: function (message, colorCode, actionMode, CentreCode) {
//       // var aaa = CentreCode.split('~');
//        //    var SelectedCentreCode = aaa[0];
//        //    var SelectedCentreName = aaa[1];

//        $.ajax(
//        {
//            cache: false,
//            type: "Post",
//            data: { actionMode: actionMode, centerCode: CentreCode },
//            dataType: "html",
//            //  data: { "actionMode": actionMode },
//            url: '/OrganisationCentrewiseSession/List',
//            success: function (data) {
//                //Rebind Grid Data
//                $("#CreateCentrewiseSession").show();
//                $("#ListViewModel").empty().append(data);
//                //twitter type notification
//                $('#SuccessMessage').html(message);
//                $('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
//            }
//        });
//    },





//    //Fire ajax call to insert update and delete record
//    AjaxCallOrganisationCentrewiseSession: function () {
//        var OrganisationCentrewiseSessionData = null;
//        if (OrganisationCentrewiseSession.ActionName == "Create") {
//            //$("#FormCreateOrganisationCentrewiseSession").validate();
//            //if ($("#FormCreateOrganisationCentrewiseSession").valid()) {
                
//                OrganisationCentrewiseSessionData = null;
//                OrganisationCentrewiseSessionData = OrganisationCentrewiseSession.GetOrganisationCentrewiseSession();
//                ajaxRequest.makeRequest("/OrganisationCentrewiseSession/Create", "POST", OrganisationCentrewiseSessionData, OrganisationCentrewiseSession.Success);
//            //}
//        }
//        else if (OrganisationCentrewiseSession.ActionName == "Edit") {
            
//            $("#FormEditOrganisationCentrewiseSession").validate();
//            if ($("#FormEditOrganisationCentrewiseSession").valid()) {
                
//                OrganisationCentrewiseSessionData = null;
//                OrganisationCentrewiseSessionData = OrganisationCentrewiseSession.GetOrganisationCentrewiseSession();
//                ajaxRequest.makeRequest("/OrganisationCentrewiseSession/Edit", "POST", OrganisationCentrewiseSessionData, OrganisationCentrewiseSession.Success);
//            }
//        }
//        else if (OrganisationCentrewiseSession.ActionName == "Delete") {
//            OrganisationCentrewiseSessionData = null;
//            //$("#FormCreateOrganisationCentrewiseSession").validate();
//            OrganisationCentrewiseSessionData = OrganisationCentrewiseSession.GetOrganisationCentrewiseSession();
//            ajaxRequest.makeRequest("/OrganisationCentrewiseSession/Delete", "POST", OrganisationCentrewiseSessionData, OrganisationCentrewiseSession.Success);

//        }
//    },
//    //Get properties data from the Create, Update and Delete page
//    GetOrganisationCentrewiseSession: function () {
        
//        var Data = {
//        };
//        if (OrganisationCentrewiseSession.ActionName == "Create") {
            
//            Data.ID = $('#ID').val();
//            Data.SessionID = $('#SessionName').val();
//            Data.SessionName = $('#SessionName').text();
//            Data.SessionFromDate = $('#SessionFromDate').val();
//            Data.SessionUptoDate = $('#SessionUptoDate').val();
//            Data.CentreCode = $('#CentreCode').val();
//            Data.ActiveSessionType = $('input[name=ActiveSessionType]:checked').val();
//           // Data.ActiveSessionFlag = $('#ActiveSessionFlag:checked') ? true : false;
//            Data.ActiveSessionFlag = $('input[name=ActiveSessionFlag]:checked').val() ? true : false;

//            Data.LockStatus = $('#LockStatus').val();

//        }
//       else if (OrganisationCentrewiseSession.ActionName == "Edit") {
            
//            Data.ID = $('#ID').val();
//            Data.SessionID = $('#SessionID').val();
//            Data.SessionName = $('#SessionName').text();
//            Data.SessionFromDate = $('#SessionFromDate').val();
//            Data.SessionUptoDate = $('#SessionUptoDate').val();
//            Data.CentreCode = $('#CentreCode').val();
//            Data.ActiveSessionType = $('input[name=ActiveSessionType]:checked').val();
//            Data.ActiveSessionFlag = $('input[name=ActiveSessionFlag]:checked').val() ? true : false;
//            Data.LockStatus = $('#LockStatus').val();

//        }
//        else if (OrganisationCentrewiseSession.ActionName == "Delete") {
//            Data.ID = $('#ID').val();
//        }
//        return Data;
//    },

//    //this is used to for showing successfully record creation message and reload the list view
//    Success: function (data) {
        
//        var CentreCode = data.SelectedCentreCode;//splitdata[1].split(":");
//        ////var splitData = data.errorMessage.split(',');
//        var splitData = data.split(',');
//        if (data != null) {
//            parent.$.colorbox.close();
//            OrganisationCentrewiseSession.ReloadList(splitData[0], splitData[1], splitData[2], CentreCode);
//        } else {
//            parent.$.colorbox.close();
//            OrganisationCentrewiseSession.ReloadList(splitData[0], splitData[1], splitData[2], CentreCode);
//        }
        


//        //var splitData = data.errorMessage.split(',');
//        //if (data != null) {
//        //    parent.$.colorbox.close();
//        //    OrganisationCentrewiseSession.ReloadList(splitData[0], splitData[1], splitData[2], CentreCode);
//        //}

//    },


//};

//////////////////////new js///////////////////////


//this class contain methods related to nationality functionality
var OrganisationCentrewiseSession = {
    //Member variables
    ActionName: null,
    ActiveSessionType: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        OrganisationCentrewiseSession.constructor();
        //OrganisationCentrewiseSession.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {


        $('#SelectedCentreCode').on("change", function () {
            $('#CreateCentrewiseSession').hide(true);
            $('#myDataTable').html("");
            $('#myDataTable_info').text("No entries to show");
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
                         url: '/OrganisationCentrewiseSession/List',
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

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');

            return false;
        });

        $('#SessionFromDate').datetimepicker({
            format: 'DD MMMM YYYY',
            ignoreReadonly: true,
            //maxDate: moment(),
        });

        $('#SessionUptoDate').datetimepicker({
            format: 'DD MMMM YYYY',
            ignoreReadonly: true,
            //maxDate: moment(),
        });

        $('#SessionFromDate').on("dp.hide", function (e) {
            var minDate = new Date(e.date.valueOf());
            minDate.setDate(minDate.getDate());
            $('#SessionUptoDate').data("DateTimePicker").minDate(minDate);
        });

        $('#SessionUptoDate').on("dp.hide", function (e) {
            var maxDate = new Date(e.date.valueOf());
            maxDate.setDate(maxDate.getDate());
            $('#SessionFromDate').data("DateTimePicker").maxDate(maxDate);
        });

        //$('#SessionFromDate').datepicker({
        //    dateFormat: 'd-M-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    minDate: 0,
        //    //  yearRange: '1950:document.write(currentYear.getFullYear()',
        //    maxDate: "+1D +1M + 1Y",
        //    onClose: function (selectedDate) {
        //        $("#SessionFromDate").datepicker("option", "minDate", selectedDate);
        //    }
        //})

        //$('#SessionUptoDate').datepicker({
        //    dateFormat: 'd-M-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    //   yearRange: '1950:document.write(currentYear.getFullYear()',
        //    maxDate: "+1Y",
        //    onClose: function (selectedDate) {
        //        $("#SessionUptoDate").datepicker("option", "maxDate", selectedDate);
        //    }
        //})

        // Create new record
        $('#CreateOrganisationCentrewiseSessionRecord').on("click", function () {

            OrganisationCentrewiseSession.ActionName = "Create";
            OrganisationCentrewiseSession.AjaxCallOrganisationCentrewiseSession();
        });

        $('#EditOrganisationCentrewiseSessionRecord').on("click", function () {

            OrganisationCentrewiseSession.ActionName = "Edit";
            OrganisationCentrewiseSession.AjaxCallOrganisationCentrewiseSession();
        });

        $('#DeleteOrganisationCentrewiseSessionRecord').on("click", function () {

            OrganisationCentrewiseSession.ActionName = "Delete";
            OrganisationCentrewiseSession.AjaxCallOrganisationCentrewiseSession();
        });

        $("#UserSearch").keyup(function () {
            var oTable = $("#myDataTable").dataTable();
            oTable.fnFilter(this.value);
        });

        $("#searchBtn").click(function () {
            $("#UserSearch").focus();
        });


        $('#ActiveSessionType').change(function () {
            if (document.getElementById('Odd').checked = true) {
                OrganisationCentrewiseSession.ActiveSessionType = 'O';
            }
            else {
                OrganisationCentrewiseSession.ActiveSessionType = 'E';
            }
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
             url: '/OrganisationCentrewiseSession/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
                 //$("#CreateCentrewiseSession").show();
             }
         });
    },
    

    ReloadList: function (message, colorCode, actionMode, CentreCode) {
        // var aaa = CentreCode.split('~');
        //    var SelectedCentreCode = aaa[0];
        //    var SelectedCentreName = aaa[1];

        $.ajax(
        {
            cache: false,
            type: "Post",
            data: { actionMode: actionMode, centerCode: CentreCode },
            dataType: "html",
            //  data: { "actionMode": actionMode },
            url: '/OrganisationCentrewiseSession/List',
            success: function (data) {
                //Rebind Grid Data
                $("#CreateCentrewiseSession").show();
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
                notify(message, colorCode);
            }
        });
    },





    //Fire ajax call to insert update and delete record
    AjaxCallOrganisationCentrewiseSession: function () {
        var OrganisationCentrewiseSessionData = null;
        if (OrganisationCentrewiseSession.ActionName == "Create") {
            //$("#FormCreateOrganisationCentrewiseSession").validate();
            //if ($("#FormCreateOrganisationCentrewiseSession").valid()) {

            OrganisationCentrewiseSessionData = null;
            OrganisationCentrewiseSessionData = OrganisationCentrewiseSession.GetOrganisationCentrewiseSession();
            ajaxRequest.makeRequest("/OrganisationCentrewiseSession/Create", "POST", OrganisationCentrewiseSessionData, OrganisationCentrewiseSession.Success);
            //}
        }
        else if (OrganisationCentrewiseSession.ActionName == "Edit") {

            $("#FormEditOrganisationCentrewiseSession").validate();
            if ($("#FormEditOrganisationCentrewiseSession").valid()) {

                OrganisationCentrewiseSessionData = null;
                OrganisationCentrewiseSessionData = OrganisationCentrewiseSession.GetOrganisationCentrewiseSession();
                ajaxRequest.makeRequest("/OrganisationCentrewiseSession/Edit", "POST", OrganisationCentrewiseSessionData, OrganisationCentrewiseSession.Success);
            }
        }
        else if (OrganisationCentrewiseSession.ActionName == "Delete") {
            OrganisationCentrewiseSessionData = null;
            //$("#FormCreateOrganisationCentrewiseSession").validate();
            OrganisationCentrewiseSessionData = OrganisationCentrewiseSession.GetOrganisationCentrewiseSession();
            ajaxRequest.makeRequest("/OrganisationCentrewiseSession/Delete", "POST", OrganisationCentrewiseSessionData, OrganisationCentrewiseSession.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetOrganisationCentrewiseSession: function () {

        var Data = {
        };
        if (OrganisationCentrewiseSession.ActionName == "Create") {

            Data.ID = $('#ID').val();
            Data.SessionID = $('#SessionName').val();
            Data.SessionName = $('#SessionName').text();
            Data.SessionFromDate = $('#SessionFromDate').val();
            Data.SessionUptoDate = $('#SessionUptoDate').val();
            Data.CentreCode = $('#CentreCode').val();
            Data.ActiveSessionType = $('input[name=ActiveSessionType]:checked').val();
            // Data.ActiveSessionFlag = $('#ActiveSessionFlag:checked') ? true : false;
            Data.ActiveSessionFlag = $('input[name=ActiveSessionFlag]:checked').val() ? true : false;

            Data.LockStatus = $('#LockStatus').val();

        }
        else if (OrganisationCentrewiseSession.ActionName == "Edit") {

            Data.ID = $('#ID').val();
            Data.SessionID = $('#SessionID').val();
            Data.SessionName = $('#SessionName').text();
            Data.SessionFromDate = $('#SessionFromDate').val();
            Data.SessionUptoDate = $('#SessionUptoDate').val();
            Data.CentreCode = $('#CentreCode').val();
            Data.ActiveSessionType = $('input[name=ActiveSessionType]:checked').val();
            Data.ActiveSessionFlag = $('input[name=ActiveSessionFlag]:checked').val() ? true : false;
            Data.LockStatus = $('#LockStatus').val();

        }
        else if (OrganisationCentrewiseSession.ActionName == "Delete") {
            Data.ID = $('#ID').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {

        var CentreCode = data.SelectedCentreCode;//splitdata[1].split(":");
        ////var splitData = data.errorMessage.split(',');
        var splitData = data.split(',');
        if (data != null) {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            OrganisationCentrewiseSession.ReloadList(splitData[0], splitData[1], splitData[2], CentreCode);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            OrganisationCentrewiseSession.ReloadList(splitData[0], splitData[1], splitData[2], CentreCode);
        }



        //var splitData = data.errorMessage.split(',');
        //if (data != null) {
        //    parent.$.colorbox.close();
        //    OrganisationCentrewiseSession.ReloadList(splitData[0], splitData[1], splitData[2], CentreCode);
        //}

    },


};

