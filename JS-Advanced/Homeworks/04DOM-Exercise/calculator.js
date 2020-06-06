function solve() {
    const output = document.querySelector('#expressionOutput');
    const resultOutput = document.querySelector('#resultOutput');

    const operations = {
        '+': (x, y) => x + y,
        '-': (x, y) => x - y,
        '*': (x, y) => x * y,
        '/': (x, y) => x / y,
    };

    let left = '';
    let right = '';
    let operator = '';

    const buttons = document.querySelectorAll('button');

    Array.from(buttons).forEach(button => {
        button.addEventListener('click', function (e) {
            const value = e.target.value;

            if (value === '=') {
                if (left === '' || right === '' || operator == '') {
                    resultOutput.textContent = NaN;
                } else {
                    const result = operations[operator](Number(left), Number(right));
                    resultOutput.textContent = result;
                    left = '';
                    right = '';
                    operator = '';
                }
            } else if (value === 'Clear') {
                document.querySelector('#expressionOutput').innerHTML = '';
                document.querySelector('#resultOutput').innerHTML = '';

            } else if (value === '.') {
                if (operator === '') {
                    left += value;
                } else {
                    right += value;
                }

                output.textContent += value;
            } else if (isNaN(value)) {
                operator = value;
                output.textContent += ` ${value} `;
            } else {
                if (operator === '') {
                    left += value;
                } else {
                    right += value;
                }

                output.textContent += value;
            }
        });
    });
}