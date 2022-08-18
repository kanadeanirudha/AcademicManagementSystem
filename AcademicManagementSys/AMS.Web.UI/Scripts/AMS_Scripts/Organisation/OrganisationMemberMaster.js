////this class contain methods related to nationality functionality
//var OrganisationMemberMaster = {
//    //Member variables
//    ActionName: null,
//    //Class intialisation method
//    Initialize: function () {
//        //organisationStudyCentre.loadData();

//        OrganisationMemberMaster.constructor();
//        //OrganisationMemberMaster.initializeValidation();
//    },
//    //Attach all event of page
//    constructor: function () {

//        // $('#ExperienceTypeDescription').focus();

//        $("#reset").click(function () {

//            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
//            $('input:checkbox,input:radio').removeAttr('checked');
//            $('#MemberName').focus();
//            return false;
//        });


//        // Create new record

//        $('#CreateOrganisationMemberMasterRecord').on("click", function () {
//            OrganisationMemberMaster.ActionName = "Create";
//            OrganisationMemberMaster.AjaxCallOrganisationMemberMaster();
//        });

//        $('#DeleteOrganisationMemberMasterRecord').on("click", function () {
//            OrganisationMemberMaster.ActionName = "Delete";
//            OrganisationMemberMaster.AjaxCallOrganisationMemberMaster();
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

//        $("#JoiningDate").datepicker({
//            dateFormat: 'd M yy',
//            numberOfMonths: 1,            
//        });




//        //FOLLOWING FUNCTION IS SEARCHLIST OF EMPLOYEE NAMES      

//        $("#MemberName").autocomplete({
//            source: function (request, response) {

//                $.ajax({
//                    url: "/OrganisationMemberMaster/GetUserEntity",
//                    type: "POST",
//                    dataType: "json",
//                    data: { term: request.term, centreCode:$("#CentreList :selected").val() },
//                    success: function (data) {

//                        response($.map(data, function (item) {
//                            return { label: item.name, value: item.name, id: item.id, personId: item.personId, personType: item.personType, fistName: item.fistName, middleName: item.middleName, lastName: item.lastName };
//                        }))
//                    }
//                })
//            },
//            select: function (event, ui) {

//                $(this).val(ui.item.label);                                             // display the selected text
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
//                 url: '/OrganisationMemberMaster/List',
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
//                 $('#Createbutton').hide();
//            }
//        });

//        $("#CentreCode").change(function () {
            
//            var selectedItem = $(this).val();
//            var $ddlDepartments = $("#CentrewiseDeptID");
//            var $departmentProgress = $("#states-loading-progress");
//            $departmentProgress.show();
//            if ($("#CentreCode").val() != "") {
//                $.ajax({
//                    cache: false,
//                    type: "GET",
//                    url: "/OrganisationMemberMaster/GetCentrewiseDepartmentByCentreCode",
//                    //url: "@(Url.RouteUrl("GetDepartmentByCentreCode"))",
//                    data: { "CentreCode": selectedItem },
//                    success: function (data) {
//                        $ddlDepartments.html('');
//                        $ddlDepartments.append('<option value="">--Select Department--</option>');
//                        $.each(data, function (id, option) {

//                            $ddlDepartments.append($('<option></option>').val(option.id).html(option.name));
//                        });
//                        $departmentProgress.hide();
//                    },
//                    error: function (xhr, ajaxOptions, thrownError) {
//                        alert('Failed to retrieve Departments.');
//                        $departmentProgress.hide();
//                    }
//                });
//                $('#btnCreate').hide();
//            }
//            else {
//                $('#myDataTable tbody').empty();
//                $('#SelectedDepartmentID').find('option').remove().end().append('<option value>---Select Department---</option>');
//                $('#btnCreate').hide();
//            }
//        });

      
//    },



//    //LoadList method is used to load List page
//    LoadList: function () {

//        $.ajax(
//         {
//             cache: false,
//             type: "POST",

//             dataType: "html",
//             url: 'OrganisationMemberMaster/List',
//             success: function (data) {
//                 //Rebind Grid Data
//                 $('#ListViewModel').html(data);
//             }
//         });
//    },
//    //ReloadList method is used to load List page
//    ReloadList: function (message, colorCode, actionMode) {

//        var CentreCode = $('#CentreList :selected').val();
//        $.ajax(
//        {
//            cache: false,
//            type: "GET",
//            dataType: "html",
//            data: { "actionMode": actionMode, "centerCode": CentreCode },
//            url: '/OrganisationMemberMaster/List',
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

