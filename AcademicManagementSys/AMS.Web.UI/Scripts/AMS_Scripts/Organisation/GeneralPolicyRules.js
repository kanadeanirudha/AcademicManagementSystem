//this class contain methods related to nationality functionality
var GeneralPolicyRules = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        GeneralPolicyRules.constructor();
        //GeneralPolicyMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#PolicyCode').focus();

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');

            $('#PolicyQuestionDescription').focus();
            $('#PolicyAnsType').val("Logical");
            $('#RangeSeparateBy').val(",");


           

        });
         //$("#PolicyName").prop('readonly', true);

        // Create new record
         $('#CreateGeneralPolicyRulesRecord').on("click", function () {
             
            GeneralPolicyRules.ActionName = "Create";
            GeneralPolicyRules.AjaxCallGeneralPolicyRules();
        });

        $('#EditGeneralPolicyRulesRecord').on("click", function () {

            GeneralPolicyRules.ActionName = "Edit";
            GeneralPolicyRules.AjaxCallGeneralPolicyRules();
        });

        $('#DeleteGeneralPolicyRulesRecord').on("click", function () {

            GeneralPolicyRules.ActionName = "Delete";
            GeneralPolicyRules.AjaxCallGeneralPolicyRules();
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

        $(".ajax").colorbox();


    },
    //LoadList method is used to load List page
    LoadList: function () {

        $.ajax(

         {

             cache: false,
             type: "POST",

             dataType: "html",
             url: '/GeneralPolicyRules/List',
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
            url: '/GeneralPolicyRules/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                $('#SuccessMessage').html(message);
                $('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record
    AjaxCallGeneralPolicyRules: function () {
        var GeneralPolicyRulesData = null;
        if (GeneralPolicyRules.ActionName == "Create") {
            $("#FormCreateGeneralPolicyRules").validate();
            if ($("#FormCreateGeneralPolicyRules").valid()) {
                GeneralPolicyRulesData = null;
                GeneralPolicyRulesData = GeneralPolicyRules.GetGeneralPolicyRules();
                ajaxRequest.makeRequest("/GeneralPolicyRules/Create", "POST", GeneralPolicyRulesData, GeneralPolicyRules.Success);
            }
        }
        else if (GeneralPolicyRules.ActionName == "Edit") {
            $("#FormCreateGeneralPolicyRules").validate();
            if ($("#FormCreateGeneralPolicyRules").valid()) {
                GeneralPolicyRulesData = null;
                GeneralPolicyRulesData = GeneralPolicyRules.GetGeneralPolicyRules();
                ajaxRequest.makeRequest("/GeneralPolicyRules/Edit", "POST", GeneralPolicyRulesData, GeneralPolicyRules.Success);
            }
        }
        else if (GeneralPolicyRules.ActionName == "Delete") {
            GeneralPolicyRulesData = null;
            
            GeneralPolicyRulesData = GeneralPolicyRules.GetGeneralPolicyRules();
            ajaxRequest.makeRequest("/GeneralPolicyRules/Delete", "POST", GeneralPolicyRulesData, GeneralPolicyRules.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetGeneralPolicyRules: function () {
        var Data = {
        };
        if (GeneralPolicyRules.ActionName == "Create" || GeneralPolicyRules.ActionName == "Edit") {

            
            Data.ID = $('#GeneralPolicyRulesID').val();
            Data.PolicyMasterID = $('#GeneralPolicyMasterID').val();
            //Data.PolicyMasterCode = $('#PolicyMasterCode').val();
            alert($('input[name=PolicyCode]').val());
            Data.PolicyCode = $('input[name=PolicyCode]').val();
            Data.PolicyQuestionDescription = $('#PolicyQuestionDescription').val();
            Data.PolicyRange = $('#PolicyRange').val();
            Data.PolicyDefaultAnswer = $('#PolicyDefaultAnswer').val();
            Data.PolicyAnsType = $('#PolicyAnsType').val();
            Data.RangeSeparateBy = $('#RangeSeparateBy').val();

            Data.IsPolicyActive = $('#IsPolicyActive:checked').val();
            // Data.IsPolicyActive = $("input[id=IsPolicyActive]:checked").val();
        }
        else if (GeneralPolicyRules.ActionName == "Delete") {
            Data.ID = $('#ID').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        
        var splitData = data.split(',');
        if (data != null) {
            parent.$.colorbox.close();
            GeneralPolicyRules.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            parent.$.colorbox.close();
            GeneralPolicyRules.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },


};

