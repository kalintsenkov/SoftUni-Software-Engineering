'use strict'

function solve(arr) {
    const output = {};
    const store = {};

    for (const row of arr) {
        let [juice, quantity] = row.split(' => ');
        quantity = Number(quantity);

        if (juice in store) {
            store[juice] += quantity;
        } else {
            store[juice] = quantity;
        }

        if (store[juice] >= 1000) {
            if (juice in output) {
                output[juice] += quantity;
            } else {
                output[juice] = store[juice];
            }
        }
    }

    for (let juice in output) {
        console.log(`${juice} => ${Math.floor(output[juice] / 1000)}`);
    }
}