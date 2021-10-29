var dataTable;
var newData;
$(document).ready(function () {
    $.ajax({
        url: '/Admin/Category/GetAll',
        type: 'GET',
        //data: { searchKey: searchKey },
        dataType: 'json',
        success: function (data, status, xhr) {
            debugger;
            newData = data.data;
            loadDataTable(newData);
        },
        error: function () {
        }
    });
    //loadDataTable();
});


function loadDataTable(newData) {
    debugger;
    dataTable = $('#tblCategoryData').DataTable({
        "data": newData,
        "columns": [
            { "data": "id", "width": "5%" },
            { "data": "name", "width": "20%" },
            {
                "data": "id",
                "render": function (newData) {
                    return `
                            <div class="text-center">
                                <a href="/Admin/User/Upsert/${newData}" class="btn btn-success text-white" style="cursor:pointer">
                                    <i class="fas fa-edit"></i> 
                                </a>
                                <a onclick=Delete("/Admin/User/Delete/${newData}") class="btn btn-danger text-white" style="cursor:pointer">
                                    <i class="fas fa-trash-alt"></i> 
                                </a>
                            </div>
                           `;
                }, "width": "40%"
            }
        ]
    });
}
