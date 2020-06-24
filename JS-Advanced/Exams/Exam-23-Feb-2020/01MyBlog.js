'use strict'

function solve() {
    const siteContent = document.querySelector('.site-content');

    const articleSection = siteContent.querySelector('main > section');
    const archiveSection = document.querySelector('.archive-section > ul');

    const creator = document.querySelector('#creator');
    const title = document.querySelector('#title');
    const category = document.querySelector('#category');
    const content = document.querySelector('#content');

    const createBtn = document.querySelector('.btn.create');

    createBtn.addEventListener('click', (e) => {
        e.preventDefault();

        const deleteBtn = el('button', 'Delete', { className: 'btn delete' });
        const archiveBtn = el('button', 'Archive', { className: 'btn archive' });

        const article = el('article', [
            el('h1', title.value),
            el('p', [
                'Category: ',
                el('strong', category.value)
            ]),
            el('p', [
                'Creator: ',
                el('strong', creator.value)
            ]),
            el('p', content.value),
            el('div', [deleteBtn, archiveBtn], { className: 'buttons' })
        ]);

        articleSection.appendChild(article);

        deleteBtn.addEventListener('click', () => {
            article.remove();
        });

        archiveBtn.addEventListener('click', () => {
            const title = article.querySelector('h1').innerText;
            const li = el('li', title);

            article.remove();
            archiveSection.appendChild(li);

            const sorted = Array.from(archiveSection.querySelectorAll('li'))
                .map(li => li.innerText)
                .sort((a, b) => a.localeCompare(b));

            archiveSection.innerHTML = ''
            sorted.forEach(liText => archiveSection.appendChild(el('li', liText)));
        })
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
