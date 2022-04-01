using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuickReading.DataAccess.Repository.IRepository;
using QuickReading.Models.Models.Games.FindLetter;
using QuickReading.MVC.Models;
using QuickReading.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickReading.MVC.Controllers
{
    public partial class GamesController : Controller
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
                    var newPoint = RandomGenerator.GetRandomPoint(tableSize);
                    model.ArrayLetter[newPoint.x, newPoint.y] = model.Letter;
                    countToSearchLetter++;
                }

                model.CountSearchLetter = countToSearchLetter;
                return View(model);
            }

            else
                return RedirectToActionPermanent("FindLetter");
        }

        [HttpPost]
        public async Task<IActionResult> EndFindLetterGame(FindLetterSubmitModel model)
        {
            int wholeSeconds = model.seconds + model.minutes * 60;

            float score = (wholeSeconds / model.numberLetters) *model.arraySize;
            //zapisywanie do bazy;

            Exercise exercise = new Exercise();
            exercise.DateOfAdd = DateTime.Now;
            exercise.Score = score;
            exercise.TypeOfGame = Utilities.Enums.TypeOfGame.FindLetter;
            exercise.ApplicationUser = await _userManager.GetUserAsync(HttpContext.User);

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
