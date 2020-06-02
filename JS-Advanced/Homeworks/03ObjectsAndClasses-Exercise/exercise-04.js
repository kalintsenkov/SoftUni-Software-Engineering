'use strict'

function solve(arr) {
    const output = {};

    for (const row of arr) {
        let [product, price] = row.split(' : ');
        price = Number(price);

        const firstLetter = product[0];

        if (firstLetter in output) {
            output[firstLetter].push({ product, price });
        } else {
            output[firstLetter] = [];
            output[firstLetter].push({ product, price });
        }
    }

    const ordered = {};
    Object.keys(output)
        .sort((a, b) => a.localeCompare(b))
        .forEach(function (key) {
            ordered[key] = output[key];
        });

    for (const key in ordered) {
        console.log(key);

        for (const object in ordered[key].sort((a, b) => (a.product > b.product) ? 1 : -1)) {
            const element = ordered[key][object];
            console.log(`  ${element.product}: ${element.price}`);
        }
    }
}