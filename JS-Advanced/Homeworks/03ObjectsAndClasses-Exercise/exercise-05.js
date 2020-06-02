'use strict'

function solve(arr) {
    const output = {};

    for (const row of arr) {
        let [brand, model, total] = row.split(' | ');
        total = Number(total);

        if (brand in output) {

            if (output[brand].hasOwnProperty(model)) {
                output[brand][model] += total;
            } else {
                output[brand][model] = total;
            }
        } else {
            output[brand] = [];
            output[brand][model] = total;
        }
    }

    for (const brand in output) {
        console.log(brand);

        for (const model in output[brand]) {
            const produced = output[brand][model];
            console.log(`###${model} -> ${produced}`);
        }
    }
}