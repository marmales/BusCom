using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusCom.Controllers
{
    public class ChatController : Controller
    {
        private IChatRepository _chatRepo;
        public ChatController(IChatRepository repoParam)
        {
            _chatRepo = repoParam;
        }
        // GET: Chat
        public ActionResult Index()
        {
            return View();
        }
    }
}