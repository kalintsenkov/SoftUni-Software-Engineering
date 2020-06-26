'use strict'

function solve() {
    const sections = document.querySelectorAll('section');

    const oldBooks = sections[0].querySelector('div.bookShelf');
    const newBooks = sections[1].querySelector('div.bookShelf');

    const inputs = document.querySelectorAll('input');
    const title = inputs[0];
    const year = inputs[1];
    const price = inputs[2];

    const totalProfitHeading = document.querySelectorAll('h1')[1];

    let totalProfit = 0;

    document.querySelector('button').addEventListener('click', (e) => {
        e.preventDefault();

        if (!title.value || !year.value || !price.value) {
            return;
        }

        let bookPrice = year.value >= 2000
            ? Number(price.value)
            : Number(price.value) * 0.85;

        const buyBtn = el('button', `Buy it only for ${bookPrice.toFixed(2)} BGN`);
        const moveBtn = el('button', 'Move to old section');

        const bookDiv = el('div', el('p', `${title.value} [${year.value}]`), { className: 'book' });

        bookDiv.appendChild(buyBtn);

        if (year.value >= 2000) {
            bookDiv.appendChild(moveBtn);
            newBooks.appendChild(bookDiv)

            moveBtn.addEventListener('click', moveButtonHandler);
        } else {
            oldBooks.appendChild(bookDiv)
        }

        buyBtn.addEventListener('click', buyButtonHandler);

        function buyButtonHandler(e) {
            e.target.parentElement.parentElement.removeChild(bookDiv)
            totalProfit += bookPrice;
            totalProfitHeading.innerText = `Total Store Profit: ${totalProfit.toFixed(2)} BGN`;
        }

        function moveButtonHandler() {
            newBooks.removeChild(bookDiv);
            bookDiv.removeChild(buyBtn);

            if (moveBtn !== undefined) {
                bookDiv.removeChild(moveBtn);
            }

            bookPrice *= 0.85;

            buyBtn.innerText = `Buy it only for ${bookPrice.toFixed(2)} BGN`;

            bookDiv.appendChild(buyBtn);
            oldBooks.appendChild(bookDiv);

            buyBtn.addEventListener('click', buyButtonHandler);
        }
    });

    function el(type, content, attributes) {
        const result = document.createElement(type);

        if (attributes !== undefined) {
            Object.assign(result, attributes);
        }

        if (Array.isArray(content)) {
            content.forEach(append);
        } else {
            append(content);
        }

        function append(node) {
            if (typeof node === 'string') {
                node = document.createTextNode(node);
            }
            result.appendChild(node);
        }

        return result;
    }
}