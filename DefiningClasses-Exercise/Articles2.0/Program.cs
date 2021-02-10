using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Articles2._0
{
    public class Program
    {
        static void Main(string[] args)
        {
            var listOfArticles = new List<Article>();
            int numberOfArticles = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfArticles; i++)
            {
                string[] inputArray = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string title = inputArray[0];
                string content = inputArray[1];
                string author = inputArray[2];
                var newArticle = new Article(title, content, author);
                listOfArticles.Add(newArticle);
            }

            string commandForOrderBy = Console.ReadLine();
            if (commandForOrderBy == "title")
            {
                foreach (var article in listOfArticles.OrderBy(a=> a.Title))
                {
                    Console.WriteLine(article.ToString());
                }
            }

            else if(commandForOrderBy == "content")
            {
                foreach (var article in listOfArticles.OrderBy(a=> a.Content))
                {
                    Console.WriteLine(article.ToString());
                }
            }

            else if (commandForOrderBy == "author")
            {
                foreach (var article in listOfArticles.OrderBy(a=> a.Author))
                {
                    Console.WriteLine(article.ToString());
                }
            }
        }
    }


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
            var sb = new StringBuilder();
            sb.Append(this.Title);
            sb.Append(" - ");
            sb.Append(this.Content);
            sb.Append(": ");
            sb.Append(this.Author);
            return sb.ToString();
        }
    }
}
