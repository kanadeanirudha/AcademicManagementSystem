////this class contain methods related to nationality functionality
//var FeePredefinedCriteriaParameters = {
//    //Member variables
//    ActionName: null,
//    //Class intialisation method
//    Initialize: function () {
//        //organisationStudyCentre.loadData();

//        FeePredefinedCriteriaParameters.constructor();
//        //FeePredefinedCriteriaParameters.initializeValidation();
//    },
//    //Attach all event of page
//    constructor: function () {

//        $("#reset").click(function () {

//            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
//            $('input:checkbox,input:radio').removeAttr('checked');
//            return false;
//        });

//        //cascading 
//        $("#TableEntityName").change(function () {
//            debugger;
//            var selectedItem = $(this).val();
//          //  FeePredefinedCriteriaParameters.ResetBaseTableKeyValues();
//            if (selectedItem != "") {
//                var $ddlPrimaryKey = $("#PrimaryKeyFieldName");
//                var $PrimaryKeyProgress = $("#states-loading-progress");
//                var $ddlColumnList = $("#DisplayKeyFieldName");
//                var $ColumnListProgress = $("#states-loading-progress");
//                $PrimaryKeyProgress.show();
//                $ColumnListProgress.show();
//                $.ajax({
//                    cache: false,
//                    type: "GET",
//                    url: "/FeePredefinedCriteriaParameters/GetPrimaryKeyList",
//                    data: { "tableName": selectedItem },
//                    success: function (data) {
//                        //------------------binding dropdown 1
//                        $ddlPrimaryKey.html('');
//                        $('#PrimaryKeyFieldName').append('<option value>----Select Primary Key ----</option>');
//                        $.each(data.Result1, function (id, option) {

//                            $ddlPrimaryKey.append($('<option></option>').val(option.id).html(option.name));
//                        });
//                        $PrimaryKeyProgress.hide();
//                        //------------------binding dropdown 2
//                        $ddlColumnList.html('');
//                        $('#DisplayKeyFieldName').append('<option value>----Select Display Field----</option>');
//                        $.each(data.Result2, function (id, option) {

//                            $ddlColumnList.append($('<option></option>').val(option.id).html(option.name));
//                        });
//                        $ColumnListProgress.hide();
//                    },
//                    error: function (xhr, ajaxOptions, thrownError) {
//                        alert('Failed to retrieve data.');
//                        $PrimaryKeyProgress.hide();
//                    }
//                });
//            }
//            else {
//                $('#PrimaryKeyFieldName').find('option').remove().end().append('<option value>---Select Primary Key ---</option>');
//                $('#DisplayKeyFieldName').find('option').remove().end().append('<option value>---Select Display Field---</option>');
//            }
//        });

//        //$('#PrimaryKeyFieldName').on("change", function () {
//        //    FeePredefinedCriteriaParameters.ResetBaseTableKeyValues();
//        //});
//        //$('#DisplayKeyFieldName').on("change", function () {
//        //    FeePredefinedCriteriaParameters.ResetBaseTableKeyValues();
//        //});


//        // Create new record
//        $('#CreateFeePredefinedCriteriaParametersRecord').on("click", function () {
//            FeePredefinedCriteriaParameters.ActionName = "Create";
//            FeePredefinedCriteriaParameters.AjaxCallFeePredefinedCriteriaParameters();
//        });

//        $('#EditFeePredefinedCriteriaParametersRecord').on("click", function () {

//            FeePredefinedCriteriaParameters.ActionName = "Edit";
//            FeePredefinedCriteriaParameters.AjaxCallFeePredefinedCriteriaParameters();
//        });

//        $('#DeleteFeePredefinedCriteriaParametersRecord').on("click", function () {

//            FeePredefinedCriteriaParameters.ActionName = "Delete";
//            FeePredefinedCriteriaParameters.AjaxCallFeePredefinedCriteriaParameters();
//        });


