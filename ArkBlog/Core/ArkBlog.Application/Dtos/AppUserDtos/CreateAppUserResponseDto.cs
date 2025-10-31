using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkBlog.Application.Dtos.AppUserDtos
{
    public class CreateAppUserResponseDto
    {
        public bool Succeeded { get; set; }

        public string Message { get; set; }
    }
}
