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


/////////////////////////////// Amount  ////////////////////////////////////////////////////////////////
var DocumentAmount = document.getElementById("amount").value;

if (DocumentAmount == "") {
    document.getElementById("Amount").style.borderColor = "FireBrick";
}
else {
    document.getElementById("Amount").style.borderColor = "Green";
}

document.querySelector('#Amount').addEventListener('input', function () {
    var Amount = this.value;
    var validationMessage = document.querySelector('#AmountValidationMessage');
    if (!/^\d+$/.test(Amount)) {
        validationMessage.innerHTML = "El monto solo permite numeros.";
        this.style.borderColor = "FireBrick";
    } else {
        validationMessage.innerHTML = "";
        this.style.borderColor = "Green";
    }
});

/////////////////////////////// PaymentType  ////////////////////////////////////////////////////////////////

function checkPaymentTypeList() {
    var selectedValue = PaymentTypeDropdown.value;
    var validationMessage = document.getElementById('PaymentTypeValidationMessage');

    if (selectedValue === '0') {
        validationMessage.innerHTML = "Seleccione un tipo de pago valido.";
    } else {
        validationMessage.innerHTML = "";
    }

    checkSubmitButton();
}

/////////////////////////////// IncomeOutcome  ////////////////////////////////////////////////////////////////

function checkIncomeOutcomeList() {
    var selectedValue = IncomeOutcomeDropdown.value;
    var validationMessage = document.getElementById('IncomeOutcomeValidationMessage');

    if (selectedValue === '0') {
        validationMessage.innerHTML = "Seleccione un caracter valido.";
    } else {
        validationMessage.innerHTML = "";
    }

    checkSubmitButton();
}

/////////////////////////////// Reason  ////////////////////////////////////////////////////////////////


function checkReasonList() {
    var selectedValue = ReasonDropdown.value;
    var validationMessage = document.getElementById('ReasonValidationMessage');

    if (selectedValue === '0') {
        validationMessage.innerHTML = "Seleccione un motivo valido.";
    } else {
        validationMessage.innerHTML = "";
    }

    checkSubmitButton();
}


/////////////////////////////// Fecha Creacion  ////////////////////////////////////////////////////////////////

var documentCreationDate = document.getElementById("CreationDate").value;
if (documentCreationDate == "") {
    document.getElementById("CreationDate").style.borderColor = "FireBrick";
}
else {
    document.getElementById("CreationDate").style.borderColor = "Green";
}

document.querySelector('#CreationDate').addEventListener('input', function () {
    var CreationDate = this.value;
    if (CreationDate != null) {
        this.style.borderColor = "Green";
    } else {
        this.style.borderColor = "FireBrick";
    }
});