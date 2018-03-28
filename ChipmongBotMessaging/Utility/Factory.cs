using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChipmongBotMessaging.BLL;

namespace ChipmongBotMessaging.Utility
{
    public class Factory
    {
        public static ILineHandler CreateLineHandler() => new LineHandler();
    }
}