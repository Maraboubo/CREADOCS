using ApiCreadocs.Models;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiCreadocs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProxyController : ControllerBase
    {

        [HttpPost("proxy")]
        public async Task<IActionResult> Proxy([FromBody] object jsonBody)
        {
            string JSONData = jsonBody.ToString();

            using (var client = new HttpClient())
            {
                var content = new MultipartFormDataContent();
                content.Add(new StringContent(JSONData), "json:Assurance_Kw_Demo");

                //var response = await client.PostAsync("https://contenthub-fr.test.omscloud.eu/mtext-integration-adapter/template/CONTRAT_KW_ASSURANCE_DEMO/Templates/CONTRAT_KW_ASSURANCE_DEMO.template/export?document-name=ASSURANCE1234567&mime-type=application%2Fpdf&user=user_ADV&passwordplain=demo", content);
                var response = await client.PostAsync("https://demo1.test.omscloud.eu/mtext-integration-adapter/template/CONTRAT_KW_ASSURANCE_DEMO/Templates/CONTRAT_KW_ASSURANCE_DEMO.template/export?document-name=ASSURANCE1234567&mime-type=application%2Fpdf&user=user_ADV&passwordplain=demo", content);


                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStreamAsync();
                    return File(result, "application/pdf", "ASSURANCE1234567.pdf");
                }

                return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());
            }
        }
     }
}
