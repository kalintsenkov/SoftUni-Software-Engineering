'use strict'

function area() {
    return this.x * this.y;
}

function vol() {
    return this.x * this.y * this.z;
}

function solve(area, vol, input) {
    const result = [];
    const obj = JSON.parse(input);
    obj.map(o => {
        const a = Math.abs(area.call(o));
        const v = Math.abs(vol.call(o));
        result.push({ area: a, volume: v });
    })

    return result;
}