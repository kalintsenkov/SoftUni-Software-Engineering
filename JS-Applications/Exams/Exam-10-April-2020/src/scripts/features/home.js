export default async function () {
    this.partials = {
        header: await this.load('./templates/common/header.hbs')
    };

    this.partial('./templates/home/home.hbs', this.app.userData);
}