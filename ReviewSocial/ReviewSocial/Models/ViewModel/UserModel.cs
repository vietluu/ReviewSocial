using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ReviewSocial.Models
{
    public partial class UserModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [NotMapped]
        public string RePassword { get; set; }
    }
}
