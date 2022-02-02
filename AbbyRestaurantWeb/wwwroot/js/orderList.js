var dataTable;

$(document).ready(function () {
    var url = window.location.search;
    if (url.includes("cancelled")) {
        loadList("cancelled");
    }
    else {
        if (url.includes("completed")) {
            loadList("completed");
        }
        else {
            if (url.includes("ready")) {
                loadList("ready");
            }
            else {
                loadList("inprocess");
            }
        }
    }
});

function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload();
                        toastr.success(data.message);
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            })
        }
    })
}

function loadList(param) {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/order?status=" + param,
            "type": "GET",
            "dataType": "json"
        },
        "columns": [
            { "data": "id", "width": "10%" },
            { "data": "pickupName", "width": "20%" },
            { "data": "applicationUser.email", "width": "20%" },
            { "data": "orderTotal", "width": "15%" },
            { "data": "pickUpTime", "width": "20%" },
            { "data": "status", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="w-75 btn-group">
                                <a href="/Admin/Order/OrderDetails?id=${data}" class="btn btn-outline-info btn-sm px-3" style="cursor: pointer,width:100px">
                                    <i class="bi bi-pencil-square"></i>
                                </a>
                            </div>`
                },
                "width": "25%"
            }
        ],
        "width": "100%"
    });
}