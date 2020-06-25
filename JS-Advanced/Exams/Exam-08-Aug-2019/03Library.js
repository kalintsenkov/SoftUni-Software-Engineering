'use strict'

class Library {
    constructor(libraryName) {
        this.libraryName = libraryName;
        this.subscribers = [];
        this.subscriptionTypes = {
            'normal': this.libraryName.length,
            'special': this.libraryName.length * 2,
            'vip': Number.MAX_SAFE_INTEGER
        };
    }

    subscribe(name, type) {
        if (!this.subscriptionTypes[type]) {
            throw new Error(`The type ${type} is invalid`);
        }

        let subscriber = this._getSubscriberByName(name);

        if (subscriber === undefined) {
            subscriber = { name: name, type: type, books: [] };
            this.subscribers.push(subscriber);
        } else {
            subscriber.type = type;
        }

        return subscriber;
    }

    unsubscribe(name) {
        const subscriber = this._getSubscriberByName(name);

        this._throwIfUndefined(subscriber, name);

        const index = this.subscribers.indexOf(subscriber);
        this.subscribers.splice(index, 1)

        return this.subscribers;
    }

    receiveBook(subscriberName, bookTitle, bookAuthor) {
        const subscriber = this._getSubscriberByName(subscriberName);

        this._throwIfUndefined(subscriber, subscriberName);

        const allowedBooks = this.subscriptionTypes[subscriber.type];
        const ownedBooks = subscriber.books.length;

        if (ownedBooks + 1 > allowedBooks) {
            throw new Error(`You have reached your subscription limit ${allowedBooks}!`);
        }

        subscriber.books.push({ title: bookTitle, author: bookAuthor });

        return subscriber;
    }

    showInfo() {
        if (this.subscribers.length === 0) {
            return `${this.libraryName} has no information about any subscribers`;
        }

        let result = '';
        for (const subscriber of this.subscribers) {
            result += `Subscriber: ${subscriber.name}, Type: ${subscriber.type}\n`;
            result += `Received books: ${subscriber.books.map(b => `${b.title} by ${b.author}`).join(', ')}\n`;
        }

        return result.trim();
    }

    _getSubscriberByName(name) {
        return this.subscribers.find(s => s.name === name)
    }

    _throwIfUndefined(subscriber, name) {
        if (subscriber === undefined) {
            throw new Error(`There is no such subscriber as ${name}`);
        }
    }
}

const lib = new Library('Lib');

lib.subscribe('Peter', 'normal');
lib.subscribe('John', 'special');

lib.receiveBook('John', 'A Song of Ice and Fire', 'George R. R. Martin');
lib.receiveBook('Peter', 'Lord of the rings', 'J. R. R. Tolkien');
lib.receiveBook('John', 'Harry Potter', 'J. K. Rowling');

console.log(lib.showInfo());

// Subscriber: Peter, Type: normal
// Received books: Lord of the rings by J. R. R. Tolkien
// Subscriber: John, Type: special
// Received books: A Song of Ice and Fire by George R. R. Martin, Harry Potter by J. K. Rowling