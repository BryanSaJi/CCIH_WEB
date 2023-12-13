
    $(document).ready(function () {
        $('#DataTable').DataTable({
            "language": {
                buttons: {
                    print: 'Imprimir'
                },
                "url": "//cdn.datatables.net/plug-ins/1.10.16/i18n/Spanish.json"
            },
            dom: 'Bfrtlip',
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
            scrollX: true
        });
        table.buttons().container()
            .appendTo('#example_wrapper .col-md-6:eq(0)');
    });