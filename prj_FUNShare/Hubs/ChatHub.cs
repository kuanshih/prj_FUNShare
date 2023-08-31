using Microsoft.AspNetCore.SignalR;
using prj_FUNShare.Models;

namespace prj_FUNShare.Hubs
{
    public class ChatHub:Hub
    {
        private readonly FUNShareContext _context;
        public ChatHub(FUNShareContext context)
        {
            _context = context;
        }
        public async Task SendPrivateMessage(int senderId,int receiverId, string message)
        {
            //var chatMessage = new Chat
            //{
            //    ChatMessengerId = 1,
            //    SenderId = senderId,
            //    ReceiverId = receiverId,
            //    MessageContent = Message,
            //    MessageCreateTime = DateTime.Now
            //};
            //_context.Chat.Add(chatMessage);
            //await _context.SaveChangesAsync();

            //string connetionId = getUserConnId(receiverId);
            await Clients.All.SendAsync("ReceiveMessage", senderId, message);
        }

        private string getUserConnId(int receiverId)
        {
            //var user = userConnections.Find(u=>u.AccountId)
            return "";
        }
    }
}
