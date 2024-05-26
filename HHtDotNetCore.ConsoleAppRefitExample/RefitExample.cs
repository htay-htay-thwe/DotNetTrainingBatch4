using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HHtDotNetCore.ConsoleAppRefitExample
{
    internal class RefitExample
    {
        private readonly IBlogApi _service = RestService.For<IBlogApi>("https://localhost:7146");
        private object ex;

        public async Task RunAsync()
        {
            //await ReadAsync();
            //await ReadAsync();
            //await EditAsync(1);
            //await CreateAsync("title", "author 2", "content 3");
            //await UpdateAsync(6002, "title 1", "author 2", "content 3");
        }
        private async Task ReadAsync()
        {
          
            var lst = await _service.GetBlogs();
            foreach (var item in lst)
            {

                Console.WriteLine($"Id => {item.BlodId}");
                Console.WriteLine($"Title => {item.BlogTitle}");
                Console.WriteLine($"Author => {item.BlogAuthor}");
                Console.WriteLine($"Content => {item.BlogContent}");
                Console.WriteLine("-------------------------");
            }
           
        }
        private async Task EditAsync(int id)
        {
           
            try
            {
                var item = await _service.GetBlog(id);
                Console.WriteLine($"Id => {item.BlodId}");
                Console.WriteLine($"Title => {item.BlogTitle}");
                Console.WriteLine($"Author => {item.BlogAuthor}");
                Console.WriteLine($"Content => {item.BlogContent}");
                Console.WriteLine("-------------------------");
            }
            catch (ApiException ex)
            {
                Console.WriteLine(ex.StatusCode.ToString());
                Console.WriteLine(ex.Content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async Task CreateAsync(string title,string author,string content)
        {
            BlogModel blog = new BlogModel()
            {
                BlogAuthor = author,
                BlogTitle = title,
                BlogContent = content
            };
            var message = await _service.CreateBlog(blog);
            Console.WriteLine(message); 
        }

        private async Task UpdateAsync(int id,string title, string author, string content)
        {
            BlogModel blog = new BlogModel()
            {
                BlogAuthor = author,
                BlogTitle = title,
                BlogContent = content
            };
            var message = await _service.UpdateBlog(id,blog);
            Console.WriteLine(message);
        }

        private async Task DeleteAsync(int id)
        {
          
            var message = await _service.DeleteBlog(id);
            Console.WriteLine(message);
        }
    }
}
