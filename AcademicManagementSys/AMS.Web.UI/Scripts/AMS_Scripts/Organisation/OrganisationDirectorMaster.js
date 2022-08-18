
////this class contain methods related to organisation director master functionality
//var OrganisationDirectorMaster = {
//    //Member variables
//    ActionName: null,
//    //Class intialisation method
//    Initialize: function () {
//        OrganisationDirectorMaster.constructor();        
//    },

//    //Attach all event of page
//    constructor: function () {
//        $("#reset").click(function () {

//            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
//            $('input:checkbox,input:radio').removeAttr('checked');
//            $('#DirectorName').focus();            
//            return false;
//        });

//        // Create new record
//        $('#CreateOrganisationDirectorMasterRecord').on("click", function () {
//            OrganisationDirectorMaster.ActionName = "Create";
//            OrganisationDirectorMaster.AjaxCallOrganisationDirectorMaster();
//        });

//        //Edit Record
//        $('#EditOrganisationDirectorMasterRecord').on("click", function () {
//            OrganisationDirectorMaster.ActionName = "Edit";
//            OrganisationDirectorMaster.AjaxCallOrganisationDirectorMaster();
//        });

//        //Delete Record
//        $('#DeleteOrganisationDirectorMasterRecord').on("click", function () {
//            OrganisationDirectorMaster.ActionName = "Delete";
//            OrganisationDirectorMaster.AjaxCallOrganisationDirectorMaster();
//        });
        
        
//        //To search Record.
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

//        $("#JoiningDate").datepicker({
//            dateFormat: 'd M yy',
//            numberOfMonths: 1,
//        });

//        $("#LeavingDate").datepicker({
//            dateFormat: 'd M yy',
//            numberOfMonths: 1,
//        });

//        //FOLLOWING FUNCTION IS SEARCHLIST OF EMPLOYEE NAMES 
//        $("#DirectorName").autocomplete({
//            source: function (request, response) {               
//                $.ajax({
//                    url: "/OrganisationDirectorMaster/GetUserEntity",
//                    type: "POST",
//                    dataType: "json",
//                    data: { term: request.term, centreCode: $("#CentreList :selected").val() },
//                    success: function (data) {
                        
//                        response($.map(data, function (item) {
//                            return { label: item.name, value: item.name, id: item.id, personId: item.personId, personType: item.personType, fistName: item.fistName, middleName: item.middleName, lastName: item.lastName };
//                        }))
//                    }
//                })
//            },
//            select: function (event, ui) {
               
//                $(this).val(ui.item.label);                                             // display the selected text
//                $('#OrganisationMembersMasterID').val(ui.item.id);
//                $("#PersonID").val(ui.item.personId);                                       // save selected id to hidden input
//                $("#PersonType").val(ui.item.personType);
//                $("#FirstName").val(ui.item.fistName);
//                $("#MiddleName").val(ui.item.middleName);
//                $("#LastName").val(ui.item.lastName);
//            }
//        });



//        $(".ajax").colorbox();

//        $("#CentreList").change(function () {
//            $('#myDataTable').html("");
//            $('#myDataTable_info').text("No entries to show");
//            $('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
//            $('#Createbutton').hide();
//        });

//        $("#ShowList").click(function () {           
//            var SelectedCentreCode = $('#CentreList').val();
//            var SelectedCentreName = $('#CentreList :selected').text();

//            if (SelectedCentreCode != "") {
//                $.ajax(
//             {
//                 cache: false,
//                 type: "POST",
//                 data: { actionMode: null, centerCode: SelectedCentreCode, centreName: SelectedCentreName },

//                 dataType: "html",
//                 url: '/OrganisationDirectorMaster/List',
//                 success: function (result) {
//                     //Rebind Grid Data                
//                     $('#ListViewModel').html(result);
//                     $('#Createbutton').show();
//                 }
//             });
//            }
//            else {
//                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectCentre", "SuccessMessage", "#FFCC80");
//                //  OrganisationMemberMaster.ReloadList("Please select centre", "#FFCC80", null);
//                $('#Createbutton').hide();
//            }
//        });

//    },

//    //LoadList method is used to load List page
//    LoadList: function () {
//        $.ajax({
//             cache: false,
//             type: "POST",
//             dataType: "html",
//             url: 'OrganisationDirectorMaster/List',
//             success: function (data) {
//                 //Rebind Grid Data
//                 $('#ListViewModel').html(data);
//             }
//         });
//    },

