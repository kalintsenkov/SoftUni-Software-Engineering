'use strict'

class Person {
    constructor(firstName, lastName) {
        this.firstName = firstName;
        this.lastName = lastName;
    }

    get fullName() { 
        return this.firstName + ' ' + this.lastName; 
    }

    set fullName(newName) {
        if (newName.split(' ').length > 1) {
            const [ fn, ln ] = newName.split(' ');
            this.firstName = fn;
            this.lastName = ln;
        }
    }
}

const person = new Person("Albert", "Simpson");
console.log(person.fullName);//Albert Simpson
person.firstName = "Simon";
console.log(person.fullName);//Simon Simpson
person.fullName = "Peter";
console.log(person.firstName) // Simon
console.log(person.lastName) // Simpson