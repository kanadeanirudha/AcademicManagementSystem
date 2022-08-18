////this class contain methods related to nationality functionality
//var InventoryMachineMaster = {
//    //Member variables
//    ActionName: null,
//    //Class intialisation method
//    Initialize: function () {
//        //organisationStudyCentre.loadData();

//        InventoryMachineMaster.constructor();
//        //InventoryMachineMaster.initializeValidation();
//    },
//    //Attach all event of page
//    constructor: function () {

//        $('#MachineName').focus();

//        $("#reset").click(function () {

//            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
//            $('input:checkbox,input:radio').removeAttr('checked');
//            $('#MachineName').focus();
//            return false;
//        });


//        // Create new record
//        $('#CreateInventoryMachineMasterRecord').on("click", function () {
           
//            InventoryMachineMaster.ActionName = "Create";
//            InventoryMachineMaster.AjaxCallInventoryMachineMaster();
//        });

//        $('#EditInventoryMachineMasterRecord').on("click", function () {
           
//            InventoryMachineMaster.ActionName = "Edit";
//            InventoryMachineMaster.AjaxCallInventoryMachineMaster();
//        });

//        $('#DeleteInventoryMachineMasterRecord').on("click", function () {
           
//            InventoryMachineMaster.ActionName = "Delete";
//            InventoryMachineMaster.AjaxCallInventoryMachineMaster();
//        });


//        //$('#counterName').on("keydown", function (e) {
//        //    AMSValidation.NotAllowSpaces(e);

//        //});
//        $('#MachineCode').on("keydown", function (e) {
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
//    //LoadList method is used to load List page
//    LoadList: function () {

//        $.ajax(

//         {

//             cache: false,
//             type: "POST",

//             dataType: "html",
//             url: '/InventoryMachineMaster/List',
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
//            url: '/InventoryMachineMaster/List',
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
//    AjaxCallInventoryMachineMaster: function () {
//        var InventoryMachineMasterData = null;
//        if (InventoryMachineMaster.ActionName == "Create") {
//            $("#FormCreateInventoryMachineMaster").validate();
//            if ($("#FormCreateInventoryMachineMaster").valid()) {
//                InventoryMachineMasterData = null;
//                InventoryMachineMasterData = InventoryMachineMaster.GetInventoryMachineMaster();
//                ajaxRequest.makeRequest("/InventoryMachineMaster/Create", "POST", InventoryMachineMasterData, InventoryMachineMaster.Success);
//            }
//        }
//        else if (InventoryMachineMaster.ActionName == "Edit") {
//            $("#FormEditInventoryMachineMaster").validate();
//            if ($("#FormEditInventoryMachineMaster").valid()) {
//                InventoryMachineMasterData = null;
//                InventoryMachineMasterData = InventoryMachineMaster.GetInventoryMachineMaster();
//                ajaxRequest.makeRequest("/InventoryMachineMaster/Edit", "POST", InventoryMachineMasterData, InventoryMachineMaster.Success);
//            }
//        }
//        else if (InventoryMachineMaster.ActionName == "Delete") {
//            InventoryMachineMasterData = null;
//            //$("#FormCreateInventoryMachineMaster").validate();
//            InventoryMachineMasterData = InventoryMachineMaster.GetInventoryMachineMaster();
//            ajaxRequest.makeRequest("/InventoryMachineMaster/Delete", "POST", InventoryMachineMasterData, InventoryMachineMaster.Success);

//        }
//    },
//    //Get properties data from the Create, Update and Delete page
//    GetInventoryMachineMaster: function () {
//        var Data = {
//        };
//        if (InventoryMachineMaster.ActionName == "Create" || InventoryMachineMaster.ActionName == "Edit") {
//            Data.ID = $('#ID').val();
//            Data.MachineName = $('#MachineName').val();
//            Data.MachineCode = $('#MachineCode').val();
            
//        }
//        else if (InventoryMachineMaster.ActionName == "Delete") {
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
//            InventoryMachineMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
//        } else {
//            parent.$.colorbox.close();
//            InventoryMachineMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
//        }

//    },


//};

/////////////new code///////////////


//this class contain methods related to nationality functionality
var InventoryMachineMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        InventoryMachineMaster.constructor();
        //InventoryMachineMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#MachineName').focus();

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#MachineName').focus();
            return false;
        });


        // Create new record
        $('#CreateInventoryMachineMasterRecord').on("click", function () {

            InventoryMachineMaster.ActionName = "Create";
            InventoryMachineMaster.AjaxCallInventoryMachineMaster();
        });

        $('#EditInventoryMachineMasterRecord').on("click", function () {

            InventoryMachineMaster.ActionName = "Edit";
            InventoryMachineMaster.AjaxCallInventoryMachineMaster();
        });

        $('#DeleteInventoryMachineMasterRecord').on("click", function () {

            InventoryMachineMaster.ActionName = "Delete";
            InventoryMachineMaster.AjaxCallInventoryMachineMaster();
        });


        //$('#counterName').on("keydown", function (e) {
        //    AMSValidation.NotAllowSpaces(e);

        //});
        $('#MachineCode').on("keydown", function (e) {
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
             url: '/InventoryMachineMaster/List',
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
            url: '/InventoryMachineMaster/List',
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


    //Fire ajax call to insert update and delete record
    AjaxCallInventoryMachineMaster: function () {
        var InventoryMachineMasterData = null;
        if (InventoryMachineMaster.ActionName == "Create") {
            $("#FormCreateInventoryMachineMaster").validate();
            if ($("#FormCreateInventoryMachineMaster").valid()) {
                InventoryMachineMasterData = null;
                InventoryMachineMasterData = InventoryMachineMaster.GetInventoryMachineMaster();
                ajaxRequest.makeRequest("/InventoryMachineMaster/Create", "POST", InventoryMachineMasterData, InventoryMachineMaster.Success);
            }
        }
        else if (InventoryMachineMaster.ActionName == "Edit") {
            $("#FormEditInventoryMachineMaster").validate();
            if ($("#FormEditInventoryMachineMaster").valid()) {
                InventoryMachineMasterData = null;
                InventoryMachineMasterData = InventoryMachineMaster.GetInventoryMachineMaster();
                ajaxRequest.makeRequest("/InventoryMachineMaster/Edit", "POST", InventoryMachineMasterData, InventoryMachineMaster.Success);
            }
        }
        else if (InventoryMachineMaster.ActionName == "Delete") {
            InventoryMachineMasterData = null;
            //$("#FormCreateInventoryMachineMaster").validate();
            InventoryMachineMasterData = InventoryMachineMaster.GetInventoryMachineMaster();
            ajaxRequest.makeRequest("/InventoryMachineMaster/Delete", "POST", InventoryMachineMasterData, InventoryMachineMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetInventoryMachineMaster: function () {
        var Data = {
        };
        if (InventoryMachineMaster.ActionName == "Create" || InventoryMachineMaster.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.MachineName = $('#MachineName').val();
            Data.MachineCode = $('#MachineCode').val();

        }
        else if (InventoryMachineMaster.ActionName == "Delete") {
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
            InventoryMachineMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            InventoryMachineMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },


};

