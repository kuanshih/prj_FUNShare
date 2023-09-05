using Microsoft.AspNetCore.SignalR;
using prj_FUNShare.Models;
using prj_FUNShare.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;

namespace prj_FUNShare.Hubs
{
    public class ChatHub3 : Hub
    {
        private static List<CChatUserInfo> userConnections = new List<CChatUserInfo>();
        private readonly FUNShareContext _context;

        public ChatHub3(FUNShareContext context)
        {
            _context = context;
        }

        //連線找到使用者ID 如果沒有新增
        public async Task UpdateUserInfo(int senderId, string vconnectionId)
        {
            // 獲取使用者的 accountId 和 ConnectionId
            int accountId = senderId;
            string connectionId = Context.ConnectionId;
            CChatUserInfo existingUserInfo = userConnections.FirstOrDefault(u => u.AccountId == accountId);
            if (existingUserInfo != null)
            {
                // 更新現有的 ConnectionId
                existingUserInfo.ConnectionId = connectionId;
            }
            else
            {
                // 新增新的使用者資訊
                CChatUserInfo userInfo = new CChatUserInfo
                {
                    AccountId = accountId,
                    ConnectionId = connectionId
                };
                userConnections.Add(userInfo);
            }
            await Clients.All.SendAsync("UpdateUserInfo", accountId, connectionId);
        }
        //找到收件者UserConnID
        private string getUserConnId(int receiverId)
        {
            var user = userConnections.Find(u => u.AccountId == receiverId);
            if (!string.IsNullOrEmpty(user.ConnectionId))
            {
                return user.ConnectionId;
            }
            else { return "No Find."; }
        }
        //傳送私人訊息
        public async Task SendPrivateMessage(int senderId, int receiverId, string message)
        {
            //先存入資料庫
            var chatMessage = new Chat
            {
                SenderId = senderId,
                ReceiverId = receiverId,
                MessageContent = message,
                MessageCreateTime = DateTime.Now


            };
            _context.Chat.Add(chatMessage);
            await _context.SaveChangesAsync();

            // 將訊息傳送給特定的使用者
            string connectionId = getUserConnId(receiverId);
            await Clients.Client(connectionId).SendAsync("ReceiveMessage", senderId, message);

        }
    }
}
