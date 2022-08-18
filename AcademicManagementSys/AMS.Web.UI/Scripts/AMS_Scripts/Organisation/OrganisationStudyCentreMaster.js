//var OrganisationStudyCentreMaster = {
//    ActionName: null,
//    SelectedUniversityIDs: null,
//    Initialize: function () {
//        //OrganisationStudyCentreMaster.loadData();
//        OrganisationStudyCentreMaster.constructor();
     
//    },
//    //loadData: function () {
//    //    alert("Function is loaded");
//    //},
//    constructor: function (e) {
//        //$("#HoCoRoScFlag").change(function () {
//        //    
//        //    var selectedItem = $(this).val();
//        //    //var Data = OrganisationStudyCentreMaster.getData(selectedItem);
//        //    OrganisationStudyCentreMaster.GetStudyCentreHORO(selectedItem);
//        //    //ajaxRequest.makeRequest("/OrganisationStudyCentreMaster/GetStudyCentreHORO", "GET", Data, OrganisationStudyCentreMaster.success);
//        //});
//        $('#CentreEstablishmentDatetime').datepicker({

//            dateFormat: 'd-M-yy',
//            changeMonth: true,
//            changeYear: true,
//            yearRange: '1850:document.write(currentYear.getFullYear()',
//        });

//        //FOLLOWING FUNCTION IS SEARCHLIST OF Timezone list
//        $("#TimeZone").autocomplete({
           
//            source: function (request, response) {
                
                
//                $.ajax({
                   
//                    url: "/OrganisationStudyCentreMaster/GetGeneralTimeZoneMasterSearchlist",
//                    type: "POST",
//                    dataType: "json",
//                    data: { term: request.term},
//                    success: function (data) {
//                        response($.map(data, function (item) {

//                            return {

//                                label: item.TimeZone,
//                                value: item.TimeZone,
//                                TimeZoneID: item.TimeZoneID,
//                                TimeZone: item.TimeZone,
//                                UTCoffset: item.UTCoffset
//                            };
//                        }))
//                    }
//                })
//            },
//            select: function (event, ui) {
//                $(this).val(ui.item.label);                                             // display the selected text
                
//                $("#TimeZoneID").val(parseInt(ui.item.TimeZoneID));
//                $("#TimeZone").val(ui.item.TimeZone);
//                $("#UTCoffset").val(ui.item.UTCoffset);
//            }
//        });



//        $('#CreateOrganisationStudyCentreMasterRecord').on("click", function () {
            
//            OrganisationStudyCentreMaster.ActionName = "Create";
//            OrganisationStudyCentreMaster.getValueUsingParentTag_Check_UnCheck();
//            OrganisationStudyCentreMaster.AjaxCallOrganisationStudyCentreMaster();
//        });
        
//        $('#EditOrganisationStudyCentreMasterRecord').on("click", function () {
            
//            OrganisationStudyCentreMaster.ActionName = "Edit";
//            OrganisationStudyCentreMaster.getValueUsingParentTag_Check_UnCheck();
//            OrganisationStudyCentreMaster.AjaxCallOrganisationStudyCentreMaster();
//        });

//        $('#DeleteOrganisationStudyCentreMasterRecord').on("click", function () {
            
//            OrganisationStudyCentreMaster.ActionName = "Delete";
//            OrganisationStudyCentreMaster.AjaxCallOrganisationStudyCentreMaster();
//        });

//        $('#closeBtn').on("click", function () {
//            parent.$.colorbox.close();
//        });
//        $("#UserSearch").on("keyup", function () {
//            var oTable = $("#myDataTable").dataTable();
//            oTable.fnFilter(this.value);
//        });
//        $("#searchBtn").on("click", function () {
//            $("#UserSearch").focus();
//        });
//        $("#showrecord").on("change", function () {
//            var showRecord = $("#showrecord").val();
//            $("select[name*='myDataTable_length']").val(showRecord);
//            $("select[name*='myDataTable_length']").change();
//        });
//        $(".ajax").colorbox();

//        $('#CentreName').keydown(function (e) {
//            AMSValidation.AllowCharacterOnly(e);
//        });
        
//        //$('#CentreCode').keydown(function (e) {
//        //    AMSValidation.AllowCharacterOnly(e);
//        //});
//        $('#CentreCode').keydown(function (e) {
//            AMSValidation.NotAllowSpaces(e);
//            AMSValidation.AllowCharacterOnly(e);
//        });
//        $('#CentreLoginNumber').keydown(function (e) {
//            AMSValidation.AllowNumbersOnly(e);
//        });
//        $('#CentreLoginNumber').keydown(function (e) {
//            AMSValidation.NotAllowSpaces(e);
//        });

//        $('#CentreSpecialization').keydown(function (e) {
//            AMSValidation.AllowCharacterOnly(e);
//        });

//        //$('#CentreAddress').keydown(function (e) {
//        //    AMSValidation.AllowCharacterOnly(e);
//        //});
        
//        $('#PlotNo').keydown(function (e) {
//            AMSValidation.AllowNumbersOnly(e);
//        });
//        $('#PlotNo').keydown(function (e) {
//            AMSValidation.NotAllowSpaces(e);
//        });

