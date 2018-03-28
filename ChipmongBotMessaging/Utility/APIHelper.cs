using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ChipmongBotMessaging.Models;
using Newtonsoft.Json;

namespace ChipmongBotMessaging.Utility
{
    public class APIHelper
    {
        //private readonly static string channelToken = "replace with your Channel Access Token";

        //-- x_demo bot 
        //private readonly static string channelToken = "EQj4pA2791DnPKpdmO+Gmn33c4bgjE6RhaSUThMiEY/khUYRuNZfqTgganra1LeqE7uONB9qOk8wTp41vq6uqJVSSEE9ApWAaytvGgMRj0qFtsxz4WxN2uFZ/8gI+F8fc4MDKdVLViAagbNWSiIY8QdB04t89/1O/w1cDnyilFU=";

        //-x-ware bot
        private readonly static string channelToken = "iTSPe02D3aHe3Z98tlMpWIQchqThOvBY6lfrBIeOmAjKWMSxKCX38BEube44MYvszihUGUO5bqUnjXdXy+tI1n/7i0QrKF7jB/wA96gJmoy1Y9XNXNZNdNgKyamhy0FKb55vktwsy1EBwfAjDlZlTAdB04t89/1O/w1cDnyilFU=";

        public static async Task<HttpResponseMessage> ReplyMessage(ReplyModel reply)
        {
            using (HttpClient client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(reply);
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {channelToken}");
                return await client.PostAsync("https://api.line.me/v2/bot/message/reply",
                    new StringContent(json, Encoding.UTF8, "application/json"));
            }
        }
    }
}