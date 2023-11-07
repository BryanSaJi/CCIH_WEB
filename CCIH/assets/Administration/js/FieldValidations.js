
//////////////////////     Esperar 5 segundos y luego ocultar el mensaje     ////////////////////////////////////////////

setTimeout(function () {
    var mensajeDiv = document.getElementById('mensajePositivo');
    if (mensajeDiv != null) {
        mensajeDiv.style.display = 'none';
    }

    var mensajeDiv2 = document.getElementById('mensajeNegativo');
    if (mensajeDiv2 != null) {
        mensajeDiv2.style.display = 'none';
    }

    Session["MensajePositivo"] = 0;

}, 5000); // 5000 milisegundos = 5 segundos



////////////////////////////  id   ///////////////////////////////////////////////////////////////////

var documentID = document.getElementById("PersonalId").value;

if (documentID == "") {
    document.getElementById("PersonalId").style.borderColor = "FireBrick";
}
else {
    document.getElementById("PersonalId").style.borderColor = "Green";
}

document.querySelector('#PersonalId').addEventListener('keyup', function () {
    var id = this.value;
    var validationMessage = document.querySelector('#validationMessage');
    if (!/^\d+$/.test(id)) {
        validationMessage.innerHTML = "Cedula solo permite numeros.";
        this.style.borderColor = "FireBrick";
    } else {
        validationMessage.innerHTML = "";
        this.style.borderColor = "Green";
    }
});


/////////////////////////////// name  ////////////////////////////////////////////////////////////////

    if (document.getElementById("nameField").value != "") {
        document.getElementById("nameField").style.borderColor = "Green";
    }

document.querySelector('#nameField').addEventListener('input', function () {
    var name = this.value;
    var validationMessage = document.querySelector('#nameValidationMessage');
    if (!/^[A-Za-zÁÉÍÓÚáéíóúñÑ\s]+$/.test(name)) {
        validationMessage.innerHTML = "Nombre solo permite letras.";
        this.style.borderColor = "FireBrick";
    } else {
        validationMessage.innerHTML = "";
        this.style.borderColor = "Green";
    }
});

/////////////////////////////// lastname  ////////////////////////////////////////////////////////////////

if (document.getElementById("lastNameField").value != "") {
    document.getElementById("lastNameField").style.borderColor = "Green";
}

document.querySelector('#lastNameField').addEventListener('input', function () {
    var lastname = this.value;
    var validationMessage = document.querySelector('#lastNameValidationMessage');
    if (!/^[A-Za-zÁÉÍÓÚáéíóúñÑ\s]+$/.test(lastname)) {
        validationMessage.innerHTML = "Primer apellido solo permite letras.";
        this.style.borderColor = "FireBrick";
    } else {
        validationMessage.innerHTML = "";
        this.style.borderColor = "Green";
    }


});

/////////////////////////////// Slastname  ////////////////////////////////////////////////////////////////

if (document.getElementById("slnFIELD").value != "") {
    document.getElementById("slnFIELD").style.borderColor = "Green";
}

document.querySelector('#slnFIELD').addEventListener('input', function () {
    var slastname = this.value;
    var validationMessage = document.querySelector('#slnFIELDValidationMessage');
    if (!/^[A-Za-zÁÉÍÓÚáéíóúñÑ\s]+$/.test(slastname)) {
        validationMessage.innerHTML = "Segundo apellido solo permite letras.";
        this.style.borderColor = "FireBrick";
    } else {
        validationMessage.innerHTML = "";
        this.style.borderColor = "Green";
    }

});

/////////////////////////////// email  ////////////////////////////////////////////////////////////////

var DocumentEmail = document.getElementById("email").value;

if (DocumentEmail == "") {
    document.getElementById("email").style.borderColor = "FireBrick";
}
else {
    document.getElementById("email").style.borderColor = "Green";
}

document.querySelector('#email').addEventListener('keyup', function () {
    var email = this.value;
    var validationMessage = document.querySelector('#emailValidationMessage');
    if (!isValidEmail(email)) {
        validationMessage.innerHTML = "Por favor, ingrese un correo electronico valido, ejemplo: correo@email.com";
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
var DocumentPhone = document.getElementById("cel").value;

if (DocumentPhone == "") {
    document.getElementById("cel").style.borderColor = "FireBrick";
}
else {
    document.getElementById("cel").style.borderColor = "Green";
}

document.querySelector('#cel').addEventListener('input', function () {
    var phone = this.value;
    var validationMessage = document.querySelector('#PhoneValidationMessage');
    if (!/^\d+$/.test(phone)) {
        validationMessage.innerHTML = "Telefono solo permite numeros.";
        this.style.borderColor = "FireBrick";
    } else {
        validationMessage.innerHTML = "";
        this.style.borderColor = "Green";
    }
});

/////////////////////////////// Fecha Nacimiento  ////////////////////////////////////////////////////////////////

var documentBirthDate = document.getElementById("Birthdate").value;
if (documentBirthDate == "") {
    document.getElementById("Birthdate").style.borderColor = "FireBrick";
}
else {
    document.getElementById("Birthdate").style.borderColor = "Green";
}

document.querySelector('#Birthdate').addEventListener('input', function () {
    var Birthdate = this.value;
    if (Birthdate != null) {
        this.style.borderColor = "Green";
    } else {
        this.style.borderColor = "FireBrick";
    }
});

/////////////////////////////// Rol  ////////////////////////////////////////////////////////////////
var documentRol = document.getElementById("Rol").value;
if (documentRol == "") {
    document.getElementById("Rol").style.borderColor = "FireBrick";
}
else {
    document.getElementById("Rol").style.borderColor = "Green";
}

document.querySelector('#Rol').addEventListener('input', function () {
    var rol = this.value;
    if (rol > 0) {
        this.style.borderColor = "Green";
    } else {
        this.style.borderColor = "FireBrick";
    }
});

/////////////////////////////// Address  ////////////////////////////////////////////////////////////////
if (document.getElementById("Address").value == "") {
    document.getElementById("Address").style.borderColor = "FireBrick";
}
else {
    document.getElementById("Address").style.borderColor = "Green";
}

document.querySelector('#Address').addEventListener('keyup', function () {
    var Address = this.value;
    if (Address != "") {
        this.style.borderColor = "Green";
    } else {
        this.style.borderColor = "FireBrick";
    }
});


/////////////////////////////// Status  ////////////////////////////////////////////////////////////////
var documentStatusList = document.getElementById("StatusList").value;
if (documentStatusList == "") {
    document.getElementById("StatusList").style.borderColor = "FireBrick";
}
else {
    document.getElementById("StatusList").style.borderColor = "Green";
}

document.querySelector('#StatusList').addEventListener('input', function () {
    var rol = this.value;
    if (rol > 0) {
        this.style.borderColor = "Green";
    } else {
        this.style.borderColor = "FireBrick";
    }
});


