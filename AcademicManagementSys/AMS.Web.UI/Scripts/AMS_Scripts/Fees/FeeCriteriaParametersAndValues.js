//this class contain methods related to nationality functionality
var FeeCriteriaParametersAndValues = {
    //Member variables
    ActionName: null,
    FeeCriteriaValueXML: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        FeeCriteriaParametersAndValues.constructor();
        //generalCountryMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#FeeCriteriaParametersDescription').focus();
        $('#FeeCriteriaParameterValue').focus();
       
        $("#reset").click(function () {
            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#FeeCriteriaParametersDescription').val("");
            $('#FeeCriteriaParameterValue').focus();
           
            return false;
        });


        

        // Create Fee Criteria Parameter new record
        $('#CreateFeeCriteriaParameterRecord').on("click", function () {
            FeeCriteriaParametersAndValues.ActionName = "CreateParameter";
            FeeCriteriaParametersAndValues.AjaxCallFeeCriteriaParametersAndValues();
        });
        // Delete Fee Criteria Parameter new record
        $('#DeleteFeeCriteriaParameterRecord').on("click", function () {

            FeeCriteriaParametersAndValues.ActionName = "DeleteParameter";
            FeeCriteriaParametersAndValues.AjaxCallFeeCriteriaParametersAndValues();
        });
        // Create Fee Criteria Parameter Value new record
        $('#CreateFeeCriteriaParameterValueRecord').on("click", function () {
          
            FeeCriteriaParametersAndValues.ActionName = "CreateValue";
            FeeCriteriaParametersAndValues.GetParameterValueXML();
            if (FeeCriteriaParametersAndValues.FeeCriteriaValueXML != "" && FeeCriteriaParametersAndValues.FeeCriteriaValueXML != null) {
                FeeCriteriaParametersAndValues.AjaxCallFeeCriteriaParametersAndValues();
            }
            else {
                $('#update-message').html("No record selected");
                $('#update-message').delay(400).slideDown(400).delay(2000).slideUp(400).css('background-color', "#FFCC80");
            }
        });
        // Delete Fee Criteria Parameter new Value record
        $('#DeleteFeeCriteriaParameterValueRecord').on("click", function () {            
            FeeCriteriaParametersAndValues.ActionName = "DeleteValue";
            FeeCriteriaParametersAndValues.AjaxCallFeeCriteriaParametersAndValues();
        });


        $('#FeeCriteriaParametersCode').on("keydown", function (e) {
            AMSValidation.NotAllowSpaces(e);
        });

        $('#FeeCriteriaParameterValue').on("keydown", function (e) {
            AMSValidation.NotAllowSpaces(e);
        });

        InitAnimatedBorder();
        CloseAlert();

         //Set Al Check box checked.
        $('#selectAllParmeterValueID').change(function () {
            if (this.checked) {
                $('.abc1').prop('checked', true);                
            }
            else {
                $('.abc1').prop('checked', false);               
            }

        });
    },
    //LoadList method is used to load List page
  
    LoadList: function () {
        var Balancesheet = $("#selectedBalsheetID").val();
        if (Balancesheet != null && Balancesheet != "NaN" && Balancesheet != "") {
            $.ajax({
                   cache: false,
                   type: "POST",
                   dataType: "html",
                   url: '/FeeCriteriaParametersAndValues/List',
                   success: function (data) {
                       //Rebind Grid Data
                       $('#ListViewModel').html(data);
                   }
               });
        }
        else {
            notify("Please select balancesheet.", "danger");
            return false;
        }
    },
    //ReloadList method is used to load List page
    ReloadList: function (message, colorCode, actionMode, feeCriteriaParameterOrValue) {

        $.ajax({
            cache: false,
            type: "POST",
            dataType: "html",
            data: { "actionMode": actionMode, "feeCriteriaParameterOrValue": feeCriteriaParameterOrValue },
            url: '/FeeCriteriaParametersAndValues/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },

    //Generate XML;
    GetParameterValueXML: function () {
        debugger;
        
         var DataArray = [];
        //Get Checkbox checked or not.
        $('#tblFeeCriteriaParametersValues input[type=checkbox]').each(function () {
            if (this.checked == true) {
                DataArray.push($(this).val());
            }
        }); 
        var TotalRecord = DataArray.length;       
        var ParameterValueXML = "<rows>";
       
        for (var i = 0; i < TotalRecord; i++)            
        {
            var item = DataArray[i];
            if (DataArray[i].split('~')[0] != "" && DataArray[i].split('~')[1] != "" && DataArray[i] != "on") {
                ParameterValueXML = ParameterValueXML + "<row><ID>0</ID><FeeCriteriaParameterKeyValue>" + DataArray[i].split('~')[0] + "</FeeCriteriaParameterKeyValue>" +
                                                         "<FeeCriteriaParameterValue>" + DataArray[i].split('~')[1] + "</FeeCriteriaParameterValue></row>";
            }
        }
        if(ParameterValueXML.length > 6)
        {
            FeeCriteriaParametersAndValues.FeeCriteriaValueXML = ParameterValueXML + "</rows>";
        } else {
            FeeCriteriaParametersAndValues.FeeCriteriaValueXML = "";
        }
    },

    //Fire ajax call to insert update and delete record
    AjaxCallFeeCriteriaParametersAndValues: function () {
        var FeeCriteriaParameterData = null;
        var FeeCriteriaParameterValueData = null;
        if (FeeCriteriaParametersAndValues.ActionName == "CreateParameter") {
            $("#FormCreateFeeCriteriaParameter").validate();
            if ($("#FormCreateFeeCriteriaParameter").valid()) {
                FeeCriteriaParameterData = null;
                FeeCriteriaParameterData = FeeCriteriaParametersAndValues.GetFeeCriteriaParameter();
                ajaxRequest.makeRequest("/FeeCriteriaParametersAndValues/CreateFeeCriteriaParameter", "POST", FeeCriteriaParameterData, FeeCriteriaParametersAndValues.Success, "CreateFeeCriteriaParameterRecord");
            }
        }
        else if (FeeCriteriaParametersAndValues.ActionName == "DeleteParameter") {
            FeeCriteriaParameterData = null;
            //$("#FormCreateFeeCriteriaParametersAndValues").validate();
            FeeCriteriaParameterData = FeeCriteriaParametersAndValues.GetFeeCriteriaParameter();
            ajaxRequest.makeRequest("/FeeCriteriaParametersAndValues/DeleteFeeCriteriaParameter", "POST", FeeCriteriaParameterData, FeeCriteriaParametersAndValues.Success, "DeleteFeeCriteriaParameterRecord");

        }
        else if (FeeCriteriaParametersAndValues.ActionName == "CreateValue") {
            $("#FormCreateFeeCriteriaParameterValue").validate();
            if ($("#FormCreateFeeCriteriaParameterValue").valid()) {
                FeeCriteriaParameterValueData = null;
                FeeCriteriaParameterValueData = FeeCriteriaParametersAndValues.GetFeeCriteriaParameterValue();
                ajaxRequest.makeRequest("/FeeCriteriaParametersAndValues/CreateFeeCriteriaParametersValue", "POST", FeeCriteriaParameterValueData, FeeCriteriaParametersAndValues.Success, "CreateFeeCriteriaParameterValueRecord");
            }
        }
        else if (FeeCriteriaParametersAndValues.ActionName == "DeleteValue") {
            FeeCriteriaParameterValueData = null;
            //$("#FormCreateFeeCriteriaParametersAndValues").validate();
            FeeCriteriaParameterValueData = FeeCriteriaParametersAndValues.GetFeeCriteriaParameterValue();
            ajaxRequest.makeRequest("/FeeCriteriaParametersAndValues/DeleteFeeCriteriaParameterValue", "POST", FeeCriteriaParameterValueData, FeeCriteriaParametersAndValues.Success, "DeleteFeeCriteriaParameterValueRecord");

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetFeeCriteriaParameter: function () {        
        var Data = {
        };
        if (FeeCriteriaParametersAndValues.ActionName == "CreateParameter") {            
            Data.FeeCriteriaParametersID = $('#FeeCriteriaParametersID').val();
            Data.FeeCriteriaParametersDescription = $("#FeeCriteriaParametersDescription  option:selected").text();
            Data.FeeCriteriaParametersCode = $('#FeeCriteriaParametersDescription').val();
            Data.RelatedWith = $('#RelatedWith').val();
        }
        else if (FeeCriteriaParametersAndValues.ActionName == "DeleteParameter") {
            Data.FeeCriteriaParametersID = $('#FeeCriteriaParametersID').val();
        }
        return Data;
    },

    GetFeeCriteriaParameterValue: function () {
        var Data = {
        };
        if (FeeCriteriaParametersAndValues.ActionName == "CreateValue") {
            Data.FeeCriteriaParametersID = $('#FeeCriteriaParametersID').val();
            Data.FeeCriteriaParameterValue = FeeCriteriaParametersAndValues.FeeCriteriaValueXML;
            //Data.FeeCriteriaParameterValue = $('#FeeCriteriaParameterValue').val();
        }
        else if (FeeCriteriaParametersAndValues.ActionName == "DeleteValue") {
            Data.FeeCriteriaParametersValuesID = $('#FeeCriteriaParametersValuesID').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {       
        debugger;
        var splitData = data.split(',');
        if (splitData[1] == 'success') {
            $.magnificPopup.close()
            FeeCriteriaParametersAndValues.ReloadList(splitData[0], splitData[1], splitData[2], splitData[3]);
        }
        else {
            $("#displayErrorMessage p").text(splitData[0]).closest('div').fadeIn().closest('div').addClass('alert-' + splitData[1]);
        }

    },
   
};

