import * as data from './data.js';

window.addEventListener('load', async function () {

    const app = Sammy('#container', async function () {

        this.get('#/', async function () {
            const furniture = await data.allFurniture();

            const furnitureItemTemplate = await fetch('./templates/partials/furniture-item.hbs');
            const furnitureItemTemplateString = await furnitureItemTemplate.text();

            const indexTemplate = await fetch('./templates/all.hbs');
            const indexTemplateString = await indexTemplate.text();

            Handlebars.registerPartial('furnitureItem', furnitureItemTemplateString);
            const template = Handlebars.compile(indexTemplateString);

            this.swap(template({ furniture }));
        });

        this.get('#/details/:id', async function (context) {
            const id = context.params.id;
            const furniture = await data.getFurniture(id)

            const detailsTemplate = await fetch('./templates/details.hbs');
            const detailsTemplateString = await detailsTemplate.text();

            const template = Handlebars.compile(detailsTemplateString);

            this.swap(template({ furniture }));
        });

        this.get('#/create', async function () {
            const createTemplate = await fetch('./templates/create.hbs');
            const createTemplateString = await createTemplate.text();

            const template = Handlebars.compile(createTemplateString);

            this.swap(template());

            const newMakeEl = document.getElementById('new-make');
            const newModelEl = document.getElementById('new-model');
            const newYearEl = document.getElementById('new-year');
            const newDescriptionEl = document.getElementById('new-description');
            const newPriceEl = document.getElementById('new-price');
            const newImageEl = document.getElementById('new-image');
            const newMaterialEl = document.getElementById('new-material');

            const createBtn = document.querySelector('.btn.btn-primary');

            createBtn.addEventListener('click', createHandler);

            async function createHandler(e) {
                e.preventDefault();

                const make = newMakeEl.value;
                const model = newModelEl.value;
                const year = Number(newYearEl.value);
                const description = newDescriptionEl.value;
                const price = Number(newPriceEl.value);
                const image = newImageEl.value;
                const material = newMaterialEl.value;

                const furnitureObj = {
                    make,
                    model,
                    year,
                    description,
                    price,
                    image,
                    material
                };

                const id = await data.createFurniture(furnitureObj);

                window.location = `#/details/${id}`;
            }
        });

        this.get('#/profile', async function (context) {
            const furniture = await data.allFurniture();

            const furnitureItemTemplate = await fetch('./templates/partials/furniture-item.hbs');
            const furnitureItemTemplateString = await furnitureItemTemplate.text();

            const profileTemplate = await fetch('./templates/profile.hbs');
            const profileTemplateString = await profileTemplate.text();

            Handlebars.registerPartial('furnitureItem', furnitureItemTemplateString);
            const template = Handlebars.compile(profileTemplateString);

            this.swap(template({ furniture }));

            document.querySelector('.btn.btn-danger').addEventListener('click', deleteHandler);

            async function deleteHandler(e) {
                // e.target.preventDefault();
                console.log(e.target);

                // const id = e.target.getAttribute('href');
                // await data.deleteFurniture(id);

                // window.location = `#/`;
            }
        });
    });

    app.run('#/');
});