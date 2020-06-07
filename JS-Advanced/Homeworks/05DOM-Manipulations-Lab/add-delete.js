function addItem() {
    const input = document.querySelector('#newText');
    
    const a = document.createElement('a');
    a.href = '#';
    a.innerText = '[Delete]';

    const li = document.createElement('li');
    li.innerText = input.value; 
    li.appendChild(a);

    const ulList = document.querySelector('#items');
    ulList.appendChild(li);
    
    a.addEventListener('click', function(e) {
       ulList.removeChild(e.target.parentElement);
    });

    input.value = '';
}