import { getEvents } from '../data.js';

export default async function () {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        notFound: await this.load('./templates/common/notFound.hbs')
    };

    const events = await getEvents();
    const hasEvents = events.length == 0 ? false : true;

    const data = Object.assign({ events, hasEvents }, this.app.userData);

    this.partial('./templates/home.hbs', data);
}
