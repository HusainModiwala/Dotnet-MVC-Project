using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCAssignment2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignment2.Data
{
    public class BookReadingEventContext : IdentityDbContext<ApplicationUser>
    {
        public BookReadingEventContext(DbContextOptions<BookReadingEventContext> options)
            : base(options)
        {

        }
        public DbSet<BookReadingEvents> BookReadingEvents { get; set; }
        public DbSet<Comments> Comments { get; set; }
    }
}
