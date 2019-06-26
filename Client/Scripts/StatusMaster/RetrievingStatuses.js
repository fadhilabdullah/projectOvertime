$(document).ready(function () {
    LoadIndexStatuse();
    $('#table').DataTable({
        "ajax": LoadIndexStatuses()
    });
})

function Save() {
    var Status = new Object();
    Status.Name_Status = $('#Name').val();
    Status.Status = $('#Status').val();
    $.ajax({
        url: "/Statuses/InsertOrUpdate/",
        data: Status,
        success: function (result) {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
            function () {
                window.location.href = '/Statuses/Index/';
            });
            LoadIndexStatuses();
            $('#myModal').modal('hide');
            ClearScreen();
        }
    });
};

function LoadIndexStatuses() {
    $.ajax({
        type: "GET",
        async: false,
        url: "/Statuses/LoadStatus/",
        dateType: "json",
        success: function (data) {
            var html = '';
            var i = 1;
            $.each(data, function (index, val) {
                html += '<tr>';
                html += '<td>' + i + '</td>';
                html += '<td>' + val.Name_Status + '</td>';
                html += '<td>' + val.Status + '</td>';
                html += '<td><a href="#" class="fa fa-pencil" onclick="return GetById(' + val.Id + ')">Edit</a>';
                html += ' | <a href="#" class="fa fa-trash" onclick="return Delete(' + val.Id + ')">Delete</a></td>';
                html += '</tr>';
                i++;
            });
            $('.tbody').html(html);
        }
    });
}

function Edit() {
    var Status = new Object();
    Status.id = $('#Id').val();
    Status.Name_Status = $('#Name').val();
    Status.status = $('#Status').val();
    $.ajax({
        url: "/Statuses/InsertOrUpdate/",
        data: Status,
        success: function (result) {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
            function () {
                window.location.href = '/Statuses/Index/';
            });
            LoadIndexStatus();
            $('#myModal').modal('hide');
            ClearScreen();
        }
    });
};

function GetById(Id) {
    $.ajax({
        url: "/Statuses/GetById/",
        type: "GET",
        dataType: "json",
        data: { id: Id },
        success: function (result) {
            $('#Id').val(result.Id);
            $('#Name').val(result.Name_Status);
            $('#Status').val(result.Status);

            $('#myModal').modal('show');
            $('#Update').show();
            $('#Save').hide();
        },
        error: function (response) {
            swal("Oops", "We couldn't connect to the server!", "error");
        }
    });
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
            url: "/Statuses/Delete/",
            data: { id: Id },
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft delete!",
                    type: "success"
                },
                    function () {
                        window.location.href = '/Statuses/Index/';
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