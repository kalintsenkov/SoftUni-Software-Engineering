const url = 'http://localhost:3000/messenger';

const messagesTextArea = document.getElementById('messages');
const authorInput = document.getElementById('author');
const contentInput = document.getElementById('content');
const submitBtn = document.getElementById('submit');
const refreshBtn = document.getElementById('refresh');

function attachEvents() {
    refreshBtn.addEventListener('click', loadData);
    submitBtn.addEventListener('click', createData);

    function loadData() {
        fetch(url)
            .then(response => response.json())
            .then(data => {
                messagesTextArea.innerHTML = '';

                for (const key in data) {
                    const { author, content } = data[key];
                    messagesTextArea.innerHTML += `${author}: ${content}\n`;
                }
            });
    }

    function createData() {
        const data = {
            author: authorInput.value,
            content: contentInput.value
        };

        authorInput.value = '';
        contentInput.value = '';

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