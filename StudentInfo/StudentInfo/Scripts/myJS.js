$(document).ready(function () {
    $('#txtDOB').datepicker();
    $('#txtSDATE').datepicker();
});

$(document).ready(function () {
    $("#form1").validationEngine('attach', { promptPosition: "topRight" });
});
$(document).ready(function DateFormat(field, rules, i, options) {
    var regex = /^(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}$/;
    if (!regex.test(field.val())) {
        return "Please enter date in dd/MM/yyyy format."
    }
});