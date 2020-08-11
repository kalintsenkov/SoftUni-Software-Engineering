import { showSuccess, showError } from '../notifications.js';
import { register, login, logout } from '../data.js';

export async function getRegister() {
    this.partials = {
        header: await this.load('./views/common/header.hbs'),
        footer: await this.load('./views/common/footer.hbs')
    };

    this.partial('./views/users/register.hbs', this.app.userData);
}

export async function postRegister() {
    if (!this.params.email) {
        showError('Email input must be filled');
        return;
    }

    if (this.params.password.length < 6) {
        showError('Password should be at least 6 characters long');
        return;
    }

    if (this.params.password !== this.params.repeatPassword) {
        showError('Passwords don\'t match');
        return;
    }

    try {
        const result = await register(this.params.email, this.params.password);

        if (result.hasOwnProperty('errorData')) {
            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

        this.app.userData.loggedIn = true;
        this.app.userData.userId = result.objectId;
        this.app.userData.email = result.email;

        showSuccess('Successful registration!');

        this.redirect('#/home');
    } catch (error) {
        console.error(error);
        showError(error.message);
    }
}

export async function getLogin() {
    this.partials = {
        header: await this.load('./views/common/header.hbs'),
        footer: await this.load('./views/common/footer.hbs')
    };

    this.partial('./views/users/login.hbs', this.app.userData);
}

export async function postLogin() {
    try {
        const result = await login(this.params.email, this.params.password);

        if (result.hasOwnProperty('errorData')) {
            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

        this.app.userData.loggedIn = true;
        this.app.userData.userId = result.objectId;
        this.app.userData.email = result.email;

        showSuccess('Login successful.');

        this.redirect('#/home');
    } catch (error) {
        console.error(error);
        showError(error.message);
    }
}

export async function getLogout() {
    await logout();

    this.app.userData.loggedIn = false;
    this.app.userData.userId = undefined;
    this.app.userData.email = undefined;

    showSuccess('Successful logout');

    this.redirect('#/login');
}
