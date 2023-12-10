
    document.addEventListener("DOMContentLoaded", function () {
        var preRegistrationForm = document.getElementById("PreRegistrationForm");
    var preRegistrationFormButton = document.getElementById("PreRegistrationFormButton");

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
            var formInputs = form.querySelectorAll("input, select");
    for (var i = 0; i < formInputs.length; i++) {
                if (formInputs[i].value.trim() === "") {
                    return false; // El formulario no está completo
                }
            }
    return true; // El formulario está completo
        }

        function emptyfields(form) {
            // Valida si todos los campos del formulario están llenos
            var formInputs = form.querySelectorAll("input, select");
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






/////////////////////////////// email  ////////////////////////////////////////////////////////////////

document.querySelector('#email').addEventListener('keyup', function () {
    var email = this.value;
    var validationMessage = document.querySelector('#validationEmail');

    if (email.trim() === "") {
        validationMessage.innerHTML = "";
        this.style.borderColor = ""; // Restaurar el color del borde
    } else if (!isValidEmail(email)) {
        validationMessage.innerHTML = "Por favor, ingrese un correo electrónico válido, ejemplo: correo@email.com";
        this.style.borderColor = "FireBrick";
    } else {
        validationMessage.innerHTML = "";
        this.style.borderColor = "Green";
    }
});

function isValidEmail(email) {
    var emailPattern = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
    return emailPattern.test(email);
}


/////////////////////////////// phone  ////////////////////////////////////////////////////////////////

document.querySelector('#Telefono').addEventListener('input', function () {
    var phone = this.value;
    var validationMessage = document.querySelector('#validationPhone');

    if (phone.trim() === "") {
        validationMessage.innerHTML = "";
        this.style.borderColor = ""; // Restaurar el color del borde
    } else if (!/^\d+$/.test(phone)) {
        validationMessage.innerHTML = "Telefono solo permite números.";
        this.style.borderColor = "FireBrick";
    } else if (phone.length < 8) {
        validationMessage.innerHTML = "Telefono debe ser mínimo de 8 dígitos.";
        this.style.borderColor = "FireBrick";
    } else {
        validationMessage.innerHTML = "";
        this.style.borderColor = "Green";
    }
});

/////////////////////////////// name  ////////////////////////////////////////////////////////////////

document.querySelector('#Nombre').addEventListener('input', function () {
    var name = this.value;
    var validationMessage = document.querySelector('#validationNombre');

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

/////////////////////////////// apellido 1  ////////////////////////////////////////////////////////////////

document.querySelector('#Apellido1').addEventListener('input', function () {
    var name = this.value;
    var validationMessage = document.querySelector('#validationApellido');

    if (name.trim() === "") {
        validationMessage.innerHTML = "";
        this.style.borderColor = ""; // Restaurar el color del borde
    } else if (!/^[A-Za-zÁÉÍÓÚáéíóúñÑ\s]+$/.test(name)) {
        validationMessage.innerHTML = "Apellido solo permite letras.";
        this.style.borderColor = "FireBrick";
    } else {
        validationMessage.innerHTML = "";
        this.style.borderColor = "Green";
    }
});

/////////////////////////////// apellido 2  ////////////////////////////////////////////////////////////////

document.querySelector('#Apellido2').addEventListener('input', function () {
    var name = this.value;
    var validationMessage = document.querySelector('#validationSegundoApellido');

    if (name.trim() === "") {
        validationMessage.innerHTML = "";
        this.style.borderColor = ""; // Restaurar el color del borde
    } else if (!/^[A-Za-zÁÉÍÓÚáéíóúñÑ\s]+$/.test(name)) {
        validationMessage.innerHTML = "Apellido solo permite letras.";
        this.style.borderColor = "FireBrick";
    } else {
        validationMessage.innerHTML = "";
        this.style.borderColor = "Green";
    }
});

///////////////////////////////// Cursos  ////////////////////////////////////////////////////////////////

document.querySelector('#Cursos').addEventListener('input', function () {
    var validationMessage = document.querySelector('#validationCurso');
    var Curso = this.value;
    if (Curso > 0) {
        this.style.borderColor = "Green";
        validationMessage.innerHTML = "";
    } else {
        this.style.borderColor = "FireBrick";
        validationMessage.innerHTML = "Seleccione un curso.";

    }
});

/////////////////////////////////// Modalidad  ////////////////////////////////////////////////////////////////

document.querySelector('#Modalidad').addEventListener('input', function () {
    var validationMessage = document.querySelector('#validationModalidad');
    var Curso = this.value;
    if (Curso > 0) {
        this.style.borderColor = "Green";
        validationMessage.innerHTML = "";
    } else {
        this.style.borderColor = "FireBrick";
        validationMessage.innerHTML = "Seleccione una modalidad.";

    }
});

/////////////////////////////////// Nivel  ////////////////////////////////////////////////////////////////

document.querySelector('#Nivel').addEventListener('input', function () {
    var validationMessage = document.querySelector('#validationNivel');
    var Curso = this.value;
    if (Curso > 0) {
        this.style.borderColor = "Green";
        validationMessage.innerHTML = "";
    } else {
        this.style.borderColor = "FireBrick";
        validationMessage.innerHTML = "Seleccione un Nivel.";

    }
});
