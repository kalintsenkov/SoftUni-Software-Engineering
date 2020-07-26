import home from './controllers/home.js';
import about from './controllers/about.js';
import register, { registerPost } from './controllers/register.js';
import login, { loginPost, logout } from './controllers/login.js';
import catalog from './controllers/catalog.js';
import details from './controllers/details.js';
import create, { createPost } from './controllers/create.js';
import edit from './controllers/edit.js';

window.addEventListener('load', async function () {

    const app = Sammy('#main', async function () {

        this.use('Handlebars', 'hbs');

        this.userData = {
            loggedIn: false,
            hasTeam: false
        };

        this.get('#/', home);
        this.get('#/home', home);
        this.get('index.html', home);

        this.get('#/about', about);

        this.get('#/register', register);
        this.post('#/register', (context) => { registerPost.call(context); });

        this.get('#/login', login);
        this.post('#/login', (context) => { loginPost.call(context); });

        this.get('#/logout', logout);

        this.get('#/catalog', catalog);
        this.get('#/catalog/:id', details);

        this.get('#/create', create);
        this.post('#/create', (context) => { createPost.call(context); });

        this.get('#/edit/:id', edit);
    });

    app.run('#/');
});
