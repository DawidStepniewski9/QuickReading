using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuickReading.DataAccess.Repository.IRepository;
using QuickReading.Models.Models.Games.FindLetter;
using QuickReading.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickReading.MVC.Controllers
{
    public class GamesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;

        public GamesController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }
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

                if(countToSearchLetter==0)
                {
                    Random random = new Random();
                    int x = random.Next(0, tableSize - 1);
                    int y = random.Next(0, tableSize - 1);
                    model.ArrayLetter[x, y] = model.Letter;
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

            float score = (wholeSeconds / model.numberLetters) *model.arraySize;
            //zapisywanie do bazy;

            Exercise exercise = new Exercise();
            exercise.DateOfAdd = DateTime.Now;
            exercise.Score = score;
            exercise.TypeOfGame = Utilities.Enums.TypeOfGame.FindLetter;

            _unitOfWork.Exercise.Add(exercise);
            _unitOfWork.Save();

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
