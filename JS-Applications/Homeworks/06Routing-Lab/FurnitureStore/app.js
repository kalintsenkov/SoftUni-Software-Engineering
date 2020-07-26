import * as data from './data.js';

window.addEventListener('load', async function () {

    const app = Sammy('#container', async function () {

        this.use('Handlebars', 'hbs');

        this.get('#/', async function () {
            const furniture = await data.allFurniture();

            this.partials = {
                furnitureItem: await this.load('./templates/partials/furniture-item.hbs')
            };

            await this.partial('./templates/all.hbs', { furniture });
        });

        this.get('#/details/:id', async function (context) {
            const id = context.params.id;
            const furniture = await data.getFurniture(id);

            await this.partial('./templates/details.hbs', { furniture });
        });

        this.get('#/create', async function () {
            await this.partial('./templates/create.hbs');

            const newMakeEl = document.getElementById('new-make');
            const newModelEl = document.getElementById('new-model');
            const newYearEl = document.getElementById('new-year');
            const newDescriptionEl = document.getElementById('new-description');
            const newPriceEl = document.getElementById('new-price');
            const newImageEl = document.getElementById('new-image');
            const newMaterialEl = document.getElementById('new-material');

            document.querySelector('.btn.btn-primary').addEventListener('click', createHandler);

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

        this.get('#/profile', async function () {
            const furniture = await data.allFurniture();

            this.partials = {
                furnitureItem: await this.load('./templates/partials/furniture-item.hbs')
            };

            await this.partial('./templates/profile.hbs', { furniture });
        });
    });

    app.run('#/');
});