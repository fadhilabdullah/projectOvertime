﻿$(document).ready(function () {
    LoadIndexSubmited();
    $('#table').DataTable({
        "ajax": LoadIndexSubmited()
    });
})

function Save() {
    var submited = new Object();
    submited.name = $('#Name').val();
    submited.status = $('#Status').val();
    $.ajax({
        url: "/Submiteds/InsertOrUpdate/",
        data: submited,
        success: function (result) {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
            function () {
                window.location.href = '/Submiteds/Index/';
            });
            LoadIndexSubmited();
            $('#myModal').modal('hide');
            ClearScreen();
        }
    });
};

function LoadIndexSubmited() {
    $.ajax({
        type: "GET",
        async: false,
        url: "/Submiteds/LoadSubmited/",
        dateType: "json",
        success: function (data) {
            var html = '';
            var i = 1;
            $.each(data, function (index, val) {
                html += '<tr>';
                html += '<td>' + i + '</td>';
                html += '<td>' + val.Name_Submited + '</td>';
                html += '<td>' + val.Status + '</td>';
                html += '<td> <a href="#" class="fa fa-pencil" onclick="return GetById(' + val.Id + ')"></a>';
                html += ' | <a href="#" class="fa fa-trash" onclick="return Delete(' + val.Id + ')"></a></td>';
                html += '</tr>';
                i++;
            });
            $('.tbody').html(html);
        }
    });
}

function Edit() {
    var submited = new Object();
    submited.id = $('#Id').val();
    submited.name = $('#Name').val();
    submited.status = $('#Status').val();
    $.ajax({
        url: "/Submiteds/InsertOrUpdate/",
        data: submited,
        success: function (result) {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
            function () {
                window.location.href = '/Submiteds/Index/';
            });
            LoadIndexSubmited();
            $('#myModal').modal('hide');
            ClearScreen();
        }
    });
};

function GetById(Id) {
    $.ajax({
        url: "/Submiteds/GetById/",
        type: "GET",
        dataType: "json",
        data: { id: Id },
        success: function (result) {
            $('#Id').val(result.Id);
            $('#Name').val(result.Name_Submited);
            $('#Status').val(result.Status);

            $('#myModal').modal('show');
            $('#Update').show();
            $('#Save').hide();
        }
    })
}

function Delete(Id) {
    swal({
        title: "Are you sure?",
        text: "You will not be able to recover this imaginary file!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Yes, delete it!",
        closeOnConfirm: false
    }, function () {
        $.ajax({
            url: "/Submiteds/Delete/",
            data: { id: Id },
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft delete!",
                    type: "success"
                },
                    function () {
                        window.location.href = '/Submiteds/Index/';
                    });
            },
            error: function (response) {
                swal("Oops", "We couldn't connect to the server!", "error");
            }
        });
    });
}

function ClearScreen() {
    $('#Name').val('');
    $('#Id').val('');
    $('#Update').hide();
    $('#Save').show();
}

function Validate() {
    if ($('#Name').val() == "" || $('#Name').val() == " ") {
        swal("Oops", "Please Insert Name", "error")
    } else if ($('#Id').val() == "") {
        Save();
    } else {
        Edit();
    }
}