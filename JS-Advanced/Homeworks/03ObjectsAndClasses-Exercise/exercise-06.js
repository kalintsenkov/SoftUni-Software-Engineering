'use strict'

function solve(arr) {
    const systems = [];

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
            systems[name] = [];
            systems[name][component] = [];
            systems[name][component].push(subcomponent);
        }
    }

    for (const system in systems) {
        console.log(system);

        for (const component in systems[system].sort((a, b) => systems[a].length < systems[b].length)) {
            console.log(`|||${component}`);

            for (const subcomponent of systems[system][component]) {
                console.log(`||||||${subcomponent}`);
            }
        }
    }
}

solve([
    'SULS | Main Site | Home Page',
    'SULS | Main Site | Login Page',
    'SULS | Main Site | Register Page',
    'SULS | Judge Site | Login Page',
    'SULS | Judge Site | Submittion Page',
    'Lambda | CoreA | A23',
    'SULS | Digital Site | Login Page',
    'Lambda | CoreB | B24',
    'Lambda | CoreA | A24',
    'Lambda | CoreA | A25',
    'Lambda | CoreC | C4',
    'Indice | Session | Default Storage',
    'Indice | Session | Default Security'
]);