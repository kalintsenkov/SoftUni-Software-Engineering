'use strict'

function pressHouse() {
    class Article {
        constructor(title, content) {
            this.title = title,
                this.content = content;
        }

        toString() {
            let result = `Title: ${this.title}\n`;
            result += `Content: ${this.content}`;
            return result;
        }
    }

    return {
        Article
    };
}
