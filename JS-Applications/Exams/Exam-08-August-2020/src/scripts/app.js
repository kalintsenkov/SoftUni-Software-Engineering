import home from './controllers/home.js';
import { getRegister, postRegister, getLogin, postLogin, getLogout } from './controllers/users.js';
import { getCreate, postCreate, getDetails, getEdit, postEdit, getDelete, getLike } from './controllers/movies.js';

window.addEventListener('load', async function () {
    const app = Sammy('#container', async function () {
        this.use('Handlebars', 'hbs');

        this.userData = {
            loggedIn: localStorage.getItem('email') ? true : false,
            email: localStorage.getItem('email') || '',
            userId: localStorage.getItem('userId') || ''
        };

        this.get('/', home);
        this.get('#/', home);
        this.get('#/home', home);

        this.get('#/register', getRegister);
        this.post('#/register', (context) => { postRegister.call(context); });

        this.get('#/login', getLogin);
        this.post('#/login', (context) => { postLogin.call(context); });

        this.get('#/logout', getLogout);

        this.get('#/create', getCreate);
        this.post('#/create', (context) => { postCreate.call(context); });

        this.get('#/details/:id', getDetails);

        this.get('#/edit/:id', getEdit);
        this.post('#/edit/:id', (context) => { postEdit.call(context); });

        this.get('#/delete/:id', getDelete);

        this.get('#/like/:id', getLike);
    });

    app.run('#/');
});
