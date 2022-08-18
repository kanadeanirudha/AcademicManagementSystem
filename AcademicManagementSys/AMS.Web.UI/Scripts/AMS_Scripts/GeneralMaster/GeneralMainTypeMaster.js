
////This class cantain methods for General Previous Tables For Main Type Master funcationality.
//var GeneralMainTypeMaster = {

//    //Member variables
//    ActionName: null,
//    //Class intialisation method
//    Initialize: function () {
//        GeneralMainTypeMaster.constructor();
//    },

//    //Attach all event of page
//    constructor: function () {

//        $("#reset").click(function () {
//            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val('');
//            $('input:checkbox,input:radio').removeAttr('checked');
//            $('#ModuleCode').val('');
//            $('#MenuCode').val('');
//            $('#TransactionType').val('');
//            $('#RefTableEntityDisplayKey').val('');
//        });

//        //Create New Record  
//        $('#CreateGeneralMainTypeMasterRecord').on("click", function () {
//            GeneralMainTypeMaster.ActionName = "Create";
//            GeneralMainTypeMaster.AjaxCallGeneralMainTypeMaster();
//        });

//        //Delete Record
//        $('#DeleteGeneralMainTypeMasterRecord').on("click", function () {
//            GeneralMainTypeMaster.ActionName = "Delete";
//            GeneralMainTypeMaster.AjaxCallGeneralMainTypeMaster();
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

//        $('#TypeDesc').on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
//        });

//        $('#TypeShortDesc').on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
//        });

//        $('#SubTypeDesc').on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
//        });

//        $('#SubShortDesc').on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
//        });

//        $('#KeyCode').on("keydown", function (e) {
//            AMSValidation.AllowCharacterOnly(e);
//        });

//        //Method to bind menu list on module code.
//        $("#ModuleCode").change(function (e) {           
//            if ($('#ModuleCode :selected').val() != "") {
//                var $ddlUserMenuList = $("#MenuCode");
//                $.ajax({
//                    cache: false,
//                    type: "GET",
//                    datatype: "html",
//                    data: { "moduleCode": $('#ModuleCode :selected').val() },
//                    url: '/GeneralMainTypeMaster/GetUserMenuMasterList',
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

//        //Get Hidden Feild Value from ModuleCode And MenuCode.
//        $("#MenuCode").change(function (e) {
//            if ($('#ModuleCode :selected').val() != "" && $('#MenuCode :selected').val() != "") {
//                $.ajax({
//                    cache: false,
//                    type: "GET",
//                    datatype: "html",
//                    data: { "moduleCode": $('#ModuleCode :selected').val(), "menuCode": $('#MenuCode :selected').val() },
//                    url: '/GeneralMainTypeMaster/GetGeneralPreTableforMainMaster',
//                    success: function (data) {                        
//                        if (data.RefTableEntity != null && data.RefTableEntityKey != null && data.RefTableEntityDisplayKey != null) {
//                            $("#RefTableEntity").html('');
//                            $('#RefTableEntity').val(data.RefTableEntity);

//                            $("#RefTableEntityKey").html('');
//                            $('#RefTableEntityKey').val(data.RefTableEntityKey);

//                            $("#RefTableEntityKeyValue").html('');
//                            $('#RefTableEntityKeyValue').val(data.RefTableEntityDisplayKey);
//                            $("#ValidSuccess").show();

