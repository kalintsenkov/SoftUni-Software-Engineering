'use strict'

class Hex {
    constructor(value) {
        this.value = value;
    }

    valueOf() {
        return this.value;
    }

    plus(hex) {
        return new Hex(this.value + hex);
    }

    minus(hex) {
        return new Hex(this.value - hex);
    }

    parse(hexValue) {
        return parseInt(hexValue, 16);
    }

    toString() {
        return '0x' + this.value.toString(16).toUpperCase();
    }
}