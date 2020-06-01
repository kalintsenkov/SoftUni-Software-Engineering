'use strict'

function populationInTowns(arr) {
    const towns = {};

    for (let i = 0; i < arr.length; i++) {
        const row = arr[i].split(' <-> ')
        const town = row[0];
        const income = Number(row[1]);

        if (towns.hasOwnProperty(town)) {
            towns[town] += income;
        } else {
            towns[town] = income;
        }
    }

    let result = '';
    for (const town in towns) {
        if (towns.hasOwnProperty(town)) {
            const element = towns[town];
            result += `${town} : ${element}\n`;
        }
    }

    return result;
}