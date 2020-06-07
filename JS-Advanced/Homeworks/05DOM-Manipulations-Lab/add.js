function addItem() {
    const input = document.querySelector('#newItemText');
    
    const li = document.createElement('li');
    li.innerText = input.value; 

    const ulList = document.querySelector('#items');
    ulList.appendChild(li);

    input.value = '';
}