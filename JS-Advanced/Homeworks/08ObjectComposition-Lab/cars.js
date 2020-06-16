'use strict'

function solution(input) {
    const cars = {};

    const operations = {
        create: (name, _, parentName) => {
            if (!parentName) {
                cars[name] = {};
                return;
            }

            const parent = cars[parentName];
            cars[name] = Object.create(parent);
        },
        set: (name, key, value) => {
            cars[name][key] = value;
        },
        print: (name) => {
            let res = '';
            for (const prop in cars[name]) {
                res += `${prop}:${cars[name][prop]}, `
            }

            console.log(res.substring(res.length - 2, 0));
        }
    };

    input.forEach(i => {
        const [command, v1, v2, v3] = i.split(' ');

        return operations[command](v1, v2, v3);
    });
}