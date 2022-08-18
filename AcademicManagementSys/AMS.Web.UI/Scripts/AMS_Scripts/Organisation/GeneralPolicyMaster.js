////this class contain methods related to nationality functionality
//var GeneralPolicyMaster = {
//    //Member variables
//    ActionName: null,
//    //Class intialisation method
//    Initialize: function () {
//        //organisationStudyCentre.loadData();

//        GeneralPolicyMaster.constructor();
//        //GeneralPolicyMaster.initializeValidation();
//    },
//    //Attach all event of page
//    constructor: function () {

//        $('#PolicyCode').focus();

//        $("#reset").click(function () {

//            $("input,textarea").not(':reset, :submit, :hidden, :button,:checkbox,:radio').val("");
//            $('input:radio').removeAttr('checked');

//            $('#PolicyName').focus();
//            $('#PolicyRelatedToModuleCode').focusin();
//            $('#PolicyCode').val("");
//            $('#PolicyName').val("");
//            $('#PolicyDescription').val("");
//            $('#PolicyRelatedToModuleCode').val("");
//            $('#PolicyApplicableStatus').val("General");
//            $('#IsPolicyActive').removeAttr('checked');
//            $('#PolicyAnsType').val("Logical");
//            $('#RangeSeparateBy').val(",");
//            //$('input[name="IsActive"]').removeAttr('checked');
//            return false;
           
//        });


//        // Create new record
//        $('#CreateGeneralPolicyMasterRecord').on("click", function () {
//            GeneralPolicyMaster.ActionName = "Create";
//            GeneralPolicyMaster.AjaxCallGeneralPolicyMaster();
//        });

//        $('#EditGeneralPolicyMasterRecord').on("click", function () {

//            GeneralPolicyMaster.ActionName = "Edit";
//            GeneralPolicyMaster.AjaxCallGeneralPolicyMaster();
//        });

//        $('#DeleteGeneralPolicyMasterRecord').on("click", function () {

//            GeneralPolicyMaster.ActionName = "Delete";
//            GeneralPolicyMaster.AjaxCallGeneralPolicyMaster();
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
//             url: '/GeneralPolicyMaster/List',
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
//            url: '/GeneralPolicyMaster/List',
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
//    AjaxCallGeneralPolicyMaster: function () {
//        var GeneralPolicyMasterData = null;
//        if (GeneralPolicyMaster.ActionName == "Create") {
//            $("#FormCreateGeneralPolicyMaster").validate();
//            if ($("#FormCreateGeneralPolicyMaster").valid()) {
//                GeneralPolicyMasterData = null;
//                GeneralPolicyMasterData = GeneralPolicyMaster.GetGeneralPolicyMaster();
//                ajaxRequest.makeRequest("/GeneralPolicyMaster/Create", "POST", GeneralPolicyMasterData, GeneralPolicyMaster.Success);
//            }
//        }
//        else if (GeneralPolicyMaster.ActionName == "Edit") {
//            $("#FormEditGeneralPolicyMaster").validate();
//            if ($("#FormEditGeneralPolicyMaster").valid()) {
//                GeneralPolicyMasterData = null;
//                GeneralPolicyMasterData = GeneralPolicyMaster.GetGeneralPolicyMaster();
//                ajaxRequest.makeRequest("/GeneralPolicyMaster/Edit", "POST", GeneralPolicyMasterData, GeneralPolicyMaster.Success);
//            }
//        }
//        else if (GeneralPolicyMaster.ActionName == "Delete") {
//            GeneralPolicyMasterData = null;
//            //$("#FormCreateGeneralPolicyMaster").validate();
//            GeneralPolicyMasterData = GeneralPolicyMaster.GetGeneralPolicyMaster();
//            ajaxRequest.makeRequest("/GeneralPolicyMaster/Delete", "POST", GeneralPolicyMasterData, GeneralPolicyMaster.Success);

//        }
//    },
//    //Get properties data from the Create, Update and Delete page
//    GetGeneralPolicyMaster: function () {
//        var Data = {
//        };
//        if (GeneralPolicyMaster.ActionName == "Create" || GeneralPolicyMaster.ActionName == "Edit") {

            
//            Data.ID = $('#ID').val();
//            Data.PolicyCode = $('#PolicyCode').val();
//            Data.PolicyName = $('#PolicyName').val();
//            Data.PolicyDescription = $('#PolicyDescription').val();
//            Data.PolicyRelatedToModuleCode = $('#PolicyRelatedToModuleCode').val();
//            Data.PolicyApplicableStatus = $('#PolicyApplicableStatus').val();
//            Data.IsPolicyActive = $('#IsPolicyActive:checked').val();
//            // Data.IsPolicyActive = $("input[id=IsPolicyActive]:checked").val();
//            //Feilds From GeneralpolicyRule Table
//            Data.PolicyRange = $('#PolicyRange').val();
//            Data.PolicyDefaultAnswer = $('#PolicyDefaultAnswer').val();
//            Data.PolicyAnsType = $('#PolicyAnsType').val();
//            Data.RangeSeparateBy = $('#RangeSeparateBy').val();

