var primaryKeyColumn = {
    hidden: true,
    key: true,
    editable: false,
    editoptions: { autocomplete: "off" },
    hidedlg: true

};

var textColumn = {
    edittype: "text",
    editable: true,
    editrules: {
        required: true,
        edithidden: true
    },
    width: 300,
    minResizeWidth: 300,
    stype: "text",
    searchoptions: {
        sopt: ["eq", "nq", "bw", "ew", "cn", "nc"]
    },
    editoptions: { autocomplete: "off" },
    coloptions: {
        filtering: false,
        grouping: false,
        freeze: false

    }
};

var textAreaColumn = {
    edittype: "textarea",
    editable: true,
    editrules: {
        required: true,
        edithidden: true
    },
    width: 300,
    minResizeWidth: 300,
    stype: "text",
    searchoptions: {
        sopt: ["eq", "nq", "bw", "ew", "cn", "nc"]
    },
    editoptions: {
        autocomplete: "off",
        rows: "2",
        cols: "10",
        dataInit: function (elem) {
            $(elem).css("resize", "none");
            $(elem).css("width", "98%");
        }
    },
    coloptions: {
        filtering: false,
        grouping: false,
        freeze: false

    }
};



var integerColumn = {
    edittype: "text",
    editable: true,
    editrules: {
        integer: true,
        required: true,
        edithidden: true,
        number: true,
    },
    width: 200,
    minResizeWidth: 200,
    stype: "text",
    search: true,
    searchoptions: {
        sopt: ["eq", "ne", "lt", "le", "gt", "ge"]
    },
    editoptions: { autocomplete: "off" },
    coloptions: {
        filtering: false,
        grouping: false,
        freeze: false

    }
};

var decimalColumn = {
    edittype: "text",
    editable: true,
    editrules: {
        integer: false,
        required: true,
        edithidden: true,
        number: true
    },
    width: 200,
    minResizeWidth: 200,
    stype: "text",
    search: true,
    searchoptions: {
        sopt: ["eq", "ne", "lt", "le", "gt", "ge"]
    },
    editoptions: { autocomplete: "off" },
    coloptions: {
        filtering: false,
        grouping: false,
        freeze: false
    },
    formatter: "number",
    formatoptions: { decimalSeparator: ".", decimalPlaces: 2 }
};

var integerAsBoolColumn = {
    search: true,
    editable: true,
    edittype: "checkbox",
    editrules: {
        required: true,
        edithidden: true

    },
    width: 200,
    minResizeWidth: 200,
    stype: "select",
    searchoptions: {
        value: ":;1:активно;0:неактивно",
        sopt: ["eq"]
    },
    editoptions: {
        value: "1:0",
        autocomplete: "off",
        defaultValue: "0"
    },
    align: "center",
    formatter: 'checkbox',
    coloptions: {
        filtering: false,
        grouping: false,
        freeze: false

    }
};

var boolColumn = {
    search: true,
    editable: true,
    edittype: "checkbox",
    editrules: {
        required: true,
        edithidden: true

    },
    width: 200,
    minResizeWidth: 200,
    stype: "select",
    searchoptions: {
        value: ":;true:active;false:unactive",
        sopt: ["eq"]
    },
    editoptions: {
        value: "true:false",
        autocomplete: "off",
        defaultValue: "false"
    },
    align: "center",
    formatter: 'checkbox',
    coloptions: {
        filtering: false,
        grouping: false,
        freeze: false

    }
};

