'use strict'

function solve(input) {
    const object = {};
    const parsed = JSON.parse(input);

    parsed.forEach(prop => {
        const entries = Object.entries(prop);
        entries.forEach(entry => {
            const [key, value] = entry;
            object[key] = value;
        });
    });

    return object;
}