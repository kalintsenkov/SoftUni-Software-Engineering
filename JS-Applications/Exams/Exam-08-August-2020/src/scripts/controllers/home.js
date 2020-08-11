import { getAllMovies } from "../data.js";

export default async function () {
    this.partials = {
        header: await this.load('./views/common/header.hbs'),
        footer: await this.load('./views/common/footer.hbs')
    };

    const search = this.params.search || '';
    const movies = await getAllMovies(search);

    const data = Object.assign({ movies }, this.app.userData);

    this.partial('./views/home.hbs', data);
}
