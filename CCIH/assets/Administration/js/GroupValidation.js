


//////////////////////     Esperar 5 segundos y luego ocultar el mensaje     ////////////////////////////////////////////

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

    ////////////////////////////  GroupName   ///////////////////////////////////////////////////////////////////

    // Validación para el campo del nombre de grupo
    var groupNameInput = document.getElementById("GroupNameId");

    // Verificar si el campo está vacío
    if (groupNameInput.value.trim() === "") {
        groupNameInput.style.borderColor = "FireBrick";
    } else {
        groupNameInput.style.borderColor = "Green";
    }

    groupNameInput.addEventListener('keyup', function () {
        var groupName = this.value.trim();
        var validationMessage = document.getElementById('GroupNameMessage');

        if (groupName === "") {
            validationMessage.innerHTML = "El nombre del grupo es requerido.";
            this.style.borderColor = "FireBrick";
        } else {
            validationMessage.innerHTML = "";
            this.style.borderColor = "Green";
        }
    });



    ///////////////////////////////// MaxStudentsNumber  ////////////////////////////////////////////////////////////////

    // Validación para el campo de máximo número de estudiantes
    var maxStudentsInput = document.getElementById("MaxStudentsNumberId");
    var studentsNumberInput = document.getElementById("StudentsNumberId");

    maxStudentsInput.addEventListener('keyup', function () {
        var maxStudents = this.value.trim();
        var validationMessage = document.getElementById('MaxStudentsNumberValidationMessage');

        if (maxStudents === "") {
            validationMessage.innerHTML = "El número máximo de estudiantes es requerido.";
            this.style.borderColor = "FireBrick";
        } else if (!/^\d+$/.test(maxStudents)) {
            validationMessage.innerHTML = "Ingrese un número válido.";
            this.style.borderColor = "FireBrick";
        } else if (parseInt(maxStudents) > 20) {
            validationMessage.innerHTML = "El número máximo permitido es 20.";
            this.style.borderColor = "FireBrick";
        //} else if (parseInt(maxStudents) < studentsNumber) {
        //    validationMessage.innerHTML = "El número máximo no puede ser menor que el número actual de estudiantes.";
        //    this.style.borderColor = "FireBrick";
        } else {
            validationMessage.innerHTML = "";
            this.style.borderColor = "Green";
        }
    });




    /////////////////////////////// StudentsNumberId  ////////////////////////////////////////////////////////////////

    //// Validación para el campo de número de estudiantes
    //var studentsNumberInput = document.getElementById("StudentsNumberId");

    //// Validación inicial para asegurarse de que el valor no exceda 20 al cargar la página
    //var studentsNumber = studentsNumberInput.value.trim();
    //if (parseInt(studentsNumber) > 20) {
    //    studentsNumberInput.style.borderColor = "FireBrick";
    //    document.getElementById('StudentsNumberValidationMessage').innerHTML = "El número máximo permitido es 20.";
    //}

    //// Evento keyup para mostrar mensaje si se intenta modificar el campo de solo lectura
    //studentsNumberInput.addEventListener('keyup', function () {
    //    var students = this.value.trim();
    //    var validationMessage = document.getElementById('StudentsNumberValidationMessage');

    //    if (students === "") {
    //        validationMessage.innerHTML = "El número de estudiantes es requerido.";
    //        this.style.borderColor = "FireBrick";
    //    } else if (!/^\d+$/.test(students)) {
    //        validationMessage.innerHTML = "Ingrese un número válido.";
    //        this.style.borderColor = "FireBrick";
    //    } else if (parseInt(students) > 20) {
    //        validationMessage.innerHTML = "El número máximo permitido es 20.";
    //        this.style.borderColor = "FireBrick";
    //    } else {
    //        validationMessage.innerHTML = "";
    //        this.style.borderColor = "Green";
    //    }
    //});



    /////////////////////////////// StartDate & EndDate  ////////////////////////////////////////////////////////////////


    /////////////////////////////// Update Button  ////////////////////////////////////////////////////////////////


    // Obtener los elementos de fecha de inicio y fecha final
    var startDateInput = document.getElementById("StartDateId");
    var endDateInput = document.getElementById("EndDateId");
    var submitButton = document.getElementById("UserFormButton");

    // Evento change para la validación de fechas
    startDateInput.addEventListener('change', validateDates);
    endDateInput.addEventListener('change', validateDates);

    function validateDates() {
        var startDate = new Date(startDateInput.value); // Obtener la fecha de inicio en formato Date
        var endDate = new Date(endDateInput.value); // Obtener la fecha final en formato Date

        var oneMonthAgo = new Date(); // Obtener la fecha de hace un mes
        oneMonthAgo.setMonth(oneMonthAgo.getMonth() - 1);

        var validationMessageStart = document.getElementById('StartDatevalidationMessage');
        var validationMessageEnd = document.getElementById('EndDatevalidationMessage');

        // Calcular diferencia en milisegundos entre las fechas
        var differenceInMs = endDate.getTime() - startDate.getTime();

        // Calcular la diferencia en días
        var differenceInDays = differenceInMs / (1000 * 3600 * 24);

        // Validar si las fechas son iguales o si la diferencia es menor a un mes (30 días)
        if (startDate >= endDate || differenceInDays < 30) {
            validationMessageStart.innerHTML = "La fecha de inicio debe ser menor que la fecha final y mayor a un mes atrás.";
            startDateInput.style.borderColor = "FireBrick";

            validationMessageEnd.innerHTML = "La fecha final debe ser mayor que la fecha de inicio y mayor a un mes.";
            endDateInput.style.borderColor = "FireBrick";

            submitButton.disabled = true; // Si hay errores, se deshabilita el botón
        } else {
            validationMessageStart.innerHTML = "";
            startDateInput.style.borderColor = "Green";

            validationMessageEnd.innerHTML = "";
            endDateInput.style.borderColor = "Green";

            submitButton.disabled = false; // Si no hay errores, se habilita el botón
            // checkSubmitButton();
        }
    }




    /////////////////////////////// Send Information  ////////////////////////////////////////////////////////////////



    // Evento de clic para enviar el formulario al presionar "Guardar Cambios" en el modal
    $('#EditModalFormButton').on('click', function () {
        var formData = $('#EditModelForm').serialize(); // Serializa los datos del formulario

        $.ajax({
            url: '/Group/SendInfoEditGroup',
            type: 'POST',
            data: formData,
            success: function (response) {

                //window.location.reload();
                window.location.href = '/Group/ShowGroups'; // Redirigir a la página deseada
            },
            error: function (error) {
                // Manejar errores si los hay
            }
        });
    });


    // Evento de clic para enviar el formulario al presionar "Guardar Cambios" en el modal
    $('#CreateModalFormButton').on('click', function () {
        var formData = $('#ModelForm').serialize(); // Serializa los datos del formulario

        $.ajax({
            url: '/Group/SendInfoCreateGroup',
            type: 'POST',
            data: formData,
            success: function (response) {

                //window.location.reload();
                window.location.href = '/Group/ShowGroups'; // Redirigir a la página deseada
            },
            error: function (error) {
                // Manejar errores si los hay
            }
        });
    });


    // Ocultar el modal al hacer clic en "Cancelar" o cerrar el modal
    $('#basicModal button.btn-danger, #basicModal button.close').on('click', function () {
        $('#basicModal').modal('hide');
    });


    /////////////////////////////// Check course name  ////////////////////////////////////////////////////////////////


    // Obtener el elemento del menú desplegable por su ID
    var courseDropdown = document.getElementById('CourseNameList');
    var scheduleDropdown = document.getElementById('ScheduleDescriptionNameList');
    var teacherDropdown = document.getElementById('TeacherNameNameList');
    var submitButton = document.getElementById('UserFormButton');

    // Agregar eventos para escuchar cambios en la selección
    courseDropdown.addEventListener('change', function () {
        checkCourseList();
    });

    scheduleDropdown.addEventListener('change', function () {
        checkScheduleList();
    });

    teacherDropdown.addEventListener('change', function () {
        checkTeacherList();
    });

    function checkCourseList() {
        var selectedValue = courseDropdown.value;
        var validationMessage = document.getElementById('CourseNameValidationMessage');

        if (selectedValue === '0') {
            validationMessage.innerHTML = "Selecciona un curso válido.";
        } else {
            validationMessage.innerHTML = "";
        }

        checkSubmitButton();
    }

    function checkScheduleList() {
        var selectedValue = scheduleDropdown.value;
        var validationMessage = document.getElementById('ScheduleDescriptionValidationMessage');

        if (selectedValue === '0') {
            validationMessage.innerHTML = "Selecciona un horario válido.";
        } else {
            validationMessage.innerHTML = "";
        }

        checkSubmitButton();
    }


    function checkTeacherList() {
        var selectedValue = teacherDropdown.value;
        var validationMessage = document.getElementById('TeacherNameValidationMessage');

        if (selectedValue === '0') {
            validationMessage.innerHTML = "Selecciona un profesor válido.";
        } else {
            validationMessage.innerHTML = "";
        }

        checkSubmitButton();
    }


    function checkSubmitButton() {
        var selectedValue1 = courseDropdown.value;
        var selectedValue2 = scheduleDropdown.value;
        var selectedValue3 = teacherDropdown.value;

        if (selectedValue1 === '0' || selectedValue2 === '0' || selectedValue3 === '0') {
            submitButton.disabled = true;
        } else {
            submitButton.disabled = false;
        }
    }


    checkCourseList();
    checkScheduleList();
    checkTeacherList();
    validateDates();



    document.getElementById('goBack').onclick = function () {
        // Realizar una solicitud AJAX al método del controlador

        var newUrl = '/Group/ShowGroups';


        $.ajax({
            url: '/Group/ShowGroups',
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


});



