import { getTeamById } from '../data.js';

export default async function () {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        teamMember: await this.load('./templates/catalog/teamMember.hbs'),
        teamControls: await this.load('./templates/catalog/teamControls.hbs')
    };

    const data = await getTeamById(this.params.id);

    Object.assign(data, this.app.userData);

    if (data.ownerId === this.app.userData.userId) {
        data.isAuthor = true;
    }

    if (data.objectId === this.app.userData.teamId) {
        data.isOnTeam = true;
    }

    this.partial('./templates/catalog/details.hbs', data);
}