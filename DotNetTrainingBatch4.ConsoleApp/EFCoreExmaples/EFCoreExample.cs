using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HHTDotNetCore.ConsoleApp.Dtos;

namespace HHTDotNetCore.ConsoleApp.EFCoreExmaples
{
    internal class EFCoreExample
    {
        private readonly AppDbContext db = new AppDbContext();
        public void Run()
        {
            Read();
            Edit(1);
            //Create("title", "author", "content");
            //Update(2002, "title2", "author2", "content2");
            Delete(2002);

        }
        private void Read()
        {
            AppDbContext db = new AppDbContext();
            var lst = db.Blogs.ToList();
            foreach (BlogDto item in lst)
            {
                Console.WriteLine(item.BlodId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
                Console.WriteLine("----------");
            }

        }

        private void Edit(int id)
        {
            var item = db.Blogs.FirstOrDefault(x => x.BlodId == id);
            if (item is null)
            {
                Console.WriteLine("No Data found.");
                return;
            }
            Console.WriteLine(item.BlodId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
        }

        private void Create(string title, string author, string content)
        {
            var item = new BlogDto
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content,
            };
            db.Blogs.Add(item);
            int result = db.SaveChanges();
            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
            Console.WriteLine(message);
        }
        private void Update(int id, string title, string author, string content)
        {
            var item = db.Blogs.FirstOrDefault(x => x.BlodId == id);
            if (item is null)
            {
                Console.WriteLine("No data found");
                return;
            }
            item.BlogTitle = title;
            item.BlogAuthor = author;
            item.BlogContent = content;
            int result = db.SaveChanges();
            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
            Console.WriteLine(message);

        }

        private void Delete(int id)
        {
            var item = db.Blogs.FirstOrDefault(x => x.BlodId == id);
            if (item is null)
            {
                Console.WriteLine("No data found");
                return;
            }
            db.Blogs.Remove(item);
            int result = db.SaveChanges();
            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
            Console.WriteLine(message);

        }
    }
}