//                            if ($('#RefTableEntity').val() != "" && $('#RefTableEntityKey').val() != "" && $('#RefTableEntityKeyValue').val() != "") {                                
//                                var $ddlRefTableEntityDisplayKeyList = $("#RefTableEntityDisplayKey");
//                                $.ajax({
//                                    cache: false,
//                                    type: "GET",
//                                    datatype: "html",
//                                    data: { "refTableEntity": $('#RefTableEntity').val(), "refTableEntityKey": $('#RefTableEntityKey').val(), "refTableEntityKeyValue": $('#RefTableEntityKeyValue').val() },
//                                    url: '/GeneralMainTypeMaster/GetRefrenceTableRecord',
//                                    success: function (data) {
//                                        //Bind data with menu drop down.
//                                        $ddlRefTableEntityDisplayKeyList.html('');
//                                        $("#RefTableEntityDisplayKey").empty().append('<option value>----------Select key value ----------</option>');
//                                        $.each(data, function (DisplayField, option) {
//                                            $ddlRefTableEntityDisplayKeyList.append($('<option></option>').val(option.DisplayField).html(option.DisplayField));
//                                        });
//                                    },
//                                    error: function (xhr, ajaxOptions, thrownError) {
//                                        alert('Failed to retrieve data.');
//                                    }
//                                });
//                            }
//                            else
//                            {                               
//                                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectFailedToRetrieveData", "SuccessMessages", "#FFCC80");
//                            }
//                        }
//                        else {                           
//                            ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectFailedToRetrieveData", "SuccessMessages", "#FFCC80");                            
//                            $("#ValidSuccess").hide();
//                        }
//                    },
//                    error: function (xhr, ajaxOptions, thrownError) {
//                        $("#ValidSuccess").hide();
//                        ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectFailedToRetrieveData", "SuccessMessages", "#FFCC80");
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
//            url: '/GeneralMainTypeMaster/List',
//            data: { "actionMode": null },
//            success: function (data) {
//                //Rebind Grid Data.
//                $('#ListViewModel').html(data);
//                $("#ValidSuccess").hide();
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
//            url: '/GeneralMainTypeMaster/List',
//            success: function (data) {
//                //Rebind Grid Data
//                $("#ListViewModel").empty().append(data);
//                //twitter type notification
//                $('#SuccessMessage').html(message);
//                $('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', colorCode);
//                $("#ValidSuccess").hide();
//            }
//        });
//    },

//    //Fire ajax call to insert update and delete record
//    AjaxCallGeneralMainTypeMaster: function () {
//        var GeneralMainTypeMasterData = null;
//        if (GeneralMainTypeMaster.ActionName == "Create") {
//            $("#FormCreateGeneralMainTypeMaster").validate();
//            if ($("#FormCreateGeneralMainTypeMaster").valid()) {
//                GeneralMainTypeMasterData = null;
//                GeneralMainTypeMasterData = GeneralMainTypeMaster.GetGeneralMainTypeMaster();
//                ajaxRequest.makeRequest("/GeneralMainTypeMaster/Create", "POST", GeneralMainTypeMasterData, GeneralMainTypeMaster.Success);
//            }
//        }

//        else if (GeneralMainTypeMaster.ActionName == "Delete") {
//            GeneralMainTypeMasterData = null;
//            GeneralMainTypeMasterData = GeneralMainTypeMaster.GetGeneralMainTypeMaster();
//            ajaxRequest.makeRequest("/GeneralMainTypeMaster/Delete", "POST", GeneralMainTypeMasterData, GeneralMainTypeMaster.Success);
//        }
//    },

//    //Get properties data from the Create, Update and Delete page
//    GetGeneralMainTypeMaster: function () {
//        var Data = {
//        };
//        if (GeneralMainTypeMaster.ActionName == "Create") {
//            Data.TypeDesc = $('#TypeDesc').val();
//            Data.TypeShortDesc = $('#TypeShortDesc').val();
//            Data.ModuleCode = $('#ModuleCode :selected').val();
//            Data.MenuCode = $('#MenuCode :selected').val();
//            Data.IsFixed = $('#IsFixed').val();

//            Data.SubTypeDesc = $('#SubTypeDesc').val();
//            Data.SubShortDesc = $('#SubShortDesc').val();
//            Data.TransactionType = $('#TransactionType :selected').val();
//            Data.KeyCode = $('#KeyCode').val();            
//            Data.RefTableEntityDisplayKey = $('#RefTableEntityDisplayKey :selected').val();
//            Data.RefTableEntity = $('#RefTableEntity').val();
//            Data.RefTableEntityKey = $('#RefTableEntityKey').val();
//            Data.RefTableEntityKeyValue = $('#RefTableEntityKeyValue').val();
//            Data.IsActive = true;
//        }
//        else if (GeneralMainTypeMaster.ActionName == "Delete") {
//            Data.ID = $('input[name=ID]').val();
//        }
//        return Data;
//    },
//    //this is used to for showing successfully record creation message and reload the list view
//    Success: function (data) {
//        var splitData = data.split(',');
//        parent.$.colorbox.close();
//        GeneralMainTypeMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
//    }
//};

