using HHTDotNetCore.shared;
using HHTDotNetCore_ResetApiWithNLayer;
using HHTDotNetCore_ResetApiWithNLayer.db;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HHTDotNetCore.PizzaApi.Pizza
{
    [Route("api/[controller]")]
    [ApiController]
    public class DreamController : ControllerBase
    {
        private readonly DbContext _appDbContext;
        private readonly DapperService _dapperService;

        public DreamController() {
            _appDbContext = new AppDbContext();
            _dapperService = new DapperService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        }

        public object extraId { get; private set; }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var lst = await _appDbContext.Pizzas.ToListAsync();
            return Ok(lst);
        }
        [HttpGet("Extras")]
        public async Task<IActionResult> GetExtraAsync()
        {
            var lst = await _appDbContext.PizzaExtras.ToListAsync();
            return Ok(lst);
        }

        //[HttpGet("Order/{invoiceNo}")]
        //public async Task<IActionResult> GetOrder(string invoiceNo)
        //{
        //    var item= await _appDbContext.PizzaOrders.FirstOrDefaultAsync(x => x.PizzaOrderInvoiceNo == invoiceNo);
        //    var lst = await _appDbContext.PizzaOrderDetails.Where(x =>x.PizzaOrderInvoiceNo == invoiceNo).ToListAsync();

        //    return Ok(new{
        //          Order = item,
        //          OrderDetail = lst
        //    });
        //}

        [HttpGet("Order/{invoiceNo}")]
        public IActionResult GetOrder(string invoiceNo)
        {
            var item = _dapperService.QueryFirstOrDefault<PizzaOrderInvoiceHeadModel>
                (
                query.DreamQuery.PizzaOrderQuery,
                new
                {
                    PizzaOrderInvoiceNo = invoiceNo
                } 
        
                );
            var lst = _dapperService.Query<PizzaOrderInvoiceDetailModel>
                (
                query.DreamQuery.PizzaOrderQuery,
                new
                {
                    PizzaOrderInvoiceNo = invoiceNo
                }

                );
            var model = new PizzaOrderInvoiceResponse
            {
                Order = item,
                OrderDetail = lst
            };
            return Ok(model);
        }
        [HttpPost("Order")]
        public async Task<IActionResult> OrderAsync(OrderRequest orderRequest)
        {
            var itemPizza = await _appDbContext.Pizzas.FirstOrDefaultAsync(x => x.Id == orderRequest);
            var total = itemPizza.Price;
            if(orderRequest.Extras.Length > 0 )
            {
                var lstExtra = await _appDbContext.PizzaExtras.Where(x => orderRequest.Extras.Contains(x.Id)).ToListAsync();
                total += lstExtra.Sum(x => x.Price);
            }
            //PizzaModel pizzaOrderModel = new PizzaModel()
            //{
            //    PizzaId = orderRequest.PizzaId,
            //    PizzaOrderInvoiceNo = DateTime.Now.ToString("yyyyMMddHHmmss"),
            //    TotalAmount = total
            //};
            var invoiceNo = DateTime.Now.ToString("yyyyMMddHHmmss");
            PizzaOrderModel pizzaOrderModel = new PizzaOrderModel()
            {
                PizzaId = orderRequest.PizzaId,
                PizzaOrderInvoiceNo = invoiceNo,
                TotalAmount = total,
            };
            List<PizzaOrderDetailModel>pizzaExtraModels = orderRequest.Extras.Select(x => new PizzaOrderDetailModel
            {
               PizzaExtraId = (int)extraId,
                    PizzaOrderInvoiceNo = invoiceNo,
            }).ToList();    
            await _appDbContext.pizzaOrders.AddAsync(pizzaOrderModel);
            await _appDbContext.pizzaOrderDetails.AddRangeAsync(pizzaExtraModels);
            await _appDbContext.SaveChangesAsync();
            OrderResponse response = new OrderResponse()
            {
                InvoiceNo = invoiceNo,
                Message = "Thank you for your order!",
                TotalAmount = total,
            };
            return Ok(orderRequest);
        }
    }
}
