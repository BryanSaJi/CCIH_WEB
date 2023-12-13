$(document).ready(function () {


    $('#DataTable').on('click', '#EditFormButton', function () {
        // Obtener la fila correspondiente al botón presionado
        var row = $(this).closest('tr');
        // Obtener el valor de Description en la columna correspondiente
        var description = row.find('td:first').text();
        localStorage.setItem('LastDescription', description);
        // Asignar el valor al input del modal de edición

        $('#courseName').val(description);
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





    function getDayLetter(day) {
        // Crear un objeto con la traducción de días
        const dayTranslations = {
            "Lunes": "L",
            "Martes": "K",
            "Miércoles": "M",
            "Jueves": "J",
            "Viernes": "V",
            "Sábado": "S",
            "Domingo": "D"
        };

        // Retornar la primera letra del día o la letra "X" en caso de no encontrar una traducción
        return dayTranslations[day] || "X";
    }


    $('#AddModalFormButton').click(function () {
        var dayStart = $('#dayStart').val();
        var dayEnd = $('#dayEnd').val();
        var timeStart = $('#timeStart').val();
        var timeEnd = $('#timeEnd').val();

        // Validaciones
        if (timeStart === timeEnd) {
            // Las horas de inicio y finalización deben ser diferentes
            $('#timeStart').after('<span class="error">Las horas de inicio y finalización deben ser diferentes.</span>');
            return;
        }

        // Validación AM/PM
        var startTimeMoment = moment(timeStart, 'h:mm A');
        var endTimeMoment = moment(timeEnd, 'h:mm A');

        var hoursStart = startTimeMoment.hours();
        var hoursEnd = endTimeMoment.hours();

        var minutesStart = startTimeMoment.minutes();
        var minutesEnd = endTimeMoment.minutes();

        // Validación de horas
        if (hoursStart > hoursEnd || (hoursStart === hoursEnd && minutesStart >= minutesEnd)) {
            // La hora de inicio debe ser menor a la hora de finalización
            $('#timeEnd').after('<span class="error">La hora de finalización debe ser posterior a la hora de inicio.</span>');
            return;
        }

        // Concatenación con AM/PM
        //var description = `${dayStart} - ${dayEnd} ${hoursStart}:${moment(timeStart, 'h:mm A').format('mm')} ${ampmStart}/${hoursEnd}:${moment(timeEnd, 'h:mm A').format('mm')} ${ampmEnd}`;
        // Validación AM/PM y concatenación con el formato deseado
        var formattedStartTime = moment(timeStart, 'h:mm A').format('h:mmA');
        var formattedEndTime = moment(timeEnd, 'h:mm A').format('h:mmA');


        // Obtener la primera letra del día
        var dayStartLetter = getDayLetter(dayStart);
        var dayEndLetter = getDayLetter(dayEnd);


        var description = `${dayStartLetter} - ${dayEndLetter} ${formattedStartTime}/${formattedEndTime}`;




        // Envío de la solicitud AJAX
        var scheduleEnt = {
            description: description,
        };

        $.ajax({
            url: '/Schedule/createSchedule', // Replace with your actual controller and action path
            method: "POST",
            data: JSON.stringify(scheduleEnt),
            contentType: "application/json",
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
        var dayStart = $('#EditdayStart').val();
        var dayEnd = $('#EditdayEnd').val();
        var timeStart = $('#EdittimeStart').val();
        var timeEnd = $('#EdittimeEnd').val();

                
        // Validaciones
        if (timeStart === timeEnd) {
            // Las horas de inicio y finalización deben ser diferentes
            $('#EdittimeStart').after('<span class="error">Las horas de inicio y finalización deben ser diferentes.</span>');
            return;
        }

        // Validación AM/PM
        var startTimeMoment = moment(timeStart, 'h:mm A');
        var endTimeMoment = moment(timeEnd, 'h:mm A');

        var hoursStart = startTimeMoment.hours();
        var hoursEnd = endTimeMoment.hours();

        var minutesStart = startTimeMoment.minutes();
        var minutesEnd = endTimeMoment.minutes();

        // Validación de horas
        if (hoursStart > hoursEnd || (hoursStart === hoursEnd && minutesStart >= minutesEnd)) {
            // La hora de inicio debe ser menor a la hora de finalización
            $('#EdittimeEnd').after('<span class="error">La hora de finalización debe ser posterior a la hora de inicio.</span>');
            return;
        }

        // Concatenación con AM/PM
        //var description = `${dayStart} - ${dayEnd} ${hoursStart}:${moment(timeStart, 'h:mm A').format('mm')} ${ampmStart}/${hoursEnd}:${moment(timeEnd, 'h:mm A').format('mm')} ${ampmEnd}`;
        // Validación AM/PM y concatenación con el formato deseado
        var formattedStartTime = moment(timeStart, 'h:mm A').format('h:mmA');
        var formattedEndTime = moment(timeEnd, 'h:mm A').format('h:mmA');


        // Obtener la primera letra del día
        var dayStartLetter = getDayLetter(dayStart);
        var dayEndLetter = getDayLetter(dayEnd);


        var description = `${dayStartLetter} - ${dayEndLetter} ${formattedStartTime}/${formattedEndTime}`;




        // Envío de la solicitud AJAX
        var scheduleData = {
            description: description,
            LastDescription: localStorage.getItem('LastDescription'),
        };

        
        $.ajax({
            url: '/Schedule/EditSchedule', // Ruta del controlador y acción
            method: 'POST',
            data: scheduleData,
            success: function (data) {
                $('#EditbasicModal').modal('hide'); // Ocultar el modal después de guardar
                location.reload(); // Reload the page
            },
            error: function (error) {
                $('#EditbasicModal').modal('hide'); // Ocultar el modal después de guardar
                location.reload(); // Reload the page
            }
        });
    });


});
