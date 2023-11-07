
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

////////////////////////////  Cursos   ///////////////////////////////////////////////////////////////////

var documentListaCursos = document.getElementById("ListaCursos").value;
if (documentListaCursos == "") {
    document.getElementById("ListaCursos").style.borderColor = "FireBrick";
}
else {
    document.getElementById("ListaCursos").style.borderColor = "Green";
}

document.querySelector('#ListaCursos').addEventListener('input', function () {
    var dato = this.value;
    if (dato > 0) {
        this.style.borderColor = "Green";
    } else {
        this.style.borderColor = "FireBrick";
    }
});

////////////////////////////  Modalidad   ///////////////////////////////////////////////////////////////////

var documentListaModalidad = document.getElementById("ListaModalidad").value;
if (documentListaModalidad == "") {
    document.getElementById("ListaModalidad").style.borderColor = "FireBrick";
}
else {
    document.getElementById("ListaModalidad").style.borderColor = "Green";
}

document.querySelector('#ListaModalidad').addEventListener('input', function () {
    var dato = this.value;
    if (dato > 0) {
        this.style.borderColor = "Green";
    } else {
        this.style.borderColor = "FireBrick";
    }
});

////////////////////////////  Nivel   ///////////////////////////////////////////////////////////////////

var documentListaNivel = document.getElementById("ListaNivel").value;
if (documentListaNivel == "") {
    document.getElementById("ListaNivel").style.borderColor = "FireBrick";
}
else {
    document.getElementById("ListaNivel").style.borderColor = "Green";
}

document.querySelector('#ListaNivel').addEventListener('input', function () {
    var dato = this.value;
    if (dato > 0) {
        this.style.borderColor = "Green";
    } else {
        this.style.borderColor = "FireBrick";
    }
});

////////////////////////////  Horario   ///////////////////////////////////////////////////////////////////

var documentListaHorario = document.getElementById("ListaHorario").value;
if (documentListaHorario == "") {
    document.getElementById("ListaHorario").style.borderColor = "FireBrick";
}
else {
    document.getElementById("ListaHorario").style.borderColor = "Green";
}

document.querySelector('#ListaHorario').addEventListener('input', function () {
    var dato = this.value;
    if (dato > 0) {
        this.style.borderColor = "Green";
    } else {
        this.style.borderColor = "FireBrick";
    }
});

////////////////////////////  Monto   ///////////////////////////////////////////////////////////////////

var documentMonto = document.getElementById("Monto").value;
if (documentMonto == "") {
    document.getElementById("Monto").style.borderColor = "FireBrick";
}
else {
    document.getElementById("Monto").style.borderColor = "Green";
}

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

var documentfechamatricula = document.getElementById("fechamatricula").value;
if (documentfechamatricula == "") {
    document.getElementById("fechamatricula").style.borderColor = "FireBrick";
}
else {
    document.getElementById("fechamatricula").style.borderColor = "Green";
}

document.querySelector('#fechamatricula').addEventListener('input', function () {
    var Birthdate = this.value;
    if (Birthdate != null) {
        this.style.borderColor = "Green";
    } else {
        this.style.borderColor = "FireBrick";
    }
});

/////////////////////////////// DayPay  ////////////////////////////////////////////////////////////////

var documentDayPay = document.getElementById("DayPay").value;

if (documentDayPay == "") {
    document.getElementById("DayPay").style.borderColor = "FireBrick";
}
else {
    document.getElementById("DayPay").style.borderColor = "Green";
}

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

var documentComment = document.getElementById("Comment").value;
if (documentComment == "") {
    document.getElementById("Comment").style.borderColor = "FireBrick";
}
else {
    document.getElementById("Comment").style.borderColor = "Green";
}

document.querySelector('#Comment').addEventListener('input', function () {
    var Birthdate = this.value;
    if (Birthdate != null) {
        this.style.borderColor = "Green";
    } else {
        this.style.borderColor = "FireBrick";
    }
});