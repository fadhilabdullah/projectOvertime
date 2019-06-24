$(document).ready(function () {
    LoadIndexParameter();
    $('#table').DataTable({
        "ajax": LoadIndexParameter()
    })
})

function LoadIndexParameter() {
    $.ajax({
        type: "GET",
        async: false,
        url: "/Parameters/LoadParameter/",
        dataType: "json",
        success: function (data) {
            var html = '';
            var i = 1;
            $.each(data, function(index, val){
                html += '<tr>';
                html += '<td>' + i + '</td>';
                html += '<td>' + val.Long_Time + '</td>';
                html += '<td>' + val.Pay + '</td>';
                html += '<td>' + '<a href="#" class="fa fa-pencil" onclick=return GetById(' + val.Id + ')">Edit</a>';
                html += '| <a href="#" class="fa fa-trash" onclick=return Delete(' + val.Id + ')">Deleter</a></td>';
                html += '</tr>';
                i++;
            });
            $('.tbody').html(html);
        }
    });
}