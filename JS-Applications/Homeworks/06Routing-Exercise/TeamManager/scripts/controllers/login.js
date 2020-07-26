import { login, logout as logoutGet } from '../data.js';

export default async function () {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        loginForm: await this.load('./templates/login/loginForm.hbs')
    };

    this.partial('./templates/login/loginPage.hbs');
}

export async function loginPost() {
    try {
        const result = await login(this.params.username, this.params.password);
        if (result.hasOwnProperty('errorData')) {
            const error = new Error();
            Object.assign(error, result);
            return error;
        }

        this.app.userData.loggedIn = true;
        this.app.userData.username = result.username;
        this.app.userData.userId = result.objectId;

        localStorage.setItem('userToken', result['user-token']);
        localStorage.setItem('username', result.username);
        localStorage.setItem('userId', result.userId);

        this.redirect('#/home');
    } catch (error) {
        console.error(error);
        alert(error.message);
    }
}

export async function logout() {
    await logoutGet();

    this.app.userData.loggedIn = false;
    this.app.userData.username = undefined;
    this.app.userData.userId = undefined;
    this.app.userData.teamId = undefined;

    localStorage.removeItem('userToken');
    localStorage.removeItem('username');
    localStorage.removeItem('userId');

    this.redirect('#/');
}