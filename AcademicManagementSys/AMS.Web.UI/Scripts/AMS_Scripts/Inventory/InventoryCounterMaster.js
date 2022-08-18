////this class contain methods related to nationality functionality
//var InventoryCounterMaster = {
//    //Member variables
//    ActionName: null,
//    //Class intialisation method
//    Initialize: function () {
//        //organisationStudyCentre.loadData();

//        InventoryCounterMaster.constructor();
//        //InventoryCounterMaster.initializeValidation();
//    },
//    //Attach all event of page
//    constructor: function () {
//        $('.YourBackgroundClass').focus();
     
//        $("#reset").click(function () {

//            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
//            $('input:checkbox,input:radio').removeAttr('checked');
//            $("#CounterName").focus();
//            return false;
//        });


//        // Create new record
//        $('#CreateInventoryCounterMasterRecord').on("click", function () {
//            InventoryCounterMaster.ActionName = "Create";
//            InventoryCounterMaster.AjaxCallInventoryCounterMaster();
//        });

//        $('#EditInventoryCounterMasterRecord').on("click", function () {

//            InventoryCounterMaster.ActionName = "Edit";
//            InventoryCounterMaster.AjaxCallInventoryCounterMaster();
//        });

//        $('#DeleteInventoryCounterMasterRecord').on("click", function () {

//            InventoryCounterMaster.ActionName = "Delete";
//            InventoryCounterMaster.AjaxCallInventoryCounterMaster();
//        });


//        //$('#counterName').on("keydown", function (e) {
//        //    AMSValidation.NotAllowSpaces(e);

//        //});
//        $('#CounterCode').on("keydown", function (e) {
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
//             url: '/InventoryCounterMaster/List',
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
//            url: '/InventoryCounterMaster/List',
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
//    AjaxCallInventoryCounterMaster: function () {
//        var InventoryCounterMasterData = null;
//        if (InventoryCounterMaster.ActionName == "Create") {
//            $("#FormCreateInventoryCounterMaster").validate();
//            if ($("#FormCreateInventoryCounterMaster").valid()) {
//                InventoryCounterMasterData = null;
//                InventoryCounterMasterData = InventoryCounterMaster.GetInventoryCounterMaster();
//                ajaxRequest.makeRequest("/InventoryCounterMaster/Create", "POST", InventoryCounterMasterData, InventoryCounterMaster.Success);
//            }
//        }
//        else if (InventoryCounterMaster.ActionName == "Edit") {
//            $("#FormEditInventoryCounterMaster").validate();
//            if ($("#FormEditInventoryCounterMaster").valid()) {
//                InventoryCounterMasterData = null;
//                InventoryCounterMasterData = InventoryCounterMaster.GetInventoryCounterMaster();
//                ajaxRequest.makeRequest("/InventoryCounterMaster/Edit", "POST", InventoryCounterMasterData, InventoryCounterMaster.Success);
//            }
//        }
//        else if (InventoryCounterMaster.ActionName == "Delete") {
//            InventoryCounterMasterData = null;
//            //$("#FormCreateInventoryCounterMaster").validate();
//            InventoryCounterMasterData = InventoryCounterMaster.GetInventoryCounterMaster();
//            ajaxRequest.makeRequest("/InventoryCounterMaster/Delete", "POST", InventoryCounterMasterData, InventoryCounterMaster.Success);

//        }
//    },
//    //Get properties data from the Create, Update and Delete page
//    GetInventoryCounterMaster: function () {
//        var Data = {
//        };
//        if (InventoryCounterMaster.ActionName == "Create" || InventoryCounterMaster.ActionName == "Edit") {
//            Data.ID = $('#ID').val();
//            Data.CounterName = $('#CounterName').val();
//            Data.CounterCode = $('#CounterCode').val();
//            //Data.SeqNo = $('#SeqNo').val();
//            // Data.DefaultFlag = $("input[id=DefaultFlag]:checked").val();
//        }
//        else if (InventoryCounterMaster.ActionName == "Delete") {
//            Data.ID = $('#ID').val();
//        }
//        return Data;
//    },

