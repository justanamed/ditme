using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using abcccdscdcdcsdcsdcsdcdscsdfsdf.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace abcccdscdcdcsdcsdcsdcdscsdfsdf.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }
        public class JsonContent : StringContent
        {
            public JsonContent(object obj) :
                base(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json")
            { }
        }
        //[HttpPost]
        //public async Task<IActionResult> Index(IFormCollection tk)
        //{
            
        //    string temp = tk["id"] + ":" + tk["pass"];
        //    var client = new HttpClient();
        //    client.BaseAddress = new Uri("https://demo-sinvoice.viettel.vn:8443/InvoiceAPI/");
        //    client.DefaultRequestHeaders.Accept.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    string authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(temp)); //("Username:Password")  
        //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authInfo);
        //    var response = await client.PostAsync("InvoiceUtilsWS/getInvoiceRepresentationFile",
        //        new JsonContent(new {
        //            supplierTaxCode = "0100109106",
        //            invoiceNo = "AB/19E0000746",
        //            templateCode = "01GTKT0/315",
        //            fileType = "pdf",

        //        }));
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var item =Json(response.Content.ReadAsStringAsync().Result);
        //        ViewBag.alo = item;
        //        return View();
        //    }
        //    else
        //    {
        //        ViewBag.alo = "Đăng nhập lỗi";
        //        return View();
        //    }
        //}
        //[HttpPost]
        //public async Task<JsonResult> Getitem(string tk, string mk)
        //{
        //    string temp = tk+ ":" + mk;
        //    var client = new HttpClient();
        //    client.BaseAddress = new Uri("https://demo-sinvoice.viettel.vn:8443/InvoiceAPI/");
        //    client.DefaultRequestHeaders.Accept.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    string authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(temp)); //("Username:Password")  
        //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authInfo);
        //    var response = await client.PostAsync("InvoiceUtilsWS/getInvoiceRepresentationFile",
        //        new JsonContent(new
        //        {
        //            supplierTaxCode = "0100109106",
        //            invoiceNo = "AB/19E0000746",
        //            templateCode = "01GTKT0/315",
        //            fileType = "pdf",

        //        }));
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var item = Json(response.Content.ReadAsStringAsync().Result);
        //        return Json(item);
        //    }
        //    else
        //    {
        //        return Json(null);
        //    }
        //}
        //public IActionResult Privacy()
        //{
        //    return View();
        //}
        [HttpPost]
        public async Task<JsonResult> Getitem(string tk, string mk)
        {
            string temp = tk + ":" + mk;
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://demo-sinvoice.viettel.vn:8443/InvoiceAPI/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(temp)); //("Username:Password")  
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authInfo);
            var response = await client.PostAsync("InvoiceUtilsWS/getInvoices/0100109106",
                new JsonContent(new
                {
                    startDate = "2019-5-12T10:14:32.611+07:00",
                    endDate = "2019-5-17T10:14:32.611+07:00",
                    invoiceType = "02GTTT",
                    rowPerPage = "20",
                    pageNum = "1"
                }));
            if (response.IsSuccessStatusCode)
            {
                var item = Json(response.Content.ReadAsStringAsync().Result);
                return Json(item);
            }
            else
            {
                return Json(null);
            }
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
