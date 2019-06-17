using System;
using System.Linq;

namespace _02Articles
{
    public class Article
    {
        public Article(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }

        public void Edit(string newContent)
        {
            this.Content = newContent;
        }

        public void ChangeAuthor(string newAuthor)
        {
            this.Author = newAuthor;
        }

        public void Rename(string newTitle)
        {
            this.Title = newTitle;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var articleList = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string title = articleList[0];
            string content = articleList[1];
            string author = articleList[2];

            var article = new Article(title, content, author);

            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                var tokens = Console.ReadLine()
                    .Split(": ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = tokens[0];

                if (command == "Edit")
                {
                    string newContent = tokens[1];

                    article.Edit(newContent);
                }
                else if (command == "ChangeAuthor")
                {
                    string newAuthor = tokens[1];

                    article.ChangeAuthor(newAuthor);
                }
                else if (command == "Rename")
                {
                    string newTitle = tokens[1];

                    article.Rename(newTitle);
                }
            }

            Console.WriteLine(article.ToString());
        }
    }
}
