
////This class cantain methods for General Previous Tables For Main Type Master funcationality.
//var GeneralPreTablesForMainTypeMaster = {

//    //Member variables
//    ActionName: null,
//    //Class intialisation method
//    Initialize: function () {
//        GeneralPreTablesForMainTypeMaster.constructor();
//    },

//    //Attach all event of page
//    constructor: function () {

//        $("#reset").click(function () {
//            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val('');
//            $('input:checkbox,input:radio').removeAttr('checked');
//        });

//        //Create New Record  
//        $('#CreateGeneralPreTablesForMainTypeMasterRecord').on("click", function () {
//            GeneralPreTablesForMainTypeMaster.ActionName = "Create";
//            GeneralPreTablesForMainTypeMaster.AjaxCallGeneralPreTablesForMainTypeMaster();
//        });

//        //Delete Record
//        $('#DeleteGeneralPreTablesForMainTypeMasterRecord').on("click", function () {
//            GeneralPreTablesForMainTypeMaster.ActionName = "Delete";
//            GeneralPreTablesForMainTypeMaster.AjaxCallGeneralPreTablesForMainTypeMaster();
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

//        // Validate Input fields in form
//        //$('#FirstName').on("keydown", function (e) {
//        //    AMSValidation.AllowCharacterOnly(e);
//        //});

//        //Method to bind menu list on module code.
//        $("#ModuleCode").change(function (e) {
//            if ($('#ModuleCode :selected').val() != "") {
//                var $ddlUserMenuList = $("#MenuCode");
//                $.ajax({
//                    cache: false,
//                    type: "GET",
//                    datatype: "html",
//                    data: { "moduleCode": $('#ModuleCode :selected').val() },
//                    url: '/GeneralPreTablesForMainTypeMaster/GetUserMenuMasterList',
//                    success: function (data) {                        
//                        //Bind data with menu drop down.
//                        $ddlUserMenuList.html('');
//                        $("#MenuCode").empty().append('<option value>----------Select Menu ----------</option>');
//                        $.each(data, function (MenuCode, option) {                            
//                            $ddlUserMenuList.append($('<option></option>').val(option.MenuCode).html(option.MenuName));
//                        });
//                    },
//                    error: function (xhr, ajaxOptions, thrownError) {
//                        alert('Failed to retrieve data.');
//                    }
//                });
//            }
//        });

//        // Method to bind primary key and column name to drop down.
//        $("#TableName").change(function (e) {           
//            if ($('#TableName :selected').val() != "") {                
//                var $ddlTablePrimaryKeyList = $("#TablePrimaryKey");
//                var $ddlTableDisplayFieldList = $("#DisplayField");
//                $.ajax({
//                    cache : false,
//                    type: "GET",
//                    datatype: "html",
//                    data: { "tableName": $('#TableName :selected').val() },
//                    url: '/GeneralPreTablesForMainTypeMaster/GetTableFielsList',
//                    success: function (data) {
//                        //Bind primary key on table name.
//                        $ddlTablePrimaryKeyList.html('');
//                        $("#TablePrimaryKey").empty().append('<option value>----------Select Primary Key ----------</option>');
//                        $.each(data.PrimaryKey, function (id, option) {
//                            $ddlTablePrimaryKeyList.append($('<option></option>').val(option.id).html(option.name));
//                        });

//                        //---------------Bind Feild Name----------
//                        $ddlTableDisplayFieldList.html('');
//                        $("#DisplayField").empty().append('<option value>----------Select Table Field----------</option>');
//                        $.each(data.DisplayField, function (DisplayField, option) {
//                            $ddlTableDisplayFieldList.append($('<option></option>').val(option.id).html(option.name));
//                        });
//                    },
//                    error: function (xhr, ajaxOptions, thrownError) {
//                        alert('Failed to retrieve data.');
//                    }
//                });
//            }
//        });

//    },

//    LoadList: function () {
//        $.ajax({
//            cache: false,
//            type: "POST",
//            datatype: "html",
//            url: '/GeneralPreTablesForMainTypeMaster/List',
//            data: { "actionMode": null },
//            success: function (data) {
//                //Rebind Grid Data.
//                $('#ListViewModel').html(data);
//            }
//        });
//    },

//    //ReloadList method is used to load List page
//    ReloadList: function (message, colorCode, actionMode) {
//        $.ajax({
//            cache: false,
//            type: "POST",
//            datatype: "html",
//            data: { actionMode: actionMode },
//            url: '/GeneralPreTablesForMainTypeMaster/List',
//            success: function (data) {
//                //Rebind Grid Data
//                $("#ListViewModel").empty().append(data);
//                //twitter type notification
//                $('#SuccessMessage').html(message);
//                $('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', colorCode);
//            }
//        });
//    },
      

