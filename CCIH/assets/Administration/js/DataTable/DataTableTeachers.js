

// DataTables initialisation with buttons
let table = new DataTable('#DataTable', {
    dom: 'Bfrtlip', // B: Buttons, l: Length changing, f: Filtering, r: pRocessing, t: Table, i: Information, p: Pagination
    "language": {
        "url": "//cdn.datatables.net/plug-ins/1.10.16/i18n/Spanish.json"
    },
    buttons: [
        {
            extend: 'excelHtml5',
            text: '<i class="ri-file-excel-2-line text-success" style="font-size: 150%;"></i>',
            titleAttr: 'Excel',
            className: 'btn btn-outline-primary',
        },
        {
            extend: 'pdfHtml5',
            text: '<i class="bi bi-file-earmark-pdf text-danger" style="font-size: 150%;"></i>',
            titleAttr: 'PDF',
            className: 'btn btn-success',
        },
        {
            extend: 'print',
            text: '<i class="bi bi-printer-fill text-primary" style="font-size: 150%;"></i>',
            titleAttr: 'print',
            className: 'btn btn-success',
        }, 'colvis'
    ],
    responsive: true,
    scrollX: true,
});

table.buttons().container()
    .appendTo('#example_wrapper .col-md-6:eq(0)');



let minDate, maxDate;

// Custom filtering function which will search data in column four between two values
DataTable.ext.search.push(function (settings, data, dataIndex) {
    let min = minDate.val();
    let max = maxDate.val();

    let dateString = data[2];
    let date = moment(dateString, "DD/MM/YYYY HH:mm:ss").toDate();

    // Formatear min y max al formato DD/MM/YY si no son nulos
    if (min !== null) {
        min = moment(min, "DD/MM/YYYY HH:mm:ss").add(6, 'hours').toDate();
    }
    if (max !== null) {
        max = moment(max, "DD/MM/YYYY HH:mm:ss").add(29, 'hours').toDate();
    }

    if (
        (min === null && max === null) ||
        (min === null && date <= max) ||
        (min <= date && max === null) ||
        (min <= date && date <= max)
    ) {
       
        return true;
    }

    return false;
});

// Create date inputs
minDate = new DateTime('#min', {
    format: 'MMMM Do YYYY'
});


maxDate = new DateTime('#max', {
    format: 'MMMM Do YYYY'
});

// Refilter the table
document.querySelectorAll('#min, #max').forEach((el) => {
    el.addEventListener('change', () => table.draw());
});