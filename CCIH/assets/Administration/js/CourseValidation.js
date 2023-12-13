$(document).ready(function () {


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




    $('#DurationWeeks').on('input', function () {
        var durationWeeks = $(this).val();

        if (durationWeeks.trim() === '') {
            $('#DurationWeeksValidationMessage').text('Por favor, ingrese la duración en semanas.');
            return;
        }

        if (isNaN(durationWeeks)) {
            $('#DurationWeeksValidationMessage').text('La duración debe ser un número.');
            return;
        }

        if (parseInt(durationWeeks) < 0) {
            $('#DurationWeeksValidationMessage').text('La duración no puede ser menor que 0.');
            return;
        }

        if (parseInt(durationWeeks) > 104) {
            $('#DurationWeeksValidationMessage').text('La duración no puede ser Mayor que 104 semanas.');
            return;
        }

        $('#DurationWeeksValidationMessage').text(''); // Borrar el mensaje si la validación es correcta
        // Resto de tu lógica para actualizar o enviar datos...
    });



    $('#EditModalFormButton').on('click', function () {
        var formData = new FormData($('#EditModelForm')[0]); // Obtener datos del formulario

        // Subir la imagen y obtener el nombre del archivo

        var uploadedFileName = UploadFileEdit();

        if (uploadedFileName === 'No image') {
            uploadedFileName = ''
        }

        // Asignar el nombre del archivo al formData
        formData.append('image', uploadedFileName);


        // Enviar los datos del formulario con la imagen
        $.ajax({
            url: '/Course/SendInfoEditCourse',
            type: 'POST',
            data: formData, image,
            processData: false, // Evitar que jQuery procese los datos
            contentType: false, // Evitar el contentType automático
            success: function (response) {
                // Manejar la respuesta exitosa
                window.location.href = '/Course/ShowCourses'; // Redirigir a la página deseada
            },
            error: function (error) {
                // Manejar errores
            }
        });
    });


    $('#AddModalFormButton').on('click', function () {
        var formData = new FormData($('#AddModelForm')[0]); // Obtener datos del formulario

        // Subir la imagen y obtener el nombre del archivo
        var uploadedFileName = UploadFileAdd();

        if (uploadedFileName === 'No image') {
            uploadedFileName = ''
        }

        // Asignar el nombre del archivo al formData
        formData.append('image', uploadedFileName);
                

        // Enviar los datos del formulario con la imagen
        $.ajax({
            url: '/Course/SendInfoAddCourse',
            type: 'POST',
            data: formData,image,
            processData: false, // Evitar que jQuery procese los datos
            contentType: false, // Evitar el contentType automático
            success: function (response) {
                // Manejar la respuesta exitosa
                window.location.href = '/Course/ShowCourses'; // Redirigir a la página deseada
            },
            error: function (error) {
                // Manejar errores
            }
        });
    });






    document.getElementById('goBack').onclick = function () {
        // Realizar una solicitud AJAX al método del controlador

        var newUrl = '/Course/ShowCourses';


        $.ajax({
            url: '/Course/ShowCourses',
            type: 'GET', // o 'GET' dependiendo del método del controlador
            data: {
                // Aquí puedes enviar datos adicionales si es necesario
                // por ejemplo: parametro1: valor1, parametro2: valor2
            },
            success: function (response) {
                // Redirige a la nueva URL
                window.location.href = newUrl;
            },
            error: function (error) {
                // Manejar errores si los hay
            }
        });
    };




    function generateUniqueFileName(fileName) {
        var date = new Date().toISOString().replace(/:/g, '-');
        return date + '_' + fileName;
    }


    //document.getElementById('uploadButton').addEventListener('click', function () {
        
    //});

    function UploadFileEdit() {
        var fileInput = document.getElementById('imageSelect');
        var file = fileInput.files[0]; // Obtener el archivo seleccionado

        //var uniqueFileName = generateUniqueFileName(file.name); // Generar un nombre único para el archivo

        //return uniqueFileName;
        if (file === '' || file === undefined) {
            file = 'No image'
        }

        return file.name;

        //var formData = new FormData(); // Crear un objeto FormData para enviar el archivo
        //formData.append('file', file, uniqueFileName);

        //// Enviar la solicitud AJAX
        //fetch('/Course/UploadImage', {
        //    method: 'POST',
        //    body: formData
        //})
        //    .then(response => {

        //        //if (response.ok) {
        //        //    console.log('Imagen subida correctamente');
        //        //    // Lógica adicional después de subir la imagen con éxito
        //        //} else {
        //        //    console.error('Error al subir la imagen');
        //        //    // Manejo de errores
        //        //}
        //    })
        //    .catch(error => {
        //        console.error('Error:', error);
        //        // Manejo de errores
        //    });
    }

    function UploadFileAdd() {
        var fileInput = document.getElementById('imageSelect');
        var file = fileInput.files[0]; // Obtener el archivo seleccionado

        //var uniqueFileName = generateUniqueFileName(file.name); // Generar un nombre único para el archivo

        //return uniqueFileName;

        if (file === '' || file === undefined) {
            file = 'No image'
        }


        return file.name;

        //var formData = new FormData(); // Crear un objeto FormData para enviar el archivo
        //formData.append('file', file, uniqueFileName);

        //// Enviar la solicitud AJAX
        //fetch('/Course/UploadImage', {
        //    method: 'POST',
        //    body: formData
        //})
        //    .then(response => {

        //        //if (response.ok) {
        //        //    console.log('Imagen subida correctamente');
        //        //    // Lógica adicional después de subir la imagen con éxito
        //        //} else {
        //        //    console.error('Error al subir la imagen');
        //        //    // Manejo de errores
        //        //}
        //    })
        //    .catch(error => {
        //        console.error('Error:', error);
        //        // Manejo de errores
        //    });
    }


});


