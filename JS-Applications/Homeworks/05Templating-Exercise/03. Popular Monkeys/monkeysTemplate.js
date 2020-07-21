(async () => {
    const monkeyTemplate = await fetch('./templates/monkey.hbs');
    const monkeyTemplateString = await monkeyTemplate.text();

    const monkeyListTemplate = await fetch('./templates/monkey-list.hbs');
    const monkeyListTemplateString = await monkeyListTemplate.text();

    Handlebars.registerPartial('monkey', monkeyTemplateString);
    const template = Handlebars.compile(monkeyListTemplateString);

    const section = document.querySelector('section');

    section.innerHTML = template({ monkeys });

    section.addEventListener('click', (e) => {
        const target = e.target;

        if (target.nodeName !== 'BUTTON') {
            return;
        }

        const paragraph = target.nextElementSibling;
        const style = paragraph.style;

        style.display = style.display === 'none' ? '' : 'none';
    });
})();