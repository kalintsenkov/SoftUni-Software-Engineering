const submitBtn = document.getElementById('submitBtn');
const loadBooksBtn = document.getElementById('loadBooks');
const booksListTBody = document.getElementById('booksList');
const titleInput = document.getElementById('title');
const authorInput = document.getElementById('author');
const isbnInput = document.getElementById('isbn');

const api = {
    books: 'https://api.backendless.com/3EF35E83-C6D2-9A77-FF84-B3914ED62F00/5991DFF1-2FDD-44CF-99F4-DB2D7E38B868/data/books'
};

window.addEventListener('load', () => {
    loadBooksBtn.addEventListener('click', getAllBooks);
    submitBtn.addEventListener('click', createBook);

    async function getAllBooks() {
        booksListTBody.innerHTML = '';

        const response = await fetch(api.books);
        const books = await response.json();

        [...books].forEach(book => {
            const tr = document.createElement('tr');
            const titleTd = document.createElement('td');
            const authorTd = document.createElement('td');
            const isbnTd = document.createElement('td');
            const buttonsTd = document.createElement('td');
            const editBtn = document.createElement('button');
            const deleteBtn = document.createElement('button');

            tr.dataset.id = book.objectId;
            titleTd.innerHTML = book.title;
            authorTd.innerHTML = book.author;
            isbnTd.innerHTML = book.isbn;
            editBtn.innerHTML = 'Edit';
            deleteBtn.innerHTML = 'Delete';

            buttonsTd.appendChild(editBtn);
            buttonsTd.appendChild(deleteBtn);

            tr.appendChild(titleTd);
            tr.appendChild(authorTd);
            tr.appendChild(isbnTd);
            tr.appendChild(buttonsTd);

            booksListTBody.appendChild(tr);

            titleTd.addEventListener('click', loadBook);
            authorTd.addEventListener('click', loadBook);
            isbnTd.addEventListener('click', loadBook);
            editBtn.addEventListener('click', editBook);
            deleteBtn.addEventListener('click', deleteBook);
        });
    }

    async function createBook(e) {
        e.preventDefault();

        const bookObj = {
            title: titleInput.value,
            author: authorInput.value,
            isbn: isbnInput.value,
        };

        authorInput.value = '';
        titleInput.value = '';
        isbnInput.value = '';

        const requestObj = {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(bookObj)
        };

        await fetch(api.books, requestObj);
        await getAllBooks();
    }

    async function loadBook(e) {
        const tr = e.target.parentElement;
        const id = tr.dataset.id;

        const response = await fetch(api.books + '/' + id);
        const book = await response.json();

        authorInput.value = book.author;
        titleInput.value = book.title;
        isbnInput.value = book.isbn;
    }

    async function editBook(e) {
        const tr = e.target.parentElement.parentElement;
        const id = tr.dataset.id;

        if (!titleInput.value || !authorInput.value || !isbnInput.value) {
            return;
        }

        const bookObj = {
            title: titleInput.value,
            author: authorInput.value,
            isbn: isbnInput.value,
        };

        authorInput.value = '';
        titleInput.value = '';
        isbnInput.value = '';

        const requestObj = {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(bookObj)
        };

        await fetch(api.books + '/' + id, requestObj);
        await getAllBooks();
    }

    async function deleteBook(e) {
        const id = e.target.parentElement.parentElement.dataset.id;

        const requestObj = {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json'
            }
        };

        await fetch(api.books + '/' + id, requestObj);
        await getAllBooks();
    }
});
