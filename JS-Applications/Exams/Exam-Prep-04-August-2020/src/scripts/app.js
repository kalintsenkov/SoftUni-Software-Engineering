import home from './features/home.js';
import { getRegister, postRegister, getLogin, postLogin, getLogout } from './features/users.js';
import { getShare, postShare, getDetails, getEdit, postEdit, getArchive, getLike } from './features/recipes.js';

window.addEventListener('load', async function () {
    const app = Sammy('#rooter', async function () {
        this.use('Handlebars', 'hbs');

        this.userData = {
            loggedIn: false
        };

        this.get('#/', home);
        this.get('#/home', home);

        this.get('#/register', getRegister);
        this.post('#/register', (context) => { postRegister.call(context); });

        this.get('#/login', getLogin);
        this.post('#/login', (context) => { postLogin.call(context); });

        this.get('#/logout', getLogout);

        this.get('#/share', getShare);
        this.post('#/share', (context) => { postShare.call(context); });

        this.get('#/details/:id', getDetails);

        this.get('#/edit/:id', getEdit);
        this.post('#/edit/:id', (context) => { postEdit.call(context); });

        this.get('#/archive/:id', getArchive);

        this.get('#/like/:id', getLike);
    });

    app.run('#/');
});
