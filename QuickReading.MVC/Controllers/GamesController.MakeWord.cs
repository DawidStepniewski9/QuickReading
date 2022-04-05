using Microsoft.AspNetCore.Mvc;
using QuickReading.Models.Models.Games;
using QuickReading.Models.Models.Games.GuessLetter;
using QuickReading.MVC.Models;
using QuickReading.Utilities;
using System;
using System.Threading.Tasks;

namespace QuickReading.MVC.Controllers
{
    public partial class GamesController : Controller
    {
        public IActionResult MakeWord()
        {
            return View();
        }
    }
}
