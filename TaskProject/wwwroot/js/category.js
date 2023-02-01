var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Category/GetAll"
        },
        "columns": [
            { "data": "name", "width": "15%" },
            { "data": "description", "width": "15%" },
            { "data": "isActive", "width": "15%" },
            {
                "data": "categoryId",
                "render": function (data) {
                    return `
                        <div class="w-75 btn-group"  role="group" >
                            <a class="btn btn-primary mx-2" onclick="outputEdit('Category/Edit/?id=${data}', 'Edit Category')"> Edit </a>
                            <a class="btn btn-danger mx-2" onclick="outputDelete('Category/Delete/?id=${data}', 'Delete Category')"> Delete </a>
                            <a class="btn btn-secondary mx-2" onclick="outputChild('Category/SubCategory/?id=${data}', 'Add a new child')"> Add Child </a>
                        </div>
                        `
                },
                "width": "15%"
            }
        ]
    });
}



function outputEdit(url, title) {
    $.ajax({
        type: "GET",
        url: url,
        success: function (data) {
            $('#popOutput .modal-body').html(data);
            $('#popOutput .modal-title').html(title);
            $('#popOutput').modal('show');
        }
    })
}

function outputDelete(url, title) {
    $.ajax({
        type: "GET",
        url: url,
        success: function (data) {
            $('#popOutput .modal-body').html(data);
            $('#popOutput .modal-title').html(title);
            $('#popOutput').modal('show');
        }
    })
}


function outputChild(url, title) {
    $.ajax({
        type: "GET",
        url: url,
        success: function (data) {
            $('#popOutput .modal-body').html(data);
            $('#popOutput .modal-title').html(title);
            $('#popOutput').modal('show');
        }
    })
}