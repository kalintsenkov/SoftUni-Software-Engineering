import home from './features/home.js';
import { registerGet, registerPost, loginGet, loginPost, logoutGet } from './features/users.js';
import { create, editGet, edit, deleteGet, details } from './features/posts.js';

window.addEventListener('load', async function () {

    const app = Sammy('#root', async function () {

        this.use('Handlebars', 'hbs');

        this.userData = {
            loggedIn: false
        };

        this.get('#/', home);
        this.get('#/home', home);

        this.get('#/register', registerGet);
        this.post('#/register', (context) => { registerPost.call(context) });

        this.get('#/login', loginGet);
        this.post('#/login', (context) => { loginPost.call(context) });

        this.get('#/logout', logoutGet);

        this.get('#/details/:id', details);

        this.get('#/edit/:id', editGet);
        this.post('#/edit/:id', (context) => { edit.call(context) });

        this.get('#/delete/:id', deleteGet);

        this.post('/create-post', (context) => { create.call(context) });
    });

    app.run('#/home');
});