


$(document).ready(function () {


        $('#DataTable').on('click', '#EditFormButton', function () {
            // Obtener la fila correspondiente al botón presionado
            var row = $(this).closest('tr');
            // Obtener el valor de CourseName en la columna correspondiente
            var courseName = row.find('td:first').text();
            localStorage.setItem('courseName', courseName);
            // Asignar el valor al input del modal de edición
            $('#ModifyInfo').val(courseName);
        });


        $('#DataTable').on('click', '#DeleteFormButton', function () {
            // Obtener la fila correspondiente al botón presionado
            var row = $(this).closest('tr');
            // Obtener el valor de CourseName en la columna correspondiente
            var courseName = row.find('td:first').text();
            localStorage.setItem('DeletecourseName', courseName);
            
        });



       setTimeout(function () {
        var mensajeDiv = document.getElementById('mensajePositivo');
        if (mensajeDiv != null) {
            mensajeDiv.style.display = 'none';
        }

        var mensajeDiv2 = document.getElementById('mensajeNegativo');
        if (mensajeDiv2 != null) {
            mensajeDiv2.style.display = 'none';
        }


        $.ajax({
            url: '/Group/cleanSessionMessage', // Ruta del controlador y acción
            type: 'Get', // Método de solicitud (en este caso, POST)
            data: {},
            success: function (response) {


            },
            error: function (error) {

                // Manejar errores si los hay
            }
        });

        }, 3000); // 5000 milisegundos = 5 segundos



    $('#AddModalFormButton').click(function () {
        var courseName = $('#additionalInfo').val();

        if (courseName.length === 0) {
            // Input is empty
            $('#additionalInfo').after('<span class="error">El nombre del curso no puede estar vacío.</span>');
            return;
        }

        $.ajax({
            url: '/Course/CreateCourseCatalog', // Replace with your actual controller and action path
            method: "POST",
            data: { courseName: courseName },
            success: function (data) {
                // Handle success response from the controller
                if (data == 1) {
                    // Display success message and close the modal
                    $('#CreatebasicModal').modal('hide');
                    location.reload(); // Reload the page
                } else {
                    // Display error message
                    $('#CreatebasicModal').modal('hide');
                    location.reload(); // Reload the page
                }
            },
            error: function (error) {
                console.error(error);
            }
        });
    });




    $('#EditModalFormButton').click(function () {
        var courseName = $('#ModifyInfo').val();
        

        // Verificar si el nombre del curso no está vacío
        if (courseName.trim() === '') {
            // Mostrar un mensaje de error o tomar la acción apropiada
            return;
        }

        // Objeto con los datos a enviar
        var courseData = {
            CourseName: courseName,
            LastName: localStorage.getItem('courseName'),
        };

        $.ajax({
            url: '/Course/EditCourseCatalog', // Ruta del controlador y acción
            method: 'POST',
            data: courseData,
            success: function (data) {
                
                $('#EditbasicModal').modal('hide'); // Ocultar el modal
                location.reload(); // Reload the page
            },
            error: function (error) {
                $('#EditbasicModal').modal('hide'); // Ocultar el modal
                location.reload(); // Reload the page
            }
        });
    });





    $('#DeletetModalFormButton').click(function () {
        // Realizar la lógica para borrar el curso

        var courseData = {
            currentCourseName: localStorage.getItem('DeletecourseName'),
        };


        $.ajax({
            url: '/course/DeleteCourseCatalog', // Ruta del controlador y acción
            method: 'POST',
            data: courseData, 
            success: function (data) {
                $('#DeletebasicModal').modal('hide'); // Ocultar el modal
                location.reload(); // Reload the page
            },
            error: function (error) {
                $('#DeletebasicModal').modal('hide'); // Ocultar el modal
                location.reload(); // Reload the page
            }
        });
    });



});
