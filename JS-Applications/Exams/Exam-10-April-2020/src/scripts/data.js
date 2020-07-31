function host(endpoint) {
    return `https://api.backendless.com/49E3EDFB-2271-B09B-FF99-FD6845C04600/A099600D-964B-4647-B729-1CD5625B498A/${endpoint}`;
}

const endpoints = {
    register: 'users/register',
    login: 'users/login',
    logout: 'users/logout',
    posts: 'data/posts'
};

export async function register(email, password) {
    const response = await fetch('https://api.backendless.com/49E3EDFB-2271-B09B-FF99-FD6845C04600/A099600D-964B-4647-B729-1CD5625B498A/users/register', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            email,
            password
        })
    });

    return await response.json();
}

export async function login(email, password) {
    const response = await fetch(host(endpoints.login), {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            login: email,
            password
        })
    });

    return await response.json();
}

export async function logout() {
    const token = localStorage.getItem('userToken');

    if (!token) {
        throw new Error('User is not logged in!');
    }

    return await fetch(host(endpoints.logout), {
        method: 'GET',
        headers: {
            'user-token': token
        }
    });
}