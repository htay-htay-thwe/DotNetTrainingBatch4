using HHTDotNetCore.ConsoleAppREstClientExample;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace HHTDotNetCore.ConsoleAppREstClientExample
{
    internal class RestClientExample
    {
        private readonly RestClient _client = new RestClient(new Uri("https://localhost:7102"));
        private readonly string _blogEndPoint = "api/blog";
        private object? blogDto;

        public async Task RunAsync()
        {
            //await ReadAsync();
            //await EditAsync(1);
            //await CreateAsync("title", "author 2", "content 3");
            //await UpdateAsync(6002, "title 1", "author 2", "content 3");
        }
        private async Task ReadAsync()
        {
            RestRequest restRequest = new RestRequest(_blogEndPoint, Method.Get);
            var response = await _client.GetAsync(restRequest);
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = response.Content!;
                List<BlogDto> lst = JsonConvert.DeserializeObject<List<BlogDto>>(jsonStr)!;
                foreach (var item in lst)
                {
                    Console.WriteLine(JsonConvert.SerializeObject(item));
                    Console.WriteLine($"Title => {item.BlogTitle}");
                }



            }
        }

        private async Task EditAsync(int id)
        {
            RestRequest restRequest = new RestRequest($"{_blogEndPoint}/{id}", Method.Get);
            var response = await _client.ExecuteAsync(restRequest);
            if (response.IsSuccessStatusCode)
            {
                string jsonstr = response.Content!;
                var item = JsonConvert.DeserializeObject<BlogDto>(jsonstr);

                Console.WriteLine(JsonConvert.SerializeObject(item));
                Console.WriteLine($"title => {item.BlogTitle}");
                Console.WriteLine($"Author => {item.BlogAuthor}");

            }
            else
            {
                string message = response.Content!;
                Console.WriteLine(message);
            }
        }

        private async Task CreateAsync(string title, string author, string content)
        {
            BlogDto blog = new BlogDto()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            var restRequest = new RestRequest(_blogEndPoint, Method.Post);
            restRequest.AddJsonBody(blogDto);
            var response = await _client.ExecuteAsync(restRequest);
            if (response.IsSuccessStatusCode)
            {
                string message = response.Content!;
                Console.WriteLine(message);
            }
        }

        private async Task UpdateAsync(int id, string title, string author, string content)
        {
            BlogDto blog = new BlogDto()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            var restRequest = new RestRequest($"{_blogEndPoint}/{id}", Method.Put);
            restRequest.AddJsonBody(blogDto);
            var response = await _client.ExecuteAsync(restRequest);
            if (response.IsSuccessStatusCode)
            {
                string message = response.Content!;
                Console.WriteLine(message);
            }
        }

        private async Task DeleteAsync(int id)
        {
            RestRequest restRequest = new RestRequest($"{_blogEndPoint}/{id}", Method.Delete);
            var response = await _client.ExecuteAsync(restRequest);
            if (response.IsSuccessStatusCode)
            {
                string message = response.Content!;
                Console.WriteLine(message);
            }

        }
    }
}
