import { getTeams } from '../data.js';

export default async function () {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        team: await this.load('./templates/catalog/team.hbs')
    };

    const teams = await getTeams();
    const data = Object.assign({ teams }, this.app.userData);

    this.partial('./templates/catalog/teamCatalog.hbs', data);
}