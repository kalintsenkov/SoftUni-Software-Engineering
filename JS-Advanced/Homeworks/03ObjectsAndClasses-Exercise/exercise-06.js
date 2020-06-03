'use strict'

function solve(arr) {
    const systems = {};

    for (const row of arr) {
        const [name, component, subcomponent] = row.split(' | ');

        if (name in systems) {

            if (component in systems[name]) {
                systems[name][component].push(subcomponent);
            } else {
                systems[name][component] = [];
                systems[name][component].push(subcomponent);
            }
        } else {
            systems[name] = {};
            systems[name][component] = [];
            systems[name][component].push(subcomponent);
        }
    }

    const sortedSystems = Object.entries(systems)
        .sort((a, b) => Object.keys(b[1]).length - Object.keys(a[1]).length || a[0].localeCompare(b[0]))
        .forEach(([system, component]) => {
            console.log(system);
            Object.entries(component)
                .sort((a, b) => b[1].length - a[1].length)
                .forEach(([name, sub]) => {
                    console.log(`|||${name}`);
                    sub.forEach(s => console.log(`||||||${s}`));
                });
        });
}