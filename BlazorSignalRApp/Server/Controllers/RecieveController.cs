using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Client;


namespace BlazorSignalRApp.Server.Controllers
{
    public class ReceiveController : Controller
    {

        private HubConnection _hubConnection;
        private List<string> _messages = new List<string>();
        private string lane;
        private string _messageInput;
        Task Send() =>
       _hubConnection.SendAsync("SendMessage", lane, _messageInput);
       
        
        // GET: Home
        public  ActionResult Index(string _lane, string name, string ph)
        {
            lane = _lane;
            _messageInput = name + " "+ ph;

            _hubConnection = new HubConnectionBuilder()
            //.WithUrl(NavigationManager.ToAbsoluteUri("/chatHub"))
            .WithUrl("https://localhost:44376/chatHub")
            .Build();

             _hubConnection.StartAsync();

            Send();
            Console.WriteLine(lane + name + ph);

            return View();
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}