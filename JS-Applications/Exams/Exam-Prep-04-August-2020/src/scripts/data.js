import { beginRequest, endRequest } from './notifications.js';
import API from './api.js';

const endpoints = {
    recipes: 'data/recipes'
};

const api = new API(
    '34330E0B-4D5C-8487-FF53-CF6BCDE40300',
    'CA69EF3C-575A-4131-A514-772E43AB671F',
    beginRequest,
    endRequest);

export const register = api.register.bind(api);
export const login = api.login.bind(api);
export const logout = api.logout.bind(api);

export async function share(receipt) {
    return await api.post(endpoints.recipes, receipt);
}

export async function edit(id, receipt) {
    return await api.put(endpoints.recipes + '/' + id, receipt);
}

export async function archive(id) {
    return await api.delete(endpoints.recipes + '/' + id);
}

export async function like(id, likes) {
    return await api.put(endpoints.recipes + '/' + id, { likes });
}

export async function getById(id) {
    return await api.get(endpoints.recipes + '/' + id);
}

export async function getAll() {
    return await api.get(endpoints.recipes);
}

export async function getAllByOwner() {
    const ownerId = localStorage.getItem('userId');

    return await api.get(endpoints.recipes + `?where=ownerId%3D%27${ownerId}%27`);
}
