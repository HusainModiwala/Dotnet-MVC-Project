using MVCAssignment2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVCAssignment2.Repositories
{
    public interface IBookReadingEventRepository
    {
        Task<string> AddBookReadingEvent(BookReadingEventModel model);
        Task<List<BookReadingEventModel>> GetAllBookEvents();
        Task<BookReadingEventModel> GetBookEventByTitle(string title);
        Task<string> EditBookReadingEvent(BookReadingEventModel model);
        Task<List<BookReadingEventModel>> GetBookReadingEventsOfUser(string userId);
        Task<List<BookReadingEventModel>> GetBookReadingEventsWhereUserInvited(string userEmail);
        Task<bool> DeleteEvent(string Title);
    }
}