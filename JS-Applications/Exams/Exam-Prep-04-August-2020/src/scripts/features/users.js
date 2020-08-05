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
    if (this.params.firstName.length < 2 || this.params.lastName.length < 2) {
        showError('First and last name should be at least 2 characters long');
        return;
    }

    if (this.params.username.length < 3) {
        showError('Username should be at least 3 characters long');
        return;
    }

    if (this.params.username.length < 3) {
        showError('Username should be at least 3 characters long');
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
        const result = await register(this.params.firstName, this.params.lastName, this.params.username, this.params.password);

        if (result.hasOwnProperty('errorData')) {
            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

        this.app.userData.loggedIn = true;
        this.app.userData.userId = result.objectId;
        this.app.userData.fullName = result.firstName + ' ' + result.lastName;

        showSuccess('User registration successful.');

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
        const result = await login(this.params.username, this.params.password);

        if (result.hasOwnProperty('errorData')) {
            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

        this.app.userData.loggedIn = true;
        this.app.userData.userId = result.objectId;
        this.app.userData.fullName = result.firstName + ' ' + result.lastName;

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
    this.app.userData.fullName = undefined;

    showSuccess('Logout successful.');

    this.redirect('#/home');
}
