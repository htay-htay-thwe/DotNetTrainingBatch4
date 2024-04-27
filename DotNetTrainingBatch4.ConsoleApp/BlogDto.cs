using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHTDotNetCore.ConsoleApp
{
    public class BlogDto
    {
        public int BlodId { get; set; }
        public string BlogTitle { get; set; }
        public string BlogAuthor { get; set; }
        public string BlogContent { get; set; }
    }
    public record BlogEntity(int BlodId,string BlogTitle,string BlogContent,string BlogAuthor);
}
