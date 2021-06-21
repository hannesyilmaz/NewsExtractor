using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewsExtractor.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace NewsExtractor.Controllers
{
    public class HomeController : Controller
    {
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        SqlConnection con = new SqlConnection();
        List<News> newses = new List<News>();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            con.ConnectionString = NewsExtractor.Properties.Resources.ConnectionString;
        }

        public IActionResult Index()
        {
            FetchData();
            return View(newses);
        }
        private void FetchData()
        {
            if(newses.Count > 0)
            {
                newses.Clear();
            }


            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "SELECT TOP (1000) [topic],[title],[summary],[link] FROM [NewsExtractor].[dbo].[Dataset]";
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    newses.Add(new News() { Topic = dr["topic"].ToString()
                    , Title = dr["title"].ToString()
                    , Summary = dr["summary"].ToString()
                    , Link = dr["link"].ToString()
                    });
                }
                con.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
