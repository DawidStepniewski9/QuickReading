using Microsoft.AspNetCore.Mvc;
using QuickReading.Models.Models.Games;
using QuickReading.Models.Models.Games.GuessLetter;
using QuickReading.Models.Models.Games.MakeWord;
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
        public IActionResult MakeWord()
        {
            return View();
        }

        public async Task<IActionResult> MakeWordGame(int numberOfWords)
        {
            
            MakeWordModel model = new MakeWordModel();
            model.GroupsOfWords = await PrepareListWords(numberOfWords);
            model.NumberOfWords = numberOfWords;


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EndMakeWordGame(GameSubmitModel model)
        {
            int wholeSeconds = model.seconds + model.minutes * 60;

            float score = (wholeSeconds / model.arraySize) - model.numberLetters;
            //zapisywanie do bazy;

            Exercise exercise = new Exercise();
            exercise.DateOfAdd = DateTime.Now;
            exercise.Score = score;
            exercise.TypeOfGame = Utilities.Enums.TypeOfGame.MakeWords;
            exercise.ApplicationUser = await _userManager.GetUserAsync(HttpContext.User);

            _unitOfWork.Exercise.Add(exercise);
            _unitOfWork.Save();

            return View();
        }

        private async Task<List<MakeWordList>> PrepareListWords(int size)
        {
            string word, translationWord, mixedWord;
            Random r = new Random();
            List<MakeWordList> result = new List<MakeWordList>();

            for(int i=0;i<5;i++)
            {
                MakeWordList list = new MakeWordList();
                List<MakeWordItemModel> groupList = new List<MakeWordItemModel>();

                word = await _wordsApiService.GetWord();
                translationWord = await _translateService.GetTranslation(word);
                list.AnswerWord = translationWord.ToLower();
                mixedWord = new string(translationWord.ToCharArray().
                OrderBy(s => (r.Next(2) % 2) == 0).ToArray());

                groupList.Add(new MakeWordItemModel(mixedWord.ToUpper(),true));

                for (int j = 0; j < size - 1; j++)
                {
                    groupList.Add(new MakeWordItemModel(Randomize.Word(translationWord.Length),false));
                }

                groupList.Shuffle();

                list.list = groupList;

                result.Add(list);

            }

            return result;
        }

    }
}
