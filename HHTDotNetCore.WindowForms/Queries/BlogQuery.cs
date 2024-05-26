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
            @"select * from[dbo].[Tbl_PizzaOrder] po
            inner join Tbl_pizza p on p.PizzaId = po.PizzaId
            where PizzaOrderInvoiceNo = @PizzaOrderInvoiceNo";
    }
}
