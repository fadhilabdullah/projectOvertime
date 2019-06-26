$(document).ready(function () {
    LoadIndexDataOvertime();
    LoadTypeProject();
    $('#TableDataOvertime').DataTable({
        "ajax": LoadIndexDataOvertime()
    });
})

function Save() {
    var DataOvertime = new Object();
    DataOvertime.Employee_Id = $('#Name').val();
    DataOvertime.Date = $('#Date').val();
    DataOvertime.Pay_Overtime = $('#Pay_Time').val();
    DataOvertime.Start_Time = $('#Start_Time').val();
    DataOvertime.End_Time = $('#End_Time').val();
    DataOvertime.Type_Id = $('#TypeOvertime_Id').val();
    DataOvertime.Attachment_Overtime = $('#Attachment_Overtime').val();
    DataOvertime.Description = $('#Description').val();
    DataOvertime.Activity = $('#Activity').val();
    $.ajax({
        url: "/DataOvertimes/InsertOrUpdate/",
        data: DataOvertime,
        success: function (result) {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
            function () {
                window.location.href = '/DataOvertimes/Index/';
            });
            LoadIndexDataOvertime();
            $('#myModal').modal('hide');
            ClearScreen();
        }
    });
};


function LoadTypeProject() {
    $.ajax({
        type: "GET",
        async: false,
        url: "/DataOvertimes/GetTypeProject/",
        dataType: "json",
        success: function (data) {
            console.log(data);
            var html = '';
            $.each(data,
                function (index, val) {
                    html += ' <option value="' + val.Id + '">' + val.Name_Type + '</option>';
                });

            $('#TypeOvertime_Id').html(html);
        }
    });
}

function LoadIndexDataOvertime() {
    $.ajax({
        type: "GET",
        async: false,
        url: "/DataOvertimes/LoadDataOvertime/",
        dateType: "json",
        success: function (data) {
            var html = '';
            var i = 1;
            $.each(data, function (index, val) {
                html += '<tr>';
                html += '<td>' + i + '</td>';
                html += '<td><a href="#" class="fa fa-pencil" onclick="return GetById(' + val.Id + ')">Edit</a>';
                html += ' | <a href="#" class="fa fa-trash" onclick="return Delete(' + val.Id + ')">Delete</a></td>';
                html += '<td>' + val.Employee_Id + '</td>';
                html += '<td>' + moment(val.Date).format("MM/DD/YYYY") + '</td>';
                html += '<td>' + val.Start_Time + '</td>';
                html += '<td>' + val.End_Time + '</td>';
                html += '<td>' + val.TypeOvertime.Name_Type + '</td>';
                html += '<td>' + val.Attachment_Overtime + '</td>';
                html += '<td>' + val.Description + '</td>';
                html += '<td>' + val.Activity + '</td>';
                html += '<td>' + val.Pay_Overtime + '</td>';
                html += '</tr>';
                i++;
            });
            $('.tbody').html(html);
        }
    });
}

function Edit() {
    var DataOvertime = new Object();
    DataOvertime.Id = $('#Id').val();
    DataOvertime.Employee_Id = $('#Name').val();
    DataOvertime.Date = $('#Date').val();
    DataOvertime.Pay_Overtime = $('#Pay_Time').val();
    DataOvertime.Start_Time = $('#Start_Time').val();
    DataOvertime.End_Time = $('#End_Time').val();
    DataOvertime.Type_Id = $('#TypeOvertime_Id').val();
    DataOvertime.Attachment_Overtime = $('#Attachment_Overtime').val();
    DataOvertime.Description = $('#Description').val();
    DataOvertime.Activity = $('#Activity').val();
    $.ajax({
        url: "/DataOvertimes/InsertOrUpdate/",
        data: DataOvertime,
        success: function (result) {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
            function () {
                window.location.href = '/DataOvertimes/Index/';
            });
            LoadIndexDataOvertime();
            $('#myModal').modal('hide');
            ClearScreen();
        }
    });
};

function GetById(Id) {
    $.ajax({
        url: "/DataOvertimes/GetById/",
        type: "GET",
        dataType: "json",
        data: { id: Id },
        success: function (result) {
            $('#Id').val(result.Id);
            $('#Name').val(result.Employee_Id);
            $('#Date').val(moment(result.Date).format('MM/DD/YYYY'));
            $('#Pay_Time').val(result.Pay_Overtime);
            $('#Start_Time').val(result.Start_Time);
            $('#End_Time').val(result.End_Time);
            $('#TypeOvertime_Id').val(result.Type_Id);
            $('#Attachment_Overtime').val(result.Attachment_Overtime);
            $('#Description').val(result.Description);
            $('#Activity').val(result.Activity);

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
            url: "/DataOvertimes/Delete/",
            data: { id: Id },
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft delete!",
                    type: "success"
                },
                    function () {
                        window.location.href = '/DataOvertimes/Index/';
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