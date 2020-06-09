function encodeAndDecodeMessages() {
    const buttonsList = document.querySelectorAll('button');
    const encodeBtn = buttonsList[0];
    const decodeBtn = buttonsList[1];

    const textAreaList = document.querySelectorAll('textarea');
    const inputTextArea = textAreaList[0];
    const outputTextArea = textAreaList[1];

    encodeBtn.addEventListener('click', encodeHandler);
    decodeBtn.addEventListener('click', decodeHandler);

    function encodeHandler() {
        const inputText = inputTextArea.value;
        
        let encoded = '';

        for (let i = 0; i < inputText.length; i++) {
            const char = inputText[i];
            encoded += String.fromCharCode(char.charCodeAt(0) + 1);
        }

        inputTextArea.value = '';
        outputTextArea.value = encoded;
    }

    function decodeHandler() {
        const outputText = outputTextArea.value;

        let decoded = '';

        for (let i = 0; i < outputText.length; i++) {
            const char = outputText[i];
            decoded += String.fromCharCode(char.charCodeAt(0) - 1);
        }

        outputTextArea.value = decoded;
    }
}