//    //ReloadList method is used to load List page
//    ReloadList: function (message, colorCode, actionMode) {
//        var CentreCode = $('#CentreList :selected').val();        
//        $.ajax({
//            cache: false,
//            type: "GET",
//            dataType: "html",
//            data: { "actionMode": actionMode, "centerCode": CentreCode },
//            url: '/OrganisationDirectorMaster/List',
//            success: function (data) {
//                //Rebind Grid Data
//                $("#ListViewModel").empty().append(data);
//                //twitter type notification
//                $('#Createbutton').show();
//                $('#SuccessMessage').html(message);
//                $('#SuccessMessage').delay(600).slideDown('slow').delay(1000).slideUp(2000).css('background-color', colorCode);
//            }
//        });
//    },

//    //Ajax call to insert update record
//    AjaxCallOrganisationDirectorMaster: function () {

//        var OrganisationDirectorMasterData = null;
//        if (OrganisationDirectorMaster.ActionName == "Create") {
//            $("#FormCreateOrganisationDirectorMaster").validate();
//            if ($("#FormCreateOrganisationDirectorMaster").valid()) {
//                OrganisationDirectorMasterData = null;
//                OrganisationDirectorMasterData = OrganisationDirectorMaster.GetOrganisationDirectorMaster();
//                ajaxRequest.makeRequest("/OrganisationDirectorMaster/Create", "POST", OrganisationDirectorMasterData, OrganisationDirectorMaster.Success);
//            }
//        }
//        else if (OrganisationDirectorMaster.ActionName == "Edit") {
//            $("#FormEditOrganisationDirectorMaster").validate();
//            if ($("#FormEditOrganisationDirectorMaster").valid()) {
//                OrganisationDirectorMasterData = null;
//                OrganisationDirectorMasterData = OrganisationDirectorMaster.GetOrganisationDirectorMaster();
//                ajaxRequest.makeRequest("/OrganisationDirectorMaster/Edit", "POST", OrganisationDirectorMasterData, OrganisationDirectorMaster.Success);
//            }
//        }
//        else if (OrganisationDirectorMaster.ActionName == "Delete") {
//            $("#FormDeleteOrganisationMemberMaster").validate();
//            OrganisationDirectorMasterData = null;
//            OrganisationDirectorMasterData = OrganisationDirectorMaster.GetOrganisationDirectorMaster();
//            ajaxRequest.makeRequest("/OrganisationDirectorMaster/Delete", "POST", OrganisationDirectorMasterData, OrganisationDirectorMaster.Success);
//        }
//    },

//    //Get properties data from the Create, Update and Delete page
//    GetOrganisationDirectorMaster: function () {
//        var Data = {
//        };
        
//        if (OrganisationDirectorMaster.ActionName == "Create" || OrganisationDirectorMaster.ActionName == "Edit") {
           
//            Data.OrganisationMembersMasterID = $('input[id=OrganisationMembersMasterID]').val();
//            Data.PersonID = $('input[id=PersonID]').val();
//            Data.PersonType = $('input[id=PersonType]').val();
//            Data.FirstName = $('input[id=FirstName]').val();
//            Data.MiddleName = $('input[id=MiddleName]').val();
//            Data.LastName = $('input[id=LastName]').val();
//            Data.JoiningDate = $('#JoiningDate').val();
//            Data.PrintingSeqOrder = $('#PrintingSeqOrder').val();
//            Data.IsCurrentDirector = $("input[id=IsCurrentDirector]:checked").val();
//            Data.IsLifeTimeDirector = $("input[id=IsLifeTimeDirector]:checked").val();
//            Data.DesignationID = $('#Designation :selected').val();
//            Data.CentreCode = $('#CentreList :selected').val();
//            if (OrganisationDirectorMaster.ActionName == "Edit")
//            {
//                Data.ID = $('input[id=ID]').val();
//                Data.LeavingDate = $('#LeavingDate').val();
//            }
//        }
//        else if (OrganisationDirectorMaster.ActionName == "Delete") {
//            Data.ID = $('#ID').val();
//            Data.PersonID = $('#PersonID').val();
//        }
//        return Data;
//    },

//    //this is used to for showing successfully record creation message and reload the list view
//    Success: function (data) {       
//        var splitData = data.errorMessage.split(',');
//        parent.$.colorbox.close();
//        OrganisationDirectorMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
//    },


//};


///////new js//////////////////


