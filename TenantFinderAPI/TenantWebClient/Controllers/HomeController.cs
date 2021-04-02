using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TenantWebClient.Models;
using TenantFinderAPI.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using TenantWebClient.ViewModels;
using Microsoft.AspNetCore.Http;

namespace TenantWebClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static readonly HttpClient client = new HttpClient();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        
        public async Task<IActionResult> Index()
        {
            var check = HttpContext.Session.GetString("utype");
            if (check==null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                if(check.Equals("owner"))
                {
                    HttpRequestMessage hrmsg = new HttpRequestMessage(HttpMethod.Get, "http://localhost:57445/api/house");
                    var response = await client.SendAsync(hrmsg);

                    if (response.IsSuccessStatusCode)
                    {
                        using var responseStream = await response.Content.ReadAsStreamAsync();
                        var h = await System.Text.Json.JsonSerializer.DeserializeAsync
                            <IEnumerable<House>>(responseStream);
                        return View(h);
                    }
                    else
                    {
                        var h = Array.Empty<House>();
                        return View(h);
                    }
                }
                else
                {
                    return RedirectToAction("TIndex");
                }
            }
            

        }

        public async Task<IActionResult> TIndex()
        {
            HttpRequestMessage hrmsg = new HttpRequestMessage(HttpMethod.Get, "http://localhost:57445/api/house");
            var response = await client.SendAsync(hrmsg);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var h = await System.Text.Json.JsonSerializer.DeserializeAsync
                    <IEnumerable<House>>(responseStream);
                return View(h);
            }
            else
            {
                var h = Array.Empty<House>();
                return View(h);
            }

        }

        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(ULogin ulogin)
        {
            if(ModelState.IsValid)
            {
                if(ulogin.uname.Equals("owner") && (ulogin.pass.Equals("owner")))
                {
                    HttpContext.Session.SetString("utype", "owner");
                    return RedirectToAction("Index");
                }
                else
                {
                    HttpRequestMessage hrmsg = new HttpRequestMessage(HttpMethod.Get, "http://localhost:57445/api/tenant");
                    var response = await client.SendAsync(hrmsg);

                    if (response.IsSuccessStatusCode)
                    {
                        using var responseStream = await response.Content.ReadAsStreamAsync();
                        var t = await System.Text.Json.JsonSerializer.DeserializeAsync
                            <IEnumerable<Tenant>>(responseStream);
                        foreach(var i in t)
                        {
                            if(i.tname.Equals(ulogin.uname) && i.phone.ToString().Equals(ulogin.pass))
                            {
                                HttpContext.Session.SetString("utype", "tenant");
                                HttpContext.Session.SetInt32("uid", i.tid);
                                return RedirectToAction("Index");
                            }
                        }
                    }

                }
            }
            ViewBag.msg = "Incorrect Credentials";
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            var check = HttpContext.Session.GetString("utype");
            if (check == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                if (check.Equals("owner"))
                {

                    return View();
                }
                else
                {
                    return NotFound();
                }
            }
        }


        [HttpPost]
        public async Task<ActionResult> Add(House house)
        {

            if (ModelState.IsValid)
            {
                HttpClient client1 = new HttpClient();
                var myContent = JsonConvert.SerializeObject(house);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var result = client1.PostAsync("http://localhost:57445/api/house", byteContent).Result;

                if (result.IsSuccessStatusCode)
                {
                    HttpRequestMessage hrmsg = new HttpRequestMessage(HttpMethod.Get, "http://localhost:57445/api/house");
                    var response = await client1.SendAsync(hrmsg);

                    if (response.IsSuccessStatusCode)
                    {
                        using var responseStream = await response.Content.ReadAsStreamAsync();
                        var h = await System.Text.Json.JsonSerializer.DeserializeAsync<IEnumerable<House>>(responseStream);


                        return View("Index", h);
                    }
                    else
                    {
                        var h = Array.Empty<House>();
                        return View("Index", h);
                    }

                }
                else
                {
                    return View();
                }

            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var check = HttpContext.Session.GetString("utype");
            if (check == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                if (check.Equals("owner"))
                {

                    HttpRequestMessage hrmsg = new HttpRequestMessage(HttpMethod.Get, "http://localhost:57445/api/house/" + id);
                    var response = await client.SendAsync(hrmsg);

                    if (response.IsSuccessStatusCode)
                    {
                        using var responseStream = await response.Content.ReadAsStreamAsync();
                        var h2 = await response.Content.ReadAsStringAsync();
                        var h1 = JsonConvert.DeserializeObject<House>(h2);
                        return View(h1);
                    }
                    else
                    {
                        var h = Array.Empty<House>();
                        return View(h[0]);
                    }
                }
                else
                {
                    return NotFound();
                }

            }
        }



        
        [HttpPost]
        public async Task<ActionResult> Edit(House house)
        {

            var hItemJson = new StringContent(
            System.Text.Json.JsonSerializer.Serialize(house), Encoding.UTF8,"application/json");

            using var httpResp =
                await client.PutAsync("http://localhost:57445/api/house/" + house.hid, hItemJson);

            httpResp.EnsureSuccessStatusCode();
       
            HttpRequestMessage hrmsg = new HttpRequestMessage(HttpMethod.Get, "http://localhost:57445/api/house");
            var response = await client.SendAsync(hrmsg);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var h = await System.Text.Json.JsonSerializer.DeserializeAsync
                    <IEnumerable<House>>(responseStream);
                return View("Index", h);
            }
            else
            {
                var h = Array.Empty<House>();
                return View("Index", h);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var check = HttpContext.Session.GetString("utype");
            if (check == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                if (check.Equals("owner"))
                {
                    HttpRequestMessage hrmsg = new HttpRequestMessage(HttpMethod.Get, "http://localhost:57445/api/house/" + id);
                    var response = await client.SendAsync(hrmsg);

                    if (response.IsSuccessStatusCode)
                    {
                        using var responseStream = await response.Content.ReadAsStreamAsync();
                        var h2 = await response.Content.ReadAsStringAsync();
                        var h1 = JsonConvert.DeserializeObject<House>(h2);
                        return View(h1);
                    }
                    else
                    {
                        var h = Array.Empty<House>();
                        return View(h[0]);
                    }
                }
                else
                {
                    return NotFound();
                }
            }
        }
        [HttpPost, ActionName("Delete")]

        public async Task<ActionResult> Deletecnf(int id)
        {
            Console.WriteLine(id);
            using var httpResp = await client.DeleteAsync("http://localhost:57445/api/house/" + id);

            httpResp.EnsureSuccessStatusCode();
           
            HttpRequestMessage hrmsg = new HttpRequestMessage(HttpMethod.Get, "http://localhost:57445/api/house");
            var response = await client.SendAsync(hrmsg);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var h = await System.Text.Json.JsonSerializer.DeserializeAsync<IEnumerable<House>>(responseStream);
                return RedirectToAction("Index");
            }
            else
            {
                var h = Array.Empty<House>();
                return RedirectToAction("Index");
            }

        }
        
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
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
