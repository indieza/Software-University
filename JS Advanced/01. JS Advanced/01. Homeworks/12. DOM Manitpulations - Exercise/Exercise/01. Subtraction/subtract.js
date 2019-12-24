function subtract() {
    const firstNumber = document.getElementById("firstNumber").value;
    const secondNumber = document.getElementById("secondNumber").value;

    const result = document.getElementById("result");
    result.innerHTML = Number(firstNumber) - Number(secondNumber);
}