//        $('#FeeCriteriaParametersCode').on("keydown", function (e) {
//            AMSValidation.NotAllowSpaces(e);

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


//    //ResetBaseTableKeyValues: function () {
//    //    $('#TaskApprovalKeyValue').find('option').remove().end().append('<option value>-----Select Primary Key Values-------</option>');
//    //    $('#e5_f .ms-drop ul').html('<li class="ms-no-results" style="display: list-item;">No matches found</li>');
//    //},

//    //LoadList method is used to load List page
//    LoadList: function () {

//        $.ajax(

//         {

//             cache: false,
//             type: "POST",

//             dataType: "html",
//             url: '/FeePredefinedCriteriaParameters/List',
//             success: function (data) {
//                 //Rebind Grid Data
//                 $('#ListViewModel').html(data);
//             }
//         });
//    },
//    //ReloadList method is used to load List page
//    ReloadList: function (message, colorCode, actionMode) {

//        $.ajax(
//        {
//            cache: false,
//            type: "POST",
//            dataType: "html",
//            data: { "actionMode": actionMode },
//            url: '/FeePredefinedCriteriaParameters/List',
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
//    AjaxCallFeePredefinedCriteriaParameters: function () {
//        var FeePredefinedCriteriaParametersData = null;
//        if (FeePredefinedCriteriaParameters.ActionName == "Create") {
//            $("#FormCreateFeePredefinedCriteriaParameters").validate();
//            if ($("#FormCreateFeePredefinedCriteriaParameters").valid()) {
//                debugger;
//                FeePredefinedCriteriaParametersData = null;
//                FeePredefinedCriteriaParametersData = FeePredefinedCriteriaParameters.GetFeePredefinedCriteriaParameters();
//                ajaxRequest.makeRequest("/FeePredefinedCriteriaParameters/Create", "POST", FeePredefinedCriteriaParametersData, FeePredefinedCriteriaParameters.Success, "CreateFeePredefinedCriteriaParametersRecord");
//            }
//        }
//        else if (FeePredefinedCriteriaParameters.ActionName == "Edit") {
//            $("#FormEditFeePredefinedCriteriaParameters").validate();
//            if ($("#FormEditFeePredefinedCriteriaParameters").valid()) {
//                FeePredefinedCriteriaParametersData = null;
//                FeePredefinedCriteriaParametersData = FeePredefinedCriteriaParameters.GetFeePredefinedCriteriaParameters();
//                ajaxRequest.makeRequest("/FeePredefinedCriteriaParameters/Edit", "POST", FeePredefinedCriteriaParametersData, FeePredefinedCriteriaParameters.Success);
//            }
//        }
//        else if (FeePredefinedCriteriaParameters.ActionName == "Delete") {
//            FeePredefinedCriteriaParametersData = null;
//            //$("#FormCreateFeePredefinedCriteriaParameters").validate();
//            FeePredefinedCriteriaParametersData = FeePredefinedCriteriaParameters.GetFeePredefinedCriteriaParameters();
//            ajaxRequest.makeRequest("/FeePredefinedCriteriaParameters/Delete", "POST", FeePredefinedCriteriaParametersData, FeePredefinedCriteriaParameters.Success, "DeleteFeePredefinedCriteriaParametersRecord");

//        }
//    },
//    //Get properties data from the Create, Update and Delete page
//    GetFeePredefinedCriteriaParameters: function () {
//        var Data = {
//        };
//        if (FeePredefinedCriteriaParameters.ActionName == "Create" || FeePredefinedCriteriaParameters.ActionName == "Edit") {
//            debugger;
//            Data.ID = $('#ID').val();
//            Data.FeeCriteriaParametersDescription = $('#FeeCriteriaParametersDescription').val();
//            Data.FeeCriteriaParametersCode = $('#FeeCriteriaParametersCode').val();
//            Data.TableEntityName = $('#TableEntityName').val();
//            Data.PrimaryKeyFieldName = $('#PrimaryKeyFieldName').val();
//            Data.DisplayKeyFieldName = $('#DisplayKeyFieldName').val();

