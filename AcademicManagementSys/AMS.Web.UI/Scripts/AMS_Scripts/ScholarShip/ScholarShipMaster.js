//this class contain methods related to nationality functionality
var ScholarShipMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        ScholarShipMaster.constructor();
        //ScholarShipMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $("#divSlabDetails").hide();

        $("#ScholarShipType").on("change", function () {
            if ($(this).val() == "2") {
                $("select[id='ScholarShipImplementType']").val("2");
                $("select[id='ScholarShipImplementType']").attr("disabled", true);
            }
            else {
                $("select[id='ScholarShipImplementType']").val("");
                $("select[id='ScholarShipImplementType']").attr("disabled", false);
            }
            if ($(this).val() != "" && $("#ScholarShipImplementType").val() != "") {
                if ($(this).val() == "1" && $("#ScholarShipImplementType").val() == "1") {
                    $("#FeeAccountTypeMasterIDForStudentReceivable").val("1");
                    $("#FeeAccountTypeMasterID").val("2");

                    var showDataForStudentRec = String($("#FeeAccountTypeMasterIDForStudentReceivable :selected").text()).split('~')[1];
                    var showData = String($("#FeeAccountTypeMasterID :selected").text()).split('~')[1];

                    $("#lblStudentReceivable").text(showDataForStudentRec);
                    $("#lblFeeSubTypeAccount").text(showData);
                }
                if ($(this).val() == "1" && $("#ScholarShipImplementType").val() == "2") {
                    $("#FeeAccountTypeMasterIDForStudentReceivable").val("1");
                    $("#FeeAccountTypeMasterID").val("4");

                    var showDataForStudentRec = String($("#FeeAccountTypeMasterIDForStudentReceivable :selected").text()).split('~')[1];
                    var showData = String($("#FeeAccountTypeMasterID :selected").text()).split('~')[1];

                    $("#lblStudentReceivable").text(showDataForStudentRec);
                    $("#lblFeeSubTypeAccount").text(showData);
                }
                if ($(this).val() == "2" && $("#ScholarShipImplementType").val() == "2") {
                    $("#FeeAccountTypeMasterIDForStudentReceivable").val("1");
                    $("#FeeAccountTypeMasterID").val("3");

                    var showDataForStudentRec = String($("#FeeAccountTypeMasterIDForStudentReceivable :selected").text()).split('~')[1];
                    var showData = String($("#FeeAccountTypeMasterID :selected").text()).split('~')[1];

                    $("#lblStudentReceivable").text(showDataForStudentRec);
                    $("#lblFeeSubTypeAccount").text(showData);
                }
                $("#divSlabDetails").show();
            }
            else {
                $("#divSlabDetails").hide();
            }
        });

        $("#ScholarShipImplementType").on("change", function () {
            if ($(this).val() != "" && $("#ScholarShipType").val() != "") {
                if ($(this).val() == "1" && $("#ScholarShipType").val() == "1") {
                    $("#FeeAccountTypeMasterIDForStudentReceivable").val("1");
                    $("#FeeAccountTypeMasterID").val("2");

                    var showDataForStudentRec = String($("#FeeAccountTypeMasterIDForStudentReceivable :selected").text()).split('~')[1];
                    var showData = String($("#FeeAccountTypeMasterID :selected").text()).split('~')[1];

                    $("#lblStudentReceivable").text(showDataForStudentRec);
                    $("#lblFeeSubTypeAccount").text(showData);
                }
                if ($(this).val() == "2" && $("#ScholarShipType").val() == "1") {
                    $("#FeeAccountTypeMasterIDForStudentReceivable").val("1");
                    $("#FeeAccountTypeMasterID").val("4");

                    var showDataForStudentRec = String($("#FeeAccountTypeMasterIDForStudentReceivable :selected").text()).split('~')[1];
                    var showData = String($("#FeeAccountTypeMasterID :selected").text()).split('~')[1];

                    $("#lblStudentReceivable").text(showDataForStudentRec);
                    $("#lblFeeSubTypeAccount").text(showData);
                }
                if ($(this).val() == "2" && $("#ScholarShipType").val() == "2") {
                    $("#FeeAccountTypeMasterIDForStudentReceivable").val("1");
                    $("#FeeAccountTypeMasterID").val("3");

                    var showDataForStudentRec = String($("#FeeAccountTypeMasterIDForStudentReceivable :selected").text()).split('~')[1];
                    var showData = String($("#FeeAccountTypeMasterID :selected").text()).split('~')[1];

                    $("#lblStudentReceivable").text(showDataForStudentRec);
                    $("#lblFeeSubTypeAccount").text(showData);
                }
                $("#divSlabDetails").show();
            }
            else {
                $("#divSlabDetails").hide();
            }
        }); 

        $("#IsCalulatedAmountFix").on("click", function () {
            if ($(this).is(':checked')) {
                $("#Percentage").attr("disabled", true);
                $("#Percentage").val(0);
                $("#FixAmount").attr("disabled", false);
                $('#Percentage').rules('remove');
                $('#FixAmount').rules('remove', 'required');
            }
            else {
                $("#FixAmount").attr("disabled", true);
                $("#FixAmount").val(0);
                $("#Percentage").attr("disabled", false);
                $('#FixAmount').rules('remove');
                $('#Percentage').rules('remove', 'required');
            }

        });
        // Create new record
        $('#CreateScholarShipMasterRecord').on("click", function () {
            ScholarShipMaster.ActionName = "Create";
            ScholarShipMaster.AjaxCallScholarShipMaster();
        });

        $('#CountryName').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#ContryCode').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
            if (e.keyCode == 32) {
                return false;
            }
        });
        InitAnimatedBorder();
        CloseAlert();


     
      
        

    },
    //LoadList method is used to load List page
    LoadList: function () {
        $.ajax({
            cache: false,
            type: "POST",
            dataType: "html",
            url: '/ScholarShipMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $('#ListViewModel').html(data);
            }
        });
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {
        $.ajax({
            cache: false,
            type: "POST",
            dataType: "html",
            data: { "actionMode": actionMode },
            url: '/ScholarShipMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallScholarShipMaster: function () {
        var ScholarShipMasterData = null;
        if (ScholarShipMaster.ActionName == "Create") {
            
            $("#FormCreateScholarShipMaster").validate();
            if ($("#FormCreateScholarShipMaster").valid()) {
                ScholarShipMasterData = null;
                ScholarShipMasterData = ScholarShipMaster.GetScholarShipMaster();
                ajaxRequest.makeRequest("/ScholarShipMaster/Create", "POST", ScholarShipMasterData, ScholarShipMaster.Success, "CreateScholarShipMasterRecord");
            }
        }
        else if (ScholarShipMaster.ActionName == "Edit") {
            $("#FormEditScholarShipMaster").validate();
            if ($("#FormEditScholarShipMaster").valid()) {
                ScholarShipMasterData = null;
                ScholarShipMasterData = ScholarShipMaster.GetScholarShipMaster();
                ajaxRequest.makeRequest("/ScholarShipMaster/Edit", "POST", ScholarShipMasterData, ScholarShipMaster.Success);
            }
        }
        else if (ScholarShipMaster.ActionName == "Delete") {
            ScholarShipMasterData = null;
            //$("#FormCreateScholarShipMaster").validate();
            ScholarShipMasterData = ScholarShipMaster.GetScholarShipMaster();
            ajaxRequest.makeRequest("/ScholarShipMaster/Delete", "POST", ScholarShipMasterData, ScholarShipMaster.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetScholarShipMaster: function () {
        var Data = {
        };
        if (ScholarShipMaster.ActionName == "Create" || ScholarShipMaster.ActionName == "Edit") {

            Data.ScholarShipDescription = $('#ScholarShipDescription').val();
            Data.ScholarShipType = $('#ScholarShipType :selected').val();
            Data.ScholarShipImplementType = $('#ScholarShipImplementType :selected').val();
            Data.IsCalulatedAmountFix = $("#IsCalulatedAmountFix").is(':checked');
            if (Data.IsCalulatedAmountFix == true) {
                Data.FixAmount = $('#FixAmount').val();
            }
            else {
                Data.Percentage = $('#Percentage').val();
            }
            Data.FeeAccountTypeMasterIDForStudentReceivable =String($('#FeeAccountTypeMasterIDForStudentReceivable :selected').text()).split('~')[0];
            Data.FeeAccountSubTypeDescForStudentReceivable = $('#FeeAccountSubTypeDescForStudentReceivable').val();
            Data.FeeAccountSubTypeCodeForStudentReceivable = $('#FeeAccountSubTypeCodeForStudentReceivable').val();
            Data.AccountIDForStudentReceivable = $('#AccountIDForStudentReceivable :selected').val();
            Data.FeeAccountTypeMasterID = String($('#FeeAccountTypeMasterID :selected').text()).split('~')[0];
            Data.FeeAccountSubTypeDesc = $('#FeeAccountSubTypeDesc').val();
            Data.FeeAccountSubTypeCode = $('#FeeAccountSubTypeCode').val();
            Data.AccountID = $('#AccountID :selected').val();
        }
        else if (ScholarShipMaster.ActionName == "Delete") {
            Data.ID = $('#ID').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            ScholarShipMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }

    },
 
};