//        $('#PlotNo').keydown(function (e) {
//            AMSValidation.NotAllowSpaces(e);
//        });
      
//        $('#InstituteCode').keydown(function (e) {
//            AMSValidation.NotAllowSpaces(e);
//        });

//        $('#FaxNumber').keydown(function (e) {
//            AMSValidation.AllowNumbersOnly(e);
//        });
//        $('#EmailID').keydown(function (e) {
//            AMSValidation.NotAllowSpaces(e);
//        });
      

//        $('#PhoneNumberOffice').keydown(function (e) {
//            AMSValidation.AllowNumbersOnly(e);
//        });
//        $('#PhoneNumberOffice').keydown(function (e) {
//            AMSValidation.NotAllowSpaces(e);
//        });

//        $('#CellPhone').keydown(function (e) {
//            AMSValidation.AllowNumbersOnly(e);
//        });
//        $('#CellPhone').keydown(function (e) {
//            AMSValidation.NotAllowSpaces(e);
//        });

//        $('#Pincode').keydown(function (e) {
//            AMSValidation.AllowNumbersOnly(e);
//        });
//        $('#Pincode').keydown(function (e) {
//            AMSValidation.NotAllowSpaces(e);
//        });

//        $('#Url').keydown(function (e) {
//            AMSValidation.AllowCharacterOnly(e);
//        });
//        $('#Url').keydown(function (e) {
//            AMSValidation.NotAllowSpaces(e);
//        });


//        $("#reset").click(function () {

//            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
//            $('input:checkbox,input:radio').removeAttr('checked');
//            $('#CentreName').focus();
//            $('#HoCoRoScFlag').val("RO");
//            $('#SelectedCityID').val("");
//            return false;
//        });


//        if ($("#HoCoRoScFlag").val() == "SC") {
//            $("#DivLabRoID").show(true);
//            $("#DivDisRoID").show(true);
           
//        }

//        $("#HoCoRoScFlag").on("click", function () {
//            var SelectedItem =  $("#HoCoRoScFlag").val();
//            if (SelectedItem == "SC") {
//                $("#DivLabRoID").show(true);
//                $("#DivDisRoID").show(true);
//                OrganisationStudyCentreMaster.GetStudyCentreHORO(SelectedItem);
//            }
//            else {
//                $("#DivLabRoID").hide(true);
//                $("#DivDisRoID").hide(true);
//                OrganisationStudyCentreMaster.GetStudyCentreHORO(SelectedItem);
               
//            }
//        });
//    },
//    //addOrganisationStudyCentre: function () {
//    //    $("#FormOrganisationStudyCentreMaster").validate();
//    //    if ($("#FormOrganisationStudyCentreMaster").valid()) {
//    //        var OrganisationStudyCentreMasterData = OrganisationStudyCentreMaster.getOrganisationStudyCentreMasterData();
//    //        ajaxRequest.makeRequest("/OrganisationStudyCentreMaster/Create", "POST", OrganisationStudyCentreMasterData, OrganisationStudyCentreMaster.createSuccess);
//    //    }
//    //}
    
//    AjaxCallOrganisationStudyCentreMaster: function () {
//        var OrganisationStudyCentreMasterData = null;
//        if (OrganisationStudyCentreMaster.ActionName == "Create") {
//            $("#FormCreateOrganisationStudyCentreMaster").validate();
//            if ($("#FormCreateOrganisationStudyCentreMaster").valid()) {
//                OrganisationStudyCentreMasterData = null;
//                OrganisationStudyCentreMasterData = OrganisationStudyCentreMaster.getOrganisationStudyCentreMasterData();
//                ajaxRequest.makeRequest("OrganisationStudyCentreMaster/Create", "POST", OrganisationStudyCentreMasterData, OrganisationStudyCentreMaster.Success);
//            }
//        }
//        else if (OrganisationStudyCentreMaster.ActionName == "Edit") {
//            $("#FormEditOrganisationStudyCentreMaster").validate();
//            if ($("#FormEditOrganisationStudyCentreMaster").valid()) {
//                OrganisationStudyCentreMasterData = null;
//                OrganisationStudyCentreMasterData = OrganisationStudyCentreMaster.getOrganisationStudyCentreMasterData();
//                ajaxRequest.makeRequest("OrganisationStudyCentreMaster/Edit", "POST", OrganisationStudyCentreMasterData, OrganisationStudyCentreMaster.Success);
//            }
//        }
//        else if (OrganisationStudyCentreMaster.ActionName == "Delete") {

//            $("#FormDeleteOrganisationStudyCentreMaster").validate();
//            if ($("#FormDeleteOrganisationStudyCentreMaster").valid()) {
//                OrganisationStudyCentreMasterData = null;
//                //$("#FormCreateOrganisationStudyCentreMaster").validate();
//                OrganisationStudyCentreMasterData = OrganisationStudyCentreMaster.getOrganisationStudyCentreMasterData();
//                ajaxRequest.makeRequest("OrganisationStudyCentreMaster/Delete", "POST", OrganisationStudyCentreMasterData, OrganisationStudyCentreMaster.Success);
//            }
//        }
//    },
//    success: function (data) {
        
