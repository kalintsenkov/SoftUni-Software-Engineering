import { register, login, logout } from '../data.js'

export async function registerGet() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs')
    };

    this.partial('./templates/users/register.hbs', this.app.userData);
}

export async function registerPost() {
    if (this.params.password !== this.params.repeatPassword) {
        alert('Passwords don\'t match');
        return;
    }

    try {
        const result = await register(this.params.email, this.params.password);
        if (result.hasOwnProperty('errorData')) {
            const error = new Error();
            Object.assign(error, result);
            return error;
        }

        this.redirect('#/login');
    } catch (error) {
        console.error(error);
        alert(error.message);
    }
}

export async function loginGet() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs')
    };

    this.partial('./templates/users/login.hbs');
}

export async function loginPost() {
    try {
        const result = await login(this.params.email, this.params.password);

        if (result.hasOwnProperty('errorData')) {
            const error = new Error();
            Object.assign(error, result);
            return error;
        }

        this.app.userData.loggedIn = true;
        this.app.userData.email = result.email;
        this.app.userData.userId = result.objectId;

        localStorage.setItem('userToken', result['user-token']);
        localStorage.setItem('email', result.email);
        localStorage.setItem('userId', result.objectId);

        this.redirect('#/home');
    } catch (error) {
        console.error(error);
        alert(error.message);
    }
}

export async function logoutGet() {
    await logout();

    this.app.userData.loggedIn = false;
    this.app.userData.email = undefined;
    this.app.userData.userId = undefined;

    localStorage.removeItem('userToken');
    localStorage.removeItem('email');
    localStorage.removeItem('userId');

    this.redirect('#/');
}