'use strict'

function solveClasses() {
    class Article {
        constructor(title, content) {
            this.title = title;
            this.content = content;
        }

        toString() {
            let result = `Title: ${this.title}\n`;
            result += `Content: ${this.content}`;
            return result;
        }
    }

    class ShortReports extends Article {
        constructor(title, content, originalResearch) {

            if (content.length > 150) {
                throw new Error('Short reports content should be less then 150 symbols.');
            }

            if (!originalResearch.title || !originalResearch.author) {
                throw new Error('The original research should have author and title.');
            }

            super(title, content);
            this.originalResearches = originalResearch;
            this.comments = [];
        }

        addComment(comment) {
            this.comments.push(comment);
            return 'The comment is added.';
        }

        toString() {
            let result = `${super.toString()}\n`;
            result += `Original Research: ${this.originalResearches.title} by ${this.originalResearches.author}\n`;

            if (this.comments.length > 0) {
                result += `Comments:\n`;
                this.comments.map(comment => result += `${comment}\n`);
            }

            return result.trim();
        }
    }

    class BookReview extends Article {
        constructor(title, content, book) {
            super(title, content);
            this.book = book;
            this.clients = [];
        }

        addClient(clientName, orderDescription) {
            const isExisting = this.clients.some(c => c.clientName === clientName);
            if (isExisting) {
                throw new Error('This client has already ordered this review.');
            }

            this.clients.push({ clientName, orderDescription });
            return `${clientName} has ordered a review for ${this.book.name}`;
        }

        toString() {
            let result = `${super.toString()}\n`;
            result += `Book: ${this.book.name}\n`;

            if (this.clients.length > 0) {
                result += `Orders:`;
                this.clients.map(client => result += `${client.name} - ${client.orderDescription}\n`);
            }

            return result.trim();
        }
    }

    return {
        Article,
        ShortReports,
        BookReview
    };
}