//        $("#RoID").html('');
//        $('#RoID').append('<option value>--Select--</option>');
//        $.each(data, function (id, option) {

//            $("#RoID").append($('<option></option>').val(option.id).html(option.name));
//        });
//        $RegionProgress.hide();
//    },
//    getOrganisationStudyCentreMasterData: function () {
         
//        var Data = {
//        };
//        Data.ID = $('input[name=ID]').val();
//        Data.CentreName = $('#CentreName').val();
//        Data.CentreCode = $('#CentreCode').val();
//        Data.HoCoRoScFlag = $('#HoCoRoScFlag').val();
//        if ($('#HoCoRoScFlag').val() == "SC") {
//            Data.RoID = $('#RoID').val();
//        }
//        else {
//            Data.RoID = 0;
//        }
//        Data.OrganisationID = $('#OrganisationID').val();
//        Data.SelectedOrganisationID = $('#SelectedOrganisationID').val();
//        Data.SelectedUniversityID = $('#SelectedUniversityID').val();
//        Data.SelectedCityID = $('#SelectedCityID').val();        
//       // Data.UniversityID = $('#UniversityID').val();
//        Data.CentreEstablishmentDatetime = $('#CentreEstablishmentDatetime').val();
//        Data.CentreLoginNumber = $('#CentreLoginNumber').val();
//        Data.CentreSpecialization = $('#CentreSpecialization').val();
//        Data.CentreAddress = $('#CentreAddress').val();
//        Data.PlotNo = $('#PlotNo').val();
//        Data.StreetName = $('#StreetName').val();
//        Data.CityID = $('#CityID').val();
//        Data.Pincode = $('#Pincode').val();
//        Data.FaxNumber = $('#FaxNumber').val();
//        Data.PhoneNumberOffice = $('#PhoneNumberOffice').val();
//        Data.InstituteCode = $('#InstituteCode').val();
//        Data.CellPhone = $('#CellPhone').val();
//        Data.EmailID = $('#EmailID').val();
//        Data.Url = $('#Url').val();
//        Data.IDs = OrganisationStudyCentreMaster.SelectedUniversityIDs;
//        Data.TimeZone = $('#TimeZone').val();
//        Data.Latitude = $('#Latitude').val();
//        Data.Longitude = $('#Longitude').val();
//        Data.CampusArea = $('#CampusArea').val();
//        return Data;
//    },
//    initializeValidation: function () {
//        $('#homeForm').validate({
//            rules: {
//                CentreName: "required",
//                CentreCode: "required",
//                HoCoRoScFlag: "required",
//                RoID: "required",
//                OrganisationID: "required",
//                //UniversityID: "required",
//                CentreEstablishmentDatetime: "required",
//                CentreLoginNumber: "required",
//                CentreSpecialization: "required",
//                CentreAddress: "required",
//                PlotNo: "required",
//                StreetName: "required",
//                CityID: "required",
//                Pincode: "required",
//                FaxNumber: "required",
//                PhoneNumberOffice: "required",
//                InstituteCode: "required",

//                TimeZone: "required",
//                Latitude: "required",
//                Longitude: "required",
//                CampusArea: "required",


//                CellPhone: "required",
//                EmailID: "required",
//                Url: "required"
//            },
//            messages: {
//                CentreName: "Centre name is required",
//                CentreCode: "Centre code is required",
//                HoCoRoScFlag: "Office type is required",
//                OrganisationID: "Oganisation is required",
//                //UniversityID: "University is required",
//                CentreEstablishmentDatetime: "Centre Stablishment date is required",
//                CentreLoginNumber: "Centre login is required",
//                CentreSpecialization: "Centre specialization is required",
//                EmailID: "Email address is required",

//                CentreName: "Centre name is required",
//                CentreCode: "Centre code is required",
//                HoCoRoScFlag: "Office type is required",
//                RoID: "RoID is required",
//                OrganisationID: "Organisation id is required",
//                UniversityID: "University id is required",
//                CentreEstablishmentDatetime: "Centre Establishment date is required",
//                CentreLoginNumber: "Centre login number is required",
//                CentreSpecialization: "Centre specialization is required",
//                CentreAddress: "Centre address is required",
//                PlotNo: "Plot number is required",
//                StreetName: "Street name is required",
//                CityID: "City id is required",
//                Pincode: "Pin code is required",
//                FaxNumber: "Fax number is required",
//                PhoneNumberOffice: "Office phone number is required",
//                InstituteCode: "Institute code is required",
//                TimeZone: "TimeZone is required",
//                Latitude: "Latitude is required",
//                Longitude: "Longitude is required",
//                CampusArea: "CampusArea is required",


//                CellPhone: "Cell phone number is required",
//                EmailID: "Email id is required",
//                Url: "Url is required"

