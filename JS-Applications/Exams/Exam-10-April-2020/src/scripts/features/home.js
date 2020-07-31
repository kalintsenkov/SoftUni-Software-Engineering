import { getPosts } from "../data.js";

export default async function () {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        postArticle: await this.load('./templates/posts/postArticle.hbs')
    };

    const posts = await getPosts();

    const data = Object.assign({ posts }, this.app.userData);

    this.partial('./templates/home/home.hbs', data);
}