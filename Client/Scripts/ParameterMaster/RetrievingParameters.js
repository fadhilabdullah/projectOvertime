$(document).ready(function () {
    LoadIndexParameter();
    $('#table').DataTable({
        "ajax": LoadIndexParameter()
    });
})

function Save() {
    var Parameter = new Object();
    Parameter.Long_Time = $('#LongTime').val();
    Parameter.Pay = $('#Pay').val();
    $.ajax({
        url: "/Parameters/InsertOrUpdate/",
        data: Parameter,
        success: function (result) {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
            function () {
                window.location.href = '/Parameters/Index/';
            });
            LoadIndexParameter();
            $('#myModal').modal('hide');
            ClearScreen();
        }
    });
};

function LoadIndexParameter() {
    $.ajax({
        type: "GET",
        async: false,
        url: "/Parameters/LoadParameter/",
        dateType: "json",
        success: function (data) {
            var html = '';
            var i = 1;
            $.each(data, function (index, val) {
                html += '<tr>';
                html += '<td>' + i + '</td>';
                html += '<td>' + val.Long_Time + '</td>';
                html += '<td>' + val.Pay + '</td>';
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
    var Parameter = new Object();
    Parameter.Id = $('#Id').val();
    Parameter.Long_Time = $('#LongTime').val();
    Parameter.Pay = $('#Pay').val();
    $.ajax({
        url: "/Parameters/InsertOrUpdate/",
        data: Parameter,
        success: function (result) {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
            function () {
                window.location.href = '/Parameters/Index/';
            });
            LoadIndexParameter();
            $('#myModal').modal('hide');
            ClearScreen();
        }
    });
};

function GetById(Id) {
    $.ajax({
        url: "/Parameters/GetById/",
        type: "GET",
        dataType: "json",
        data: { id: Id },
        success: function (result) {
            $('#Id').val(result.Id);
            $('#LongTime').val(result.Long_Time);
            $('#Pay').val(result.Pay);

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
            url: "/Parameters/Delete/",
            data: { id: Id },
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft delete!",
                    type: "success"
                },
                    function () {
                        window.location.href = '/Parameters/Index/';
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
    if ($('#Pay').val() == "" || $('#Pay').val() == " ") {
        swal("Oops", "Please Insert Name", "error")
    } else if ($('#Id').val() == "") {
        Save();
    } else {
        Edit();
    }
}