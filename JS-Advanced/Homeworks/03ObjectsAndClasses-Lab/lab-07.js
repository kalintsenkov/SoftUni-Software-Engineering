'use strict'

function getPersons() {
    class Person {
        constructor(firstName, lastName, age, email) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.email = email
        }
    
        toString() {
            return `${this.firstName} ${this.lastName} (age: ${this.age}, email: ${this.email})`;
        }
    }

    const persons = [];

    const firstPerson = new Person('Anna', 'Simpson', 22, 'anna@yahoo.com');
    const secondPerson = new Person('SoftUni');
    const thirdPerson = new Person('Stephan', 'Johnson', 25);
    const fourthPerson = new Person('Gabriel', 'Peterson', 24, 'g.p@gmail.com');

    persons.push(firstPerson);
    persons.push(secondPerson);
    persons.push(thirdPerson);
    persons.push(fourthPerson);

    return persons;
}