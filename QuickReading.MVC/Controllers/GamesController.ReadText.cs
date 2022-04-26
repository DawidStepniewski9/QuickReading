using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuickReading.Models.Models.Data;
using QuickReading.Models.Models.Games;
using QuickReading.Models.Models.Games.GuessLetter;
using QuickReading.Models.Models.Games.MakeWord;
using QuickReading.Models.Models.Games.ReadText;
using QuickReading.MVC.Models;
using QuickReading.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace QuickReading.MVC.Controllers
{
    public partial class GamesController : Controller
    {
        public IActionResult ReadText()
        {
            var text = GetRandomUrlBook();
            return View();
        }

        public async Task<IActionResult> ReadTextGame()
        {

            ReadTextModel model = new ReadTextModel();
            string bookText = await _bookApiService.GetText(GetRandomUrlBook());
            bookText = bookText.TruncateLongString(3000)+"...";
            model.BookText = bookText;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EndReadTextGame(GameSubmitModel model)
        {
            int wholeSeconds = model.seconds + model.minutes * 60;

            float score = wholeSeconds;
            //zapisywanie do bazy;

            Exercise exercise = new Exercise();
            exercise.DateOfAdd = DateTime.Now;
            exercise.Score = score;
            exercise.TypeOfGame = Utilities.Enums.TypeOfGame.ReadText;
            exercise.ApplicationUser = await _userManager.GetUserAsync(HttpContext.User);

            _unitOfWork.Exercise.Add(exercise);
            _unitOfWork.Save();

            return View();
        }

        private string GetRandomUrlBook()
        {
            
            List<BookModel> books;
            string path = Path.Combine(_environment.ContentRootPath, "wwwroot/files/json/") + "books.json";
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                books = JsonConvert.DeserializeObject<List<BookModel>>(json);
            }

            int size = books.Count;

            Random rnd = new Random();
            var book = books.ElementAt(rnd.Next(0, size - 1));
            return book.Href;
        }

    }
}
