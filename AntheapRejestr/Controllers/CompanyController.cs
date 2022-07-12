using AntheapRejestr.Models;
using AntheapRejestr.Models.DBPersistence;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Schema;

namespace AntheapRejestr.Controllers
{
    public class CompanyController : Controller
    {
        static readonly ICompanyRepository CompanyRepository = new CompanyRepository();

        public IActionResult Company()
        {
            Company modelCompany = new Company();
            return View(modelCompany);
        }

        [HttpPost]
        public async Task<ActionResult> SearchByNIP(Company resultCompany)
        {
            var result = new Company() { NIP = resultCompany.NIP };
            string txtBoxNIP = Request.Form["NIP"];
            DateTime dateForSearch = DateTime.Now;

            using (var client = new HttpClient())
            {
                var requestGET = new HttpRequestMessage()
                {
                    RequestUri = new Uri($"https://wl-api.mf.gov.pl/api/search/nip/{txtBoxNIP}?date={dateForSearch.ToString(("yyyy-MM-dd"))}"),
                    Method = HttpMethod.Get
                };

                var response = await client.SendAsync(requestGET);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var data = Json(responseContent);

                    //TODO: wyświetlanie na stronie
                    var jsonDoc = JsonDocument.Parse(responseContent);
                    var jsonRoot = jsonDoc.RootElement;
                    var jsonResult = jsonRoot.GetProperty("result");
                    var jsonSubject = jsonResult.GetProperty("subject");
                    var deserializedCompany = JsonConvert.DeserializeObject<Company>(jsonSubject.ToString());
                    var companyGuid = CompanyRepository.Add(deserializedCompany);

                    return View(deserializedCompany);
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.TooManyRequests)
                    {
                        /* Use of test JSON mimicking real response. 
                         * in case we reached too many request to the real API 
                         * Use-case created solely for test purposes, to be deleted in production
                         */
                        string jsonTEST = System.IO.File.ReadAllText("jsonTEST.json");
                        var jsonDoc = JsonDocument.Parse(jsonTEST);
                        var jsonRoot = jsonDoc.RootElement;
                        var jsonResult = jsonRoot.GetProperty("result");
                        var jsonSubject = jsonResult.GetProperty("subject");
                        var deserializedCompany = JsonConvert.DeserializeObject<Company>(jsonSubject.ToString());
                        var companyGuid = CompanyRepository.Add(deserializedCompany);

                        return View(deserializedCompany);
                    }
                    else
                    {
                        return Json(response.StatusCode);
                    }
                }
            }
        }
    }
}
