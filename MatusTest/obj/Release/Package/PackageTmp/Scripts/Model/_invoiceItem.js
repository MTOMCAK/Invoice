
function calculateTotal() {
    var quantity = $("#quantity").val();
    var unitPrice = $("#unitPrice").val();
    var totalPrice = $("#totalPrice");
    // calculate total
    if (quantity !== "" && unitPrice !== "") {
        totalPrice.val(Number(quantity * unitPrice).toFixed(2));
        // recalculate amount VAT
        calculateAmountVAT();
    }
    else {
        totalPrice.val(0);
    }
}

function calculateAmountVAT() {
    var percentageVAT = $("#percentageVAT").val();
    var totalPrice = $("#totalPrice").val();
    var amountVAT = $("#amountVAT");

    if (percentageVAT !== "" && totalPrice !== "") {
        amountVAT.val(Number(percentageVAT * totalPrice * 0.01).toFixed(2));
    }
    else {
        amountVAT.val(0);
    }
}