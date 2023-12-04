var personalIdSeleccionado; // Variable global para almacenar el PersonalID seleccionado
var groupSelected;
var teacherId;

// Esta función se ejecutará al cargar el documento
$(document).ready(function () {
    // Esperar 5 segundos y luego ocultar el mensaje
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

    // Ocultar las secciones al cargar la página
    $('#ScheduleDescriptionNameList').closest('.col-lg-6').hide(); // Oculta la sección de horario
    $('#StartDateId').closest('.col-lg-6').hide(); // Oculta la sección de fecha de inicio
    $('#EndDateId').closest('.col-lg-6').hide(); // Oculta la sección de fecha final

    // Llama a la función que maneja el cambio de #GroupNameList
    handleGroupNameListChange();




    // Llamar a la función al cargar la página y cada vez que se cambie el contenido de los campos
    verificarInformacion();

    $('#GroupName').on('input', verificarInformacion);
    $('#ScheduleDescriptionNameList').on('input', verificarInformacion);
    $('#StartDateId').on('input', verificarInformacion);
    $('#EndDateId').on('input', verificarInformacion);


    /***************************************************************************************/



    $('#AddButton').on('click', function () {
        // Obtener el valor seleccionado del DropDownList de profesores
        teacherId = $('#TeacherNameList').val();

    });


    $(document).on('click', '#DataTable button#AddButtonS', function () {
        var personalID = $(this).closest('tr').find('td:first').text().trim();
        personalIdSeleccionado = personalID;
    });





    $('#AddStudentModalFormButton').on('click', function () {
        var personalId = obtenerPersonalIdSeleccionado(); // Obtener el personalID seleccionado
        var groupId = obtenerIdGrupoSeleccionado(); // Obtener el ID del grupo seleccionado
        // Obtén la URL actual
        var currentUrl = window.location.href;
        var newUrl;

        // Realizar la solicitud AJAX
        $.ajax({
            url: '/Group/AssignGroupToStudent', // Ruta del controlador y acción
            type: 'POST', // Método de solicitud (en este caso, POST)
            data: {
                personalId: personalId,
                groupId: groupId
            },
            success: function (response) {
                //console.log('Estudiante asignado al grupo correctamente');
                // Manejar la respuesta exitosa, si es necesario
                //window.location.reload(); // Recargar la página después de asignar

                newUrl = currentUrl.split('?')[0] + '?init=false' + '&groupIdP=' + groupId;
                // Redirige a la nueva URL
                window.location.href = newUrl;


            },
            error: function (error) {
                console.error('Error al asignar estudiante al grupo:', error);
                // Manejar errores si los hay
            }
        });


    });




    $('#AddTeacherModalFormButton').on('click', function () {
        var groupId = obtenerIdGrupoSeleccionado(); // Obtener el ID del grupo seleccionado
        var teacherId = obtenerTeacherIdSeleccionado();
        // Obtén la URL actual
        var currentUrl = window.location.href;
        var newUrl;

        // Realizar la solicitud AJAX
        $.ajax({
            url: '/Group/AssignTeacherToGroup', // Ruta del controlador y acción
            type: 'POST', // Método de solicitud (en este caso, POST)
            data: {
                teacherId: teacherId,
                groupId: groupId
            },
            success: function (response) {
                //console.log('Estudiante asignado al grupo correctamente');
                // Manejar la respuesta exitosa, si es necesario
                //window.location.reload(); // Recargar la página después de asignar

                newUrl = currentUrl.split('?')[0] + '?init=false' + '&groupIdP=' + groupId;
                // Redirige a la nueva URL
                window.location.href = newUrl;


            },
            error: function (error) {
                console.error('Error al asignar estudiante al grupo:', error);
                // Manejar errores si los hay
            }
        });
    });



    $('#RemoveButton').on('click', function () {
        // Obtener el valor seleccionado del DropDownList de profesores
        teacherId = $('#TeacherNameList').val();

    });



    $(document).on('click', '#DataTable button#RemoveButtonS', function () {
        var personalID = $(this).closest('tr').find('td:first').text().trim();
        personalIdSeleccionado = personalID;
    });




    $('#RemoveStudentModalFormButton').on('click', function () {
        var personalId = obtenerPersonalIdSeleccionado(); // Obtener el personalID seleccionado
        var groupId = obtenerIdGrupoSeleccionado(); // Obtener el ID del grupo seleccionado
        // Obtén la URL actual
        var currentUrl = window.location.href;
        var newUrl;

        // Realizar la solicitud AJAX
        $.ajax({
            url: '/Group/RemoveStudentFromGroup', // Ruta del controlador y acción
            type: 'POST', // Método de solicitud (en este caso, POST)
            data: {
                personalId: personalId,
                groupId: groupId
            },
            success: function (response) {
                //console.log('Estudiante asignado al grupo correctamente');
                // Manejar la respuesta exitosa, si es necesario
                //window.location.reload(); // Recargar la página después de asignar

                newUrl = currentUrl.split('?')[0] + '?init=false' + '&groupIdP=' + groupId;
                // Redirige a la nueva URL
                window.location.href = newUrl;


            },
            error: function (error) {
                console.error('Error al asignar estudiante al grupo:', error);
                // Manejar errores si los hay
            }
        });
    });



    $('#RemoveTeacherModalFormButton').on('click', function () {
        var groupId = obtenerIdGrupoSeleccionado(); // Obtener el ID del grupo seleccionado
        // Obtén la URL actual
        var currentUrl = window.location.href;
        var newUrl;

        // Realizar la solicitud AJAX
        $.ajax({
            url: '/Group/RemoveTeacherFromGroup', // Ruta del controlador y acción
            type: 'POST', // Método de solicitud (en este caso, POST)
            data: {
                groupId: groupId
            },
            success: function (response) {
                //console.log('Estudiante asignado al grupo correctamente');
                // Manejar la respuesta exitosa, si es necesario
                //window.location.reload(); // Recargar la página después de asignar

                newUrl = currentUrl.split('?')[0] + '?init=false' + '&groupIdP=' + groupId;
                // Redirige a la nueva URL
                window.location.href = newUrl;


            },
            error: function (error) {
                console.error('Error al asignar estudiante al grupo:', error);
                // Manejar errores si los hay
            }
        });
    });


});