//    //Fire ajax call to insert update and delete record
//    AjaxCallOrganisationMemberMaster: function () {

//        var OrganisationMemberMasterData = null;
//        if (OrganisationMemberMaster.ActionName == "Create") {
//            $("#FormCreateOrganisationMemberMaster").validate();
//            if ($("#FormCreateOrganisationMemberMaster").valid()) {
//                OrganisationMemberMasterData = null;
//                OrganisationMemberMasterData = OrganisationMemberMaster.GetOrganisationMemberMaster();
//                ajaxRequest.makeRequest("/OrganisationMemberMaster/Create", "POST", OrganisationMemberMasterData, OrganisationMemberMaster.Success);
//            }
//        }
//        else if (OrganisationMemberMaster.ActionName == "Delete") {
//            $("#FormDeleteOrganisationMemberMaster").validate();
            
//                OrganisationMemberMasterData = null;
//                OrganisationMemberMasterData = OrganisationMemberMaster.GetOrganisationMemberMaster();
//                ajaxRequest.makeRequest("/OrganisationMemberMaster/Delete", "POST", OrganisationMemberMasterData, OrganisationMemberMaster.Success);
//        }
//    },
//    //Get properties data from the Create, Update and Delete page
//    GetOrganisationMemberMaster: function () {
//        var Data = {
//        };
        
//        if (OrganisationMemberMaster.ActionName == "Create" || OrganisationMemberMaster.ActionName == "Edit") {
           
//            Data.PersonID = $('input[id=PersonID]').val();
//            Data.PersonType = $('input[id=PersonType]').val();
//            Data.FirstName = $('input[id=FirstName]').val();
//            Data.MiddleName = $('input[id=MiddleName]').val();
//            Data.LastName = $('input[id=LastName]').val();
//            Data.JoiningDate = $('#JoiningDate').val();
//            Data.ShareQuantity = $('#ShareQuantity').val();
//            Data.EachSharePrice = $('#EachSharePrice').val();
//            Data.CentreCode = $('#CentreList :selected').val();
//        }
//        else if (OrganisationMemberMaster.ActionName == "Delete") {
//            Data.ID = $('#ID').val();

//            Data.PersonID = $('#PersonID').val();
//        }
//        return Data;
//    },

//    //this is used to for showing successfully record creation message and reload the list view
//    Success: function (data) {
//        var splitData = data.errorMessage.split(',');
//        parent.$.colorbox.close();
//        OrganisationMemberMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
//    },

//};

/////////////new js///////////////////


