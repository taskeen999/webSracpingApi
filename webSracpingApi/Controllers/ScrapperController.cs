using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HtmlAgilityPack;
using System.Net.Http;

namespace webSracpingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScrapperController : ControllerBase
    {
        private readonly ILogger _logger;
        public ScrapperController(ILogger<ScrapperController> logger)
        {
            _logger = logger;
        }

        [HttpPost("webscrape")]
        public async Task<List<string>> webscrape( string website) {

         List<string> result = new List<string>();
            var web =  new HtmlWeb();
            var htmldoc = web.Load(website);
            var nodeElement = htmldoc.DocumentNode.SelectNodes("//div[@class='rankings-block__container full rankings-table']/table");

            
            foreach (var node in nodeElement)
            {

                result .Add( node.InnerHtml.FirstOrDefault().ToString());
              // node.FirstChild.Element().F
                    

            }


            


            return result;
        }
        
    }
}
