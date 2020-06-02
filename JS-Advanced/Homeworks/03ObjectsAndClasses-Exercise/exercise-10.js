'use strict'

class Stringer {
    constructor(input, length) {
        this.innerString = input;
        this.length = 0;
        this.increase(length);
    }

    get innerLength() {
        return this.length;
    }

    set innerLength(value) {
        this.length = value < 0 ? 0 : value;
    }

    increase(length) {
        this.innerLength += length;
    }

    decrease(length) {
        this.innerLength -= length;
    }

    toString() {
        return this.length < this.innerString.length ?
            this.innerString.substring(0, this.length) + '...'
            : this.innerString;
    }
}

let test = new Stringer("Test", 5);
console.log(test.toString()); // Test

test.decrease(3);
console.log(test.toString()); // Te...

test.decrease(5);
console.log(test.toString()); // ...

test.increase(4);
console.log(test.toString()); // Test