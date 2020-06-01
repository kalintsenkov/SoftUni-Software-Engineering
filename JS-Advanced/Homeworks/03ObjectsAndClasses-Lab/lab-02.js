'use strict'

function sumByTown(arr) {
    const towns = {};

    for (let i = 0; i < arr.length - 1; i += 2) {
        const town = arr[i];
        const income = Number(arr[i + 1]);

        if (towns.hasOwnProperty(town)) {
            towns[town] += income;
        } else {
            towns[town] = income;
        }
    }

    return JSON.stringify(towns);
}