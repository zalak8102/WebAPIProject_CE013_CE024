using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TenantFinderAPI.Models;

namespace TenantWebClient.Controllers
{
    public class FinderController : Controller
    {
        private readonly ILogger<FinderController> _logger;
        private static readonly HttpClient client = new HttpClient();
        public FinderController(ILogger<FinderController> logger)
        {
            _logger = logger;
        }
        public async Task<IActionResult> Profile()
        {
            var check = HttpContext.Session.GetString("utype");
            if (check == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                if (check.Equals("owner"))
                {
                    return RedirectToAction("index");
                }
                else
                {
                    int id = (int)HttpContext.Session.GetInt32("uid");
                    HttpRequestMessage hrmsg = new HttpRequestMessage(HttpMethod.Get, "http://localhost:57445/api/tenant/" + id);
                    var response = await client.SendAsync(hrmsg);

                    if (response.IsSuccessStatusCode)
                    {
                        using var responseStream = await response.Content.ReadAsStreamAsync();
                        var t2 = await response.Content.ReadAsStringAsync();
                        var t1 = JsonConvert.DeserializeObject<Tenant>(t2);
                        return View(t1);
                    }
                    else
                    {
                        var t = Array.Empty<Tenant>();
                        return View(t[0]);
                    }
                }
            }
                   
        }
        public async Task<IActionResult> Index()
        {
            var check = HttpContext.Session.GetString("utype");
            if (check == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                if (check.Equals("owner"))
                {
                    HttpRequestMessage hrmsg = new HttpRequestMessage(HttpMethod.Get, "http://localhost:57445/api/tenant");
                    var response = await client.SendAsync(hrmsg);

                    if (response.IsSuccessStatusCode)
                    {
                        using var responseStream = await response.Content.ReadAsStreamAsync();
                        var t = await System.Text.Json.JsonSerializer.DeserializeAsync
                            <IEnumerable<Tenant>>(responseStream);
                        return View(t);
                    }
                    else
                    {
                        var t = Array.Empty<Tenant>();
                        return View(t);
                    }
                }
                else
                {
                    return RedirectToAction("Profile");
                }
            }
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> Add(Tenant tenant)
        {

            if (ModelState.IsValid)
            {
                HttpClient client1 = new HttpClient();
                var myContent = JsonConvert.SerializeObject(tenant);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var result = client1.PostAsync("http://localhost:57445/api/tenant", byteContent).Result;

                if (result.IsSuccessStatusCode)
                {
                    HttpRequestMessage hrmsg = new HttpRequestMessage(HttpMethod.Get, "http://localhost:57445/api/tenant");
                    var response = await client1.SendAsync(hrmsg);

                    if (response.IsSuccessStatusCode)
                    {
                        using var responseStream = await response.Content.ReadAsStreamAsync();
                        var t = await System.Text.Json.JsonSerializer.DeserializeAsync<IEnumerable<Tenant>>(responseStream);


                        return RedirectToAction("Login", "Home");
                    }
                    else
                    {
                        var t = Array.Empty<Tenant>();
                        return RedirectToAction("Login", "Home");
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
                return RedirectToAction("Login", "Home");
            }
            else
            {
                if (check.Equals("tenant"))
                {
                    HttpRequestMessage hrmsg = new HttpRequestMessage(HttpMethod.Get, "http://localhost:57445/api/tenant/" + id);
                    var response = await client.SendAsync(hrmsg);

                    if (response.IsSuccessStatusCode)
                    {
                        using var responseStream = await response.Content.ReadAsStreamAsync();
                        var t2 = await response.Content.ReadAsStringAsync();
                        var t1 = JsonConvert.DeserializeObject<Tenant>(t2);
                        return View(t1);
                    }
                    else
                    {
                        var t = Array.Empty<Tenant>();
                        return View(t[0]);
                    }
                }
                else
                {
                    return NotFound();
                }
            }

        }




        [HttpPost]
        public async Task<ActionResult> Edit(Tenant tenant)
        {

            var hItemJson = new StringContent(
            System.Text.Json.JsonSerializer.Serialize(tenant), Encoding.UTF8, "application/json");

            using var httpResp =
                await client.PutAsync("http://localhost:57445/api/tenant/" + tenant.tid, hItemJson);

            httpResp.EnsureSuccessStatusCode();

            HttpRequestMessage hrmsg = new HttpRequestMessage(HttpMethod.Get, "http://localhost:57445/api/tenant");
            var response = await client.SendAsync(hrmsg);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var t = await System.Text.Json.JsonSerializer.DeserializeAsync
                    <IEnumerable<Tenant>>(responseStream);
                return RedirectToAction("Profile");
            }
            else
            {
                var t = Array.Empty<Tenant>();
                return RedirectToAction("Profile");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            HttpRequestMessage hrmsg = new HttpRequestMessage(HttpMethod.Get, "http://localhost:57445/api/tenant/" + id);
            var response = await client.SendAsync(hrmsg);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var t2 = await response.Content.ReadAsStringAsync();
                var t1 = JsonConvert.DeserializeObject<Tenant>(t2);
                return View(t1);
            }
            else
            {
                var t = Array.Empty<Tenant>();
                return View(t[0]);
            }

        }

        [HttpPost , ActionName("Delete")]
        public async Task<ActionResult> Deletecnf(int id)
        {
            Console.WriteLine(id);
            using var httpResp = await client.DeleteAsync("http://localhost:57445/api/tenant/" + id);

            httpResp.EnsureSuccessStatusCode();

            HttpRequestMessage hrmsg = new HttpRequestMessage(HttpMethod.Get, "http://localhost:57445/api/tenant");
            var response = await client.SendAsync(hrmsg);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var t = await System.Text.Json.JsonSerializer.DeserializeAsync<IEnumerable<Tenant>>(responseStream);
                return RedirectToAction("Index");
            }
            else
            {
                var t = Array.Empty<Tenant>();
                return RedirectToAction("Index");
            }

        }
    }
}
