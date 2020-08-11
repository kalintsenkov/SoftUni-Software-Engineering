export default class API {
    constructor(appId, apiKey, beginRequest, endRequest) {
        this.appId = appId;
        this.apiKey = apiKey;
        this.endpoints = {
            register: 'users/register',
            login: 'users/login',
            logout: 'users/logout'
        };
    }

    host(endpoint) {
        return `https://api.backendless.com/${this.appId}/${this.apiKey}/${endpoint}`;
    }

    getOptions(headers) {
        const token = localStorage.getItem('userToken');

        const options = { headers: headers || {} };

        if (token !== null) {
            Object.assign(options.headers, { 'user-token': token });
        }

        return options;
    }

    async get(endpoint) {
        const response = await fetch(this.host(endpoint), this.getOptions());
        return endpoint == this.endpoints.logout ? response : await response.json();
    }

    async post(endpoint, body) {
        const options = this.getOptions({ 'Content-Type': 'application/json' });

        options.method = 'POST';
        options.body = JSON.stringify(body);

        return await (await fetch(this.host(endpoint), options)).json();
    }

    async put(endpoint, body) {
        const options = this.getOptions({ 'Content-Type': 'application/json' });

        options.method = 'PUT';
        options.body = JSON.stringify(body);

        return await (await fetch(this.host(endpoint), options)).json();
    }

    async delete(endpoint) {
        const options = this.getOptions();

        options.method = 'DELETE';

        return await (await fetch(this.host(endpoint), options)).json();
    }

    async register(email, password) {
        let result = await this.post(this.endpoints.register, {
            email,
            password
        });

        result = await this.login(email, password);

        return result;
    }

    async login(email, password) {
        const result = await this.post(this.endpoints.login, {
            login: email,
            password
        });

        localStorage.setItem('userToken', result['user-token']);
        localStorage.setItem('userId', result.objectId);
        localStorage.setItem('email', result.email);

        return result;
    }

    async logout() {
        await this.get(this.endpoints.logout);

        localStorage.clear();
    }
}
