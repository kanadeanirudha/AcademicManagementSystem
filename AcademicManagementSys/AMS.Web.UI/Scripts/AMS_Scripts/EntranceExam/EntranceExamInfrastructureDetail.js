//this class contain methods related to nationality functionality
var EntranceExamInfrastructureDetail = {
    //Member variables
    ActionName: null,
    //Class intialisation method
    Initialize: function () {
        //organisationStudyCentre.loadData();

        EntranceExamInfrastructureDetail.constructor();
        //EntranceExamInfrastructureDetail.initializeValidation();
    },
    //Attach all event of page
    constructor: function () {

        $('#CounterName').focus();

        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#CounterCode').focus();
            return false;
        });


        // Create new record
        //For EntranceExamInfrastructureDetail
        $('#CreateEntranceExamInfrastructureDetailRecord').on("click", function () {
            
            EntranceExamInfrastructureDetail.ActionName = "CreateInfrastructureDetail";
            EntranceExamInfrastructureDetail.AjaxCallEntranceExamInfrastructureDetail();
        });

        $('#EditEntranceExamInfrastructureDetailRecord').on("click", function () {
            
            EntranceExamInfrastructureDetail.ActionName = "Edit";
            EntranceExamInfrastructureDetail.AjaxCallEntranceExamInfrastructureDetail();
        });

        $('#DeleteEntranceExamInfrastructureDetailRecord').on("click", function () {

            EntranceExamInfrastructureDetail.ActionName = "Delete";
            EntranceExamInfrastructureDetail.AjaxCallEntranceExamInfrastructureDetail();
        });
        //For EntranceExamAvailableCentres

        $('#CreateEntranceExamAvailableCentresRecord').on("click", function () {
            
            EntranceExamInfrastructureDetail.ActionName = "Create";

            if ($('#GenLocationID').val() == 0) {
                ajaxRequest.ErrorMessageForJS("JsValidationMessages_EnterLocationAddress", "DivSuccessMessage", "#FFCC80");
               // alert("Please select Proper Location Address")
                return false;
            }
            else {
                EntranceExamInfrastructureDetail.AjaxCallEntranceExamInfrastructureDetail();

            }


          
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

        $("#ActiveUpto").prop('readonly', true);
        $("#ActiveFrom").prop('readonly', true);
        $('#ActiveFrom').datepicker({
            numberOfMonths: 1,
            dateFormat: 'd M yy',
            minDate: 0,
            onSelect: function (selected) {
                $("#ActiveUpto").datepicker("option", "minDate", selected)
            }
        })
        //serachlistfor Location
        $("#LocationAddress").autocomplete({

            source: function (request, response) {
                $.ajax({
                    url: "/EntranceExamInfrastructureDetail/GetLocationList",
                    type: "POST",
                    dataType: "json",
                    data: { term: request.term, maxResults: 10, CityID: $("#SelectedCityID :selected").val(), RegionID: $("#SelectedRegionID :selected").val() }, //1 for current year student
                    //{ term: request.term, maxResults: 10, courseYearID: $("#SelectedCourseYearId :selected").val(), sectionDetailID: $("#SelectedSectionDetailID :selected").val(), SessionID: $("#SelectedAcademicYear :selected").val() }, //1 for current year student
                    success: function (data) {
                        //alert(data)
                        response($.map(data, function (item) {
                            return { label: item.LocationAddress, value: item.LocationAddress, id: item.id };

                        }))
                    }
                })
            },
            select: function (event, ui) {
                //alert(ui.item.id);
                $(this).val(ui.item.label);                                             // display the selected text
                $("#GenLocationID").val(ui.item.id);
            }
        });

        // End of serachlistfor Location
        $('#ActiveUpto').datepicker({
            numberOfMonths: 1,
            dateFormat: 'd M yy',

            onSelect: function (selected) {
                $("#ActiveFrom").datepicker("option", "maxDate", selected)
            }
        })

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
             url: '/EntranceExamInfrastructureDetail/List',
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
            url: '/EntranceExamInfrastructureDetail/List',
            success: function (data) {
                //Rebind Grid Data
                $("#ListViewModel").empty().append(data);
                //twitter type notification
                $('#SuccessMessage').html(message);
                $('#SuccessMessage').delay(400).slideDown(400).delay(10000).slideUp(400).css('background-color', colorCode);
            }
        });
    },


    //Fire ajax call to insert update and delete record for Infrastructure
    AjaxCallEntranceExamInfrastructureDetail: function () {
        var EntranceExamInfrastructureDetailData = null;
        if (EntranceExamInfrastructureDetail.ActionName == "Create") {
            $("#FormCreateEntranceExamAvailableCentres").validate();
            if ($("#FormCreateEntranceExamAvailableCentres").valid()) {
                EntranceExamInfrastructureDetailData = null;
                EntranceExamInfrastructureDetailData = EntranceExamInfrastructureDetail.GetEntranceExamInfrastructureDetail();
                ajaxRequest.makeRequest("/EntranceExamInfrastructureDetail/Create", "POST", EntranceExamInfrastructureDetailData, EntranceExamInfrastructureDetail.Success);
            }
        }
        if (EntranceExamInfrastructureDetail.ActionName == "CreateInfrastructureDetail") {
            $("#FormCreateEntranceExamInfrastructureDetail").validate();
            if ($("#FormCreateEntranceExamInfrastructureDetail").valid()) {
                EntranceExamInfrastructureDetailData = null;
                EntranceExamInfrastructureDetailData = EntranceExamInfrastructureDetail.GetEntranceExamInfrastructureDetail();
                ajaxRequest.makeRequest("/EntranceExamInfrastructureDetail/CreateInfrastructureDetail", "POST", EntranceExamInfrastructureDetailData, EntranceExamInfrastructureDetail.Success);
            }
        }
        else if (EntranceExamInfrastructureDetail.ActionName == "Edit") {
            $("#FormEditEntranceExamInfrastructureDetail").validate();
            if ($("#FormEditEntranceExamInfrastructureDetail").valid()) {
                EntranceExamInfrastructureDetailData = null;
                EntranceExamInfrastructureDetailData = EntranceExamInfrastructureDetail.GetEntranceExamInfrastructureDetail();
                ajaxRequest.makeRequest("/EntranceExamInfrastructureDetail/Edit", "POST", EntranceExamInfrastructureDetailData, EntranceExamInfrastructureDetail.Success);
            }
        }
        else if (EntranceExamInfrastructureDetail.ActionName == "Delete") {
            EntranceExamInfrastructureDetailData = null;
            //$("#FormCreateEntranceExamInfrastructureDetail").validate();
            EntranceExamInfrastructureDetailData = EntranceExamInfrastructureDetail.GetEntranceExamInfrastructureDetail();
            ajaxRequest.makeRequest("/EntranceExamInfrastructureDetail/Delete", "POST", EntranceExamInfrastructureDetailData, EntranceExamInfrastructureDetail.Success);

        }
    },


  



    //Get properties data from the Create, Update and Delete page
    GetEntranceExamInfrastructureDetail: function () {
        var Data = {
        }; 
        if (EntranceExamInfrastructureDetail.ActionName == "Create" || EntranceExamInfrastructureDetail.ActionName == "Edit") {
            
            Data.EntranceExamAvailableCentresID = $('#ID').val();
            Data.CentreName = $('#CentreName').val();
            Data.LocationAddress = $('#LocationAddress').val();
            Data.Address = $('#Address').val();
            Data.ActiveFrom = $('#ActiveFrom').val();
            Data.ActiveUpto = $('#ActiveUpto').val();
            Data.GenLocationID = $('#GenLocationID').val();
        }
        else if (EntranceExamInfrastructureDetail.ActionName == "CreateInfrastructureDetail") {
            
            Data.EntranceExamInfrastructureDetailID = $('#ID').val();
           
           // Data.EntranceExamAvailableCentresID = $('#EntranceExamAvailableCentresID').val();
            Data.EntranceExamAvailableCentresID = $('input[name=EntranceExamAvailableCentresID]').val();
            Data.RoomName = $('#RoomName').val();
            Data.RoomNumber = $('#RoomNumber').val();
            Data.ExtraDescription = $('#ExtraDescription').val();
            Data.RoomCapacity = $('#RoomCapacity').val();
            Data.CentreName = $('#CentreName').val();
           
        }
        else if (EntranceExamInfrastructureDetail.ActionName == "Delete") {
            Data.ID = $('#ID').val();
        }
        return Data;
    },

    //this is used to for showing successfully record creation message and reload the list view
    Success: function (data) {
        
        var splitData = data.split(',');
        if (data != null) {
            parent.$.colorbox.close();
            EntranceExamInfrastructureDetail.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            parent.$.colorbox.close();
            EntranceExamInfrastructureDetail.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },


};

