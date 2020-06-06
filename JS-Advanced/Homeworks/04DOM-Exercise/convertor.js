function solve() {
    
    const binary = document.createElement('option');
    binary.value = 'binary';
    binary.textContent = 'Binary';

    const hexa = document.createElement('option');
    hexa.value = 'hexadecimal';
    hexa.textContent = 'Hexadecimal';
    
    const selectMenuTo = document.querySelector('#selectMenuTo');
    selectMenuTo.appendChild(binary);
    selectMenuTo.appendChild(hexa);

    const convertMap = {
        'binary': (num) => num.toString(2),
        'hexadecimal': (num) => num.toString(16).toUpperCase()
    };

    const button = document.querySelector('button');

    button.addEventListener('click', function () {
        const number = Number(document.querySelector('#input').value);
        const menuValue = selectMenuTo.value;

        document.querySelector('#result').value = convertMap[menuValue](number);
    });
}