//            }
//        });
//    },
//    LoadList: function () {
//        $.ajax(
//        {
//            cache: false,
//            type: "POST",
//            dataType: "html",
//            url: 'OrganisationStudyCentreMaster/List',
//            success: function (data) {
//                //Rebind Grid Data
//                $('#ListViewModel').html(data);
//            }
//        });
//    },
//    ReloadList: function (message,colorCode, actionMode) {
//        $.ajax(
//       {
//           cache: false,
//           type: "POST",
//           dataType: "html",
//           data: { actionMode: actionMode },
//           url: 'OrganisationStudyCentreMaster/List',
//           success: function (data) {
//               //Rebind Grid Data
//               $("#ListViewModel").empty().append(data);
//               //twitter type notification
//               $('#SuccessMessage').html(message);
//               $('#SuccessMessage').delay(400).slideDown(400).delay(3000).slideUp(400).css('background-color', colorCode);
//           }
//       });
//    },
//    checkdatavalidations: function () {

//    },
//    GetStudyCentreHORO: function (selectedItem) {
//        if (selectedItem == "SC") {
//            $("#RoID").prop("disabled", false);
//            var $ddlRegion = $("#RoID");
//            var $RegionProgress = $("#states-loading-progress");
//            $RegionProgress.show();
//            $.ajax({
//                cache: false,
//                type: "GET",
//                url: "/OrganisationStudyCentreMaster/GetStudyCentreHORO",
//                data: { "HoCoRoScFlag": selectedItem },
//                success: function (data) {
//                    $ddlRegion.html('');
//                    $('#RoID').append('<option value>------------------Select----------------</option>');
//                    $.each(data, function (id, option) {

//                        $ddlRegion.append($('<option></option>').val(option.id).html(option.name));
//                    });
//                    $RegionProgress.hide();

//                },
//                error: function (xhr, ajaxOptions, thrownError) {
//                    alert('Failed to retrieve Head Office.');
//                    $RegionProgress.hide();
//                }
//            });
//        }
//        else {
//            $('#RoID').find('option').remove().end().append('');
//            $("#RoID").prop("disabled", true);
//        }
//    },


//    getValueUsingParentTag_Check_UnCheck: function () {
        
//        var sList = "";
//        var xmlParamList = "<rows>"
//        $('#checkboxlist input[type=checkbox]').each(function () {
//            if ($(this).val() != "on") {
//                var sArray = [];
//                sArray = $(this).val().split("~");
//                if (this.checked == true && parseInt(sArray[1]) == 0) {
//                    //xmlInsert code here
//                    xmlParamList = xmlParamList + "<row>" + "<ID>" + sArray[1] + "</ID>" + "<UniversityID>" + sArray[0] + "</UniversityID>" + "<IsActive>1</IsActive>" + "</row>";
//                }
//                else if (this.checked == false && parseInt(sArray[1]) > 0) {
//                    //xmlUpdate code here
//                    xmlParamList = xmlParamList + "<row>" + "<ID>" + sArray[1] + "</ID>" + "<UniversityID>" + sArray[0] + "</UniversityID>" + "<IsActive>0</IsActive>" + "</row>";

//                }
//            }
//            if (xmlParamList.length >6)
//                OrganisationStudyCentreMaster.SelectedUniversityIDs = xmlParamList + "</rows>";
//            else 
//                OrganisationStudyCentreMaster.SelectedUniversityIDs ="0";
//        });

//    },
//    //  @sIDs= <rows><row><ID>0</ID><UniversityID>1</UniversityID><IsActive>1</IsActive></row></rows>

//    Success: function (data) {
//        var splitData = data.split(',');
//        if (data != null) {
//            parent.$.colorbox.close();
//            OrganisationStudyCentreMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
//        } else {
//            parent.$.colorbox.close();
//            OrganisationStudyCentreMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
//        }

//    },
//    //editSuccess: function (data) {
//    //    parent.$.colorbox.close();
//    //    var actionMode = "1";
//    //    OrganisationStudyCentreMaster.ReloadList("Record Updated Sucessfully.", actionMode);
//    //    //if ($("#update-message").html() == "True") {
//    //    //    //Reload List
//    //    //    OrganisationStudyCentreMaster.ReloadList("Record Updated Sucessfully.");
//    //    //    //now we can close the dialog
//    //    //    $('#dialog-edit').dialog('close');
//    //    //} else {
//    //    //    $("#update-message").show();
//    //    //}
//    //},
//    //deleteSuccess: function (data) {
//    //    parent.$.colorbox.close();
//    //    OrganisationStudyCentreMaster.ReloadList("Record Updated Sucessfully.");
//    //    //if ($("#update-message").html() == "True") {
//    //    //    //Reload List
//    //    //    OrganisationStudyCentreMaster.ReloadList("Record Deleted Sucessfully.");
//    //    //    //now we can close the dialog
//    //    //    $('#delete-dialog').dialog('close');
//    //    //} else {
//    //    //    $("#update-message").show();
//    //    //}
//    //},
//};


/////////new js////////////////////

