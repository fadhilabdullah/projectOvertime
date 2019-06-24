$(document).ready(function () {
    LoadIndexTypeOvertime();
    $('#table').DataTable({
        "ajax": LoadIndexTypeOvertime()
    });
})

function Save() {
    var TypeOvertime = new Object();
    TypeOvertime.name = $('#Name').val();
    $.ajax({
        url: "/TypeOvertimes/InsertOrUpdate/",
        data: TypeOvertime,
        success: function (result) {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
            function () {
                window.location.href = '/TypeOvertimes/Index/';
            });
            LoadIndexTypeOvertime();
            $('#myModal').modal('hide');
            ClearScreen();
        }
    });
};

function LoadIndexTypeOvertime() {
    $.ajax({
        type: "GET",
        async: false,
        url: "/TypeOvertimes/LoadTypeOvertime/",
        dateType: "json",
        success: function (data) {
            var html = '';
            var i = 1;
            $.each(data, function (index, val) {
                html += '<tr>';
                html += '<td>' + i + '</td>';
                html += '<td>' + val.Employee.Name + '</td>';
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
    var TypeOvertime = new Object();
    TypeOvertime.id = $('#Id').val();
    TypeOvertime.name = $('#Name').val();
    $.ajax({
        url: "/TypeOvertimes/InsertOrUpdate/",
        data: TypeOvertime,
        success: function (result) {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
            function () {
                window.location.href = '/TypeOvertimes/Index/';
            });
            LoadIndexTypeOvertime();
            $('#myModal').modal('hide');
            ClearScreen();
        }
    });
};

function GetById(Id) {
    $.ajax({
        url: "/TypeOvertimes/GetById/",
        type: "GET",
        dataType: "json",
        data: { id: Id },
        success: function (result) {
            $('#Id').val(result.Id);
            $('#Name').val(result.Employee.Name);
            $('#Pay').val(result.Pay_Overtime);
            $('#Start').val(result.Start_Overtime);
            $('#End').val(result.End_Overtime);
            $('#Attachment').val(result.Attachment_Overtime);
            $('#Description').val(result.Description);
            $('#Activity').val(result.Activity);
            $('#Submited').val(result.Submited.Name_Submited);
            $('#Type').val(result.TypeOvertime.OvertimeType);

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
            url: "/TypeOvertimes/Delete/",
            data: { id: Id },
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft delete!",
                    type: "success"
                },
                    function () {
                        window.location.href = '/TypeOvertimes/Index/';
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