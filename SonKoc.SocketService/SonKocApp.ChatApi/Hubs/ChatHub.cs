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
        private readonly IKurumService _kurumservice;
        public ChatHub(IKisiService kisiService, IKurumService kurumservice)
        {
            _kisiService = kisiService;
            _kurumservice = kurumservice;

        }
        public static Dictionary<string, int> Users = new();
        public async Task Connect(int id)
        {
            if(id > 4999999)
            {
                Users.Add(Context.ConnectionId, id);
                Kurum? user = _kurumservice.TGetByid(id);
                if (user != null)
                {
                    user.KurumOnlineMi = true;
                    user.KurumToplamGiris = user.KurumToplamGiris + 1;
                    user.KurumSonGirisTarihi = DateTime.Now;
                    _kurumservice.TUpdate(user);
                }
            }
            else
            {
                Users.Add(Context.ConnectionId, id);
                Kisi? user = _kisiService.TGetByid(id);
                if (user != null)
                {
                    user.UserOnlineMi = true;
                    user.UserSonGirisTarihi = DateTime.Now;
                    user.UserToplamGirisSayisi = user.UserToplamGirisSayisi + 1;
                    _kisiService.TUpdate(user);
                }
                await Clients.All.SendAsync("Users", user);
            }
         
        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            if (Users.TryGetValue(Context.ConnectionId, out int userId))
            {
                Users.Remove(Context.ConnectionId);

                if(userId > 4999999)
                {
                    Kurum? user = _kurumservice.TGetByid(userId);
                    if (user != null)
                    {
                        user.KurumOnlineMi = false;
                 
                        user.KurumSonCikisTarihi = DateTime.Now;
                        _kurumservice.TUpdate(user);
                    }
                }
                else {
                    Kisi? user = _kisiService.TGetByid(userId);
                    if (user != null)
                    {
                        user.UserOnlineMi = false;
                        user.UserSonCikisTarihi = DateTime.Now;
                        _kisiService.TUpdate(user);

                        await Clients.All.SendAsync("Users", user);
                    }
                }
                
            }

            await base.OnDisconnectedAsync(exception);
        }

    }
}
