import { showSuccess, showError } from '../notification.js';
import { register, login, logout, getEventsByOwner } from '../data.js';

export async function registerGet() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs')
    };

    this.partial('./templates/users/register.hbs', this.app.userData);
}

export async function registerPost() {
    if (this.params.username.length < 3) {
        alert('Username should be at least 3 characters long');
        return;
    }

    if (this.params.password.length < 6) {
        alert('Password should be at least 6 characters long');
        return;
    }

    if (this.params.password !== this.params.rePassword) {
        alert('Passwords don\'t match');
        return;
    }

    try {
        const result = await register(this.params.username, this.params.password);
        if (result.hasOwnProperty('errorData')) {
            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

        showSuccess('User registration successful.');
        this.redirect('#/login');
    } catch (error) {
        console.error(error);
        showError(error.message);
    }
}

export async function loginGet() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs')
    };

    this.partial('./templates/users/login.hbs');
}

export async function loginPost() {
    try {
        const result = await login(this.params.username, this.params.password);

        if (result.hasOwnProperty('errorData')) {
            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

        this.app.userData.loggedIn = true;
        this.app.userData.username = result.username;
        this.app.userData.userId = result.objectId;

        showSuccess('Login successful.');
        
        this.redirect('#/home');
    } catch (error) {
        console.error(error);
        showError(error.message);
    }
}

export async function logoutGet() {
    await logout();

    this.app.userData.loggedIn = false;
    this.app.userData.username = undefined;
    this.app.userData.userId = undefined;

    showSuccess('Logout successful.');
    this.redirect('#/home');
}

export async function profile() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs')
    };

    const events = await getEventsByOwner();
    const hasEvents = events.length == 0 ? false : true;

    const data = Object.assign({
        events,
        hasEvents,
        numberOfEvents: events.length
    }, this.app.userData);

    this.partial('./templates/users/profile.hbs', data);
}
