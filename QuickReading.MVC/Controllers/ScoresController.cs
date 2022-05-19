using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuickReading.DataAccess.Repository.IRepository;
using QuickReading.Models.Models.Scores;
using QuickReading.MVC.Models;
using QuickReading.Utilities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickReading.MVC.Controllers
{
    [Authorize]
    public class ScoresController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;

        public ScoresController(IUnitOfWork unitOfWork,
            UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Scores(TypeOfGame typeOfGame)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var scoreList = _unitOfWork.Exercise.GetAll()
                .Where(e => e.TypeOfGame == typeOfGame && e.ApplicationUser==user).OrderBy(o=>o.DateOfAdd);

            ScoresModel model = new ScoresModel();

            model.Text = typeOfGame.ToString();
            var labels = scoreList.Select(s => "\""+s.DateOfAdd.ToShortDateString()+"\"").ToList();
            model.Labels = string.Join(", ", labels); //"08.10.2022", "08.10.2022"
            ViewBag.Exponate =
                Newtonsoft.Json.JsonConvert.SerializeObject(labels);
            var data = scoreList.Select(s => s.Score).ToList();
            model.Data = string.Join(", ", data);

            return View(model);
        }
    }
}
