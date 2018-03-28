using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using ChipmongBotMessaging.Models;
using ChipmongBotMessaging.Utility;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace ChipmongBotMessaging.Controllers
{
    public class LineController : ApiController
    {
        //private string channelSecret = "replace with your channel secret";

        //--x_demo bot
        //private string channelSecret = "598283af2dfe71eeff0ae28d6ffc22f4";

        //-x-ware bot
        private string channelSecret = "4d6755fc38d23e2e6b8d599fb4e0a12c";

        public IHttpActionResult Get()
        {
            return Ok();
        }

        // GET: api/Line/5
        public string Get(int id)
        {
            return id.ToString();
        }

        // POST: api/Line
        public async Task<HttpResponseMessage> Post()
        {
            try
            {
                var signature = Request.Headers.GetValues("X-Line-Signature").FirstOrDefault();
                var body = await Request.Content.ReadAsStringAsync();
                var cryptoResult = SHA256Crypto(body);
                if (signature == cryptoResult)
                {
                    var value = JsonConvert.DeserializeObject<WebhookModel>(body);
                    var handler = Factory.CreateLineHandler();
                    await handler.ProcessMessage(value);
                }
                else
                {
                    // signature not valid
                }
            }
            catch (Exception ex)
            {
                // handle exception
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        private string SHA256Crypto(string text)
        {
            using (HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(channelSecret)))
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(text));
                return Convert.ToBase64String(hash);
            }
        }
    }
}

