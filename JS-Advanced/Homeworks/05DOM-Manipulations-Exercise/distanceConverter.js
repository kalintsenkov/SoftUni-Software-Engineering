function attachEventsListeners() {
    const convertBtn = document.querySelector('input[value="Convert"]');
    const input = document.querySelector('#inputDistance');
    const output = document.querySelector('#outputDistance');
    const inputUnits = document.querySelector('select#inputUnits');
    const outputUnits = document.querySelector('select#outputUnits');

    convertBtn.addEventListener('click', onConvert);

    const inputOperations = {
        'km':  (input, operator) => operator === '*' ? input * 1000 : input / 1000,
        'm':   (input, _) => input,
        'cm':  (input, operator) => operator === '*' ? input * 0.01 : input / 0.01,
        'mm':  (input, operator) => operator === '*' ? input * 0.001 : input / 0.001,
        'mi':  (input, operator) => operator === '*' ? input * 1609.34 : input / 1609.34,
        'yrd': (input, operator) => operator === '*' ? input * 0.9144 : input / 0.9144,
        'ft':  (input, operator) => operator === '*' ? input * 0.3048 : input / 0.3048,
        'in':  (input, operator) => operator === '*' ? input * 0.0254 : input / 0.0254
    };

    function onConvert() {
        const inputValue = Number(input.value);

        const inputUnit = inputUnits.value;
        const outputUnit = outputUnits.value;

        const inputToM = inputOperations[inputUnit](inputValue, '*');
        const result = inputOperations[outputUnit](inputToM, '/');

        output.value = result;
    }
}