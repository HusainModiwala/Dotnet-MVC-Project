using Microsoft.EntityFrameworkCore;
using MVCAssignment2.Data;
using MVCAssignment2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignment2.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly BookReadingEventContext _context;
        public CommentRepository(BookReadingEventContext context)
        {
            _context = context;
        }
        public async Task<List<CommentModel>> GetCommentsForEvent(string title)
        {
            List<CommentModel> result = new List<CommentModel>();
            var allComments = await _context.Comments.Where(x => x.EventTitle.Equals(title)).ToListAsync();
            
            if (allComments != null)
            {
                foreach (Comments comment in allComments) {
                    result.Add(new CommentModel()
                    {
                        Id = comment.Id,
                        Comment = comment.Comment,
                        EventTitle = comment.EventTitle
                    }); 
                }
                return result;
            }
            return null;
        }

        public async Task<bool> SaveComment(string title, string comment)
        {
            Comments obj = new Comments() { Comment = comment, EventTitle = title };
            await _context.Comments.AddAsync(obj);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
