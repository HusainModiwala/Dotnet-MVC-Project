using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCAssignment2.Models;
using MVCAssignment2.Repositories;
using MVCAssignment2.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignment2.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _service;
        private readonly IBookReadingEventRepository _bookReadingRepository;

        public HomeController(ILogger<HomeController> logger, IUserService service, IBookReadingEventRepository bookReadingRepository)
        {
            _logger = logger;
            _service = service;
            _bookReadingRepository = bookReadingRepository;
        }
        [Route("~/")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> MyEvents()
        {
            if (_service.IsAuthenticated())
            {
                var allEvents = await _bookReadingRepository.GetBookReadingEventsOfUser(_service.GetUserId());
                return View(allEvents);
            }
            return RedirectToAction("Error");
        }

        [Authorize]
        public async Task<IActionResult> EventsInvitedTo()
        {
            if (_service.IsAuthenticated())
            {
                var allEvents = await _bookReadingRepository.GetBookReadingEventsWhereUserInvited(_service.GetUserEmail());
                return View(allEvents);
            }
            return RedirectToAction("Error");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
