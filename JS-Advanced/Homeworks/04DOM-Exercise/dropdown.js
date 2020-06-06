function addItem() {
    const newItemText = document.getElementById('newItemText').value;
    const newItemValue = document.getElementById('newItemValue').value;

    const option = document.createElement('option');
    option.value = newItemValue;
    option.textContent = newItemText;

    const menu = document.getElementById('menu');
    menu.appendChild(option);

    document.getElementById('newItemText').value = '';
    document.getElementById('newItemValue').value = '';
}