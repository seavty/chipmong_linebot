using System.Threading.Tasks;
using ChipmongBotMessaging.Models;

namespace ChipmongBotMessaging.BLL
{
    public interface ILineHandler
    {
        Task ProcessMessage(WebhookModel value);
    }
}
