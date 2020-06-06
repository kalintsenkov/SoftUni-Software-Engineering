function subtract() {
    const firstNumber = Number(document.getElementById('firstNumber').value);
    const secondNumber = Number(document.getElementById('secondNumber').value);

    const resultDiv = document.getElementById('result');
    resultDiv.innerText = firstNumber - secondNumber;
}