using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
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
    [Authorize]
    public partial class GamesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWordsApiService _wordsApiService;
        private readonly ITranslateService _translateService;
        private readonly IHostEnvironment _environment;
        private readonly IBookApiService _bookApiService;


        public GamesController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager,
            IWordsApiService wordsApiService,
            ITranslateService translateService,
            IHostEnvironment environment,
            IBookApiService bookApiService)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _wordsApiService = wordsApiService;
            _translateService = translateService;
            _environment = environment;
            _bookApiService = bookApiService;
        }
        
    }
}
