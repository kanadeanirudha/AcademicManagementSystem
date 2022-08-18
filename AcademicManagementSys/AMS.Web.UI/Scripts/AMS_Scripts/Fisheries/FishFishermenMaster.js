
//This class cantain methods for Fish License type funcationality.
var FishFishermenMaster = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        FishFishermenMaster.constructor();
    },

    //Attach all event of page
    constructor: function () {

        $("#reset").click(function () {
            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val('');
            $('input:checkbox,input:radio').removeAttr('checked');
        });

        //Create New Record  
        $('#CreateFishFishermenMasterRecord').on("click", function () {
            FishFishermenMaster.ActionName = "Create";
            FishFishermenMaster.AjaxCallFishFishermenMaster();
        });

        //Edit Existing Record
        $('#EditFishFishermenMasterRecord').on("click", function () {            
            FishFishermenMaster.ActionName = "Edit";
            FishFishermenMaster.AjaxCallFishFishermenMaster();
        });

        //Delete Record
        $('#DeleteFishFishermenMasterRecord').on("click", function () {
            FishFishermenMaster.ActionName = "Delete";
            FishFishermenMaster.AjaxCallFishFishermenMaster();
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

        // Validate Input fields in form
        $('#FirstName').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#MiddleName').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#LastName').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#Gender').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#MobileNumber').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });

        $('#PanNumber').on("keydown", function (e) {
            AMSValidation.AllowAlphaNumericOnly(e);
        });

        $('#AdharCardNumber').on("keydown", function (e) {
            AMSValidation.AllowAlphaNumericOnly(e);
        });

        $('#BankName').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        $('#BankNumber').on("keydown", function (e) {
            AMSValidation.allowNumbersOnly(e);
        });

        $('#NationalityID').on("keydown", function (e) {
            AMSValidation.allowNumbersOnly(e);
        });

        $('#Address').on("keydown", function (e) {
            AMSValidation.AllowAlphaNumericOnly(e);
        });

        $('#PostalAddress').on("keydown", function (e) {
            AMSValidation.AllowAlphaNumericOnly(e);
        });

        $('#BirthDate').on("keydown", function (e) {
            return false;
        });

        $('#JoiningDate').on("keydown", function (e) {
            return false;
        });

        $('#FederationMemberId').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });

       

        //$("#CentreList").change(function () {
        //    $('#myDataTable').html("");
        //    $('#myDataTable_info').text("No entries to show");
        //    $('#myDataTable_paginate').html('<a class="fg-button ui-button ui-state-default first ui-state-disabled" aria-controls="myDataTable" data-dt-idx="0" tabindex="0" id="myDataTable_first">First</a><a class="fg-button ui-button ui-state-default previous ui-state-disabled" aria-controls="myDataTable" data-dt-idx="1" tabindex="0" id="myDataTable_previous">Previous</a><span></span><a class="fg-button ui-button ui-state-default next ui-state-disabled" aria-controls="myDataTable" data-dt-idx="2" tabindex="0" id="myDataTable_next">Next</a><a class="fg-button ui-button ui-state-default last ui-state-disabled" aria-controls="myDataTable" data-dt-idx="3" tabindex="0" id="myDataTable_last">Last</a>');           
        //});

      

        $("#ShowList").click(function () {            
            var SelectedCentreCode = $('#CentreList').val();
            if (SelectedCentreCode != "") {
                $.ajax({
                 cache: false,
                 type: "POST",
                 data: { actionMode: null, centerCode: SelectedCentreCode },
                 dataType: "html",
                 url: '/FishFishermenMaster/List',
                 success: function (result) {
                     //Rebind Grid Data                
                     $('#ListViewModel').html(result);                    
                 }
             });
            }
            else {
                FishFishermenMaster.ReloadList("Please select centre", "#FFCC80", null);                
            }
        });



        //Date Picker for Date of Birth control.
        $('#BirthDate').datepicker({
            //dateFormat: 'd-M-yy',
            //changeMonth: true,
            //changeYear: true,
            //yearRange: 'c-65:c+0',
            
            //maxDate: "0D",
            dateFormat: 'd M yy',
            numberOfMonths: 1
        })

        //Date picker for Joining Date
        $('#JoiningDate').datepicker({
            dateFormat: 'd M yy',
            numberOfMonths: 1
        })

        $('#DateOfLeaving').datepicker({
            dateFormat: 'd M yy',
            numberOfMonths: 1
        })

    },

    //LoadList method is used to load List page
    LoadList: function () {       
        $.ajax({             
             cache: false,
             type: "POST",
             dataType: "html",
             url: '/FishFishermenMaster/List',
             success: function (data) {
                 //Rebind Grid Data
                 $('#ListViewModel').html(data);
             }
         });
    },

    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode) {        
        var ID = $('input[name=ID]').val();
        var CentreCode = $('#CentreCode').val();
        $.ajax(        {
            cache: false,
            type: "POST",
            dataType: "html",
            data: { "actionMode": actionMode, "centerCode": CentreCode },
            url: '/FishFishermenMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                $('#SuccessMessage').html(message);
                $('#SuccessMessage').delay(600).slideDown('slow').delay(1000).slideUp(2000).css('background-color', colorCode);
            }
        });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallFishFishermenMaster: function () {       
        var FishFishermenMasterData = null;
        if (FishFishermenMaster.ActionName == "Create") {
            
            $("#FormCreateFishFishermenMaster").validate();
            if ($("#FormCreateFishFishermenMaster").valid()) {
                FishFishermenMasterData = null;
                FishFishermenMasterData = FishFishermenMaster.GetFishFishermenMaster();
                ajaxRequest.makeRequest("/FishFishermenMaster/Create", "POST", FishFishermenMasterData, FishFishermenMaster.Success);
            }
        }
        else if (FishFishermenMaster.ActionName == "Edit") {
            $("#FormEditFishFishermenMaster").validate();
            if ($("#FormEditFishFishermenMaster").valid()) {
                FishFishermenMasterData = null;
                FishFishermenMasterData = FishFishermenMaster.GetFishFishermenMaster();
                ajaxRequest.makeRequest("/FishFishermenMaster/Edit", "POST", FishFishermenMasterData, FishFishermenMaster.Success);
            }
        }
        else if (FishFishermenMaster.ActionName == "Delete") {
            FishFishermenMasterData = null;
            FishFishermenMasterData = FishFishermenMaster.GetFishFishermenMaster();
            ajaxRequest.makeRequest("/FishFishermenMaster/Delete", "POST", FishFishermenMasterData, FishFishermenMaster.Success);
        }
    },

    //Get properties data from the Create, Update and Delete page
    GetFishFishermenMaster: function () {
        var Data = {
        };
        if (FishFishermenMaster.ActionName == "Create" || FishFishermenMaster.ActionName == "Edit") {

            Data.ID = $('input[name=ID]').val();
            Data.CentreCode = $('input[name=CentreCode]').val();
            Data.NameTitleID = $('#FishermenNameTitle :selected').val();
            Data.FirstName = $('input[name=FirstName]').val();
            Data.MiddleName = $('input[name=MiddleName]').val();
            Data.LastName = $('input[name=LastName]').val();
            //Data.Gender = $('input[name=Gender]').val();
            if ($('#FishermenNameTitle :selected').val() == 1) {
                Data.Gender = 'M';
            }
            else {
                Data.Gender = 'F';
            }

            Data.BirthDate = $('input[name=BirthDate]').val();
            Data.EmailID = $('input[name=EmailID]').val();
            Data.MobileNumber = $('input[name=MobileNumber]').val();
            Data.PanNumber = $('input[name=PanNumber]').val();
            Data.AdharCardNumber = $('input[name=AdharCardNumber]').val();
            Data.BankName = $('input[name=BankName]').val();
            Data.BankNumber = $('input[name=BankNumber]').val();

            Data.JoiningDate = $('input[name=JoiningDate]').val();
            Data.NationalityID = $('#NationalityId :selected').val();
            Data.Address = $('#Address').val();
            Data.PostalAddress = $('#PostalAddress').val();
            Data.IsFederationMember = $('#IsFederationMember').val();
            Data.FederationMemberId = $('input[name=FederationMemberId]').val();            

        }
        else if (FishFishermenMaster.ActionName == "Delete") {
            Data.ID = $('#ID').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        parent.$.colorbox.close();
        FishFishermenMaster.ReloadList(splitData[0], splitData[1], splitData[2], splitData[3]);
    }

};