'use strict'

function townsToJSON(arr) {
    const headings = escapePipes(arr[0]);
    const town = headings[0];
    const latitude = headings[1];
    const longitude = headings[2];

    const result = [];

    for (let i = 1; i < arr.length; i++) {
        const row = escapePipes(arr[i]);
        const object = {};
        object[town] = row[0];
        object[latitude] = +(Number((row[1] * 100) / 100).toFixed(2));
        object[longitude] = +(Number((row[2] * 100) / 100).toFixed(2));

        result.push(object);
    }

    return JSON.stringify(result);

    function escapePipes(arr) {
        return arr
            .split(/[ ]*[|][ ]*/)
            .filter(i => i !== '');
    }
}