//    //this is used to for showing successfully record creation message and reload the list view
//    Success: function (data) {
        
//        var splitData = data.split(',');
//        if (data != null) {
//            parent.$.colorbox.close();
//            InventoryCounterMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
//        } else {
//            parent.$.colorbox.close();
//            InventoryCounterMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
//        }

//    },


//};

/////////////////new js/////////////////////


//this class contain methods related to nationality functionality
var InventoryCounterMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        InventoryCounterMaster.constructor();
        //InventoryCounterMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {
        $('.YourBackgroundClass').focus();

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $("#CounterName").focus();
            return false;
        });


        // Create new record
        $('#CreateInventoryCounterMasterRecord').on("click", function () {
            InventoryCounterMaster.ActionName = "Create";
            InventoryCounterMaster.AjaxCallInventoryCounterMaster();
        });

        $('#EditInventoryCounterMasterRecord').on("click", function () {

            InventoryCounterMaster.ActionName = "Edit";
            InventoryCounterMaster.AjaxCallInventoryCounterMaster();
        });

        $('#DeleteInventoryCounterMasterRecord').on("click", function () {

            InventoryCounterMaster.ActionName = "Delete";
            InventoryCounterMaster.AjaxCallInventoryCounterMaster();
        });


        //$('#counterName').on("keydown", function (e) {
        //    AMSValidation.NotAllowSpaces(e);

        //});
        $('#CounterCode').on("keydown", function (e) {
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
             url: '/InventoryCounterMaster/List',
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
            url: '/InventoryCounterMaster/List',
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
    AjaxCallInventoryCounterMaster: function () {
        var InventoryCounterMasterData = null;
        if (InventoryCounterMaster.ActionName == "Create") {
            $("#FormCreateInventoryCounterMaster").validate();
            if ($("#FormCreateInventoryCounterMaster").valid()) {
                InventoryCounterMasterData = null;
                InventoryCounterMasterData = InventoryCounterMaster.GetInventoryCounterMaster();
                ajaxRequest.makeRequest("/InventoryCounterMaster/Create", "POST", InventoryCounterMasterData, InventoryCounterMaster.Success);
            }
        }
        else if (InventoryCounterMaster.ActionName == "Edit") {
            $("#FormEditInventoryCounterMaster").validate();
            if ($("#FormEditInventoryCounterMaster").valid()) {
                InventoryCounterMasterData = null;
                InventoryCounterMasterData = InventoryCounterMaster.GetInventoryCounterMaster();
                ajaxRequest.makeRequest("/InventoryCounterMaster/Edit", "POST", InventoryCounterMasterData, InventoryCounterMaster.Success);
            }
        }
        else if (InventoryCounterMaster.ActionName == "Delete") {
            InventoryCounterMasterData = null;
            //$("#FormCreateInventoryCounterMaster").validate();
            InventoryCounterMasterData = InventoryCounterMaster.GetInventoryCounterMaster();
            ajaxRequest.makeRequest("/InventoryCounterMaster/Delete", "POST", InventoryCounterMasterData, InventoryCounterMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetInventoryCounterMaster: function () {
        var Data = {
        };
        if (InventoryCounterMaster.ActionName == "Create" || InventoryCounterMaster.ActionName == "Edit") {
            Data.ID = $('#ID').val();
            Data.CounterName = $('#CounterName').val();
            Data.CounterCode = $('#CounterCode').val();
            //Data.SeqNo = $('#SeqNo').val();
            // Data.DefaultFlag = $("input[id=DefaultFlag]:checked").val();
        }
        else if (InventoryCounterMaster.ActionName == "Delete") {
            Data.ID = $('#ID').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {

        var splitData = data.split(',');
        if (data != null) {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            InventoryCounterMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            InventoryCounterMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },


};

