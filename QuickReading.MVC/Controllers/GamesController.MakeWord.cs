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
            string word = await _wordsApiService.GetWord();
            MakeWordModel model = new MakeWordModel();
            model.Word = word;
            model.Words = new List<string>();
            string translationWord = await _translateService.GetTranslation(word);
            model.Translation = translationWord;

            Random r = new Random();

            string mixedWord = new string(translationWord.ToCharArray().
                OrderBy(s => (r.Next(2) % 2) == 0).ToArray());

            model.Words.Add(mixedWord);

            for(int i=0;i< numberOfWords-1;i++)
            {
                model.Words.Add(Randomize.Word(translationWord.Length));
            }

            model.Words.Shuffle();

            return View(model);
        }

    }
}
