using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Dtos
{
    public class UserRegisterDto
    {
        public UserRegisterDto()
        {
            CreatedDate = DateTime.Today;
        }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserRole { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
