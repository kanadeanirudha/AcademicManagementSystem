//this class contain methods related to nationality functionality
var FeeCriteriaCombinationParameterValue = {
    //Member variables
    ActionName: null,
    SubjectGrpCombinationIDs: null,
    SubHoursGrpAllocationIDs: null,
    SubjectGrpMarksIDs: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        FeeCriteriaCombinationParameterValue.constructor();
        //generalCountryMaster.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {



        $("#SelectedFeeCriteriaMasterID").change(function () {
            $('#myDataTable').html("");
            $('#myDataTable_info').text("No entries to show");
            $('.pagination').html('<li class="fg-button ui-button ui-state-default first disabled" id="myDataTable_first"><a href="#" aria-controls="myDataTable" data-dt-idx="0" tabindex="0"><i class="zmdi zmdi-more-horiz"></i></a></li><li class="fg-button ui-button ui-state-default previous disabled" id="myDataTable_previous"><a href="#" aria-controls="myDataTable" data-dt-idx="1" tabindex="0"><i class="zmdi zmdi-chevron-left"></i></a></li><li class="fg-button ui-button ui-state-default next disabled" id="myDataTable_next"><a href="#" aria-controls="myDataTable" data-dt-idx="2" tabindex="0"><i class="zmdi zmdi-chevron-right"></i></a></li><li class="fg-button ui-button ui-state-default last disabled" id="myDataTable_last"><a href="#" aria-controls="myDataTable" data-dt-idx="3" tabindex="0"><i class="zmdi zmdi-more-horiz"></i></a></li>');
        });
    

        $('#btnShowList').click(function () {
           
            var valueSelectedFeeCriteriaMasterID = $('#SelectedFeeCriteriaMasterID :selected').val();
            if ( valueSelectedFeeCriteriaMasterID > 0) {
                FeeCriteriaCombinationParameterValue.LoadListByFeeCriteriaMasterID(valueSelectedFeeCriteriaMasterID);
            }
            else if (valueSelectedFeeCriteriaMasterID <= 0) {
                
                notify("Please select fee criteria.", "danger");
                return false;


                $('#DivCreateNew').hide(true);
            }

            InitAnimatedBorder();
            CloseAlert();
           
        });


        // Create new record
        $('#CreateFeeCriteriaCombinationParameterValueRecord').on("click", function () {
            FeeCriteriaCombinationParameterValue.ActionName = "Create";
            FeeCriteriaCombinationParameterValue.AjaxCallFeeCriteriaCombinationParameterValue();
        });


        $('#DeleteFeeCriteriaCombinationParameterValueRecord').on("click", function () {

            FeeCriteriaCombinationParameterValue.ActionName = "Delete";
            FeeCriteriaCombinationParameterValue.AjaxCallFeeCriteriaCombinationParameterValue();
        });
        
      


    },
    //LoadList method is used to load List page

    LoadList: function () {
        var Balancesheet = $("#selectedBalsheetID").val();
        if (Balancesheet != null && Balancesheet != "NaN" && Balancesheet != "") {
            $.ajax(
               {
                   cache: false,
                   type: "POST",
                   dataType: "html",
                   url: '/FeeCriteriaCombinationParameterValue/List',
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
    ReloadList: function (message, colorCode, actionMode, feeCriteriaMasterID) {
      
        $.ajax(
        {
            cache: false,
            type: "POST",
            data: {actionMode: actionMode, feeCriteriaMasterID: feeCriteriaMasterID },
            dataType: "html",
            url: '/FeeCriteriaCombinationParameterValue/List',
            success: function (result) {
                //Rebind Grid Data                
                $("#ListViewModel").empty().append(result);
                //twitter type notification
                notify(message, colorCode);
            }
        });
    },
    //ReloadList method is used to load List page
    LoadListByFeeCriteriaMasterID: function (SelectedFeeCriteriaMasterID) {
      
        $.ajax(
          {
              cache: false,
              type: "POST",
              data: { feeCriteriaMasterID: SelectedFeeCriteriaMasterID },

              dataType: "html",
              url: '/FeeCriteriaCombinationParameterValue/List',
              success: function (result) {
                  //Rebind Grid Data                
                  $('#ListViewModel').html(result);

              }
          });
    },

    //Fire ajax call to insert update and delete record
    AjaxCallFeeCriteriaCombinationParameterValue: function () {
        var FeeCriteriaCombinationParameterValueData = null;
        if (FeeCriteriaCombinationParameterValue.ActionName == "Create") {
            //$("#FormCreateFeeCriteriaCombinationParameterValue").validate();
            if ($("#FormCreateFeeCriteriaCombinationParameterValue").valid()) {
                FeeCriteriaCombinationParameterValueData = null;
                FeeCriteriaCombinationParameterValueData = FeeCriteriaCombinationParameterValue.GetFeeCriteriaCombinationParameterValue();
                ajaxRequest.makeRequest("/FeeCriteriaCombinationParameterValue/CreateFeeCriteriaParameterValue", "POST", FeeCriteriaCombinationParameterValueData, FeeCriteriaCombinationParameterValue.createSuccess, "CreateFeeCriteriaCombinationParameterValueRecord");
            }
        }
      
        else if (FeeCriteriaCombinationParameterValue.ActionName == "Delete") {
            FeeCriteriaCombinationParameterValueData = null;
            //$("#FormCreateFeeCriteriaCombinationParameterValue").validate();
            FeeCriteriaCombinationParameterValueData = FeeCriteriaCombinationParameterValue.GetFeeCriteriaCombinationParameterValue();
            ajaxRequest.makeRequest("/FeeCriteriaCombinationParameterValue/DeleteFeeCriteriaParameterValue", "POST", FeeCriteriaCombinationParameterValueData, FeeCriteriaCombinationParameterValue.deleteSuccess, "DeleteFeeCriteriaCombinationParameterValueRecord");

        }
    },
    //Get properties data from the Create, Update and Delete page
    GetFeeCriteriaCombinationParameterValue: function () {

        var Data = {
        };
        if (FeeCriteriaCombinationParameterValue.ActionName == "Create") {
            Data.FeeCriteriaMasterID = $('input[name=FeeCriteriaMasterID]').val();
            Data.FeeCriteriaParameterValueCombinationIDs = $('input[name=FeeCriteriaParameterValueCombinationIDs]').val();
            Data.FeeCriteriaValueCombinationDescription = $('input[name=FeeCriteriaValueCombinationDescription]').val();
        }
        else if (FeeCriteriaCombinationParameterValue.ActionName == "Delete") {
            Data.FeeCriteriaMasterID = $('input[name=FeeCriteriaMasterID]').val();
            Data.FeeCriteriaValueCombinationMasterID = $('input[name=FeeCriteriaValueCombinationMasterID]').val();
        }

        return Data;
    },


    //this is used to for showing successfully record creation message and reload the list view
    //createSuccess: function (data) {
        
    //    var feeCriteriaMasterID = data.SelectedFeeCriteriaMasterID;
    //    var splitData = data.errorMessage.split(',');
    //    FeeCriteriaCombinationParameterValue.ReloadList(splitData[0], splitData[1], splitData[2], feeCriteriaMasterID);
    //    parent.$.colorbox.close();
      
    //},

    //deleteSuccess: function (data) {

    //    var feeCriteriaMasterID = data.SelectedFeeCriteriaMasterID;
    //    var splitData = data.errorMessage.split(',');
    //    FeeCriteriaCombinationParameterValue.ReloadList(splitData[0], splitData[1], splitData[2], feeCriteriaMasterID);
    //    parent.$.colorbox.close();

    //},
 
};

