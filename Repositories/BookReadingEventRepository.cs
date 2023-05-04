using Microsoft.EntityFrameworkCore;
using MVCAssignment2.Data;
using MVCAssignment2.Models;
using MVCAssignment2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignment2.Repositories
{
    public class BookReadingEventRepository : IBookReadingEventRepository
    {
        private readonly BookReadingEventContext _context;
        private readonly IUserService _userService;
        public BookReadingEventRepository(BookReadingEventContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }
        public async Task<string> AddBookReadingEvent(BookReadingEventModel model)
        {
            var newBookEvent = new BookReadingEvents()
            {
                Title = model.Title,
                Date = model.Date,
                Location = model.Location,
                StartTime = model.StartTime.ToString(),
                Type = model.Type,
                Duration = model.Duration,
                Description = model.Description,
                Other = model.Other,
                InviteByMail = model.InviteByMail,
                Organizer = _userService.GetUserId()
            };
            bool flag = false;
            if (newBookEvent.Type != null && (newBookEvent.Type.Trim().ToLower().Equals("private") || newBookEvent.Type.Trim().ToLower().Equals("public")))
            {
                flag = true;
                newBookEvent.Type = newBookEvent.Type.Trim().ToLower();
                newBookEvent.Type = char.ToUpper(newBookEvent.Type[0]) + newBookEvent.Type.Substring(1);
            }
            if (flag == false) { newBookEvent.Type = "Public"; }

            await _context.BookReadingEvents.AddAsync(newBookEvent);
            await _context.SaveChangesAsync();
            return newBookEvent.Title;
        }
        public async Task<string> EditBookReadingEvent(BookReadingEventModel model)
        {
            var BookEvent = await _context.BookReadingEvents.FindAsync(model.Title);
            if (BookEvent != null)
            {
                BookEvent.Date = model.Date;
                BookEvent.Location = model.Location;
                BookEvent.StartTime = model.StartTime.ToString();
                BookEvent.Type = model.Type;
                BookEvent.Duration = model.Duration;
                BookEvent.Description = model.Description;
                BookEvent.Other = model.Other;
                BookEvent.InviteByMail = model.InviteByMail;
                BookEvent.Organizer = _userService.GetUserId();
            }
            
                
            bool flag = false;
            if (BookEvent.Type != null && (BookEvent.Type.Trim().ToLower().Equals("Private") || BookEvent.Type.Trim().ToLower().Equals("Public")))
            {
                flag = true;
                BookEvent.Type = BookEvent.Type.Trim().ToLower();
                BookEvent.Type = char.ToUpper(BookEvent.Type[0]) + BookEvent.Type.Substring(1);
            }
            if (flag == false) { BookEvent.Type = "Public"; }

            await _context.SaveChangesAsync();
            return BookEvent.Title;
        }

        public async Task<List<BookReadingEventModel>> GetAllBookEvents()
        {
            List<BookReadingEventModel> allevents = new List<BookReadingEventModel>();
            var data = await _context.BookReadingEvents.ToListAsync();
            if (data?.Any() == true)
            {
                foreach (BookReadingEvents bv in data)
                {
                    allevents.Add(new BookReadingEventModel()
                    {
                        Title = bv.Title,
                        Date = bv.Date,
                        Location = bv.Location,
                        StartTime = bv.StartTime,
                        Type = bv.Type,
                        Duration = bv.Duration,
                        Description = bv.Description,
                        Other = bv.Other,
                        InviteByMail = bv.InviteByMail
                    });
                }

            }
            return allevents;
        }
        public async Task<BookReadingEventModel> GetBookEventByTitle(string title)
        {
            var bookeventdata = await _context.BookReadingEvents.FindAsync(title);
            if (bookeventdata == null)
            {
                return null;
            }
            return new BookReadingEventModel()
            {
                Title = bookeventdata.Title,
                Date = bookeventdata.Date.Date,
                Location = bookeventdata.Location,
                StartTime = bookeventdata.StartTime,
                Type = bookeventdata.Type,
                Duration = bookeventdata.Duration,
                Description = bookeventdata.Description,
                Other = bookeventdata.Other,
                InviteByMail = bookeventdata.InviteByMail,
                Organizer = bookeventdata.Organizer
            };
        }

        public async Task<List<BookReadingEventModel>> GetBookReadingEventsOfUser(string userId)
        {
            List<BookReadingEventModel> allevents = new List<BookReadingEventModel>();
            var data = await _context.BookReadingEvents.Where(x => x.Organizer.Equals(userId)).OrderByDescending(x => x.Date).ToListAsync();
            if (data?.Any() == true)
            {
                foreach (BookReadingEvents bv in data)
                {
                    allevents.Add(new BookReadingEventModel()
                    {
                        Title = bv.Title,
                        Date = bv.Date,
                        Location = bv.Location,
                        StartTime = bv.StartTime,
                        Type = bv.Type,
                        Duration = bv.Duration,
                        Description = bv.Description,
                        Other = bv.Other,
                        InviteByMail = bv.InviteByMail
                    });
                }

            }
            return allevents;
        }

        public async Task<List<BookReadingEventModel>> GetBookReadingEventsWhereUserInvited(string userEmail)
        {
            List<BookReadingEventModel> allevents = new List<BookReadingEventModel>();
            var data = await _context.BookReadingEvents.ToListAsync();
            if (data?.Any() == true)
            {
                foreach (BookReadingEvents bv in data)
                {
                    if(verify(bv, userEmail))
                    {
                        allevents.Add(new BookReadingEventModel()
                        {
                            Title = bv.Title,
                            Date = bv.Date,
                            Location = bv.Location,
                            StartTime = bv.StartTime,
                            Type = bv.Type,
                            Duration = bv.Duration,
                            Description = bv.Description,
                            Other = bv.Other,
                            InviteByMail = bv.InviteByMail
                        });
                    }
                    
                }

            }
            return allevents;
        }

        public async Task<bool> DeleteEvent(string Title)
        {
            var obj =  await _context.BookReadingEvents.FindAsync(Title);
            if (obj != null)
            {
                _context.BookReadingEvents.Remove(obj);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        private bool verify(BookReadingEvents x, string userEmail)
        {
            string allinvitees = x.InviteByMail;
            if (allinvitees == null)
            {
                return false;
            }
            string[] invitee = allinvitees.Split(",");
            foreach(string iv in invitee)
            {
                if (iv.Equals(userEmail))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
