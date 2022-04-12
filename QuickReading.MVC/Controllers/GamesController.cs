using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuickReading.DataAccess.Repository.IRepository;
using QuickReading.Models.Models.Games;
using QuickReading.Models.Models.Games.FindLetter;
using QuickReading.MVC.Models;
using QuickReading.Utilities;
using QuickReading.Utilities.API.Interface;
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
        private readonly IWordsApiService _wordsApiService;
        private readonly ITranslateService _translateService;

        public GamesController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager,
            IWordsApiService wordsApiService,
            ITranslateService translateService)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _wordsApiService = wordsApiService;
            _translateService = translateService;
        }
        
    }
}
