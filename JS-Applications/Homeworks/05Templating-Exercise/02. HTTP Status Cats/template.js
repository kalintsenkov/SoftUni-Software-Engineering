(async () => {
    const catCardTemplate = await fetch('./templates/cat-card.hbs');
    const catCardTemplateString = await catCardTemplate.text();

    const catsListTemplate = await fetch('./templates/cats-list.hbs');
    const catsListTemplateString = await catsListTemplate.text();

    Handlebars.registerPartial('cat', catCardTemplateString);
    const template = Handlebars.compile(catsListTemplateString);

    renderCatTemplate();

    function renderCatTemplate() {
        const catsListSection = document.getElementById('allCats');
        catsListSection.innerHTML = template({ cats });

        catsListSection.addEventListener('click', (e) => {
            const target = e.target;

            if (!target.classList.contains('showBtn')) {
                return;
            }

            target.innerHTML = target.innerHTML === 'Show status code'
                ? 'Hide status code'
                : 'Show status code';

            const statusDiv = target.nextElementSibling;
            const style = statusDiv.style

            style.display = style.display === 'none'
                ? ''
                : 'none';
        });
    }
})();
