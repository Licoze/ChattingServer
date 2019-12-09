using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChattingServer.DAL.Models.Users
{
    public class Role:IdentityRole<Guid>
    {
    }
}
