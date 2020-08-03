import { beginRequest, endRequest } from './notification.js';
import API from './api.js';

const endpoints = {
    events: 'data/events'
};

const api = new API(
    '3501460D-8EB5-377A-FF13-7A4254AFF000',
    'EC8EA7A3-29D3-4586-95F5-99DD92CC11D8',
    beginRequest,
    endRequest);

export const register = api.register.bind(api);
export const login = api.login.bind(api);
export const logout = api.logout.bind(api);

export async function createEvent(event) {
    return await api.post(endpoints.events, event);
}

export async function editEvent(id, event) {
    return await api.put(endpoints.events + '/' + id, event);
}

export async function deleteEvent(id) {
    return await api.delete(endpoints.events + '/' + id);
}

export async function joinEvent(id, interested) {
    return await api.put(endpoints.events + '/' + id, { interested });
}

export async function getEventById(id) {
    return await api.get(endpoints.events + '/' + id);
}

export async function getEvents() {
    return await api.get(endpoints.events);
}

export async function getEventsByOwner() {
    const ownerId = localStorage.getItem('userId');

    return await api.get(endpoints.events + `?where=ownerId%3D%27${ownerId}%27`);
}
