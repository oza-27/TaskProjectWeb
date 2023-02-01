// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

outputCreate = (url, title) => {
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