var dateColumn = {
    edittype: "text",
    editable: true,
    width: 150,
    minResizeWidth: 150,
    stype: "text",
    formatter: "date",
    formatoptions: {
        srcformat: "d.m.Y",
        newformat: "d.m.Y"
    },

    editoptions: {
        autocomplete: "off",
        formatter: "date",
        formatoptions: {
            newformat: "d.m.Y"
        },
        dataInit: function (element) {
            var currentDate = new Date();
            $(element).datepicker({
                autoclose: true,
                format: "dd.mm.yyyy",
                orientation: "bottom",
                language: "sr",
                todayHighlight: true,
                defaultViewDate: { year: currentDate.getFullYear(), month: currentDate.getMonth(), day: currentDate.getDate() }
            }).on('hide', function (ev) {
                setTimeout(function() {
                    $(element).blur();
                });
            });
        },
        editrules: {
            date: true,
            edithidden: true

        },
        dataEvents: [
            {
                type: 'keydown', fn: function (e) {
                    if (e.keyCode !== 9) {
                        e.preventDefault();
                        e.stopPropagation();
                    }

                }
            }
        ]
    },
    searchoptions: {
        autocomplete: "off",
        editable: true,
        width: 150,
        minResizeWidth: 150,
        stype: "text",
        formatter: "date",
        formatoptions: {
            newformat: "d.m.Y"
        },
        dataInit: function (element) {
            var currentDate = new Date();
            $(element).datepicker({
                autoclose: true,
                format: "dd.mm.yyyy",
                orientation: "bottom",
                language: "sr",
                todayHighlight: true,
                defaultViewDate: { year: currentDate.getFullYear(), month: currentDate.getMonth(), day: currentDate.getDate() }
            }).on('changeDate', function (e) {
                setTimeout(function () {
                    var clossestJqGridViewId = element.closest('.ui-jqgrid-view').id;
                    var gridId = clossestJqGridViewId.replace('gview_', '');
                    var jqgrid = $("#" + gridId)[0];
                    jqgrid.triggerToolbar();
                }, 100);

            });

        },

        sopt: ["eq", "lt", "le", "gt", "ge"],
        dataEvents: [
            {
                type: 'keydown', fn: function (e) {
                    e.preventDefault();
                    e.stopPropagation();
                }
            }
        ]
    },
    editrules: {
        date: true, required: true,
        edithidden: true

    },
    coloptions: {
        filtering: false,
        grouping: false,
        freeze: false
    },
};

var SelectForCreateOrUpdate = {
    hidden: true,
    edittype: 'select',
    hidedlg: true,
    editable: true,
    editrules: {
        edithidden: true,
        required: true
    },
    viewable: false

};

function getErrorMessageFromResponse(data) {
    var response = data.responseJSON;
    if (response.hasOwnProperty("error"))
        return response.error;
    return null;
}

function CreateSubGridTable(childGridId, childGridPagerId) {
    var div = $("<div></div>");
    var subGridTable = $("<table id=" + childGridId + "></table>");
    var subGridPager = $("<table id=" + childGridPagerId + "></table>");

    div.append(subGridTable);
    div.append(subGridPager);
    return div;
}

function removeUnusedTdsFromViewModal(gridId) {

    $('#ViewTbl_' + gridId + ' tr').each(function () {
        var tds = $(this).children("td");
        tds.each(function () {
            var tdData = $(this).html().trim();
            if (tdData === '')
                $(this).remove();
        });

    });
}

function removeUnusedTdsFromEditModal(gridId) {
    $('#TblGrid_' + gridId + ' tr').each(function () {
        var tds = $(this).children("td");
        tds.each(function () {
            var tdData = $(this).html().trim();
            if (tdData === '')
                $(this).remove();
        });

    });
}

function centerViewModal(gridId) {
    centerDialog('viewmod', gridId);
}

function centerEditModal(gridId) {
    centerDialog('editmod', gridId);
}

function centerDeleteModal(gridId) {
    centerDialog('delmod', gridId);
}

function centerDialog(prefix, gridId) {

    var name = $("#" + prefix + gridId);
    var dlgDiv = $(name);

    var parentDiv = dlgDiv.parent();
    var dlgWidth = dlgDiv.width();
    var dlgHeight = dlgDiv.height();
    var parentWidth = parentDiv.width();
    var parentHeight = parentDiv.height();
    var parentLeft = parentDiv.offset().left;
    var parentTop = parentDiv.offset().top;

    dlgDiv[0].style.left = Math.round(parentLeft + (parentWidth - dlgWidth) / 2) + "px";
    //dlgDiv[0].style.top = Math.round(parentTop + (parentHeight - dlgHeight) / 2) + "px";
}


function addLineAboveActions(span) {
    span = 1;
    $("#Act_Buttons")
        .before('<tr style="height:2px !important;"><td style="width:100%;height:2px !important;" colspan="' + span + '"><hr style="height:2px; margin:0;"></td></tr>');
}

