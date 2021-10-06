

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wedding.Core.Models
{
    public class User : IdentityUser
    {
        public string Avatar { get; set; }
        [MaxLength(300)]
        public string FirstName { get; set; }
        [MaxLength(300)]
        public string LastName { get; set; }
        public ICollection<Article> Articles { get; set; }

        public bool IsEmployee { get; set; } = false;

    }
}
