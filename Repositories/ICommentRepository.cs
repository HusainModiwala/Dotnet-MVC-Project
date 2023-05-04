using MVCAssignment2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVCAssignment2.Repositories
{
    public interface ICommentRepository
    {
        Task<List<CommentModel>> GetCommentsForEvent(string title);
        Task<bool> SaveComment(string title, string comment);
    }
}