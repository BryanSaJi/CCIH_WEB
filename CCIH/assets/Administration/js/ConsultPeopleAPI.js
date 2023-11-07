function ConsultPeopleInfo() {

    let PersonalID = $("#PersonalId").val();

    if (PersonalID.length > 0) {
        $.ajax({
            type: "GET",
            url: "https://apis.gometa.org/cedulas/" + PersonalID,
            dataType: "json",
            success: function (result) {
                    $("#nameField").val(result.results[0].firstname1);
                    $("#lastNameField").val(result.results[0].lastname1),
                    $("#slnFIELD").val(result.results[0].lastname2);
            }
        });
    }
    else {
        $("#nameField").val("");
            $("#lastNameField").val("");
            $("#slnFIELD").val("");
    }
}