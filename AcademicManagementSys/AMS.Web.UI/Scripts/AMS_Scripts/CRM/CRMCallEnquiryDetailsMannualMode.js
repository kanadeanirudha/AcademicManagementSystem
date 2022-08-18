//this class contain methods related to nationality functionality
var CRMCallEnquiryDetailsMannualMode = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        CRMCallEnquiryDetailsMannualMode.constructor();
        //CRMCallEnquiryDetailsMannualMode.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#GroupDescription').focus();
        $("#CreateCRMCallEnquiryDetails").hide();
        $("#ResetCRMCallEnquiryDetails").hide();

        $("#ResetCRMCallEnquiryDetails").click(function () {

            //$("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            //$('input:checkbox,input:radio').removeAttr('checked');
            $('#StudentFirstName').val("");
            $('#StudentMiddelName').val(""); 
            $('#StudentLastName').val("");
            $('#StudentMobileNo').val("");
            $('#StudentEmailID').val("");
            $('#selectedSource').val("");
            $('#SourceContactPerson').val("");
            $("#tblData tbody tr").remove();
           
            return false;
        });
        // Create new record

        $('#CreateCRMCallEnquiryDetails').on("click", function () {
          
            CRMCallEnquiryDetailsMannualMode.ActionName = "Create";
            CRMCallEnquiryDetailsMannualMode.GetXmlData();
            CRMCallEnquiryDetailsMannualMode.AjaxCallCRMCallEnquiryDetails();
            $("#tblData tbody tr").remove();
        });

        $('#EditCRMCallEnquiryDetailRecord').on("click", function () {

            CRMCallEnquiryDetailsMannualMode.ActionName = "Edit";
            CRMCallEnquiryDetailsMannualMode.AjaxCallCRMCallEnquiryDetail();
        });

        $('#DeleteCRMCallEnquiryDetailRecord').on("click", function () {

            CRMCallEnquiryDetailsMannualMode.ActionName = "Delete";
            CRMCallEnquiryDetailsMannualMode.AjaxCallCRMCallEnquiryDetail();
        });
        $('#StudentMobileNo').on("keydown", function (e) {
            AMSValidation.AllowNumbersOnly(e);
            AMSValidation.NotAllowSpaces(e);
        });
        $('#SourceContactPerson').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
            AMSValidation.NotAllowSpaces(e);
        });
        $('#StudentFirstName').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
            AMSValidation.NotAllowSpaces(e);
        });

        $('#StudentMiddelName').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
            AMSValidation.NotAllowSpaces(e);
        });

        $('#StudentLastName').on("keydown", function (e) {
            AMSValidation.AllowCharacterOnly(e);
            AMSValidation.NotAllowSpaces(e);
        });
        $('#btnAdd').on("click", function () {
            $("#CreateCRMCallEnquiryDetails").show();
            $("#ResetCRMCallEnquiryDetails").show();
            debugger;
            var DataArray = [];
           
            var data = $('#tblData tbody tr input[type="text"],select[id="selectedSource"]').each(function () {
               
                DataArray.push($(this).val());
            });
         
            TotalRecord = DataArray.length;
            ParameterXml = "<rows>";
            for (var i = 0; i < TotalRecord; i = i + 7) {
                if ((DataArray[i+3] == ($('#StudentMobileNo').val()))) {
                    notify(" Student MobileNo Already Enter.", "danger");
                    return false
                }
            }
            var selectedSource = $("#Source").val();
            var SelectedLaimoon = "";
            var SelectedSocialMedia = "";
            var SelectedWebsite = "";
            var SelectedEvent = "";
            
            if (selectedSource == 'Laimoon') {
                SelectedLaimoon = 'selected';
            }
            else if (selectedSource == 'Social Media') {
                SelectedSocialMedia = 'selected';
            }
            else if (selectedSource == 'Website') {
                SelectedWebsite = 'selected';
            }
            else if (selectedSource == 'Event') {
                SelectedEvent = 'selected';
            }
          
           
      
             //if ($("#StudentEmailID").val() != null || $("#StudentEmailID").val() != ""){
             //   function ValidateEmail(email) {

             //       var expr = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
             //       return expr.test(email);
             //   };

                //if (!ValidateEmail($("#StudentEmailID").val())) {

                //    notify("Please Check EmailID.", "danger");
                //    return false;
                //}
                //else { var a=0}

            //}
            //if ($("#StudentFirstName").val() == null || $("#StudentFirstName").val() == "") {
            //    notify("Please Enter Student First Name.", "danger");
           
            //}
            //else if ($("#StudentMiddelName").val() == null || $("#StudentMiddelName").val() == "") {
            //    notify("Please Enter Student Middel Name.", "danger");
            //}

            //else if ($("#StudentLastName").val() == null || $("#StudentLastName").val() == "") {
            //    notify("Please Enter Student Last Name.", "danger");

            //}
            if ($("#StudentMobileNo").val() == null || $("#StudentMobileNo").val() == "" ) {
                notify("Please Enter Student MobileNo.", "danger");
            }
            else if ($("#StudentMobileNo").val().length <= 4){
                notify("Please enter mobile number containing at least 4 digits.", "danger");
            }
            //else if ($("#StudentEmailID").val() == null || $("#StudentEmailID").val() == "") {
            //    notify("Please Enter Student EmailID.", "danger");
            //}
            //else if ($("#Source").val() == null || $("#Source").val() == "") {
            //    notify("Please Enter Source.", "danger");
            //}
            //else if ($("#SourceContactPerson").val() == null || $("#SourceContactPerson").val() == "") {
            //    notify("Please Enter Source Contact Person.", "danger");
            //}
           
             else {
                 $("#tblData tbody").append(

                                     "<tr>" +
                                      "<td><div class='form-group fg-line'><input id='StudentFirstName' class='form-control'  type='text'  value='" + $('#StudentFirstName').val() + "' style=' '/ ></div></td>" +
                                      "<td><div class='form-group fg-line'><input id='StudentMiddelName' class='form-control'  type='text' value='" + $('#StudentMiddelName').val() + "' style=' '/></div></td>" +
                                      "<td><div class='form-group fg-line'><input id='StudentLastName' class='form-control'  type='text' value='" + $('#StudentLastName').val() + "' style=' '/></div></td>" +
                                      "<td><div class='form-group fg-line'><input id='StudentMobileNo' class='form-control'  type='text' value='" + $('#StudentMobileNo').val() + "' style=' '/></div></td>" +
                                      "<td><div class='form-group fg-line'><input id='StudentEmailID' class='form-control'  type='text' value='" + $('#StudentEmailID').val() + "' style=' '/></div></td>" +
                                      "<td><div class='form-group fg-line'><select name='selectedSource' id='selectedSource' class='form-control input-sm valid'><option value='' ></option><option value='Laimoon' " + SelectedLaimoon + " >Laimoon</option><option value='Social Media' " + SelectedSocialMedia + ">Social Media</option><option value='Website' " + SelectedWebsite + ">Website</option><option value='Event' " + SelectedEvent + ">Event</option></select></div></td>" +
                                      "<td><div class='form-group fg-line'><input id='SourceContactPerson' class='form-control'  type='text' value='" + $('#SourceContactPerson').val() + "' style=''/></div></td>" +
                                      "<td> <i class='zmdi zmdi-delete zmdi-hc-fw' style='cursor:pointer'' title = Delete></td>" +
                                      "</tr>"
                                    );

                $("#StudentFirstName").val("");
                $("#StudentMiddelName").val("");
                $("#StudentLastName").val("");
                $("#StudentMobileNo").val("");
                $("#StudentEmailID").val("");
                $("#Source").val("");
                $("#SourceContactPerson").val("");
            }
            //Delete record in table
            $("#tblData tbody").on("click", "tr td i", function () {
                $(this).closest('tr').remove();
            });

        });

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
             url: '/CRMCallEnquiryDetailsMannualMode/List',
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
            data: { actionMode: actionMode },
            url: '/CRMCallEnquiryDetailsMannualMode/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },

    GetXmlData: function () {

        var DataArray = [];
        //CRMCallEnquiryDetailsMannualMode.flag = true;
        var data = $('#tblData tbody tr input[type="text"],select[id="selectedSource"]').each(function () {
            //alert($(this).val());
            DataArray.push($(this).val());
        });
        //alert(DataArray);
        var TotalRecord = DataArray.length;
        //
        var ParameterXml = "<rows>";
        for (var i = 0; i < TotalRecord; i = i + 7) {
            ParameterXml = ParameterXml + "<row><ID>" + 0 + "</ID><CalleeFirstName>" + DataArray[i] + "</CalleeFirstName><CalleeMiddelName>" + (DataArray[i + 1]) + "</CalleeMiddelName><CalleeLastName>" + (DataArray[i + 2]) + "</CalleeLastName><CalleeMobileNo>" + (DataArray[i + 3]) + "</CalleeMobileNo><CalleeEmailID>" + (DataArray[i + 4]) + "</CalleeEmailID><Source>" + (DataArray[i + 5]) + "</Source><SourceContactPerson>" + (DataArray[i + 6]) + "</SourceContactPerson></row>";
        }
        //alert(ParameterXml);
        if (ParameterXml.length > 12)
            CRMCallEnquiryDetailsMannualMode.ParameterXml = ParameterXml + "</rows>";

        else
            CRMCallEnquiryDetailsMannualMode.ParameterXml = "";

    
       
    },

    //Fire ajax call to insert update and delete recordss

    AjaxCallCRMCallEnquiryDetails: function () {
        var CRMCallEnquiryDetailsData = null;
       
        if (CRMCallEnquiryDetailsMannualMode.ActionName == "Create") {
           
            $("#FormCRMCallEnquiryDetailsMannualMode").validate();
           // if ($("#FormCRMCallEnquiryDetailsMannualMode").valid()) {
               
                CRMCallEnquiryDetailData = null;
                CRMCallEnquiryDetailData = CRMCallEnquiryDetailsMannualMode.GetCRMCallEnquiryDetails();
                ajaxRequest.makeRequest("/CRMCallEnquiryDetailsMannualMode/Create", "POST", CRMCallEnquiryDetailData, CRMCallEnquiryDetailsMannualMode.Success, "CreateCRMCallEnquiryDetailRecord");
            //}
        }
        else if (CRMCallEnquiryDetailsMannualMode.ActionName == "Edit") {
            $("#FormCRMCallEnquiryDetailsMannualMode").validate();
            if ($("#FormCRMCallEnquiryDetailsMannualMode").valid()) {
                CRMCallEnquiryDetailsData = null;
                CRMCallEnquiryDetailsData = CRMCallEnquiryDetailsMannualMode.GetCRMCallEnquiryDetails();
                ajaxRequest.makeRequest("/CRMCallEnquiryDetailsMannualMode/Edit", "POST", CRMCallEnquiryDetailsData, CRMCallEnquiryDetailsMannualMode.Success);
            }
        }
        else if (CRMCallEnquiryDetailsMannualMode.ActionName == "Delete") {
          
            CRMCallEnquiryDetailsData = null;
            $("#FormCRMCallEnquiryDetailsMannualMode").validate();
            CRMCallEnquiryDetailsData = CRMCallEnquiryDetailsMannualMode.GetCRMCallEnquiryDetails();
            ajaxRequest.makeRequest("/CRMCallEnquiryDetailsMannualMode/Delete", "POST", BCRMCallEnquiryDetailsData, CRMCallEnquiryDetailsMannualMode.Success);

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetCRMCallEnquiryDetails: function () {
        var Data = {
        };

        if (CRMCallEnquiryDetailsMannualMode.ActionName == "Create" || CRMCallEnquiryDetailsMannualMode.ActionName == "Edit") {

            Data.ID = $('#ID').val();
          
            Data.XMLstring = CRMCallEnquiryDetailsMannualMode.ParameterXml;
            Data.CallTypeID = $('#CallTypeDescription').val();
        }
        else if (CRMCallEnquiryDetailsMannualMode.ActionName == "Delete") {

            
            // Data.ID = $('input[name=ID]').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            CRMCallEnquiryDetailsMannualMode.ReloadList(splitData[0], splitData[1], splitData[2]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }
    },

};



