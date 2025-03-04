$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url:'/Admin/Product/GetAll'},
        "columns": [
            { data: "title" },
            { data: "author" },
            { data: "isbn" },
            { data: "price" },
            { data: "category.name" },
            {
                data: "id",
                render: function (data) {
                    return `<a href="/Admin/Product/Upsert/${data}" class="btn btn-warning">Edit</a>
                    <a href="/Admin/Product/Delete/${data}" class="btn btn-danger">Delete</a>`;
                }
            }
        ]
    });
}