//this class contain methods related to organisation director master functionality
var OrganisationDirectorMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    map: {},
    map2: {},
    Initialize: function () {
        OrganisationDirectorMaster.constructor();
    },

    //Attach all event of page
    constructor: function () {
        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#DirectorName').focus();
            return false;
        });

        // Create new record
        $('#CreateOrganisationDirectorMasterRecord').on("click", function () {
            OrganisationDirectorMaster.ActionName = "Create";
            OrganisationDirectorMaster.AjaxCallOrganisationDirectorMaster();
        });

        //Edit Record
        $('#EditOrganisationDirectorMasterRecord').on("click", function () {
            OrganisationDirectorMaster.ActionName = "Edit";
            OrganisationDirectorMaster.AjaxCallOrganisationDirectorMaster();
        });

        //Delete Record
        $('#DeleteOrganisationDirectorMasterRecord').on("click", function () {
            OrganisationDirectorMaster.ActionName = "Delete";
            OrganisationDirectorMaster.AjaxCallOrganisationDirectorMaster();
        });


        //To search Record.
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

        //$("#JoiningDate").datepicker({
        //    dateFormat: 'd M yy',
        //    numberOfMonths: 1,
        //});

        //$("#LeavingDate").datepicker({
        //    dateFormat: 'd M yy',
        //    numberOfMonths: 1,
        //});

        $('#JoiningDate').datetimepicker({
            format: 'DD MMMM YYYY',
            ignoreReadonly: true,
            //maxDate: moment(),
        });

        $('#LeavingDate').datetimepicker({
            format: 'DD MMMM YYYY',
            ignoreReadonly: true,
            //maxDate: moment(),
        });


        //FOLLOWING FUNCTION IS SEARCHLIST OF EMPLOYEE NAMES 
        //$("#DirectorName").autocomplete({
        //    source: function (request, response) {
        //        $.ajax({
        //            url: "/OrganisationDirectorMaster/GetUserEntity",
        //            type: "POST",
        //            dataType: "json",
        //            data: { term: request.term, centreCode: $("#CentreList :selected").val() },
        //            success: function (data) {

        //                response($.map(data, function (item) {
        //                    return { label: item.name, value: item.name, id: item.id, personId: item.personId, personType: item.personType, fistName: item.fistName, middleName: item.middleName, lastName: item.lastName };
        //                }))
        //            }
        //        })
        //    },
        //    select: function (event, ui) {

        //        $(this).val(ui.item.label);                                             // display the selected text
        //        $('#OrganisationMembersMasterID').val(ui.item.id);
        //        $("#PersonID").val(ui.item.personId);                                       // save selected id to hidden input
        //        $("#PersonType").val(ui.item.personType);
        //        $("#FirstName").val(ui.item.fistName);
        //        $("#MiddleName").val(ui.item.middleName);
        //        $("#LastName").val(ui.item.lastName);
        //    }
        //});

        /////////////new search functionality///////////////////////////////////
        var getData = function () {
            return function findMatches(q, cb) {

                var matches, substringRegex;

                // an array that will be populated with substring matches
                matches = [];

                // regex used to determine if a string contains the substring `q`
                substrRegex = new RegExp(q, 'i');

                $.ajax({
                    url: "/OrganisationDirectorMaster/GetUserEntity",
                    type: "POST",
                    data: { term: q, centreCode: $("#CentreList :selected").val() },
                    dataType: "json",
                    success: function (data) {

                        // iterate through the pool of strings and for any string that
                        // contains the substring `q`, add it to the `matches` array
                        //alert(data);

                        $.each(data, function (i, response) {
                            //alert(response.personId);

                            if (substrRegex.test(response.name)) {
                                //alert(response.personId);
                                OrganisationDirectorMaster.map[response.name] = response;
                                matches.push(response.name);

                            }
                        });

                    },
                    async: false
                })
                cb(matches);
            };

        };

        $("#DirectorName").typeahead({
            hint: true,
            highlight: true,
            minLength: 1
        }, {
            source: getData()
        }).on("typeahead:selected", function (obj, item) {
            
            //$("#PersonID").val(parseInt(OrganisationDirectorMaster.map[item].personId));
            //$("#PersonType").val(OrganisationMemberMaster.map[item].personType);
            //$("#FirstName").val(OrganisationMemberMaster.map[item].fistName);
            //$("#MiddleName").val(OrganisationMemberMaster.map[item].middleName);
            //$("#LastName").val(OrganisationMemberMaster.map[item].lastName);

            $('#OrganisationMembersMasterID').val(OrganisationDirectorMaster.map[item].id);
            $("#PersonID").val(OrganisationDirectorMaster.map[item].personId);
            $("#PersonType").val(OrganisationDirectorMaster.map[item].personType);
            $("#FirstName").val(OrganisationDirectorMaster.map[item].fistName);
            $("#MiddleName").val(OrganisationDirectorMaster.map[item].middleName);
            $("#LastName").val(OrganisationDirectorMaster.map[item].lastName);

        });
        //end new search functionality

        InitAnimatedBorder();
        CloseAlert();


        $("#CentreList").change(function () {
            $('#myDataTable').html("");
            //$('#myDataTable_info').text("No entries to show");
            //$('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');
            //$('#Createbutton').hide();
        });

        $("#ShowList").click(function () {
            var SelectedCentreCode = $('#CentreList').val();
            var SelectedCentreName = $('#CentreList :selected').text();

            if (SelectedCentreCode != "") {
                $.ajax(
             {
                 cache: false,
                 type: "POST",
                 data: { actionMode: null, centerCode: SelectedCentreCode, centreName: SelectedCentreName },

                 dataType: "html",
                 url: '/OrganisationDirectorMaster/List',
                 success: function (result) {
                     //Rebind Grid Data                
                     $('#ListViewModel').html(result);
                     $('#Createbutton').show();
                 }
             });
            }
            else {
                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectCentre", "SuccessMessage", "#FFCC80");
                //  OrganisationMemberMaster.ReloadList("Please select centre", "#FFCC80", null);
                $('#Createbutton').hide();
            }
        });

    },

    //LoadList method is used to load List page
    LoadList: function () {
        $.ajax({
            cache: false,
            type: "POST",
            dataType: "html",
            url: 'OrganisationDirectorMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $('#ListViewModel').html(data);
            }
        });
    },

    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        var CentreCode = $('#CentreList :selected').val();
        $.ajax({
            cache: false,
            type: "GET",
            dataType: "html",
            data: { "actionMode": actionMode, "centerCode": CentreCode },
            url: '/OrganisationDirectorMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                $('#Createbutton').show();
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(600).slideDown('slow').delay(1000).slideUp(2000).css('background-color', colorCode);
                notify(message,colorCode);
            }
        });
    },

    //Ajax call to insert update record
    AjaxCallOrganisationDirectorMaster: function () {

        var OrganisationDirectorMasterData = null;
        if (OrganisationDirectorMaster.ActionName == "Create") {
            $("#FormCreateOrganisationDirectorMaster").validate();
            if ($("#FormCreateOrganisationDirectorMaster").valid()) {
                OrganisationDirectorMasterData = null;
                OrganisationDirectorMasterData = OrganisationDirectorMaster.GetOrganisationDirectorMaster();
                ajaxRequest.makeRequest("/OrganisationDirectorMaster/Create", "POST", OrganisationDirectorMasterData, OrganisationDirectorMaster.Success);
            }
        }
        else if (OrganisationDirectorMaster.ActionName == "Edit") {
            $("#FormEditOrganisationDirectorMaster").validate();
            if ($("#FormEditOrganisationDirectorMaster").valid()) {
                OrganisationDirectorMasterData = null;
                OrganisationDirectorMasterData = OrganisationDirectorMaster.GetOrganisationDirectorMaster();
                ajaxRequest.makeRequest("/OrganisationDirectorMaster/Edit", "POST", OrganisationDirectorMasterData, OrganisationDirectorMaster.Success);
            }
        }
        else if (OrganisationDirectorMaster.ActionName == "Delete") {
            $("#FormDeleteOrganisationMemberMaster").validate();
            OrganisationDirectorMasterData = null;
            OrganisationDirectorMasterData = OrganisationDirectorMaster.GetOrganisationDirectorMaster();
            ajaxRequest.makeRequest("/OrganisationDirectorMaster/Delete", "POST", OrganisationDirectorMasterData, OrganisationDirectorMaster.Success);
        }
    },

    //Get properties data from the Create, Update and Delete page
    GetOrganisationDirectorMaster: function () {
        var Data = {
        };

        if (OrganisationDirectorMaster.ActionName == "Create" || OrganisationDirectorMaster.ActionName == "Edit") {

            Data.OrganisationMembersMasterID = $('input[id=OrganisationMembersMasterID]').val();
            Data.PersonID = $('input[id=PersonID]').val();
            Data.PersonType = $('input[id=PersonType]').val();
            Data.FirstName = $('input[id=FirstName]').val();
            Data.MiddleName = $('input[id=MiddleName]').val();
            Data.LastName = $('input[id=LastName]').val();
            Data.JoiningDate = $('#JoiningDate').val();
            Data.PrintingSeqOrder = $('#PrintingSeqOrder').val();
            //Data.IsCurrentDirector = $("input[id=IsCurrentDirector]:checked").val();
            //Data.IsLifeTimeDirector = $("input[id=IsLifeTimeDirector]:checked").val();
            Data.IsCurrentDirector = $('input[id=IsCurrentDirector]:checked').val() ? true : false;
            Data.IsLifeTimeDirector = $('input[id=IsLifeTimeDirector]:checked').val() ? true : false;

            Data.DesignationID = $('#Designation :selected').val();
            Data.CentreCode = $('#CentreList :selected').val();
            if (OrganisationDirectorMaster.ActionName == "Edit") {
                Data.ID = $('input[id=ID]').val();
                Data.LeavingDate = $('#LeavingDate').val();
            }
        }
        else if (OrganisationDirectorMaster.ActionName == "Delete") {
            Data.ID = $('#ID').val();
            Data.PersonID = $('#PersonID').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.errorMessage.split(',');
        $.magnificPopup.close();
        OrganisationDirectorMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
    },


};