function solve() {
    const box = document.querySelector('#box');
    const button = document.querySelector('button#dropdown');
    const dropdownUl = document.querySelector('ul#dropdown-ul');

    button.addEventListener('click', function () {
        if (dropdownUl.style.display === 'none' || !dropdownUl.style.display) {
            dropdownUl.style.display = 'block';
        } else {
            dropdownUl.style.display = 'none';
        }

        box.style.color = 'white';
        box.style.backgroundColor = 'black';
    });

    dropdownUl.addEventListener('click', function (e) {
        box.style.color = 'black';
        box.style.backgroundColor = e.target.textContent;
    });
}