'use strict'

class Article {
    constructor(title, creator) {
        this.title = title;
        this.creator = creator;

        this._likes = [];
        this._comments = [];
        this._commentsIdentifier = 1;
    }

    get likes() {
        if (this._likes.length === 0) {
            return `${this.title} has 0 likes`;
        }

        if (this._likes.length === 1) {
            return `${this._likes[0]} likes this article!`;
        }

        return `${this._likes[0]} and ${this._likes.length - 1} others like this article!`
    }

    like(username) {
        const isExisting = this._likes.some(u => u === username);
        if (isExisting) {
            throw new Error(`You can't like the same article twice!`);
        }

        if (username === this.creator) {
            throw new Error(`You can't like your own articles!`);
        }

        this._likes.push(username);
        return `${username} liked ${this.title}!`;
    }

    dislike(username) {
        const index = this._likes.indexOf(username);
        if (index === -1) {
            throw new Error(`You can't dislike this article!`);
        }

        this._likes.splice(index, 1);
        return `${username} disliked ${this.title}`;
    }

    comment(username, content, id) {
        const isExisting = this._comments.some(c => c.id === id);
        if (id === undefined || !isExisting) {
            this._comments.push({
                id: this._commentsIdentifier,
                username: username,
                content: content,
                replies: []
            });

            this._commentsIdentifier++;

            return `${username} commented on ${this.title}`;
        }

        const replyId = this._comments[id - 1].replies.length + 1;

        this._comments[id - 1].replies.push({
            id: `${id}.${replyId}`,
            username: username,
            content: content,
        });

        return 'You replied successfully';
    }

    toString(sortingType) {
        const sortingMap = {
            'asc': () => this._comments
                .sort((a, b) => a.id - b.id)
                .map(c => c.replies.sort((a, b) => a.id.localeCompare(b.id))),
            'desc': () => this._comments
                .sort((a, b) => b.id - a.id)
                .map(c => c.replies.sort((a, b) => b.id.localeCompare(a.id))),
            'username': () => this._comments
                .sort((a, b) => a.username.localeCompare(b.username))
                .map(c => c.replies.sort((a, b) => a.username.localeCompare(b.username)))
        };

        let result = `Title: ${this.title}\n`;
        result += `Creator: ${this.creator}\n`;
        result += `Likes: ${this._likes.length}\n`;
        result += `Comments:\n`;

        sortingMap[sortingType]();

        for (const comment of this._comments) {
            result += `-- ${comment.id}. ${comment.username}: ${comment.content}\n`;
            for (const reply of comment.replies) {
                result += `--- ${reply.id}. ${reply.username}: ${reply.content}\n`;
            }
        }

        return result.trim();
    }
}
