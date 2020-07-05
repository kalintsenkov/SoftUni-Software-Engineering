using System;
using System.Collections.Generic;
using System.Linq;

namespace _03Articles2._0
{
    public class Article
    {
        public Article(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var articleList = new List<Article>();

            for (int i = 1; i <= n; i++)
            {
                var tokens = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string title = tokens[0];
                string content = tokens[1];
                string author = tokens[2];

                var article = new Article(title, content, author);

                articleList.Add(article);
            }

            string input = Console.ReadLine();

            if(input == "title")
            {
                foreach (var article in articleList.OrderBy(x => x.Title))
                {
                    Console.WriteLine(article.ToString());
                }
            }
            else if(input == "content")
            {
                foreach (var article in articleList.OrderBy(x => x.Content))
                {
                    Console.WriteLine(article.ToString());
                }
            }
            else if (input == "author")
            {
                foreach (var article in articleList.OrderBy(x => x.Author))
                {
                    Console.WriteLine(article.ToString());
                }
            }
        }
    }
}
