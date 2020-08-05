export default class API {
    constructor(appId, apiKey, beginRequest, endRequest) {
        this.appId = appId;
        this.apiKey = apiKey;
        this.endpoints = {
            register: 'users/register',
            login: 'users/login',
            logout: 'users/logout'
        };

        this.beginRequest = () => {
            if (beginRequest) {
                beginRequest();
            }
        };

        this.endRequest = () => {
            if (endRequest) {
                endRequest();
            }
        };
    }

    host(endpoint) {
        return `https://api.backendless.com/${this.appId}/${this.apiKey}/${endpoint}`;
    }

    getOptions(headers) {
        const token = sessionStorage.getItem('userToken');

        const options = { headers: headers || {} };

        if (token !== null) {
            Object.assign(options.headers, { 'user-token': token });
        }

        return options;
    }

    async get(endpoint) {
        this.beginRequest();
        const response = await fetch(this.host(endpoint), this.getOptions());
        const result = endpoint == this.endpoints.logout ? response : await response.json();
        this.endRequest();

        return result;
    }

    async post(endpoint, body) {
        const options = this.getOptions({ 'Content-Type': 'application/json' });

        options.method = 'POST';
        options.body = JSON.stringify(body);

        this.beginRequest();
        const result = await (await fetch(this.host(endpoint), options)).json();
        this.endRequest();

        return result;
    }

    async put(endpoint, body) {
        const options = this.getOptions({ 'Content-Type': 'application/json' });

        options.method = 'PUT';
        options.body = JSON.stringify(body);

        this.beginRequest();
        const result = await (await fetch(this.host(endpoint), options)).json();
        this.endRequest();

        return result;
    }

    async delete(endpoint) {
        const options = this.getOptions();

        options.method = 'DELETE';

        this.beginRequest();
        const result = await (await fetch(this.host(endpoint), options)).json();
        this.endRequest();

        return result;
    }

    async register(firstName, lastName, username, password) {
        const result = await this.post(this.endpoints.register, {
            firstName,
            lastName,
            username,
            password
        });

        sessionStorage.setItem('fullName', result.firstName + ' ' + result.lastName);
        sessionStorage.setItem('userToken', result['user-token']);
        sessionStorage.setItem('userId', result.objectId);

        return result;
    }

    async login(username, password) {
        const result = await this.post(this.endpoints.login, {
            login: username,
            password
        });

        sessionStorage.setItem('fullName', result.firstName + ' ' + result.lastName);
        sessionStorage.setItem('userToken', result['user-token']);
        sessionStorage.setItem('userId', result.objectId);

        return result;
    }

    async logout() {
        await this.get(this.endpoints.logout);

        sessionStorage.clear();
    }
}
