

/////////////////////////////// CreateUserForm Button  ////////////////////////////////////////////////////////////////


// Obt�n los elementos del formulario y el bot�n
var formulario = document.getElementById("RegistrationForm");
var campos = formulario.querySelectorAll("input, textarea, select");
var boton = document.getElementById("RegistrationFormButton");

// Agrega un event listener a cada campo de entrada para verificar cambios
campos.forEach(function (campo) {
    campo.addEventListener("input", function () {
        habilitarDesabilitarBoton();
    });
});

// Funci�n para habilitar o deshabilitar el bot�n y mostrar mensaje de error
function habilitarDesabilitarBoton() {
    var todosCamposLlenos = true;
    campos.forEach(function (campo) {
        if (campo.value.trim() === "") {
            todosCamposLlenos = false;
        }
    });

    if (todosCamposLlenos) {
        boton.removeAttribute("disabled");
        // Oculta el mensaje de error
        document.getElementById("errorMessageRegisterForm").style.display = "none";
    } else {
        boton.setAttribute("disabled", "disabled");
        // Muestra el mensaje de error
        document.getElementById("errorMessageRegisterForm").style.display = "block";
        document.getElementById("errorMessageRegisterForm").textContent = "Por favor complete todos los campos.";
    }
}

// Llama a la funci�n inicialmente para establecer el estado inicial del bot�n y del mensaje
habilitarDesabilitarBoton();
