import API from './api.js';

const endpoints = {
    movies: 'data/movies'
};

const api = new API('CE04F09B-6AA4-BFF1-FFB2-1B9B15F53A00', 'B8A66F0C-CBA2-4C92-A025-B89A6B8B1055');

export const register = api.register.bind(api);
export const login = api.login.bind(api);
export const logout = api.logout.bind(api);

export async function createMovie(movie) {
    return await api.post(endpoints.movies, movie);
}

export async function editMovie(id, movie) {
    return await api.put(endpoints.movies + '/' + id, movie);
}

export async function deleteMovie(id) {
    return await api.delete(endpoints.movies + '/' + id);
}

export async function getMovieById(id) {
    return await api.get(endpoints.movies + '/' + id);
}

export async function getAllMovies(search) {
    if (!search) {
        return await api.get(endpoints.movies);
    } else {
        return await api.get(endpoints.movies + `?where=${escape(`title LIKE '%${search}%'`)}`);
    }
}
