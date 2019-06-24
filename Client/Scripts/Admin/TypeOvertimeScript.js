$(document).ready(function () {
    LoadIndexTypeOvertime();
    $('#table').DataTable({
        "ajax": LoadIndexTypeOvertime()
    })
})

function LoadIndexTypeOvertime() {
    $.ajax({
        type: "GET",
        async: false,
        url: "/TypeOvertimes/LoadTypeOvertime/",
        dataType: "json",
        success: function (data) {
            var html = '';
            var i = 1;
            $.each(data, function(index, val){
                html += '<tr>';
                html += '<td>' + i + '</td>';
                html += '<td>' + val.OvertimeType + '</td>';
                html += '<td>' + '<a href="#" class="fa fa-pencil" onclick=return GetById(' + val.Id + ')">Edit</a>';
                html += '| <a href="#" class="fa fa-trash" onclick=return Delete(' + val.Id + ')">Deleter</a></td>';
                html += '</tr>';
                i++;
            });
            $('.tbody').html(html);
        }
    });
}