//        }
//        else if (GeneralPolicyMaster.ActionName == "Delete") {
//            Data.ID = $('#ID').val();
//        }
//        return Data;
//    },

//    //this is used to for showing successfully record creation message and reload the list view
//    Success: function (data) {
        
//        var splitData = data.split(',');
//        if (data != null) {
//            parent.$.colorbox.close();
//            GeneralPolicyMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
//        } else {
//            parent.$.colorbox.close();
//            GeneralPolicyMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
//        }

//    },


//};

////////////////////////////new js//////////////////////

//this class contain methods related to nationality functionality
var GeneralPolicyMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        GeneralPolicyMaster.constructor();
        //GeneralPolicyMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#PolicyCode').focus();

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button,:checkbox,:radio').val("");
            $('input:radio').removeAttr('checked');

            $('#PolicyName').focus();
            $('#PolicyRelatedToModuleCode').focusin();
            $('#PolicyCode').val("");
            $('#PolicyName').val("");
            $('#PolicyDescription').val("");
            $('#PolicyRelatedToModuleCode').val("");
            $('#PolicyApplicableStatus').val("General");
            $('#IsPolicyActive').removeAttr('checked');
            $('#PolicyAnsType').val("Logical");
            $('#RangeSeparateBy').val(",");
            //$('input[name="IsActive"]').removeAttr('checked');
            return false;

        });


        // Create new record
        $('#CreateGeneralPolicyMasterRecord').on("click", function () {
            GeneralPolicyMaster.ActionName = "Create";
            GeneralPolicyMaster.AjaxCallGeneralPolicyMaster();
        });

        $('#EditGeneralPolicyMasterRecord').on("click", function () {

            GeneralPolicyMaster.ActionName = "Edit";
            GeneralPolicyMaster.AjaxCallGeneralPolicyMaster();
        });

        $('#DeleteGeneralPolicyMasterRecord').on("click", function () {

            GeneralPolicyMaster.ActionName = "Delete";
            GeneralPolicyMaster.AjaxCallGeneralPolicyMaster();
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
             url: '/GeneralPolicyMaster/List',
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
            url: '/GeneralPolicyMaster/List',
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
    AjaxCallGeneralPolicyMaster: function () {
        var GeneralPolicyMasterData = null;
        if (GeneralPolicyMaster.ActionName == "Create") {
            $("#FormCreateGeneralPolicyMaster").validate();
            if ($("#FormCreateGeneralPolicyMaster").valid()) {
                GeneralPolicyMasterData = null;
                GeneralPolicyMasterData = GeneralPolicyMaster.GetGeneralPolicyMaster();
                ajaxRequest.makeRequest("/GeneralPolicyMaster/Create", "POST", GeneralPolicyMasterData, GeneralPolicyMaster.Success);
            }
        }
        else if (GeneralPolicyMaster.ActionName == "Edit") {
            $("#FormEditGeneralPolicyMaster").validate();
            if ($("#FormEditGeneralPolicyMaster").valid()) {
                GeneralPolicyMasterData = null;
                GeneralPolicyMasterData = GeneralPolicyMaster.GetGeneralPolicyMaster();
                ajaxRequest.makeRequest("/GeneralPolicyMaster/Edit", "POST", GeneralPolicyMasterData, GeneralPolicyMaster.Success);
            }
        }
        else if (GeneralPolicyMaster.ActionName == "Delete") {
            GeneralPolicyMasterData = null;
            //$("#FormCreateGeneralPolicyMaster").validate();
            GeneralPolicyMasterData = GeneralPolicyMaster.GetGeneralPolicyMaster();
            ajaxRequest.makeRequest("/GeneralPolicyMaster/Delete", "POST", GeneralPolicyMasterData, GeneralPolicyMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetGeneralPolicyMaster: function () {
        var Data = {
        };
        if (GeneralPolicyMaster.ActionName == "Create" || GeneralPolicyMaster.ActionName == "Edit") {


            Data.ID = $('#ID').val();
            Data.PolicyCode = $('#PolicyCode').val();
            Data.PolicyName = $('#PolicyName').val();
            Data.PolicyDescription = $('#PolicyDescription').val();
            Data.PolicyRelatedToModuleCode = $('#PolicyRelatedToModuleCode').val();
            Data.PolicyApplicableStatus = $('#PolicyApplicableStatus').val();
            //Data.IsPolicyActive = $('#IsPolicyActive:checked').val();
            Data.IsPolicyActive = $('#IsPolicyActive:checked').val() ? true : false;
            // Data.IsPolicyActive = $("input[id=IsPolicyActive]:checked").val();
            //Feilds From GeneralpolicyRule Table
            Data.PolicyRange = $('#PolicyRange').val();
            Data.PolicyDefaultAnswer = $('#PolicyDefaultAnswer').val();
            Data.PolicyAnsType = $('#PolicyAnsType').val();
            Data.RangeSeparateBy = $('#RangeSeparateBy').val();

        }
        else if (GeneralPolicyMaster.ActionName == "Delete") {
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
            GeneralPolicyMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            GeneralPolicyMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },


};

