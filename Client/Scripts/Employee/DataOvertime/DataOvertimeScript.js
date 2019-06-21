$(document).ready(function () {                     //ini yg akan jln duluan
    LoadIndexDataOvertime();
    $('#table').DataTable({                         //manggil berdasarkan id, krn # utk id, dan akan menjalankan function DataTable
        "ajax": LoadIndexDataOvertime()             //untuk mengelolah data dari LoadIndexDataOvertime
    })
})

function LoadIndexDataOvertime() {
    $.ajax({
        type: "GET",
        async: false,
        url: "/DataOvertimes/LoadDataOvertime",           //LoadDataOvertime itu action atau method
        dataType: "json",                           //penampilan datanya
        success: function (data) {  
            var html = '';
            var i = 1;                              //untuk nomer urut
            $.each(data, function(index, val){
                html += '<tr>';
                html += '<td>' + i + '</td>';
                html += '<td>' + val.Employee.Name + '</td>';
                html += '<td>' + val.Pay_Overtime + '</td>';
                html += '<td>' + val.Start_Overtime + '</td>';
                html += '<td>' + val.End_Overtime + '</td>';
                html += '<td>' + val.Attachment_Overtime + '</td>';
                html += '<td>' + val.Description + '</td>';
                html += '<td>' + val.Activity + '</td>';
                html += '<td>' + val.Submited.Name_submited + '</td>';
                html += '<td>' + val.TypeOvertime.OvertimeType + '</td>';
                html += '<td>' + '<a.haref="#" class="fa fa-pencil" onclick=return GetById(' + val.Id + ')">Edit<tr>';              //line 21 dan 22 untuk kolom action di table
                html += ' | <a href="#" class="fa fa-trash" onclick=return Delete(' + val.Id + ')">Delete</a></td>';
                html += '</tr>';
                i++;
            });
            $('.tbody').html(html);            
        }
    })
}