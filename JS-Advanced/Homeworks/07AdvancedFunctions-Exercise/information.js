'use strict'

function solve(...params) {
    const summary = {};

    [...params].forEach(p => {
        const type = typeof p;

        if (!(type in summary)) {
            summary[type] = 0;
        }

        summary[type]++;

        console.log(`${type}: ${p}`);
    });

    const ordered = Object.keys(summary).sort((a, b) => summary[b] - summary[a]);

    for (const line of ordered) {
        console.log(`${line} = ${summary[line]}`);
    }
}

solve('cat', 42, function () { console.log('Hello world!'); });

// string: cat
// number: 42
// function: function () { console.log('Hello world!'); }
// string = 1
// number = 1
// function = 1