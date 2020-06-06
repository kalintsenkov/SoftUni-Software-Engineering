function solve() {
    const button = document.querySelector('button');
    const liList = document.querySelectorAll('li');

    button.addEventListener('click', function () {
        const inputValue = document.querySelector('input').value;
        const position = inputValue.toLowerCase().charCodeAt(0) - 97;

        const currentText = liList[position].innerText;

        const fixed = fixLetters(inputValue);

        currentText === ''
            ? liList[position].textContent = fixed
            : liList[position].textContent += ', ' + fixed;

        document.querySelector('input').value = '';
    });

    function fixLetters(input) {
        let result = '';
        result += input[0].toUpperCase();
        for (let i = 1; i < input.length; i++) {
            const char = input[i];
            result += char.toLowerCase();
        }
        return result;
    }
}