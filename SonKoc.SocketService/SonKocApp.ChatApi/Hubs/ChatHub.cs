using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SonKocApp.BusinessLayer.Abstract;
using SonKocApp.DataAccessLayer.Concrete;
using SonKocApp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SonKocApp.ChatApi.Hubs
{
    public sealed class ChatHub : Hub
    {
        private readonly IKisiService _kisiService;
        public ChatHub(IKisiService kisiService)
        {
            _kisiService= kisiService;
        }
        public static Dictionary<string, int> Users = new();
        public async Task Connect(int id)
        {
            Users.Add(Context.ConnectionId,id);
            Kisi? user = _kisiService.TGetByid(id);
            if (user != null) {
                user.UserOnlineMi = true; 
                _kisiService.TUpdate(user);
            }
            await Clients.All.SendAsync("Users", user);
        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            if (Users.TryGetValue(Context.ConnectionId, out int userId))
            {
                Users.Remove(Context.ConnectionId);
                Kisi? user = _kisiService.TGetByid(userId);
                if (user != null)
                {
                    user.UserOnlineMi = false;
                    _kisiService.TUpdate(user);

                    await Clients.All.SendAsync("Users", user);
                }
            }

            await base.OnDisconnectedAsync(exception);
        }

    }
}
