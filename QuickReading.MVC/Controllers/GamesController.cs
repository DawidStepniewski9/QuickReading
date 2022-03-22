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

        public IActionResult FindLetterGame(int tableSize)
        {
            if (tableSize > 0)
            {
                int arraySize = tableSize;
                int countToSearchLetter = 0;
                char letter;
                FindLetterModel model = new FindLetterModel();
                model.Letter = GetRandomLetter();
                model.ArrayLetter = new char[arraySize, arraySize];
                model.ArraySize = arraySize;

                for (int i = 0; i < arraySize; i++)
                {
                    for (int j = 0; j < arraySize; j++)
                    {
                        letter = GetRandomLetter();
                        model.ArrayLetter[i, j] = letter;

                        if (letter == model.Letter)
                        {
                            countToSearchLetter++;
                        }
                    }
                }

                model.CountSearchLetter = countToSearchLetter;
                return View(model);
            }

            else
                return RedirectToActionPermanent("FindLetter");
        }

        [HttpPost]
        public IActionResult EndFindLetterGame(FindLetterSubmitModel model)
        {
            int wholeSeconds = model.seconds + model.minutes * 60;

            float score = (wholeSeconds / model.numbernumberLetters)*model.arraySize;
            //zapisywanie do bazy;
            return View();
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
