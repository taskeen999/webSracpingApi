using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HtmlAgilityPack;
using System.Net.Http;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations;
using static webSracpingApi.Controllers.ScrapperController;
using System;

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

        [HttpPost("Mens/TestBatters/bowlers/Allrounder")]
        public async Task<IActionResult> TestBatters(Overall formate)
        {
            //..https://feed.cricket-rankings.com/feed/test/batting/....done..


            List<Batter> batters = new List<Batter>();
            string website = $"https://feed.cricket-rankings.com/feed/test/{formate.ToString()}/";
            var web = new HtmlWeb();

            var htmldoc = web.Load(website);
            var nodeElement = htmldoc.DocumentNode.SelectNodes("//tr[@class='rankings']");
          //  var m = nodeElement.Nodes();

            foreach (var node in nodeElement)
            {


                var tds = node.InnerHtml;
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(tds);
                var t = doc.DocumentNode.SelectNodes("//td");
                batters.Add(new Batter
                {
                    Rank = t[0].InnerText.Trim(),
                    Name = t[1].InnerText.Trim(),
                    // Name = t[1].InnerText.Substring(0,0),
                    //  Name = t[1].InnerText.Remove(10),
                    Country = t[2].InnerText.Trim(),

                    Rating = t[3].InnerText.Trim()


                });
            }

            return Ok( batters);
           
        }
        [HttpPost("Mens/ODI/Batters/bowlers/Allrounder")]
        public async Task<IActionResult> ODItBatters(Overall formate)
        {
            //..https://feed.cricket-rankings.com/feed/test/batting/....done..


            List<Batter> batters = new List<Batter>();
            string website = $"https://feed.cricket-rankings.com/feed/odi/{formate.ToString()}/";
            var web = new HtmlWeb();

            var htmldoc = web.Load(website);
            var nodeElement = htmldoc.DocumentNode.SelectNodes("//tr[@class='rankings']");
            //  var m = nodeElement.Nodes();

            foreach (var node in nodeElement)
            {


                var tds = node.InnerHtml;
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(tds);
                var t = doc.DocumentNode.SelectNodes("//td");
                batters.Add(new Batter
                {
                    Rank = t[0].InnerText.Trim(),
                    Name = t[1].InnerText.Trim(),
                    // Name = t[1].InnerText.Substring(0,0),
                    //  Name = t[1].InnerText.Remove(10),
                    Country = t[2].InnerText.Trim(),

                    Rating = t[3].InnerText.Trim()


                });
            }

            return Ok(batters);

        }


        [HttpPost("Mens/T20/Batters/bowlers/Allrounder")]
        public async Task<IActionResult> t20tBatters(Overall formate)
        {
            //..https://feed.cricket-rankings.com/feed/test/batting/....done..


            List<Batter> batters = new List<Batter>();
            string website = $"https://feed.cricket-rankings.com/feed/t20/{formate.ToString()}/";
            var web = new HtmlWeb();

            var htmldoc = web.Load(website);
            var nodeElement = htmldoc.DocumentNode.SelectNodes("//tr[@class='rankings']");
            //  var m = nodeElement.Nodes();

            foreach (var node in nodeElement)
            {


                var tds = node.InnerHtml;
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(tds);
                var t = doc.DocumentNode.SelectNodes("//td");
                batters.Add(new Batter
                {
                    Rank = t[0].InnerText.Trim(),
                    Name = t[1].InnerText.Trim(),
                    // Name = t[1].InnerText.Substring(0,0),
                    //  Name = t[1].InnerText.Remove(10),
                    Country = t[2].InnerText.Trim(),

                    Rating = t[3].InnerText.Trim()


                });
            }

            return Ok(batters);

        }
        [HttpPost("Womens/ODi/Batters/bowlers/Allrounder")]
        public async Task<IActionResult> Odiwomen(Overall formate)
        {
            //..https://feed.cricket-rankings.com/feed/test/batting/....done..


            List<Batter> batters = new List<Batter>();
            string website = $"https://feed.cricket-rankings.com/feed/womenodi/{formate.ToString()}/";
            var web = new HtmlWeb();

            var htmldoc = web.Load(website);
            var nodeElement = htmldoc.DocumentNode.SelectNodes("//tr[@class='rankings']");
            //  var m = nodeElement.Nodes();

            foreach (var node in nodeElement)
            {


                var tds = node.InnerHtml;
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(tds);
                var t = doc.DocumentNode.SelectNodes("//td");
                batters.Add(new Batter
                {
                    Rank = t[0].InnerText.Trim(),
                    Name = t[1].InnerText.Trim(),
                    // Name = t[1].InnerText.Substring(0,0),
                    //  Name = t[1].InnerText.Remove(10),
                    Country = t[2].InnerText.Trim(),

                    Rating = t[3].InnerText.Trim()


                });
            }

            return Ok(batters);

        }


        [HttpPost("Womens/T20/Batters/bowlers/Allrounder")]
        public async Task<IActionResult> T20women(Overall formate)
        {
            //..https://feed.cricket-rankings.com/feed/test/batting/....done..


            List<Batter> batters = new List<Batter>();
            string website = $"https://feed.cricket-rankings.com/feed/woment20/{formate.ToString()}/";
            var web = new HtmlWeb();

            var htmldoc = web.Load(website);
            var nodeElement = htmldoc.DocumentNode.SelectNodes("//tr[@class='rankings']");
            //  var m = nodeElement.Nodes();

            foreach (var node in nodeElement)
            {


                var tds = node.InnerHtml;
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(tds);
                var t = doc.DocumentNode.SelectNodes("//td");
                batters.Add(new Batter
                {
                    Rank = t[0].InnerText.Trim(),
                    Name = t[1].InnerText.Trim(),
                    // Name = t[1].InnerText.Substring(0,0),
                    //  Name = t[1].InnerText.Remove(10),
                    Country = t[2].InnerText.Trim(),

                    Rating = t[3].InnerText.Trim()


                });
            }

            return Ok(batters);

        }













        [HttpPost("TeamsRanking")]
        public async Task<IActionResult> TeamsRanking(enFormat format)
        {
            List<TeamStatus> teamsStatus = new List<TeamStatus>();

            string website = $"https://www.icc-cricket.com/rankings/mens/team-rankings/{format.ToString()}";
            var web = new HtmlWeb();

            var htmldoc = web.Load(website);
            var nodeElement = htmldoc.DocumentNode.SelectNodes("//div[@class='rankings-block__container full rankings-table']/table/tbody" +
                "//tr");
            // var nodeindia = htmldoc.DocumentNode.SelectNodes("//div[@class='rankings-block__container full rankings-table']/table/tbody" +
            //  "//tr[@class='rankings-block__banner']");





            //  int iter = 0;
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
                    Name = t[1].InnerText.Trim().Replace("\n", "").Remove(15).Trim(),
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




        public class Batter
        {

            public string Rank { get; set; }
            public string Name { get; set; }
            public string Country { get; set; }
            public string Rating { get; set; }

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
        public enum Overall
        {
            batting = 1,
            bowling = 2,
            //all-rounder =3
        }

    }
    