//    //Fire ajax call to insert update and delete record
//    AjaxCallGeneralPreTablesForMainTypeMaster: function () {
//        var GeneralPreTablesForMainTypeMasterData = null;
//        if (GeneralPreTablesForMainTypeMaster.ActionName == "Create") {
//            $("#FormCreateGeneralPreTablesForMainTypeMaster").validate();
//            if ($("#FormCreateGeneralPreTablesForMainTypeMaster").valid()) {
//                GeneralPreTablesForMainTypeMasterData = null;
//                GeneralPreTablesForMainTypeMasterData = GeneralPreTablesForMainTypeMaster.GetGeneralPreTablesForMainTypeMaster();
//                ajaxRequest.makeRequest("/GeneralPreTablesForMainTypeMaster/Create", "POST", GeneralPreTablesForMainTypeMasterData, GeneralPreTablesForMainTypeMaster.Success);
//            }
//        }
        
//        else if (GeneralPreTablesForMainTypeMaster.ActionName == "Delete") {
//            GeneralPreTablesForMainTypeMasterData = null;
//            GeneralPreTablesForMainTypeMasterData = GeneralPreTablesForMainTypeMaster.GetGeneralPreTablesForMainTypeMaster();
//            ajaxRequest.makeRequest("/GeneralPreTablesForMainTypeMaster/Delete", "POST", GeneralPreTablesForMainTypeMasterData, GeneralPreTablesForMainTypeMaster.Success);
//        }
//    },
//    //Get properties data from the Create, Update and Delete page
//    GetGeneralPreTablesForMainTypeMaster: function () {
//        var Data = {
//        };
//        if (GeneralPreTablesForMainTypeMaster.ActionName == "Create") {
//            Data.ModuleCode = $('#ModuleCode :selected').val();
//            Data.MenuCode = $('#MenuCode :selected').val();
//            Data.RefTableEntity = $('#TableName :selected').val();
//            Data.RefTableEntityDisplayKey = $('#TablePrimaryKey :selected').val();
//            Data.RefTableEntityKey = $('#DisplayField :selected').val();            
//        }
//        else if (GeneralPreTablesForMainTypeMaster.ActionName == "Delete") {
//            Data.ID = $('input[name=ID]').val();
//        }
//        return Data;
//    },
//    //this is used to for showing successfully record creation message and reload the list view
//    Success: function (data) {
//        var splitData = data.split(',');
//        parent.$.colorbox.close();
//        GeneralPreTablesForMainTypeMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
//    }
//};

///////////////////new js/////////////////


