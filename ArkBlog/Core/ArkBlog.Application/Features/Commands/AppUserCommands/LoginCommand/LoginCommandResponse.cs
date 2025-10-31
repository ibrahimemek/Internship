using ArkBlog.Application.Dtos;
using ArkBlog.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkBlog.Application.Features.Commands.AppUserCommands.LoginCommand
{
    
    public class LoginCommandResponse
    {
        public TokenDto Token { get; set; }
        public AppUser User { get; set; } // Add this
        public bool Succeeded { get; set; }
    }

}
