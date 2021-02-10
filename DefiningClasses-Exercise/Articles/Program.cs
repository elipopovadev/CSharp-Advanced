using System;
using System.Text;

namespace Articles
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] inputArray = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries);
            string title = inputArray[0];
            string content = inputArray[1];
            string author = inputArray[2];
            var newArticle = new Article(title, content, author);
            int numberOfCommands = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] commandArray = Console.ReadLine().Split(": ",StringSplitOptions.RemoveEmptyEntries);
                string command = commandArray[0];
                switch (command)
                {
                    case "Edit":
                        {
                            string betterContent = commandArray[1];
                            newArticle.Edit(betterContent);
                            break;
                        }

                    case "ChangeAuthor":
                        {
                            string betterAuthor = commandArray[1];
                            newArticle.ChangeAuthor(betterAuthor);
                            break;
                        }

                    case "Rename":
                        {
                            string betterTitle = commandArray[1];
                            newArticle.Rename(betterTitle);
                            break;
                        }
                }
            }

            Console.WriteLine(newArticle.ToString());
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