//        }
//        else if (FeePredefinedCriteriaParameters.ActionName == "Delete") {
//            Data.ID = $('#ID').val();
//        }
//        return Data;
//    },

//    //this is used to for showing successfully record creation message and reload the list view
//    Success: function (data) {
//        debugger;
//        var splitData = data.split(',');
//        if (data != null) {
//            parent.$.colorbox.close();
//            FeePredefinedCriteriaParameters.ReloadList(splitData[0], splitData[1], splitData[2]);
//        } else {
//            parent.$.colorbox.close();
//            FeePredefinedCriteriaParameters.ReloadList(splitData[0], splitData[1], splitData[2]);
//        }

//    },


//};

////////////////new js////////////////////////


//this class contain methods related to nationality functionality
var FeePredefinedCriteriaParameters = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        FeePredefinedCriteriaParameters.constructor();
        //FeePredefinedCriteriaParameters.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            return false;
        });

        //cascading 
        $("#TableEntityName").change(function () {
            debugger;
            var selectedItem = $(this).val();
            //  FeePredefinedCriteriaParameters.ResetBaseTableKeyValues();
            if (selectedItem != "") {
                var $ddlPrimaryKey = $("#PrimaryKeyFieldName");
                var $PrimaryKeyProgress = $("#states-loading-progress");
                var $ddlColumnList = $("#DisplayKeyFieldName");
                var $ColumnListProgress = $("#states-loading-progress");
                $PrimaryKeyProgress.show();
                $ColumnListProgress.show();
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/FeePredefinedCriteriaParameters/GetPrimaryKeyList",
                    data: { "tableName": selectedItem },
                    success: function (data) {
                        //------------------binding dropdown 1
                        $ddlPrimaryKey.html('');
                        $('#PrimaryKeyFieldName').append('<option value>----Select Primary Key ----</option>');
                        $.each(data.Result1, function (id, option) {

                            $ddlPrimaryKey.append($('<option></option>').val(option.id).html(option.name));
                        });
                        $PrimaryKeyProgress.hide();
                        //------------------binding dropdown 2
                        $ddlColumnList.html('');
                        $('#DisplayKeyFieldName').append('<option value>----Select Display Field----</option>');
                        $.each(data.Result2, function (id, option) {

                            $ddlColumnList.append($('<option></option>').val(option.id).html(option.name));
                        });
                        $ColumnListProgress.hide();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve data.');
                        $PrimaryKeyProgress.hide();
                    }
                });
            }
            else {
                $('#PrimaryKeyFieldName').find('option').remove().end().append('<option value>---Select Primary Key ---</option>');
                $('#DisplayKeyFieldName').find('option').remove().end().append('<option value>---Select Display Field---</option>');
            }
        });

        //$('#PrimaryKeyFieldName').on("change", function () {
        //    FeePredefinedCriteriaParameters.ResetBaseTableKeyValues();
        //});
        //$('#DisplayKeyFieldName').on("change", function () {
        //    FeePredefinedCriteriaParameters.ResetBaseTableKeyValues();
        //});


        // Create new record
        $('#CreateFeePredefinedCriteriaParametersRecord').on("click", function () {
            FeePredefinedCriteriaParameters.ActionName = "Create";
            FeePredefinedCriteriaParameters.AjaxCallFeePredefinedCriteriaParameters();
        });

        $('#EditFeePredefinedCriteriaParametersRecord').on("click", function () {

            FeePredefinedCriteriaParameters.ActionName = "Edit";
            FeePredefinedCriteriaParameters.AjaxCallFeePredefinedCriteriaParameters();
        });

        $('#DeleteFeePredefinedCriteriaParametersRecord').on("click", function () {

            FeePredefinedCriteriaParameters.ActionName = "Delete";
            FeePredefinedCriteriaParameters.AjaxCallFeePredefinedCriteriaParameters();
        });


        $('#FeeCriteriaParametersCode').on("keydown", function (e) {
            AMSValidation.NotAllowSpaces(e);

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

       // $(".ajax").colorbox();
        InitAnimatedBorder();
        CloseAlert();

    },


    //ResetBaseTableKeyValues: function () {
    //    $('#TaskApprovalKeyValue').find('option').remove().end().append('<option value>-----Select Primary Key Values-------</option>');
    //    $('#e5_f .ms-drop ul').html('<li class="ms-no-results" style="display: list-item;">No matches found</li>');
    //},

    //LoadList method is used to load List page
    LoadList: function () {

        $.ajax(

         {

             cache: false,
             type: "POST",

             dataType: "html",
             url: '/FeePredefinedCriteriaParameters/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {

        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { "actionMode": actionMode },
            url: '/FeePredefinedCriteriaParameters/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
                
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallFeePredefinedCriteriaParameters: function () {
        var FeePredefinedCriteriaParametersData = null;
        if (FeePredefinedCriteriaParameters.ActionName == "Create") {
            $("#FormCreateFeePredefinedCriteriaParameters").validate();
            if ($("#FormCreateFeePredefinedCriteriaParameters").valid()) {
                
                FeePredefinedCriteriaParametersData = null;
                FeePredefinedCriteriaParametersData = FeePredefinedCriteriaParameters.GetFeePredefinedCriteriaParameters();
                ajaxRequest.makeRequest("/FeePredefinedCriteriaParameters/Create", "POST", FeePredefinedCriteriaParametersData, FeePredefinedCriteriaParameters.Success, "CreateFeePredefinedCriteriaParametersRecord");
            }
        }
        else if (FeePredefinedCriteriaParameters.ActionName == "Edit") {
            $("#FormEditFeePredefinedCriteriaParameters").validate();
            if ($("#FormEditFeePredefinedCriteriaParameters").valid()) {
                FeePredefinedCriteriaParametersData = null;
                FeePredefinedCriteriaParametersData = FeePredefinedCriteriaParameters.GetFeePredefinedCriteriaParameters();
                ajaxRequest.makeRequest("/FeePredefinedCriteriaParameters/Edit", "POST", FeePredefinedCriteriaParametersData, FeePredefinedCriteriaParameters.Success);
            }
        }
        else if (FeePredefinedCriteriaParameters.ActionName == "Delete") {
            FeePredefinedCriteriaParametersData = null;
            //$("#FormCreateFeePredefinedCriteriaParameters").validate();
            FeePredefinedCriteriaParametersData = FeePredefinedCriteriaParameters.GetFeePredefinedCriteriaParameters();
            ajaxRequest.makeRequest("/FeePredefinedCriteriaParameters/Delete", "POST", FeePredefinedCriteriaParametersData, FeePredefinedCriteriaParameters.Success, "DeleteFeePredefinedCriteriaParametersRecord");

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetFeePredefinedCriteriaParameters: function () {
        var Data = {
        };
        if (FeePredefinedCriteriaParameters.ActionName == "Create" || FeePredefinedCriteriaParameters.ActionName == "Edit") {
            
            Data.ID = $('#ID').val();
            Data.FeeCriteriaParametersDescription = $('#FeeCriteriaParametersDescription').val();
            Data.FeeCriteriaParametersCode = $('#FeeCriteriaParametersCode').val();
            Data.TableEntityName = $('#TableEntityName').val();
            Data.PrimaryKeyFieldName = $('#PrimaryKeyFieldName').val();
            Data.DisplayKeyFieldName = $('#DisplayKeyFieldName').val();

        }
        else if (FeePredefinedCriteriaParameters.ActionName == "Delete") {
            Data.ID = $('#ID').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        debugger;
        var splitData = data.split(',');
        if (data != null) {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            FeePredefinedCriteriaParameters.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            FeePredefinedCriteriaParameters.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },


};

