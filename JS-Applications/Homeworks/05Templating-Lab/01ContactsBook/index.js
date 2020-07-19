(async () => {
    const appDiv = document.getElementById('app');

    const contactCartTemplate = await fetch('./templates/contact-card.hbs');
    const contactCartTemplateString = await contactCartTemplate.text();

    const contactsTemplate = await fetch('./templates/contacts.hbs');
    const contactsTemplateString = await contactsTemplate.text();

    Handlebars.registerPartial('contact', contactCartTemplateString);
    const template = Handlebars.compile(contactsTemplateString);
    const contactsDiv = template({ contacts });

    appDiv.innerHTML = contactsDiv;

    appDiv.addEventListener('click', (e) => {
        const target = e.target;
        if (target.className === 'detailsBtn') {
            const detailsDiv = target.parentElement.querySelector('div');
            detailsDiv.classList.toggle('details');
        }
    });
})();