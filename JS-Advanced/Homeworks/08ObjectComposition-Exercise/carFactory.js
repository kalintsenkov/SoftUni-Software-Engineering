'use strict'

function solve(input) {
    const enginesMap = {
        90: { power: 90, volume: 1800 },
        120: { power: 120, volume: 2400 },
        200: { power: 200, volume: 3500 }
    }

    const carriagesMap = {
        'hatchback': (color) => ({ type: 'hatchback', color: color }),
        'coupe': (color) => ({ type: 'coupe', color: color })
    }

    const car = {};
    const wheelSize = input.wheelsize % 2 === 0
        ? 2 * Math.floor(input.wheelsize / 2) - 1
        : input.wheelsize;

    car.model = input.model;

    if (input.power <= 90) {
        car.engine = enginesMap[90];
    } else if (input.power > 90 && input.power <= 120) {
        car.engine = enginesMap[120];
    } else if (input.power > 120) {
        car.engine = enginesMap[200];
    }

    car.carriage = carriagesMap[input.carriage](input.color);
    car.wheels = [wheelSize, wheelSize, wheelSize, wheelSize];

    return car;
}