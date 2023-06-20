using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HtmlAgilityPack;
using System.Net.Http;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations;

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



        //  rankings-block__banner--pos
        //rankings-block__banner--pos


        [HttpPost("TeamsRanking")]
        public async Task<IActionResult> TeamsRanking(enFormat format)
        {
            List<TeamStatus> teamsStatus = new List<TeamStatus>();

            string website = $"https://www.icc-cricket.com/rankings/mens/team-rankings/{format.ToString()}";
            var web = new HtmlWeb();

            var htmldoc = web.Load(website);
            var nodeElement = htmldoc.DocumentNode.SelectNodes("//div[@class='rankings-block__container full rankings-table']/table/tbody" +
                "//tr");
            var nodeindia = htmldoc.DocumentNode.SelectNodes("//div[@class='rankings-block__container full rankings-table']/table/tbody" +
              "//tr[@class='rankings-block__banner']");

            //u-show-phablet
            HtmlDocument html = new HtmlDocument();
            

            int iter = 0;
            foreach (var node in nodeElement)
            {
                //if (iter != 0)
              //  {
                    var tds = node.InnerHtml;
                    HtmlDocument doc = new HtmlDocument();
                    doc.LoadHtml(tds);
                    var t = doc.DocumentNode.SelectNodes("//td");

                    //doc.LoadHtml(t[1].InnerHtml);
                    // var spans = doc.DocumentNode.SelectNodes("//span");
                    // var spans = doc.DocumentNode.SelectNodes("//span");

                    teamsStatus.Add(new TeamStatus
                    {
                        Position = t[0].InnerText.Trim(),
                        Name = t[1].InnerText.Trim().Replace("\n","").Remove(15).Trim(),
                        // Name = t[1].InnerText.Substring(0,0),
                      //  Name = t[1].InnerText.Remove(10),
                        Matches = t[2].InnerText.Trim(),
                        Points = t[3].InnerText.Trim(),
                        Rating = t[4].InnerText.Trim()
                        
                        
                    });
          //      }
               // if (iter > 8)
                    //break;
                //iter++;
            }

            return Ok(teamsStatus);
        }

    }

    public class TeamStatus
    {
        public string Position { get; set; }
       // [MaxLength(7)]
        public string Name { get; set; }
        public string Matches { get; set; }
        public string Points { get; set; }
        public string Rating { get; set; }
    }

    public enum enFormat
    {
        t20i = 1,
        odi = 2,
        test = 3
    }
}