//This class cantain methods for General Previous Tables For Main Type Master funcationality.
var GeneralPreTablesForMainTypeMaster = {

    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        GeneralPreTablesForMainTypeMaster.constructor();
    },

    //Attach all event of page
    constructor: function () {

        $("#reset").click(function () {
            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val('');
            $('input:checkbox,input:radio').removeAttr('checked');
        });

        //Create New Record  
        $('#CreateGeneralPreTablesForMainTypeMasterRecord').on("click", function () {
            GeneralPreTablesForMainTypeMaster.ActionName = "Create";
            GeneralPreTablesForMainTypeMaster.AjaxCallGeneralPreTablesForMainTypeMaster();
        });

        //Delete Record
        $('#DeleteGeneralPreTablesForMainTypeMasterRecord').on("click", function () {
            GeneralPreTablesForMainTypeMaster.ActionName = "Delete";
            GeneralPreTablesForMainTypeMaster.AjaxCallGeneralPreTablesForMainTypeMaster();
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

        // Validate Input fields in form
        //$('#FirstName').on("keydown", function (e) {
        //    AMSValidation.AllowCharacterOnly(e);
        //});

        //Method to bind menu list on module code.
        $("#ModuleCode").change(function (e) {
            if ($('#ModuleCode :selected').val() != "") {
                var $ddlUserMenuList = $("#MenuCode");
                $.ajax({
                    cache: false,
                    type: "GET",
                    datatype: "html",
                    data: { "moduleCode": $('#ModuleCode :selected').val() },
                    url: '/GeneralPreTablesForMainTypeMaster/GetUserMenuMasterList',
                    success: function (data) {
                        //Bind data with menu drop down.
                        $ddlUserMenuList.html('');
                        $("#MenuCode").empty().append('<option value>----------Select Menu ----------</option>');
                        $.each(data, function (MenuCode, option) {
                            $ddlUserMenuList.append($('<option></option>').val(option.MenuCode).html(option.MenuName));
                        });
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve data.');
                    }
                });
            }
        });

        // Method to bind primary key and column name to drop down.
        $("#TableName").change(function (e) {
            if ($('#TableName :selected').val() != "") {
                var $ddlTablePrimaryKeyList = $("#TablePrimaryKey");
                var $ddlTableDisplayFieldList = $("#DisplayField");
                $.ajax({
                    cache: false,
                    type: "GET",
                    datatype: "html",
                    data: { "tableName": $('#TableName :selected').val() },
                    url: '/GeneralPreTablesForMainTypeMaster/GetTableFielsList',
                    success: function (data) {
                        //Bind primary key on table name.
                        $ddlTablePrimaryKeyList.html('');
                        $("#TablePrimaryKey").empty().append('<option value>----------Select Primary Key ----------</option>');
                        $.each(data.PrimaryKey, function (id, option) {
                            $ddlTablePrimaryKeyList.append($('<option></option>').val(option.id).html(option.name));
                        });

                        //---------------Bind Feild Name----------
                        $ddlTableDisplayFieldList.html('');
                        $("#DisplayField").empty().append('<option value>----------Select Table Field----------</option>');
                        $.each(data.DisplayField, function (DisplayField, option) {
                            $ddlTableDisplayFieldList.append($('<option></option>').val(option.id).html(option.name));
                        });
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert('Failed to retrieve data.');
                    }
                });
            }
        });

    },

    LoadList: function () {
        $.ajax({
            cache: false,
            type: "POST",
            datatype: "html",
            url: '/GeneralPreTablesForMainTypeMaster/List',
            data: { "actionMode": null },
            success: function (data) {
                //Rebind Grid Data.
                $('#ListViewModel').html(data);
            }
        });
    },

    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        $.ajax({
            cache: false,
            type: "POST",
            datatype: "html",
            data: { actionMode: actionMode },
            url: '/GeneralPreTablesForMainTypeMaster/List',
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


    //Fire ajax call to insert update and delete record
    AjaxCallGeneralPreTablesForMainTypeMaster: function () {
        var GeneralPreTablesForMainTypeMasterData = null;
        if (GeneralPreTablesForMainTypeMaster.ActionName == "Create") {
            $("#FormCreateGeneralPreTablesForMainTypeMaster").validate();
            if ($("#FormCreateGeneralPreTablesForMainTypeMaster").valid()) {
                GeneralPreTablesForMainTypeMasterData = null;
                GeneralPreTablesForMainTypeMasterData = GeneralPreTablesForMainTypeMaster.GetGeneralPreTablesForMainTypeMaster();
                ajaxRequest.makeRequest("/GeneralPreTablesForMainTypeMaster/Create", "POST", GeneralPreTablesForMainTypeMasterData, GeneralPreTablesForMainTypeMaster.Success);
            }
        }

        else if (GeneralPreTablesForMainTypeMaster.ActionName == "Delete") {
            GeneralPreTablesForMainTypeMasterData = null;
            GeneralPreTablesForMainTypeMasterData = GeneralPreTablesForMainTypeMaster.GetGeneralPreTablesForMainTypeMaster();
            ajaxRequest.makeRequest("/GeneralPreTablesForMainTypeMaster/Delete", "POST", GeneralPreTablesForMainTypeMasterData, GeneralPreTablesForMainTypeMaster.Success);
        }
    },
    //Get properties data from the Create, Update and Delete page
    GetGeneralPreTablesForMainTypeMaster: function () {
        var Data = {
        };
        if (GeneralPreTablesForMainTypeMaster.ActionName == "Create") {
            Data.ModuleCode = $('#ModuleCode :selected').val();
            Data.MenuCode = $('#MenuCode :selected').val();
            Data.RefTableEntity = $('#TableName :selected').val();
            Data.RefTableEntityDisplayKey = $('#TablePrimaryKey :selected').val();
            Data.RefTableEntityKey = $('#DisplayField :selected').val();
        }
        else if (GeneralPreTablesForMainTypeMaster.ActionName == "Delete") {
            Data.ID = $('input[name=ID]').val();
        }
        return Data;
    },
    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        //parent.$.colorbox.close();
        $.magnificPopup.close();
        GeneralPreTablesForMainTypeMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
    }
};