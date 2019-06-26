$(document).ready(function () {
    console.log("Ready...");
    $('#table').DataTable({
        "processing": true,
        "serverSide": true,
        "info": true,
        "responsive": true,
        "ajax": {

        }
    })
})