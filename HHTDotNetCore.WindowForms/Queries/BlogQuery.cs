using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHTDotNetCore.WindowForms.Queries
{
    internal class BlogQuery
    {
        public static string BlogCreate { get; } =
            @"INSERT INTO [dbo].[Table_1]
            ([BlogTitle],[BlogAuthor],[BlogContent]) 
            VALUES 
            (@BlogTitle,@BlogAuthor,@BlogContent)";
        public static string BlogList { get; } = @"SELECT [BlodId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
  FROM [dbo].[Table_1]";


    }
}
