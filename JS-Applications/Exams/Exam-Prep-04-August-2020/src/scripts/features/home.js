export default async function () {
    this.partials = {
        header: await this.load('./views/common/header.hbs'),
        footer: await this.load('./views/common/footer.hbs'),
        notFound: await this.load('./views/common/notFound.hbs')
    };

    this.partial('./views/home.hbs', this.app.userData);
}