//////////////////////////////////new js///////////////////////////////////



//This class cantain methods for General Previous Tables For Main Type Master funcationality.
var GeneralMainTypeMaster = {

    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        GeneralMainTypeMaster.constructor();
    },

    //Attach all event of page
    constructor: function () {

        $("#reset").click(function () {
            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val('');
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#ModuleCode').val('');
            $('#MenuCode').val('');
            $('#TransactionType').val('');
            $('#RefTableEntityDisplayKey').val('');
        });

        //Create New Record  
        $('#CreateGeneralMainTypeMasterRecord').on("click", function () {
            GeneralMainTypeMaster.ActionName = "Create";
            GeneralMainTypeMaster.AjaxCallGeneralMainTypeMaster();
        });

        //Delete Record
        $('#DeleteGeneralMainTypeMasterRecord').on("click", function () {
            GeneralMainTypeMaster.ActionName = "Delete";
            GeneralMainTypeMaster.AjaxCallGeneralMainTypeMaster();
        });

        //$("#UserSearch").keyup(function () {
        //    var oTable = $("#myDataTable").dataTable();
        //    oTable.fnFilter(this.value);
        //});

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


        $('#TypeDesc').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#TypeShortDesc').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#SubTypeDesc').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#SubShortDesc').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#KeyCode').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        //Method to bind menu list on module code.
        $("#ModuleCode").change(function (e) {
            if ($('#ModuleCode :selected').val() != "") {
                var $ddlUserMenuList = $("#MenuCode");
                $.ajax({
                    cache: false,
                    type: "GET",
                    datatype: "html",
                    data: { "moduleCode": $('#ModuleCode :selected').val() },
                    url: '/GeneralMainTypeMaster/GetUserMenuMasterList',
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

        //Get Hidden Feild Value from ModuleCode And MenuCode.
        $("#MenuCode").change(function (e) {
            if ($('#ModuleCode :selected').val() != "" && $('#MenuCode :selected').val() != "") {
                $.ajax({
                    cache: false,
                    type: "GET",
                    datatype: "html",
                    data: { "moduleCode": $('#ModuleCode :selected').val(), "menuCode": $('#MenuCode :selected').val() },
                    url: '/GeneralMainTypeMaster/GetGeneralPreTableforMainMaster',
                    success: function (data) {
                        if (data.RefTableEntity != null && data.RefTableEntityKey != null && data.RefTableEntityDisplayKey != null) {
                            $("#RefTableEntity").html('');
                            $('#RefTableEntity').val(data.RefTableEntity);

                            $("#RefTableEntityKey").html('');
                            $('#RefTableEntityKey').val(data.RefTableEntityKey);

                            $("#RefTableEntityKeyValue").html('');
                            $('#RefTableEntityKeyValue').val(data.RefTableEntityDisplayKey);
                            $("#ValidSuccess").show();

                            if ($('#RefTableEntity').val() != "" && $('#RefTableEntityKey').val() != "" && $('#RefTableEntityKeyValue').val() != "") {
                                var $ddlRefTableEntityDisplayKeyList = $("#RefTableEntityDisplayKey");
                                $.ajax({
                                    cache: false,
                                    type: "GET",
                                    datatype: "html",
                                    data: { "refTableEntity": $('#RefTableEntity').val(), "refTableEntityKey": $('#RefTableEntityKey').val(), "refTableEntityKeyValue": $('#RefTableEntityKeyValue').val() },
                                    url: '/GeneralMainTypeMaster/GetRefrenceTableRecord',
                                    success: function (data) {
                                        //Bind data with menu drop down.
                                        $ddlRefTableEntityDisplayKeyList.html('');
                                        $("#RefTableEntityDisplayKey").empty().append('<option value>----------Select key value ----------</option>');
                                        $.each(data, function (DisplayField, option) {
                                            $ddlRefTableEntityDisplayKeyList.append($('<option></option>').val(option.DisplayField).html(option.DisplayField));
                                        });
                                    },
                                    error: function (xhr, ajaxOptions, thrownError) {
                                        alert('Failed to retrieve data.');
                                    }
                                });
                            }
                            else {
                                ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectFailedToRetrieveData", "SuccessMessages", "#FFCC80");
                            }
                        }
                        else {
                            ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectFailedToRetrieveData", "SuccessMessages", "#FFCC80");
                            $("#ValidSuccess").hide();
                        }
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        $("#ValidSuccess").hide();
                        ajaxRequest.ErrorMessageForJS("JsValidationMessages_SelectFailedToRetrieveData", "SuccessMessages", "#FFCC80");
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
            url: '/GeneralMainTypeMaster/List',
            data: { "actionMode": null },
            success: function (data) {
                //Rebind Grid Data.
                $('#ListViewModel').html(data);
                $("#ValidSuccess").hide();
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
            url: '/GeneralMainTypeMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                //$('#SuccessMessage').html(message);
                //$('#SuccessMessage').delay(400).slideDown(400).delay(15000).slideUp(400).css('background-color', colorCode);
                notify(message,colorCode);
                $("#ValidSuccess").hide();
            }
        });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallGeneralMainTypeMaster: function () {
        var GeneralMainTypeMasterData = null;
        if (GeneralMainTypeMaster.ActionName == "Create") {
            $("#FormCreateGeneralMainTypeMaster").validate();
            if ($("#FormCreateGeneralMainTypeMaster").valid()) {
                GeneralMainTypeMasterData = null;
                GeneralMainTypeMasterData = GeneralMainTypeMaster.GetGeneralMainTypeMaster();
                ajaxRequest.makeRequest("/GeneralMainTypeMaster/Create", "POST", GeneralMainTypeMasterData, GeneralMainTypeMaster.Success);
            }
        }

        else if (GeneralMainTypeMaster.ActionName == "Delete") {
            GeneralMainTypeMasterData = null;
            GeneralMainTypeMasterData = GeneralMainTypeMaster.GetGeneralMainTypeMaster();
            ajaxRequest.makeRequest("/GeneralMainTypeMaster/Delete", "POST", GeneralMainTypeMasterData, GeneralMainTypeMaster.Success);
        }
    },

    //Get properties data from the Create, Update and Delete page
    GetGeneralMainTypeMaster: function () {
        var Data = {
        };
        if (GeneralMainTypeMaster.ActionName == "Create") {
            Data.TypeDesc = $('#TypeDesc').val();
            Data.TypeShortDesc = $('#TypeShortDesc').val();
            Data.ModuleCode = $('#ModuleCode :selected').val();
            Data.MenuCode = $('#MenuCode :selected').val();
            Data.IsFixed = $('#IsFixed').val();

            Data.SubTypeDesc = $('#SubTypeDesc').val();
            Data.SubShortDesc = $('#SubShortDesc').val();
            Data.TransactionType = $('#TransactionType :selected').val();
            Data.KeyCode = $('#KeyCode').val();
            Data.RefTableEntityDisplayKey = $('#RefTableEntityDisplayKey :selected').val();
            Data.RefTableEntity = $('#RefTableEntity').val();
            Data.RefTableEntityKey = $('#RefTableEntityKey').val();
            Data.RefTableEntityKeyValue = $('#RefTableEntityKeyValue').val();
            Data.IsActive = true;
        }
        else if (GeneralMainTypeMaster.ActionName == "Delete") {
            Data.ID = $('input[name=ID]').val();
        }
        return Data;
    },
    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        //parent.$.colorbox.close();
        $.magnificPopup.close();
        GeneralMainTypeMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
    }
};