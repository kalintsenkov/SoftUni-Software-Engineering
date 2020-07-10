const url = 'http://localhost:3000/phonebook';

const phonebookUl = document.getElementById('phonebook');
const loadBtn = document.getElementById('btnLoad');
const createBtn = document.getElementById('btnCreate');
const personInput = document.getElementById('person');
const phoneInput = document.getElementById('phone');

function attachEvents() {
    loadBtn.addEventListener('click', loadData);
    createBtn.addEventListener('click', createData)

    function loadData() {
        fetch(url)
            .then(response => response.json())
            .then(data => {
                phonebookUl.innerHTML = '';

                for (const id in data) {
                    const { person, phone } = data[id];
                    const li = document.createElement('li');
                    li.innerHTML = `${person}: ${phone} `;
                    phonebookUl.appendChild(li);
                }
            });
    }

    function createData() {
        const data = {
            person: personInput.value,
            phone: phoneInput.value
        };

        personInput.value = '';
        phoneInput.value = '';

        fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(data)
        })
        .then(loadData())
    }
}

attachEvents();