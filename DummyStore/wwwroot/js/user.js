var dataTable;
var newData;
$(document).ready(function () {
    $.ajax({
        url: '/Admin/User/GetAll',
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
    dataTable = $('#tblUserData').DataTable({
        //"ajax": {
        //    "url": "/Admin/User/GetAll"
        //},
        "data": newData,
        "columns": [
            { "data": "id", "width": "5%" },
            { "data": "fullName", "width": "20%" },
            { "data": "username", "width": "10%" },
            { "data": "email", "width": "20%" },
            { "data": "phone", "width": "20%" },
            { "data": "address.city", "width": "10%" },
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
