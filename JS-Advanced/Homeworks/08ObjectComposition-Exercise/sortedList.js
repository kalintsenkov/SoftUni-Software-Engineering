'use strict'

function solve() {
    const list = [];
    let size = 0;

    function add(element) {
        this.size++;
        list.push(element);
        return sortList();
    }

    function remove(index) {
        throwIfOutsideList(index);
        this.size--;
        list.splice(index, 1);
        return sortList();
    }

    function get(index) {
        throwIfOutsideList(index);
        return list[index];
    }

    function sortList() {
        return list.sort((a, b) => a - b);
    }

    function throwIfOutsideList(index) {
        if (index < 0 || index >= list.length) {
            throw new Error('Index out of range!');
        }
    }

    return { add, remove, get, size };
}

const myList = solve();
myList.add(5);
myList.add(3);
myList.remove(0);
console.log(myList.size);