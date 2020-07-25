const url = 'https://api.backendless.com/EFAF9BAB-A12B-D58D-FF1C-6A0299F76100/9FFC8DD4-80F6-4839-A636-98AB3DC3D8F7/data/furnitures';

export async function allFurniture() {
    const response = await fetch(url);
    const json = await response.json();

    return json;
}

export async function getFurniture(id) {
    const response = await fetch(url + `/${id}`);
    const json = await response.json();

    return json;
}

export async function createFurniture(furniture) {
    const requestObj = {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(furniture)
    };

    const response = await fetch(url, requestObj);
    const json = await response.json();

    return json.objectId;
}

export async function deleteFurniture(id) {
    const requestObj = {
        method: 'DELETE'
    };

    await fetch(url + `/${id}`, requestObj);
}