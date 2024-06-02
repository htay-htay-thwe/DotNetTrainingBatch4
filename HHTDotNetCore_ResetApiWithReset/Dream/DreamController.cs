using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HHTDotNetCore.DreamDict.Dream
{
    [Route("api/[controller]")]
    [ApiController]
    public class DreamController : ControllerBase
    {
        public async Task<Dream> GetDataFromApi()
        {
            //HttpClient client = new HttpClient();
            //var response = await client.GetAsync(https://github.com/sannlynnhtun-coding/Dream-Dictionary/blob/main/DreamDictionary.json");
            //if (response.IsSuccessStatusCode)
            //{
            //    string jsonStr = await response.Content.ReadAsStringAsync();
            //    var model = JsonConvert.DeserializeObject<Tbl_Mmproverbs>(jsonStr);
            //return model!;
            //}
            var jsonStr = await System.IO.File.ReadAllTextAsync("DreamDictionary.json");
            var model = JsonConvert.DeserializeObject<Dream>(jsonStr);
            return model!;
        }
        public async Task<IActionResult> Get()
        {
            var model = await GetDataFromApi();
            return Ok(model.BlogHeader);
        }


        [HttpGet("{BlogTitle}")]
        public async Task<IActionResult> GetHeader(string titleName)
        {
            var model = await GetDataFromApi();
            var item = model.BlogHeader.FirstOrDefault(x => x.BlogTitle == titleName);
            if (item is null) return NotFound();
            var titleId = item.BlogId;
            var result = model.BlogHeader.Where(x => x.BlogId == titleId);
            List<Blogheader> lst = result.Select(x => new Blogheader
            {
                BlogId = x.BlogId,
                BlogTitle = x.BlogTitle,
            }).ToList();
            return Ok(lst);
        }

        [HttpGet("{titleName}/{detailId}")]
        public async Task<IActionResult> GetDetail(string titleName, int detailId)
        {
            var model = await GetDataFromApi();
            var item = model.BlogDetail.FirstOrDefault(x => x.Blogheader == titleName && x.BlogDetailId == detailId);
            return Ok(item);
        }
    }
        public class Dream
        {
            public Blogheader[] BlogHeader { get; set; }
            public Blogdetail[] BlogDetail { get; set; }
        }

        public class Blogheader
        {
            public int BlogId { get; set; }
            public string BlogTitle { get; set; }
        }

        public class Blogdetail
        {

            public int BlogDetailId { get; set; }
            public int BlogId { get; set; }
            public string Blogheader { get; set; }
        }
    
}
