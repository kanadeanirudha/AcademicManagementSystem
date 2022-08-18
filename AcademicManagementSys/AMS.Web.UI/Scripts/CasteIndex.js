
$(document).ready(function () {

    var oTable = $('#myDataTable').dataTable({
        "bServerSide": true,
        "sAjaxSource": "CasteMaster/AjaxHandler",
        "bProcessing": true,
        "aoColumns": [
                        { "sName": "CasteID" },
			            { "sName": "Category" },
                        { "sName": "cast" },
                        {
                            "sName": "ID",
                            "bSearchable": false,
                            "bSortable": false,
                            "fnRender": function (oObj) {
                                var result = '@Html.ActionLink("Edit","Edit",' + oObj.aData[3] + ')';
                                //return '<a href=\"CasteMaster/Edit/' + oObj.aData[3] + ' \"><img src="Content/images/index.jpg"/></a>';
                                //return  '<a href="#" id="dynamicLink"><img src="Content/images/index.jpg"/></a>';
                                //$("#dynamicLink").attr("href", result);
                                return result;
                            }


                        },
                        {
                            "sName": "ID",
                            "bSearchable": false,
                            "bSortable": false,
                            "fnRender": function (oObj) {
                                return '<a href=\"CasteMaster/Create/' + oObj.aData[4] + ' new { id = "lnkCreate" }\"><img src="Content/images/view_details_icon.gif"/></a>';

                            }
                        },
                        {
                            "sName": "ID",
                            "bSearchable": false,
                            "bSortable": false,
                            "fnRender": function (oObj) {
                                return '<a href=\"CasteMaster/Delete/' + oObj.aData[5] + '\"><img src="Content/images/indexDelete.jpg"/></a>';

                            }
                        }


        ]
    });

   
});



