var page = 0,
    inCallback = false,
    hasReachedEndOfInfiniteScroll = false;

var scrollHandler = function () {
    if (hasReachedEndOfInfiniteScroll == false && ($(window).scrollTop() == $(document).height() - $(window).height()) && FeeStructureApplicable.IsLazyLoadActive == 1) {
            loadMoreToInfiniteScrollTable();
    }
}

function loadMoreToInfiniteScrollTable(loadMoreRowsUrl) {
    alert(page);
    if (page > -1 && !inCallback) {
        inCallback = true;
        page++;
        $("div#loading").show();
        $.ajax({
            type: 'GET',
            url: "/FeeStructureApplicable/GetStudentList",
            data: { "pageNum": page, ID: $("#FeeStructureMasterID").val() },
            success: function (data, textstatus) {
                if (String(data).length > 10) {
                    $("#tblData3.infinite-scroll > tbody").append(data);
                    $("#tblData3.infinite-scroll > tbody > tr:even").addClass("alt-row-class");
                    $("#tblData3.infinite-scroll > tbody > tr:odd").removeClass("alt-row-class");
                }
                else {
                    alert("haha");
                    page = -1;
                    showNoMoreRecords()
                }

                inCallback = false;
                $("div#loading").hide();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
            }
        });
    }
}

function showNoMoreRecords() {
    hasReachedEndOfInfiniteScroll = true;
}