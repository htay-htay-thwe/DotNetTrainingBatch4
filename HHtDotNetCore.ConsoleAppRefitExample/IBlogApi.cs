using Refit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHtDotNetCore.ConsoleAppRefitExample
{
    internal interface IBlogApi
    {
        [Get("/api/blog")]
        Task<List<BlogModel>> GetBlogs();

        [Get("/api/blog/{id}")]
        Task<BlogModel> GetBlog(int id);

        [Post("/api/blog")]
        Task<string> CreateBlog(BlogModel blog);

        [Put("/api/blog/{id}")]
        Task<string> UpdateBlog(int id,BlogModel blog);

        [Delete("/api/blog/{id}")]
        Task<string> DeleteBlog(int id);

    }
}
public class BlogModel
{
    [Key]
    public int BlodId { get; set; }
    public string? BlogTitle { get; set; }
    public string? BlogAuthor { get; set; }
    public string? BlogContent { get; set; }
}
