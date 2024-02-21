


//////////////////////     Esperar 5 segundos y luego ocultar el mensaje     ////////////////////////////////////////////

setTimeout(function () {
    var mensajeDiv = document.getElementById('MsjPantalla');
    if (mensajeDiv != null) {
        mensajeDiv.style.display = 'none';
    }

}, 5000); // 5000 milisegundos = 5 segundos

/// FORM

document.addEventListener("DOMContentLoaded", function () {
    var preRegistrationForm = document.getElementById("RegistrationForm");
    var preRegistrationFormButton = document.getElementById("RegistrationFormButton");

    preRegistrationFormButton.addEventListener("click", function (event) {
        event.preventDefault(); // Evitar el envío automático del formulario

        if (isFormValid(preRegistrationForm)) {
            // Si el formulario es válido, muestra el modal de éxito
            $("#successModal").modal("show");
        } else {
            emptyfields(preRegistrationForm);
            $("#errorModal").modal("show");

        }
    });

    function isFormValid(form) {
        // Valida si todos los campos del formulario están llenos
        var formInputs = form.querySelectorAll("input, textarea, select");
        for (var i = 0; i < formInputs.length; i++) {
            if (formInputs[i].value.trim() === "") {
                return false; // El formulario no está completo
            } else {
                formInputs[i].style.borderColor = "Green";
            }
        }
        return true; // El formulario está completo
    }

    function emptyfields(form) {
        // Valida si todos los campos del formulario están llenos
        var formInputs = form.querySelectorAll("input, textarea, select");
        for (var i = 0; i < formInputs.length; i++) {
            if (formInputs[i].value.trim() === "") {
                formInputs[i].style.borderColor = "FireBrick";
            } else {
                formInputs[i].style.borderColor = "Green";
            }
        }
        return true; // El formulario está completo
    }
});


/////////////////////////////// Cedula  ////////////////////////////////////////////////////////////////

document.querySelector('#PersonalId').addEventListener('input', function () {
    var cedula = this.value;
    var validationMessage = document.querySelector('#validationMessage');

    if (cedula.trim() === "") {
        validationMessage.innerHTML = "";
        this.style.borderColor = ""; // Restaurar el color del borde
    } else if (!/^\d+$/.test(cedula)) {
        validationMessage.innerHTML = "Cedula solo permite numeros.";
        this.style.borderColor = "FireBrick";
    } else if (cedula.length < 9) {
        validationMessage.innerHTML = "Telefono debe ser minimo de 9 dígitos.";
        this.style.borderColor = "FireBrick";
    } else {
        validationMessage.innerHTML = "";
        this.style.borderColor = "Green";
    }


});


/////////////////////////////// name  ////////////////////////////////////////////////////////////////

document.querySelector('#nameField').addEventListener('input', function () {
    var name = this.value;
    var validationMessage = document.querySelector('#nameValidationMessage');

    if (name.trim() === "") {
        validationMessage.innerHTML = "";
        this.style.borderColor = ""; // Restaurar el color del borde
    } else if (!/^[A-Za-zÁÉÍÓÚáéíóúñÑ\s]+$/.test(name)) {
        validationMessage.innerHTML = "Nombre solo permite letras.";
        this.style.borderColor = "FireBrick";
    } else {
        validationMessage.innerHTML = "";
        this.style.borderColor = "Green";
    }
});


////////////////////////////  Cursos   ///////////////////////////////////////////////////////////////////


document.querySelector('#ListaCursos').addEventListener('input', function () {
    var validationMessage = document.querySelector('#validationCurso');
    var Curso = this.value;
    if (Curso > 0) {
        this.style.borderColor = "Green";
        validationMessage.innerHTML = "";
    } else {
        this.style.borderColor = "FireBrick";
        validationMessage.innerHTML = "Seleccione un Curso.";

    }
});

////////////////////////////  Modalidad   ///////////////////////////////////////////////////////////////////


document.querySelector('#ListaModalidad').addEventListener('input', function () {
    var validationMessage = document.querySelector('#validationModalidad');
    var Curso = this.value;
    if (Curso > 0) {
        this.style.borderColor = "Green";
        validationMessage.innerHTML = "";
    } else {
        this.style.borderColor = "FireBrick";
        validationMessage.innerHTML = "Seleccione una Modalidad.";

    }
});

////////////////////////////  Nivel   ///////////////////////////////////////////////////////////////////



document.querySelector('#ListaNivel').addEventListener('input', function () {
    var validationMessage = document.querySelector('#validationHorario');
    var Curso = this.value;
    if (Curso > 0) {
        this.style.borderColor = "Green";
        validationMessage.innerHTML = "";
    } else {
        this.style.borderColor = "FireBrick";
        validationMessage.innerHTML = "Seleccione un Nivel.";

    }
});

////////////////////////////  Horario   ///////////////////////////////////////////////////////////////////



document.querySelector('#ListaHorario').addEventListener('input', function () {
    var validationMessage = document.querySelector('#validationHorario');
    var Curso = this.value;
    if (Curso > 0) {
        this.style.borderColor = "Green";
        validationMessage.innerHTML = "";
    } else {
        this.style.borderColor = "FireBrick";
        validationMessage.innerHTML = "Seleccione un Horario.";

    }
});

////////////////////////////  Monto   ///////////////////////////////////////////////////////////////////



document.querySelector('#Monto').addEventListener('keyup', function () {
    var dato = this.value;
    var validationMessage = document.querySelector('#ValidationMessageMonto');
    if (!/^\d+$/.test(dato)) {
        validationMessage.innerHTML = "Monto solo permite numeros.";
        this.style.borderColor = "FireBrick";
    } else {
        validationMessage.innerHTML = "";
        this.style.borderColor = "Green";
    }
});

/////////////////////////////// Fecha matricula  ////////////////////////////////////////////////////////////////



document.querySelector('#fechamatricula').addEventListener('input', function () {
    var Birthdate = this.value;
    var validationMessage = document.querySelector('#ValidationMessageMonto');
    if (Birthdate != null) {
        this.style.borderColor = "Green";
    } else {
        this.style.borderColor = "FireBrick";
        validationMessage.innerHTML = "Seleccione la fecha de la matricula.";
    }
});

/////////////////////////////// DayPay  ////////////////////////////////////////////////////////////////

document.querySelector('#DayPay').addEventListener('keyup', function () {
    var dato = this.value;
    var validationMessage = document.querySelector('#validationMessageDayPay');
    if (dato > 31) {
        validationMessage.innerHTML = "Solo se permite maximo 31.";
        this.style.borderColor = "FireBrick";
    } else {
        validationMessage.innerHTML = "";
        this.style.borderColor = "Green";
    }
});

/////////////////////////////// Comentario  ////////////////////////////////////////////////////////////////



document.querySelector('#Comment').addEventListener('input', function () {
    var Birthdate = this.value;
    if (Birthdate != null) {
        this.style.borderColor = "Green";
    } else {
        this.style.borderColor = "FireBrick";
        validationMessage.innerHTML = "Digite un comentario.";

    }
});