//this class contain methods related to nationality functionality
var OrganisationMemberMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    map: {},
    map2: {},
    Initialize: function () {
        //organisationStudyCentre.loadData();

        OrganisationMemberMaster.constructor();
        //OrganisationMemberMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        // $('#ExperienceTypeDescription').focus();

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#MemberName').focus();
            return false;
        });


        // Create new record

        $('#CreateOrganisationMemberMasterRecord').on("click", function () {
            OrganisationMemberMaster.ActionName = "Create";
            OrganisationMemberMaster.AjaxCallOrganisationMemberMaster();
        });

        $('#DeleteOrganisationMemberMasterRecord').on("click", function () {
            OrganisationMemberMaster.ActionName = "Delete";
            OrganisationMemberMaster.AjaxCallOrganisationMemberMaster();
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

        //$("#JoiningDate").datepicker({
        //    dateFormat: 'd M yy',
        //    numberOfMonths: 1,
        //});

        $('#JoiningDate').datetimepicker({
            format: 'DD MMMM YYYY',
            ignoreReadonly: true,
            //maxDate: moment(),
        });




        //FOLLOWING FUNCTION IS SEARCHLIST OF EMPLOYEE NAMES      

        //$("#MemberName").autocomplete({
        //    source: function (request, response) {

        //        $.ajax({
        //            url: "/OrganisationMemberMaster/GetUserEntity",
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
                    url: "/OrganisationMemberMaster/GetUserEntity",
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
                                OrganisationMemberMaster.map[response.name] = response;
                                matches.push(response.name);

                            }
                        });

                    },
                    async: false
                })
                cb(matches);
            };

        };

        $("#MemberName").typeahead({
            hint: true,
            highlight: true,
            minLength: 1
        }, {
            source: getData()
        }).on("typeahead:selected", function (obj, item) {
            //$(this).val(item.label);

            //$("#TimeZoneID").val(parseInt(OrganisationStudyCentreMaster.map[item].TimeZoneID));
            //$("#TimeZone").val(OrganisationStudyCentreMaster.map[item].TimeZone);
            //$("#UTCoffset").val(OrganisationStudyCentreMaster.map[item].UTCoffset);

            $("#PersonID").val(parseInt(OrganisationMemberMaster.map[item].personId));
            $("#PersonType").val(OrganisationMemberMaster.map[item].personType);
            $("#FirstName").val(OrganisationMemberMaster.map[item].fistName);
            $("#MiddleName").val(OrganisationMemberMaster.map[item].middleName);
            $("#LastName").val(OrganisationMemberMaster.map[item].lastName);

        });
        //end new search functionality


        //$(".ajax").colorbox();
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
                 url: '/OrganisationMemberMaster/List',
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

        $("#CentreCode").change(function () {

            var selectedItem = $(this).val();
            var $ddlDepartments = $("#CentrewiseDeptID");
            var $departmentProgress = $("#states-loading-progress");
            $departmentProgress.show();
            if ($("#CentreCode").val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/OrganisationMemberMaster/GetCentrewiseDepartmentByCentreCode",
                    //url: "@(Url.RouteUrl("GetDepartmentByCentreCode"))",
                    data: { "CentreCode": selectedItem },
                    success: function (data) {
                        $ddlDepartments.html('');
                        $ddlDepartments.append('<option value="">--Select Department--</option>');
                        $.each(data, function (id, option) {

                            $ddlDepartments.append($('<option></option>').val(option.id).html(option.name));
                        });
                        $departmentProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve Departments.');
                        $departmentProgress.hide();
                    }
                });
                $('#btnCreate').hide();
            }
            else {
                $('#myDataTable tbody').empty();
                $('#SelectedDepartmentID').find('option').remove().end().append('<option value>---Select Department---</option>');
                $('#btnCreate').hide();
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
             url: 'OrganisationMemberMaster/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {

        var CentreCode = $('#CentreList :selected').val();
        $.ajax(
        {
            cache: false,
            type: "GET",
            dataType: "html",
            data: { "actionMode": actionMode, "centerCode": CentreCode },
            url: '/OrganisationMemberMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                $('#Createbutton').show();
                //$('#SuccessMessage').html(message);
                ///$('#SuccessMessage').delay(600).slideDown('slow').delay(1000).slideUp(2000).css('background-color', colorCode);
                notify(message,colorCode);
            }
        });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallOrganisationMemberMaster: function () {

        var OrganisationMemberMasterData = null;
        if (OrganisationMemberMaster.ActionName == "Create") {
            $("#FormCreateOrganisationMemberMaster").validate();
            if ($("#FormCreateOrganisationMemberMaster").valid()) {
                OrganisationMemberMasterData = null;
                OrganisationMemberMasterData = OrganisationMemberMaster.GetOrganisationMemberMaster();
                ajaxRequest.makeRequest("/OrganisationMemberMaster/Create", "POST", OrganisationMemberMasterData, OrganisationMemberMaster.Success);
            }
        }
        else if (OrganisationMemberMaster.ActionName == "Delete") {
            $("#FormDeleteOrganisationMemberMaster").validate();

            OrganisationMemberMasterData = null;
            OrganisationMemberMasterData = OrganisationMemberMaster.GetOrganisationMemberMaster();
            ajaxRequest.makeRequest("/OrganisationMemberMaster/Delete", "POST", OrganisationMemberMasterData, OrganisationMemberMaster.Success);
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetOrganisationMemberMaster: function () {
        var Data = {
        };

        if (OrganisationMemberMaster.ActionName == "Create" || OrganisationMemberMaster.ActionName == "Edit") {

            Data.PersonID = $('input[id=PersonID]').val();
            Data.PersonType = $('input[id=PersonType]').val();
            Data.FirstName = $('input[id=FirstName]').val();
            Data.MiddleName = $('input[id=MiddleName]').val();
            Data.LastName = $('input[id=LastName]').val();
            Data.JoiningDate = $('#JoiningDate').val();
            Data.ShareQuantity = $('#ShareQuantity').val();
            Data.EachSharePrice = $('#EachSharePrice').val();
            Data.CentreCode = $('#CentreList :selected').val();
        }
        else if (OrganisationMemberMaster.ActionName == "Delete") {
            Data.ID = $('#ID').val();

            Data.PersonID = $('#PersonID').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.errorMessage.split(',');
        $.magnificPopup.close();
        OrganisationMemberMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
    },

};

