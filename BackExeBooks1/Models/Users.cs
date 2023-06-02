using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BackExeBooks1.Models
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string UserLogin { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int Money { get; set; }
        [Required]
        public int role { get; set; }

    }
}