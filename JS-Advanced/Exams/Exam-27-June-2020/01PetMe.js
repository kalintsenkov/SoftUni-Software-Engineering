'use strict'

function solve() {
    const inputs = document.querySelectorAll('input');

    const nameInput = inputs[0];
    const ageInput = inputs[1];
    const kindInput = inputs[2];
    const ownerInput = inputs[3];

    const adoptionSection = document.querySelector('#adoption');
    const adoptionUl = adoptionSection.querySelector('ul');

    const adoptedSection = document.querySelector('#adopted');
    const adoptedUl = adoptedSection.querySelector('ul');

    const addButton = document.querySelector('button');

    addButton.addEventListener('click', (e) => {
        e.preventDefault();

        const name = nameInput.value;
        const age = ageInput.value;
        const kind = kindInput.value;
        const owner = ownerInput.value;

        if (!name || !age || !kind || !owner) {
            return;
        }

        if (isNaN(age)) {
            return;
        }

        nameInput.value = '';
        ageInput.value = '';
        kindInput.value = '';
        ownerInput.value = '';

        const ownerSpan = el('span', `Owner: ${owner}`);
        const contactButton = el('button', 'Contact with owner');

        const li = el('li', [
            el('p', [
                el('strong', `${name}`),
                ' is a ',
                el('strong', `${age}`),
                ' year old ',
                el('strong', `${kind}`)
            ]),
            ownerSpan,
            contactButton
        ]);

        adoptionUl.appendChild(li);

        contactButton.addEventListener('click', () => {
            const newOwner = el('input', '', { placeholder: 'Enter your names' });
            const takeItButton = el('button', 'Yes! I take it!');
            const div = el('div', [newOwner, takeItButton]);

            li.removeChild(contactButton);
            li.appendChild(div);

            takeItButton.addEventListener('click', () => {
                if (!newOwner.value) {
                    return;
                }

                li.remove();
                li.removeChild(ownerSpan);
                li.removeChild(div);

                const newOwnerSpan = el('span', `New Owner: ${newOwner.value}`);
                const checked = el('button', 'Checked');

                li.appendChild(newOwnerSpan);
                li.appendChild(checked);
                adoptedUl.appendChild(li);

                checked.addEventListener('click', () => {
                    li.remove();
                })
            });
        });
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