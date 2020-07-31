import { createPost, getPostById } from '../data.js';

export async function create() {
    const post = {
        title: this.params.title,
        category: this.params.category,
        content: this.params.content
    };

    if (Object.values(post).some(value => value.length === 0)) {
        alert('All fields are required!');
        return;
    }

    try {
        const result = await createPost(post);

        if (result.hasOwnProperty('errorData')) {
            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

        this.redirect(`#/home`);
    } catch (error) {
        console.error(error);
        alert(error.message);
    }
}

export async function details() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs')
    };

    const data = await getPostById(this.params.id);

    Object.assign(data, this.app.userData);

    this.partial('./templates/posts/details.hbs', data);
}