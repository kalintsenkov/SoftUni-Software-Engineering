'use strict'

function solve(arr) {
    const result = [];

    for (const iterator of arr) {
        let [name, level, items] = iterator.split(' / ');
        level = Number(level);
        items = items ? items.split(', ') : [];

        result.push({ name, level, items });
    }

    return JSON.stringify(result);
}