// See https://aka.ms/new-console-template for more information
using HHTDotNet.ConsoleAppHttpClientExample;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

//HttpClient client = new HttpClient();
//var response = await client.GetAsync("https://localhost:7102/api/blog");
//if (response.IsSuccessStatusCode)
//{
//    string jsonStr = await response.Content.ReadAsStringAsync(); 
//    List<BlogDto> lst = JsonConvert.DeserializeObject<List<BlogDto>>(jsonStr)!;   
//    foreach(var blog in lst)
//    {
//        Console.WriteLine(JsonConvert.SerializeObject(blog));
//        Console.WriteLine($"Title => {blog.BlogTitle}");
//    }
//}

HttpClientExample example = new HttpClientExample();
await example.RunAsync();