using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCAssignment2.Models;
using MVCAssignment2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignment2.Controllers
{
    [Route("[controller]/[action]")]
    public class BookReadingEventController : Controller
    {
        private readonly IBookReadingEventRepository _bookreadingrepository;
        public BookReadingEventController(IBookReadingEventRepository bookreadingrepository)
        {
            _bookreadingrepository = bookreadingrepository ;
        }

        public List<string> GetStartTimeList()
        {
            return new List<string>()
            {
                "00:00", "01:00", "02:00", "03:00", "04:00","05:00", "06:00","07:00", "08:00",
                "09:00", "10:00", "11:00", "12:00", "13:00","14:00", "15:00","16:00", "17:00",
                "18:00", "19:00", "20:00","21:00", "22:00","23:00"
            };
        }

        public async Task<ViewResult> GetAllBookReadingEvents()
        {
            var data = await _bookreadingrepository.GetAllBookEvents();
            return View(data);
        }
        public async Task<ViewResult> PastEvent()
        {
            var data = await _bookreadingrepository.GetAllBookEvents();
            return View(data);
        }
        public async Task<ViewResult> FutureEvent()
        {
            var data = await _bookreadingrepository.GetAllBookEvents();
            return View(data);
        }

        public async Task<ViewResult> GetBookReadingEventByTitle(string title)
        {
            var data = await _bookreadingrepository.GetBookEventByTitle(title);
            var email = data.InviteByMail != null;
            var m = email;
            return View(data);
        }

        [Authorize]
        public ViewResult AddBookReadingEvent(bool isSuccess = false, string booktitle = "")
        {
            var model = new BookReadingEventModel()
            {
                StartTime = "00:00"
            };
            ViewBag.startTime = new SelectList(GetStartTimeList());
            ViewBag.isSuccess = isSuccess;
            ViewBag.booktitle = booktitle;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddBookReadingEvent(BookReadingEventModel bookReadingEventModel)
        {
            if (ModelState.IsValid)
            {
                string res = await _bookreadingrepository.AddBookReadingEvent(bookReadingEventModel);
                if (res != null)
                {
                    return RedirectToAction(nameof(AddBookReadingEvent), new { isSuccess = true, booktitle = res });
                }
            }
            ViewBag.startTime = new SelectList(GetStartTimeList());
            return View();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> EditBookReadingEvent(string title, bool isSuccess = false)
        {
            var model = await _bookreadingrepository.GetBookEventByTitle(title);
            ViewBag.startTime = new SelectList(GetStartTimeList());
            ViewBag.isSuccess = isSuccess;
            ViewBag.booktitle = title;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditBookReadingEvent(BookReadingEventModel bookReadingEventModel)
        {
            if (ModelState.IsValid)
            {
                string res = await _bookreadingrepository.EditBookReadingEvent(bookReadingEventModel);
                if (res != null)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            ViewBag.startTime = new SelectList(GetStartTimeList());
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> DeleteEvent(string title)
        {
            var res = await _bookreadingrepository.DeleteEvent(title);
            if (res)
            {
                return RedirectToAction("Index", "Home");
            }
            return View("Error");
        }
    }
}