function spanTd(columnId, span) {
    $('#' + columnId).attr('colspan', span);
}

function prepareViewModal(form) {
    if (form === undefined || form === null)
        console.error("prepareViewModal mora da primi parametar form iz funkcije beforeShowForm");
    var formId = form[0].firstChild.id;
    var gridId = formId.replace("ViewTbl_", "");

    var table = $('#ViewTbl_' + gridId);
    table.css('table-layout', 'fixed');
    table.css('height', 'auto');
    table.css('border-collapse', 'separate');

    var dataCells = $('#ViewTbl_' + gridId + ' tr td.DataTD ');
    dataCells.css('border', '1px solid #cccccc');
    dataCells.css('vertical-align', 'middle');
    dataCells.css('border-radius', '5px');
    dataCells.css('background-color', '#fafafa');

    $('#ViewTbl_' + gridId + ' tr').css('height', 'auto');

    var tds = $('#ViewTbl_' + gridId + ' tr td');
    tds.css('height', 'auto');
    tds.css('white-space', 'normal');
    tds.css('word-break', 'break-all');

    $('#ViewGrid_' + gridId).css('max-height', '60vh');

    removeUnusedTdsFromViewModal(gridId);

    //centerViewModal(gridId);
}

function prepareEditModal(form) {
    var formId = form[0].id;
    var gridId = formId.replace("FrmGrid_", "");

    removeUnusedTdsFromEditModal(gridId);

    $('#TblGrid_' + gridId).css('table-layout', 'fixed');
    $('#FrmGrid_' + gridId).css('max-height', '60vh');
    centerEditModal(gridId);
}

function prepareDeleteModal(form) {

    //var formId = form[0].id;
    //var gridId = formId.replace("DelTbl_", "");
    //centerDeleteModal(gridId);
}

function setWidthOfElement(element, width) {
    $(element).css('width', width);
}

function setWidthOfTextArea(element, colspan, width, resize) {
    if (resize === null || resize === undefined)
        resize = false;
    if (width === null || width === undefined)
        width = '100%';
    if (colspan === null || colspan === undefined)
        colspan = 1;

    $(element).parent().attr("colspan", colspan);
    $(element).css('width', width);

    if (resize === false)
        $(element).css("resize", "none");

}

function setMaxHeightForElement(jqGridId, value) {
    if (value === null || value === undefined)
        value = '60vh';
    $(jqGridId).closest('div.ui-jqgrid-bdiv').css('max-height', value);
}

function GetSelectedRowData(jqGridObject) {
    var selRowId = GetSelectedRowId(jqGridObject);
    return jqGridObject.jqGrid('getRowData', selRowId);
}

function GetSelectedRowId(jqGridObject) {
    return jqGridObject.jqGrid('getGridParam', 'selrow');
}

function disableAdd(jqGridObject) {
    $("#add_" + jqGridObject[0].id).addClass('ui-disabled');
}

function enableAdd(jqGridObject) {
    $("#add_" + jqGridObject[0].id).removeClass('ui-disabled');
}

function disableDelete(jqGridObject) {
    $("#del_" + jqGridObject[0].id).addClass('ui-disabled');
}

function enableDelete(jqGridObject) {
    $("#del_" + jqGridObject[0].id).removeClass('ui-disabled');
}

function disableEdit(jqGridObject) {
    $("#edit_" + jqGridObject[0].id).addClass('ui-disabled');
}

function enableEdit(jqGridObject) {
    $("#edit_" + jqGridObject[0].id).removeClass('ui-disabled');
}

function SpanColumnsForElement(element, colsToSpan) {
    $(element).parent().attr("colspan", colsToSpan);
    setTimeout(function () {
        for (var i = 0; i < colsToSpan; i++)
            $(element).parent().next().remove();
    },
        0);

}

function disableElement(jQueryObject) {
    jQueryObject.attr('disabled', 'disabled');
}

function enableElement(jQueryObject) {
    jQueryObject.attr('disabled', false);
}

function removeSelectTag(select) {
    select = select.replace("<select>", "");
    select = select.replace("</select>", "");
    return select;
}