function obtenerTeacherIdSeleccionado() {
    // Lógica para obtener el personalID seleccionado
    return teacherId; // Reemplazar con la lógica real
}


function obtenerPersonalIdSeleccionado() {
    // Lógica para obtener el personalID seleccionado
    return personalIdSeleccionado; // Reemplazar con la lógica real
}

function obtenerIdGrupoSeleccionado() {
    // Lógica para obtener el ID del grupo seleccionado
    var storedGroupSelected = localStorage.getItem('groupSelected');
    return storedGroupSelected; // Reemplazar con la lógica real
}

// Función para verificar si los campos tienen información y habilitar los botones
function verificarInformacion() {
    var groupName = $('#GroupName').val();
    var scheduleDescription = $('#ScheduleDescriptionNameList').val();
    var startDate = $('#StartDateId').val();
    var endDate = $('#EndDateId').val();

    var tieneInformacion = groupName !== '' &&
        scheduleDescription !== '' &&
        startDate !== '' &&
        endDate !== '';

    // Obtener los botones que quieres habilitar
    var addButton = $('#AddButton');
    var addButtonS = $('#AddButtonS');
    var removeButton = $('#RemoveButton');

    // Habilitar o deshabilitar los botones según si hay información o no
    addButtonS.prop('disabled', !tieneInformacion);
    addButton.prop('disabled', !tieneInformacion);
    removeButton.prop('disabled', !tieneInformacion);
}




// Esta función maneja el cambio en #SetGroupNameList
function handleGroupNameListChange(elementId, actionUrl) {
    $(elementId).change(function () {
        var selectedValue = $(this).val();
        groupSelected = selectedValue;
        localStorage.setItem('groupSelected', groupSelected);

        // Si el valor seleccionado es diferente de '0', muestra las secciones de horario, inicio y fin
        if (selectedValue !== '0') {
            $('#ScheduleDescriptionNameList').closest('.col-lg-6').show(); // Muestra la sección de horario
            $('#StartDateId').closest('.col-lg-6').show(); // Muestra la sección de fecha de inicio
            $('#EndDateId').closest('.col-lg-6').show(); // Muestra la sección de fecha final
        } else {
            $('#ScheduleDescriptionNameList').closest('.col-lg-6').hide(); // Oculta la sección de horario
            $('#StartDateId').closest('.col-lg-6').hide(); // Oculta la sección de fecha de inicio
            $('#EndDateId').closest('.col-lg-6').hide(); // Oculta la sección de fecha final
        }

        // Obtén la URL actual
        var currentUrl = window.location.href;
        var newUrl;

        // Realiza una petición AJAX al controlador
        $.ajax({
            url: actionUrl, // URL del controlador y acción
            type: 'GET', // Método de la solicitud (GET, POST, etc.)
            data: {
                groupIdP: selectedValue,
                init: false
            },
            success: function (response) {
                newUrl = currentUrl.split('?')[0] + '?init=false' + '&groupIdP=' + selectedValue;
                // Redirige a la nueva URL
                window.location.href = newUrl;

                verificarInformacion();
            },
            error: function (error) {
                // Maneja errores si los hay
                console.error('Error al obtener grupos:', error);
            }
        });
    });
}

// Llama a la función para manejar los cambios en las listas desplegables
handleGroupNameListChange('#SetGroupNameList', '/Group/SetPeople');
handleGroupNameListChange('#RemoveGroupNameList', '/Group/RemovePeople');


document.addEventListener("DOMContentLoaded", function () {
    var teacherDropdown = document.getElementById("TeacherNameList");
    var removeButton = document.getElementById("RemoveButton");

    // Función para verificar el valor inicial del dropdown y deshabilitar el botón si es "Sin Profesor"
    function checkInitialValue() {
        var selectedValue = teacherDropdown.value; // Obtener el valor inicial

        // Verificar si el valor inicial es "Sin Profesor"
        if (selectedValue === "Sin Profesor") {
            removeButton.disabled = true; // Si es "Sin Profesor", deshabilitar el botón
        } else {
            removeButton.disabled = false; // Habilitar el botón para otros valores
        }
    }

    // Llamar a la función una vez que se haya cargado la página para verificar el valor inicial
    checkInitialValue();
});