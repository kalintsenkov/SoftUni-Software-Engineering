import { beginRequest, endRequest } from './notification.js';

function host(endpoint) {
    return `https://api.backendless.com/3501460D-8EB5-377A-FF13-7A4254AFF000/EC8EA7A3-29D3-4586-95F5-99DD92CC11D8/${endpoint}`;
}

const endpoints = {
    register: 'users/register',
    login: 'users/login',
    logout: 'users/logout',
    events: 'data/events'
};

export async function register(username, password) {
    beginRequest();

    const result = await (await fetch(host(endpoints.register), {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            username,
            password
        })
    })).json();

    endRequest();

    return result;
}

export async function login(username, password) {
    beginRequest();

    const result = await (await fetch(host(endpoints.login), {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            login: username,
            password
        })
    })).json();

    endRequest();

    return result;
}

export async function logout() {
    beginRequest();

    const token = localStorage.getItem('userToken');

    const result = await fetch(host(endpoints.logout), {
        headers: {
            'user-token': token
        }
    });

    endRequest();

    return result;
}

export async function createEvent(event) {
    beginRequest();

    const token = localStorage.getItem('userToken');

    const result = await (await fetch(host(endpoints.events), {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'user-token': token
        },
        body: JSON.stringify(event)
    })).json();

    endRequest();

    return result;
}

export async function editEvent(id, event) {
    beginRequest();

    const token = localStorage.getItem('userToken');

    const result = await (await fetch(host(endpoints.events + '/' + id), {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
            'user-token': token
        },
        body: JSON.stringify(event)
    })).json();

    endRequest();

    return result;
}

export async function deleteEvent(id) {
    beginRequest();

    const token = localStorage.getItem('userToken');

    const result = await (await fetch(host(endpoints.events + '/' + id), {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
            'user-token': token
        }
    })).json();

    endRequest();

    return result;
}

export async function joinEvent(id, interested) {
    beginRequest();

    const token = localStorage.getItem('userToken');

    const result = await (await fetch(host(endpoints.events + '/' + id), {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
            'user-token': token
        },
        body: JSON.stringify({ interested })
    })).json();

    endRequest();

    return result;
}

export async function getEventById(id) {
    beginRequest();

    const result = await (await fetch(host(endpoints.events + '/' + id))).json();

    endRequest();

    return result;
}

export async function getEvents() {
    beginRequest();

    const result = await (await fetch(host(endpoints.events))).json();

    endRequest();

    return result;
}

export async function getEventsByOwner() {
    beginRequest();

    const token = localStorage.getItem('userToken');
    const ownerId = localStorage.getItem('userId');

    const result = await (await fetch(host(endpoints.events + `?where=ownerId%3D%27${ownerId}%27`), {
        headers: {
            'Content-Type': 'application/json',
            'user-token': token
        }
    })).json();

    endRequest();

    return result;
}
