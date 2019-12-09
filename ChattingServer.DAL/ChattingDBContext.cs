using ChattingServer.DAL.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChattingServer.DAL
{
    public class ChattingDBContext : IdentityDbContext<User,Role,Guid>
    {
        public ChattingDBContext(DbContextOptions<ChattingDBContext> options) : base(options) {
            Database.EnsureCreated();
        }

    }
}

