using Microsoft.AspNetCore.Mvc;
using MVCAssignment2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignment2.Controllers
{
    [Route("[controller]/[action]")]
    public class CommentController : Controller
    {
        private readonly ICommentRepository _commentRepository;
        public CommentController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public async Task<IActionResult> GetCommentsForEvent(string title)
        {
            var data = await _commentRepository.GetCommentsForEvent(title);
            if (data != null)
            {
                return View(data);
            }
            return View("NoComments");
        }

        [HttpPost]
        public async Task<IActionResult> SaveComment(string title, string comment)
        {
            var res = await _commentRepository.SaveComment(title, comment);
            return RedirectToAction("GetBookReadingEventByTitle", "BookReadingEvent", new { title });
        }
    }
}
