(async () => {
    const root = document.getElementById('root');

    const townItemTemplate = await fetch('./templates/town-item.hbs');
    const townItemTemplateString = await townItemTemplate.text();

    const townsListTemplate = await fetch('./templates/towns-list.hbs');
    const townsListTemplateString = await townsListTemplate.text();

    Handlebars.registerPartial('town', townItemTemplateString);
    const template = Handlebars.compile(townsListTemplateString);

    const townsInput = document.getElementById('towns');
    const loadTownsBtn = document.getElementById('btnLoadTowns');

    loadTownsBtn.addEventListener('click', (e) => {
        e.preventDefault();

        const townsValue = townsInput.value;

        if (!townsValue) {
            return;
        }

        const towns = townsValue.split(', ');
        const townsUl = template({ towns });

        root.innerHTML = townsUl;
    });
})();