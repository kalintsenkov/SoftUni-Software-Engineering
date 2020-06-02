'use strict'

class List {
    #elements;

    constructor() {
        this.#elements = [];
        this.size = 0;
    }

    add(element) {
        this.#elements.push(element);
        this.#elements.sort((a, b) => a - b);
        this.size++;
    }

    remove(index) {
        if (index < 0 || index > this.#elements.length) {
            throw 'Index out of range!';
        }

        if (this.#elements.length === 0){
            throw 'Empty';
        }

        this.#elements.splice(index, 1);
        this.#elements.sort((a, b) => a - b);
        this.size--;
    }

    get(index) {
        if (index < 0 || index > this.#elements.length) {
            throw 'Index out of range!';
        }

        if (this.#elements.length === 0){
            throw 'Empty';
        }

        return this.#elements[index];
    }
}