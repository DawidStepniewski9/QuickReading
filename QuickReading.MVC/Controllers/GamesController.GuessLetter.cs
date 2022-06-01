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
        public IActionResult GuessLetter()
        {
            return View();
        }

        public IActionResult GuessLetterGame(int tableSize)
        {
            int arraySize = tableSize;
            int countToFindLetters = 0;
            GuessLetterModel model = new GuessLetterModel();
            model.ArrayLetter = new string[arraySize, arraySize];
            model.ArraySize = arraySize;

            if (tableSize > 0)
            {
                if(tableSize<10)
                {
                    countToFindLetters = 1;
                    model.CountSearchLetter = 1;
                }
                if (tableSize >= 10 && tableSize<25)
                {
                    countToFindLetters = 3;
                    model.CountSearchLetter = 3;
                }
                if (tableSize >= 25)
                {
                    countToFindLetters = 5;
                    model.CountSearchLetter = 5;
                }

                for (int i = 0; i < arraySize; i++)
                {
                    for (int j = 0; j < arraySize; j++)
                    {
                        if (i == arraySize / 2 && j == arraySize / 2)
                        {
                            model.ArrayLetter[i, j] = "⚫";
                        }
                        //else
                        //    model.ArrayLetter[i, j] = "";
                    }
                }

                for (int i = 0; i < countToFindLetters; i++)
                {
                    RandomPoint p = RandomGenerator.GetRandomPoint(tableSize);
                    while (!CheckAvability(model.ArrayLetter, tableSize, p))
                    {
                        p = RandomGenerator.GetRandomPoint(tableSize);
                    }

                    model.ArrayLetter[p.x, p.y] = GetRandomLetter().ToString();
                }




                return View(model);
            }

            else
                return RedirectToActionPermanent("GuessLetter");
        }

        [HttpPost]
        public async Task<IActionResult> EndGuessLetterGame(GameSubmitModel model)
        {
            int wholeSeconds = model.seconds + model.minutes * 60;

            float score = (wholeSeconds / model.numberLetters) * model.arraySize;
            //zapisywanie do bazy;

            Exercise exercise = new Exercise();
            exercise.DateOfAdd = DateTime.Now;
            exercise.Score = score;
            exercise.TypeOfGame = Utilities.Enums.TypeOfGame.GuessLetter;
            exercise.ApplicationUser = await _userManager.GetUserAsync(HttpContext.User);

            _unitOfWork.Exercise.Add(exercise);
            _unitOfWork.Save();

            return View();
        }

        public bool CheckAvability(string[,] array, int tableSize, RandomPoint p)
        {
            if (p.x == tableSize / 2 && p.y == tableSize / 2)
            {
                return false;
            }

            if (p.x != 0 && p.y != 0 && p.x != tableSize - 1 && p.y != tableSize - 1)
            {
                if (string.IsNullOrEmpty(array[p.x - 1, p.y - 1])
                    && string.IsNullOrEmpty(array[p.x, p.y - 1])
                    && string.IsNullOrEmpty(array[p.x + 1, p.y - 1])
                    && string.IsNullOrEmpty(array[p.x + 1, p.y])
                    && string.IsNullOrEmpty(array[p.x + 1, p.y + 1])
                    && string.IsNullOrEmpty(array[p.x, p.y + 1])
                    && string.IsNullOrEmpty(array[p.x - 1, p.y - 1])
                    && string.IsNullOrEmpty(array[p.x, p.y - 1]))
                    return true;
                else
                    return false;
            }
            else
            {
                if (p.x == 0 && p.y == 0)
                {
                    if (string.IsNullOrEmpty(array[p.x, p.y + 1])
                    && string.IsNullOrEmpty(array[p.x - 1, p.y])
                    && string.IsNullOrEmpty(array[p.x + 1, p.y + 1]))
                        return true;
                    else
                        return false;
                }
                if (p.x == 0 && p.y == tableSize - 1)
                {
                    if (string.IsNullOrEmpty(array[p.x, p.y + 1])
                    && string.IsNullOrEmpty(array[p.x - 1, p.y])
                    && string.IsNullOrEmpty(array[p.x + 1, p.y + 1]))
                        return true;
                    else
                        return false;
                }

                if (p.x == tableSize-1 && p.y == 0)
                {
                    if (string.IsNullOrEmpty(array[p.x-1, p.y])
                    && string.IsNullOrEmpty(array[p.x - 1, p.y+1])
                    && string.IsNullOrEmpty(array[p.x, p.y + 1]))
                        return true;
                    else
                        return false;
                }
                if (p.x == tableSize - 1 && p.y == tableSize-1)
                {
                    if (string.IsNullOrEmpty(array[p.x - 1, p.y])
                    && string.IsNullOrEmpty(array[p.x - 1, p.y])
                    && string.IsNullOrEmpty(array[p.x-1, p.y -1]))
                        return true;
                    else
                        return false;
                }
                if(p.x==0 && p.y!=0 && p.y!= tableSize - 1)
                {
                    if (string.IsNullOrEmpty(array[p.x, p.y - 1])
                    && string.IsNullOrEmpty(array[p.x + 1, p.y - 1])
                    && string.IsNullOrEmpty(array[p.x + 1, p.y])
                    && string.IsNullOrEmpty(array[p.x + 1, p.y + 1])
                    && string.IsNullOrEmpty(array[p.x, p.y + 1])
                    && string.IsNullOrEmpty(array[p.x, p.y - 1]))
                        return true;
                    else
                        return false;
                }
                if (p.y == 0 && p.x != 0 && p.x != tableSize-1)
                {
                    if (string.IsNullOrEmpty(array[p.x + 1, p.y])
                   && string.IsNullOrEmpty(array[p.x + 1, p.y + 1])
                   && string.IsNullOrEmpty(array[p.x, p.y + 1]))
                        return true;
                    else
                        return false;
                }
                if (p.y == tableSize-1 && p.x != 0 && p.x != tableSize - 1)
                {
                    if (string.IsNullOrEmpty(array[p.x - 1, p.y - 1])
                    && string.IsNullOrEmpty(array[p.x, p.y - 1])
                    && string.IsNullOrEmpty(array[p.x + 1, p.y - 1])
                    && string.IsNullOrEmpty(array[p.x + 1, p.y])
                    && string.IsNullOrEmpty(array[p.x - 1, p.y - 1])
                    && string.IsNullOrEmpty(array[p.x, p.y - 1]))
                        return true;
                    else
                        return false;
                }
                if (p.x == tableSize - 1 && p.y != 0 && p.y != tableSize - 1)
                {
                    if (string.IsNullOrEmpty(array[p.x - 1, p.y - 1])
                    && string.IsNullOrEmpty(array[p.x, p.y - 1])
                    && string.IsNullOrEmpty(array[p.x, p.y + 1])
                    && string.IsNullOrEmpty(array[p.x - 1, p.y - 1])
                    && string.IsNullOrEmpty(array[p.x, p.y - 1]))
                        return true;
                    else
                        return false;
                }
            }

            return false;
            
        }

    }
}
