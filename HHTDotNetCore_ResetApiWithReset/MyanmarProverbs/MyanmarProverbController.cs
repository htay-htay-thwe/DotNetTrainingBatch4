using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HHTDotNetCore_ResetApiWithNLayer.MyanmarProverbs
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyanmarProverbController : ControllerBase
    {
        public async Task<Tbl_MmproverbsDetail> GetDataFromApi()
        {
            //HttpClient client = new HttpClient();
            //var response = await client.GetAsync("https://github.com/sannlynnhtun-coding/Myanmar-Proverbs/blob/main/MyanmarProverbs.json");
            //if (response.IsSuccessStatusCode)
            //{
            //    string jsonStr = await response.Content.ReadAsStringAsync();
            //    var model = JsonConvert.DeserializeObject<Tbl_Mmproverbs>(jsonStr);
            //return model!;
            //}
            var jsonStr = await System.IO.File.ReadAllTextAsync("data2.json");
            var model = JsonConvert.DeserializeObject<Tbl_Mmproverbs>(jsonStr);
            return model!;
        }
        public async Task<IActionResult> Get()
        {
            var model = await GetDataFromApi();
            return Ok(model.Tbl_MMProverbs);
        }


        [HttpGet("{titleName}")]
        public async Task<IActionResult> Get(string titleName)
        {
            var model = await GetDataFromApi();
            var item = model.Tbl_MMProverbsTitle.FirstOrDefault(x => x.TitleName == titleName);
            if (item is null) return NotFound();
            var titleId = item.TitleId;
            var result = model.Tbl_MMProverbs.Where(x => x.TitleId == titleId);
            List<Tbl_MmproverbsHead> lst = result.Select(x => new Tbl_MmproverbsHead
            {
                ProverbId = x.ProverbId,
                ProverbName = x.ProverbName,
                TitleId = x.TitleId,
            }).ToList();
            return Ok(lst);
        }

        [HttpGet("{titleId}/{proverbId}")]
        public async Task<IActionResult> Get(string titleName,int proverbId)
        {
            var model = await GetDataFromApi();
           var item = model.Tbl_MMProverbs.FirstOrDefault(x => x.TitleId == titleId && x.ProverbId == proverbId);  
            return Ok(item);
        }

    }
    public class Tbl_Mmproverbs
    {
        public Tbl_Mmproverbstitle[] Tbl_MMProverbsTitle { get; set; }
        public Tbl_MmproverbsDetail[] Tbl_MMProverbs { get; set; }
    }

    public class Tbl_Mmproverbstitle
    {
        public int TitleId { get; set; }
        public string TitleName { get; set; }
    }

    public class Tbl_MmproverbsDetail
    {
        public int TitleId { get; set; }
        public int ProverbId { get; set; }
        public string ProverbName { get; set; }
        public string ProverbDesp { get; set; }
        public object? Tbl_MMProverbs { get; internal set; }
        public object Tbl_MMProverbsTitle { get; internal set; }
    }

    public class Tbl_MmproverbsHead
    {
        public int TitleId { get; set; }
        public int ProverbId { get; set; }
        public string ProverbName { get; set; }
        public string ProverbDesp { get; set; }
        public object? Tbl_MMProverbs { get; internal set; }
        public object Tbl_MMProverbsTitle { get; internal set; }
    }
}
