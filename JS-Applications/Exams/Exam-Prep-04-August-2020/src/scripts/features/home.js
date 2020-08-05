import { getAll } from "../data.js";

export default async function () {
    this.partials = {
        header: await this.load('./views/common/header.hbs'),
        footer: await this.load('./views/common/footer.hbs'),
        notFound: await this.load('./views/common/notFound.hbs')
    };

    let recipes = await getAll();

    recipes = recipes.reduce((acc, curr, i) => {
        curr.ingredients = curr.ingredients.split(', ');
        acc.push(curr);
        return acc;
    }, []);

    const data = Object.assign({ recipes }, this.app.userData);

    this.partial('./views/home.hbs', data);
}
