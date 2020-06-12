function getArticleGenerator(articles) {
    const content = $('#content');

    return function createArticle() {
        if (articles.length > 0) {
            content.prepend($('<article>').text(articles.shift()));
        }
    }
}