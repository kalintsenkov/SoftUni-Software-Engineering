import home from './features/home.js';
import { registerGet, registerPost, loginGet, loginPost, logoutGet, profile } from './features/users.js';
import { createGet, createPost, details, editGet, editPost, deleteGet, join } from './features/events.js';

window.addEventListener('load', async function () {

    const app = Sammy('#main', async function () {

        this.use('Handlebars', 'hbs');

        this.userData = {
            loggedIn: false
        };

        this.get('#/', home);
        this.get('#/home', home);
        this.get('index.html', home);

        this.get('#/register', registerGet);
        this.post('#/register', (context) => { registerPost.call(context); });

        this.get('#/login', loginGet);
        this.post('#/login', (context) => { loginPost.call(context); });

        this.get('#/logout', logoutGet);

        this.get('#/profile', profile);

        this.get('#/organize', createGet);
        this.post('#/organize', (context) => { createPost.call(context); });

        this.get('#/details/:id', details);

        this.get('#/edit/:id', editGet);
        this.post('#/edit/:id', (context) => { editPost.call(context); });

        this.get('#/delete/:id', deleteGet);

        this.get('#/join/:id', join);
    });

    app.run('#/');
});