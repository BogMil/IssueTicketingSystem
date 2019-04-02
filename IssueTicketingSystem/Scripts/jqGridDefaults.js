//$.extend($.jgrid.edit, { recreateForm: true });

//condesed table
$.jgrid.styleUI.Bootstrap.base.headerTable = "table table-bordered table-condesed";
$.jgrid.styleUI.Bootstrap.base.rowTable = "table table-bordered table-condesed";
$.jgrid.styleUI.Bootstrap.base.footerTable = "table table-bordered table-condesed";
$.jgrid.styleUI.Bootstrap.base.pagerTable = "table table-condesed";

    $.jgrid.defaults.styleUI = 'Bootstrap';
$.jgrid.defaults.responsive = false;
$.jgrid.defaults.mtype = "GET";
$.jgrid.defaults.datatype = "json";
$.jgrid.defaults.prmNames = {
    page: "CurrentPageNumber",
    rows: "NumberOfRowsToDisplay",
    sort: "OrderByColumn",
    order: "OrderDirection"
};
//$.jgrid.defaults.minColWidth = 200;
$.jgrid.defaults.rownumbers = true;
$.jgrid.defaults.viewrecords = true;
$.jgrid.defaults.height = 'auto';
$.jgrid.defaults.rowNum = 20;
//$.jgrid.defaults.rowList = [5, 10, 20, 50, 100];
$.jgrid.defaults.autowidth = false;
$.jgrid.defaults.shrinkToFit = false;
$.jgrid.defaults.sortable = true;
$.jgrid.defaults.altRows = true;
$.jgrid.defaults.colMenu = false;
$.jgrid.defaults.jsonReader = {
    total: "TotalNumberOfPages",
    page: "CurrentPageNumber",
    records: "TotalNumberOfRecords",
    root: "Records"
};
$.jgrid.defaults.treeReader = {
    parent_id_field: "ParentId",
    level_field: "Level",
    leaf_field: "IsLeaf",
};


//defaultNavGridOptions
$.jgrid.regional["en"].nav.edit = true;
$.jgrid.regional["en"].nav.add = true;
$.jgrid.regional["en"].nav.del = true;
$.jgrid.regional["en"].nav.search = false;
$.jgrid.regional["en"].nav.view = true;
$.jgrid.regional["en"].nav.refresh = false;
$.jgrid.regional["en"].nav.errorTextFormat = function (data) {
    return "Error: " + data.responseText;
};

//defaultEditModalOptions
$.jgrid.regional["en"].edit.closeAfterEdit= true;
$.jgrid.regional["en"].edit.recreateForm= true;
$.jgrid.regional["en"].edit.afterSubmit= afterSubmit;
$.jgrid.regional["en"].edit.afterComplete= afterComplete;
$.jgrid.regional["en"].edit.resize= false;
$.jgrid.regional["en"].edit.modal= true;
$.jgrid.regional["en"].edit.beforeShowForm= function (form) {
    //prepareEditModal(form);
}

//defaultAddModalOptions
$.jgrid.regional["en"].edit.closeAfterAdd = true;
//plus defaultEditModalOptions

//default deleteModalOptions
$.jgrid.regional["en"].del.recreateForm= true;
$.jgrid.regional["en"].del.afterSubmit= afterSubmit;
$.jgrid.regional["en"].del.afterComplete = afterComplete;
$.jgrid.regional["en"].del.beforeShowForm = function(form) {
    prepareDeleteModal(form);
};

//defaultViewModalOptions
$.jgrid.regional["en"].view.resize = false;
$.jgrid.regional["en"].view.modal = true;
$.jgrid.regional["en"].view.beforeShowForm = function(form) {
    prepareViewModal(form);
};

function afterSubmit(data, postdata) {
    var errorMessage = getErrorMessageFromResponse(data);
    if (errorMessage !== null) {
        return [false, errorMessage, ""];
    }
    return [true, "", ""];
}

function afterComplete(response, postdata, formid) {

    //var successMessage = getSuccessMessageFromResponse(response);
    //alert("success: " + successMessage.success);

    //$.alert({
    //    title: 'Poruka',
    //    content: 'Uspesno!',
    //    theme: 'modern'
    //});

}