var OrganisationStudyCentreMaster = {
    ActionName: null,
    SelectedUniversityIDs: null,
    map: {},
    map2: {},
    Initialize: function () {
        //OrganisationStudyCentreMaster.loadData();
        OrganisationStudyCentreMaster.constructor();

    },
    //loadData: function () {
    //    alert("Function is loaded");
    //},
    constructor: function (e) {
        //$("#HoCoRoScFlag").change(function () {
        //    
        //    var selectedItem = $(this).val();
        //    //var Data = OrganisationStudyCentreMaster.getData(selectedItem);
        //    OrganisationStudyCentreMaster.GetStudyCentreHORO(selectedItem);
        //    //ajaxRequest.makeRequest("/OrganisationStudyCentreMaster/GetStudyCentreHORO", "GET", Data, OrganisationStudyCentreMaster.success);
        //});

        //$('#CentreEstablishmentDatetime').datepicker({

        //    dateFormat: 'd-M-yy',
        //    changeMonth: true,
        //    changeYear: true,
        //    yearRange: '1850:document.write(currentYear.getFullYear()',
        //});

        $('#CentreEstablishmentDatetime').datetimepicker({
            format: 'DD MMMM YYYY',
            ignoreReadonly: true,
            //maxDate: moment(),
        });

        //FOLLOWING FUNCTION IS SEARCHLIST OF Timezone list

        //$("#TimeZone").autocomplete({

        //    source: function (request, response) {


        //        $.ajax({

        //            url: "/OrganisationStudyCentreMaster/GetGeneralTimeZoneMasterSearchlist",
        //            type: "POST",
        //            dataType: "json",
        //            data: { term: request.term },
        //            success: function (data) {
        //                response($.map(data, function (item) {

        //                    return {

        //                        label: item.TimeZone,
        //                        value: item.TimeZone,
        //                        TimeZoneID: item.TimeZoneID,
        //                        TimeZone: item.TimeZone,
        //                        UTCoffset: item.UTCoffset
        //                    };
        //                }))
        //            }
        //        })
        //    },
        //    select: function (event, ui) {
        //        $(this).val(ui.item.label);                                             // display the selected text

        //        $("#TimeZoneID").val(parseInt(ui.item.TimeZoneID));
        //        $("#TimeZone").val(ui.item.TimeZone);
        //        $("#UTCoffset").val(ui.item.UTCoffset);
        //    }
        //});

        /////////////new search functionality///////////////////////////////////
        var getData = function () {
            return function findMatches(q, cb) {

                var matches, substringRegex;

                // an array that will be populated with substring matches
                matches = [];

                // regex used to determine if a string contains the substring `q`
                substrRegex = new RegExp(q, 'i');
                var valuCentreCode = $('#SelectedCentreCode :selected').val();
                var valuStudentType = $('#IsCurrentYearStudent').val();
                $.ajax({
                    url: "/OrganisationStudyCentreMaster/GetGeneralTimeZoneMasterSearchlist",
                    type: "POST",
                    data: { term: q },
                    dataType: "json",
                    success: function (data) {

                        // iterate through the pool of strings and for any string that
                        // contains the substring `q`, add it to the `matches` array
                        //alert(data);

                        $.each(data, function (i, response) {
                            //alert(response.TimeZoneID);

                            if (substrRegex.test(response.TimeZone)) {
                                OrganisationStudyCentreMaster.map[response.TimeZone] = response;
                                matches.push(response.TimeZone);

                            }
                        });

                    },
                    async: false
                })
                cb(matches);
            };

        };

        $("#TimeZone").typeahead({
            hint: true,
            highlight: true,
            minLength: 1
        }, {
            source: getData()
        }).on("typeahead:selected", function (obj, item) {

            //alert(OrganisationStudyCentreMaster.map[item].UTCoffset);
            //$(this).val(item.label);
            
            $("#TimeZoneID").val(parseInt(OrganisationStudyCentreMaster.map[item].TimeZoneID));
            $("#TimeZone").val(OrganisationStudyCentreMaster.map[item].TimeZone);
            $("#UTCoffset").val(OrganisationStudyCentreMaster.map[item].UTCoffset);

        });
        //end new search functionality

        $('#CreateOrganisationStudyCentreMasterRecord').on("click", function () {
            debugger;
            OrganisationStudyCentreMaster.ActionName = "Create";
            OrganisationStudyCentreMaster.getValueUsingParentTag_Check_UnCheck();
            OrganisationStudyCentreMaster.AjaxCallOrganisationStudyCentreMaster();
        });

        $('#EditOrganisationStudyCentreMasterRecord').on("click", function () {
            //debugger;
            OrganisationStudyCentreMaster.ActionName = "Edit";
            OrganisationStudyCentreMaster.getValueUsingParentTag_Check_UnCheck();
            OrganisationStudyCentreMaster.AjaxCallOrganisationStudyCentreMaster();
        });

        $('#DeleteOrganisationStudyCentreMasterRecord').on("click", function () {

            OrganisationStudyCentreMaster.ActionName = "Delete";
            OrganisationStudyCentreMaster.AjaxCallOrganisationStudyCentreMaster();
        });

        $('#closeBtn').on("click", function () {
            parent.$.colorbox.close();
        });
        $("#UserSearch").on("keyup", function () {
            var oTable = $("#myDataTable").dataTable();
            oTable.fnFilter(this.value);
        });
        $("#searchBtn").on("click", function () {
            $("#UserSearch").focus();
        });
        $("#showrecord").on("change", function () {
            var showRecord = $("#showrecord").val();
            $("select[name*='myDataTable_length']").val(showRecord);
            $("select[name*='myDataTable_length']").change();
        });

        //$(".ajax").colorbox();
        InitAnimatedBorder();
        CloseAlert();

        $('#CentreName').keydown(function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        //$('#CentreCode').keydown(function (e) {
        //    AMSValidation.AllowCharacterOnly(e);
        //});
        $('#CentreCode').keydown(function (e) {
            AMSValidation.NotAllowSpaces(e);
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#CentreLoginNumber').keydown(function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        $('#CentreLoginNumber').keydown(function (e) {
            AMSValidation.NotAllowSpaces(e);
        });

        $('#CentreSpecialization').keydown(function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });

        //$('#CentreAddress').keydown(function (e) {
        //    AMSValidation.AllowCharacterOnly(e);
        //});

        $('#PlotNo').keydown(function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        $('#PlotNo').keydown(function (e) {
            AMSValidation.NotAllowSpaces(e);
        });

        $('#PlotNo').keydown(function (e) {
            AMSValidation.NotAllowSpaces(e);
        });

        $('#InstituteCode').keydown(function (e) {
            AMSValidation.NotAllowSpaces(e);
        });

        $('#FaxNumber').keydown(function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        $('#EmailID').keydown(function (e) {
            AMSValidation.NotAllowSpaces(e);
        });


        $('#PhoneNumberOffice').keydown(function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        $('#PhoneNumberOffice').keydown(function (e) {
            AMSValidation.NotAllowSpaces(e);
        });

        $('#CellPhone').keydown(function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        $('#CellPhone').keydown(function (e) {
            AMSValidation.NotAllowSpaces(e);
        });

        $('#Pincode').keydown(function (e) {
            AMSValidation.AllowNumbersOnly(e);
        });
        $('#Pincode').keydown(function (e) {
            AMSValidation.NotAllowSpaces(e);
        });

        $('#Url').keydown(function (e) {
            AMSValidation.AllowCharacterOnly(e);
        });
        $('#Url').keydown(function (e) {
            AMSValidation.NotAllowSpaces(e);
        });


        $("#reset").click(function () {

            $("input,textarea").not(':reset, :submit, :hidden, :button, :checkbox,:radio').val("");
            $('input:checkbox,input:radio').removeAttr('checked');
            $('#CentreName').focus();
            $('#HoCoRoScFlag').val("RO");
            $('#SelectedCityID').val("");
            return false;
        });


        if ($("#HoCoRoScFlag").val() == "SC") {
            $("#DivLabRoID").show(true);
            $("#DivDisRoID").show(true);

        }

        $("#HoCoRoScFlag").on("click", function () {
            var SelectedItem = $("#HoCoRoScFlag").val();
            if (SelectedItem == "SC") {
                $("#DivLabRoID").show(true);
                $("#DivDisRoID").show(true);
                OrganisationStudyCentreMaster.GetStudyCentreHORO(SelectedItem);
            }
            else {
                $("#DivLabRoID").hide(true);
                $("#DivDisRoID").hide(true);
                OrganisationStudyCentreMaster.GetStudyCentreHORO(SelectedItem);

            }
        });
    },
    //addOrganisationStudyCentre: function () {
    //    $("#FormOrganisationStudyCentreMaster").validate();
    //    if ($("#FormOrganisationStudyCentreMaster").valid()) {
    //        var OrganisationStudyCentreMasterData = OrganisationStudyCentreMaster.getOrganisationStudyCentreMasterData();
    //        ajaxRequest.makeRequest("/OrganisationStudyCentreMaster/Create", "POST", OrganisationStudyCentreMasterData, OrganisationStudyCentreMaster.createSuccess);
    //    }
    //}

    AjaxCallOrganisationStudyCentreMaster: function () {
        debugger;
        var OrganisationStudyCentreMasterData = null;
        if (OrganisationStudyCentreMaster.ActionName == "Create") {
            $("#FormCreateOrganisationStudyCentreMaster").validate();
            if ($("#FormCreateOrganisationStudyCentreMaster").valid()) {
                OrganisationStudyCentreMasterData = null;
                OrganisationStudyCentreMasterData = OrganisationStudyCentreMaster.getOrganisationStudyCentreMasterData();
                ajaxRequest.makeRequest("OrganisationStudyCentreMaster/Create", "POST", OrganisationStudyCentreMasterData, OrganisationStudyCentreMaster.Success);
            }
        }
        else if (OrganisationStudyCentreMaster.ActionName == "Edit") {
            $("#FormEditOrganisationStudyCentreMaster").validate();
            if ($("#FormEditOrganisationStudyCentreMaster").valid()) {
                OrganisationStudyCentreMasterData = null;
                OrganisationStudyCentreMasterData = OrganisationStudyCentreMaster.getOrganisationStudyCentreMasterData();
                ajaxRequest.makeRequest("OrganisationStudyCentreMaster/Edit", "POST", OrganisationStudyCentreMasterData, OrganisationStudyCentreMaster.Success);
            }
        }
        else if (OrganisationStudyCentreMaster.ActionName == "Delete") {

            $("#FormDeleteOrganisationStudyCentreMaster").validate();
            if ($("#FormDeleteOrganisationStudyCentreMaster").valid()) {
                OrganisationStudyCentreMasterData = null;
                //$("#FormCreateOrganisationStudyCentreMaster").validate();
                OrganisationStudyCentreMasterData = OrganisationStudyCentreMaster.getOrganisationStudyCentreMasterData();
                ajaxRequest.makeRequest("OrganisationStudyCentreMaster/Delete", "POST", OrganisationStudyCentreMasterData, OrganisationStudyCentreMaster.Success);
            }
        }
    },
    success: function (data) {

        $("#RoID").html('');
        $('#RoID').append('<option value>--Select--</option>');
        $.each(data, function (id, option) {

            $("#RoID").append($('<option></option>').val(option.id).html(option.name));
        });
        $RegionProgress.hide();
    },
    getOrganisationStudyCentreMasterData: function () {

        var Data = {
        };
        Data.ID = $('input[name=ID]').val();
        Data.CentreName = $('#CentreName').val();
        Data.CentreCode = $('#CentreCode').val();
        Data.HoCoRoScFlag = $('#HoCoRoScFlag').val();
        if ($('#HoCoRoScFlag').val() == "SC") {
            Data.RoID = $('#RoID').val();
        }
        else {
            Data.RoID = 0;
        }
        Data.OrganisationID = $('#OrganisationID').val();
        Data.SelectedOrganisationID = $('#SelectedOrganisationID').val();
        Data.SelectedUniversityID = $('#SelectedUniversityID').val();
        Data.SelectedCityID = $('#SelectedCityID').val();
        // Data.UniversityID = $('#UniversityID').val();
        Data.CentreEstablishmentDatetime = $('#CentreEstablishmentDatetime').val();
        Data.CentreLoginNumber = $('#CentreLoginNumber').val();
        Data.CentreSpecialization = $('#CentreSpecialization').val();
        Data.CentreAddress = $('#CentreAddress').val();
        Data.PlotNo = $('#PlotNo').val();
        Data.StreetName = $('#StreetName').val();
        Data.CityID = $('#CityID').val();
        Data.Pincode = $('#Pincode').val();
        Data.FaxNumber = $('#FaxNumber').val();
        Data.PhoneNumberOffice = $('#PhoneNumberOffice').val();
        Data.InstituteCode = $('#InstituteCode').val();
        Data.CellPhone = $('#CellPhone').val();
        Data.EmailID = $('#EmailID').val();
        Data.Url = $('#Url').val();
        Data.IDs = OrganisationStudyCentreMaster.SelectedUniversityIDs;
        Data.TimeZone = $('#TimeZone').val();
        Data.Latitude = $('#Latitude').val();
        Data.Longitude = $('#Longitude').val();
        Data.CampusArea = $('#CampusArea').val();
        return Data;
    },
    initializeValidation: function () {
        $('#homeForm').validate({
            rules: {
                CentreName: "required",
                CentreCode: "required",
                HoCoRoScFlag: "required",
                RoID: "required",
                OrganisationID: "required",
                //UniversityID: "required",
                CentreEstablishmentDatetime: "required",
                CentreLoginNumber: "required",
                CentreSpecialization: "required",
                CentreAddress: "required",
                PlotNo: "required",
                StreetName: "required",
                CityID: "required",
                Pincode: "required",
                FaxNumber: "required",
                PhoneNumberOffice: "required",
                InstituteCode: "required",

                TimeZone: "required",
                Latitude: "required",
                Longitude: "required",
                CampusArea: "required",


                CellPhone: "required",
                EmailID: "required",
                Url: "required"
            },
            messages: {
                CentreName: "Centre name is required",
                CentreCode: "Centre code is required",
                HoCoRoScFlag: "Office type is required",
                OrganisationID: "Oganisation is required",
                //UniversityID: "University is required",
                CentreEstablishmentDatetime: "Centre Stablishment date is required",
                CentreLoginNumber: "Centre login is required",
                CentreSpecialization: "Centre specialization is required",
                EmailID: "Email address is required",

                CentreName: "Centre name is required",
                CentreCode: "Centre code is required",
                HoCoRoScFlag: "Office type is required",
                RoID: "RoID is required",
                OrganisationID: "Organisation id is required",
                UniversityID: "University id is required",
                CentreEstablishmentDatetime: "Centre Establishment date is required",
                CentreLoginNumber: "Centre login number is required",
                CentreSpecialization: "Centre specialization is required",
                CentreAddress: "Centre address is required",
                PlotNo: "Plot number is required",
                StreetName: "Street name is required",
                CityID: "City id is required",
                Pincode: "Pin code is required",
                FaxNumber: "Fax number is required",
                PhoneNumberOffice: "Office phone number is required",
                InstituteCode: "Institute code is required",
                TimeZone: "TimeZone is required",
                Latitude: "Latitude is required",
                Longitude: "Longitude is required",
                CampusArea: "CampusArea is required",


                CellPhone: "Cell phone number is required",
                EmailID: "Email id is required",
                Url: "Url is required"

            }
        });
    },
    LoadList: function () {
        $.ajax(
        {
            cache: false,
            type: "POST",
            dataType: "html",
            url: 'OrganisationStudyCentreMaster/List',
            success: function (data) {
                //Rebind Grid Data
                $('#ListViewModel').html(data);
            }
        });
    },
    ReloadList: function (message, colorCode, actionMode) {
        $.ajax(
       {
           cache: false,
           type: "POST",
           dataType: "html",
           data: { actionMode: actionMode },
           url: 'OrganisationStudyCentreMaster/List',
           success: function (data) {
               //Rebind Grid Data
               $("#ListViewModel").empty().append(data);
               //twitter type notification
               //$('#SuccessMessage').html(message);
               //$('#SuccessMessage').delay(400).slideDown(400).delay(3000).slideUp(400).css('background-color', colorCode);
               notify(message, colorCode);
           }
       });
    },
    checkdatavalidations: function () {

    },
    GetStudyCentreHORO: function (selectedItem) {
        if (selectedItem == "SC") {
            $("#RoID").prop("disabled", false);
            var $ddlRegion = $("#RoID");
            var $RegionProgress = $("#states-loading-progress");
            $RegionProgress.show();
            $.ajax({
                cache: false,
                type: "GET",
                url: "/OrganisationStudyCentreMaster/GetStudyCentreHORO",
                data: { "HoCoRoScFlag": selectedItem },
                success: function (data) {
                    $ddlRegion.html('');
                    $('#RoID').append('<option value>------------------Select----------------</option>');
                    $.each(data, function (id, option) {

                        $ddlRegion.append($('<option></option>').val(option.id).html(option.name));
                    });
                    $RegionProgress.hide();

                },
                error: function (xhr, ajaxOptions, thrownError) {
                    alert('Failed to retrieve Head Office.');
                    $RegionProgress.hide();
                }
            });
        }
        else {
            $('#RoID').find('option').remove().end().append('');
            $("#RoID").prop("disabled", true);
        }
    },


    getValueUsingParentTag_Check_UnCheck: function () {
        var sList = "";
        var xmlParamList = "<rows>";
        var centerList = $("#checkboxlist1").val();
        if (centerList == null) {
            var centerLngth = 0;
        }
        else {
            var centerLngth = centerList.length;
        }
        
        
        //$('#checkboxlist input[type=checkbox]').each(function () {
        //for (var i = 0; i < centerLngth;) {

        //    //alert(centerList[i].split('~'));

        //    if ($("#checkboxlist1").val()!= "") {
        //        var sArray = [];
        //        sArray = centerList[i].split('~');
        //        //alert(sArray[0] + '--' + sArray[1]);
        //        if (this.checked == true && parseInt(sArray[1]) == 0) {
        //            //xmlInsert code here
        //            xmlParamList = xmlParamList + "<row>" + "<ID>" + sArray[1] + "</ID>" + "<UniversityID>" + sArray[0] + "</UniversityID>" + "<IsActive>1</IsActive>" + "</row>";
        //        }
        //        else if (this.checked == false && parseInt(sArray[1]) > 0) {
        //            //xmlUpdate code here
        //            xmlParamList = xmlParamList + "<row>" + "<ID>" + sArray[1] + "</ID>" + "<UniversityID>" + sArray[0] + "</UniversityID>" + "<IsActive>0</IsActive>" + "</row>";

        //        }
        //    }
        //    if (xmlParamList.length > 6)
        //        OrganisationStudyCentreMaster.SelectedUniversityIDs = xmlParamList + "</rows>";
        //    else
        //        OrganisationStudyCentreMaster.SelectedUniversityIDs = "0";
        //    i = i + 1;
        //}

        

        //$('#checkboxlist input[type=checkbox]').each(function () {
        //$('#checkboxlist :checked').each(function () {
        $('#checkboxlist option').each(function () {
            //alert($(this).val());
            

            if ($(this).val() != "on") {
                var sArray = [];
                sArray = $(this).val().split("~");
                
                if (this.selected == true && parseInt(sArray[1]) == 0) {
                    xmlParamList = xmlParamList + "<row>" + "<ID>" + sArray[1] + "</ID>" + "<UniversityID>" + sArray[0] + "</UniversityID>" + "<IsActive>1</IsActive>" + "</row>";
                }
                else if (this.selected == false && parseInt(sArray[1]) > 0) {
                    //xmlUpdate code here
                    xmlParamList = xmlParamList + "<row>" + "<ID>" + sArray[1] + "</ID>" + "<UniversityID>" + sArray[0] + "</UniversityID>" + "<IsActive>0</IsActive>" + "</row>";

                }
            }
            if (xmlParamList.length > 6)
                OrganisationStudyCentreMaster.SelectedUniversityIDs = xmlParamList + "</rows>";
            else
                OrganisationStudyCentreMaster.SelectedUniversityIDs = "0";
        });

    },
    //  @sIDs= <rows><row><ID>0</ID><UniversityID>1</UniversityID><IsActive>1</IsActive></row></rows>

    Success: function (data) {
        var splitData = data.split(',');
        if (data != null) {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            OrganisationStudyCentreMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        } else {
            //parent.$.colorbox.close();
            $.magnificPopup.close();
            OrganisationStudyCentreMaster.ReloadList(splitData[0], splitData[1], splitData[2]);
        }

    },

};
