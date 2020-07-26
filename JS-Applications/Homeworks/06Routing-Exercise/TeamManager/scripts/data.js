function host(endpoint) {
    return `https://api.backendless.com/8935E8E3-31D0-394A-FFF1-5470C4256700/58AA3048-6EA6-4076-9C3B-33B97A8540EC/${endpoint}`;
}

const endpoints = {
    register: 'users/register',
    login: 'users/login',
    logout: 'users/logout',
    teams: 'data/teams',
    updateUser: 'users/'
};

export async function register(username, password) {
    const response = await fetch(host(endpoints.register), {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            username,
            password
        })
    });

    return await response.json();
}

export async function login(username, password) {
    const response = await fetch(host(endpoints.login), {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            login: username,
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

async function setUserTeamId(userId, teamId) {
    const token = localStorage.getItem('userToken');

    if (!token) {
        throw new Error('User is not logged in!');
    }

    const response = await fetch(host(endpoints.updateUser + userId), {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
            'user-token': token
        },
        body: JSON.stringify({ teamId })
    });

    return await response.json();
}

export async function createTeam(team) {
    const token = localStorage.getItem('userToken');

    if (!token) {
        throw new Error('User is not logged in!');
    }

    const response = await fetch(host(endpoints.teams), {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'user-token': token
        },
        body: JSON.stringify(team)
    });

    const result = await response.json();

    if (result.hasOwnProperty('errorData')) {
        const error = new Error();
        Object.assign(error, result);
        return error;
    }

    const userUpdateResult = await setUserTeamId(result.ownerId, result.objectId);

    if (userUpdateResult.hasOwnProperty('errorData')) {
        const error = new Error();
        Object.assign(error, userUpdateResult);
        return error;
    }

    return result;
}

export async function getTeams() {
    const response = await fetch(host(endpoints.teams));

    return await response.json();
}

export async function getTeamById(id) {
    const response = await fetch(host(endpoints.teams + '/' + id));

    return await response.json();
}