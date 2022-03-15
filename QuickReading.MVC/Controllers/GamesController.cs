using Microsoft.AspNetCore.Mvc;
using QuickReading.Models.Models.Games.FindLetter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickReading.MVC.Controllers
{
    public class GamesController : Controller
    {
        public IActionResult FindLetter()
        {
            return View();
        }

        public IActionResult FindLetterGame()
        {
            int arraySize = 20;
            FindLetterModel model = new FindLetterModel();
            model.Letter = GetRandomLetter();
            model.ArrayLetter = new char[arraySize, arraySize];
            model.ArraySize = arraySize;

            for(int i=0;i< arraySize; i++)
            {
                for(int j=0;j<arraySize;j++)
                {
                    model.ArrayLetter[i, j] = GetRandomLetter();
                }
            }

            return View(model);
        }

        private char GetRandomLetter()
        {
            Random random = new Random();

            int ascii_index = random.Next(65, 91);
            char result = Convert.ToChar(ascii_index);
            
            return result;
        }
    }
}
